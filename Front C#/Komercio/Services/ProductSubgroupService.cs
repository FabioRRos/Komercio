using Komercio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Services
{
    public class ProductSubgroupService
    {
        private readonly HttpClient _httpClient;

        public ProductSubgroupService(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
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
