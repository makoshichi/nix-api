using FluentValidation;
using NixService.DTOs;

namespace NixService.Validators
{
    public class ClientDtoValidator : AbstractValidator<ClientDto>
    {
        public ClientDtoValidator()
        {
            RuleFor(x => x.ClientName).NotNull().NotEmpty();
            RuleFor(x => x.CreditCardNumber.ToString()).Length(16).When(x => x.CreditCardNumber != null);
            RuleFor(x => x.AccountNumber.ToString()).MaximumLength(5).When(x => x.AccountNumber != null);
        }
    }
}
