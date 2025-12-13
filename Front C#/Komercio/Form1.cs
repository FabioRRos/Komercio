using Komercio.Models;
using Komercio.Services;
using Komercio.UI.Forms;
using Komercio.UI.Forms.Caixa;
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
        private readonly string _httpClient;
        private readonly ProductDescriptionService _productDescriptionService;
        private readonly CustomerTransactionService _customerTransactionService;
        private readonly CaixaService _caixaService;
        private readonly CashmovementsService _cashmovementsService;
        private readonly CupomService _cupomService;

        //Status do caixa 
        internal bool caixaStatus;

        public Home(EmployeeService empliyeeService, CustomerService customerService, ProductService productService, ProductGroupService productGroupService, ProductSubgroupService productSubgroupService , ProductDescriptionService productDescriptionService, CustomerTransactionService customerTransactionService,CaixaService caixaService,CashmovementsService cashMovement,CupomService cupomService, string baseUrl)
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
            _cupomService = cupomService;

            _httpClient = baseUrl;


        }

        private void novoFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função desativada temporariamente!!","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //CadastrarFuncionario();
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

            if (caixaDTO.Count <= 0)
            {
                MessageBox.Show("É necessário realizar a abertura do caixa!!");
                mlbStatusCaixaa.Text = "Fechado";
                caixaStatus = false;
                mbtAbrirCaixa.UseAccentColor = false;
                mtbFecharCaixa.UseAccentColor = true;
                mbtSangria.UseAccentColor = true;
                return;

            }

            if (caixaDTO[0].ChangeOrigin == null)
            {
                MessageBox.Show("Tive dificuldades em carregar, tente novamente mais tarde");
            }
            
                switch (caixaDTO[caixaDTO.Count - 1].Status)
                {
                    case true:
                        {
                        mlbStatusCaixaa.Text = "Aberto";
                        caixaStatus = caixaDTO[caixaDTO.Count - 1].Status;
                        mbtAbrirCaixa.UseAccentColor = true;
                        mtbFecharCaixa.UseAccentColor = false;
                        mbtSangria.UseAccentColor = false;

                        }
                    break;
 
                    case false:
                        {
                        mlbStatusCaixaa.Text = "Fechado";
                        caixaStatus = caixaDTO[caixaDTO.Count - 1].Status;
                        mbtAbrirCaixa.UseAccentColor = false;
                        mtbFecharCaixa.UseAccentColor = true;
                        mbtSangria.UseAccentColor = true;
                    }
                    break;
                    default:
                    {
                        mlbStatusCaixaa.Text = "Tente novamente";
                        caixaStatus = false;


                    }
                    break;


                }
        


        }

        private void CaixaFechadoOptions()
        {

        }
        private void CaixaAbertoOptions()
        {

        }

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarSenhaFuncionario();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarClientes();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlterarCliente();
        }

        private void novoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarProdutoManual();
        }

        private void entradaEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EntradaEstoque();
        }

        private void novaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendas();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
    
                
           
        }

        private void vendaPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmSalesDump saleDump = new fmSalesDump(_httpClient);
            saleDump.ShowDialog();
        }

        private void estoqueBaixoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função desativada temporariamente!!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //ConfigurarBaixaEstoque();
        }

        private void loteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnImportStock newProductLote = new btnImportStock(_productService);
            newProductLote.ShowDialog();
        }

        private void cadernetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Caderneta();
        }

        private void fechamentoDoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FechamentoDoCaixa();

        }

        private void aberturaDoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AberturaDoCaixa();
        }


        private void sangriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sangria();
        }

        private void descarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescartarProdutos();
        }



        /// <summary>
        /// Menus de abertura, fechamento e sangria
        /// </summary>

        private void AberturaDoCaixa()
        {
            if (caixaStatus)
            {
                MessageBox.Show("O caixa já está aberto!", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!caixaStatus)
            {
                var caixa = new fmAberturaCaixa(_caixaService, _employeeService);
                var retorno = caixa.ShowDialog();

                if (retorno == DialogResult.OK)
                {
                    StatusCaixa();
                }
            }
        }

        private void FechamentoDoCaixa()
        {
            if (!caixaStatus)
            {
                MessageBox.Show("O caixa já está Fechado!", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (caixaStatus)
            {
                var caixa = new frmFechamentoCaixa(_caixaService, _cashmovementsService, caixaDTO,_employeeService);
                var retorno = caixa.ShowDialog();

                if (retorno == DialogResult.OK)
                {
                    StatusCaixa();
                }
            }
        }


        private void Vendas()
        {
            if (caixaStatus)
            {
                fmSalesProduct salesProduct = new fmSalesProduct(_employeeService, _productService, _productGroupService, _productSubgroupService, _customerService, _productDescriptionService, _cupomService, _httpClient);
                salesProduct.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para realizar uma venda é necessário primeiro abrir o caixa","ATENÇÃO!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Caderneta()
        {
            if (caixaStatus)
            {
                fmCustomerTransactions customerTransactions = new fmCustomerTransactions(_customerService, _customerTransactionService, _employeeService);
                customerTransactions.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para acessar a caderneta é necessário primeiro abrir o caixa", "ATENÇÃO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void Sangria()
        {
            if (caixaStatus)
            {

                frmSangria sangria = new frmSangria(_caixaService, _employeeService);
                sangria.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para realizar a sangria é necessário primeiro abrir o caixa", "ATENÇÃO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        private void CadastrarClientes()
        {
            fmCreateCustomer createCustomer = new fmCreateCustomer(_customerService);
            createCustomer.ShowDialog();
        }


        private void EntradaEstoque()
        {
            fmImputProduct imputProduct = new fmImputProduct(_productService);
            imputProduct.ShowDialog();
        }

        private void CadastrarProdutoManual()
        {
            fmCreateProduct createProduct = new fmCreateProduct(_productService, _productDescriptionService);
            createProduct.ShowDialog();
        }

        private void AlterarCliente()
        {
            fmChangeCustomer changeCustomer = new fmChangeCustomer(_customerService);
            changeCustomer.ShowDialog();
        }

        private void AlterarSenhaFuncionario()
        {
            fmChangePasswordEmployeer changePasswordEmployeer = new fmChangePasswordEmployeer(_employeeService);
            changePasswordEmployeer.ShowDialog();
        }

        private void CadastrarFuncionario()
        {
            fmCreateEmployee newEmployee = new fmCreateEmployee(_employeeService);
            newEmployee.ShowDialog();
        }


        private void ConfigurarBaixaEstoque()
        {
            fmProductSettings productSettingos = new fmProductSettings(_productService);
            productSettingos.ShowDialog();
        }


        private void DescartarProdutos()
        {
            frmDescarte descarteProduto = new frmDescarte(_productService,_employeeService);
            descarteProduto.ShowDialog();
        }

        private void ListaDeProdutos()
        {
            frmProductVisualize listaProduto = new frmProductVisualize(_productService,_productGroupService);
            listaProduto.ShowDialog();
        }



        /// <summary>
        /// BOTÕES FORM PRINCIPAL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mbtSangria_Click(object sender, EventArgs e)
        {
            Sangria();
        }

        private void mtbFecharCaixa_Click(object sender, EventArgs e)
        {
            FechamentoDoCaixa();
        }

        private void mbtAbrirCaixa_Click(object sender, EventArgs e)
        {
            AberturaDoCaixa();
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            Vendas();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            Caderneta();
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            CadastrarClientes();
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            EntradaEstoque();
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            CadastrarProdutoManual();
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            AlterarCliente();
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            AlterarSenhaFuncionario();
        }

        private void listaDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaDeProdutos();
        }
    }
}
