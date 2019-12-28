using Autofac;
using Invoices.Application.Configuration.DataAccess;
using Invoices.Application.Configuration.EventBus;
using Invoices.Application.Configuration.Medation;
using Invoices.Application.Configuration.Processing;
using System;

namespace Invoices.Application.Configuration
{
    public class InvoicesStartup
    {
        public static void Initialize(string connectionString)
        {
            ConfigureContainer(connectionString);
        }
        private static void ConfigureContainer(string connectionString)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new EventBusModule());
            var container = containerBuilder.Build();

            InvoicesCompositionRoot.SetContainer(container);
            EventBusStartup.Initialize();
        }
    }
}
