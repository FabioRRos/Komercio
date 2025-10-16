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
            tbEmployeePassword.PasswordChar = '\0';
            await Task.Delay(2000);
            tbEmployeePassword.PasswordChar = '•';
        }

        private void fmCreateEmployee_Load(object sender, EventArgs e)
        {
            InitializeItens();

        }

        private void InitializeItens()
        {
            tbEmployeeName.Enabled = false;
            tbEmployeePassword.Enabled = false;
            btnSaveNewEmployee.Enabled = false;
            btnSeePassword.Enabled = false;
            btnNewEmployee.Enabled = true;
            //clear fields
            tbEmployeeName.Text = "";
            tbEmployeePassword.Text = "";
        }

        private void NewEmployee_Click()
        {
            tbEmployeeName.Enabled = true;
            tbEmployeePassword.Enabled = true;
            btnSaveNewEmployee.Enabled = true;
            btnSeePassword.Enabled = true;
            btnNewEmployee.Enabled = false;

        
            btnNewEmployee.Focus();
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

            var nameParts = tbEmployeeName.Text.Split(' ');
            string firstName = nameParts[0].ToLower();
            string lastName = nameParts[nameParts.Length - 1].ToLower();

            var employee = new EmployeeDto
            {
                EmployeeFullName = tbEmployeeName.Text,
                EmployeeLogin = $"{firstName}.{lastName}",
                EmployeePassword = tbEmployeePassword.Text
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
            if (string.IsNullOrEmpty(tbEmployeeName.Text))
            {
                MessageBox.Show("O campo Nome do Funcionário é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbEmployeeName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbEmployeePassword.Text))
            {
                MessageBox.Show("O campo Senha do Funcionário é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbEmployeePassword.Focus();
                return false;
            }
            return true;
        }
    }

}
