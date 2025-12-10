using MeuProjetoWinForms.Models;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms
{
    public partial class frmLogin : Form
    {
        private readonly EmployeeService _employeeService;
        private bool returnAutentication = false;
        public int employeersId { get; private set; }
       public  EmployeeDto employee = new EmployeeDto();
        public frmLogin(EmployeeService service)
        {
            InitializeComponent();
            _employeeService = service;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {

            ValidarLogin();

        }
        private async void ValidarLogin()
        {
            if (mtbLoginEmployeer.Text == "" || mtbPasswordEmployeer.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Iniciando a validação de login e senha

            employee.EmployeeLogin = mtbLoginEmployeer.Text;
            employee.EmployeePassword = mtbPasswordEmployeer.Text;


            try
            {
                returnAutentication = await _employeeService.LoginAsync(employee.EmployeeLogin, employee.EmployeePassword);

                if (returnAutentication)
                {
                    await NormalizeEmployeer();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha invalido",
                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mtbPasswordEmployeer_TextChanged(object sender, EventArgs e)
        {
            if (mtbPasswordEmployeer.Text != "")
            {
                mtbPasswordEmployeer.PasswordChar = '*';
            }
        }

        private async void mbtVer_Click(object sender, EventArgs e)
        {
            mtbPasswordEmployeer.PasswordChar = '\0';
            await Task.Delay(2000);
            mtbPasswordEmployeer.PasswordChar = '•';
        }


        internal async Task NormalizeEmployeer()
        {
          List<EmployeeDto> lista = await _employeeService.GetActiveEmployeeNamesAsync();


            foreach (EmployeeDto emp in lista)
            {
                string nomeCompleto = emp.EmployeeFullName;
                string usuarioAbreviado = GerarUsuarioAbreviado(nomeCompleto);
                if (usuarioAbreviado == employee.EmployeeLogin )
                {
                    employeersId = emp.Id;
                }
            }

        }

        public string GerarUsuarioAbreviado(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;

            texto = texto.Trim();

            string[] palavras = texto.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (palavras.Length < 2)
                return texto.ToLower();

            string primeiraLetra = palavras[0].Substring(0, 1).ToLower();
            string ultimaPalavra = palavras[palavras.Length - 1].ToLower();

            string resultado = primeiraLetra + "." + ultimaPalavra;

            return resultado;
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidarLogin();
            }
        }
    }
}
