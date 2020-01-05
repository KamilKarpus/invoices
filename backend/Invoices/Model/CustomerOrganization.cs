using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Model
{
    public static class CustomerOrganization
    {
        public class AddCustomerOrganization
        {
            public string Name { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string PostalCode { get; set; }
            public string Nip { get; set; }
        }
    }
}
