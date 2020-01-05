using Invoices.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Application.Configuration.DataAccess.EntityConfiguration
{
    public class RegisterSellerEntityConfiguration : IEntityTypeConfiguration<RegisterSeller>
    {
        public void Configure(EntityTypeBuilder<RegisterSeller> builder)
        {
            builder.ToTable("registerseller", "public");
            builder.HasKey(p => p.Id).HasName("id");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.SellerId).HasColumnName("sellerid");
            builder.Property(p => p.CompanyName).HasColumnName("companyname");
            builder.Property(p => p.BankSwift).HasColumnName("bankswift");
            builder.Property(p => p.BankName).HasColumnName("bankname");
            builder.Property(p => p.BankAccountNumber).HasColumnName("bankaccountnumber");
            builder.Property(p => p.City).HasColumnName("city");
            builder.Property(p => p.Street).HasColumnName("street");
            builder.Property(p => p.NIP).HasColumnName("nip");
            builder.Property(p => p.ModifyDate).HasColumnName("modifydate");
            builder.Property(p => p.PostalCode).HasColumnName("postalcode");
        }
    }
}
