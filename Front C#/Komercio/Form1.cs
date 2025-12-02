using Komercio.Models;
using Komercio.Services;
using Komercio.UI.Forms;
using Komercio.UI.Forms.Customer;
using Komercio.UI.Forms.Dump;
using Komercio.UI.Forms.Employee;
using Komercio.UI.Forms.Product;
using Komercio.UI.Forms.Sales;
using Komercio.UI.Forms.Transactions;
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
        private readonly CustomerTransactionService _customerTransactionService;
        private readonly CaixaService _caixaService;
        private readonly CashmovementsService _cashmovementsService;

        public Home(EmployeeService empliyeeService, CustomerService customerService, ProductService productService, ProductGroupService productGroupService, ProductSubgroupService productSubgroupService , ProductDescriptionService productDescriptionService, CustomerTransactionService customerTransactionService,CaixaService caixaService,CashmovementsService cashMovement, string baseUrl)
        {
            InitializeComponent();
            _employeeService = empliyeeService;
            _customerService = customerService;
            _productService = productService;
            _productGroupService = productGroupService;
            _productSubgroupService =  productSubgroupService;
            _productDescriptionService = productDescriptionService;
            _customerTransactionService = customerTransactionService;
            _caixaService = caixaService;
            _cashmovementsService = cashMovement;

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
            StatusCaixa();
        }
        //DTO para status Caixa:
        private List<CaixaDTO> caixaDTO = new List<CaixaDTO>();

        private async void StatusCaixa()
        {
            caixaDTO = await _caixaService.GetCaixaTransactionsAsync();

            if (caixaDTO[0].ChangeOrigin == null)
            {
                MessageBox.Show("Tive dificuldades em carregar, tente novamente mais tarde");
            }

            switch (caixaDTO[caixaDTO.Count-1].Status)
            {
                case true:
                    { mlbStatusCaixa.Text = "Aberto"; break; }
                case false:
                    { mlbStatusCaixa.Text = "Fechado"; break; }
                default:
                    { mlbStatusCaixa.Text = "Tente novamente"; break; }

            }


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
            var caixa = new frmCaixa(_caixaService, _cashmovementsService, caixaDTO);
           var retorno =  caixa.ShowDialog();

            if (retorno == DialogResult.OK) {
                StatusCaixa();
            }
        }

        private void vendaPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmSalesDump saleDump = new fmSalesDump(_httpClient);
            saleDump.ShowDialog();
        }

        private void estoqueBaixoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmProductSettings productSettingos = new fmProductSettings(_productService);
            productSettingos.ShowDialog();
        }

        private void loteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnImportStock newProductLote = new btnImportStock(_productService);
            newProductLote.ShowDialog();
        }

        private void cadernetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmCustomerTransactions customerTransactions = new fmCustomerTransactions(_customerService, _customerTransactionService, _employeeService);
            customerTransactions.ShowDialog();
        }
    }
}
