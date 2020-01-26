using Domain;
using Invoices.Common.DomainEvents;
using Invoices.Common.Entitys;
using Invoices.Domain.DomainEvents;
using Invoices.Domain.ErrorCodes;
using Invoices.Domain.Errors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoices.Domain.Invoices
{
    public class Invoice : Entity
    {
        private List<Product> _products;
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public InvoicesNumber Number { get; private set; }
        public DateTime SaleDate { get; private set; }

        public DateTime PaymentDeadline { get; private set; }
        public Money GrossToPay { get; private set; }
        public Money NetToPay { get; private set; }
        public Money Paid { get; private set; }

        public Guid SellerId { get; private set; }
        public InvoiceStatus Status { get; private set; }
        public Percentage VatRate { get; private set; }

        private Invoice() 
        {
            _products = new List<Product>();
        }
        public Invoice(Guid id, Guid customerId, Guid sellerId, string currency, 
            DateTime creationDate,  int vatRate) : this()
        {
            Id = id;
            CustomerId = customerId;
            SellerId = sellerId;
            NetToPay = new Money(0, currency);
            GrossToPay = new Money(0, currency);
            Paid = new Money(0, currency);
            CreationDate = creationDate;
            Status = InvoiceStatus.NotIssued;
            VatRate = Percentage.From(vatRate);
            AddDomainEvent(new CreatedInvoiceDomainEvent
            {
                InvoiceId = id
            });
        }

        public void AddProduct(Guid id, Guid invoiceId, string name, decimal netPrice, int quantity)
        {
            if(Status != InvoiceStatus.NotIssued)
            {
                throw new InvoiceException($"[{InvoiceErrorCodes.IssuedError}] You cannot add product to issued invoice.");
            }
            var product = new Product(id, invoiceId, name, netPrice, VatRate, GrossToPay.Currency, quantity);
            _products.Add(product);
            GrossToPay += product.GrossPrice;
            NetToPay += product.NetPrice;
            AddDomainEvent(new AddProductDomainEvent());
        }
        private void ReCalculate()
        {
            Money netToPay = Money.Zero(NetToPay.Currency);
            Money grossToPay = Money.Zero(GrossToPay.Currency);
            _products.ForEach(p =>
                {
                    netToPay += p.NetPrice;
                    grossToPay += p.GrossPrice;
                });
            GrossToPay = grossToPay;
            NetToPay = netToPay;
            
        }
        public void UpdateProduct(Guid id, string name, decimal netprice,int quantity)
        {
            if (Status != InvoiceStatus.NotIssued)
            {
                throw new InvoiceException($"[{InvoiceErrorCodes.IssuedError}] You cannot add product to issued invoice.");
            }
            var product = _products.FirstOrDefault(p => p.Id == id);
            product.UpdateProduct(name, netprice, quantity);
            ReCalculate();
        }

        public void DeleteProduct(Guid productId)
        {
            if (Status != InvoiceStatus.NotIssued)
            {
                throw new InvoiceException($"[{InvoiceErrorCodes.IssuedError}] You cannot add product to issued invoice.");
            }
            var product = _products.FirstOrDefault(p => p.Id == productId);
            _products.Remove(product);
            ReCalculate();
        }

    }
}
