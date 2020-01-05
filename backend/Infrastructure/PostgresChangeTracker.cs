using Domain.Enitity;
using Infrastructure.DomainEvents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class PostgresChangeTracker : IPostgresChangeTracker
    {
        private readonly DbContext _context;
        private readonly IDomainEventAccesor _accesor; 
        public PostgresChangeTracker(DbContext context, IDomainEventAccesor accesor)
        {
            _context = context;
            _accesor = accesor;
        }
        public void ChangeTracker()
        {
            var events = _accesor.GetDomainEvents().Where(p => p.GetType().Name.Contains("Add"));
            if (events.Any())
            {
                var entries = _context.ChangeTracker.Entries()
                    .Where(p => p.State == EntityState.Modified).ToList();


                var entriestochange = entries.Where(p => p.Entity.GetType().GetInterface("IEntity") != null).ToList();
                entriestochange.ForEach(p => p.State = EntityState.Added);

            }
        }
    }
}
