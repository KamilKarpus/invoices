using Administration.Application.ReadModels;
using Dapper;
using Infrastructure;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Administration.Application.Queries.Handler
{
    public class GetSellerInfoQueryHandler : IRequestHandler<GetSellerInfoQuery, SellerReadModel>
    {
        ISqlConnectionFactory _conn;
        public GetSellerInfoQueryHandler(ISqlConnectionFactory conn)
        {
            _conn = conn;
        }
        public async Task<SellerReadModel> Handle(GetSellerInfoQuery request, CancellationToken cancellationToken)
        {
            var conn = _conn.GetConnection();
            var result = await conn.QuerySingleAsync<SellerReadModel>("SELECT id, companyname, street, city, postalcode,"
                + "bankname, bankaccountnumber, bankswift, modifydate, version, nip" 
                +" FROM public.seller where id=@Id;", new { Id = request.SellerId });
            return result;
        }
    }
}
