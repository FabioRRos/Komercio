using MeuProjetoWinForms.Models;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Employee
{
    public partial class fmChangePasswordEmployeer : Form
    {
        private readonly EmployeeService _employeeService;


        private bool returnAutentication = false;
        public fmChangePasswordEmployeer(EmployeeService servic)
        {
            InitializeComponent();
            _employeeService = servic;
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
         
            if (mtbLoginEmployeer.Text == "" || mtbPasswordEmployeer.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Iniciando a validação de login e senha

            var employee = new EmployeeDto
            {
                EmployeeLogin = mtbLoginEmployeer.Text,
                EmployeePassword = mtbPasswordEmployeer.Text
            };

            try
            {
                returnAutentication = await _employeeService.LoginAsync(employee.EmployeeLogin,employee.EmployeePassword);

                if (returnAutentication)
                {
                    mbtNewPasswordEmployeer1.Enabled = true;
                    mbtNewPasswordEmployeer2.Enabled = true;
                    btnChangePasswordEmployeer.Enabled = true;
                    mtbLoginEmployeer.Enabled = false;
                    mtbPasswordEmployeer.Enabled = false;
                    mbtnLoginChangePassword.Enabled = false;

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



        private void fmChangePasswordEmployeer_Load(object sender, EventArgs e)
        {
            InitializeComponent_status();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }


        public void InitializeComponent_status()
        {
            mbtNewPasswordEmployeer1.Enabled = false;
            mbtNewPasswordEmployeer2.Enabled = false;
            btnChangePasswordEmployeer.Enabled = false;
        }

        private async void btnChangePasswordEmployeer_Click(object sender, EventArgs e)
        {
            if (returnAutentication != true){
                return;
            }

            if (mbtNewPasswordEmployeer1.Text != mbtNewPasswordEmployeer2.Text)
            {
                MessageBox.Show("As senhas não coincidem", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                returnAutentication = await _employeeService.UpdatePasswordAsync(mtbLoginEmployeer.Text,mbtNewPasswordEmployeer1.Text);

                if (returnAutentication)
                {
                    MessageBox.Show("Senha alterada com sucesso",
                                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                }
                else
                {
                    MessageBox.Show("Não foi possivel alterar neste momento, tente novamente mais tarde",
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

        private async void mbtVisiblePassword_Click(object sender, EventArgs e)
        {
            mtbPasswordEmployeer.PasswordChar = '\0';           
            await Task.Delay(2000);
            mtbPasswordEmployeer.PasswordChar = '•';
            
        }

        private async void materialButton1_Click_1(object sender, EventArgs e)
        {

            mbtNewPasswordEmployeer1.PasswordChar = '\0';
            mbtNewPasswordEmployeer2.PasswordChar = '\0';
            await Task.Delay(2000);
            mbtNewPasswordEmployeer1.PasswordChar = '•';
            mbtNewPasswordEmployeer2.PasswordChar = '•';

        }
    }
}
