using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NixService.DTOs;
using NixService;
using Newtonsoft.Json;

namespace NixWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        readonly IClientService _service;

        public ClientController(IClientService service) : base()
        {
            _service = service;
        }

        [HttpPost("OpenAccount")]
        public async Task<IActionResult> OpenAccount([FromBody] ClientDto client)
        {
            client = await _service.SaveAsync(client);
            var response = $"Conta criada com sucesso para o cliente {client.ClientName}.\r\nNúmero da Conta: {client.AccountNumber}. Fundo inicial: {client.Funds}\r\nCartão de Crédito: {client.CreditCardNumber}. Limite: {client.CreditCardLimit}";
            return Ok(response); // As exceções são gerenciadas pelo HttpResponseExceptionFilter
        }

        [HttpGet("GetClients")]
        public IActionResult GetClients()
        {
            var response = JsonConvert.SerializeObject(_service.GetClients());
            return Ok(response);
        }
    }
}
