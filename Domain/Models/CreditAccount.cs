using Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("CreditStatement")]
    public class CreditAccount : BaseAccount
    {
        [Required]
        public long CreditCardNumber { get; set; } 
    }
}