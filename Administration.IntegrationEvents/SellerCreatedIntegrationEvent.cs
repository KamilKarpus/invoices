using EventServiceBus.Models;
using System;

namespace Adminstration.IntegrationEvents
{
    public class SellerCreatedIntegrationEvent : IIntegrationEvent
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
        public SellerCreatedIntegrationEvent(Guid id, string companyName, string street, string city, string postalCode, string bankName,
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
