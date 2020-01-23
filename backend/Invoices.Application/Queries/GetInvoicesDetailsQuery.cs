using Invoices.Application.Configuration.Processing;
using Invoices.Application.ReadModels;
using System;

namespace Invoices.Application.Queries
{
    public class GetInvoicesDetailsQuery : IQuery<InvoicesView>
    {
        public Guid Id { get; set; }
    }
}
