
using Newtonsoft.Json;
using System.Net;
using WebApiSchool.Exceptions;
using WebApiSchool.MyLogger;

namespace WebApiSchool.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILoggerManager _logger;
        public ExceptionMiddleware(ILoggerManager logger) => _logger = logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                var routeData = context.GetRouteData();

                string controller = routeData.Values["action"] as string ?? string.Empty;
                string action = routeData.Values["controller"] as string ?? string.Empty;

                var innerExceptionMessage = e.InnerException == null ? string.Empty : e.InnerException.Message;
                _logger.LogError($"{e.Message} - innerExceptionMessage: {innerExceptionMessage}", controller, action);

                await HandleExceptionAsync(context, e);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "application/json";

            if (exception is UnauthorizedAccessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = "Unauthorized" }));
            }

            if (exception is ValidationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = exception.Message }));
            }

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error. Please try again later."
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

    }
}
