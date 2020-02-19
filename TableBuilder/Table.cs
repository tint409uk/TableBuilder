using System;
using System.Collections.Generic;
using System.Linq;
using TableBuilder.Columns;
using TableBuilder.Columns.Interfaces;
using TableBuilder.Columns.Options;
using TableBuilder.Rows;

namespace TableBuilder
{
    public class Table<TRowModel> where TRowModel : class
    {
        private TableColumnsConfigurator<TRowModel> _tableColumnsConfigurator;

        public Table(IEnumerable<TRowModel> rows)
        {
            DataSource = rows.ToList();
            _tableColumnsConfigurator = new TableColumnsConfigurator<TRowModel>(this);
        }

        public Table<TRowModel> SetupColumns(Action<TableColumnsConfigurator<TRowModel>> configurator)
        {
            configurator?.Invoke(_tableColumnsConfigurator);
            return this;
        }

        public string Render()
        {
            var table = string.Empty;
            table += new TableRowHeader<TRowModel>(this).RenderRow();
            for (var i = 0; i < ColumnImplementors.Count; i++)
            {
                table += new TableRowData<TRowModel>(this, i).RenderRow();
            }
            return table;
        }

        internal List<IInternalTableColumn<TRowModel, ColumnOptions>> ColumnImplementors { get; } = new List<IInternalTableColumn<TRowModel, ColumnOptions>>();
        internal IReadOnlyList<TRowModel> DataSource { get; private set; } = new List<TRowModel>();
    }
}