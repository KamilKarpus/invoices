using System;

namespace Invoices.Domain
{
    public class RegisterSeller
    {
        public Guid Id { get; private set; }
        public Guid SellerId { get; private set; }
        public string CompanyName { get; private set; }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string BankName { get; private set; }

        public string BankAccountNumber { get; private set; }
        public string BankSwift { get; private set; }
        public string NIP { get; private set; }
        public DateTime ModifyDate { get; private set; }

        private RegisterSeller() { }
        public RegisterSeller(Guid id, string companyName, string street, string city, string postalCode, string bankName,
            string bankAccountNumber, string bankSwift, string nip)
        {
            Id = Guid.NewGuid();
            SellerId = id;
            CompanyName = companyName;
            Street = street;
            City = city;
            PostalCode = postalCode;
            BankName = bankName;
            BankAccountNumber = bankAccountNumber;
            BankSwift = bankSwift;
            NIP = nip;
            ModifyDate = DateTime.Now;
        }
    }
}
