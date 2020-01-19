using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.ReadModels.Customer
{
    public class CustomerNameView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OrganizationName { get; set; }
        public string FullName { get => $"{Name} {Surname}, {OrganizationName}"; }
    }
}
