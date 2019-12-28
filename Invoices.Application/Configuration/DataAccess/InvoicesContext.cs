using Invoices.Application.Configuration.DataAccess.EntityConfiguration;
using Invoices.Domain;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<RegisterSeller>(new RegisterSellerEntityConfiguration());
        }
    }
}