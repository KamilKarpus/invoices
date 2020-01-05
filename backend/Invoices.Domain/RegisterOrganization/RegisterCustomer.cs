using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices.Domain.RegisterOrganization
{
    public class RegisterCustomer
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Guid OrganizationId { get; private set; }
        public RegisterCustomer(Guid id, string name, string surname, Guid organizationId)
        {
            Id = Guid.NewGuid();
            CustomerId = id;
            Name = name;
            Surname = surname;
            OrganizationId = organizationId;
        }
    }
}
