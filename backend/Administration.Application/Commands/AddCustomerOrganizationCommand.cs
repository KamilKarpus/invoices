using Administration.Application.Configuration.Processing;
using System;

namespace Administration.Application.Commands
{
    public class AddCustomerOrganizationCommand : ICommand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Nip { get; private set; }

        public AddCustomerOrganizationCommand(Guid id, string name, string street, string city, string postalcode, string nip)
        {
            Id = id;
            Name = name;
            Street = street;
            City = city;
            PostalCode = postalcode;
            Nip = nip;
        }
    }
}
