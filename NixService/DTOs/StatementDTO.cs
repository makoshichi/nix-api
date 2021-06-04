using NixService.DTOs.Base;
using System.Collections.Generic;

namespace NixService.DTOs
{
    public class StatementDto<TEntityDto> where TEntityDto : BaseAccountDto
    {
        public IEnumerable<TEntityDto> Statements { get; set; }
        public decimal InitialValue { get; set; }
        public decimal FinalValue { get; set; }
    }
}
