using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Domain.Pagination;
using Infrastructure;
using Invoices.Application.ReadModels;
using MediatR;

namespace Invoices.Application.Queries.Handlers
{
    public class GetManyInvoicesShortViewHandler : IRequestHandler<GetManyInvoicesQuery, PagedList<InvoicesShortView>>
    {
        private readonly ISqlConnectionFactory _factory;
        public GetManyInvoicesShortViewHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<PagedList<InvoicesShortView>> Handle(GetManyInvoicesQuery request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var result = await conn.QueryAsync<InvoicesShortView>("SELECT i.id, i.creationdate, i.paymentdeadline, i.lefttopay, i.status, r.name, r.surname " +
                "FROM public.invoice i " +
                "join registercustomer r on i.customerid = r.id;");
            return new PagedList<InvoicesShortView>(result.AsQueryable(),request.PageSize, request.CurrentPage, order => order.CreationDate.ToString());
        }
    }
}
