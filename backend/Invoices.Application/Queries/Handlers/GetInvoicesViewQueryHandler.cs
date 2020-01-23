using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Infrastructure;
using Invoices.Application.ReadModels;
using MediatR;

namespace Invoices.Application.Queries.Handlers
{
    public class GetInvoicesViewQueryHandler : IRequestHandler<GetInvoicesDetailsQuery, InvoicesView>
    {
        public readonly ISqlConnectionFactory _factory;
        public GetInvoicesViewQueryHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<InvoicesView> Handle(GetInvoicesDetailsQuery request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var result = await conn.QuerySingleAsync<InvoicesView>(
                "SELECT id, customerid, creationdate, saledate, " +
                "paymentdeadline, nettopay, grosstopay, paid, lefttopay," +
                " remarks, status, sellerid, currency, vatrate " +
                "FROM public.invoice " +
                "where id = @Id", new { Id = request.Id });
            return result;
        }
    }
}
