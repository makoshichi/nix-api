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
    public class DebtService<TEntity, TEntityDto> : FinancialAccountService<TEntity, TEntityDto>, IFinancialAccountService<TEntity, TEntityDto>
        where TEntity : DebtAccount, new()
        where TEntityDto : DebtAccountDto
    {

        public DebtService(IFinancialAccountRepository<TEntity> accountRepository, IClientRepository clientRepository, IMapper mapper)
            : base(accountRepository, clientRepository, mapper)
        {
        }

        protected override Expression<Func<Client, bool>> GetPaymentFilter(long? paymentMethodNumber)
        {
            return (x => x.AccountNumber == paymentMethodNumber);
        }

        protected override void ValidateOperation(Client client, decimal? purchaseValue)
        {
            var spent = accountRepository.GetStatements().Where(x => x.ClientId == client.Id).Select(x => x.PurchaseValue).Sum();

            if (client.InitialFunds - spent - purchaseValue < 0)
                throw new HttpResponseException(HttpStatusCode.Unauthorized, "Transação não autorizada");
        }

        protected override TEntity CreateEntry(Client client, PurchaseDto purchase)
        {
            return new TEntity
            {
                ClientId = client.Id,
                //AccountNumber = purchase.PaymentMethodNumber,
                Description = purchase.Description,
                PurchaseValue = purchase.Value.Value,
                PurchaseDate = DateTime.Now
            };
        }

        protected override (decimal Initial, decimal Final) ComputeStatementFunds(Client client, decimal initialValue, decimal finalValue)
        {
            return (client.InitialFunds - initialValue, client.InitialFunds - finalValue);
        }
    }
}
