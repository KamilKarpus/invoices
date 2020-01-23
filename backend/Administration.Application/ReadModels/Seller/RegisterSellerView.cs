using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.ReadModels.Seller
{
    public class RegisterSellerView
    {
        public Guid Id { get; set; }
        public string Companyname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string Nip { get; set; }
    }
}
