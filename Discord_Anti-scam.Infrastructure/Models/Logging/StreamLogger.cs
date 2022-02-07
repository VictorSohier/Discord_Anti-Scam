using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord_Anti_scam.Core.Enums;
using Discord_Anti_scam.Core.Interfaces.Logging;

namespace Discord_Anti_scam.Infrastructure.Models
{
    public class StreamLogger : ILogger
    {
        protected Stream Stream { get; }
		protected Encoding Encoding { get; }
		protected string Format { get; }
		protected ColorModeEnum ColorMode { get; }

		/// <summary>
		/// Creates a stream logger
		/// </summary>
		/// <param name="stream">The stream to output to</param>
		/// <param name="encoding">The encoder for output encoding. Default is UTF8</param>
		/// <param name="format">The format of the output
		/// - {0} = DateTimeOffset.UtcNow
		/// - {1} = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
		/// - {2} = logLevel.Name
		/// - {3} = logLevel foregraound ANSI marker (accessible only to ascii compatible streams)
		/// - {4} = logLevel background ANSI marker (accessible only to ascii compatible streams)
		/// - {5} = message</param>
		/// <param name="colorMode">The mode by which ANSI colors are displayed. Default is 16 color.</param>
		public StreamLogger(Stream stream,
			Encoding encoding = null,
			string format = "[{2}] [{1}] {5}\n",
			ColorModeEnum colorMode = null)
		{
			Stream = stream;
			Encoding = encoding ?? Encoding.UTF8;
			Format = stream.GetType() == typeof(FileStream)
				? format.Replace("{3}", "").Replace("{4}", "")
				: format;
			ColorMode = colorMode  ?? ColorModeEnum.TERMINAL_16_COLOR;
		}

		public async Task LogAsync(LogLevelEnum logLevel, string message)
		{
			byte[] data = Encoding.GetBytes(string.Format(Format,
				DateTimeOffset.UtcNow,
				DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
				logLevel.Name,
				ColorMode == ColorModeEnum.RGB
				? $"\u001b[38;2;{logLevel.FgColor.R};{logLevel.FgColor.G};{logLevel.FgColor.B}m"
				: ColorMode == ColorModeEnum.ANSI_256_COLOR
					? $"\u001b[38;5;{logLevel.ANSI256FgColor}m"
					: $"\u001b[{logLevel.FgConsoleColor + ((int) logLevel.FgConsoleColor > 7 ? 82 : 30)}m",
				ColorMode == ColorModeEnum.RGB
				? $"\u001b[38;2;{logLevel.BgColor.R};{logLevel.BgColor.G};{logLevel.BgColor.B}m"
				: ColorMode == ColorModeEnum.ANSI_256_COLOR
					? $"\u001b[38;5;{logLevel.ANSI256BgColor}m"
					: $"\u001b[{logLevel.BgConsoleColor + ((int) logLevel.BgConsoleColor > 7 ? 82 : 30)}m",
				message
				));
			await Stream.WriteAsync(data);
			await Stream.FlushAsync();
		}

		public void Log(LogLevelEnum logLevel, string message)
		{
			byte[] data = Encoding.GetBytes(string.Format(Format,
				DateTimeOffset.UtcNow,
				DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
				logLevel.Name,
				ColorMode == ColorModeEnum.RGB
				? $"\u001b[38;2;{logLevel.FgColor.R};{logLevel.FgColor.G};{logLevel.FgColor.B}m"
				: ColorMode == ColorModeEnum.ANSI_256_COLOR
					? $"\u001b[38;5;{logLevel.ANSI256FgColor}m"
					: $"\u001b[{logLevel.FgConsoleColor + ((int) logLevel.FgConsoleColor > 7 ? 83 : 30)}m",
				ColorMode == ColorModeEnum.RGB
				? $"\u001b[48;2;{logLevel.BgColor.R};{logLevel.BgColor.G};{logLevel.BgColor.B}m"
				: ColorMode == ColorModeEnum.ANSI_256_COLOR
					? $"\u001b[48;5;{logLevel.ANSI256BgColor}m"
					: $"\u001b[{logLevel.BgConsoleColor + ((int) logLevel.BgConsoleColor > 7 ? 93 : 40)}m",
				message
				));
			Stream.Write(data);
			Stream.Flush();
		}
    }
}