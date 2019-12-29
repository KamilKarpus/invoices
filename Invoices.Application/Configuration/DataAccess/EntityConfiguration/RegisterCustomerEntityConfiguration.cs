using Invoices.Domain.RegisterOrganization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Application.Configuration.DataAccess.EntityConfiguration
{
    public class RegisterCustomerEntityConfiguration : IEntityTypeConfiguration<RegisterCustomer>
    {
        public void Configure(EntityTypeBuilder<RegisterCustomer> builder)
        {
            builder.ToTable("registercustomer", "public");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.CustomerId).HasColumnName("customerid");
            builder.Property(p => p.OrganizationId).HasColumnName("id_organization");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Surname).HasColumnName("surname");
        }
    }
}
