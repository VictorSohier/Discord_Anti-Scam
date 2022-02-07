using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord_Anti_scam.Core.Enums;

namespace Discord_Anti_scam.Infrastructure.Models.Logging
{
    public class FileLogger : StreamLogger
    {
		/// <summary>
		/// FileLogger constructor
		/// </summary>
		/// <param name="filePath">The file for which the log is saved to</param>
		/// <param name="encoding">The encoder for output encoding. Default is UTF8</param>
		/// <param name="format">The format of the output
		/// - {0} = DateTimeOffset.UtcNow
		/// - {1} = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
		/// - {2} = logLevel.Name
		/// - {3} = message</param>
        public FileLogger(
			string filePath,
			Encoding encoding = null,
			string format = "[{2}] [{1}] {3}") : base(new FileStream(filePath, FileMode.Append), encoding, format.Replace("{3}", "{5}"), ColorModeEnum.RGB)
		{
			
		}
    }
}