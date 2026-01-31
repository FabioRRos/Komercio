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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Product.Produto
{
    public partial class fmAlterarProduto : Form
    {

        private List<ProductDTO> retornoLista = new List<ProductDTO>();




        ///////
        private readonly ProdutoApp _produtoApp;
        private  List<ProductgroupDTO> productGrupo = new List<ProductgroupDTO>();
        private List<ProductSubgroupDTO> productSubGrupo = new List<ProductSubgroupDTO>();


        private ProductDescriptionDTO description = new ProductDescriptionDTO();
       private ProductDTO product = new ProductDTO();
        private ProductDTO productReturnet = new ProductDTO();

        public fmAlterarProduto(ProductDTO productDTO,
            ProdutoApp produtoApp)
        {

            product = productDTO;


            /////////
            _produtoApp = produtoApp;

            InitializeComponent();
        }

        private void fmAlterarProduto_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.KeyPreview = true;
            LoadForms();
            //Carrego a lista de grupo e subgrupo. As listas vão estar carregadas e prontas para utilização.
            LoadListGroupAndSubgroup();
            loaddbListaproduto();


        }

        private void LoadForms()
        {
            if (product!= null && product.productCodbar != null) 
            {
                //Carrega os componentes na tela
                LoadComponentes();
                CarregaDescricao();
                return;
            }
            BlockComponentes();
        }
        // BLOQUEIA COMPONENTES PARA NÃO PERMITIR A EDIÇÃO ENQUANTO NÃO BUSCAR O CÓDIGO DE BARRAS.
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


        // LIBERA PARA EDIÇÃO APÓS LOCALIZAR O CÓDIGO DE BARRAS
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
        // O MATERIAL SKIN É BUGADO. SE NÃO RECARREGAR O HINT ELE FICA TODO TORTO.
        private void CarregaDescricao()
        {
            mtbProductName.Hint = "Descrição do produto";
            mtbProductPrice.Hint = "Preço unitário";
            mtbProductCodeBar.Hint = "Código de barras";
            mcbGroup.Hint = "Grupo do produto";
            mcbSubGroup.Hint = "Subgrupo do produto";
            mtbProductStock.Hint = "Quantidade";

        }
        //REALIZA A BUSCA DO CÓDIGO DE BARRAS. SE LOCALIZADO, CARREGA O FORMS COM OS DADOS.
        public async void BuscaProduto()
        {
            try
            {
                product = await _produtoApp.BuscarProdutoPorCodigoDeBarras(mtbProductCodeBar.Text);
                    

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
        //CARREGA OS COMPONENTES DA TELA COM OS DADOS CARREGADOS PELO BUSCAR PRODUTO
        private void LoadComponentes()
        {

            mtbProductName.Text = product.productName;
            mtbProductPrice.Text = product.productPrice.ToString("C2");
            mtbProductCodeBar.Text = product.productCodbar;
            if (product.productGroup != null)
            {
                mcbGroup.Items.Add(product.productGroup);
                mcbGroup.Text = product.productGroup;
            }
                
            if (product.productSubgroup != null)
            {
                mcbSubGroup.Items.Add(product.productSubgroup);
                mcbSubGroup.Text = product.productSubgroup;
            }
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
                 description = await _produtoApp.Description();
                productGrupo = description.Group;
                productSubGrupo = description.Subgroup;

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
        // valida o produto antes de tentar enviar para alteração.
        private void mbtSaveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                productReturnet = productReturnet.ValidaProduto(mtbProductName.Text,
                    mtbProductPrice.Text,
                    mtbProductCodeBar.Text,
                    mcbGroup.Text,
                    mcbSubGroup.Text,
                    mtbProductStock.Text,
                    string.Empty // <= ARRUMAR ESSE AQUI
                    );

                productReturnet.idProduct = product.idProduct;
            }
            catch (Exception ex)
            {



                MessageBox.Show($"{ex.Message}", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (productReturnet.productStatus = msProductStatus.Checked)
            {
                productReturnet.productStatus = true;
            }
            else
            {
                productReturnet.productStatus = false;
            }

            try
            {
                // criei uma função para ela poder ser assincrona.
               
                CreateProductAsync();
            }

            catch
            {
                return;
            }


        }
        //Aqui salva a alteração do menor.
        private async void CreateProductAsync()
        {
            if (productReturnet.productGroup == "") productReturnet.productGroup = product.productGroup;
            if (productReturnet.productSubgroup =="") productReturnet.productSubgroup = product.productSubgroup;


            var returnSatus = await _produtoApp.AlterarProduto(productReturnet);
            if (!returnSatus)
            {
                MessageBox.Show("Erro ao atualizar produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Produto atualizado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            product = new ProductDTO();
            this.Controls.Clear();
            this.InitializeComponent();
            this.fmAlterarProduto_Load(null, null);
        }

        private void mcbGroup_MouseClick(object sender, MouseEventArgs e)
        {
            LoadListGroupAndSubgroup(); 
        }



        //bloqueia o campo para só aceitar numeros.
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
        //formata em tempo real o numero.
        private void mtbProductPrice_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbProductPrice.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbProductPrice.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbProductPrice.SelectionStart = mtbProductPrice.Text.Length;


        }

        private void mepBuscaDescricao_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            product = new ProductDTO();
            Clear();
            BlockComponentes();
            DataGridViewRow linha = dgwListaProdutos.Rows[e.RowIndex];
            string codigoBarras = linha.Cells["productCodbar"].Value.ToString();
            mtbProductCodeBar.Text = codigoBarras;

            mepBuscaDescricao.Collapse = true;
            mtbProductCodeBar.Hint = "Código de barras";        
            
           
        }


        private void ConfigurarColunasProdutos()
        {
            dgwListaProdutos.RowHeadersVisible = false;

            dgwListaProdutos.Columns["productName"].HeaderText = "Produto";
            dgwListaProdutos.Columns["productName"].SortMode =
        DataGridViewColumnSortMode.Programmatic;

            dgwListaProdutos.Columns["idProduct"].Visible = false;
            dgwListaProdutos.Columns["productPrice"].Visible = false;
            dgwListaProdutos.Columns["productCodbar"].Visible = false;
            dgwListaProdutos.Columns["productGroup"].Visible = false;
            dgwListaProdutos.Columns["productSubgroup"].Visible = false;
            dgwListaProdutos.Columns["productStock"].Visible = false;
            dgwListaProdutos.Columns["productStatus"].Visible = false;
            dgwListaProdutos.Columns["ProductPrchasePrice"].Visible = false;



            dgwListaProdutos.BackgroundColor = Color.White;
            dgwListaProdutos.BorderStyle = BorderStyle.None;


            dgwListaProdutos.Columns["productName"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)DataGridViewAutoSizeColumnsMode.AllCells;

            dgwListaProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgwListaProdutos.Sort(dgwListaProdutos.Columns["productName"], ListSortDirection.Ascending);



        }

        private async Task loaddbListaproduto()
        {
            // Aqui estou carregando a lista dentro do service.

            (retornoLista,_) = await _produtoApp.BuscaListaDeProdutoEGrupo();

;
            dgwListaProdutos.DataSource = retornoLista;

            ConfigurarColunasProdutos();
        }

        private void mtbBusca_TextChanged(object sender, EventArgs e)
        {
            FiltrarProdutoPorNome(mtbBusca.Text);
        }

        private void FiltrarProdutoPorNome(string texto)
        {

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgwListaProdutos.DataSource = retornoLista;
                return;
            }

            List<ProductDTO> filtrada = new List<ProductDTO>();

            foreach (ProductDTO p in retornoLista)
            {
                if (p.productName
                    .IndexOf(texto, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    filtrada.Add(p);
                }
            }

            dgwListaProdutos.DataSource = filtrada;
        }

        private void Clear()
        {
            mtbProductName.Text = string.Empty;
            mtbProductPrice.Text = string.Empty;
            mtbProductCodeBar.Text = string.Empty;
            mcbGroup.Text = string.Empty;
            mcbSubGroup.Text = string.Empty;
            mtbProductStock.Text = string.Empty;
            msProductStatus.Checked = product.productStatus;
        }
    }
}
