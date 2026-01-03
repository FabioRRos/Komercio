using Komercio.Models.DTO;
using System.Text.Json;

namespace Komercio.Services
{
    public interface IItensVendaService
    {
        Task<List<ItensVendaModel>> ListaDeItensVenda();
        Task<List<ProductsModel>> ListaDeProdutos();
    }


    public class ItensVendaService : IItensVendaService
    {
        private List<ItensVendaModel> itensVenda = new List<ItensVendaModel>();
        private List<ProductsModel> product = new List<ProductsModel>();


        private readonly HttpClient _httpClient;
        internal readonly string _key;

        public ItensVendaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _key = configuration["ChavePrivada"];

            _httpClient.DefaultRequestHeaders.Remove("X-Token-Secreto");
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", _key);
        }
        //Lista de produtos vendidos
        public async Task<List<ItensVendaModel>> ListaDeItensVenda()
        {
            var response = await _httpClient.GetAsync("sale_items/");

            if (!response.IsSuccessStatusCode) 
            {
                return itensVenda;
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            itensVenda = JsonSerializer.Deserialize<List<ItensVendaModel>>(json, options);

            return itensVenda;
        }

        //Lista de produtos cadastrados

        public async Task<List<ProductsModel>> ListaDeProdutos()
        {
            var response = await _httpClient.GetAsync("products/");

            if (!response.IsSuccessStatusCode)
            {
                return product;
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            product = JsonSerializer.Deserialize<List<ProductsModel>>(json, options);

            return product;
        }

    }
}
