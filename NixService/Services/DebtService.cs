using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using NixRepository;
using NixService.DTOs;
using NixService.Services.Base;
using NixUtil.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NixService.Services
{
    public class DebtService<TEntity, TEntityDto> : AbstractStatementService<TEntity, TEntityDto>
        where TEntity : DebtAccount, new()
        where TEntityDto : DebtStatementDto
    {
        public DebtService(IStatementRepository<TEntity> statementRepository, IClientAccountRepository clientAccountRepository)
            : base(statementRepository, clientAccountRepository)
        {
        }

        protected override Expression<Func<TEntity, bool>> GetFundsFilter(int accountNumber)
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
                AccountNumber = purchase.ChargeMethodNumber,
                Description = purchase.Description,
                PurchaseValue = purchase.Value,
                PurchaseDate = DateTime.Now
            };
        }

    }
}
