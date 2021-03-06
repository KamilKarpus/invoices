﻿using Invoices.Common.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Common.Entitys
{
    public abstract class Entity
    {
        public DateTime ModifyDate {get; private set;}

        private readonly List<DomainEvent> _domainEvents;

        public Entity()
        {
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
            ModifyDate = DateTime.Now;
        }
    }
}
