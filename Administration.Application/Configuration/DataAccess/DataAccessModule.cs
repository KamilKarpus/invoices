using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Administration.Application.Configuration.DataAccess
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _dbConnectionString;
        public DataAccessModule(string conn)
        {
            _dbConnectionString = conn;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(r =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<AdministrationContext>();
                dbContextOptionsBuilder.UseNpgsql(_dbConnectionString);

                return new AdministrationContext(dbContextOptionsBuilder.Options);
            }).AsSelf();

            builder.RegisterType<AdministrationContext>().As<IUnityOfWork>();
        }
    }
}
