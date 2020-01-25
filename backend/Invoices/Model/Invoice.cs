using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Model
{
    public static class Invoice
    {
        public class Add
        {
            public Guid CustomerId { get; set; }
            public Guid SellerId { get; set; }
            public string Currency { get; set; }
            public int VatRate { get; set; }
        }
        public class AddProduct
        {
            public Guid InvoiceId { get; set; }
            public string Name { get; set; }
            public  decimal NetPrice { get; set; }
            public int Quantity { get; set; }
        }
        public static class Get
        {
            public class GetPaggination
            {
                public int PageSize { get; set; }
                public int CurrentPage { get; set; }
            }
        }
        public static class Update
        {
            public class Product
            {
                public Guid ProductId { get; set; }
                public decimal NetPrice { get; set; }
                public int Quantity { get; set; }
                public string Name { get; set; }
            }
        }
    }
}
