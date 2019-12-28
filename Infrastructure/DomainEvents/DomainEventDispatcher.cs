using Autofac;
using Invoices.Common.DomainEvents;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DomainEvents
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IDomainEventAccesor _domainEventAccesor;
        private readonly ILifetimeScope _scope;
        public DomainEventDispatcher(IDomainEventAccesor domainEventAccesor, ILifetimeScope scope)
        {
            _domainEventAccesor = domainEventAccesor;
            _scope = scope;
        }

        public async Task DispatchAsync()
        {
            var @events = _domainEventAccesor.GetDomainEvents();
            var handlersTypes = typeof(IDomainEventHandler<>);
            foreach (var @event in @events)
            {
                var genericType = handlersTypes.MakeGenericType(@event.GetType());
                dynamic handler = _scope.Resolve(genericType);
                await handler.Handle((dynamic)@event);
            }
            _domainEventAccesor.ClearDomainEvents();
        }
    }
}
