using Komercio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace Komercio.Services
{
    public interface IRelatoriosService
    {
        Task<List<VendaRelatorio>> ListaDeVendaGeral();
    }
    public class RelatoriosService : IRelatoriosService
    {
        private List<VendaRelatorio> listaDeVendaRelatorio = new List<VendaRelatorio>();

        private readonly HttpClient _httpClient;
        internal readonly string _key;

        public RelatoriosService(HttpClient httpClient, IConfiguration configuration) {

            _httpClient = httpClient;
            _key = configuration["ChavePrivada"];

            _httpClient.DefaultRequestHeaders.Remove("X-Token-Secreto");
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", _key);

        }


        public async Task<List<VendaRelatorio>> ListaDeVendaGeral()
        {
            try
            {
                var response = await _httpClient.GetAsync("Report/Sales/");
                if (!response.IsSuccessStatusCode)
                {
                    return new List<VendaRelatorio>();
                }

                var json = await response.Content.ReadAsStringAsync();



                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                listaDeVendaRelatorio = JsonSerializer.Deserialize<List<VendaRelatorio>>(json,options);

                return listaDeVendaRelatorio ?? new List<VendaRelatorio>();


            }
            catch
            {
                return new List<VendaRelatorio>();
            }
        }
    }
}
