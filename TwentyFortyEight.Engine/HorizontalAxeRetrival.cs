namespace TeamSL.TwentyFortyEight.Engine
{
    internal class HorizontalAxeRetrival : IAxeRetrival
    {
        private readonly Cell[,] _cells;

        public HorizontalAxeRetrival(Cell[,] cells)
        {
            _cells = cells;
        }
        public ref Cell Getter(int firstAxeIndex, int secondAxeIndex)
        {
            return ref _cells[firstAxeIndex, secondAxeIndex];
        }
    }
}