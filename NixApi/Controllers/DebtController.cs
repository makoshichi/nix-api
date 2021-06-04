﻿using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using NixService;
using NixService.DTOs;
using NixWeb.Controllers.Base;
using System;
using System.Threading.Tasks;

namespace NixWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtController : AbstractController<DebtAccount, DebtAccountDto>
    {
        public DebtController(IFinancialAccountService<DebtAccount, DebtAccountDto> service) : base(service)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> Purchase([FromBody] PurchaseDto purchase)
        {
            return await base.Purchase(purchase);
        }

        [HttpGet("{id}")]
        public override IActionResult GetStatement(int accountNumber, DateTime startDate, DateTime endDate)
        {
            return base.GetStatement(accountNumber, startDate, endDate);
        }
    }
}
