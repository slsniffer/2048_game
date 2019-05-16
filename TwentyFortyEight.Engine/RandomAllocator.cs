using System;

namespace TeamSL.TwentyFortyEight.Engine
{
    internal class RandomAllocator
    {
        private readonly Random _random = new Random();
        private readonly Board _board;

        public RandomAllocator(Board board)
        {
            _board = board;
        }

        public void Init()
        {
            var emptyCells = _board.Cells.Empty();

            var firstCellIndex = _random.Next(0, emptyCells.Count - 1);
            var secondCellIndex = -1;
            while (firstCellIndex == secondCellIndex || secondCellIndex == -1)
            {
                secondCellIndex = _random.Next(0, emptyCells.Count - 1);
            }

            var firstCell = emptyCells[firstCellIndex];
            var secondCell = emptyCells[secondCellIndex];

            _board.Cells[firstCell.RowIndex, firstCell.ColumnIndex].SetValue(2);
            _board.Cells[secondCell.RowIndex, secondCell.ColumnIndex].SetValue(2);
        }

        public void PutNewNumber()
        {
            var emptyCells = _board.Cells.Empty();

            if (emptyCells.Count == 0)
                return;

            var randomCellIndex = _random.Next(0, emptyCells.Count);
            var randomCell = emptyCells[randomCellIndex];

            _board.Cells[randomCell.RowIndex, randomCell.ColumnIndex].SetValue(2);
        }
    }
}