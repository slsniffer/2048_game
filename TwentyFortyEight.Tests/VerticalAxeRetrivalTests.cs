using NUnit.Framework;
using TeamSL.TwentyFortyEight.Engine;

namespace TeamSL.TwentyFortyEight.Tests
{
    [TestFixture]
    public class VerticalAxeRetrivalTests
    {
        [Test]
        public void ShouldReturnCorrectVerticalAxe()
        {
            var cells = new Cell[4,4];
            cells[0, 0].SetValue(2);
            cells[1, 0].SetValue(4);
            cells[2, 0].SetValue(8);
            var axeRetrival = new VerticalAxeRetrival(cells);

            Assert.That(axeRetrival.Getter(0, 0).Value, Is.EqualTo(2));
            Assert.That(axeRetrival.Getter(0, 1).Value, Is.EqualTo(4));
            Assert.That(axeRetrival.Getter(0, 2).Value, Is.EqualTo(8));
        }
    }
}
