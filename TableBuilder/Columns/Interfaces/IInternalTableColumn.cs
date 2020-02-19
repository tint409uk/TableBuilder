using System;
using TableBuilder.Columns.Options;

namespace TableBuilder.Columns.Interfaces
{
    internal interface IInternalTableColumn<TRowModel, out TColumnOptions>
        where TRowModel : class
        where TColumnOptions : ColumnOptions, new()
    {
        TColumnOptions Options { get; }
        Func<TRowModel, object?>? GetCellValue { get; }
    }
}
