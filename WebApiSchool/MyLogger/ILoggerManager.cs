namespace WebApiSchool.MyLogger
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message, string controllerName, string actionName = null);
        void LogDebug(string message, string controllerName, string actionName = null);
        void LogError(string message, string controllerName, string actionName = null);
    }
}
