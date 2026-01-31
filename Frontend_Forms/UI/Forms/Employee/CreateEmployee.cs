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
    public partial class fmCreateEmployee : Form
    {
        private readonly EmployeeService _employeeService;
        public fmCreateEmployee(EmployeeService service)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            _employeeService = service;



        }

        private async void btnSeePassword_Click(object sender, EventArgs e)
        {
            mtbEmployeePassword.PasswordChar = '\0';
            await Task.Delay(2000);
            mtbEmployeePassword.PasswordChar = '•';
        }

        private void fmCreateEmployee_Load(object sender, EventArgs e)
        {
            InitializeItens();

        }

        private void InitializeItens()
        {
            mtbEmployeeName.Enabled = false;
            mtbEmployeePassword.Enabled = false;
            mbtnSaveNewEmployee.Enabled = false;
            mbtnSeePassword.Enabled = false;
            mtbEmployeePassword1.Enabled = false;
            mbtnNewEmployee.Enabled = true;
            //clear fields
            mtbEmployeeName.Text = "";
            mtbEmployeePassword.Text = "";
            mtbEmployeePassword1.Text = "";
        }

        private void NewEmployee_Click()
        {
            mtbEmployeeName.Enabled = true;
            mtbEmployeePassword.Enabled = true;
            mbtnSaveNewEmployee.Enabled = true;
            mbtnSeePassword.Enabled = true;
            mtbEmployeePassword1.Enabled = true;
            mbtnNewEmployee.Enabled = false;

        
            mbtnNewEmployee.Focus();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            NewEmployee_Click();

        }

        private async void btnSaveNewEmployee_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateFields();
            if (!isValid)
                return;

            var nameParts = mtbEmployeeName.Text.Split(' ');
            string firstName = nameParts[0].ToLower();
            string lastName = nameParts[nameParts.Length - 1].ToLower();

            var employee = new EmployeeDto
            {
                EmployeeFullName = mtbEmployeeName.Text,
                EmployeeLogin = $"{firstName}.{lastName}",
                EmployeePassword = mtbEmployeePassword.Text
            };

            try
            {
                bool success = await _employeeService.CreateEmployeeAsync(employee);

                if (success)
                {
                    MessageBox.Show("Funcionário cadastrado com sucesso!",
                                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeItens();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar funcionário!",
                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(mtbEmployeeName.Text))
            {
                MessageBox.Show("O campo Nome do Funcionário é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbEmployeeName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(mtbEmployeePassword.Text))
            {
                MessageBox.Show("O campo Senha do Funcionário é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbEmployeePassword.Focus();
                return false;
            }

            if (mtbEmployeePassword.Text != mtbEmployeePassword1.Text)
            {
                MessageBox.Show("As senhas não coincidem.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbEmployeePassword1.Focus();
                return false;
            }
            return true;
        }

        private void mbtnNewEmployee_Click(object sender, EventArgs e)
        {
            NewEmployee_Click();
        }

        private async void mbtnSaveNewEmployee_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateFields();
            if (!isValid)
                return;

            var nameParts = mtbEmployeeName.Text.Split(' ');
            string firstName = nameParts[0].ToLower();
            string lastName = nameParts[nameParts.Length - 1].ToLower();

            var employee = new EmployeeDto
            {
                EmployeeFullName = mtbEmployeeName.Text,
                EmployeeLogin = $"{firstName}.{lastName}",
                EmployeePassword = mtbEmployeePassword.Text
            };

            try
            {
                bool success = await _employeeService.CreateEmployeeAsync(employee);

                if (success)
                {
                    MessageBox.Show("Funcionário cadastrado com sucesso!",
                                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeItens();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar funcionário!",
                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void mbtnSeePassword_Click(object sender, EventArgs e)
        {
            mtbEmployeePassword.PasswordChar = '\0';
            mtbEmployeePassword1.PasswordChar = '\0';
            await Task.Delay(2000);
            mtbEmployeePassword.PasswordChar = '•';
            mtbEmployeePassword1.PasswordChar = '•';
        }



        
    }

}
