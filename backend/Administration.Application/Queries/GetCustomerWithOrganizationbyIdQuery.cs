using Administration.Application.Configuration.Processing;
using Administration.Application.ReadModels.Customer;
using System;

namespace Administration.Application.Queries
{
    public class GetCustomerWithOrganizationbyIdQuery : IQuery<CustomerOrganizationView>
    {
        public Guid CustomerId { get; set; }
    }
}
