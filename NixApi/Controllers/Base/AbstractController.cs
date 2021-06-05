using Domain.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NixService;
using NixService.DTOs;
using NixService.DTOs.Base;
using System;
using System.Threading.Tasks;

namespace NixWeb.Controllers.Base
{
    public abstract class AbstractController<TEntity, TEntityDto> : ControllerBase 
        where TEntity : BaseFinancialAccount
        where TEntityDto : BaseFinancialAccountDto
    {

        protected IFinancialAccountService<TEntity, TEntityDto> service;

        public AbstractController(IFinancialAccountService<TEntity, TEntityDto> service) : base()
        {
            this.service = service;
        }

        public virtual async Task<IActionResult> Purchase(PurchaseDto purchase)
        {
            await service.Purchase(purchase);

            return Ok("Transação efetuada com sucesso"); // As exceções são gerenciadas pelo HttpResponseExceptionFilter
        }      

        public virtual async Task<IActionResult> GetStatement(StatementFilterDto filter)
        {
            var response = JsonConvert.SerializeObject(await service.GetStatement(filter)); 
            return Ok(response);
        }
    }
}
