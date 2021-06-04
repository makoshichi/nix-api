using Newtonsoft.Json;
using NixService.DTOs.Base;
using System.Collections.Generic;

namespace NixService.DTOs
{
    public class StatementsDto<TEntityDto> where TEntityDto : BaseFinancialAccountDto
    {
        public IEnumerable<TEntityDto> Statements { get; set; }
        public decimal InitialValue { get; set; }
        public decimal FinalValue { get; set; }
    }
}
