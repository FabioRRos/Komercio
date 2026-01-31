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
    public class FormaPagamentoService
    {
        private HttpClient _httpClient;
        internal readonly string key = ConfigurationManager.AppSettings["ChavePrivada"];

        public FormaPagamentoService(string baseUrl)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", $"{key}");
        }

        public async Task<List<FormaPagamentoDTO>> GetFormaPagamento()
        {
            var response = await _httpClient.GetAsync("formadepagamento");

            if (!response.IsSuccessStatusCode)
            {
                return new List<FormaPagamentoDTO>();
            }

            var resultJson = await response.Content.ReadAsStringAsync();
            var formaPagamento = JsonConvert.DeserializeObject<List<FormaPagamentoDTO>>(resultJson);

            if (formaPagamento == null)
            {
                return new List<FormaPagamentoDTO>();
            }

            return formaPagamento;

        }

    }
}
