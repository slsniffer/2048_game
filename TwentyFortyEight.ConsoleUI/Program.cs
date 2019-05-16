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
}
