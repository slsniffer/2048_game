using NUnit.Framework;
using TeamSL.TwentyFortyEight.Engine;

namespace TeamSL.TwentyFortyEight.Tests
{
    [TestFixture]
    public class CellsExtensionsTests
    {
        [Test]
        public void ShouldReturnCorrectEptyCells()
        {
            var cells = new Cell[4, 4];

            cells[0,3].SetValue(2);
            cells[2,1].SetValue(4);
            Assert.That(cells.Empty().Count, Is.EqualTo(14));

            cells[1, 1].SetValue(8);
            Assert.That(cells.Empty().Count, Is.EqualTo(13));

            cells[2, 3].SetValue(16);
            Assert.That(cells.Empty().Count, Is.EqualTo(12));

            cells[3, 3].SetValue(0);
            Assert.That(cells.Empty().Count, Is.EqualTo(12));

            cells[2, 3].SetValue(0);
            Assert.That(cells.Empty().Count, Is.EqualTo(13));
        }
    }
}