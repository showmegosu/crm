using System;
using System.IO;
using System.Text;

namespace Logger
{
    public sealed class Logger
    {
        private readonly string _logPath;

        public Logger(string logPath)
        {
            _logPath = logPath;
            var directory = new DirectoryInfo(logPath);
            
        }

        public void LogException(Exception exception)
        {
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