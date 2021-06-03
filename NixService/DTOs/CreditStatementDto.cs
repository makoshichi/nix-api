using NixService.DTOs.Base;

namespace NixService.DTOs
{
    public class CreditStatementDto : BaseStatementDto
    {
        public int CreditCardNumber { get; set; }
    }
}
