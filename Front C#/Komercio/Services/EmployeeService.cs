using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MeuProjetoWinForms.Models;

namespace MeuProjetoWinForms.Services
{
    public class EmployeeService

    {

        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Cria um novo funcionário
        public async Task<bool> CreateEmployeeAsync(EmployeeDto employee)
        {
            var json = JsonConvert.SerializeObject(employee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("employees", content);
            return response.IsSuccessStatusCode;
        }

        // Login do funcionário
        public async Task<bool> LoginAsync(string login, string password)
        {
            var payload = new { login, password };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("employees/login", content);
            if (!response.IsSuccessStatusCode) return false;

            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginResponse>(resultJson);
            return result?.Success ?? false;
        }

        // Atualizar senha
        public async Task<bool> UpdatePasswordAsync(string login, string newPassword)
        {
            var payload = new { login, newPassword };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("employees/password", content);
            return response.IsSuccessStatusCode;
        }

        // Atualizar nome
        public async Task<bool> UpdateNameAsync(string login, string newName)
        {
            var payload = new { login, newName };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("employees/name", content);
            return response.IsSuccessStatusCode;
        }

        // Deletar / desativar funcionário
        public async Task<bool> DeactivateEmployeeAsync(string login)
        {
            var response = await _httpClient.DeleteAsync($"employees/{login}");
            return response.IsSuccessStatusCode;
        }

        // DTO interno para resposta de login
        private class LoginResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }
        }
    }
}
