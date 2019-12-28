using Adminstration.IntegrationEvents;
using Autofac;
using EventServiceBus;
using EventServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.Configuration.EventBus
{
    public static class EventBusStartup
    {
        public static void Subcribe()
        {
            using(var scope = AdministrationsCompositionRoot.BeginLifetimeScope())
            {

            }
        }
    }
}
