using Administration.Application.Configuration.DataAccess.EntityConfiguration;
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
    public class AdministrationContext : DbContext, IUnityOfWork
    {
        public AdministrationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Seller> Sellers { get; private set; }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Seller>(new SellerEntityConfiguration());
        }
    }
}
