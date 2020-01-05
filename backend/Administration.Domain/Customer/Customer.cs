using Domain.Enitity;
using System;

namespace Administration.Domain.Customers
{
    public class Customer : IEntity
    { 
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Guid OrganizationId { get; private set; }
        public Customer(Guid id, string name, string surname, Guid organizationId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            OrganizationId = organizationId;
        }
    }
}
