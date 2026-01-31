using Komercio.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Services
{
    public class ListaCompraService
    {
        private readonly HttpClient _httpClient;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];

        public ListaCompraService(string baseUrl)
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
        /// Cria uma lista de 
        /// </summary>
        /// <param name="listaCompra"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<ListaComprasDTO>> CriarListaComprasService(ListaComprasDTO listaCompra)
        {

            var json = JsonConvert.SerializeObject(listaCompra);


            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("listacompra", content);

            var serviceResponse = new ServiceResponse<ListaComprasDTO>();

            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var listaCriada = JsonConvert.DeserializeObject<ListaComprasDTO>(responseContent);

                serviceResponse.Dados = listaCriada;
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = "Listra Criada com sucesso!";

                return serviceResponse;
            }
            else
            {
                try
                {
                    var jsonError = JObject.Parse(responseContent);

                    string errorMessage = jsonError["error"]?.ToString();

                    serviceResponse.Mensagem = "BE - Não consegui criar a lista, tente novamente mais tarde!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                catch
                {
                    serviceResponse.Mensagem = "FE - Não consegui criar a lista, tente novamente mais tarde!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
            }
        }



        public async Task<ServiceResponse<List<ListaComprasDTO>>> BuscarTodasAsListas()
        {
            var serviceResponse = new ServiceResponse<List<ListaComprasDTO>>();


            var response = await _httpClient.GetAsync("listacompra/ativas");


            if (!response.IsSuccessStatusCode)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Não consegui buscar os itens";
                return serviceResponse;
            }


            try
            {
                var returnJson = await response.Content.ReadAsStringAsync();
                var listas = JsonConvert.DeserializeObject<List<ListaComprasDTO>>(returnJson);
                serviceResponse.Dados = listas;
            }
            catch
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Não consegui carregar as listas";
                return serviceResponse;
            }

            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Lista carregada com sucesso";

            return serviceResponse;

        }
    }
}
