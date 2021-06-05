using AutoMapper;
using Domain.Models;
using NixRepository;
using NixService.DTOs;
using NixService.Services.Base;
using NixUtil.Exceptions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace NixService.Services
{
    public class CreditService<TEntity, TEntityDto> : FinancialAccountService<TEntity, TEntityDto>, IFinancialAccountService<TEntity, TEntityDto>
        where TEntity : CreditAccount, new()
        where TEntityDto : CreditAccountDto
    {
        public CreditService(IFinancialAccountRepository<TEntity> accountRepository, IClientRepository clientAccountRepository, IMapper mapper) 
            : base(accountRepository, clientAccountRepository, mapper)
        {
        }
        protected override Expression<Func<Client, bool>> GetPaymentFilter(long? paymentMethodNumber)
        {
            return (x => x.CreditCardNumber == paymentMethodNumber);
        }

        protected override void ValidateOperation(Client client, decimal? purchaseValue)
        {

            // Para fins deste desafio, estipula-se o calculo apenas sobre o limite do cartão, ignorando fechamento e emissão de faturas mensais
            var spent = accountRepository.GetStatements().Where(x => x.ClientId == client.Id).Select(x => x.PurchaseValue).Sum();

            if (purchaseValue + spent > client.CreditCardLimit)
                throw new HttpResponseException(HttpStatusCode.Unauthorized, "Transação não autorizada");
        }

        protected override TEntity CreateEntry(Client client, PurchaseDto purchase)
        {
            return new TEntity
            {
                ClientId = client.Id,
                //CreditCardNumber = purchase.PaymentMethodNumber,
                Description = purchase.Description,
                PurchaseValue = purchase.Value.Value,
                PurchaseDate = DateTime.Now
            };
        }

        protected override (decimal Initial, decimal Final) ComputeStatementFunds(Client client, decimal initialValue, decimal finalValue)
        {
            return (client.CreditCardLimit - initialValue, client.CreditCardLimit - finalValue);
        }
    }
}
