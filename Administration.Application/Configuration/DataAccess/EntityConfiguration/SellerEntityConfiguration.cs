using Administration.Domain.Sellers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.Configuration.DataAccess.EntityConfiguration
{
    public class SellerEntityConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Seller");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CompanyName);
            builder.Property(p => p.BankSwift);
            builder.Property(p => p.BankName);
            builder.Property(p => p.BankAcountNumber);
            builder.Property(p => p.City);
            builder.Property(p => p.Street);
            builder.Property(p => p.NIP);
            builder.Property(p => p.Version);
            builder.Property(p => p.ModifyDate);
        }
    }
}
