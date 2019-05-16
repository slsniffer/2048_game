using System.Collections.Generic;

namespace TeamSL.TwentyFortyEight.Engine
{
    internal static class CellsExtensions
    {
        public static List<Cell> Empty(this Cell[,] array)
        {
            var cells = new List<Cell>();

            for (int rowIndex = 0; rowIndex < array.GetLength(0); rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < array.GetLength(1); columnIndex++)
                {
                    if (array[rowIndex, columnIndex].Value == 0)
                        cells.Add(array[rowIndex, columnIndex]);
                }
            }

            return cells;
        }
    }
}