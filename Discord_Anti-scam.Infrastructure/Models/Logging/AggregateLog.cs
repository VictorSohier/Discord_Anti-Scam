using System.Collections.Generic;
using Discord_Anti_scam.Core.Enums;
using Discord_Anti_scam.Core.Interfaces.Logging;

namespace Discord_Anti_scam.Infrastructure.Models.Logging
{
    public class AggregateLog : IAggregateLog
    {
        public IEnumerable<ILogger> Loggers { get; }

		public AggregateLog(params ILogger[] loggers)
		{
			Loggers = loggers;
		}

		public AggregateLog(IEnumerable<ILogger> loggers)
		{
			Loggers = loggers;
		}

		public async Task LogAsync(LogLevelEnum logLevel, string message)
		{
			foreach (ILogger logger in Loggers)
				await logger.LogAsync(logLevel, message);
		}

		public void Log(LogLevelEnum logLevel, string message)
		{
			foreach (ILogger logger in Loggers)
				logger.Log(logLevel, message);
		}
    }
}