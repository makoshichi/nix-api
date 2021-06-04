using NixService.DTOs.Base;
using System.Collections.Generic;

namespace NixService.DTOs
{
    public class StatementDTO<TEntityDto> where TEntityDto : BaseAccountDto
    {
        public decimal StartFunds { get; set; }
        public decimal FinalFunds { get; set; }
        public IEnumerable<TEntityDto> Statements {get;set;}
    }
}
