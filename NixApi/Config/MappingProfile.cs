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
            CreateMap<CreditAccount, CreditStatementDto>();
            CreateMap<DebtAccount, DebtStatementDto>();
            CreateMap<Client, ClientDto>();

            // DTO to Domain
            CreateMap<CreditStatementDto, CreditAccount>();
            CreateMap<DebtStatementDto, DebtAccount>();
            CreateMap<ClientDto, ClientDto>();
        }
    }
}