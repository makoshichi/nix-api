using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Base
{
    public abstract class BaseFinancialAccount
    {       
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal PurchaseValue { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("Client")]
        [Required]
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
