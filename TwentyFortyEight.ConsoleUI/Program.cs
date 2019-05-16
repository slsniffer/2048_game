using System;
using System.Collections.Generic;
using TeamSL.TwentyFortyEight.Engine;

namespace TeamSL.TwentyFortyEight.ConsoleUI
{
    class Program
    {
        private static Game _game;
        private static readonly Dictionary<ConsoleKey, Action> _actions = new Dictionary<ConsoleKey, Action>
        {
            {ConsoleKey.UpArrow, () => _game.Move(Movement.Up)},
            {ConsoleKey.RightArrow, () => _game.Move(Movement.Right)},
            {ConsoleKey.DownArrow, () => _game.Move(Movement.Down)},
            {ConsoleKey.LeftArrow, () => _game.Move(Movement.Left)},
            {ConsoleKey.Backspace, () => _game.Undo()}
        };

        static void Main(string[] args)
        {
            _game = new Game(4);
            _game.Run();

            do
            {
                var drawer = new Drawer(new ColorSchema());
                drawer.Draw(_game);

                var pressedKey = Console.ReadKey();

                if (_actions.ContainsKey(pressedKey.Key))
                {
                    _actions[pressedKey.Key]();
                }
            } while (true);
        }
    }

    public class Drawer
    {
        private readonly ColorSchema _colorSchema;

        public Drawer(ColorSchema colorSchema)
        {
            _colorSchema = colorSchema;
        }

        public void Draw(Game game)
        {
            Console.Clear();
            Console.WriteLine();

            var defaultColor = Console.ForegroundColor;

            for (int rowIndex = 0; rowIndex < game.Board.Cells.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < game.Board.Cells.GetLength(1); columnIndex++)
                {
                    var boardCell = game.Board.Cells[rowIndex, columnIndex];

                    Console.ForegroundColor = _colorSchema.GetColor(boardCell.Value);
                    Console.Write($"{boardCell.Value,6}");
                    Console.ForegroundColor = defaultColor;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Score: {0}", game.Score);
            Console.WriteLine("Use arrows for movements, Backspace to undo last movement...");
        }
    }

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
