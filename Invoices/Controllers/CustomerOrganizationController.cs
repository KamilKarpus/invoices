using Administration.Application.Commands;
using Administration.Application.Configuration;
using Invoices.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Invoices.Controllers
{
    [Route("api/organization")]
    public class CustomerOrganizationController : Controller
    {
        IAdministrationModule _module;
        public CustomerOrganizationController(IAdministrationModule module)
        {
            _module = module;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CustomerOrganization.AddCustomerOrganization organization)
        {
            var id = Guid.NewGuid();
            await _module.ExecuteCommand(new AddCustomerOrganizationCommand(id,organization.Name,
                organization.Street,organization.City,organization.PostalCode,organization.Nip));
            return Created($"api/customer/organization/{id}", new { Id = id });
        }
    }
}
