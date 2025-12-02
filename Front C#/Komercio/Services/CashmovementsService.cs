using Komercio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Komercio.Services
{
    public class CashmovementsService
    {
        private HttpClient _httpClient;

        public CashmovementsService(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
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
