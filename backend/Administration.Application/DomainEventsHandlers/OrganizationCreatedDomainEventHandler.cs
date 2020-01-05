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
    public class OrganizationCreatedDomainEventHandler : IDomainEventHandler<OrganizationCreatedDomainEvent>
    {
        private readonly IServiceBus _bus;
        public OrganizationCreatedDomainEventHandler (IServiceBus bus)
        {
            _bus = bus;
        }
        public Task Handle(OrganizationCreatedDomainEvent @event)
        {
            _bus.Publish(new OrganiationCreatedIntegrationEvent(@event.OrganizationId, @event.Name, @event.Street, @event.City,
                @event.PostalCode, @event.Nip));
            return Task.CompletedTask;
        }
    }
}
