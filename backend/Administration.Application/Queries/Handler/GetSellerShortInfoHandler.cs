using Administration.Application.ReadModels;
using Dapper;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Application.Queries.Handler
{
    public class GetSellerShortInfoQueryHandler : IRequestHandler<GetSellerShortInfoQuery, IEnumerable<SellerShortInfo>>
    {
        ISqlConnectionFactory _conn;
        public GetSellerShortInfoQueryHandler(ISqlConnectionFactory conn)
        {
            _conn = conn;
        }
        public async Task<IEnumerable<SellerShortInfo>> Handle(GetSellerShortInfoQuery request, CancellationToken cancellationToken)
        {
           var connection =  _conn.GetConnection();
           var result =  await connection.QueryAsync<SellerShortInfo>("SELECT id, companyname, nip FROM public.seller");
           return result;
        }
    }
}
