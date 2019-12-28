using Invoices.Application.Configuration.DataAccess.EntityConfiguration;
using Invoices.Domain;
using Invoices.Domain.RegisterOrganization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Application.Configuration.DataAccess
{
    public class InvoicesContext : DbContext
    {
        public InvoicesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RegisterSeller> Sellers { get; private set; }
        public DbSet<RegisterOrganization> Organizations { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<RegisterSeller>(new RegisterSellerEntityConfiguration());
            modelBuilder.ApplyConfiguration<RegisterOrganization>(new RegisterOrganizationEntityConfiguration());
        }
    }
}