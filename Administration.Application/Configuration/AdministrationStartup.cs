using Administration.Application.Configuration.DataAccess;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.Configuration
{
    public class AdministrationStartup
    {
        public static void Initialize(string connectionString)
        {
            ConfigureContainer(connectionString);
        }
        private static void ConfigureContainer(string connectionString) 
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(connectionString));
            var container =  containerBuilder.Build();
            AdministrationsCompositionRoot.SetContainer(container);
        }

    }
}
