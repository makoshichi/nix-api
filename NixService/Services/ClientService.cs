using AutoMapper;
using Domain.Models;
using NixRepository;
using NixService.DTOs;
using NixUtil;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NixService.Services
{
    public class ClientService : IClientService
    {
        readonly IClientRepository _repository;
        readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientDto> SaveAsync(ClientDto clientDto)
        {
            var client = new Client()
            {
                ClientName = clientDto.ClientName,
                CreditCardLimit = clientDto.CreditCardLimit ?? 5000,
                InitialFunds = clientDto.InitialFunds ?? 2000,
                AccountNumber = clientDto.AccountNumber ?? Misc.GenerateRandomAccountNumber(),
                CreditCardNumber = clientDto.CreditCardNumber ?? Misc.GenerateRandomCreditCardNumber()
            };

            await _repository.SaveAsync(client);

            return _mapper.Map<ClientDto>(client);
        }

        public IEnumerable<ClientDto> GetClients()
        {
            foreach(var client in _repository.GetClients())
            {
                yield return _mapper.Map<ClientDto>(client);
            }
        }
    }
}
