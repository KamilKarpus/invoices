using System;

namespace Administration.Application.ReadModels.Customer
{
    public class CustomerOrganizationView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OrganizationName { get; set; }
        public Guid OrganizationId { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Nip { get; set; }
    }
}
