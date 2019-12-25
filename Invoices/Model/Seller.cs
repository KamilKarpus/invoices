using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Model
{
    public static class Seller
    {
        public class AddSeller
        {
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
}
