﻿using System.Configuration;
using Logger;
using Xunit;

namespace LoggerTets
{
    public class LoggerTests
    {
        private readonly ILogger _logger;

        public LoggerTests()
        {
            var logPath = ConfigurationManager.ConnectionStrings["TestLogPath"].ConnectionString;
            _logger = new Logger.Logger(logPath);
        }

        [Fact]
        public void LogInfo_Message_LoggerSuccessfully()
        {
            _logger.LogInfo("Log this info message");
            Assert.True(true);
        }
    }
}