using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using NixService;
using NixService.DTOs;
using NixWeb.Controllers.Base;
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
