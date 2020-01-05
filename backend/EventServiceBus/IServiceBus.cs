using EventServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventServiceBus
{
    public interface IServiceBus
    {
        void Subscribe<T>(IIntegrationEventHandler<T> handler) where T : IIntegrationEvent;
        void Publish<T>(T @event) where T : IIntegrationEvent;
    }
}
