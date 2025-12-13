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

namespace Komercio.UI.Forms.Product
{
    public partial class frmProductVisualize : Form
    {
        public List<ProductDTO> product = new List<ProductDTO>();
        public List<ProductgroupDTO> productList = new List<ProductgroupDTO>();



        // injeção de dependência

        private readonly ProductService _productService;
        private readonly ProductGroupService _productgroup;

        public frmProductVisualize(ProductService productService, ProductGroupService productgroup)
        {
           _productService = productService;
            _productgroup = productgroup;
            InitializeComponent();
        }

        private void frmProductVisualize_Load(object sender, EventArgs e)
        {
            loaddbListaproduto();
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private async void loaddbListaproduto()
        {
            // Aqui estou carregando a lista dentro do service.
            product = await _productService.GetProductInStockAsync();
            productList = await _productgroup.GetProductGroupAsync();

            dgvProdutos.DataSource = product;
            ConfigurarColunasProdutos();
            CarregaLista();
        }

        private void CarregaLista()
        {
            foreach (var product in productList) {
                mgbGrupo.Items.Add(product.ProductgroupName);
            }

        }
        private void ConfigurarDataGridViews()
        {
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.BorderStyle = BorderStyle.None;
        }

        private void ConfigurarColunasProdutos()
        {
            dgvProdutos.RowHeadersVisible = false;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvProdutos.Columns["productName"].HeaderText = "Produto";
            dgvProdutos.Columns["productCodbar"].HeaderText = "Grupo";
            dgvProdutos.Columns["productStock"].HeaderText = "QTD";
            dgvProdutos.Columns["productPrice"].HeaderText = "Preço";
            dgvProdutos.Columns["productGroup"].HeaderText = "Grupo";


            dgvProdutos.Columns["idProduct"].Visible = false;
            dgvProdutos.Columns["productStatus"].Visible = false;
            dgvProdutos.Columns["productSubgroup"].Visible = false;

        }

        private void mtbNomeProduto_Click(object sender, EventArgs e)
        {

        }

        private void mtbNomeProduto_TextChanged(object sender, EventArgs e)
        {

            FiltraPorNome();

        }

        private void FiltraPorNome()
        {
            List<ProductDTO> list = new List<ProductDTO>();

            foreach (var prod in product)
            {
                bool encontrou = prod.productName.Contains(
    mtbNomeProduto.Text);

                if (encontrou)
                {
                    list.Add(prod);
                }
                else
                {
                    continue;
                }
            }

            dgvProdutos.DataSource = list;
        }




        private void FiltraPorGrupo()
        {
            List<ProductDTO> list = new List<ProductDTO>();

            foreach (var prod in product)
            {
                bool encontrou = prod.productName.Contains(
    mgbGrupo.Text);

                if (encontrou)
                {
                    list.Add(prod);
                }
                else
                {
                    continue;
                }
            }

            dgvProdutos.DataSource = list;
        }


        private void mbtLimparFiltros_Click(object sender, EventArgs e)
        {
            mtbNomeProduto.Text =string.Empty;
            mgbGrupo.Text = string.Empty;
            dgvProdutos.DataSource = product;
        }

        private void mgbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltraPorGrupo();
        }
    }
}
