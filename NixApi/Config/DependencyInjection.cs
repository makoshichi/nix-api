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
            services.AddScoped<IFinancialAccountService<BaseAccount, BaseAccountDto>, FinantialAccountService<BaseAccount, BaseAccountDto>>();
            services.AddScoped<IFinancialAccountRepository<BaseAccount>, FinantialAccountRepository<BaseAccount>>();
            services.AddScoped<IClientAccountRepository, ClientAccountRepository>();
        }
    }
}
