using AutoMapper;
using Domain.Models;
using NixService.DTOs;

namespace NixWeb.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<CreditAccount, CreditAccountDto>();
            CreateMap<DebtAccount, DebtAccountDto>();
            CreateMap<Client, ClientDto>();

            // DTO to Domain
            CreateMap<CreditAccountDto, CreditAccount>();
            CreateMap<DebtAccountDto, DebtAccount>();
            CreateMap<ClientDto, ClientDto>();
        }
    }
}