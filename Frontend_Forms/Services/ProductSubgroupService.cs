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
using System.Windows.Forms;

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

            var response = await _httpClient.GetAsync("productSubgroup");
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


        public async Task<bool> CreateSubGroup(ProductSubgroupDTO productsubgroup)
        {
            var json = JsonConvert.SerializeObject(productsubgroup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("productSubgroup", content);


            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                try
                {
                    var jsonError = JObject.Parse(responseContent);

                    string errorMessage = jsonError["error"]?.ToString();

                    if (string.IsNullOrWhiteSpace(errorMessage))
                        errorMessage = "Erro desconhecido";

                    MessageBox.Show(errorMessage, "Erro ao criar SubGrupo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    // Se não conseguir desserializar, mostra o conteúdo bruto
                    MessageBox.Show(responseContent, "Erro ao criar o subgroup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }
        }

    }
}
