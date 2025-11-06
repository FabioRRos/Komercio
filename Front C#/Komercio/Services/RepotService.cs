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


        public ReportService()
        {

        }

        public async Task<List<SaleReportDTO>> ReturnDumpSale(HttpClient _httpClient)
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
