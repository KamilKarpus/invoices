using Invoices.Application.Configuration.Processing;
using System;

namespace Invoices.Application.Commands
{
    public class CreateInvoicePDFCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
