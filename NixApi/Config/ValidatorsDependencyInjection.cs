using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NixService.DTOs;
using NixService.Validators;

namespace NixWeb.Config
{
    public static class ValidatorsDependencyInjection
    {
        public static void AddTransient(IServiceCollection services)
        {
            services.AddTransient<IValidator<ClientDto>, ClientDtoValidator>();
            services.AddTransient<IValidator<StatementFilterDto>, StatementFilterDtoValidator>();
            services.AddTransient<IValidator<PurchaseDto>, PurchaseDtoValidator>();
        }
    }
}
