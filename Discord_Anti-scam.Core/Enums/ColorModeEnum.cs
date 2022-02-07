using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace Discord_Anti_scam.Core.Enums
{
    public class ColorModeEnum : SmartEnum<ColorModeEnum, byte>
    {

		public static readonly ColorModeEnum TERMINAL_16_COLOR = new("TERMINAL_16_COLOR", 0);
		public static readonly ColorModeEnum ANSI_256_COLOR = new("ANSI_256_COLOR", 1);
		public static readonly ColorModeEnum RGB = new("RGB", 2);

        private ColorModeEnum(string name, byte value) : base(name, value)
		{

		}
    }
}