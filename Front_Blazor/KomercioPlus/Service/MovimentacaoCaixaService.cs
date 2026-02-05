using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KomercioPlus.Model.DTO;
using KomercioPlus.Model.Entity;

namespace KomercioPlus.Service
{
    public interface IMovimentacaoCaixaService
    {
        Task<ServiceResponse<List<ReportVendaDTO>>> MovimentacaoCaixa();
        Task<ServiceResponse<HomereportDTO>> SomaValoresHome();
    }
    public class MovimentacaoCaixaService : IMovimentacaoCaixaService
    {
        private readonly HttpClient _httpClient;
        internal readonly string _key;

        public MovimentacaoCaixaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _key = configuration["ChavePrivada"];
            _httpClient.DefaultRequestHeaders.Remove("X-Token-Secreto"); // Garante que não duplica
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", _key);
        }
        public async Task<ServiceResponse<List<ReportVendaDTO>>> MovimentacaoCaixa()
        {
            var serviceResponse = new ServiceResponse<List<ReportVendaDTO>>();

            try
            {
                var response = await _httpClient.GetAsync("Report/Sales");

                if (!response.IsSuccessStatusCode)
                {
                    serviceResponse.Status = false;
                    serviceResponse.Mensagem = "Erro ao buscar movimentações.";
                    return serviceResponse;
                }

                var json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var lista = JsonSerializer.Deserialize<List<ReportVendaDTO>>(json, options);

                serviceResponse.Dados = lista;
                serviceResponse.Status = true;

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Status = false;
                serviceResponse.Mensagem = $"Erro ao buscar movimentações - {ex.Message}";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<HomereportDTO>> SomaValoresHome()
        {
            var serviceResponse = new ServiceResponse<HomereportDTO>();

            try
            {
                var response = await _httpClient.GetAsync("Report/Home");

                if (!response.IsSuccessStatusCode)
                {
                    serviceResponse.Status = false;
                    serviceResponse.Mensagem = "Erro ao buscar movimentações.";
                    return serviceResponse;
                }

                var json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var lista = JsonSerializer.Deserialize<HomereportDTO>(json, options);

                serviceResponse.Dados = lista;
                serviceResponse.Status = true;

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Status = false;
                serviceResponse.Mensagem = $"Erro ao buscar movimentações - {ex.Message}";
                return serviceResponse;
            }
        }

    }
}