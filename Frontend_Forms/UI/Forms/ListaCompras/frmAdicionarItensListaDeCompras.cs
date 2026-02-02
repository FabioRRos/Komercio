using Komercio.ApplicationLayer;
using Komercio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.ListaCompras
{
    public partial class frmAdicionarItensListaDeCompras : Form
    {
        //injeção
        private readonly ListaComprasApp _listaComprasApp;


        // O cara que preenche meu grit (GET ITENS DA LISTA)
        private ServiceResponse<List<ItemListaCompraDTO>> itemListaCompraList;
        // O CARA QUE TEM TODAS AS LISTAS (GET LISTAS)
        private ServiceResponse<List<ListaComprasDTO>> _todasAsListasDeCompras;


        ///lista de produtos para o microforms
        private List<ProductDTO> _listaDeProdutos;

        //id da lista selecionada

        int idListaSelecionada = 0;


        public frmAdicionarItensListaDeCompras(ListaComprasApp listaComprasApp)
        {
            _listaComprasApp = listaComprasApp;
            InitializeComponent();
        }

        private async void frmAdicionarItensListaDeCompras_Load(object sender, EventArgs e)
        {
            BuscaListaDeCompra();
            CustomizacaoGrids();
        }


        private async void BuscaListaDeCompra()
        {
            _todasAsListasDeCompras = await _listaComprasApp.BuscarListasDeCompra();
            PreencheOComboBox();
        }

        private async void BuscarProdutos()
        {
            _listaDeProdutos = await _listaComprasApp.BuscarProdutos();
            LoadGridProduct();
        }

        private void PreencheOComboBox()
        {
            mcbListaCompra.Items.Clear();

          

            foreach (var lista in _todasAsListasDeCompras.Dados)
            {
                mcbListaCompra.Items.Add(lista.IdListaCompra + "-" + lista.NomeDaLista);
            }
        }



        private async void BuscaListaDeProdutos(int id)
        {
            itemListaCompraList = await _listaComprasApp.BuscarItensListaDeComprasById(id);


            if (itemListaCompraList.Dados.Count >0)
            {
                mtbRemover.Enabled = true;
            }
            
            LoadGrid();
        }

        private void LoadGridProduct()
        {
            dgProdutos.DataSource = string.Empty;
            dgProdutos.DataSource = _listaDeProdutos;

            dgProdutos.Columns["idProduct"].Visible = false;
            dgProdutos.Columns["productName"].HeaderText = "Produto";
            dgProdutos.Columns["productPrice"].Visible = false;
            dgProdutos.Columns["productCodbar"].Visible = false;
            dgProdutos.Columns["productGroup"].Visible = false;
            dgProdutos.Columns["productSubgroup"].Visible = false;
            dgProdutos.Columns["productStock"].Visible = false;
            dgProdutos.Columns["productStatus"].Visible = false;
            dgProdutos.Columns["ProductPrchasePrice"].Visible = false;

            dgProdutos.RowHeadersVisible = false;
            dgProdutos.BackgroundColor = Color.White;
            dgProdutos.BorderStyle = BorderStyle.None;
            dgProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgProdutos.Columns["productName"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void LoadGrid()
        {
            dgvItens.DataSource = string.Empty;

            if (itemListaCompraList.Dados.Count <= 0) return;
            dgvItens.DataSource = itemListaCompraList.Dados;
            //descrição das colunas

            dgvItens.Columns["DescricaoProduto"].HeaderText = "Produto";
            dgvItens.Columns["CodBar"].HeaderText = "Código de barras";
            dgvItens.Columns["Quantidade"].HeaderText = "Qtd compra";
            dgvItens.Columns["Obs"].HeaderText = "Comentários";


            //Remover colunas desnecessarias
            dgvItens.Columns["IdItemCompra"].Visible = false;
            dgvItens.Columns["IdLista"].Visible = false;
            dgvItens.Columns["StatusItem"].Visible = false;

            dgvItens.Columns["DescricaoProduto"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)DataGridViewAutoSizeColumnsMode.AllCells;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void CustomizacaoGrids()
        {
            // customização do grid            
            dgvItens.RowHeadersVisible = false;
            dgvItens.BackgroundColor = Color.White;
            dgvItens.BorderStyle = BorderStyle.None;


            dgProdutos.RowHeadersVisible = false;
            dgProdutos.BackgroundColor = Color.White;
            dgProdutos.BorderStyle = BorderStyle.None;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var novaLista = new frmNewListaDeCompras(_listaComprasApp);

            DialogResult statusShowDialog = novaLista.ShowDialog();

            if (statusShowDialog == DialogResult.OK)
            {
                BuscaListaDeCompra();
            }


        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            BuscaListaDeProdutos(SelecionaIdDaLista());
            BuscarProdutos();
            mbtNovoProd.Enabled = true;
            mtbBuscarProduto.Enabled = true;
            dgProdutos.Enabled = true;
            btnCarregaLista.Enabled = false;
            mcbListaCompra.Enabled= false;
            mtbNovaLista.Enabled= false;


        }

        private void LiberaComponentes()
        {
            mtbProduto.Enabled = true;
            mtbObs.Enabled = true;
            mtbQtd.Enabled = true;
        }
        private void BloquearComponentes()
        {
            mtbProduto.Enabled = false;
            mtbObs.Enabled = false;
            mtbQtd.Enabled = false;
        }
        private void ClearComponentes()
        {
            mtbProduto.Text = string.Empty;
            mtbObs.Text = string.Empty;
            mtbQtd.Text = string.Empty;
            mtbBuscarProduto.Text = string.Empty;
           
        }

        private int SelecionaIdDaLista()
        {
            var texto = mcbListaCompra.Text.Split('-');

            int id = int.Parse(texto[0]);

            idListaSelecionada = id;

            return id;
        }

        private void gblistaCompras_Enter(object sender, EventArgs e)
        {

        }

        private void mtbBuscarProd_Click(object sender, EventArgs e)
        {

        }

        private void mcbListaCompra_TabIndexChanged(object sender, EventArgs e)
        {

        }
        private int _indexAnterior = -1;
        private bool _alterandoProgramaticamente = false;
        private void mcbListaCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCarregaLista.Enabled = true;
        }

        private void mtbProduto_TextChanged(object sender, EventArgs e)
        {
            if (mtbProduto.Text == "")
            {
                btnAddLista.Enabled = false;
              
            }
            else
            {
                 btnAddLista.Enabled = true;
            }
        }

        private void mbtNovoProd_Click(object sender, EventArgs e)
        {
            LiberaComponentes();
        }

        private void btnAddLista_Click(object sender, EventArgs e)
        {
            var item = PegaCamposEAdiciona();

            if (item == null)
            {
                return;
            }
            itemListaCompraList.Dados.Add(item);
            LoadGrid();
            mbtSalvar.Enabled = true;
            mtbRemover.Enabled = true;
            mtbCodBar.Text = string.Empty;



        }

        private ItemListaCompraDTO PegaCamposEAdiciona()
        {
            var item = new ItemListaCompraDTO();
            try
            {
                item.DescricaoProduto = mtbProduto.Text;
                item.Quantidade = int.Parse(mtbQtd.Text);  
                item.Obs = mtbObs.Text;
                item.CodBar = mtbCodBar.Text;
                BloquearComponentes();
                ClearComponentes();
                return item;
            }
            catch
            {
                MessageBox.Show("Favor verificar os dados digitados!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
            }
        }

        private void mtbBuscarProduto_TextChanged(object sender, EventArgs e)
        {
            FiltrarProdutoPorNome(mtbBuscarProduto.Text);
        }
        private void FiltrarProdutoPorNome(string texto)
        {

            if (string.IsNullOrWhiteSpace(texto))
            {
                dgProdutos.DataSource = _listaDeProdutos;
                return;
            }

            List<ProductDTO> filtrada = new List<ProductDTO>();

            foreach (ProductDTO p in _listaDeProdutos)
            {
                if (p.productName
                    .IndexOf(texto, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    filtrada.Add(p);
                }
            }

            dgProdutos.DataSource = filtrada;
            
        }

        private void dgProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var protudoSelecionado = new ProductDTO();
            if (e.RowIndex < 0) return; 

            var produtoSelecionado =
                (ProductDTO)dgProdutos.Rows[e.RowIndex].DataBoundItem;


            mtbProduto.Text = produtoSelecionado.productName;
            mtbCodBar.Text = produtoSelecionado.productCodbar;
            mtbQtd.Enabled = true;
            mtbObs.Enabled = true;
        }


        private async void mbtSalvar_Click(object sender, EventArgs e)
        {
            var retorno = await _listaComprasApp.SalvarAlteracaoNaListaDeCompraApp(itemListaCompraList.Dados, idListaSelecionada);

            if (retorno == true)
            {
                MessageBox.Show("Lista atualizada com sucesso!","sucesso",MessageBoxButtons.OK,MessageBoxIcon.None);
            ReloadForm();
                return;
            }

            MessageBox.Show("Erro ao atualizar a lista!", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

        }
        private void ReloadForm()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.frmAdicionarItensListaDeCompras_Load(null, null);
        }

        private void mtbRemover_Click(object sender, EventArgs e)
        {

            RemoverItemDaLista();


            if (itemListaCompraList.Dados.Count > 0)
            {
               
                mtbRemover.Enabled = true;
                mbtSalvar.Enabled = true;
            }
            else { 
                mbtSalvar.Enabled = false;
                mtbRemover.Enabled =false;
            }
        }



        private void RemoverItemDaLista()
        {
            if (dgvItens.CurrentRow == null) return;

            int indice = dgvItens.CurrentRow.Index;

            itemListaCompraList.Dados.RemoveAt(indice);
            LoadGrid();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem certeza que deseja cancelar? Todas as alterações serão perdidas!",
                "Atenção",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (resposta == DialogResult.Yes)
            {
                ReloadForm();
            }
            else
            {
                return;
            }
        }


    }
}
