using Invoices.Application.Configuration.Processing;
using System;

namespace Invoices.Application.Commands
{
    public class DeleteProductFromInvoiceCommand : ICommand
    {
        public Guid InvoiceId { get; set; }
        public Guid ProductId { get; set; }
    }
}
