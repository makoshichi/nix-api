using System;

namespace NixService.DTOs
{
    public class StatementFilterDto
    {
        public long PaymentMethodNumber { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }
    }
}
