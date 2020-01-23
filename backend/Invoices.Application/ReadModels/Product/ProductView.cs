using System;

namespace Invoices.Application.ReadModels.Product
{
    public class ProductView
    {
        public Guid ProductId {get; set;}
        public string Name {get; set;}
        public decimal Netperunit {get; set;}
        public decimal Grossperunit {get; set;}
        public int Quantity { get; set; }
        
    }
}
