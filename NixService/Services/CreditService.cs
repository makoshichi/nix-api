using AutoMapper;
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
        where TEntityDto : CreditAccountDto
    {
        public CreditService(IStatementRepository<TEntity> statementRepository, IClientAccountRepository clientAccountRepository, IMapper mapper) 
            : base(statementRepository, clientAccountRepository, mapper)
        {
        }

        protected override Expression<Func<TEntity, bool>> GetPaymentTypeFilter(int creditCardNumber)
        {
            return (x => x.CreditCardNumber == creditCardNumber);
        }

        protected override void ValidateOperation(Client client, decimal purchaseValue)
        {

            // Para fins deste desafio, estipula-se que O vencimento do cartão é no dia primeiro de cada mês

            //var currentDebt = statementRepository.Ge

            if (client.Funds - purchaseValue < 0)
                throw new HttpResponseException(HttpStatusCode.Unauthorized, "Transação não autorizada");
        }

        protected override TEntity CreateEntry(Client client, PurchaseDto purchase)
        {
            return new TEntity
            {
                ClientId = client.Id,
                CreditCardNumber = purchase.PaymentMethodNumber,
                Description = purchase.Description,
                PurchaseValue = purchase.Value,
                PurchaseDate = DateTime.Now
            };
        }

        public override StatementDTO<TEntityDto> GetStatement(int paymentMethodNumber, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
