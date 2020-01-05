using EventServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adminstration.IntegrationEvents
{
    public class OrganiationCreatedIntegrationEvent : IIntegrationEvent
    {
        public Guid OrganizationId { get; private set; }
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Nip { get; private set; }
        public OrganiationCreatedIntegrationEvent(Guid id, string name, string street, string city, string postalcode, string nip)
        {
            OrganizationId = id;
            Name = name;
            Street = street;
            City = city;
            PostalCode = postalcode;
            Nip = nip;
        }
    }
}
