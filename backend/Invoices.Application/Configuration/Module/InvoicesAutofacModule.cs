using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Application.Configuration.Module
{
    public class InvoicesAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InvoicesModule>().As<IInvoicesModule>();
        }
    }
}
