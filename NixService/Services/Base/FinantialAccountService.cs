using AutoMapper;
using Domain.Models;
using Domain.Models.Base;
using Microsoft.AspNetCore.Mvc;
using NixRepository;
using NixService.DTOs;
using NixService.DTOs.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace NixService.Services.Base
{
    public abstract class FinantialAccountService<TEntity, TEntityDto> : IFinancialAccountService<TEntity, TEntityDto>
        where TEntity : BaseAccount
        where TEntityDto : BaseAccountDto
    {
        protected IFinancialAccountRepository<TEntity> accountRepository;
        protected IClientAccountRepository clientAccountRepository;

        readonly IMapper _mapper;

        public FinantialAccountService(IFinancialAccountRepository<TEntity> accountRepository, IClientAccountRepository clientAccountRepository, IMapper mapper)
        {
            this.clientAccountRepository = clientAccountRepository;
            this.accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<StatusCodeResult> Purchase(PurchaseDto purchase)
        {
            var client = await clientAccountRepository.GetClient(GetPaymentTypeFilter(purchase.PaymentMethodNumber));

            ValidateOperation(client, purchase.Value);

            var entry = CreateEntry(client, purchase);

            await accountRepository.SaveAsync(entry);

            return new StatusCodeResult((int)HttpStatusCode.OK);
        }

        public abstract StatementDTO<TEntityDto> GetStatement(int paymentMethodNumber, DateTime startDate, DateTime endDate);

        protected abstract Expression<Func<TEntity, bool>> GetPaymentTypeFilter(int serviceNumber);

        protected abstract void ValidateOperation(Client client, decimal purchaseValue);

        protected abstract TEntity CreateEntry(Client client, PurchaseDto purchase);

        protected IEnumerable<TEntityDto> ConvertToDtoIEnumerable(IEnumerable<TEntity> collection)
        {
            foreach (var entry in collection)
            {
                yield return _mapper.Map<TEntityDto>(entry);
            }
        }
    }
}
