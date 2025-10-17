using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeuProjetoWinForms.Services;
using Komercio.UI.Forms;

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

            // Cria a instância do serviço da API
            var employeeService = new EmployeeService("http://localhost:8000/");
            // Passa o serviço para os forms que precisarem
            // aqui estou aplicando a injeção de dependência manualmente
            Application.Run(new Home(employeeService));

        }
    }
}
