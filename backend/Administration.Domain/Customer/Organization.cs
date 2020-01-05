using Administration.Domain.DomainEvents.Organization;
using Invoices.Common.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administration.Domain.Customers
{
    public class Organization : Entity
    {
        private List<Customer> _customers;
        public IReadOnlyCollection<Customer> Customers => _customers; 
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Nip { get; private set; }

        private Organization()
        {
            _customers = new List<Customer>();
        }
        public Organization(Guid id, string name, string street, string city, string postalcode, string nip) : this()
        {
            Id = id;
            Name = name;
            Street = street;
            City = city;
            PostalCode = postalcode;
            Nip = nip;
            AddDomainEvent(new OrganizationCreatedDomainEvent(id, name, street, city, postalcode, nip));
        }
        public void AddCustomer(string name, string surname)
        {
            var userid = Guid.NewGuid();
            var customer = new Customer(userid, name, surname, Id);
            _customers.Add(customer);
            AddDomainEvent(new AddCustomerDomainEvent(userid, name, surname, Id));
        }
    }
}
