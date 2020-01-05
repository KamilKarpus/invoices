using Invoices.Common.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Domain.DomainEvents.Organization
{
    public class AddCustomerDomainEvent : DomainEvent
    {
        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public Guid OrganizationId { get; private set; }
        public AddCustomerDomainEvent(Guid customerid, string name, string lastName, Guid organizationid)
        {
            CustomerId = customerid;
            Name = name;
            LastName = lastName;
            OrganizationId = organizationid;
        }
    }
}
