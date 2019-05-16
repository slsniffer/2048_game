using System.Linq;

namespace TeamSL.TwentyFortyEight.Engine
{
    internal class MovementStrategy
    {
        protected Cell[,] _cells;
        private readonly int[] _firstAxeOrdering;
        private readonly int[] _secondAxeOrdering;

        public ushort MovementAmount { get; private set; }
        public bool WasMovement { get; private set; }

        protected MovementStrategy(Cell[,] cells, Ordering ordering)
        {
            _cells = cells;
            _firstAxeOrdering = Enumerable.Range(0, _cells.GetLength(0)).ToArray();
            _secondAxeOrdering = ordering == Ordering.Ascending ? _firstAxeOrdering : _firstAxeOrdering.Reverse().ToArray();
        }

        public virtual void Proceed()
        {
            var length = _cells.GetLength(0);
            foreach (var firstAxeIndex in _firstAxeOrdering)
            {
                var seq = new Sequence(length);

                foreach (var secondAxeIndex in _secondAxeOrdering)
                {
                    seq.Append(Getter(firstAxeIndex, secondAxeIndex).Value);
                }

                seq.Merge();
                seq.Move();

                var elements = seq.GetElements();

                foreach (var secondAxeIndex in _secondAxeOrdering)
                {
                    Getter(firstAxeIndex, secondAxeIndex).SetValue(elements.Dequeue());
                }

                MovementAmount += seq.MovementAmount;

                if (seq.WasMovement)
                    WasMovement = true;
            }
        }

        protected virtual ref Cell Getter(int firstAxeIndex, int secondAxeIndex)
        {
            return ref _cells[firstAxeIndex, secondAxeIndex];
        }
    }
}