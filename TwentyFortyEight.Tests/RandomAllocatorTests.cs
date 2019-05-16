using NUnit.Framework;
using TeamSL.TwentyFortyEight.Engine;

namespace TeamSL.TwentyFortyEight.Tests
{
    [TestFixture]
    public class RandomAllocatorTests
    {
        [Test, Repeat(100)]
        public void ShouldInitWithTwoMinimalNumbers()
        {
            var board = new Board(4);

            var allocator = new RandomAllocator(board);
            allocator.Init();

            var emptyCells = board.Cells.Empty();

            Assert.AreEqual(14, emptyCells.Count);
        }

        [Test, Repeat(100)]
        public void ShouldPutNewNumberInEmptyCell()
        {
            var board = new Board(4);

            var allocator = new RandomAllocator(board);
            allocator.Init();

            allocator.PutNewNumber();

            var emptyCells = board.Cells.Empty();

            Assert.AreEqual(13, emptyCells.Count);
        }

        [Test]
        public void ShouldPutNewNumberInEmptyCellAfterComposing()
        {
            var game = new Game(4);

            game.Board.Cells[2, 0].SetValue(2);
            game.Board.Cells[3, 0].SetValue(2);

            game.Move(Movement.Down);

            var emptyCells = game.Board.Cells.Empty();

            Assert.AreEqual(14, emptyCells.Count);
        }
    }
}