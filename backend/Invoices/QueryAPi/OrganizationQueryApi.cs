using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Administration.Application.Configuration;
using Administration.Application.Queries;
using Administration.Application.ReadModels.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.QueryAPi
{
    [Route("api/organization")]
    [ApiController]
    public class OrganizationQueryApi: ControllerBase
    { 
        public IAdministrationModule _module;
        public OrganizationQueryApi(IAdministrationModule module)
        {
            _module = module;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizationShortInfo()
        {
            var result = await _module.ExecuteQuery<IEnumerable<OrganizationShortInfoView>>(new GetOrganizationShortInfoQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetOrganization(Guid id)
        {
            var result = await _module.ExecuteQuery<OrganizationView>(new GetOrganizationViewQuery() { Id = id });
            return Ok(result);
        }
        [HttpGet("{id}/customers")]
        public async Task<IActionResult> GetCustomers(Guid id)
        {
            var result = await _module.ExecuteQuery<IEnumerable<CustomerView>>(new GetCustomerByOrganizationQueryView() { OrganizationId = id });
            return Ok(result);
        }
    }
}