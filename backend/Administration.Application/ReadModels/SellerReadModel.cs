using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.ReadModels
{
    public class SellerReadModel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BankName { get; set; }

        public string BankAccountNumber { get; set; }
        public string BankSwift { get; set; }
        public string NIP { get; set; }
    }
}
