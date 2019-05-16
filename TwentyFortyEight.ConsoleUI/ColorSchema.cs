using System;
using System.Collections.Generic;

namespace TeamSL.TwentyFortyEight.ConsoleUI
{
    public class ColorSchema
    {
        private readonly Dictionary<ushort, ConsoleColor> _colors;

        public ColorSchema()
        {
            _colors = new Dictionary<ushort, ConsoleColor>();
            _colors.Add(0, ConsoleColor.DarkGray);
            _colors.Add(2, ConsoleColor.White);
            _colors.Add(4, ConsoleColor.Yellow);
            _colors.Add(8, ConsoleColor.DarkYellow);
            _colors.Add(16, ConsoleColor.Red);
            _colors.Add(32, ConsoleColor.DarkRed);
            _colors.Add(64, ConsoleColor.Magenta);
            _colors.Add(128, ConsoleColor.Cyan);
            _colors.Add(256, ConsoleColor.DarkCyan);
            _colors.Add(512, ConsoleColor.Blue);
            _colors.Add(1024, ConsoleColor.DarkBlue);
            _colors.Add(2048, ConsoleColor.Green);
        }

        public ConsoleColor GetColor(ushort value)
        {
            if (value > 2048)
                return _colors[2048];

            if (!_colors.ContainsKey(value))
                throw new ArgumentOutOfRangeException(nameof(value));

            return _colors[value];
        }
    }
}