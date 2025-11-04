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


    public class ProductDescriptionService
    {
        private readonly HttpClient _httpClient;

        public ProductDescriptionService(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }


        public async Task<ProductDescriptionDTO> GetProductDescriptionAsync()
        {
            var response = await _httpClient.GetAsync("ProductDescription");
            {
                if (!response.IsSuccessStatusCode)
                {
                    return new ProductDescriptionDTO();
                }
            }

            var returnJSON = await response.Content.ReadAsStringAsync();
            var productdesc = JsonConvert.DeserializeObject<ProductDescriptionDTO>(returnJSON);

            if (productdesc != null)
            {
                return productdesc;
            }
            return new ProductDescriptionDTO();


        }
    }
}
