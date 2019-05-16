namespace TeamSL.TwentyFortyEight.Engine
{
    internal class LeftMovementStrategy : HorizontalMovementStrategy
    {
        public LeftMovementStrategy(Cell[,] cells) : base(cells, Ordering.Ascending)
        {
        }
    }
}