using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoices.Model
{
    public static class Customer
    {
        public class AddCustomer
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public Guid OrganizationId { get; set; }
        }
        public static class Get
        {
            public class GetbyFullName
            {
                public string FullName { get; set; }
            }
        }
    }
}
