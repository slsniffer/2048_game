using System;
using TeamSL.TwentyFortyEight.Engine;

namespace TeamSL.TwentyFortyEight.ConsoleUI
{
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
}