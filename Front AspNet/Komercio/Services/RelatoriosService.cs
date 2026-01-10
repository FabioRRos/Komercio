using Komercio.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace Komercio.Services
{
    public interface IRelatoriosService
    {
        Task<List<VendaRelatorio>> ListaDeVendaGeral();
        Task<List<MovimentacaoCaixaModel>> MovimentacaoCaixa();
        Task<List<FormaPagamentoModel>> FormaPagamento();
        Task<List<CaixaModel>> Caixa();
        Task<List<LucratividadeModel>> GetLucratividadeAsync();
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
                var response = await _httpClient.GetAsync("Report/Sales");
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



        public async Task<List<MovimentacaoCaixaModel>>MovimentacaoCaixa()
        {
            var response = await _httpClient.GetAsync("cashmovements");
            if (!response.IsSuccessStatusCode)
            {
                return new List<MovimentacaoCaixaModel> ();
            }

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
            var listaDeMovimentacao = JsonSerializer.Deserialize<List<MovimentacaoCaixaModel>>(json,options);

            return listaDeMovimentacao ?? new List<MovimentacaoCaixaModel>();
        }

        public async Task<List<FormaPagamentoModel>> FormaPagamento()
        {
            var response = await _httpClient.GetAsync("formadepagamento");
            if (!response.IsSuccessStatusCode)
            {
                return new List<FormaPagamentoModel>();
            }

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var listaFormaPagamento = JsonSerializer.Deserialize<List<FormaPagamentoModel>>(json, options);

            return listaFormaPagamento ?? new List<FormaPagamentoModel>();
        }

        public async Task<List<CaixaModel>> Caixa()
        {
            var response = await _httpClient.GetAsync("Caixa");

            if (!response.IsSuccessStatusCode)
            {
                return new List<CaixaModel>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var caixa = JsonSerializer.Deserialize<List<CaixaModel>>(json, options);


            return caixa;
        }



        public async Task<List<LucratividadeModel>> GetLucratividadeAsync()
        {
            try
            {
                // Chamada para o endpoint do backend Go
                // O GetFromJsonAsync usa internamente o System.Text.Json que lerá seus [JsonPropertyName]
                var response = await _httpClient.GetAsync("Report/Margem");

                if (!response.IsSuccessStatusCode)
                {
                    new List<LucratividadeModel>();
                }

                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var caixa = JsonSerializer.Deserialize<List<LucratividadeModel>>(json, options);


                return caixa;
            }
            catch (Exception ex)
            {
                // Logar o erro conforme sua necessidade
                Console.WriteLine($"Erro ao buscar relatório: {ex.Message}");
                return new List<LucratividadeModel>();
            }
        }

    }
}
