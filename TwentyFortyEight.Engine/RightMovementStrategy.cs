namespace TeamSL.TwentyFortyEight.Engine
{
    internal class RightMovementStrategy : HorizontalMovementStrategy
    {
        public RightMovementStrategy(Cell[,] cells) : base(cells, Ordering.Descending)
        {
        }
    }
}