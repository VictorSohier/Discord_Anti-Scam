using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace Discord_Anti_scam.Core.Enums
{
    public class LogLevelEnum : SmartEnum<LogLevelEnum, byte>
    {
		public static readonly LogLevelEnum INFO = new("INFO", 0, Color.Black, Color.Blue);
		public static readonly LogLevelEnum WARNING = new("WARN", 1, Color.Black, Color.Yellow);
		public static readonly LogLevelEnum ERROR = new("ERR", 2, Color.Black, Color.Red);

		public Color FgColor { get; set; } = Color.White;
		public Color BgColor { get; set; } = Color.Black;
		public byte ANSI256FgColor { get; set; } = 15;
		public byte ANSI256BgColor { get; set; } = 0;
		public ConsoleColor FgConsoleColor { get; set; } = ConsoleColor.White;
		public ConsoleColor BgConsoleColor { get; set; } = ConsoleColor.Black;

        private LogLevelEnum(string name, byte value) : base(name, value)
		{

		}

        private LogLevelEnum(string name, byte value, Color fg) : base(name, value)
		{
			FgColor = fg;
			ANSI256FgColor = (byte) (Math.Floor(fg.B/(128m/3) + fg.G/(128m/3) * 5 + fg.R/(128m/3) * 30) + 16);
			if (fg.R > 127)
			{
				if (fg.G > 127)
				{
					if (fg.B > 127)
						FgConsoleColor = ConsoleColor.White;
					else
						FgConsoleColor = ConsoleColor.Yellow;
				}
				else
				{
					if (fg.B > 127)
						FgConsoleColor = ConsoleColor.Magenta;
					else
						FgConsoleColor = ConsoleColor.Red;
				}
			}
			else
			{
				if (fg.G > 127)
				{
					if (fg.B > 127)
						FgConsoleColor = ConsoleColor.Cyan;
					else
						FgConsoleColor = ConsoleColor.Green;
				}
				else
				{
					if (fg.B > 127)
						FgConsoleColor = ConsoleColor.Blue;
					else
						FgConsoleColor = ConsoleColor.Black;
				}
			}
		}

        private LogLevelEnum(string name, byte value, Color fg, Color bg) : this(name, value, fg)
		{
			BgColor = bg;
			ANSI256BgColor = (byte) (Math.Floor(bg.B/(128m/3) + bg.G/(128m/3) * 5 + bg.R/(128m/3) * 30) + 16);
			if (bg.R > 127)
			{
				if (bg.G > 127)
				{
					if (bg.B > 127)
						BgConsoleColor = ConsoleColor.White;
					else
						BgConsoleColor = ConsoleColor.Yellow;
				}
				else
				{
					if (bg.B > 127)
						BgConsoleColor = ConsoleColor.Magenta;
					else
						BgConsoleColor = ConsoleColor.Red;
				}
			}
			else
			{
				if (bg.G > 127)
				{
					if (bg.B > 127)
						BgConsoleColor = ConsoleColor.Cyan;
					else
						BgConsoleColor = ConsoleColor.Green;
				}
				else
				{
					if (bg.B > 127)
						BgConsoleColor = ConsoleColor.Blue;
					else
						BgConsoleColor = ConsoleColor.Black;
				}
			}
		}
    }
}