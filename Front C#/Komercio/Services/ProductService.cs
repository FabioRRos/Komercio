using Komercio.Models;
using MeuProjetoWinForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.Services
{
    // A classe CustomerService encapsula toda a comunicação com a API /customer do backend Go.
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }


        //Cria um novo produto

        public async Task<bool> CreateProductAsync(ProductDTO product)
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("products", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                try
                {
                    // Tenta desserializar o JSON de erro
                    var errorObj = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    string errorMessage = errorObj?.error ?? "Erro desconhecido";

                    // Exibe o MessageBox com a mensagem de erro
                    MessageBox.Show(errorMessage, "Erro ao criar produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    // Se não conseguir desserializar, mostra o conteúdo bruto
                    MessageBox.Show(responseContent, "Erro ao criar produto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }
        }

        public async Task<ProductDTO> PutProductInStock(string barcode, int newStock)
        {
            // Monta o corpo JSON
            var content = new StringContent(
                JsonConvert.SerializeObject(new { product_stock = newStock }),
                Encoding.UTF8,
                "application/json"
            );

            // Faz a chamada PUT para a rota correta
            var response = await _httpClient.PutAsync($"products/updateStock/{barcode}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductDTO>(responseContent);
                return product;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ProductDTO>> GetProductInStockAsync()
        {
            // Retorna todos os produtos (pretendo salvar em um txt futuramente para garantir utilização offline)

            var response = await _httpClient.GetAsync("products");
                {
                if (!response.IsSuccessStatusCode)
                {
                    return new List<ProductDTO>();

                }


                var returnJSON = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductDTO>>(returnJSON);


                // retorno simples para evitar "NULL"

                if (products ==null)
                {
                    return new List<ProductDTO>();
                }

                return products;
            }
        }

        public async Task<List<ProductNotificationSettingsDTO>> GetProductNotificationSettingAsync()
        {
            // Retorna todos os produtos (pretendo salvar em um txt futuramente para garantir utilização offline)

            var response = await _httpClient.GetAsync("products/notification");
            {
                if (!response.IsSuccessStatusCode)
                {
                    return new List<ProductNotificationSettingsDTO>();

                }


                var returnJSON = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductNotificationSettingsDTO>>(returnJSON);


                // retorno simples para evitar "NULL"

                if (products == null)
                {
                    return new List<ProductNotificationSettingsDTO>();
                }

                return products;
            }
        }



        public async Task <ProductDTO> GetProductByCodbad(string barcode)
        {
            var response = await _httpClient.GetAsync($"products/codbar/{barcode}");


            if (!response.IsSuccessStatusCode) {
                return new ProductDTO();
            }

            var returnJSON = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<ProductDTO>(returnJSON);


            // retorno simples para evitar "NULL"

            if (products == null)
            {
                return new ProductDTO();
            }

            return products;


        }


    }
}
