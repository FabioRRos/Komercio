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
    public class ParametrosService
    {
        private readonly HttpClient _httpClient;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];

        public ParametrosService(string baseUrl) 
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", $"{key}");

        }



        //retorno da lista de parametros 
        public async Task<List<ParametroDTO>> GetParametros() 
        {
            var response = await _httpClient.GetAsync("parametros");

            if (!response.IsSuccessStatusCode)
            {
                return new List<ParametroDTO>();
            }

            var returnJSON = await response.Content.ReadAsStringAsync();
            var parametroslist = JsonConvert.DeserializeObject<List<ParametroDTO>>(returnJSON);

            if (parametroslist != null)
            {
                return parametroslist;
            }

            return new List<ParametroDTO>();
        }
   

    public async Task<List<ParametroDTO>> PutParametros(List<ParametroDTO> listaProdutos)
        {
            var json = JsonConvert.SerializeObject(listaProdutos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("parametros",content);
            
            if (!response.IsSuccessStatusCode)
            {
                return new List<ParametroDTO>();
            }

            var returnJSON = await response.Content.ReadAsStringAsync();
            var parametrosList = JsonConvert.DeserializeObject<List<ParametroDTO>>(returnJSON);

            if (parametrosList != null) 
            {
                return new List<ParametroDTO>();
            }
            return parametrosList;
        }


        //APÓS O TERMINO, REFATORAR ESTA PARTE!!!! NÃO DEIXAR CONSULTA TODA VEZ 
        //ISSO PODE CAUSAR LENTIDÃO NAS VERIFICAÇÕES 
        //SALVAR EM CACHE FUTURAMENTE (PERSISTENCIA).

        public async Task<bool> ConsultaStatusParametro(int id) 
        { 
         var    _parametros = await GetParametros(); 

            if (_parametros == null) 

                return false; 

            foreach (var item in _parametros) 
            { 
                if (item.Parametro_Id == id) 
                { return item.Parametro_status; } 
            } 
            return false; 
        }
    }



}
