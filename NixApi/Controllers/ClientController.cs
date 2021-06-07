using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NixService.DTOs;
using NixService;
using Newtonsoft.Json;

namespace NixWeb.Controllers
{
    /// <summary>
    /// Controller para abertura de contas e listagem das mesmas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        readonly IClientService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public ClientController(IClientService service) : base()
        {
            _service = service;
        }

        /// <summary>
        /// Método para abertura de conta
        /// </summary>
        /// <param name="client">Encapsula os parametros do cliente: nome, limite de crédito, fundos iniciais, número da conta e número do cartão. Todos os campos são gerados automaticamente se deixados em branco, exceto ClientName, que é obrigatório</param>
        /// <returns>Mensagem de sucesso</returns>
        [HttpPost("OpenAccount")]
        public async Task<IActionResult> OpenAccount([FromBody] ClientDto client)
        {
            client = await _service.SaveAsync(client);
            var response = $"Conta criada com sucesso para o cliente {client.ClientName}.\r\nNúmero da Conta: {client.AccountNumber}. Fundo inicial: {client.InitialFunds}\r\nCartão de Crédito: {client.CreditCardNumber}. Limite: {client.CreditCardLimit}";
            return Ok(response); // As exceções são gerenciadas pelo HttpResponseExceptionFilter
        }

        /// <summary>
        /// Método para listagem das contas/clientes
        /// </summary>
        /// <returns>Listagem das contas/clientes</returns>
        [HttpGet("GetClients")]
        public IActionResult GetClients()
        {
            var response = _service.GetClients();
            return Ok(response);
        }
    }
}
