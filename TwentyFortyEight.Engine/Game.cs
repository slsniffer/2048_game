using System;

namespace TeamSL.TwentyFortyEight.Engine
{
    public class Game
    {
        public int Score { get; private set; }
        public Board Board { get; }
        private bool _isRunning;
        private readonly RandomAllocator _randomAllocator;

        public Game(int size)
        {
            Score = 0;
            Board = new Board(size);
            _randomAllocator = new RandomAllocator(Board);
        }

        public void Run()
        {
            if (_isRunning)
                throw new Exception("Game is in progress");

            _isRunning = true;

            _randomAllocator.Init();

            Board.OnComposed += BoardOnComposedHandler;
        }

        private void BoardOnComposedHandler(object sender, MovementComposingEventArgs e)
        {
            Score += e.Amount;
        }

        public void Move(Movement movement)
        {
            Board.Move(movement);

            if (Board.WasMovement)
                _randomAllocator.PutNewNumber();
        }

        public void Undo()
        {
            Board.Undo();
        }

        public bool IsGameOver()
        {
            return !Board.HasMovement();
        }
    }
}
