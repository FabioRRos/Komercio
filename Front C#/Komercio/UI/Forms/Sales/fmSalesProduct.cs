using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Komercio.UI.Forms.Sales
{
    public partial class fmSalesProduct : Form
    {
        private readonly ProductService _productService;
        private readonly ProductGroupService _productGroupService;
        private readonly ProductSubgroupService _productSubgroupService;
        private readonly SaleService _saleService;



        // Vai ser o carrinho
      //  private BindingList<SalesItensDTO> _productCar = new BindingList<SalesItensDTO>();


        public fmSalesProduct(ProductService productService, ProductGroupService productGroupService, ProductSubgroupService productSubgroupService)
        {
            InitializeComponent();
            _productService = productService;
            _productGroupService = productGroupService;
            _productSubgroupService = productSubgroupService;

            //INSTANCIAS DOS OBJETOS E LISTAS DO SERVICE

            _saleService = new SaleService();

           
        }


         private async void fmSalesProduct_Load(object sender, EventArgs e)
        {
            loaddbListaproduto();
            datagridviewNewColos();
            ClearAllComponents();
        }

        private void datagridviewNewColos()
        {
            dgvCarrinho.BackgroundColor = Color.White;
            dgvCarrinho.BorderStyle = BorderStyle.None;
        }



        private async void loaddbListaproduto()
        {
            //Aqui estou carregando a lista dentro do service.
            await _saleService.loaddbListaproduto(_productService);
            dbListaproduto.DataSource = _saleService.listaDeprodutosPraUtilizarNoForm;
            dbListChangeColuns();
        }

        private void dbListChangeColuns()
        {
            dbListaproduto.RowHeadersVisible = false;
            dbListaproduto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dbListaproduto.Columns["idProduct"].Visible = false;
            dbListaproduto.Columns["productName"].HeaderText = "Produto";
            dbListaproduto.Columns["productPrice"].Visible = false;
            dbListaproduto.Columns["productCodbar"].HeaderText = "Cód Barras";
            dbListaproduto.Columns["productGroup"].HeaderText = "Grupo";
            dbListaproduto.Columns["productSubgroup"].HeaderText = "Subgrupo";
            dbListaproduto.Columns["productStock"].Visible = false;
            dbListaproduto.Columns["productStatus"].Visible = false;
        }





        private async void mtbBarCode_TextChanged(object sender, EventArgs e)
        {

            if (mtbBarCode.Text == "")
            {
                return;
            }
            /* ## AQUI ESTOU UTILIZANDO A API
              
             
             try
             {

                 var temp = await _productService.GetProductByCodbad(mtbBarCode.Text);

                 if (temp.idProduct == 0)
                 {
                     return ;
                 }
                 mtbProductName.Text = temp.productName;
                 mtbUnitPrice.Text = temp.productPrice.ToString("C2");
                 mtbStock.Text = temp.productStock.ToString();
                 _saleService.tempProduct.productName = temp.productName;
                 _saleService.tempProduct.productPrice = temp.productPrice;
                 _saleService.tempProduct.productCodbar = temp.productCodbar;
                 _saleService.tempProduct.productGroup = temp.productGroup;
                 _saleService.tempProduct.productSubgroup = temp.productSubgroup;
                 _saleService.tempProduct.productStock = temp.productStock;
                 _saleService.tempProduct.productStatus = temp.productStatus;
                 mtbAddCar.Enabled = true;
                 mtbQuantity.Enabled = true;
             }
             catch
             {

             }*/

        // AQUI ESTOU USANDO A LISTA QUE ESTÁ NO SERVICE SALE. 
        var temp = _saleService.buscaprodutonalista(mtbBarCode.Text);

            mtbProductName.Text = temp.productName;
            mtbUnitPrice.Text = temp.productPrice.ToString("C2");
            mtbStock.Text = temp.productStock.ToString();
            _saleService.tempProduct.productName = temp.productName;
            _saleService.tempProduct.productPrice = temp.productPrice;
            _saleService.tempProduct.productCodbar = temp.productCodbar;
            _saleService.tempProduct.productGroup = temp.productGroup;
            _saleService.tempProduct.productSubgroup = temp.productSubgroup;
            _saleService.tempProduct.productStock = temp.productStock;
            _saleService.tempProduct.productStatus = temp.productStatus;
            mtbAddCar.Enabled = true;
            mtbQuantity.Enabled = true;
        }

        private void mtbQuantity_TextChanged(object sender, EventArgs e)
        {


            mtbQuantity.HelperText = "Quantidade vendida";
            var stock = 0;
            var qtd = 0;
            //#######################################

            if (mtbQuantity.Text != "")
            {

                
                try
                {
                     stock = int.Parse(mtbStock.Text);
                     qtd = int.Parse(mtbQuantity.Text);
                }
                catch
                {
                    MessageBox.Show("Formato de entrada invalido!");
                    mtbQuantity.HelperText = "Apenas números";

                    return;
                }

                if (stock <= 0 || stock < qtd)
                {
                    mtbQuantity.HelperText = "Produto sem estoque";
                   
                    MessageBox.Show("Estoque insuficiente. Dê entrada antes de continuar");

                    return;
                }
                else
                {
                    float temp = float.Parse(mtbUnitPrice.Text.Replace("R$", "").Replace(" ", ""));
                    mtbTotalproduct.Text = (temp * int.Parse(mtbQuantity.Text)).ToString("C2");
                    mtbTotalproduct.HelperText = mtbQuantity.Text + "*" + mtbUnitPrice.Text;
                }
            }
            else {

                mtbTotalproduct.Text = "";
            }
        }

        private void materialTextBox21_TextChanged(object sender, EventArgs e)
        {




            List<ProductDTO> filtrados = new List<ProductDTO>();

            if (materialTextBox21.Text == "")
            {
                materialTextBox22.Enabled = true;
                loaddbListaproduto();
                return;
            }


            materialTextBox22.Enabled = false;
            materialTextBox22.Text = string.Empty;

            string filtro = materialTextBox21.Text.ToLower();


            foreach (var product in _saleService.listaDeprodutosPraUtilizarNoForm)
            {
                string nome = product.productGroup.ToLower();

                if (nome.Contains(filtro))
                {
                    filtrados.Add(product);
                }

            }

            dbListaproduto.DataSource = filtrados;

            dbListChangeColuns();
        }


        

        private void materialTextBox22_TextChanged(object sender, EventArgs e)
        {
            List<ProductDTO> filtrados = new List<ProductDTO>();

            if (materialTextBox22.Text == "")
            {
                materialTextBox21.Enabled = true;
                loaddbListaproduto();
                return;
            }


            materialTextBox21.Enabled = false;
            materialTextBox21.Text = string.Empty;

            string filtro = materialTextBox22.Text.ToLower();


            foreach (var product in _saleService.listaDeprodutosPraUtilizarNoForm)
            {
                string nome = product.productName.ToLower();

                if (nome.Contains(filtro))
                {
                    filtrados.Add(product);
                }

            }

            dbListaproduto.DataSource = filtrados;

            dbListChangeColuns();
        }

        private void dbListaproduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow linha = dbListaproduto.Rows[e.RowIndex];
            string codigoBarras = linha.Cells["productCodbar"].Value.ToString();
            mtbBarCode.Text = codigoBarras;
            mepSearchProduct.Collapse = true;
            materialTextBox21.Text = string.Empty;
            materialTextBox22.Text = string.Empty;



        }

        public float soma = 0;
        private void mtbAddCar_Click(object sender, EventArgs e)
        {
           
            // Aualiza o grid

            if (addCar() == false)
            {
                return;
            }
            dgvCarrinho.DataSource = _saleService._productCar;
            datagridcar();
            mlbTotal.Text = soma.ToString("C2");
            ClearAllComponents();

        }

        private void datagridcar()
        {
            dgvCarrinho.RowHeadersVisible = false;
            dgvCarrinho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCarrinho.Columns["ProductId"].Visible = false;
            dgvCarrinho.Columns["ProductName"].HeaderText = "Produto";
            dgvCarrinho.Columns["Barcode"].HeaderText = "Cód Barras";
            dgvCarrinho.Columns["UnitPrice"].HeaderText = "Preço Unitário";
            dgvCarrinho.Columns["quantity"].HeaderText = "Quantidade";
            dgvCarrinho.Columns["total"].HeaderText = "Total produto";
    
        }


        private bool addCar()
        {
            try
            {
                SalesItensDTO salesitens = new SalesItensDTO();

                salesitens.ProductId = _saleService.tempProduct.idProduct;
                salesitens.ProductName = _saleService.tempProduct.productName;
                salesitens.Barcode = _saleService.tempProduct.productCodbar;
                salesitens.UnitPrice = _saleService.tempProduct.productPrice;
                salesitens.Quantity = int.Parse(mtbQuantity.Text);
                salesitens.Total = salesitens.Quantity * salesitens.UnitPrice;
                soma += salesitens.Total;

                //_saleService._productCar.Add(salesitens);
                _saleService.CarUpdateInput(salesitens);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Digite uma quantidade");
                return false;
            }
        }


        private void mbtClear_Click(object sender, EventArgs e)
        {
            ClearAllComponents();
        }

        private void ClearAllComponents()
        {
            mtbBarCode.Text = string.Empty;
            mtbProductName.Text = string.Empty;
            mtbUnitPrice.Text = string.Empty;
            mtbStock.Text = string.Empty;
            mtbQuantity.Text = string.Empty;
            mtbAddCar.Enabled = false;
            mtbQuantity.Enabled = false;

        }
    }
}
