using Komercio.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Komercio.Models.ViewModels
{
    public class RelatorioVendasViewModel
    {
        // Campos do Filtro
        [DataType(DataType.Date)]
        public DateTime? DataInicial { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataFinal { get; set; }

        // Lista de resultados
        public List<VendaRelatorio> Vendas { get; set; } = new List<VendaRelatorio>();

        //Lista dos vendedores
        public string? VendedorSelecionado { get; set; } 
        public List<SelectListItem> ListaVendedores { get; set; } = new List<SelectListItem>(); // As opções do dropdown

        // Totais calculados (pode ser feito aqui ou no controller)
        public decimal TotalVendido => Vendas.Sum(v => v.FinalAmount);
        public int TotalQuantidade => Vendas.Count;


    }
}