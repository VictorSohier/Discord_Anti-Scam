using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord_Anti_scam.Core.Enums;

namespace Discord_Anti_scam.Core.Interfaces.Logging
{
    public interface ILogger
    {
		/// <summary>
		/// Outputs a log message to the designated output
		/// </summary>
		/// <param name="logLevel">The log alarm level</param>
		/// <param name="message">The log message</param>
        public Task LogAsync(LogLevelEnum logLevel, string message);
        public void Log(LogLevelEnum logLevel, string message);
    }
}