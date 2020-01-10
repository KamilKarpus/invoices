using Administration.Application.ReadModels.Customer;
using Dapper;
using Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Application.Queries.Handler
{
    public class GetCustomerByOrganizartionViewHandler : IRequestHandler<GetCustomerByOrganizationQueryView, IEnumerable<CustomerView>>
    {
        private readonly ISqlConnectionFactory _factory;
        public GetCustomerByOrganizartionViewHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<CustomerView>> Handle(GetCustomerByOrganizationQueryView request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var result = await  conn.QueryAsync<CustomerView>("SELECT id, name, surname "
              +"FROM public.customer where id_organization = @id;", new {id = request.OrganizationId });
            return result;
        }
    }
}
