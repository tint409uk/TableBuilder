using System;
using System.Collections.Generic;
using System.Text;
using TableBuilder.Columns.Options;

namespace TableBuilder.Columns.Interfaces
{
    public interface ITableColumn<TRowModel, out TColumnOptions>
        where TRowModel : class
        where TColumnOptions : ColumnOptions, new()
    {
        ITableColumn<TRowModel, TColumnOptions> Options(Action<TColumnOptions> configureOptions);
        ITableColumn<TRowModel, TColumnOptions> Title(string title);
        ITableColumn<TRowModel, TColumnOptions> Width(int width);
    }
}
