using Komercio.Models; // Seu namespace de modelos
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Komercio.Services
{
    // A classe CustomerService encapsula toda a comunicação com a API /customer do backend Go.
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        // O construtor recebe a URL base via Injeção de Dependência manual.
        public CustomerService(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        // POST /customer
        // Cria um novo cliente
        public async Task<(bool Success, string Message)> CreateCustomerAsync(CustomerDto customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("customer", content);

            var message = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, message);
        }




        // GET /customer
        // Retorna todos os clientes cadastrados
        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var response = await _httpClient.GetAsync("customer");

            if (!response.IsSuccessStatusCode)
            {
                return new List<CustomerDto>();
            }

            var resultJson = await response.Content.ReadAsStringAsync();

            var customers = JsonConvert.DeserializeObject<List<CustomerDto>>(resultJson);

            // Retorno simples (explícito para evitar 'null')
            if (customers == null)
            {
                return new List<CustomerDto>();
            }

            return customers;
        }

        // GET /customer/:id
        // Busca um cliente pelo ID
        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"customer/{id}");

            if (!response.IsSuccessStatusCode)
            {
                // Retorna nulo se o cliente não for encontrado ou em caso de erro.
                return null;
            }

            var resultJson = await response.Content.ReadAsStringAsync();

           
           var  customers =  JsonConvert.DeserializeObject<CustomerDto>(resultJson);

            if (customers == null)
            {
                return new CustomerDto();
            }

            return customers;



        }


        // GET /customer/name/{name}
        // Retorna clientes com nome parcial ou completo (case-insensitive)
        public async Task<List<CustomerDto>> GetCustomersByNameAsync(string name)
        {
            var response = await _httpClient.GetAsync($"customer/name/{name}");

            if (!response.IsSuccessStatusCode)
            {
                return new List<CustomerDto>();
            }

            var resultJson = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<List<CustomerDto>>(resultJson);


            if (customers == null)
            { 
                return new List<CustomerDto>();
            }
            else
            {
                return customers;
            }

               // return customers ?? new List<CustomerDto>();
        }




        // PUT /customer/:id
        // Atualiza um cliente existente
        public async Task<bool> UpdateCustomerAsync(CustomerDto customer)
        {
            var json = JsonConvert.SerializeObject(customer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Rota: /customer/:id
            var response = await _httpClient.PutAsync($"customer/{customer.customer_id}", content);
            return response.IsSuccessStatusCode;
        }

        // DELETE /customer/:id
        // Desativa um cliente (Soft Delete)
        public async Task<bool> DeactivateCustomerAsync(int id)
        {
            // Rota: /customer/:id (o backend Go faz o soft delete)
            var response = await _httpClient.DeleteAsync($"customer/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}