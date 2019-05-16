using System.Collections.Generic;

namespace TeamSL.TwentyFortyEight.Engine
{
    internal class Sequence
    {
        public List<ushort> Elements { get; }
        public bool WasMovement { get; private set; }
        public ushort MovementAmount { get; private set; }

        public Sequence(int size)
        {
            Elements = new List<ushort>(size);
        }

        public void Append(ushort element)
        {
            Elements.Add(element);
        }

        public Queue<ushort> GetElements()
        {
            return new Queue<ushort>(Elements);
        }

        public void Merge()
        {
            var index = 0;

            do
            {
                if (Elements[index] == 0)
                {
                    index++;
                    continue;
                }

                int firstValue = Elements[index];

                int secondValue = 0;
                var secondValueIndex = index + 1;

                while (secondValueIndex < Elements.Count)
                {
                    secondValue = Elements[secondValueIndex];
                    if (secondValue != 0)
                        break;
                    secondValueIndex++;
                }

                if (firstValue != secondValue)
                {
                    index++;
                    continue;
                }

                Elements[index] = (ushort)(firstValue + secondValue);
                Elements[secondValueIndex] = 0;
                WasMovement = true;
                MovementAmount += Elements[index];
                index += 2;

            } while (index < Elements.Count);
        }

        public void Move()
        {
            var emptyPosition = -1;
            for (int index = 0; index < Elements.Count; index++)
            {
                if (Elements[index] == 0 && emptyPosition < 0)
                {
                    emptyPosition = index;
                    continue;
                }

                if (Elements[index] != 0 && emptyPosition >= 0)
                {
                    Elements[emptyPosition] = Elements[index];
                    Elements[index] = 0;
                    emptyPosition++;
                    WasMovement = true;
                }
            }
        }
    }
}