using FluentValidation;
using NixService.DTOs;
using System;

namespace NixService.Validators
{
    public class ClientDtoValidator : AbstractValidator<ClientDto>
    {
        readonly Action<int?, ValidationContext<ClientDto>> action = (accountNumber, context) =>
        {
            if (accountNumber.ToString().Length > 5)
                context.AddFailure($"The length of 'AccountNumber' must be 5 characters or fewer. You entered {accountNumber.ToString().Length} characters.");
        };

        public ClientDtoValidator()
        {
            RuleFor(x => x.ClientName).NotNull().NotEmpty();
            RuleFor(x => x.CreditCardNumber.ToString()).Length(16).When(x => x.CreditCardNumber != null);
            RuleFor(x => x.AccountNumber).Custom((accountNumber, context) =>
            {
                if (accountNumber.ToString().Length > 5)
                    context.AddFailure($"The length of 'AccountNumber' must be 5 characters or fewer. You entered {accountNumber.ToString().Length} characters.");
            }).When(x => x.AccountNumber != null);
        }

        private void AddMaxLengthFailure(int maxLength)
        {
            if (accountNumber.ToString().Length > maxLength)
                context.AddFailure($"The length of 'AccountNumber' must be 5 characters or fewer. You entered {accountNumber.ToString().Length} characters.");
        }
    }
}
