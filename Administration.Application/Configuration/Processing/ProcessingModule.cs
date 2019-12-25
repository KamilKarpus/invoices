using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Administration.Application.Configuration.Processing
{
    public class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGenericDecorator(typeof(UnityOfWorkHandlerDecorator<>), typeof(ICommandHandler<>));
                
        }
    }
}
