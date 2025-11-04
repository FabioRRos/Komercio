using Komercio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Komercio.Services
{
    public class ReportService
    {
        private readonly HttpClient _httpClient;

        public ReportService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8000/")
            };
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
    }
}
