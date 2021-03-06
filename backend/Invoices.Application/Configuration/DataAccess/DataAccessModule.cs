﻿using Autofac;
using DinkToPdf;
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

            builder.Register(r =>   
                new SqlConnectionFactory(_dbConnectionString))
            .AsImplementedInterfaces();


            builder.RegisterType<RegisterSellerService>()
                .AsSelf();
            builder.RegisterType<RegisterOrganizationService>()
                .AsSelf();
            builder.RegisterType<RegisterCustomerService>()
                .AsSelf();
            builder.RegisterType<UnityOfWork>()
                .AsImplementedInterfaces();

            builder.RegisterType<PostgresChangeTracker>()
                .AsImplementedInterfaces();
            var invoicesAssembly = typeof(DataAccessModule).Assembly;

            builder.RegisterAssemblyTypes(invoicesAssembly)
              .Where(type => type.Name.EndsWith("Repository"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope()
              .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
