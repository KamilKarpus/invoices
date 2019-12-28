using Administration.Domain.DomainEvents.Organization;
using Invoices.Common.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Application.DomainEventsHandlers
{
    public class AddCustomerDomainEventHandler : IDomainEventHandler<AddCustomerDomainEvent>
    {
        public Task Handle(AddCustomerDomainEvent @event)
        {
           return Task.CompletedTask;
        }
    }
}
