using System;
using TableBuilder.Cells;
using TableBuilder.Columns.Interfaces;
using TableBuilder.Columns.Options;

namespace TableBuilder.Columns
{
    internal abstract class TableColumnBase<TRowModel, TColumnOptions>
        : ITableColumn<TRowModel, TColumnOptions>, IInternalTableColumn<TRowModel, TColumnOptions>, ICellImplementor
        where TRowModel : class
        where TColumnOptions : ColumnOptions, new()
    {
        protected string _header;
        protected TColumnOptions _options = new TColumnOptions();
        protected Table<TRowModel> _parentTable;

        protected TableColumnBase(Table<TRowModel> parentTable, string header, Func<TRowModel, object?> getCellValue)
        {
            _parentTable = parentTable;
            _header = header;
            GetCellValue = getCellValue;
        }

        public ITableColumn<TRowModel, TColumnOptions> Options(Action<TColumnOptions> configureOptions)
        {
            configureOptions?.Invoke(_options);
            return this;
        }

        public virtual string RenderCell(int rowIndex, object? value) => string.Empty;

        public ITableColumn<TRowModel, TColumnOptions> Title(string title)
        {
            _header = title;
            return this;
        }

        public ITableColumn<TRowModel, TColumnOptions> Width(int width)
        {
            _options.ColumnWidth = width;
            return this;
        }

        protected string AlignString(string raw, bool alignRight = false) => alignRight ? raw.PadLeft(_options.ColumnWidth) : raw.PadRight(_options.ColumnWidth);

        TColumnOptions IInternalTableColumn<TRowModel, TColumnOptions>.Options => _options;
        public Func<TRowModel, object?>? GetCellValue { get; }
    }
}
