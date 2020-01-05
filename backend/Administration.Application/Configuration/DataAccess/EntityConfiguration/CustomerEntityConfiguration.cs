using Administration.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Administration.Application.Configuration.DataAccess.EntityConfiguration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer", "public");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(p => p.OrganizationId).HasColumnName("id_organization");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Surname).HasColumnName("surname");
        }
    }
}
