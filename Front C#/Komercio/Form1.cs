using Komercio.UI.Forms;
using Komercio.UI.Forms.Employee;
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

namespace Komercio
{
    public partial class Home : Form
    {
        private readonly EmployeeService _employeeService;

        public Home(EmployeeService service)
        {
            InitializeComponent();
            _employeeService = service;
        }

        private void novoFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmCreateEmployee newEmployee = new fmCreateEmployee(_employeeService);
            newEmployee.ShowDialog();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmChangePasswordEmployeer changePasswordEmployeer = new fmChangePasswordEmployeer(_employeeService);
            changePasswordEmployeer.ShowDialog();
        }
    }
}
