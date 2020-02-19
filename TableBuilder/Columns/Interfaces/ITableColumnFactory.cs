using System;
using System.Reflection;
using TableBuilder.Columns.Options;

namespace TableBuilder.Columns.Interfaces
{
    internal interface ITableColumnFactory
    {
        ITableColumn<TRowModel, ColumnOptions> CreateColumn<TRowModel>(Table<TRowModel> table, string header, PropertyInfo propInfo, Func<TRowModel, object?> propFunc) where TRowModel : class;
    }
}
