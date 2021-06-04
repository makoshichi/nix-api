using NixService.DTOs;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NixService
{
    public interface IClientService
    {
        Task<ClientDto> SaveAsync(ClientDto client);

        IEnumerable<ClientDto> GetClients();
    }
}
