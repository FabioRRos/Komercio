using Komercio.ApplicationLayer;
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
        private readonly ProdutoApp _produtoApp;


        private ProductDescriptionDTO description = new ProductDescriptionDTO();

        public fmCreateProduct(ProdutoApp produtoApp)
        {


            _produtoApp = produtoApp;


            InitializeComponent();
            ComponentsInitialize();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        public void ComponentsInitialize()
        {
            mtbProductName.Enabled = false;
            mtbProductPrice.Enabled = false;
            mtbProductCodeBar.Enabled = false;
            mcbGroup.Enabled = false;
            mcbSubGroup.Enabled = false;
            mtbProductStock.Enabled = false;
            msProductStatus.Enabled = false;
            mbtSaveProduct.Enabled = false;
            mtbPrecoCompra.Enabled = false;

            mtbProductName.Text= string.Empty;
            mtbProductPrice.Text = string.Empty;
            mtbPrecoCompra.Text = string.Empty;
            mtbProductCodeBar.Text = string.Empty;
            mtbProductStock.Text = string.Empty;


            //Habilitado apenas o botão para novo produto.

            mbtNewProduct.Enabled = true;
        }


        public void ComponentsNewProduct()
        {
            mtbProductName.Enabled = true;
            mtbProductPrice.Enabled = true;
            mtbPrecoCompra.Enabled = true;
            mtbProductCodeBar.Enabled = true;
            mcbGroup.Enabled = true;
            mcbSubGroup.Enabled = true;
            mtbProductStock.Enabled = true;
            msProductStatus.Enabled = true;
            mbtSaveProduct.Enabled = true;

            //Habilitado apenas o botão para novo produto.

            mbtNewProduct.Enabled = false;
        }

        private void mbtNewProduct_Click(object sender, EventArgs e)
        {
            ComponentsNewProduct();
        }


        //Chama o app layer para fazer a regra do negócio.
        private async void CreateProductAsync(ProductDTO product)
        {

            var result = await _produtoApp.CadastrarProduto(product);

            if (!result)
            {
                MessageBox.Show("Erro ao criar produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void mbtSaveProduct_Click(object sender, EventArgs e)
        {

            //Joga para a entidade se resolver com a validação.

           // if (mtbPrecoCompra.Text == "") mtbPrecoCompra.Text = "0";
            float precoCompra = 0;

            try
            {
                precoCompra = float.Parse(mtbPrecoCompra.Text);
            }
            catch
            {
                precoCompra = 0;
            }

            ProductDTO product = new ProductDTO();
            try
            {
                product = product.ValidaProduto(mtbProductName.Text,
                    mtbProductPrice.Text,
                    mtbProductCodeBar.Text,
                    mcbGroup.Text,
                    mcbSubGroup.Text,
                    mtbProductStock.Text,
                    precoCompra
                    );
            }
            catch (Exception ex)
            {



                    MessageBox.Show($"{ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //menos esse cara aqui kkkk
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
            }

            catch
            {
                return;
            }
            //zera os componentes
            ComponentsInitialize();
            ComponentsClear();
            mcbGroup.SelectedItem = null;
            mcbGroup.Text = string.Empty;
            mcbSubGroup.SelectedItem = null;
            mcbSubGroup.Text = string.Empty;


        }

        private void ComponentsClear()
        {
            mtbProductName.Text = "";
            mtbProductPrice.Text = "";
            mtbProductCodeBar.Text = "";
            mcbGroup.SelectedIndex = 0;
            mtbProductStock.Text = "";
            msProductStatus.Checked = true;
        }

        private void mtbProductPrice_TextChanged(object sender, EventArgs e)
        {
            //formata o texto da entrada  de valores
            string texto = mtbProductPrice.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbProductPrice.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbProductPrice.SelectionStart = mtbProductPrice.Text.Length;

        }

        private void fmCreateProduct_Load(object sender, EventArgs e)
        {
            LoadListGroupAndSubgroup();
        }
        public async  void LoadListGroupAndSubgroup()
        {
            try
            {
                description = await _produtoApp.Description();

                foreach (ProductgroupDTO group in description.Group)
                {
                        mcbGroup.Items.Add(group.ProductgroupName);
                }
            }
            catch
            {
                MessageBox.Show("Erro ao baixar os grupos e subgrupos");
            }
        }

        private void mcbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            // descobrir o id
            foreach (ProductgroupDTO group in description.Group)
            {
                if (mcbGroup.Text == group.ProductgroupName)
                {
                    id = group.ProductgroupId;
                    break;
                }
            }

            if (id == 0) return;

            mcbSubGroup.Items.Clear();
            foreach (ProductSubgroupDTO subgroup in description.Subgroup)
            {
                if (subgroup.Product_group_id == id)
                {
                    mcbSubGroup.Items.Add(subgroup.ProductsubgroupName);

                }
            }
        }

        private void mtbProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbPrecoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbPrecoCompra_TextChanged(object sender, EventArgs e)
        {
            //formata o texto da entrada  de valores
            string texto = mtbPrecoCompra.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbPrecoCompra.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbPrecoCompra.SelectionStart = mtbPrecoCompra.Text.Length;
        }
    }
}
