using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using EventServiceBus;

namespace Administration.Application.Configuration.EventBus
{
    public class EventBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceBusClient>().As<IServiceBus>();
        }
    }
}
