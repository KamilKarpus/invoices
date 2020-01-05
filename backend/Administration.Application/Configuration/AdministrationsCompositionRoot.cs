using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.Configuration
{
    public class AdministrationsCompositionRoot
    {
        private static IContainer _container;

        internal static void SetContainer(IContainer container)
        {
            _container = container;
        }

        internal static ILifetimeScope BeginLifetimeScope()
        {
            return _container.BeginLifetimeScope();
        }
    }
}
