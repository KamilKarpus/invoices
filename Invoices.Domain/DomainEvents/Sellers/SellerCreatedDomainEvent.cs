using Invoices.Common.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Domain.DomainEvents.Sellers
{
    public class SellerCreatedDomainEvent : DomainEvent
    {
        public Guid SellerId { get; private set; }
        public string CompanyName { get; private set; }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string BankName { get; private set; }

        public string BankAcountNumber { get; private set; }
        public string BankSwift { get; private set; }
        public string NIP { get; private set; }
        public SellerCreatedDomainEvent(Guid id, string companyName, string street, string city, string postalCode, string bankName,
            string bankAcountNumber, string bankSwift, string nip)
        {
            SellerId = id;
            CompanyName = companyName;
            Street = street;
            City = city;
            PostalCode = postalCode;
            BankName = bankName;
            BankAcountNumber = bankAcountNumber;
            BankSwift = bankSwift;
            NIP = nip;
        }
    }
}
