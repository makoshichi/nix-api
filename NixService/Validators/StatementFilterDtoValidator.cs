using FluentValidation;
using NixService.DTOs;
using System;

namespace NixService.Validators
{
    public class StatementFilterDtoValidator : AbstractValidator<StatementFilterDto>
    {
        public StatementFilterDtoValidator()
        {
            RuleFor(x => x.PaymentMethodNumber).Custom((paymentMethodNumber, context) =>
            {
                CustomValidationRules.CheckMaxLengthValidationFailure(paymentMethodNumber.ToString().Length, 16, "PaymentMethodNumber", context);
            }).When(x => x.PaymentMethodNumber != null);

            RuleFor(x => x.InitialDate).NotNull().NotEmpty().GreaterThan(DateTime.MinValue);
            RuleFor(x => x.FinalDate).NotNull().NotEmpty().GreaterThan(x => x.InitialDate);
        }
    }
}
