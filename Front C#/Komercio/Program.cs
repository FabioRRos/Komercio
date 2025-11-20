using Komercio.Services;
using Komercio.UI.Forms;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace Komercio
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Base URL da API
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];


            // Cria a instância do serviço da API
            var employeeService = new EmployeeService(apiBaseUrl);
            var customerService = new CustomerService(apiBaseUrl);
            var productService = new ProductService(apiBaseUrl);
            var productgroupService = new ProductGroupService(apiBaseUrl);
            var productrsuggroupService = new ProductSubgroupService(apiBaseUrl);
            var productDescriptionService = new ProductDescriptionService(apiBaseUrl);
            var customerTransactionService = new CustomerTransactionService(apiBaseUrl);



            // aqui estou aplicando a injeção de dependência manualmente
            Application.Run(new Home(employeeService, customerService, productService, productgroupService, productrsuggroupService, productDescriptionService, customerTransactionService, apiBaseUrl));


        }
    }
}