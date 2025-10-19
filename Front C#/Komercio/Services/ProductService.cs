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


    }
}
