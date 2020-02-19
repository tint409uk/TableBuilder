using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TableBuilder.Columns.Interfaces;
using TableBuilder.Columns.Options;
using TableBuilder.Utils;

namespace TableBuilder.Columns
{
    public class TableColumnsConfigurator<TRowModel> where TRowModel : class
    {
        private readonly Table<TRowModel> _table;
        private static readonly ITableColumnFactory _tableColumnFactory = new TableColumnFactory(); // By right, this should from DI

        internal TableColumnsConfigurator(Table<TRowModel> table)
        {
            _table = table;
        }

        public ITableColumnMoney<TRowModel, ColumnOptions> Bound(string header, Expression<Func<TRowModel, decimal>> prop)
        {
            TableColumnMoney<TRowModel> newColumn = (TableColumnMoney<TRowModel>)_tableColumnFactory.CreateColumn(_table, header, prop.GetAccessedMemberInfo(), (row) => prop.Compile().Invoke(row)); // TO DO: removing boxing and unboxing
            _table.ColumnImplementors.Add(newColumn);
            return newColumn;
        }

        public ITableColumnInt<TRowModel, IntOptions> Bound(string header, Expression<Func<TRowModel, int>> prop)
        {
            TableColumnInt<TRowModel> newColumn = (TableColumnInt<TRowModel>)_tableColumnFactory.CreateColumn(_table, header, prop.GetAccessedMemberInfo(), (row) => prop.Compile().Invoke(row));
            _table.ColumnImplementors.Add(newColumn);
            return newColumn;
        }

        public ITableColumn<TRowModel, ColumnOptions> Bound(string header, Expression<Func<TRowModel, string>> prop)
        {
            TableColumnString<TRowModel> newColumn = (TableColumnString<TRowModel>)_tableColumnFactory.CreateColumn(_table, header, prop.GetAccessedMemberInfo(), (row) => prop.Compile().Invoke(row));
            _table.ColumnImplementors.Add(newColumn);
            return newColumn;
        }
    }
}
