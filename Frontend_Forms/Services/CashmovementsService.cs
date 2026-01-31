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
    public class CashmovementsService
    {
        private HttpClient _httpClient;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];


        public CashmovementsService(string baseUrl)
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

        public async Task<List<CashovementsDTO>> GetCashMovement()
        {
            var response = await _httpClient.GetAsync("cashmovements");

            if (!response.IsSuccessStatusCode)
            {
                return new List<CashovementsDTO>();
            }

            var resultJson = await response.Content.ReadAsStringAsync();
            var listCashMovement = JsonConvert.DeserializeObject<List<CashovementsDTO>>(resultJson);

            if (listCashMovement == null)
            {
                return new List<CashovementsDTO>();
            }

            return listCashMovement;

        }
    }
}
