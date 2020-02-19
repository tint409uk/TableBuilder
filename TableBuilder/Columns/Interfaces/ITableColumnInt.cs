using TableBuilder.Columns.Options;

namespace TableBuilder.Columns.Interfaces
{
    public interface ITableColumnInt<TRowModel, out TColumnOptions> : ITableColumn<TRowModel, TColumnOptions>
        where TRowModel : class
        where TColumnOptions : ColumnOptions, new()
    {
        ITableColumnInt<TRowModel, TColumnOptions> DisableFormatting();
    }
}
