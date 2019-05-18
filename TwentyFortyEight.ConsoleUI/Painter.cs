using System;
using TeamSL.TwentyFortyEight.Engine;

namespace TeamSL.TwentyFortyEight.ConsoleUI
{
    public class Painter
    {
        private readonly ColorSchema _colorSchema;
        private ConsoleColor _defaultColor;

        public Painter(ColorSchema colorSchema)
        {
            _colorSchema = colorSchema;
            _defaultColor = Console.ForegroundColor;
        }

        public void Draw(Game game)
        {
            Console.Clear();
            Console.WriteLine();

            for (int rowIndex = 0; rowIndex < game.Board.Cells.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < game.Board.Cells.GetLength(1); columnIndex++)
                {
                    var boardCell = game.Board.Cells[rowIndex, columnIndex];

                    Console.ForegroundColor = _colorSchema.GetColor(boardCell.Value);
                    Console.Write(string.Format("{0,6}", boardCell.Value == 0 ? (object) ".": boardCell.Value));
                    Console.ForegroundColor = _defaultColor;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Score: {0}", game.Score);
            Console.WriteLine("Use arrows for movements, Backspace to undo last movement...");
        }

        public void DrawDead()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You are DEAD!!!!");
            Console.ForegroundColor = _defaultColor;
            Console.WriteLine("Press CTRL+C to exit ...");
        }
    }
}