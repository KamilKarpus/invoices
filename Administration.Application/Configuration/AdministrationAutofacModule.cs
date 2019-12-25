using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Administration.Application.Configuration
{
    public class AdministrationAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdministrationModule>().As<IAdministrationModule>();
        }
    }
}
