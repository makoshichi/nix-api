using Domain.Models.Base;
using Microsoft.AspNetCore.Mvc;
using NixService.DTOs;
using NixService.DTOs.Base;
using System;
using System.Threading.Tasks;

namespace NixService
{
    public interface IFinancialAccountService<TEntity, TEntityDto> 
        where TEntity : BaseFinancialAccount
        where TEntityDto : BaseFinancialAccountDto
    {
        Task<StatusCodeResult> Purchase(PurchaseDto purchase);

        Task<StatementsDto<TEntityDto>> GetStatement(StatementFilterDto filter);
    }
}
