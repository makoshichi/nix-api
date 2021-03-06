using System.ComponentModel.DataAnnotations;

namespace NixService.DTOs
{
    /// <summary>
    /// DTO utilizado pelo endpoint de abertura de conta
    /// </summary>
    public class ClientDto
    {
        /// <summary>
        /// Nome do Cliente (obrigatório)
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Número do cartão de crédito. Se não foi fornecido, um será gerado automaticamente
        /// </summary>
        public decimal? CreditCardLimit { get; set; }

        /// <summary>
        /// Fundos iniciais da conta de débito. Se não for fornecido, o valor inicial é 2000
        /// </summary>
        public decimal? InitialFunds { get; set; }

        /// <summary>
        /// Número da conta. Se não foi fornecido, um será gerado automaticamente
        /// </summary>
        public int? AccountNumber { get; set; }

        /// <summary>
        /// Limite do cartão de crédito. Se não for fornecido, o valor inicial é 2000
        /// </summary>
        public long? CreditCardNumber { get; set; }
    }
}
