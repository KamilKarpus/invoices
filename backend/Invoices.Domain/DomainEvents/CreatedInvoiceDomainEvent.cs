
using Invoices.Common.DomainEvents;
using System;

namespace Invoices.Domain.DomainEvents
{
    public class CreatedInvoiceDomainEvent : DomainEvent
    {
        public Guid InvoiceId { get; set; }
    }
}
