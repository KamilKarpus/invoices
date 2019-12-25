using Administration.Domain.DomainEvents.Sellers;
using Invoices.Common.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Domain.Sellers
{
    public class Seller : AggregateRoot
    {
        public Guid Id { get; private set; }
        public string CompanyName { get; private set; }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string BankName { get; private set; }

        public string BankAccountNumber { get; private set; }
        public string BankSwift { get; private set; }
        public string NIP { get; private set; }

        private Seller() { }
        public Seller(string companyName, string street, string city, string postalCode, string bankName, 
            string bankAccountNumber, string bankSwift, string nip)
        {
            Id = Guid.NewGuid();
            CompanyName = companyName;
            Street = street;
            City = city;
            PostalCode = postalCode;
            BankName = bankName;
            BankAccountNumber = bankAccountNumber;
            BankSwift = bankSwift;
            NIP = nip;
            AddDomainEvent(new SellerCreatedDomainEvent(Id,CompanyName, Street, City, PostalCode, BankName, BankAccountNumber,BankSwift, NIP));
        }

    }
}
