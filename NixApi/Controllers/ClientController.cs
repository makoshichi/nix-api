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
            return Ok(await _service.SaveAsync(client)); // As exceções são gerenciadas pelo HttpResponseExceptionFilter
        }

        [HttpGet("GetClients")]
        public IActionResult GetClients()
        {
            var response = JsonConvert.SerializeObject(_service.GetClients());
            return Ok(response);
        }
    }
}
