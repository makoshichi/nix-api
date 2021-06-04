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

        protected override Expression<Func<TEntity, bool>> GetPaymentTypeFilter(int accountNumber)
        {
            return (x => x.AccountNumber == accountNumber);
        }

        protected override void ValidateOperation(Client client, decimal purchaseValue)
        {
            if (client.Funds - purchaseValue < 0)
                throw new HttpResponseException(HttpStatusCode.Unauthorized, "Transação não autorizada");
        }

        protected override TEntity CreateEntry(Client client, PurchaseDto purchase)
        {
            return new TEntity
            {
                ClientId = client.Id,
                AccountNumber = purchase.PaymentMethodNumber,
                Description = purchase.Description,
                PurchaseValue = purchase.Value,
                PurchaseDate = DateTime.Now
            };
        }
    }
}
