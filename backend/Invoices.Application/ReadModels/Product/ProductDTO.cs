using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Application.ReadModels.Product
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public decimal Nettopay { get; set; } 
        public decimal Grosstopay {get ;set;} 
        public string Name {get ;set;}
        public decimal Netperunit {get ;set;}
        public decimal Grossperunit {get ;set;}
        public int Quantity {get ;set;}
 
    }
}
