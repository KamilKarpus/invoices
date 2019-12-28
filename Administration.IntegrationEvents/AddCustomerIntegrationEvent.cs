using EventServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adminstration.IntegrationEvents
{
    public class AddCustomerIntegrationEvent : IIntegrationEvent
    {
        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public Guid OrganizationId { get; private set; }
        public AddCustomerIntegrationEvent(Guid customerid, string name, string lastName, Guid organizationid)
        {
            CustomerId = customerid;
            Name = name;
            LastName = lastName;
            OrganizationId = organizationid;
        }
    }
}
