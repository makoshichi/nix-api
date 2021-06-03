using Domain.Models.Base;
using Microsoft.AspNetCore.Mvc;
using NixService.DTOs;
using NixService.DTOs.Base;
using System.Threading.Tasks;

namespace NixService
{
    public interface IStatementService<TEntity, TEntityDto> 
        where TEntity : BaseAccount
        where TEntityDto : BaseStatementDto
    {
        Task<StatusCodeResult> Purchase(PurchaseDto purchase);

        IActionResult GetStatement(int chargeMethodNumber);
    }
}
