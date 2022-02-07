using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord_Anti_scam.Core.Enums;

namespace Discord_Anti_scam.Core.Interfaces.Logging
{
    public interface IAggregateLog
    {
		public Task LogAsync(LogLevelEnum logLevel, string message);
		public void Log(LogLevelEnum logLevel, string message);
    }
}