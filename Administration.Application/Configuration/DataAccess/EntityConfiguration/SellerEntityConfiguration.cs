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
            builder.ToTable("seller","public");
            builder.HasKey(p => p.Id).HasName("id");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.CompanyName).HasColumnName("companyname");
            builder.Property(p => p.BankSwift).HasColumnName("bankswift");
            builder.Property(p => p.BankName).HasColumnName("bankname");
            builder.Property(p => p.BankAccountNumber).HasColumnName("bankaccountnumber");
            builder.Property(p => p.City).HasColumnName("city");
            builder.Property(p => p.Street).HasColumnName("street");
            builder.Property(p => p.NIP).HasColumnName("nip");
            builder.Property(p => p.Version).HasColumnName("version");
            builder.Property(p => p.ModifyDate).HasColumnName("modifydate");
            builder.Property(p => p.PostalCode).HasColumnName("postalcode");
        }
    }
}
