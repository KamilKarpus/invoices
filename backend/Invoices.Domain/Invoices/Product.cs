﻿using Domain;
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
            VatRate = vatRate;
            InvoiceId = invoiceId;
            Quantity = quantity;
            ReCalculate(netPrice, currency, vatRate, quantity);
        }
        private void ReCalculate(decimal netPrice, string currency, Percentage vatRate, int quantity)
        {
            var grossPrice = (netPrice + (netPrice * vatRate.Fraction));
            GrossPricePerUnit = new Money(grossPrice, currency);
            NetPrice = NetPricePerUnit * quantity;
            GrossPrice = GrossPricePerUnit * quantity;
            VatValue = new Money((netPrice * vatRate.Fraction), currency);
        }
        public void UpdateProduct(string name, decimal netprice, int quantity)
        {
            Name = name;
            NetPricePerUnit = new Money(netprice, NetPrice.Currency);
            Quantity = quantity;
            ReCalculate(netprice, NetPricePerUnit.Currency, VatRate, quantity);


        }
    }
}
