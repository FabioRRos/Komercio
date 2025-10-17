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
         
            if (mtbLoginEmployeer.Text == "Login" || mtbPasswordEmployeer.Text == "Senha")
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

        private void mtbLoginEmployeer_Enter(object sender, EventArgs e)
        {
            if (mtbLoginEmployeer.Text == "Login")
            {
                mtbLoginEmployeer.Text = "";
            }
        }

        private void mtbLoginEmployeer_Leave(object sender, EventArgs e)
        {
            if (mtbLoginEmployeer.Text == "")
            {
                mtbLoginEmployeer.Text = "Login";

            }
        }

        private void mtbPasswordEmployeer_Enter(object sender, EventArgs e)
        {
            if (mtbPasswordEmployeer.Text == "Senha")
            {
                mtbPasswordEmployeer.Text = "";
                mtbPasswordEmployeer.UseSystemPasswordChar = true;
            }
        }

        private void mtbPasswordEmployeer_Leave(object sender, EventArgs e)
        {
            if (mtbPasswordEmployeer.Text == "")
            {
                mtbPasswordEmployeer.Text = "Senha";
                mtbPasswordEmployeer.UseSystemPasswordChar = false;
            }
        }

        private void mbtNewPasswordEmployeer1_Enter(object sender, EventArgs e)
        {
            if (mbtNewPasswordEmployeer1.Text == "Nova senha")
            {
                mbtNewPasswordEmployeer1.Text = "";
                mbtNewPasswordEmployeer1.UseSystemPasswordChar = true;

            }

        }

        private void mbtNewPasswordEmployeer1_Leave(object sender, EventArgs e)
        {
            if (mbtNewPasswordEmployeer1.Text == "")
            {
                mbtNewPasswordEmployeer1.Text = "Nova senha";
                mbtNewPasswordEmployeer1.UseSystemPasswordChar = false;

            }
        }

        private void mbtNewPasswordEmployeer2_Enter(object sender, EventArgs e)
        {
            if (mbtNewPasswordEmployeer2.Text == "Confirmar nova senha")
            {
                mbtNewPasswordEmployeer2.Text = "";
                mbtNewPasswordEmployeer2.UseSystemPasswordChar = true;
            }
        
        }

        private void mbtNewPasswordEmployeer2_Leave(object sender, EventArgs e)
        {
            if (mbtNewPasswordEmployeer2.Text == "")
            {
                mbtNewPasswordEmployeer2.Text = "Confirmar nova senha";
                mbtNewPasswordEmployeer2.UseSystemPasswordChar = false;

            }
        }

        private void mtbPasswordEmployeer_Click(object sender, EventArgs e)
        {

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
    }
}
