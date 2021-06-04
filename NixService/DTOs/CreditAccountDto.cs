using NixService.DTOs.Base;

namespace NixService.DTOs
{
    public class CreditAccountDto : BaseAccountDto
    {
        public int CreditCardNumber { get; set; }
    }
}
