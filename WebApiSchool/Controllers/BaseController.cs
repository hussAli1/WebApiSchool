using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSchool.Models;

namespace WebApiSchool.Controllers
{

    public class BaseController : ControllerBase
    {
        protected IActionResult CreateErrorResponse(string message, object data = null)
        {
            var responseModel = new ResponseModel
            {
                Data = data,
                Status = "Error",
                Message = message
            };

            return BadRequest(responseModel);
        }
    }
}
