using System.Threading.Tasks;
using Invoices.Common.DomainEvents;
using Invoices.Domain.DomainEvents;

namespace Invoices.Application.DomainEventHandler
{
    public class CreatedInvoiceDomainEventHandler : IDomainEventHandler<CreatedInvoiceDomainEvent>
    {
        public Task Handle(CreatedInvoiceDomainEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}
