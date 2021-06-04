using Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("DebtStatement")]
    public class DebtAccount : BaseAccount
    {
        [Required]
        public long AccountNumber { get; set; }
    }
}