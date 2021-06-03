using Domain.Models.Base;
using Microsoft.AspNetCore.Mvc;
using NixService;
using NixService.DTOs;
using NixService.DTOs.Base;
using System.Threading.Tasks;

namespace NixWeb.Controllers.Base
{
    public abstract class AbstractController<TEntity, TEntityDto> : ControllerBase 
        where TEntity : BaseAccount
        where TEntityDto : BaseStatementDto
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
                ChargeMethodNumber = chargeMethodNumber,
                Description = description
            });

            return Ok("Transação efetuada com sucesso"); // As exceções são gerenciadas pelo HttpResponseExceptionFilter
        }      

        public virtual IActionResult GetStatement(int accountNumber)
        {
            //var result = JsonConvert.SerializeObject(_context.Set<TEntity>().Where(x => x.AccountNumber == accountNumber).Select(x => x));
            //return Ok(result);
            return Ok();
        }
    }
}
