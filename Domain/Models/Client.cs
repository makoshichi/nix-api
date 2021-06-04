using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; } 
        
        [Required]
        public string ClientName { get; set; }
        
        [Required]
        public long AccountNumber { get; set; }

        [Required]
        public long CreditCardNumber { get; set; }
        
        [Required]
        public decimal CreditCardLimit{ get; set;}
        
        [Required]
        public decimal Funds { get; set; }
    }
}
