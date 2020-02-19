namespace TableBuilder.Columns.Options
{
    public class MoneyOptions : ColumnOptions
    {
        public string CurrencyCode { get; set; } = "GBP";
        public int DecimalPlaces { get; set; } = 2;
    }
}
