using Autofac;
using EventServiceBus;


namespace Invoices.Application.Configuration.EventBus
{
    public class EventBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceBusClient>().As<IServiceBus>();
        }
    }
}
