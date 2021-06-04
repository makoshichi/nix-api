using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using NixService;
using NixService.DTOs;
using NixWeb.Controllers.Base;
using System.Threading.Tasks;

namespace NixWeb.Controllers
{
    /// <summary>
    /// Controller para execução de compras e emissão de extrato na modalidade débito
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DebtController : AbstractController<DebtAccount, DebtAccountDto>
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="service">Interface para serviços relacionados a operações de débito</param>
        public DebtController(IFinancialAccountService<DebtAccount, DebtAccountDto> service) : base(service)
        {
        }

        /// <summary>
        /// Executa uma compra no débito
        /// </summary>
        /// <param name="purchase">Encapsula número do método de pagamento, valor da compra e descrição</param>
        /// <returns>Mensagem de Sucesso</returns>
        [HttpPost("Purchase")]
        public override async Task<IActionResult> Purchase([FromBody] PurchaseDto purchase)
        {
            return await base.Purchase(purchase);
        }

        /// <summary>
        /// Recupera extrato de débito de acordo com o filtro de data
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
