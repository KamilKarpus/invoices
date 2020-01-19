using Administration.Application.ReadModels;
using Dapper;
using Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Application.Queries.Handler
{
    public class GetSellerByCompanyNameQueryHandler : IRequestHandler<GetSellerbyCompanyNameQuery, IEnumerable<SellerCompanyName>>
    {
        private readonly ISqlConnectionFactory _factory;
        public GetSellerByCompanyNameQueryHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<SellerCompanyName>> Handle(GetSellerbyCompanyNameQuery request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var result = await conn.QueryAsync<SellerCompanyName>("SELECT id, companyname " +
                "FROM public.seller " +
                $"where companyname like '%{request.CompanyName}%'");
            return result;
        }
    }
}
