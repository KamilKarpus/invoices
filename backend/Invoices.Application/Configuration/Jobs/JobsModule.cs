using Autofac;

namespace Invoices.Application.Configuration.Jobs
{
    public class JobsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssignNumberService>().AsSelf();
        }
    }
}
