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
    public class CustomerTransactionService
    {

        private readonly HttpClient _httpClient;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];


        public CustomerTransactionService(string baseUrl)
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
        public async Task<List<CustomerTransactionsDTO>> GetCustomerTransactionServiceAsync(int id)
        {
            var response = await _httpClient.GetAsync($"transaction/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Tive dificuldades em receber as transações: {response.StatusCode}");
            }

            var returnJson = await response.Content.ReadAsStringAsync();
            var transactions = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CustomerTransactionsDTO>>(returnJson);


            if (transactions == null)
            {
                return new List<CustomerTransactionsDTO>();
            }
            return transactions;
        }

        public async Task<List<SalesItensDTO>> GetSalesItensByTransactionIdAsync(int transactionId)
        {
            var response = await _httpClient.GetAsync($"sale_items/{transactionId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Tive dificuldades em receber os itens da transação: {response.StatusCode}");
            }
            var returnJson = await response.Content.ReadAsStringAsync();
            var salesItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SalesItensDTO>>(returnJson);
            if (salesItems == null)
            {
                return new List<SalesItensDTO>();
            }
            return salesItems;
        }


        //post

        public async Task<bool> PostCustomerTransactionAsync(CustomerTransactionsDTO transaction)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(transaction);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("transaction", content);

            // vou salvar o Json para ver se ta tudo ok

            System.IO.File.WriteAllText("transaction.json", json);


            return response.IsSuccessStatusCode;
        }

    }
}
