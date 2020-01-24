using Domain.Pagination;
using Invoices.Application.Configuration.Module;
using Invoices.Application.Queries;
using Invoices.Application.ReadModels;
using Invoices.Application.ReadModels.Product;
using Invoices.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Invoices.Model.Invoice;

namespace Invoices.QueryAPi
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoicesQueryApi : ControllerBase
    {
        private readonly IInvoicesModule _module;
        public InvoicesQueryApi(IInvoicesModule module)
        {
            _module = module;
        }
        [HttpGet]
        public async Task<IActionResult> GetInvoices([FromQuery]Get.GetPaggination request)
        {
            var result = await _module.ExecuteQuery<PagedList<InvoicesShortView>>(new GetManyInvoicesQuery()
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize
            });
            return Ok(result);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(InvoicesView),200)]
        public async Task<IActionResult> GetInvoicesbyId(Guid id)
        {
            var result = await _module.ExecuteQuery<InvoicesView>(new GetInvoicesDetailsQuery()
            {
                Id = id
            });
            return Ok(result);
        }
        [HttpGet("{id}/products")]
        [ProducesResponseType(typeof(ProductPagedList), 200)]
        public async Task<IActionResult> GetProduct(Guid id, [FromQuery]Invoice.Get.GetPaggination paggination)
        {
            var result = await _module.ExecuteQuery<ProductPagedList>(new GetProductsbyInvoiceIdQuery
            {
                InvoiceId = id,
                PageSize = paggination.PageSize,
                CurrentPage = paggination.CurrentPage
            });
            return Ok(result);
        }
    }
}