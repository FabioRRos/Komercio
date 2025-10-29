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
    public class ProductGroupService
    {
        private readonly HttpClient _httpClient;

        public ProductGroupService(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }



        public async Task<List<ProductgroupDTO>> GetProductGroupAsync()
        {
            // Retorna todos os produtos (pretendo salvar em um txt futuramente para garantir utilização offline)

            var response = await _httpClient.GetAsync("productGroup");
            {
                if (!response.IsSuccessStatusCode)
                {
                    return new List<ProductgroupDTO>();

                }


                var returnJSON = await response.Content.ReadAsStringAsync();
                var productgroup = JsonConvert.DeserializeObject<List<ProductgroupDTO>>(returnJSON);


                // retorno simples para evitar "NULL"

                if (productgroup == null)
                {
                    return new List<ProductgroupDTO>();
                }

                return productgroup;
            }
        }
    }
}
