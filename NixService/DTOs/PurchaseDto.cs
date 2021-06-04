using System.ComponentModel.DataAnnotations;

namespace NixService.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class PurchaseDto
    {
        /// <summary>
        /// Número do método de pagamento
        /// </summary>
        public long PaymentMethodNumber { get; set; }

        /// <summary>
        /// Valor da compra
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }

    }
}
