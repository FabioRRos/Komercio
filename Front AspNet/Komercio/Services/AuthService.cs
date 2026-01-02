using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Komercio.Services
{
    public interface IAuthService
    {
        Task<bool> AutenticarAsync(string usuario, string senha);
    }

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        internal readonly string _key;


        public AuthService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _key = configuration["ChavePrivada"];
        }



        /// <summary>
        /// Valida o login do colaborador
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> AutenticarAsync(string login, string password)
        {
            var payload = new { login, password };
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            _httpClient.DefaultRequestHeaders.Remove("X-Token-Secreto"); // Limpa anteriores se houver
            _httpClient.DefaultRequestHeaders.Add("X-Token-Secreto", _key);

            var response = await _httpClient.PostAsync("employees/login", content);

            return response.IsSuccessStatusCode;
        }
    }
}