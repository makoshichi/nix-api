using Newtonsoft.Json;
using System;

namespace NixService.DTOs.Base
{
    public abstract class BaseFinancialAccountDto
    {
        [JsonIgnore]
        public int Id { get; set; }

        public decimal PurchaseValue { get; set; }

        public string Description { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
