using Microsoft.AspNetCore.Mvc;
using NixWeb.Controllers.Base;
using System.Threading.Tasks;
using NixService.DTOs;
using Domain.Models;
using NixService;
using System;

namespace NixWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : AbstractController<CreditAccount, CreditAccountDto>
    {
        public CreditController(IFinancialAccountService<CreditAccount, CreditAccountDto> service) : base(service)
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
