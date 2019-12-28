using Invoices.Domain.RegisterOrganization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Application.Configuration.DataAccess.EntityConfiguration
{
    public class RegisterOrganizationEntityConfiguration : IEntityTypeConfiguration<RegisterOrganization>
    {
        public void Configure(EntityTypeBuilder<RegisterOrganization> builder)
        {
            builder.ToTable("registercustomerorganization", "public");
            builder.HasKey(p => p.Id).HasName("id");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.OrganizationId).HasColumnName("id_customerorganization");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Nip).HasColumnName("nip");
            builder.Property(p => p.PostalCode).HasColumnName("postalcode");
            builder.Property(p => p.Street).HasColumnName("street");
            builder.Property(p => p.City).HasColumnName("city");

        }
    }
}
