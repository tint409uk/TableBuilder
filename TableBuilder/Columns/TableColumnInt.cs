using System;
using TableBuilder.Cells;
using TableBuilder.Columns.Interfaces;
using TableBuilder.Columns.Options;

namespace TableBuilder.Columns
{
    internal class TableColumnInt<TRowModel> : TableColumnBase<TRowModel, IntOptions>, ITableColumnInt<TRowModel, IntOptions>,
        IHeaderCellImplementor, IDataCellImplementor where TRowModel : class
    {
        internal TableColumnInt(Table<TRowModel> parentTable, string header, Func<TRowModel, object?> getCellValue)
            : base(parentTable, header, getCellValue)
        { }

        public ITableColumnInt<TRowModel, IntOptions> DisableFormatting()
        {
            _options.DisableFormatting = true;
            return this;
        }

        string IHeaderCellImplementor.RenderCell() => AlignString(_header, !_options.DisableFormatting);

        string IDataCellImplementor.RenderCell(int rowIndex, object? value)
        {
            var result = string.Empty;
            if (int.TryParse(value?.ToString(), out int intValue))
            {
                result = _options.DisableFormatting ? intValue.ToString() : intValue.ToString("N0");
            }
            return AlignString(result, !_options.DisableFormatting);
        }
    }
}
