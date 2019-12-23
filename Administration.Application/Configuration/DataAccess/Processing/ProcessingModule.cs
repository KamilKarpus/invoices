﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Administration.Application.Configuration.DataAccess.Processing
{
    public class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGenericDecorator(typeof(ICommandHandler<>), typeof(ICommand));
        }
    }
}
