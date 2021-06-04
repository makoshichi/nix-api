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
    public class DebtService<TEntity, TEntityDto> : AbstractStatementService<TEntity, TEntityDto>
        where TEntity : DebtAccount, new()
        where TEntityDto : DebtAccountDto
    {

        public DebtService(IStatementRepository<TEntity> statementRepository, IClientAccountRepository clientAccountRepository, IMapper mapper)
            : base(statementRepository, clientAccountRepository, mapper)
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

        public override StatementDTO<TEntityDto> GetStatement(int paymentMethodNumber, DateTime startDate, DateTime endDate)
        {
            var startFunds = statementRepository.GetStatements().Where(x => x.AccountNumber == paymentMethodNumber && x.PurchaseDate < startDate).Select(x => x.PurchaseValue).Sum();
            var finalFunds = statementRepository.GetStatements().Where(x => x.AccountNumber == paymentMethodNumber && x.PurchaseDate < endDate).Select(x => x.PurchaseValue).Sum();
            var statements = statementRepository.GetStatements().Where((x => x.AccountNumber == paymentMethodNumber && x.PurchaseDate >= startDate && x.PurchaseDate >= endDate));

            return new StatementDTO<TEntityDto>
            {
                StartFunds = startFunds,
                FinalFunds = finalFunds,
                Statements = ConvertToDtoIEnumerable(statements)
            };
        }
    }
}
