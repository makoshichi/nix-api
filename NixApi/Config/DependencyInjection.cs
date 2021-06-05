using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using NixRepository;
using NixRepository.Repositories;
using NixService;
using NixService.DTOs;
using NixService.Services;

namespace NixWeb.Config
{
    public static class DependencyInjection
    {
        public static void AddScoped(IServiceCollection services)
        {
            services.AddScoped<IFinancialAccountService<DebtAccount, DebtAccountDto>, DebtService<DebtAccount, DebtAccountDto>>();
            services.AddScoped<IFinancialAccountService<CreditAccount, CreditAccountDto>, CreditService<CreditAccount, CreditAccountDto>>();
            services.AddScoped<IFinancialAccountRepository<DebtAccount>, FinantialAccountRepository<DebtAccount>>();
            services.AddScoped<IFinancialAccountRepository<CreditAccount>, FinantialAccountRepository<CreditAccount>>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
