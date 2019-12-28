using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Infrastructure;
using Invoices.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Application.Configuration.DataAccess
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _dbConnectionString;
        public DataAccessModule(string dbConn)
        {
            _dbConnectionString = dbConn;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(r =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<InvoicesContext>();
                dbContextOptionsBuilder.UseNpgsql(_dbConnectionString);

                return new InvoicesContext(dbContextOptionsBuilder.Options);
            }).AsSelf()
              .As<DbContext>()
              .InstancePerLifetimeScope();

            builder.RegisterType<RegisterSellerService>().AsSelf();
            builder.RegisterType<RegisterOrganizationService>().AsSelf();

            var invoicesAssembly = typeof(DataAccessModule).Assembly;

            builder.RegisterAssemblyTypes(invoicesAssembly)
              .Where(type => type.Name.EndsWith("Repository"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope()
              .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
