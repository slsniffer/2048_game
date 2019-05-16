namespace TeamSL.TwentyFortyEight.Engine
{
    internal class HorizontalMovementStrategy : MovementStrategy
    {
        public HorizontalMovementStrategy(Cell[,] cells, Ordering secondAxeOrdering)
            : base(cells, secondAxeOrdering)
        {
        }
    }
}