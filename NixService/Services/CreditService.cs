using Domain.Models;
using NixRepository;
using NixService.DTOs;
using NixService.Services.Base;
using NixUtil.Exceptions;
using System;
using System.Linq.Expressions;
using System.Net;

namespace NixService.Services
{
    public class CreditService<TEntity, TEntityDto> : AbstractStatementService<TEntity, TEntityDto>
        where TEntity : CreditAccount, new()
        where TEntityDto : CreditStatementDto
    {
        public CreditService(IStatementRepository<TEntity> statementRepository, IClientAccountRepository clientAccountRepository) 
            : base(statementRepository, clientAccountRepository)
        {
        }

        protected override Expression<Func<TEntity, bool>> GetFundsFilter(int creditCardNumber)
        {
            return (x => x.CreditCardNumber == creditCardNumber);
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
                CreditCardNumber = purchase.ChargeMethodNumber,
                Description = purchase.Description,
                PurchaseValue = purchase.Value,
                PurchaseDate = DateTime.Now
            };
        }

    }
}
