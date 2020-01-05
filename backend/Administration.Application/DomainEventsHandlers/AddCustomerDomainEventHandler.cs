using Administration.Domain.DomainEvents.Organization;
using Adminstration.IntegrationEvents;
using EventServiceBus;
using Invoices.Common.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.DomainEventsHandlers
{
    public class AddCustomerDomainEventHandler : IDomainEventHandler<AddCustomerDomainEvent>
    {
        private readonly IServiceBus _bus;
        public AddCustomerDomainEventHandler(IServiceBus bus)
        {
            _bus = bus;
        }
        public Task Handle(AddCustomerDomainEvent @event)
        {
            _bus.Publish(new AddCustomerIntegrationEvent(@event.Id, @event.Name, @event.LastName, @event.OrganizationId));
           return Task.CompletedTask;
        }
    }
}
