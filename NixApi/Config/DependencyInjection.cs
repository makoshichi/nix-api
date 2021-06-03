using Domain.Models.Base;
using Microsoft.Extensions.DependencyInjection;
using NixRepository;
using NixRepository.Repositories;
using NixService;
using NixService.DTOs.Base;
using NixService.Services.Base;

namespace NixWeb.Config
{
    public static class DependencyInjection
    {
        public static void AddScoped(IServiceCollection services)
        {
            services.AddScoped<IStatementService<BaseAccount, BaseStatementDto>, AbstractStatementService<BaseAccount, BaseStatementDto>>();
            services.AddScoped<IStatementRepository<BaseAccount>, AbstractStatementRepository<BaseAccount>>();
            services.AddScoped<IClientAccountRepository, ClientAccountRepository>();
        }
    }
}
