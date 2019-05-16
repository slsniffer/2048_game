namespace TeamSL.TwentyFortyEight.Engine
{
    public struct Cell
    {
        public ushort Value { get; private set; }
        public ushort RowIndex { get; }
        public ushort ColumnIndex { get; }

        internal Cell(ushort rowIndex, ushort columnIndex)
        {
            Value = 0;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        internal void SetValue(ushort value)
        {
            Value = value;
        }
    }
}