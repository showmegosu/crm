using System;
using System.IO;
using System.Web.Http.ExceptionHandling;

namespace Logger
{
    public sealed class Logger : ExceptionLogger, ILogger
    {
        private readonly string _logPath;

        public Logger(string logPath)
        {
            _logPath = logPath;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            var exception = context.Exception;
            using (var writer =
                new StreamWriter(_logPath + "Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:MM:ss") + " [Exception] " + exception);
            }
        }

        public void LogWarning(string warningMessage)
        {
            using (var writer =
                new StreamWriter(_logPath + "Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:MM:ss") + " [Warning] " + warningMessage);
            }
        }

        public void LogInfo(string infoMessage)
        {
            using (var writer =
                new StreamWriter(_logPath + "Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:MM:ss") + " [Info] " + infoMessage);
            }
        }
    }
}