namespace TeamSL.TwentyFortyEight.Engine
{
    internal class DownMovementStrategy : VerticalMovementStrategy
    {
        public DownMovementStrategy(Cell[,] cells) : base(cells, Ordering.Descending)
        {
        }
    }
}