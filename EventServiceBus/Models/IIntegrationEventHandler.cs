using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventServiceBus.Models
{
    public interface IIntegrationEventHandler<T> : IIntegrationEventHandler
        where T : IIntegrationEvent
    {
        Task Handle(T @event);

    }
    public interface IIntegrationEventHandler
    {

    }
}
