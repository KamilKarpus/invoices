using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Infrastructure.DomainEvents;
using Invoices.Common.DomainEvents;

namespace Invoices.Application.Configuration.Processing
{
    public class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGenericDecorator(typeof(UnityOfWorkHandlerDecorator<>), typeof(ICommandHandler<>));
            builder.RegisterType<DomainEventsAccesor>()
                .As<IDomainEventAccesor>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DomainEventDispatcher>()
                .As<IDomainEventDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
              .AsClosedTypesOf(typeof(IDomainEventHandler<>))
              .InstancePerDependency()
              .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
