using TableBuilder.Cells;

namespace TableBuilder.Rows
{
    internal sealed class TableRowHeader<TRowModel> : TableRowBase<TRowModel, IHeaderCellImplementor> where TRowModel : class
    {
        internal TableRowHeader(Table<TRowModel> parentTable) : base(parentTable) { }

        protected override string RenderCell(int columnIndex)
        {

            return CellImplementors[columnIndex].RenderCell();
        }
    }
}
