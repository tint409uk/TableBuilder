using System;
using System.Linq;
using TableBuilder;

namespace TableBuilderProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new Table<Invoice>(Enumerable.Range(1, 50).Select(a => new Invoice
            {
                ID = a,
                CustomerName = $"Name {a}",
                Qty = new Random().Next(0, 100),
                Price = (decimal)new Random().NextDouble() + 100m
            }));

            Console.Write(table
                .SetupColumns(conf =>
                {
                    conf.Bound("Invoice ID", i => i.ID).DisableFormatting().Width(15);
                    conf.Bound("Customer Name", i => i.CustomerName);
                    conf.Bound("Qty", i => i.Qty);
                    conf.Bound("Price", i => i.Price);
                })
                .Render());
        }
    }

    class Invoice
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
