using FluentValidation;
using NixService.DTOs;

namespace NixService.Validators
{
    public class PurchaseDtoValidator : AbstractValidator<PurchaseDto>
    {
        public PurchaseDtoValidator()
        {
            RuleFor(x => x.PaymentMethodNumber.ToString()).NotNull().NotEmpty().MaximumLength(16);
            RuleFor(x => x.Value).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
        }
    }
}
