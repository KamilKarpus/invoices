using Administration.Application.Configuration.Processing;
using Administration.Application.ReadModels.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Application.Queries
{
    public class GetCustomerByOrganizationQueryView : IQuery<IEnumerable<CustomerView>>
    {
        public Guid OrganizationId { get; set; }
    }
}
