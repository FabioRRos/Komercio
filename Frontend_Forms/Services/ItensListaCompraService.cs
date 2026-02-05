using Komercio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Services
{
    public class ItensListaCompraService
    {
        private readonly HttpClient _httpClient;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];


        public ItensListaCompraService (string baseUrl)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", $"{key}");
        }


        /// <summary>
        /// Chama a rota que me trás os itens da lista pelo ID da lista.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<ItemListaCompraDTO>>>ListarItensDaCompraPorId(int id)
        {
            var serviceResponse = new ServiceResponse<List<ItemListaCompraDTO>>();


            var response = await _httpClient.GetAsync($"/itenslista/id/{id}");

            if (!response.IsSuccessStatusCode)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Não consegui buscar os itens";
                return serviceResponse;
            }

            try
            {
            var retunJson= await response.Content.ReadAsStringAsync();
            var itens = JsonConvert.DeserializeObject<List<ItemListaCompraDTO>>(retunJson);
             serviceResponse.Dados = itens;

            }
            catch
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Não consegui carregar os itens";
                return serviceResponse;
            }
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Lista carregada com sucesso";

            return serviceResponse;


        }

        /// <summary>
        /// Pode ser utilizado para alteração e para criação de novos ITENS de produto.
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<List<ItemListaCompraDTO>>>SalvarAlteracaoNaListaDeCompra(List<ItemListaCompraDTO> lista)
        {
            var serviceResponse = new ServiceResponse<List<ItemListaCompraDTO>>();

            var json = JsonConvert.SerializeObject(lista);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("itenslista", content);

            if (!response.IsSuccessStatusCode)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Não consegui buscar os itens";
                return serviceResponse;
            }

            try
            {
                var retunJson = await response.Content.ReadAsStringAsync();
                var itens = JsonConvert.DeserializeObject<List<ItemListaCompraDTO>>(retunJson);
                serviceResponse.Dados = itens;

            }
            catch
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Não consegui carregar os itens";
                return serviceResponse;
            }
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Lista carregada com sucesso";

            return serviceResponse;

        }

    }
}
