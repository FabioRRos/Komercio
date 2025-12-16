using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Product.Produto
{
    public partial class fmAlterarProduto : Form
    {
        private readonly ProductService _productService;
        private readonly ProductDescriptionService _productDescriptionService;
        private readonly ProductSubgroupService _productSubgroupService;
        private readonly ProductGroupService _productGroupService;


        private ProductDescriptionDTO description = new ProductDescriptionDTO();
        private ProductDTO product = new ProductDTO();
        public fmAlterarProduto(ProductService productService, ProductDescriptionService productAndGroupAndSubgroup, ProductSubgroupService productSubgroupService, ProductGroupService productGroupService, ProductDTO productDTO )
        {
            _productSubgroupService = productSubgroupService;
            _productGroupService = productGroupService;
            _productService = productService;
            _productDescriptionService = productAndGroupAndSubgroup;
            _productService = productService;
            product = productDTO;

            InitializeComponent();
        }

        private void fmAlterarProduto_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.KeyPreview = true;
            LoadForms();


        }

        private void LoadForms()
        {
            if (product != null) 
            {
                LoadComponentes();
                CarregaDescricao();
                return;
            }

            BlockComponentes();
        }

        private void BlockComponentes()
        {
            mtbProductName.Enabled = false;
            mtbProductPrice.Enabled = false;
            mtbProductCodeBar.ReadOnly = false;
            mcbGroup.Enabled = false;
            mcbSubGroup.Enabled = false;
            msProductStatus.Enabled = false;
            mbtSaveProduct.Enabled = false;

        }



        private void LibereComponentes()
        {
            mtbProductName.Enabled = true;
            mtbProductPrice.Enabled = true;
            mtbProductCodeBar.ReadOnly = true;
            mcbGroup.Enabled = true;
            mcbSubGroup.Enabled = true;
            msProductStatus.Enabled = true;
            mbtSaveProduct.Enabled = true;
        }

        private void CarregaDescricao()
        {
            mtbProductName.Hint = "Descrição do produto";
            mtbProductPrice.Hint = "Preço unitário";
            mtbProductCodeBar.Hint = "Código de barras";
            mcbGroup.Hint = "Grupo do produto";
            mcbSubGroup.Hint = "Subgrupo do produto";
            mtbProductStock.Hint = "Quantidade";

        }

        public async void BuscaProduto()
        {
            try
            {
                product = await _productService.GetProductByCodbad(mtbProductCodeBar.Text);

                if (product.idProduct == 0)
                {
                    MessageBox.Show("Código de barras não localizado. Tente novamente!", "Não localizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }

            catch
            {
                MessageBox.Show("Código de barras não localizado. Tente novamente!", "Não localizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LoadForms();
        }

        private void LoadComponentes()
        {
            mtbProductName.Text = product.productName;
            mtbProductPrice.Text = product.productPrice.ToString("C2");
            mtbProductCodeBar.Text = product.productCodbar;
            mcbGroup.Items.Add(product.productGroup);
            mcbSubGroup.Items.Add(product.productSubgroup);
            mtbProductStock.Text = product.productStock.ToString();
            msProductStatus.Checked = product.productStatus;

            LibereComponentes();
        }

        // CARREGA OS ITENS DA LISTA DE GRUPO. SÓ DEVE SER ALTERADO QUANDO FOI SOLICITADO A ATLERAÇÂO PELO EVENTO
        public async void LoadListGroupAndSubgroup()
        {

            mcbSubGroup.Items.Clear();
            try
            {
                var response = await _productDescriptionService.GetProductDescriptionAsync();

                description.Product = response.Product;
                description.Group = response.Group.OrderBy(p => p.ProductgroupName).ToList();
                description.Subgroup = response.Subgroup.OrderBy(p => p.ProductsubgroupName).ToList();

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
        //SÓ VAI ALTERAR QUANDO O GRUPO FOR ALTERADO!!!!
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

            foreach (ProductSubgroupDTO subgroup in description.Subgroup)
            {
                if (subgroup.Product_group_id == id)
                {
                    mcbSubGroup.Items.Add(subgroup.ProductsubgroupName);

                }
            }
        }

        private void mbtSaveProduct_Click(object sender, EventArgs e)
        {

           

            product.productName = mtbProductName.Text;
            try
            {
                product.productPrice = float.Parse(mtbProductPrice.Text.Replace("R$", ""));
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
            try
            {
                var grupo = mcbGroup.SelectedItem.ToString();
                 product.productGroup = grupo;
            }
            catch
            {
                
            }

            try
            {
                var subgrupo = mcbSubGroup.SelectedItem.ToString();
                product.productSubgroup = subgrupo;
            }
            catch
            {

            }

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


        }

        private async void CreateProductAsync(ProductDTO product)
        {

            var returnSatus = await _productService.PutProductAtt(product);


            if (!returnSatus)
            {
                MessageBox.Show("Erro ao atualizar produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Produto atualizado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }


        }

        private void mcbGroup_MouseClick(object sender, MouseEventArgs e)
        {
            LoadListGroupAndSubgroup(); 
        }




        private async void fmAlterarProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (mtbProductCodeBar.Text != "")
                {
                    BuscaProduto();
                    
                }
                else
                {
                    MessageBox.Show("Digite um código de barras","ATENÇÃO!!!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
               
            }
        }

        private void mtbProductPrice_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbProductPrice.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbProductPrice.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbProductPrice.SelectionStart = mtbProductPrice.Text.Length;

        }
    }
}
