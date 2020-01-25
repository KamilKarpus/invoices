using Invoices.Application.Configuration.Processing;
using System;

namespace Invoices.Application.Commands
{
    public class UpdateProductCommand : ICommand
    {
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
        public decimal NetPrice { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
    }
}
