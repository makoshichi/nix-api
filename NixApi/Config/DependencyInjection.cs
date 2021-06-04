using Domain.Models;
using Domain.Models.Base;
using Microsoft.Extensions.DependencyInjection;
using NixRepository;
using NixRepository.Repositories;
using NixService;
using NixService.DTOs;
using NixService.DTOs.Base;
using NixService.Services;
using NixService.Services.Base;

namespace NixWeb.Config
{
    public static class DependencyInjection
    {
        public static void AddScoped(IServiceCollection services)
        {
            //services.AddScoped<IFinancialAccountService<BaseAccount, BaseAccountDto>, FinantialAccountService<BaseAccount, BaseAccountDto>>();
            //services.AddScoped<IFinancialAccountRepository<BaseAccount>, AbstractFinantialAccountRepository<BaseAccount>>();
            //services.AddScoped<IClientAccountRepository, ClientAccountRepository>();
            services.AddScoped<IFinancialAccountService<DebtAccount, DebtAccountDto>, DebtService<DebtAccount, DebtAccountDto>>();
            services.AddScoped<IFinancialAccountService<CreditAccount, CreditAccountDto>, CreditService<CreditAccount, CreditAccountDto>>();
            services.AddScoped<IFinancialAccountRepository<DebtAccount>, DebtAccountRepository<DebtAccount>>();
            services.AddScoped<IFinancialAccountRepository<CreditAccount>, CreditAccountRepository<CreditAccount>>();
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
