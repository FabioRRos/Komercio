using Komercio.Models.DTO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Komercio.Services
{
    public interface IListaDeCompraService
    {
        Task<List<ListaComprasDTO>> ListaDeComprasAtivaService();
        Task<List<ItemListaCompraDTO>> ItrensDaListaDeCompraService(int id);
        Task<ListaComprasDTO> AtualizarStatusDaLista(ListaComprasDTO listaDeCompra);


    }


    public class ListaDeCompraService: IListaDeCompraService
    {
        private List<ListaComprasDTO> listaDeCompra = new List<ListaComprasDTO>();
        private List<ItemListaCompraDTO> itensListaDeCompra = new List<ItemListaCompraDTO>();

        private readonly HttpClient _httpClient;
        internal readonly string _key;

        public ListaDeCompraService (HttpClient httpCliente, IConfiguration configuration)
        {
            _httpClient = httpCliente;
            _key = configuration["ChavePrivada"]; 

            _httpClient.DefaultRequestHeaders.Remove("X-Token-Secreto");
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", _key);
        }

        // Listas  de compras (todas ativas)

        public async Task<List<ListaComprasDTO>> ListaDeComprasAtivaService()
        {
            var response = await _httpClient.GetAsync("listacompra/ativas");
            if (!response.IsSuccessStatusCode)
            {
                return listaDeCompra;
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            listaDeCompra = JsonSerializer.Deserialize<List<ListaComprasDTO>>(json, options);

            return listaDeCompra;

        }


        public async Task<List<ItemListaCompraDTO>> ItrensDaListaDeCompraService(int id)
        {
            var response = await _httpClient.GetAsync($"itenslista/id/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return itensListaDeCompra;
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            itensListaDeCompra = JsonSerializer.Deserialize<List<ItemListaCompraDTO>>(json, options);

            return itensListaDeCompra;

        }


        public async Task<ListaComprasDTO> AtualizarStatusDaLista(ListaComprasDTO listaDeCompra)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                PropertyNameCaseInsensitive = true
            };
            var jsonContent = JsonSerializer.Serialize(listaDeCompra, options);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("listacompra", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ListaComprasDTO>(responseString, options);

            }            
            return null;
        }
    }
}
