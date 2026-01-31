using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Models
{
    public class ListaComprasDTO
    {
        [JsonProperty("idListaCompra")]
        public int IdListaCompra { get; set; }
        [JsonProperty("nomeDaLista")]
        public string NomeDaLista { get; set; }
        [JsonConverter(typeof(ConversorDeDataHibrido))]
        [JsonProperty("dataCriacaoLista")]
        public DateTimeOffset DataCriacaoLista { get; set; }
        [JsonProperty("statusLista")]
        public bool StatusLista { get; set; }






        public static ServiceResponse<ListaComprasDTO> ValidaLista(ListaComprasDTO listaCompra)
        {
            var serviceResponse = new ServiceResponse<ListaComprasDTO>();

            if (listaCompra == null)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Lista de compras invalida!";
                return serviceResponse;
            }

            serviceResponse.Dados = listaCompra;

            if (string.IsNullOrWhiteSpace(listaCompra.NomeDaLista))
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Nome da lista invalida";
                return serviceResponse;
            }

            if (listaCompra.DataCriacaoLista == DateTime.MinValue)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Data invalida";
                return serviceResponse;
            }

            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = string.Empty;

            return serviceResponse;
        }

    }

}
