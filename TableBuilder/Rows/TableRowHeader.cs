using System;
using TableBuilder.Cells;

namespace TableBuilder.Rows
{
    internal sealed class TableRowHeader<TRowModel> : TableRowBase<TRowModel, IHeaderCellImplementor> where TRowModel : class
    {
        internal TableRowHeader(Table<TRowModel> parentTable) : base(parentTable) { }

        internal override string RenderRow() => "".PadRight(_tableWidth, '-') + Environment.NewLine + base.RenderRow();

        protected override string RenderCell(int columnIndex) => CellImplementors[columnIndex].RenderCell();
    }
}
