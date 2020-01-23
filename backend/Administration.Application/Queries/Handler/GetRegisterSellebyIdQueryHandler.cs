using System.Threading;
using System.Threading.Tasks;
using Administration.Application.ReadModels.Seller;
using Dapper;
using Infrastructure;
using MediatR;

namespace Administration.Application.Queries.Handler
{
    public class GetRegisterSellebyIdQueryHandler : IRequestHandler<GetRegisterSellerbyIdQuery, RegisterSellerView>
    {
        private readonly ISqlConnectionFactory _factory;
        public GetRegisterSellebyIdQueryHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<RegisterSellerView> Handle(GetRegisterSellerbyIdQuery request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var result = await conn.QuerySingleAsync<RegisterSellerView>("" +
                "SELECT id, companyname, street, city, postalcode, bankaccountnumber as bankAccountNumber, nip"
               + " FROM public.registerseller"
               + " where id = @Id"
               + " limit 1;", new { Id = request.Id });
            return result;
        }
    }
}
