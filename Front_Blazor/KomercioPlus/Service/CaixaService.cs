using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KomercioPlus.Model.Entity;


namespace KomercioPlus.Service
{
    public interface ICaixaService
    {
        Task<ServiceResponse<bool>> StatusCaixa();
    }
    public class CaixaService:ICaixaService
    {
        private readonly HttpClient _httpClient;
        internal readonly string _key;

        public CaixaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _key = configuration["ChavePrivada"];
            _httpClient.DefaultRequestHeaders.Remove("X-Token-Secreto"); // Garante que não duplica
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", _key);

        }

        public async Task<ServiceResponse<bool>> StatusCaixa()
        {
            var serviceResponse = new ServiceResponse<bool>();
            
            try
            {
                var response = await _httpClient.GetAsync("Caixa/status");
                if (!response.IsSuccessStatusCode)
                {

                    serviceResponse.Status = false;
                    return serviceResponse;
                }

                var json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var status = JsonSerializer.Deserialize<bool>(json,options);

                serviceResponse.Status = status;
                if (status) serviceResponse.Mensagem = "Aberto";
                else serviceResponse.Mensagem = "Fechado";

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Status = false;
                serviceResponse.Mensagem = $"Não consegui o status - {ex}";
                return serviceResponse;
            }
        }
    }
}