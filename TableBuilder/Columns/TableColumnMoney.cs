using System;
using TableBuilder.Cells;
using TableBuilder.Columns.Interfaces;
using TableBuilder.Columns.Options;

namespace TableBuilder.Columns
{
    internal class TableColumnMoney<TRowModel> : TableColumnBase<TRowModel, MoneyOptions>, ITableColumnMoney<TRowModel, MoneyOptions>,
        IHeaderCellImplementor, IDataCellImplementor where TRowModel : class
    {
        internal TableColumnMoney(Table<TRowModel> parentTable, string header, Func<TRowModel, object?> getCellValue)
            : base(parentTable, header, getCellValue)
        { }

        public ITableColumnMoney<TRowModel, MoneyOptions> Set(Action<MoneyOptions> func)
        {
            func?.Invoke(_options);
            return this;
        }

        string IHeaderCellImplementor.RenderCell() => $"{_header} ({_options.CurrencyCode})".PadLeft(_options.ColumnWidth);

        string IDataCellImplementor.RenderCell(int rowIndex, object? value)
        {
            var result = string.Empty;
            if (decimal.TryParse(value?.ToString(), out decimal decimalValue))
            {
                result = $"{decimalValue.ToString($"N{_options.DecimalPlaces}")} {_options.CurrencyCode}";
            }
            return AlignString(result, true);
        }
    }
}
