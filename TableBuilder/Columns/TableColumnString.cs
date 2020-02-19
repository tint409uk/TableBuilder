using System;
using TableBuilder.Cells;
using TableBuilder.Columns.Options;

namespace TableBuilder.Columns
{
    internal class TableColumnString<TRowModel> : TableColumnBase<TRowModel, ColumnOptions>, IHeaderCellImplementor, IDataCellImplementor where TRowModel : class
    {
        internal TableColumnString(Table<TRowModel> parentTable, string header, Func<TRowModel, object?> getCellValue)
            : base(parentTable, header, getCellValue)
        { }

        string IHeaderCellImplementor.RenderCell() => _header.PadRight(_options.ColumnWidth);

        string IDataCellImplementor.RenderCell(int rowIndex, object? value)
        {
            var result = string.Empty;
            if (value is string strValue)
            {
                result = strValue;
            }
            return AlignString(result);
        }
    }
}
