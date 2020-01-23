using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Application.ReadModels
{
    public class InvoicesView
    {
        public Guid Id { get; set; } 
        public Guid Customerid { get; set; } 
        public DateTime Creationdate {get; set; } 
        public DateTime Saledate {get; set; } 
        public DateTime Paymentdeadline {get; set; } 
        public decimal Nettopay {get; set; } 
        public decimal Grosstopay {get; set; } 
        public decimal Paid {get; set; } 
        public decimal Lefttopay {get; set; } 
        public string Remarks {get; set; } 
        public int Status {get; set; } 
        public Guid Sellerid {get; set; } 
        public string Currency {get; set; } 
        public int Vatrate {get; set; }    
    }
}
