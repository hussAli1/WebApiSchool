using NLog;

namespace WebApiSchool.MyLogger
{
    public class LoggerManager : ILoggerManager
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {
        }

        public void LogDebug(string message, string controllerName, string? actionName = null) => logger.Debug($"{controllerName}.{actionName}: {message}");

        public void LogError(string message, string controllerName, string? actionName = null) => logger.Error($"{controllerName}.{actionName}: {message}");

        public void LogInfo(string message) => logger.Info(message);

        public void LogWarn(string message, string controllerName, string? actionName = null) => logger.Warn($"{controllerName}.{actionName}: {message}");
    }
}
