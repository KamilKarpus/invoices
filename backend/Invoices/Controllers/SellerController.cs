using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Administration.Application.Commands;
using Administration.Application.Configuration;
using Invoices.Model;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.Controllers
{
    [Route("api/seller")]
    public class SellerController : Controller
    {
        IAdministrationModule _module;
        public SellerController(IAdministrationModule module)
        {
            _module = module;
        }
        [HttpPost]
        public async Task<IActionResult> AddSeller([FromBody]Seller.AddSeller seller)
        {
            var sellerId = Guid.NewGuid();
            await _module.ExecuteCommand(new AddSellerCommand()
            {
                SellerId = sellerId,
                BankAccountNumber = seller.BankAccountNumber,
                BankName = seller.BankName,
                BankSwift = seller.BankSwift,
                City = seller.City,
                Street = seller.Street,
                CompanyName = seller.CompanyName,
                NIP = seller.NIP,
                PostalCode = seller.PostalCode
            });
            return Created($"api/seller/{sellerId}", new { Id = sellerId });
        }
    }
}