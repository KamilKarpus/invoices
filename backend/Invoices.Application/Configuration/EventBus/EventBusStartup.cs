using Adminstration.IntegrationEvents;
using Autofac;
using EventServiceBus;
using EventServiceBus.Models;
using Invoices.Application.IntegrationEventHandlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Application.Configuration.EventBus
{
    public class EventBusStartup
    {
        public static void Initialize()
        {
            using (var scope = InvoicesCompositionRoot.BeginLifetimeScope())
            {
                var eventBus = scope.Resolve<IServiceBus>();
                eventBus.Subscribe<SellerCreatedIntegrationEvent>(new InvoicesGenericIntegrationHandler<SellerCreatedIntegrationEvent>());
                eventBus.Subscribe<OrganiationCreatedIntegrationEvent>(new InvoicesGenericIntegrationHandler<OrganiationCreatedIntegrationEvent>());
                eventBus.Subscribe<AddCustomerIntegrationEvent>(new InvoicesGenericIntegrationHandler<AddCustomerIntegrationEvent>());
            }
        }

        private class InvoicesGenericIntegrationHandler<T> : IIntegrationEventHandler<T> where T : IIntegrationEvent
        {
            public Task Handle(T @event)
            {
                using (var scope = InvoicesCompositionRoot.BeginLifetimeScope())
                {
                    var mediator = scope.Resolve<IMediator>();
                     mediator.Publish(@event);
                }
                return Task.CompletedTask;
            }
        }
    }

}
