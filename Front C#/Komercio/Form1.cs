using Komercio.Services;
using Komercio.UI.Forms;
using Komercio.UI.Forms.Customer;
using Komercio.UI.Forms.Employee;
using Komercio.UI.Forms.Product;
using Komercio.UI.Forms.Sales;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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
        private readonly ProductGroupService _productGroupService;
        private readonly ProductSubgroupService _productSubgroupService;
        private readonly HttpClient _httpClient;
        private readonly ProductDescriptionService _productDescriptionService;




        public Home(EmployeeService empliyeeService, CustomerService customerService, ProductService productService, ProductGroupService productGroupService, ProductSubgroupService productSubgroupService , ProductDescriptionService productDescriptionService,  string baseUrl)
        {
            InitializeComponent();
            _employeeService = empliyeeService;
            _customerService = customerService;
            _productService = productService;
            _productGroupService = productGroupService;
            _productSubgroupService =  productSubgroupService;
            _productDescriptionService = productDescriptionService;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };


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
            fmCreateProduct createProduct = new fmCreateProduct(_productService, _productDescriptionService);
            createProduct.ShowDialog();
        }

        private void entradaEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmImputProduct imputProduct = new fmImputProduct(_productService);
            imputProduct.ShowDialog();
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmSalesProduct salesProduct = new fmSalesProduct(_employeeService,_productService, _productGroupService, _productSubgroupService, _customerService, _productDescriptionService, _httpClient);
            salesProduct.ShowDialog();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            fmCreateGroupAndSubgroup grpupandsubgroup = new fmCreateGroupAndSubgroup();

            grpupandsubgroup.ShowDialog();
        }
    }
}
