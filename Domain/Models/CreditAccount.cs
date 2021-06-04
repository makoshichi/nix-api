using Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class CreditAccount : BaseAccount
    {
        [Required]
        public int CreditCardNumber { get; set; } 
    }
}