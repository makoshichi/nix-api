using System;
using System.Collections.Generic;
using System.Text;

namespace NixService.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public decimal? CreditCardLimit { get; set; }
        public decimal? Funds { get; set; }
        public int? AccountNumber { get; set; }
        public long? CreditCardNumber { get; set; }
    }
}
