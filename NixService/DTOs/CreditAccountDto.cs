using NixService.DTOs.Base;

namespace NixService.DTOs
{
    public class CreditAccountDto : BaseAccountDto
    {
        public long CreditCardNumber { get; set; }
    }
}
