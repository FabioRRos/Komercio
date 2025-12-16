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
        private readonly ProductDescriptionService _productDescriptionService;
        private readonly ProductSubgroupService _productSubgroupService;
        private readonly ProductGroupService _productGroupService;


        private ProductDescriptionDTO description = new ProductDescriptionDTO();

        public fmCreateProduct(ProductService productService, ProductDescriptionService productAndGroupAndSubgroup, ProductSubgroupService productSubgroupService, ProductGroupService productGroupService)
        {
            _productSubgroupService = productSubgroupService;
            _productGroupService = productGroupService;
            _productService = productService;
            _productDescriptionService = productAndGroupAndSubgroup;
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
            mcbGroup.Enabled = false;
            mcbSubGroup.Enabled = false;
            mtbProductStock.Enabled = false;
            msProductStatus.Enabled = false;
            mbtSaveProduct.Enabled = false;

            mtbProductName.Text= string.Empty;
            mtbProductPrice.Text = string.Empty;
            mtbProductCodeBar.Text = string.Empty;
            mtbProductStock.Text = string.Empty;


            //Habilitado apenas o botão para novo produto.

            mbtNewProduct.Enabled = true;
        }


        public void ComponentsNewProduct()
        {
            mtbProductName.Enabled = true;
            mtbProductPrice.Enabled = true;
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



        private async void CreateProductAsync(ProductDTO product)
        {

            var returnSatus = await _productService.CreateProductAsync(product);

        
            if (!returnSatus)
            {
                MessageBox.Show("Erro ao criar produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void mbtSaveProduct_Click(object sender, EventArgs e)
        {


            ProductDTO product = new ProductDTO();

           product.productName = mtbProductName.Text;
            try
            { 
                product.productPrice = float.Parse(mtbProductPrice.Text.Replace("R$","")); 
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
            product.productGroup = mcbGroup.SelectedItem.ToString();
            product.productSubgroup = mcbSubGroup.SelectedItem.ToString();

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
               
                
            }

            catch
            {
                return;
            }

            //  this.DialogResult = DialogResult.OK;
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
            mcbSubGroup.SelectedIndex = 0;
            mtbProductStock.Text = "";
            msProductStatus.Checked = true;
        }

        private void mtbProductPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string texto = mtbProductPrice.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

                if (texto.Length == 0)
                    texto = "0";

                decimal valor = Convert.ToDecimal(texto) / 100;
                mtbProductPrice.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
                mtbProductPrice.SelectionStart = mtbProductPrice.Text.Length;
            }
            catch {
                MessageBox.Show("Formato de entrada invalido!!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbProductPrice.Text = string.Empty;
                return;
            };
        }

        private void fmCreateProduct_Load(object sender, EventArgs e)
        {
            LoadListGroupAndSubgroup();
        }
        private void SubGrupo()
        {
            fmrCadastroSubGrupoProduto cadastrarSubGrupo = new fmrCadastroSubGrupoProduto(_productSubgroupService, _productGroupService);
            cadastrarSubGrupo.ShowDialog();
        }


        public async  void LoadListGroupAndSubgroup()
        {
            try
            {
                var response = await _productDescriptionService.GetProductDescriptionAsync();

            description.Product = response.Product;
            description.Group = response.Group.OrderBy(p => p.ProductgroupName).ToList() ;
            description.Subgroup = response.Subgroup.OrderBy(p => p.ProductsubgroupName).ToList() ;

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
    }
}
