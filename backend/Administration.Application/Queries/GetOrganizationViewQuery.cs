using Administration.Application.Configuration.Processing;
using Administration.Application.ReadModels.Customer;
using System;

namespace Administration.Application.Queries
{
    public class GetOrganizationViewQuery : IQuery<OrganizationView>
    {
        public Guid Id { get; set; }
    }
}
