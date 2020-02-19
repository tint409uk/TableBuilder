using TableBuilder.Cells;

namespace TableBuilder.Rows
{
    internal class TableRowData<TRowModel> : TableRowBase<TRowModel, IDataCellImplementor> where TRowModel : class
    {
        internal TableRowData(Table<TRowModel> parent, int rowIndex)
            : base(parent, rowIndex)
        {
        }

        protected override string RenderCell(int columnIndex)
        {
            Columns.Interfaces.IInternalTableColumn<TRowModel, Columns.Options.ColumnOptions> column = _parentTable.ColumnImplementors[columnIndex];
            return _cellImplementors[columnIndex].RenderCell(_rowIndex, column.GetCellValue != null ? column.GetCellValue(_parentTable.DataSource[_rowIndex]) : null);
        }
    }
}
