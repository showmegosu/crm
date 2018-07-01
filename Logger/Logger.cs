using System;
using System.IO;

namespace Logger
{
    public sealed class Logger
    {
        private readonly string _logPath;

        public Logger(string logPath)
        {
            _logPath = logPath;
        }

        public void LogException(Exception exception)
        {
            using (StreamWriter writer =
                new StreamWriter(_logPath + "Log" + DateTime.Now.ToString("YYYYMMDD") + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:MM:SS" + " [Exception] " + exception));
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