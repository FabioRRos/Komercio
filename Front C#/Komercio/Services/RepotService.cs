using Komercio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Komercio.Services
{
    public class ReportService
    {
        private readonly HttpClient _httpClient;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];




        public ReportService(string baseUrl)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", $"{key}");


        }

        public async Task<List<SaleReportDTO>> ReturnDumpSale()
        {
            try
            {
                var response = await _httpClient.GetAsync("Report/Sales/");

                if (!response.IsSuccessStatusCode)
                {
                    return new List<SaleReportDTO>();
                }

                var json = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<SaleReportDTO>();
                }

                var dump = JsonConvert.DeserializeObject<List<SaleReportDTO>>(json);
                return dump ?? new List<SaleReportDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar relatório: " + ex.Message);
                return new List<SaleReportDTO>();
            }
        }

        /// <summary>
        /// Retorna os itens da Venda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<SalesItensDTO>> GetProductList(int id)
        {
            var response = await _httpClient.GetAsync($"sale_items/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;

            }

            var returnJson = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<List<SalesItensDTO>>(returnJson);

            if (productList == null)
            {
                return null;
            }

            return productList;
        }
    }
}
