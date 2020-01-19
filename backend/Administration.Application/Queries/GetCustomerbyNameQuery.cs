using Administration.Application.Configuration.Processing;
using Administration.Application.ReadModels.Customer;
using System.Collections.Generic;

namespace Administration.Application.Queries
{
    public class GetCustomerbyNameQuery : IQuery<IEnumerable<CustomerNameView>>
    {
        public string FullName { get; set; }
    }
}
