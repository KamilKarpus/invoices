using System;
using System.Threading.Tasks;
using Administration.Application.Commands;
using Administration.Application.Configuration;
using Invoices.Model;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Controllers
{
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly IAdministrationModule _module;
        public CustomerController(IAdministrationModule module)
        {
            _module = module;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody]Customer.AddCustomer customer)
        {
            var id = Guid.NewGuid();
            await _module.ExecuteCommand(new AddCustomerCommand(id,customer.Name,customer.Surname,customer.OrganizationId));
            return Created($"api/customer/{id}", new { Id = id });
        }
    }
}