using Komercio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Services
{
    public class CaixaService
    {
        private readonly HttpClient _httpClient;
       internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];


        public CaixaService(string baseUrl)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", $"{key}");
        }

        //get
        public async Task<List<CaixaDTO>> GetCaixaTransactionsAsync()
        {
            HttpResponseMessage response;
            try
            {
             response = await _httpClient.GetAsync("Caixa");

            }
            catch
            {
                return new List<CaixaDTO>();
            }
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao obter transações do caixa: {response.StatusCode}");
            }
            var returnJson = await response.Content.ReadAsStringAsync();
            var transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CaixaDTO>>(returnJson);
            if (transactions == null)
            {
                return new List<CaixaDTO>();
            }
            return transactions;
        }
    
    //put
    public async Task<bool> UpdateCaixaTransactionAsync(CaixaDTO caixaDTO)
        {
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(caixaDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"Caixa/", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao atualizar as transações do caixa: {response.StatusCode}");
            }
            return response.IsSuccessStatusCode;
        }

    }
}

