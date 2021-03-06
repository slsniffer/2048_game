﻿using System.Linq;

namespace TeamSL.TwentyFortyEight.Engine
{
    internal class MovementStrategy
    {
        private readonly Cell[,] _cells;
        private readonly IAxeRetrival _axeRetrival;
        private readonly int[] _firstAxeOrdering;
        private readonly int[] _secondAxeOrdering;

        public ushort MovementAmount { get; private set; }
        public bool WasMovement { get; private set; }

        public MovementStrategy(Cell[,] cells, IAxeRetrival axeRetrival, Ordering ordering)
        {
            _cells = cells;
            _axeRetrival = axeRetrival;
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
                    seq.Append(_axeRetrival.Getter(firstAxeIndex, secondAxeIndex).Value);
                }

                seq.Merge();
                seq.Move();

                var elements = seq.GetElements();

                foreach (var secondAxeIndex in _secondAxeOrdering)
                {
                    _axeRetrival.Getter(firstAxeIndex, secondAxeIndex).SetValue(elements.Dequeue());
                }

                MovementAmount += seq.MovementAmount;

                if (seq.WasMovement)
                    WasMovement = true;
            }
        }
    }
}