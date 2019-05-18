using System;
using System.Collections.Generic;
using TeamSL.TwentyFortyEight.Engine;

namespace TeamSL.TwentyFortyEight.ConsoleUI
{
    class Program
    {
        private static Game _game;

        private static readonly Dictionary<ConsoleKey, Action> _actions = new Dictionary<ConsoleKey, Action>(5)
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

            var painter = new Painter(new ColorSchema());

            do
            {
                painter.Draw(_game);

                if (_game.IsGameOver())
                {
                    painter.DrawDead();
                    break;
                }

                var pressedKey = Console.ReadKey();

                if (_actions.ContainsKey(pressedKey.Key))
                {
                    _actions[pressedKey.Key]();
                }
            } while (true);

            do
            {
            } while (true);
        }
    }
}
