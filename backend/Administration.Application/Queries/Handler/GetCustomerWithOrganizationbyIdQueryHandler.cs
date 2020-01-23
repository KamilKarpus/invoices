using System.Threading;
using System.Threading.Tasks;
using Administration.Application.ReadModels.Customer;
using Dapper;
using Infrastructure;
using MediatR;

namespace Administration.Application.Queries.Handler
{
    public class GetCustomerWithOrganizationbyIdQueryHandler : IRequestHandler<GetCustomerWithOrganizationbyIdQuery, CustomerOrganizationView>
    {
        private readonly ISqlConnectionFactory _factory;
        public GetCustomerWithOrganizationbyIdQueryHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<CustomerOrganizationView> Handle(GetCustomerWithOrganizationbyIdQuery request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var result = await conn.QuerySingleAsync<CustomerOrganizationView>(
                "SELECT c.id, c.name, c.surname, o.name as OrganizationName, o.id as OrganizationId, o.street as Adress"
                + " ,o.city as City, o.PostalCode as PostalCode, o.nip as Nip"
                + " FROM public.registercustomer c"
                + " join registercustomerorganization o on c.id_organization = o.id"
                + " where c.Id = @Id", new { Id = request.CustomerId });
            return result;
        }
    }
}
