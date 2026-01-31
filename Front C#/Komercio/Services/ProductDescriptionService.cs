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


    public class ProductDescriptionService
    {
        private readonly HttpClient _httpClient;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];


        public ProductDescriptionService(string baseUrl)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", $"{key}");

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
