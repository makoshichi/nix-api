using NixService.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NixService.DTOs
{
    public class DebtAccountDto : BaseAccountDto
    {
        public int AccountNumber { get; set; }
    }
}
