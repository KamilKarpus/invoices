using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Common.DomainEvents
{
    public interface IDomainEventHandler<T> where T : DomainEvent
    {
        Task Handle(T @event);
    }
}
