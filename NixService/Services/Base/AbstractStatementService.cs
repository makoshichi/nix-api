using Domain.Models;
using Domain.Models.Base;
using Microsoft.AspNetCore.Mvc;
using NixRepository;
using NixService.DTOs;
using NixService.DTOs.Base;
using System;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace NixService.Services.Base
{
    public abstract class AbstractStatementService<TEntity, TEntityDto> : IStatementService<TEntity, TEntityDto>
        where TEntity : BaseAccount
        where TEntityDto : BaseStatementDto
    {
        readonly IStatementRepository<TEntity> _statementRepository;
        readonly IClientAccountRepository _clientAccountRepository;

        public AbstractStatementService(IStatementRepository<TEntity> statementRepository, IClientAccountRepository clientAccountRepository)
        {
            _clientAccountRepository = clientAccountRepository;
            _statementRepository = statementRepository;
        }

        protected abstract Expression<Func<TEntity, bool>> GetFundsFilter(int serviceNumber);

        protected abstract void ValidateOperation(Client client, decimal purchaseValue);

        protected abstract TEntity CreateEntry(Client client, PurchaseDto purchase);

        public async Task<StatusCodeResult> Purchase(PurchaseDto purchase)
        {
            var client = await _clientAccountRepository.GetClient(GetFundsFilter(purchase.ChargeMethodNumber));

            ValidateOperation(client, purchase.Value);

            var entry = CreateEntry(client, purchase);

            await _statementRepository.Save(entry);

            return new StatusCodeResult((int)HttpStatusCode.OK);
        }

        public virtual IActionResult GetStatement(int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
