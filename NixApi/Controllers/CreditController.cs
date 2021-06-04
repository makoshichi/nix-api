using Microsoft.AspNetCore.Mvc;
using NixWeb.Controllers.Base;
using System.Threading.Tasks;
using NixService.DTOs;
using Domain.Models;
using NixService;

namespace NixWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : AbstractController<CreditAccount, CreditAccountDto>
    {
        public CreditController(IStatementService<CreditAccount, CreditAccountDto> service) : base(service)
        {
        }

        [HttpPost]
        public override async Task<IActionResult> Purchase([FromBody] decimal value, int creditCardNumber, string description)
        {
            return await base.Purchase(value, creditCardNumber, description);
        }

        [HttpGet("{id}")]
        public override IActionResult GetStatement(int accountNumber)
        {
            return base.GetStatement(accountNumber);
        }
    }
}
