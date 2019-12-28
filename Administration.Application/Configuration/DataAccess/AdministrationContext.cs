using Administration.Application.Configuration.DataAccess.EntityConfiguration;
using Administration.Domain.Customers;
using Administration.Domain.Sellers;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Application.Configuration.DataAccess
{
    public class AdministrationContext : DbContext
    {
        public AdministrationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Seller> Sellers { get; private set; }
        public DbSet<Organization> Organizations { get; private set; }
        public DbSet<Customer> Customers { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Seller>(new SellerEntityConfiguration());
            modelBuilder.ApplyConfiguration<Customer>(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration<Organization>(new CustomerOrganizationEntityConfiguration());
        }
    }
}
