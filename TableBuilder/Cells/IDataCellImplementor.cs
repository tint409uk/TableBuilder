namespace TableBuilder.Cells
{
    internal interface IDataCellImplementor : ICellImplementor
    {
        new string RenderCell(int rowIndex, object? value);
    }
}
