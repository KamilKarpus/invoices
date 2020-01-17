using Domain.Pagination;
using Invoices.Application.Configuration.Processing;
using Invoices.Application.ReadModels;

namespace Invoices.Application.Queries
{
    public class GetManyInvoicesQuery : IQuery<PagedList<InvoicesShortView>>
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
