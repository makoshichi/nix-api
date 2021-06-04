using Domain.Models.Base;
using Microsoft.AspNetCore.Mvc;
using NixService.DTOs;
using NixService.DTOs.Base;
using System;
using System.Threading.Tasks;

namespace NixService
{
    public interface IFinancialAccountService<TEntity, TEntityDto> 
        where TEntity : BaseAccount
        where TEntityDto : BaseAccountDto
    {
        Task<StatusCodeResult> Purchase(PurchaseDto purchase);

        StatementDto<TEntityDto> GetStatement(int paymentMethodNumber, DateTime startDate, DateTime endDate);
    }
}
