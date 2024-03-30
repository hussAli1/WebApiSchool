namespace WebApiSchool.MyLogger
{
    public class LogToFile : IMyLogger
    {
        public void LogError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
