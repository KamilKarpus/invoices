using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Common.DomainEvents
{
    public class DomainEvent
    {
        public Guid Id { get; private set; }
        public DateTime OccouredOn { get; private set; }

        public DomainEvent()
        {
            Id = Guid.NewGuid();
            OccouredOn = DateTime.Now;
        }
    }
}
