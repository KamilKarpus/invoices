using System;
using System.Threading.Tasks;
using Dapper;
using Infrastructure;
using Invoices.Common.DomainEvents;
using Invoices.Domain.DomainEvents;

namespace Invoices.Application.DomainEventHandler
{
    public class CreatedInvoiceDomainEventHandler : IDomainEventHandler<CreatedInvoiceDomainEvent>
    {
        private readonly ISqlConnectionFactory _factory;
        public CreatedInvoiceDomainEventHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task Handle(CreatedInvoiceDomainEvent @event)
        {
            var conn = _factory.GetConnection();
            await conn.ExecuteAsync("INSERT INTO public.jobs(id, occurrencedate, type, invoiceid)" +
        "VALUES(@Id, @Date, @Type, @InvoiceId); ", new { Id = Guid.NewGuid(), Date = DateTime.Now, Type = "AssignedNumberToInvoice", InvoiceId = @event.InvoiceId });
        }
    }
}
