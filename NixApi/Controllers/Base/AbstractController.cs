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
        where TEntity : BaseAccount
        where TEntityDto : BaseAccountDto
    {

        protected IStatementService<TEntity, TEntityDto> service;

        public AbstractController(IStatementService<TEntity, TEntityDto> service) : base()
        {
            this.service = service;
        }

        public virtual async Task<IActionResult> Purchase(decimal value, int chargeMethodNumber, string description)
        {
            await service.Purchase(new PurchaseDto
            {
                Value = value,
                PaymentMethodNumber = chargeMethodNumber,
                Description = description
            });

            return Ok("Transação efetuada com sucesso"); // As exceções são gerenciadas pelo HttpResponseExceptionFilter
        }      

        public virtual IActionResult GetStatement(int paymentMethodNumber, DateTime startDate, DateTime endDate)
        {
            var response = JsonConvert.SerializeObject(service.GetStatement(paymentMethodNumber, startDate, endDate)); 
            return Ok(response);
        }
    }
}
