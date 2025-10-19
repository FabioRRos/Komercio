using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Komercio.UI.Forms.Product
{
    public partial class fmCreateProduct : Form
    {
        private readonly ProductService _productService;
    
        public fmCreateProduct(ProductService productService)
        {
            _productService = productService;
            InitializeComponent();
            ComponentsInitialize();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            _productService = productService;
        }

        public void ComponentsInitialize()
        {
            mtbProductName.Enabled = false;
            mtbProductPrice.Enabled = false;
            mtbProductCodeBar.Enabled = false;
            mtbGrupo.Enabled = false;
            mtbSubGrupo.Enabled = false;
            mtbProductStock.Enabled = false;
            msProductStatus.Enabled = false;
            mbtSaveProduct.Enabled = false;

            //Habilitado apenas o botão para novo produto.

            mbtNewProduct.Enabled = true;
        }


        public void ComponentsNewProduct()
        {
            mtbProductName.Enabled = true;
            mtbProductPrice.Enabled = true;
            mtbProductCodeBar.Enabled = true;
            mtbGrupo.Enabled = true;
            mtbSubGrupo.Enabled = true;
            mtbProductStock.Enabled = true;
            msProductStatus.Enabled = true;
            mbtSaveProduct.Enabled = true;

            //Habilitado apenas o botão para novo produto.

            mbtNewProduct.Enabled = false;
        }


        private void mtbGrupo_Click(object sender, EventArgs e)
        {

        }

        private void mtbSubGrupo_Click(object sender, EventArgs e)
        {

        }

        private void mtbProductStock_Click(object sender, EventArgs e)
        {

        }

        private void fmCreateProduct_Load(object sender, EventArgs e)
        {

        }

        private void mtbProductName_Enter(object sender, EventArgs e)
        {
            if (mtbProductName.Text == "Nome")
            {
                mtbProductName.Text = "";
            }
        }

        private void mtbProductName_Leave(object sender, EventArgs e)
        {
            if (mtbProductName.Text == "")
            {
                mtbProductName.Text = "Nome";
            }
        }

        private void mtbProductPrice_Enter(object sender, EventArgs e)
        {
            if (mtbProductPrice.Text == "Preço")
            {
                mtbProductPrice.Text = "";
            }
        }

        private void mtbProductPrice_Leave(object sender, EventArgs e)
        {
            if (mtbProductPrice.Text == "")
            {
                mtbProductPrice.Text = "Preço";
            }
            // Vou tratar erros de entrada não numérica.
            try
            {

                mtbProductPrice.Text = string.Format("{0:N2}", Convert.ToDecimal(mtbProductPrice.Text));
            }
            catch
            {
                MessageBox.Show("Preço inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbProductPrice.Text = "Preço";
            }
        }

        private void mtbProductCodeBar_Enter(object sender, EventArgs e)
        {
            if (mtbProductCodeBar.Text == "Código de barras")
            {
                mtbProductCodeBar.Text = "";
            }
        }

        private void mtbProductCodeBar_Leave(object sender, EventArgs e)
        {
            if (mtbProductCodeBar.Text == "")
            {
                mtbProductCodeBar.Text = "Código de barras";
            }
        }

        private void mtbGrupo_Enter(object sender, EventArgs e)
        {
            if (mtbGrupo.Text == "Grupo")
            {
                mtbGrupo.Text = "";
            }
        }

        private void mtbGrupo_Leave(object sender, EventArgs e)
        {
            if (mtbGrupo.Text == "")
            {
                mtbGrupo.Text = "Grupo";
            }
        }

        private void mtbSubGrupo_Enter(object sender, EventArgs e)
        {
            if (mtbSubGrupo.Text == "Subgrupo")
            {
                mtbSubGrupo.Text = "";
            }
        }

        private void mtbSubGrupo_Leave(object sender, EventArgs e)
        {
            if (mtbSubGrupo.Text == "")
            {
                mtbSubGrupo.Text = "Subgrupo";
            }
        }

        private void mtbProductStock_Enter(object sender, EventArgs e)
        {
            if (mtbProductStock.Text == "Quantidade")
            {
                mtbProductStock.Text = "";
            }
        }

        private void mtbProductStock_Leave(object sender, EventArgs e)
        {
            if (mtbProductStock.Text == "")
            {
                mtbProductStock.Text = "Quantidade";
            }
        }

        private void mbtNewProduct_Click(object sender, EventArgs e)
        {
            ComponentsNewProduct();
        }



        private async void CreateProductAsync(ProductDTO product)
        {

            var returnSatus = await _productService.CreateProductAsync(product);
 
            if (returnSatus)
            {
                MessageBox.Show("Produto criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

               // return true;
            }
            else
            {
                MessageBox.Show("Erro ao criar produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return false;
            }

        }

        private void mbtSaveProduct_Click(object sender, EventArgs e)
        {


            ProductDTO product = new ProductDTO();

           product.productName = mtbProductName.Text;
            try
            { 
                product.productPrice = float.Parse(mtbProductPrice.Text); 
                if (product.productPrice < 0) 
                {
                    MessageBox.Show("Preço inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Preço inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            product.productCodbar = mtbProductCodeBar.Text;
            product.productGroup = mtbGrupo.Text;
            product.productSubgroup = mtbSubGrupo.Text;

            try
            {
                product.productStock = int.Parse(mtbProductStock.Text);

                if (product.productStock < 0)
                {
                    MessageBox.Show("Quantidade inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
                        {
                MessageBox.Show("Quantidade inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (product.productStatus = msProductStatus.Checked)
            {
                product.productStatus = true;
            }
            else
            {
                product.productStatus = false;
            }


            try
            {
                CreateProductAsync(product);
                ComponentsInitialize();
                ComponentsClear();
            }

            catch
            {
                return;
            }

            
        }

        private void ComponentsClear()
        {
            mtbProductName.Text = "Nome";
            mtbProductPrice.Text = "Preço";
            mtbProductCodeBar.Text = "Código de barras";
            mtbGrupo.Text = "Grupo";
            mtbSubGrupo.Text = "Subgrupo";
            mtbProductStock.Text = "Quantidade";
            msProductStatus.Checked = true;
        }
    }
}
