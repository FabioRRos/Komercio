using MeuProjetoWinForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoWinForms.Services
{
    public class EmployeeService

    {
        public class EmployeeName
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        private readonly HttpClient _httpClient;

        public EmployeeService(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
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
            if (result == null)
            {
                return false;
            }
            else
            {
                return result.Success;
            }
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


        // GET /employees/names - Retorna lista de nomes de funcionários ativos
        public async Task<List<EmployeeDto>> GetActiveEmployeeNamesAsync()
        {
            var response = await _httpClient.GetAsync("employees/names");

            if (!response.IsSuccessStatusCode)
            {
                return new List<EmployeeDto>();
            }

            var json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<EmployeeDto>();
            }

            var employees = JsonConvert.DeserializeObject<List<EmployeeName>>(json);

            
            var activeEmployees = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                var temp = new EmployeeDto();
                temp.EmployeeFullName = employee.Name;
                temp.Id = employee.Id;
                activeEmployees.Add(temp);
            }


            if (employees != null)
            {
                return activeEmployees;
            }
            else
            {
                return new List<EmployeeDto>();
            }
        }



        // DTO interno para resposta de login
        private class LoginResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }
        }
    }
}
