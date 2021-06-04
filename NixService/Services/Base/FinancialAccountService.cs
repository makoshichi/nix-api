using AutoMapper;
using Domain.Models;
using Domain.Models.Base;
using Microsoft.AspNetCore.Mvc;
using NixRepository;
using NixService.DTOs;
using NixService.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace NixService.Services.Base
{
    public abstract class FinancialAccountService<TEntity, TEntityDto>
        where TEntity : BaseAccount
        where TEntityDto : BaseAccountDto
    {
        protected IFinancialAccountRepository<TEntity> accountRepository;
        protected IClientRepository clientRepository;

        readonly IMapper _mapper;

        public FinancialAccountService(IFinancialAccountRepository<TEntity> accountRepository, IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<StatusCodeResult> Purchase(PurchaseDto purchase)
        {
            var client = await clientRepository.GetClient(GetPaymentFilter(purchase.PaymentMethodNumber));

            ValidateOperation(client, purchase.Value);

            var entry = CreateEntry(client, purchase);

            await accountRepository.SaveAsync(entry);

            return new StatusCodeResult((int)HttpStatusCode.OK);
        }

        public async Task<StatementDto<TEntityDto>> GetStatement(StatementFilterDto filter)
        {
            var client = await clientRepository.GetClient(GetPaymentFilter(filter.PaymentMethodNumber));

            var initialValue = accountRepository.GetStatements().Where(x => x.ClientId == client.Id && x.PurchaseDate < filter.InitialDate).Select(x => x.PurchaseValue).Sum();
            var finalValue = accountRepository.GetStatements().Where(x => x.ClientId == client.Id && x.PurchaseDate < filter.FinalDate).Select(x => x.PurchaseValue).Sum();
            var statements = accountRepository.GetStatements().Where((x => x.ClientId == client.Id && x.PurchaseDate >= filter.InitialDate && x.PurchaseDate <= filter.FinalDate));

            var tuple = ComputeStatementFunds(client, initialValue, finalValue);

            return new StatementDto<TEntityDto>
            {
                InitialValue = tuple.Initial,
                FinalValue = tuple.Final,
                Statements = ConvertToDtoIEnumerable(statements)
            };
        }

        protected abstract Expression<Func<Client, bool>> GetPaymentFilter(long paymentMethodNumber);

        protected abstract void ValidateOperation(Client client, decimal purchaseValue);

        protected abstract TEntity CreateEntry(Client client, PurchaseDto purchase);

        protected abstract (decimal Initial, decimal Final) ComputeStatementFunds(Client client, decimal initialValue, decimal finalValue);

        protected IEnumerable<TEntityDto> ConvertToDtoIEnumerable(IEnumerable<TEntity> collection)
        {
            foreach (var entry in collection)
            {
                yield return _mapper.Map<TEntityDto>(entry);
            }
        }
    }
}
