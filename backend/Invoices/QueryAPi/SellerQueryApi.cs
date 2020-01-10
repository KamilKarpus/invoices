﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Administration.Application.Configuration;
using Administration.Application.Queries;
using Administration.Application.ReadModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.QueryAPi
{
    [Route("api/seller")]
    [ApiController]
    public class SellerQueryApi : ControllerBase
    {
        public IAdministrationModule _module;
        public SellerQueryApi(IAdministrationModule module)
        {
            _module = module;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetSellerShortInfo()
        {
            var result = await _module.ExecuteQuery<IEnumerable<SellerShortInfo>>(new GetSellerShortInfoQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeller(Guid id)
        {
            var result = await _module.ExecuteQuery<SellerReadModel>(new GetSellerInfoQuery() { SellerId = id});
            return Ok(result);
        }
    }
}