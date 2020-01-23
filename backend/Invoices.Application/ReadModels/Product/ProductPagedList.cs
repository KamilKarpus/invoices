using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Pagination;

namespace Invoices.Application.ReadModels.Product
{
    public class ProductPagedList : PagedList<ProductView>
    {
        public Guid Id { get; set; }
        public decimal NetToPay { get; set; }
        public decimal GrossToPay { get; set; }
        public ProductPagedList(Guid id, decimal netToPay, decimal grossToPay,
            IQueryable<ProductView> items, int pageSize, int currentPage, Expression<Func<ProductView, string>> orderByExpression) : base(items, pageSize, currentPage, orderByExpression)
        {
            Id = id;
            NetToPay = netToPay;
            GrossToPay = grossToPay;
        }
    }
}
