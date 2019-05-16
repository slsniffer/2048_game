namespace TeamSL.TwentyFortyEight.Engine
{
    internal class VerticalMovementStrategy : MovementStrategy
    {
        public VerticalMovementStrategy(Cell[,] cells, Ordering secondAxeOrdering)
            : base(cells, secondAxeOrdering)
        {
        }

        protected override ref Cell Getter(int firstAxeIndex, int secondAxeIndex)
        {
            return ref _cells[secondAxeIndex, firstAxeIndex];
        }
    }
}