using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.ReadModels.Customer
{
    public class OrganizationShortInfoView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string Street { get; set; }
    }
}
