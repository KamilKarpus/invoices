using Invoices.Common.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DomainEvents
{
    public interface IDomainEventAccesor
    {
        List<DomainEvent> GetDomainEvents();
        void ClearDomainEvents();
    }
}
