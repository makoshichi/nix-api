using FluentValidation;
using NixService.DTOs;
using System;

namespace NixService.Validators
{
    public class StatementFilterDtoValidator : AbstractValidator<StatementFilterDto>
    {
        public StatementFilterDtoValidator()
        {
            RuleFor(x => x.PaymentMethodNumber.ToString()).NotNull().NotEmpty().MaximumLength(16);
            RuleFor(x => x.InitialDate).NotNull().NotEmpty().GreaterThan(DateTime.MinValue);
            RuleFor(x => x.FinalDate).NotNull().NotEmpty().GreaterThan(x => x.InitialDate);
        }
    }
}
