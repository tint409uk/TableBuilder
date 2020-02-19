namespace TableBuilder.Cells
{
    internal interface ICellImplementor
    {
        string RenderCell(int rowIndex, object? value);
    }
}
