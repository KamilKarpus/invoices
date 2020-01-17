using Domain.Pagination;
using Invoices.Application.Configuration.Module;
using Invoices.Application.Queries;
using Invoices.Application.ReadModels;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetInvoices([FromQuery]Get.GetPagginationInvoices request)
        {
            var result = await _module.ExecuteQuery<PagedList<InvoicesShortView>>(new GetManyInvoicesQuery() 
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize
            });
            return Ok(result);
        }
    }
}