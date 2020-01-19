using Administration.Application.ReadModels.Customer;
using Dapper;
using Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Application.Queries.Handler
{
    public class GetCustomerbyNameQueryHandler : IRequestHandler<GetCustomerbyNameQuery, IEnumerable<CustomerNameView>>
    {
        private readonly ISqlConnectionFactory _factory;
        public GetCustomerbyNameQueryHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<CustomerNameView>> Handle(GetCustomerbyNameQuery request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var result = await conn.QueryAsync<CustomerNameView>(
                "SELECT c.id, c.name, c.surname, o.name as OrganizationName "
                + "FROM customer c "
                + "JOIN customerorganization o on c.id_organization = o.id "
                + $"WHERE LOWER(CONCAT(c.name, ' ', c.surname)) LIKE LOWER('%{request.FullName}%')");
            return result;
        }
    }
}
