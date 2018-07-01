using System;
using System.IO;

namespace Logger
{
    public sealed class Logger
    {
        private readonly string _logPath;

        private Logger(string logPath)
        {
            _logPath = logPath;
        }

        public static Logger Instance(string logPath) => new Logger(logPath);

        public void LogException(string exceptionMessage)
        {
            using (StreamWriter writer =
                new StreamWriter(_logPath + "Log" + DateTime.Now.ToString("YYYYMMDD") + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:MM:SS" + " [Exception] " + exceptionMessage));
            }
        }

        public void LogWarning(string warningMessage)
        {
            using (StreamWriter writer =
                new StreamWriter(_logPath + "Log" + DateTime.Now.ToString("YYYYMMDD") + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:MM:SS" + " [Warning] " + warningMessage));
            }
        }

        public void LogInfo(string infoMessage)
        {
            using (StreamWriter writer =
                new StreamWriter(_logPath + "Log" + DateTime.Now.ToString("YYYYMMDD") + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:MM:SS" + " [Info] " + infoMessage));
            }
        }
    }
}