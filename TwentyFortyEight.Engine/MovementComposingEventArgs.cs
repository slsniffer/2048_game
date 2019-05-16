namespace TeamSL.TwentyFortyEight.Engine
{
    internal class MovementComposingEventArgs
    {
        public short Amount { get; }

        public MovementComposingEventArgs(short amount)
        {
            Amount = amount;
        }
    }
}