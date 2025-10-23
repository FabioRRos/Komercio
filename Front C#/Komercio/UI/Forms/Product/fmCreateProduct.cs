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

        private void fmCreateProduct_Load(object sender, EventArgs e)
        {

        }

     

       
        private void mtbProductPrice_Leave(object sender, EventArgs e)
        {
            if (mtbProductPrice.Text == "")
            {
                               return;
            }

            // Vou tratar erros de entrada não numérica.
            try
            {

                mtbProductPrice.Text = string.Format("{0:N2}", Convert.ToDecimal(mtbProductPrice.Text));
            }
            catch
            {
                MessageBox.Show("Preço inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbProductPrice.Text = "";
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
            mtbProductName.Text = "";
            mtbProductPrice.Text = "";
            mtbProductCodeBar.Text = "";
            mtbGrupo.Text = "";
            mtbSubGrupo.Text = "";
            mtbProductStock.Text = "";
            msProductStatus.Checked = true;
        }
    }
}
