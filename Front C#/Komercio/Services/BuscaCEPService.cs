using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Entities.Services
{
    internal class RetornaCEPServices
    {
        public async Task<RetornaCEPEntitie> RetornaCEPAsync(string cep)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                var jsonString = await response.Content.ReadAsStringAsync();
                var jsoObject = JsonConvert.DeserializeObject<RetornaCEPEntitie>(jsonString);

                if (jsoObject.Erro == "true") return null;
                else return jsoObject;
            }
            catch
            {
                return null;
            }
        }
    }
}