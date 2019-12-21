using Invoices.Common.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Common.Aggregate
{
    public abstract class AggregateRoot
    {
        public int Version { get; private set; }
        public DateTime ModifyDate {get; private set;}

        private readonly List<DomainEvent> _domainEvents;

        public AggregateRoot()
        {
            Version = 0;
           _domainEvents = new List<DomainEvent>();
        }

        public IList<DomainEvent> GetDomainEvents()
        {
            return _domainEvents;

        }
        public void ClearEvents()
        {
            _domainEvents.Clear();
        }
        protected void AddDomainEvent(DomainEvent @event)
        {
            _domainEvents.Add(@event);
            Version++;
            ModifyDate = DateTime.Now;
        }
    }
}
