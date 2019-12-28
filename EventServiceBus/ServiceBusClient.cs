using System;
using System.Collections.Generic;
using System.Text;
using EventServiceBus.Models;

namespace EventServiceBus
{
    public class ServiceBusClient : IServiceBus
    {
        public void Publish<T>(T @event) where T : IIntegrationEvent
        {
            InMemoryServiceBus.Instance.Publish(@event);
        }

        public void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IIntegrationEvent
        {
            InMemoryServiceBus.Instance.Register<T>(handler);
        }
    }
}
