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
    public class ProductSubgroupService
    {
        private readonly HttpClient _httpClient;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];


        public ProductSubgroupService(string baseUrl)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", $"{key}");

        }

        public async Task<List<ProductSubgroupDTO>> GetProductSubgroupAsync()
        {
            // Retorna todos os produtos (pretendo salvar em um txt futuramente para garantir utilização offline)

            var response = await _httpClient.GetAsync("products");
            {
                if (!response.IsSuccessStatusCode)
                {
                    return new List<ProductSubgroupDTO>();

                }


                var returnJSON = await response.Content.ReadAsStringAsync();
                var productsubgroup = JsonConvert.DeserializeObject<List<ProductSubgroupDTO>>(returnJSON);


                // retorno simples para evitar "NULL"

                if (productsubgroup == null)
                {
                    return new List<ProductSubgroupDTO>();
                }

                return productsubgroup;
            }
        }

    }
}
