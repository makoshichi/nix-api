﻿using System;

namespace NixService.DTOs
{
    /// <summary>
    /// DTO utilizado para filtrar extratos
    /// </summary>
    public class StatementFilterDto
    {
        /// <summary>
        /// Número do método de pagamento
        /// </summary>
        public long PaymentMethodNumber { get; set; }

        /// <summary>
        /// Data inicial do período
        /// </summary>
        public DateTime InitialDate { get; set; }

        /// <summary>
        /// Data final do período
        /// </summary>
        public DateTime FinalDate { get; set; }
    }
}
