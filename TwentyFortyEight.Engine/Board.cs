using System;
using System.Collections.Generic;

namespace TeamSL.TwentyFortyEight.Engine
{
    public class Board
    {
        public Cell[,] Cells { get; private set; }
        private readonly Dictionary<Movement, Func<Cell[,], MovementStrategy>> _strategies;

        public bool WasMovement { get; private set; }

        private Cell[,] _previousCells;
        private short _previousAmount;

        internal event EventHandler<MovementComposingEventArgs> OnComposed;

        internal Board(int size)
        {
            Cells = new Cell[size, size];

            for (ushort rowIndex = 0; rowIndex < size; rowIndex++)
            {
                for (ushort columnIndex = 0; columnIndex < size; columnIndex++)
                {
                    Cells[rowIndex, columnIndex] = new Cell(rowIndex, columnIndex);
                }
            }

            _strategies = new Dictionary<Movement, Func<Cell[,], MovementStrategy>>();
            _strategies.Add(Movement.Up, cells => new UpMovementStrategy(cells));
            _strategies.Add(Movement.Right, cells => new RightMovementStrategy(cells));
            _strategies.Add(Movement.Down, cells => new DownMovementStrategy(cells));
            _strategies.Add(Movement.Left, cells => new LeftMovementStrategy(cells));
        }

        private void FireOnComposedEvent(short amount)
        {
            OnComposed?.Invoke(this, new MovementComposingEventArgs(amount));
        }

        internal void Move(Movement movement)
        {
            if (!_strategies.ContainsKey(movement))
                throw new Exception(nameof(movement));

            var backup = (Cell[,])Cells.Clone();

            var movementStrategy = _strategies[movement](Cells);
            movementStrategy.Proceed();

            WasMovement = movementStrategy.WasMovement;

            if (WasMovement)
            {
                _previousCells = backup;
                _previousAmount = (short)movementStrategy.MovementAmount;
                FireOnComposedEvent(_previousAmount);
            }
        }

        internal void Undo()
        {
            if (_previousCells != null)
            {
                Cells = _previousCells;
                FireOnComposedEvent((short) (_previousAmount * -1));
            }
        }
    }
}