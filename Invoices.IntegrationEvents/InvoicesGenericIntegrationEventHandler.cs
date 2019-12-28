using EventServiceBus.Models;
using System;
using System.Threading.Tasks;

namespace Invoices.IntegrationEvents
{
    public class InvoicesGenericIntegrationEventHandler<T> : IIntegrationEventHandler<T> where T : IIntegrationEvent
    {
        public Task Handle(T @event)
        {
            throw new NotImplementedException();
        }
    }
}
