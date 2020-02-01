using Domain;
using Invoices.Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Invoices.Application.Configuration.DataAccess.EntityConfiguration
{
    public class InvoicesEntityConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

            var converter = new ValueConverter<InvoiceStatus, int>(
                v => v.Id,
                v => InvoiceStatus.From(v)
                );
            var percentage = new ValueConverter<Percentage, int>(
                v => v.Value,
                v => Percentage.From(v)
                );
            builder.ToTable("invoice");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.CustomerId).HasColumnName("customerid");
            builder.Property(p => p.CreationDate).HasColumnName("creationdate");

            builder.OwnsOne(p => p.GrossToPay, b =>
            {
                b.Property(p => p.Currency).HasColumnName("currency");
                b.Property(p => p.Value).HasColumnName("grosstopay");
            });

            builder.OwnsOne(p => p.NetToPay, b =>
            {
                b.Property(p => p.Currency).HasColumnName("currency");
                b.Property(p => p.Value).HasColumnName("nettopay");
            });
            builder.OwnsOne(p => p.LeftToPay, b =>
            {
                b.Property(p => p.Currency).HasColumnName("currency");
                b.Property(p => p.Value).HasColumnName("lefttopay");
            });
            builder.OwnsOne(p => p.Paid, b =>
            {
                b.Property(p => p.Currency).HasColumnName("currency");
                b.Property(p => p.Value).HasColumnName("paid");
            });

            builder.OwnsOne(p => p.Number, b =>
            {
                b.Property(p => p.Number).HasColumnName("number");
                b.Property(p => p.Year).HasColumnName("numberyear");
            });

            builder.Property(p => p.Status)
                .HasColumnName("status")
                .HasConversion(converter);

            builder.Property(p => p.SellerId).HasColumnName("sellerid");
            builder.Property(p => p.SaleDate).HasColumnName("saledate");
            builder.Ignore(p => p.ModifyDate);
            builder.Property(p => p.PaymentDeadline).HasColumnName("paymentdeadline");
            builder.Property(p => p.VatRate)
                .HasColumnName("vatrate")
                .HasConversion(percentage);


            builder.OwnsMany<Product>("_products", p =>
            {
                p.ToTable("product");
                p.HasKey(p => p.Id);
                p.Property(p => p.Id).HasColumnName("id").IsConcurrencyToken();
                p.Property(p => p.InvoiceId).HasColumnName("invoiceid");
                p.Property(p => p.Name).HasColumnName("name");
                p.Property(p => p.VatRate).HasColumnName("vatrate")
                    .HasConversion(percentage); 
                p.OwnsOne(p => p.GrossPrice, b =>
                {
                    b.Property(p => p.Currency).HasColumnName("currency");
                    b.Property(p => p.Value).HasColumnName("grossvalue");
                });
                p.OwnsOne(p => p.GrossPricePerUnit, b =>
                {
                    b.Property(p => p.Currency).HasColumnName("currency");
                    b.Property(p => p.Value).HasColumnName("grossperunit");
                });
                p.OwnsOne(p => p.NetPricePerUnit, b =>
                {
                    b.Property(p => p.Currency).HasColumnName("currency");
                    b.Property(p => p.Value).HasColumnName("netperunit");
                });
                p.OwnsOne(p => p.NetPrice, b =>
                {
                    b.Property(p => p.Currency).HasColumnName("currency");
                    b.Property(p => p.Value).HasColumnName("netprice");
                });
                p.OwnsOne(p => p.VatValue, b =>
                {
                    b.Property(p => p.Currency).HasColumnName("currency");
                    b.Property(p => p.Value).HasColumnName("vatvalue");
                });
                p.Property(p => p.Quantity).HasColumnName("quantity");

                p.WithOwner().HasForeignKey(p => p.InvoiceId);
            });
        }
    }
}
