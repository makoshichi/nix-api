using Microsoft.AspNetCore.Mvc;
using NixWeb.Controllers.Base;
using System.Threading.Tasks;
using NixService.DTOs;
using Domain.Models;
using NixService;
using System;

namespace NixWeb.Controllers
{
    /// <summary>
    /// Controller para execução de compras e emissão de extrato na modalidade crédito
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : AbstractController<CreditAccount, CreditAccountDto>
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="service">Interface para serviços relacionados a operações de crédito</param>
        public CreditController(IFinancialAccountService<CreditAccount, CreditAccountDto> service) : base(service)
        {
        }

        /// <summary>
        /// Executa uma compra no crédito
        /// </summary>
        /// <param name="purchase">Encapsula número do método de pagamento, valor da compra e descrição</param>
        /// <returns>Mensagem de sucesso</returns>
        [HttpPost("Purchase")]
        public override async Task<IActionResult> Purchase([FromBody] PurchaseDto purchase)
        {
            return await base.Purchase(purchase);
        }

        /// <summary>
        /// Recupera extrato de crédito de acordo com o filtro de data
        /// </summary>
        /// <param name="filter">Encapsula de número do metodo de pagamento e datas inicial e final</param>
        /// <returns>Extrato do período informado</returns>
        [HttpPost("GetStatement")]
        public override async Task<IActionResult> GetStatement([FromBody] StatementFilterDto filter)
        {
            return await base.GetStatement(filter);
        }
    }
}
