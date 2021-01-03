using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Brokers.Logging
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger logger;

        public LoggingBroker(ILogger logger) => this.logger = logger;

        public void LogCritical(Exception exception) =>
            this.logger.LogCritical(exception, exception.Message);

        public void LogDebug(string message) => this.logger.LogDebug(message);

        public void LogError(Exception exception) =>
            this.logger.LogError(exception, exception.Message);

        public void LogInformation(string message) => this.logger.LogInformation(message);

        public void LogTrace(string message) => this.logger.LogTrace(message);

        public void LogWarning(string message) => this.logger.LogWarning(message);
    }
}
