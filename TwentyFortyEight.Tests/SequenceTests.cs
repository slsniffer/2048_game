using NUnit.Framework;
using TeamSL.TwentyFortyEight.Engine;

namespace TeamSL.TwentyFortyEight.Tests
{
    [TestFixture]
    public class SequenceTests
    {
        [Test]
        public void ShouldInitializeCorrectly()
        {
            var seq = new Sequence(2);
            Assert.AreEqual(2, seq.Elements.Capacity);
        }

        [Test]
        public void ShouldAppendItemsCorrectly()
        {
            var seq = new Sequence(2);
            seq.Append(0);
            seq.Append(1);
            Assert.AreEqual(2, seq.Elements.Capacity);
            Assert.AreEqual(2, seq.Elements.Count);
        }

        [TestCase(new ushort[] { 2, 4, 8, 16 }, new ushort[] { 2, 4, 8, 16 }, false, 0)]
        [TestCase(new ushort[] { 2, 4, 2, 4 }, new ushort[] { 2, 4, 2, 4 }, false, 0)]
        [TestCase(new ushort[] { 2, 2, 2, 4 }, new ushort[] { 4, 0, 2, 4 }, true, 4)]
        [TestCase(new ushort[] { 2, 2, 4, 4 }, new ushort[] { 4, 0, 8, 0 }, true, 12)]
        [TestCase(new ushort[] { 2, 2, 2, 2 }, new ushort[] { 4, 0, 4, 0 }, true, 8)]
        [TestCase(new ushort[] { 2, 0, 0, 2 }, new ushort[] { 4, 0, 0, 0 }, true, 4)]
        [TestCase(new ushort[] { 2, 0, 2, 0 }, new ushort[] { 4, 0, 0, 0 }, true, 4)]
        [TestCase(new ushort[] { 0, 0, 2, 2 }, new ushort[] { 0, 0, 4, 0 }, true, 4)]
        [TestCase(new ushort[] { 2, 2, 0, 0 }, new ushort[] { 4, 0, 0, 0 }, true, 4)]
        [TestCase(new ushort[] { 0, 0, 0, 0 }, new ushort[] { 0, 0, 0, 0 }, false, 0)]
        [Test]
        public void ShouldMergeCorrectly(ushort[] elements, ushort[] expected, bool wasMovement, int movementAmount)
        {
            var seq = new Sequence(elements.Length);
            foreach (var element in elements)
            {
                seq.Append(element);
            }

            seq.Merge();

            CollectionAssert.AreEqual(expected, seq.Elements);
            Assert.AreEqual(wasMovement, seq.WasMovement);
            Assert.AreEqual(movementAmount, seq.MovementAmount);
        }

        [TestCase(new ushort[] { 2, 4, 0, 8 }, new ushort[] { 2, 4, 8, 0 }, true)]
        [TestCase(new ushort[] { 2, 0, 0, 4 }, new ushort[] { 2, 4, 0, 0 }, true)]
        [TestCase(new ushort[] { 4, 0, 2, 0 }, new ushort[] { 4, 2, 0, 0 }, true)]
        [TestCase(new ushort[] { 4, 0, 4, 0 }, new ushort[] { 4, 4, 0, 0 }, true)]
        [TestCase(new ushort[] { 0, 0, 0, 4 }, new ushort[] { 4, 0, 0, 0 }, true)]
        [TestCase(new ushort[] { 0, 0, 4, 0 }, new ushort[] { 4, 0, 0, 0 }, true)]
        [TestCase(new ushort[] { 0, 4, 0, 0 }, new ushort[] { 4, 0, 0, 0 }, true)]
        [TestCase(new ushort[] { 4, 0, 0, 0 }, new ushort[] { 4, 0, 0, 0 }, false)]
        [TestCase(new ushort[] { 0, 0, 0, 0 }, new ushort[] { 0, 0, 0, 0 }, false)]
        [Test]
        public void ShouldMoveCorrectly(ushort[] elements, ushort[] expected, bool wasMovement)
        {
            var seq = new Sequence(elements.Length);
            foreach (var element in elements)
            {
                seq.Append(element);
            }

            seq.Move();

            CollectionAssert.AreEqual(expected, seq.Elements);
            Assert.AreEqual(wasMovement, seq.WasMovement);
            Assert.AreEqual(0, seq.MovementAmount);
        }
    }
}
