using System;
using System.Collections.Generic;
using System.Reflection;
using TableBuilder.Columns.Interfaces;
using TableBuilder.Columns.Options;

namespace TableBuilder.Columns
{
    internal class TableColumnFactory : ITableColumnFactory
    {
        ITableColumn<TRowModel, ColumnOptions> ITableColumnFactory.CreateColumn<TRowModel>(Table<TRowModel> table, string header, PropertyInfo propInfo, Func<TRowModel, object?> propFunc) where TRowModel : class
        {
            List<string> moneyNames = new List<string>() // By right, we should have Money struct type, but I use decimal here just for demo purpose
            {
                typeof(decimal).Name,
                typeof(Decimal).Name
            };
            List<string> intNames = new List<string>()
            {
                typeof(int).Name,
                typeof(Int16).Name,
                typeof(Int32).Name,
                typeof(long).Name,
                typeof(Int64).Name
            };

            return propInfo.PropertyType.Name switch
            {
                string s when intNames.Contains(s) => new TableColumnInt<TRowModel>(table, header, propFunc),
                string s when moneyNames.Contains(s) => new TableColumnMoney<TRowModel>(table, header, propFunc),
                _ => new TableColumnString<TRowModel>(table, header, propFunc)
            };
        }
    }
}
