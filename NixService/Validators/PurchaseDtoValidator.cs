using FluentValidation;
using NixService.DTOs;

namespace NixService.Validators
{
    public class PurchaseDtoValidator : AbstractValidator<PurchaseDto>
    {
        public PurchaseDtoValidator()
        {
            RuleFor(x => x.PaymentMethodNumber).Custom((paymentMethodNumber, context) =>
            {
                CustomValidationRules.CheckMaxLengthValidationFailure(paymentMethodNumber.ToString().Length, 16, "PaymentMethodNumber", context);
            }).When(x => x.PaymentMethodNumber != null);
            RuleFor(x => x.Value).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
        }
    }
}
