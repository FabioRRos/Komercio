using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KomercioPlus.Model.Entity;

namespace KomercioPlus.Service
{
    public interface IListaDeCompraService
    {
        Task<ServiceResponse<List<ListaDeCompras>>> ListaDeCompraAtiva();
        Task<ServiceResponse<List<ItensListaCompra>>> ItensListaDeItensVenda(int id);
    }
    public class ListaDeCompraService : IListaDeCompraService
    {
        private readonly HttpClient _httpClient;
        internal readonly string _key;
        private List<ItensListaCompra> itensVenda = new List<ItensListaCompra>();
        public ListaDeCompraService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _key = configuration["ChavePrivada"];
            _httpClient.DefaultRequestHeaders.Remove("X-Token-Secreto"); // Garante que não duplica
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", _key);

        }


        public async Task<ServiceResponse<List<ListaDeCompras>>> ListaDeCompraAtiva()
        {
            var serviceResponse = new ServiceResponse<List<ListaDeCompras>>();

            try
            {
                var response = await _httpClient.GetAsync("listacompra/ativas");

                if (!response.IsSuccessStatusCode)
                {
                    serviceResponse.Status = false;
                    serviceResponse.Mensagem = "Erro ao buscar a lista de compras.";
                    return serviceResponse;
                }

                var json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var lista = JsonSerializer.Deserialize<List<ListaDeCompras>>(json, options);

                serviceResponse.Dados = lista;
                serviceResponse.Status = true;

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Status = false;
                serviceResponse.Mensagem = $"Erro ao buscar a lista de compras - {ex.Message}";
                return serviceResponse;
            }
        }



        public async Task<ServiceResponse<List<ItensListaCompra>>> ItensListaDeItensVenda(int id)
        {
            var serviceResponse = new ServiceResponse<List<ItensListaCompra>>();


            var response = await _httpClient.GetAsync($"itenslista/id/{id}");

            if (!response.IsSuccessStatusCode)
            {
                serviceResponse.Status = false;
                serviceResponse.Mensagem = "Não consegui trazer os dados da API";
                return serviceResponse;
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            serviceResponse.Dados = JsonSerializer.Deserialize<List<ItensListaCompra>>(json, options);

            serviceResponse.Status = true;

            return serviceResponse;
        }



    }
}