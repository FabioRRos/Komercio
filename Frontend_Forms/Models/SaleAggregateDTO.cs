using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
     public class SaleAggregateDTO
    {
        public SaleAggregateDTO(SalesDTO sales, List<SalesItensDTO> salesItens, CashovementsDTO cashmovements, List<FormaPagamentoDTO> formaPagamento)
        {
            Sales = sales;
            SalesItens = salesItens;
            Cashmovements = cashmovements;
            FormaPagamento = formaPagamento;

        }
        [JsonProperty("sale")]
        public SalesDTO Sales { get; set; }
        [JsonProperty("items")]
        public List<SalesItensDTO> SalesItens { get; set; }
        [JsonProperty("cash_movement")]
        public CashovementsDTO Cashmovements { get; set; }
        [JsonProperty("forma_pagamento")]
        public List<FormaPagamentoDTO> FormaPagamento { get; set; }
    }
}
