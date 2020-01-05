using Domain;
using Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Domain.Invoices
{
    public class Product : IEntity
    {
        public Guid Id { get; private set; }
        public Guid InvoiceId { get; private set; }
        public string Name { get; private set; }
        public Money NetPrice { get; private set; }
        public Money GrossPrice { get; private set; }
        public Percentage VatRate { get; private set; }
        public int Quantity { get; private set; }
        public Money NetPricePerUnit { get; private set; }
        public Money GrossPricePerUnit { get; private set; }
        public Money VatValue { get; private set; }
        private Product()
        {

        }
        public Product(Guid id, Guid invoiceId ,string name, decimal netPrice, Percentage vatRate, string currency, int quantity)
        {
            Id = id;
            Name = name;
            NetPricePerUnit = new Money(netPrice, currency);
            var grossPrice = (netPrice + (netPrice * vatRate.Fraction));
            GrossPricePerUnit = new Money(grossPrice,currency);
            NetPrice = NetPricePerUnit * quantity;
            GrossPrice = GrossPricePerUnit * quantity;
            VatValue = new Money((netPrice * vatRate.Fraction), currency);
            VatRate = vatRate;
            InvoiceId = invoiceId;
            Quantity = quantity;
        }
    }
}
