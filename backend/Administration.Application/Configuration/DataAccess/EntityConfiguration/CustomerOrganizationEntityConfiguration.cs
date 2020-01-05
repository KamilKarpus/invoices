using Administration.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.Configuration.DataAccess.EntityConfiguration
{
    public class CustomerOrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("customerorganization", "public");
            builder.HasKey(p => p.Id).HasName("id");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Nip).HasColumnName("nip");
            builder.Property(p => p.PostalCode).HasColumnName("postalcode");
            builder.Property(p => p.Street).HasColumnName("street");
            builder.Property(p => p.ModifyDate).HasColumnName("modifydate");
            builder.Property(p => p.Version).HasColumnName("version");
            builder.Property(p => p.City).HasColumnName("city");
            builder.OwnsMany<Customer>("_customers", p =>
            {
                p.ToTable("customer");
                p.HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("id").IsConcurrencyToken();
                p.Property(p => p.OrganizationId).HasColumnName("id_organization");
                p.Property(p => p.Name).HasColumnName("name");
                p.Property(p => p.Surname).HasColumnName("surname");
                p.WithOwner().HasForeignKey(p => p.OrganizationId);
            });
               
        }
    }
}
