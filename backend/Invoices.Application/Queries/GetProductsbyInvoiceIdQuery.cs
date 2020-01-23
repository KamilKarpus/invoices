
using Invoices.Application.Configuration.Processing;
using Invoices.Application.ReadModels.Product;
using System;

namespace Invoices.Application.Queries
{
    public class GetProductsbyInvoiceIdQuery : IQuery<ProductPagedList>
    {
        public Guid InvoiceId { get; set; } 
    }
}
