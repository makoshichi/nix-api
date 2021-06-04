using FluentValidation;
using NixService.DTOs;
using System;
using System.Reflection;

namespace NixService.Validators
{
    public class ClientDtoValidator : AbstractValidator<ClientDto>
    {
        public ClientDtoValidator()
        {
            RuleFor(x => x.ClientName).NotNull().NotEmpty();

            RuleFor(x => x.CreditCardNumber).Custom((creditCardNumber, context) =>
            {
                CustomValidationRules.CheckMaxLengthValidationFailure(creditCardNumber.ToString().Length, 16, "CreditCardNumber", context);
            }).When(x => x.CreditCardNumber != null);


            RuleFor(x => x.AccountNumber).Custom((accountNumber, context) =>
            {
                CustomValidationRules.CheckMaxLengthValidationFailure(accountNumber.ToString().Length, 5, "AccountNumber", context);
            }).When(x => x.AccountNumber != null);
        }
    }
}
