using System.Web.Http.ExceptionHandling;

namespace Logger
{
    public interface ILogger
    {
        void Log(ExceptionLoggerContext context);
        void LogWarning(string warningMessage);
        void LogInfo(string infoMessage);
    }
}