using NixService.DTOs.Base;

namespace NixService.DTOs
{
    public class CreditAccountDto : BaseFinancialAccountDto
    {
        public long CreditCardNumber { get; set; }
    }
}
