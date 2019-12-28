using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Domain.RegisterOrganization
{
    public class RegisterOrganization
    {
        public Guid Id { get; private set; }
        public Guid OrganizationId { get; private set; }
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Nip { get; private set; }
        private RegisterOrganization()
        {

        }
        public RegisterOrganization(Guid id, string name, string street, string city, string postalcode, string nip)
        {
            Id = Guid.NewGuid();
            OrganizationId = id;
            Name = name;
            Street = street;
            City = city;
            PostalCode = postalcode;
            Nip = nip;
        }
    }
}
