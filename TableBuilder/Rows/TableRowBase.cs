using System;
using System.Collections.Generic;
using System.Linq;
using TableBuilder.Cells;
using TableBuilder.Columns;

namespace TableBuilder.Rows
{
    internal abstract class TableRowBase<TRowModel, TCellImplementor>
        where TRowModel : class
        where TCellImplementor : ICellImplementor
    {
        protected List<TCellImplementor> _cellImplementors = new List<TCellImplementor>();
        protected Table<TRowModel> _parentTable;
        protected int _rowIndex;
        protected int _tableWidth;

        internal TableRowBase(Table<TRowModel> parent, int rowIndex = -1)
        {
            _parentTable = parent;
            _rowIndex = rowIndex;
            ConvertCellImplementors();
            _tableWidth = _parentTable.ColumnImplementors.Sum(c => c.Options.ColumnWidth) + _cellImplementors.Count * 3 + 1;
        }

        protected virtual void ConvertCellImplementors()
        {
            for (int i = 0; i < _parentTable.ColumnImplementors.Count; i++)
            {
                _cellImplementors.Add(
                    (TCellImplementor)(_parentTable.ColumnImplementors[i] is TCellImplementor ? (TCellImplementor)_parentTable.ColumnImplementors[i]
                    : (ICellImplementor)new TableColumnString<TRowModel>(_parentTable, string.Empty, r => string.Empty)));
            }
        }

        protected abstract string RenderCell(int columnIndex);

        internal virtual string RenderRow()
        {
            var tr = "| ";
            for (int i = 0; i < _cellImplementors.Count; i++)
            {
                tr += RenderCell(i) + " | ";
                if (i == _cellImplementors.Count - 1)
                {
                    tr += $"{Environment.NewLine}{"".PadRight(_tableWidth, '-')}";
                }
            }
            return tr + Environment.NewLine;
        }

        protected List<TCellImplementor> CellImplementors => _cellImplementors.Select(column => column).ToList();
    }
}