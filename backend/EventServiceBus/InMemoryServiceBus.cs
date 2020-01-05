using EventServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventServiceBus
{
    public sealed class InMemoryServiceBus
    {

        //private Dictionary<Type, IIntegrationEventHandler> _handlers;
        private readonly List<HandlerType> _handlers;
        public InMemoryServiceBus()
        {
            _handlers = new List<HandlerType>();
        }

        public static InMemoryServiceBus Instance { get; } = new InMemoryServiceBus();

        public void Register<T>(IIntegrationEventHandler<T> handler) where T : IIntegrationEvent
        {
            _handlers.Add(
            new HandlerType() 
            { 
                EventName = typeof(T).Name, 
                Handler =  handler
            });
        }

        public async Task Publish<T>(T @event) where T : IIntegrationEvent
        {
            var handlers = _handlers.Where(p => p.EventName == typeof(T).Name);
            foreach(var handler in handlers)
            {
                await handler.Invoke(@event);
            }
        }

        private class HandlerType
        {
            public string EventName { get; set; }
            public IIntegrationEventHandler Handler { get; set; }

            public async Task Invoke<T>(T @event) where T : IIntegrationEvent
            {
                await((IIntegrationEventHandler<T>)Handler).Handle(@event);
            }
        }
    }
}
