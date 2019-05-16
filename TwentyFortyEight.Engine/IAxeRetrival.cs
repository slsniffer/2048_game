namespace TeamSL.TwentyFortyEight.Engine
{
    internal interface IAxeRetrival
    {
        ref Cell Getter(int firstAxeIndex, int secondAxeIndex);
    }
}