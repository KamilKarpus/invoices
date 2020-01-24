using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Infrastructure;
using Invoices.Application.ReadModels.Product;
using MediatR;

namespace Invoices.Application.Queries.Handlers
{
    public class GetProductByInvoiceIdQueryHandler : IRequestHandler<GetProductsbyInvoiceIdQuery, ProductPagedList>
    {
        private readonly ISqlConnectionFactory _factory;
        public GetProductByInvoiceIdQueryHandler(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
        public async Task<ProductPagedList> Handle(GetProductsbyInvoiceIdQuery request, CancellationToken cancellationToken)
        {
            var conn = _factory.GetConnection();
            var result = await conn.QueryAsync<ProductDTO>(
                "SELECT i.id, i.nettopay, i.grosstopay, p.name, p.netperunit, p.grossperunit, p.quantity, p.id as productId" +
                " FROM public.invoice i " +
                " inner join product p on i.id = p.invoiceid" +
                " where i.id= @Id", new { Id = request.InvoiceId });
            var products = result.Select(p => new ProductView()
            {
                ProductId = p.ProductId,
                Grossperunit = p.Grossperunit,
                Netperunit = p.Netperunit,
                Quantity = p.Quantity,
                Name = p.Name
            }).AsQueryable();
            var invoice = result.FirstOrDefault();
            return new ProductPagedList(invoice.Id, invoice.Nettopay, invoice.Grosstopay, products, request.PageSize, request.CurrentPage, p => p.Grossperunit.ToString());

        }
    }
}
