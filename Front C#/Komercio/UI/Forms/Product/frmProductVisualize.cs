using Komercio.ApplicationLayer;
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

        private readonly ProdutoApp _produtoApp;

        //private readonly ProductService _productService;
        //private readonly ProductGroupService _productgroup;

        public frmProductVisualize(ProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;
           //_productService = productService;
           // _productgroup = productgroup;
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
            (product, productList) = await _produtoApp.BuscaListaDeProdutoEGrupo();
            dgvProdutos.DataSource = product;
            ConfigurarColunasProdutos();
            CarregaLista();
        }
        // adiciono os itens no groupBox
        private void CarregaLista()
        {
            foreach (var product in productList) {
                mgbGrupo.Items.Add(product.ProductgroupName);
            }
            ConfigurarDataGridViews();

        }
        private void ConfigurarDataGridViews()
        {
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.BorderStyle = BorderStyle.None;
        }

        private void ConfigurarColunasProdutos()
        {
            dgvProdutos.RowHeadersVisible = false;

            dgvProdutos.Columns["productName"].HeaderText = "Produto";
            dgvProdutos.Columns["productCodbar"].HeaderText = "Codigo de barras";
            dgvProdutos.Columns["productStock"].HeaderText = "QTD";
            dgvProdutos.Columns["productPrice"].HeaderText = "Preço";
            dgvProdutos.Columns["productGroup"].HeaderText = "Grupo";


            dgvProdutos.Columns["idProduct"].Visible = false;
            dgvProdutos.Columns["productStatus"].Visible = false;
            dgvProdutos.Columns["productSubgroup"].Visible = false;


            dgvProdutos.Columns["productName"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void mtbNomeProduto_Click(object sender, EventArgs e)
        {

        }

        private void mtbNomeProduto_TextChanged(object sender, EventArgs e)
        {
            if (mtbNomeProduto.Text == "")
            {
                dgvProdutos.DataSource = product;
            }
            else
            {
                FiltrarProdutosPorCampo(mtbNomeProduto.Text);

            }
        }



        private void FiltraPorGrupo()
        {
            List<ProductDTO> list = new List<ProductDTO>();

            list =  _produtoApp.FiltroDeProdutos(product, mgbGrupo.Text);

    //        foreach (var prod in product)
    //        {
    //            bool encontrou =
    //prod.productGroup != null &&
    //mgbGrupo.Text != null &&
    //prod.productGroup.IndexOf(
    //    mgbGrupo.Text,
    //    StringComparison.OrdinalIgnoreCase) >= 0;

    //            if (encontrou)
    //            {
    //                list.Add(prod);
    //            }
    //            else
    //            {
    //                continue;
    //            }
    //        }

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




        private void FiltrarProdutosPorCampo(string valorFiltro)
        {
            List<ProductDTO> filtrados = new List<ProductDTO>();


            string filtro = valorFiltro.ToLower();

            foreach (ProductDTO produto in product)
            {
                string campoComparado = "";
                campoComparado = produto.productName.ToLower();

                if (campoComparado.Contains(filtro))
                {
                    filtrados.Add(produto);
                }
            }

            dgvProdutos.DataSource = filtrados;
        }
    }
}
