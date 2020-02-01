using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoices.Application.Commands;
using Invoices.Application.Configuration.Module;
using Invoices.Model;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Controllers
{
    [Route("api/invoices")]
    public class InvoicesController : Controller
    {
        private readonly IInvoicesModule _module;
        public InvoicesController(IInvoicesModule module)
        {
            _module = module;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Invoice.Add add)
        {
            Guid id = Guid.NewGuid();
            await _module.ExecuteCommand(new AddInvoicesCommand(id, add.CustomerId, add.SellerId, add.Currency, add.VatRate));
            return Created($"api/invoices/{id}", new { Id = id });
        }
        [HttpPost]
        [Route("product")]
        public async Task<IActionResult> AddProduct([FromBody]Invoice.AddProduct add)
        {
            Guid id = Guid.NewGuid();
            await _module.ExecuteCommand(new AddProductCommand(id, add.InvoiceId, add.Name, add.NetPrice, add.Quantity));
            return Created($"api/invoices/product/{id}", new { Id = id });

        }
        [HttpPut("{id}/products")]
        public async Task<IActionResult> Update(Guid id, [FromBody]Invoice.Update.Product product)
        {
            await _module.ExecuteCommand(new UpdateProductCommand()
            {
                InvoiceId = id,
                Name = product.Name,
                NetPrice = product.NetPrice,
                ProductId = product.ProductId,
                Quantity = product.Quantity
            });
            return Ok();
        }
        [HttpDelete("{id}/products/{productId}")]
        public async Task<IActionResult> Delete(Guid id, Guid productId)
        {
            await _module.ExecuteCommand(new DeleteProductFromInvoiceCommand()
            {
                InvoiceId = id,
                ProductId = productId
            });
            return Ok();
        }

        [HttpPut("{id}/issue")]
        public async Task<IActionResult> IssueInvoice(Guid id)
        {
            await _module.ExecuteCommand(new IssueInvoiceCommand()
            {
                Id = id
            });
            return Ok();
        }
    } 
}