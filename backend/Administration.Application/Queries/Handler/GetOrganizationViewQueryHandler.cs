using System.Threading;
using System.Threading.Tasks;
using Administration.Application.ReadModels.Customer;
using Dapper;
using Infrastructure;
using MediatR;
namespace Administration.Application.Queries.Handler
{
    public class GetOrganizationViewQueryHandler : IRequestHandler<GetOrganizationViewQuery, OrganizationView>
    {
        private readonly ISqlConnectionFactory _sqlFactory;
        public GetOrganizationViewQueryHandler(ISqlConnectionFactory factory)
        {
            _sqlFactory = factory;
        }
        public async Task<OrganizationView> Handle(GetOrganizationViewQuery request, CancellationToken cancellationToken)
        {
            var conn = _sqlFactory.GetConnection();
            var result = await conn.QuerySingleAsync<OrganizationView>("SELECT id, name, street, city, postalcode, nip"
             + " FROM public.customerorganization where id = @id", new { id = request.Id });
            return result;
        }
    }
}
