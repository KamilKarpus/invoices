using Administration.Application.ReadModels.Customer;
using Dapper;
using Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Application.Queries.Handler
{
    public class GetOrganizationShortInfoQueryHandler : IRequestHandler<GetOrganizationShortInfoQuery, IEnumerable<OrganizationShortInfoView>>
    {
        private readonly ISqlConnectionFactory _sqlFactory;
        public GetOrganizationShortInfoQueryHandler(ISqlConnectionFactory factory)
        {
            _sqlFactory = factory;
        }
        public async Task<IEnumerable<OrganizationShortInfoView>> Handle(GetOrganizationShortInfoQuery request, CancellationToken cancellationToken) 
        { 
            var connection = _sqlFactory.GetConnection();
            var result = await connection.QueryAsync<OrganizationShortInfoView>("SELECT id, name, nip, street FROM public.customerorganization;");
            return result;
        }
    }
}
