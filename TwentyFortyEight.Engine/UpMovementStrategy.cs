namespace TeamSL.TwentyFortyEight.Engine
{
    internal class UpMovementStrategy : VerticalMovementStrategy
    {
        public UpMovementStrategy(Cell[,] cells) : base(cells, Ordering.Ascending)
        {
        }
    }
}