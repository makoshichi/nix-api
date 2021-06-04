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

        [HttpPost("Purchase")]
        public override async Task<IActionResult> Purchase([FromBody] PurchaseDto purchase)
        {
            return await base.Purchase(purchase);
        }

        [HttpPost("GetStatement")]
        public override async Task<IActionResult> GetStatement([FromBody] StatementFilterDto filter)
        {
            return await base.GetStatement(filter);
        }
    }
}
