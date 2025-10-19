using Komercio.Services;
using Komercio.UI.Forms;
using Komercio.UI.Forms.Customer;
using Komercio.UI.Forms.Employee;
using Komercio.UI.Forms.Product;
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
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;


        public Home(EmployeeService empliyeeService, CustomerService customerService, ProductService productService )
        {
            InitializeComponent();
            _employeeService = empliyeeService;
            _customerService = customerService;
            _productService = productService;


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

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmCreateCustomer createCustomer = new fmCreateCustomer(_customerService);
            createCustomer.ShowDialog();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmChangeCustomer changeCustomer = new fmChangeCustomer(_customerService);
            changeCustomer.ShowDialog();
        }

        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmCreateProduct createProduct = new fmCreateProduct(_productService);
            createProduct.ShowDialog();
        }
    }
}
