using Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DebtAccount : BaseAccount
    {
        [Required]
        public int AccountNumber { get; set; }
    }
}