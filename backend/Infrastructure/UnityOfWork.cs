using Infrastructure.DomainEvents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnityOfWork : IUnityOfWork
    {
        private DbContext _context;
        private IDomainEventDispatcher _dispatcher;
        private IPostgresChangeTracker _tracker;
        public UnityOfWork(DbContext context, IDomainEventDispatcher dispatcher, IPostgresChangeTracker tracker)
        {
            _context = context;
            _dispatcher = dispatcher;
            _tracker = tracker;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            _tracker.ChangeTracker();
            await _dispatcher.DispatchAsync();
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
