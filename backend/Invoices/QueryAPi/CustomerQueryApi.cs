using Administration.Application.Configuration;
using Administration.Application.Queries;
using Administration.Application.ReadModels.Customer;
using Invoices.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoices.QueryAPi
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerQueryApi : ControllerBase
    {
        public IAdministrationModule _module;
        public CustomerQueryApi(IAdministrationModule module)
        {
            _module = module;
        }
       
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerNameView>),200)]
        public async Task<IActionResult> GetbyFullName([FromQuery]string fullName)
        {
            var result = await _module.ExecuteQuery<IEnumerable<CustomerNameView>>(new GetCustomerbyNameQuery()
            {
                FullName = fullName
            });
            return Ok(result);
        }
    }
}
