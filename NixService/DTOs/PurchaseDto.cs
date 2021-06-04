using System;
using System.Collections.Generic;
using System.Text;

namespace NixService.DTOs
{
    public class PurchaseDto
    {
        public int PaymentMethodNumber { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }

    }
}
