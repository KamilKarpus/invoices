using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.ReadModels.Customer
{
    public class OrganizationView
    {
        public Guid Id { get; set; }
        public string Name { get;  set; }
        public string Street { get;  set; }
        public string City { get;  set; }
        public string PostalCode { get; set; }
        public string Nip { get; set; }

    }
}
