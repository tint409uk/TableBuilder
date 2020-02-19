using System;
using TableBuilder.Columns.Options;

namespace TableBuilder.Columns.Interfaces
{
    public interface ITableColumnMoney<TRowModel, out TColumnOptions> : ITableColumn<TRowModel, TColumnOptions>
        where TRowModel : class
        where TColumnOptions : ColumnOptions, new()
    {
        ITableColumnMoney<TRowModel, TColumnOptions> Set(Action<MoneyOptions> func);
    }
}
