using Komercio.ApplicationLayer;
using Komercio.Models;
using Komercio.Services;
using Komercio.UI.Forms.Product;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Sales
{
    public partial class fmSalesProduct : Form

    {
        private readonly HttpClient _httpClient;



        private readonly ProductService _productService;
        private readonly ProductGroupService _productGroupService;
        private readonly ProductSubgroupService _productSubgroupService;
        private readonly SaleService _saleService;
        private readonly CustomerService _customerService;
        private readonly EmployeeService _employeeService;
        private readonly ProductDescriptionService _productDescriptionService;
        private readonly CupomService _cupomService;

        private readonly ParametrosApp _parametrosApp;


        private readonly ProdutoApp _produtoApp;

        public fmSalesProduct(EmployeeService employeeService,
            ProductService productService,
            ProductGroupService productGroupService,
            ProductSubgroupService productSubgroupService,
            CustomerService customerService,
            ProductDescriptionService productDescriptionService,
            CupomService cupomService,
            string baseUrl,
            ParametrosApp parametrosApp,
            ProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;


            ////////////////////
            InitializeComponent();

            _productService = productService;
            _productGroupService = productGroupService;
            _productSubgroupService = productSubgroupService;
            _saleService = new SaleService();
            _customerService = customerService;
            _employeeService = employeeService;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _productDescriptionService = productDescriptionService;
            _cupomService = cupomService;


            ///

            _parametrosApp = parametrosApp;

        }


        private async void fmSalesProduct_Load(object sender, EventArgs e)
        {
            await loaddbListaproduto();
            ConfigurarDataGridViews();
            ClearAllComponents();
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

//aqui é pra deixar o forms bonito

        private void ConfigurarDataGridViews()
        {
            dgvCarrinho.BackgroundColor = Color.White;
            dgvCarrinho.BorderStyle = BorderStyle.None;
        }

        private void ConfigurarColunasProdutos()
        {
            dbListaproduto.RowHeadersVisible = false;

            dbListaproduto.Columns["idProduct"].Visible = false;
            dbListaproduto.Columns["productName"].HeaderText = "Produto";
            dbListaproduto.Columns["productPrice"].Visible = false;
            dbListaproduto.Columns["productCodbar"].Visible = false;
            dbListaproduto.Columns["productGroup"].HeaderText = "Grupo";
            dbListaproduto.Columns["productSubgroup"].HeaderText = "Subgrupo";
            dbListaproduto.Columns["productStock"].Visible = false;
            dbListaproduto.Columns["productStatus"].Visible = false;


            dbListaproduto.Columns["productName"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)DataGridViewAutoSizeColumnsMode.AllCells;

            dbListaproduto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigurarColunasCarrinho()
        {
            dgvCarrinho.RowHeadersVisible = false;

            dgvCarrinho.Columns["ProductId"].Visible = false;
            dgvCarrinho.Columns["ProductName"].HeaderText = "Produto";
            dgvCarrinho.Columns["Barcode"].HeaderText = "Cód Barras";
            dgvCarrinho.Columns["UnitPrice"].HeaderText = "Preço Unitário";
            dgvCarrinho.Columns["quantity"].HeaderText = "Quantidade";
            dgvCarrinho.Columns["total"].HeaderText = "Total produto";

            dgvCarrinho.Columns["ProductName"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCarrinho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

//carrega produtos
        private async Task loaddbListaproduto()
        {
            // Aqui estou carregando a lista dentro do service.
            await _saleService.loaddbListaproduto(_productService);
            dbListaproduto.DataSource = _saleService.listaDeprodutosPraUtilizarNoForm;
            ConfigurarColunasProdutos();
        }

//pesquisa por codigo de barras
        private async void mtbBarCode_TextChanged(object sender, EventArgs e)
        {
            if (mtbBarCode.Text == "")
            {
                ClearAllComponents();
                return;
            }
 
            ProductDTO temp = _saleService.buscaprodutonalista(mtbBarCode.Text);

            if (temp == null)
                return;

            PreencherCamposProduto(temp);
            statusSwitch();

            if (mswAutoInput.Checked == false)
            {
                mtbQuantity.Text = "1";
                newIten();
                return;

            }


            /*
  * Via API
  * 
  * try
  * {
  *     var temp = await _productService.GetProductByCodbad(mtbBarCode.Text);
  * 
  *     if (temp.idProduct == 0)
  *         return;
  * 
  *     PreencherCamposProduto(temp);
  * }
  * catch
  * {
  *     return;
  * }
  */

            // lista em memória
        }

        //Preenche os campos da lista de produtos

        private void PreencherCamposProduto(ProductDTO produto)
        {
            mtbProductName.Text = produto.productName;
            mtbUnitPrice.Text = produto.productPrice.ToString("C2");
            mtbStock.Text = produto.productStock.ToString();
            _saleService.tempProduct.idProduct = produto.idProduct;
            _saleService.tempProduct.productName = produto.productName;
            _saleService.tempProduct.productPrice = produto.productPrice;
            _saleService.tempProduct.productCodbar = produto.productCodbar;
            _saleService.tempProduct.productGroup = produto.productGroup;
            _saleService.tempProduct.productSubgroup = produto.productSubgroup;
            _saleService.tempProduct.productStock = produto.productStock;
            _saleService.tempProduct.productStatus = produto.productStatus;
        }

//onde temos os calculos de quantidade
        private void mtbQuantity_TextChanged(object sender, EventArgs e)
        {
            mtbQuantity.HelperText = "Quantidade";

            if (mtbQuantity.Text == "")
            {
                mtbTotalproduct.Text = "";
                return;
            }

            int stock;
            int qtd;

            try
            {
                stock = int.Parse(mtbStock.Text);
                qtd = int.Parse(mtbQuantity.Text);
            }
            catch
            {
                MessageBox.Show("Formato de entrada inválido! Digite apenas números.",
    "Erro de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mtbQuantity.HelperText = "Apenas números";
                return;
            }

            if (stock <= 0 || stock < qtd)
            {
                mtbQuantity.HelperText = "Verificar estoque";
                MessageBox.Show("Estoque insuficiente. Dê entrada antes de continuar.",
    "Sem estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbBarCode.Text = string.Empty;
                return;
            }

            float preco = float.Parse(mtbUnitPrice.Text.Replace("R$", "").Replace(" ", ""));
            mtbTotalproduct.Text = (preco * qtd).ToString("C2");
            mtbTotalproduct.HelperText = qtd + " x " + mtbUnitPrice.Text;
        }
//filtrar os produtos
        private void materialTextBox21_TextChanged(object sender, EventArgs e)
        {
            FiltrarProdutosPorCampo("productGroup", materialTextBox21.Text);
        }

        private void materialTextBox22_TextChanged(object sender, EventArgs e)
        {
            FiltrarProdutosPorCampo("productName", materialTextBox22.Text);
        }

        private void FiltrarProdutosPorCampo(string campo, string valorFiltro)
        {
            List<ProductDTO> filtrados = new List<ProductDTO>();

            if (valorFiltro == "")
            {
                materialTextBox21.Enabled = true;
                materialTextBox22.Enabled = true;
                dbListaproduto.DataSource = _saleService.listaDeprodutosPraUtilizarNoForm;
                ConfigurarColunasProdutos();
                return;
            }

            string filtro = valorFiltro.ToLower();

            foreach (ProductDTO produto in _saleService.listaDeprodutosPraUtilizarNoForm)
            {
                string campoComparado = "";

                if (campo == "productGroup")
                    campoComparado = produto.productGroup.ToLower();
                else if (campo == "productName")
                    campoComparado = produto.productName.ToLower();

                if (campoComparado.Contains(filtro))
                    filtrados.Add(produto);
            }

            dbListaproduto.DataSource = filtrados;
            ConfigurarColunasProdutos();
        }

//quando se da dois cliques para adicionar os itens no carrinho
        private void dbListaproduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow linha = dbListaproduto.Rows[e.RowIndex];
            string codigoBarras = linha.Cells["productCodbar"].Value.ToString();

            mtbBarCode.Text = codigoBarras;
            mepSearchProduct.Collapse = true;
            materialTextBox21.Text = "";
            materialTextBox22.Text = "";
        }


        private void newIten()
        {
            if (mtbBarCode.Text == "")
            {

                return;
            }

            int stock = int.Parse(mtbStock.Text);


            if (stock <= 0)
            {
                mtbBarCode.Text = string.Empty;
                return;
            }


            SalesItensDTO item = new SalesItensDTO();

            try
            {
                item.ProductId = _saleService.tempProduct.idProduct;
                item.ProductName = _saleService.tempProduct.productName;
                item.Barcode = _saleService.tempProduct.productCodbar;
                item.UnitPrice = _saleService.tempProduct.productPrice;
                item.Quantity = int.Parse(mtbQuantity.Text);
                item.Total = item.Quantity * item.UnitPrice;
            }
            catch
            {
                MessageBox.Show("Digite uma quantidade válida.",
    "Erro de entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            _saleService.CarUpdateInput(item);

            dgvCarrinho.DataSource = _saleService._productCar;
            ConfigurarColunasCarrinho();

            mlbTotal.Text = _saleService.SomeAllItens().ToString("C2");

            ClearAllComponents();
        }


//add carrinho
        private void mtbAddCar_Click(object sender, EventArgs e)
        {
            if (mtbStock.Text == "0")
            {
                return;
            }
            newIten();
        }


//remove do carrinho
        private void mbtremove_Click(object sender, EventArgs e)
        {
            ClearAllComponents();

            if (dgvCarrinho.SelectedRows.Count >= 2)
            {
                MessageBox.Show("Selecione apenas um item por vez!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCarrinho.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item para remover.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow item = dgvCarrinho.CurrentRow;


            string nomeProduto = item.Cells["ProductName"].Value.ToString();
            DialogResult resposta = MessageBox.Show(
    "Deseja remover o item\n" + item.Cells["ProductName"].Value.ToString() + "?",
    "Confirmar remoção",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question
);


            if (resposta == DialogResult.Yes)
            {
                string codbar = item.Cells["Barcode"].Value.ToString();
                bool removido = _saleService.RemoveItemCar(codbar);

                if (removido)
                {
                    MessageBox.Show("Item removido com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dbListaproduto.DataSource = null;
                    dbListaproduto.DataSource = _saleService.listaDeprodutosPraUtilizarNoForm;
                    mlbTotal.Text = _saleService.SomeAllItens().ToString("C2");
                }
                else
                {
                    MessageBox.Show("Não foi possível remover o item. Feche a venda e tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

//limpeza de estado
        private void mbtClear_Click(object sender, EventArgs e)
        {
            ClearAllComponents();
        }

        private void ClearAllComponents()
        {
            mtbBarCode.Text = "";
            mtbProductName.Text = "";
            mtbUnitPrice.Text = "";
            mtbStock.Text = "";
            mtbQuantity.Text = "";
            mtbAddCar.Enabled = false;
            mtbQuantity.Enabled = false;
        }

        private void statusSwitch()
        {
            bool ativo = mswAutoInput.Checked;

            mtbAddCar.Enabled = ativo;
            mtbQuantity.Enabled = ativo;
        }

        private void mswAutoInput_CheckedChanged(object sender, EventArgs e)
        {
            statusSwitch();
        }

        private void mswAutoInput_CheckedChanged_1(object sender, EventArgs e)
        {
            statusSwitch();
        }

        private void mtbPayment_Click(object sender, EventArgs e)
        {

            // Verifica se há itens no carrinho
            if (_saleService._productCar == null || _saleService._productCar.Count == 0)
            {
                MessageBox.Show("Adicione produtos antes de prosseguir para o pagamento.",
                                "Carrinho vazio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float totalVenda = 0;
            foreach (var item in _saleService._productCar)
            {
                totalVenda += item.Total;
            }

            // Instancia o formulário de pagamento, passando as dependências
            fmSalePaymant formPagamento = new fmSalePaymant(_employeeService,
                _customerService,
                _saleService,
                _saleService._productCar,
                totalVenda,
                _cupomService,
                _parametrosApp,
                _httpClient);

            // Exibe como diálogo (bloqueia até fechar)
            formPagamento.Owner = this;
            formPagamento.ShowDialog();

            // Depois que o form fechar, pode atualizar o carrinho ou limpar
            // (caso o pagamento tenha sido concluído)
        }

        private async void fmSalesProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F4)
            {
                fmCreateProduct createProduct = new fmCreateProduct(_produtoApp);
                createProduct.ShowDialog();
                await loaddbListaproduto();
            }

            if (e.KeyCode == Keys.F5)
            {
                fmImputProduct inputProduct = new fmImputProduct(_produtoApp);
                inputProduct.ShowDialog();
                await loaddbListaproduto();
            }
        }
    }
}
