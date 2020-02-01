using Invoices.Application.Configuration.Processing;
using System;

namespace Invoices.Application.Commands
{
    public class IssueInvoiceCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
