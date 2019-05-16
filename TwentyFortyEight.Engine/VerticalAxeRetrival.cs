namespace TeamSL.TwentyFortyEight.Engine
{
    internal class VerticalAxeRetrival : IAxeRetrival
    {
        private readonly Cell[,] _cells;

        public VerticalAxeRetrival(Cell[,] cells)
        {
            _cells = cells;
        }
        public ref Cell Getter(int firstAxeIndex, int secondAxeIndex)
        {
            return ref _cells[secondAxeIndex, firstAxeIndex];
        }
    }
}