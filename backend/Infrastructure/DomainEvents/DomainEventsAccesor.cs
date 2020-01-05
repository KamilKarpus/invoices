using Invoices.Common.Entitys;
using Invoices.Common.DomainEvents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DomainEvents
{
    public class DomainEventsAccesor : IDomainEventAccesor
    {
        private readonly DbContext _context;
        public DomainEventsAccesor(DbContext context)
        {
            _context = context;
        }

        public List<DomainEvent> GetDomainEvents()
        {
            var events = _context.ChangeTracker.Entries<Entity>()
                 .Where(p => p.Entity.GetDomainEvents().Any() && p.Entity.GetDomainEvents() != null);

            return events.SelectMany(p=>p.Entity.GetDomainEvents()).ToList();
        }

        public void ClearDomainEvents()
        {
            var events = _context.ChangeTracker.Entries<Entity>()
                .Where(p => p.Entity.GetDomainEvents().Any() && p.Entity.GetDomainEvents() != null)
                .ToList();

            events.ForEach(p => p.Entity.ClearEvents());
        }
    }
}
