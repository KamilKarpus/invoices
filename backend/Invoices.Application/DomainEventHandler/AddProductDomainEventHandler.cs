using Invoices.Common.DomainEvents;
using Invoices.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Application.DomainEventHandler
{
    public class AddProductDomainEventHandler : IDomainEventHandler<AddProductDomainEvent>
    {
        public Task Handle(AddProductDomainEvent @event)
        {
            return Task.CompletedTask;
        }
    }
}
