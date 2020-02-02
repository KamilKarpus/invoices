using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Infrastructure;
using Invoices.Application.ReadModels;
using MediatR;


namespace Invoices.Application.Queries.Handlers
{
    public class GetCustomFileInfoQueryHandler : IRequestHandler<GetFileInfoQuery, CustomFileInfo>
    {
        private readonly ISqlConnectionFactory _factory;
        public GetCustomFileInfoQueryHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<CustomFileInfo> Handle(GetFileInfoQuery request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var result = await conn.QuerySingleAsync<CustomFileInfo>("SELECT id, occurancedate, typa, filename, path " +
            $"FROM public.files where invoiceId = '{request.Id}'");
            return result;
        }
    }
}
