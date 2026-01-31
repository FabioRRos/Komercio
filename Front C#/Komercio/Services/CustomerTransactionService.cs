using Komercio.ApplicationLayer;
using Komercio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
        private readonly ParametrosApp _parametrosApp;


        public CustomerTransactionService(string baseUrl,
            ParametrosApp parametrosApp)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", $"{key}");
            _parametrosApp = parametrosApp;
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
            // Salva JSON pra validação
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(transaction, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText("transaction.json", json);


            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("transaction", content);

            var habilitaJson = await VerificaStatusParametro(10);

            if (habilitaJson)
            {


                string diretorio = @"C:\Komercio\LOG\Json_Caderneta";
            Directory.CreateDirectory(diretorio);
            string nomeArquivo = "JSON_RES_VENDA_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";
            string caminhoCompleto = Path.Combine(diretorio, nomeArquivo);


            File.WriteAllText(caminhoCompleto, json, Encoding.UTF8);
            }

            return response.IsSuccessStatusCode;
        }



        private async Task<bool> VerificaStatusParametro(int id)
        {
            var status = await _parametrosApp.ConsultaStatusParametro(id);

            return status;
        }


    }
}
