using Komercio.ApplicationLayer;
using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Komercio.UI.Forms.Product
{
    public partial class btnImportStock : Form
    {
        private string _caminhoArquivo;
        private readonly ProdutoApp _produtoApp;
        internal ProductDTO _productDTO = new ProductDTO();

        public btnImportStock(ProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;


            InitializeComponent();
        }
        // Busca o diretório e salva em uma variavel.
        // Aceita CSV apenas.
        private void mtbDirectorySearcher_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();

            abrir.Filter = "Arquivos CSV (*.CSV)|*.CSV";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                _caminhoArquivo = abrir.FileName;
            }


            LoadItens(_caminhoArquivo);

            materialButton1.Enabled = true;
            mtbDirectorySearcher.Enabled = false;

        }

        public List<ProductDTO> ProductList = new List<ProductDTO>();
        public int qtdError = 0;


        // Busca o arquivo no diretório importado e retorna a lista de produtos que deu bom + a quantidade que deu ruim
        public void LoadItens(string caminhoArquivo)
        {

            if (caminhoArquivo == null)
            {
                return;
            }
            (ProductList, qtdError) = _produtoApp.BuscarEAbrirArquivo(caminhoArquivo);

            if (qtdError > 0)
            {
                MessageBox.Show(qtdError + "itens com erro de formatação não puderam ser importados", "ERRO DE IMPORTAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgwImportList.DataSource = ProductList;
            VisualizeDG();
        }
        //firnata o DG
        private void VisualizeDG()
        {
            dgwImportList.Columns["idproduct"].Visible = false;
            dgwImportList.Columns["productName"].HeaderText = "Descrição";
            dgwImportList.Columns["productPrice"].HeaderText = "Preço Unit.";
            dgwImportList.Columns["productCodbar"].HeaderText = "Cód. Barras";
            dgwImportList.Columns["productGroup"].HeaderText = "Grupo";
            dgwImportList.Columns["productSubgroup"].HeaderText = "SubGrupo";
            dgwImportList.Columns["productSubgroup"].HeaderText = "SubGrupo";
            dgwImportList.Columns["productStatus"].HeaderText = "Status";


            dgwImportList.BackgroundColor = Color.White;
            dgwImportList.BorderStyle = BorderStyle.None;
            dgwImportList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void materialButton1_Click(object sender, EventArgs e)
        {
            CadastrarList();
            materialButton1.Enabled = false;
            mtbDirectorySearcher.Enabled = true;
            dgwImportList.DataSource = null;

            ReloadForm();
        }
        private void ReloadForm()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.btnImportStock_Load(null, null);
        }


        private async Task CadastrarList()
        {
            mpbload.Minimum = 0;
            mpbload.Maximum = ProductList.Count;
            mpbload.Value = 0;

            var progress = new Progress<int>(valor =>
            {
                if (valor <= mpbload.Maximum)
                    mpbload.Value = valor;
            });

            var error = await _produtoApp.CadastrarProdutosEmLotePB(
                ProductList,
                progress
            );

            if (error == 0)
            {
                MessageBox.Show(
                    "Todos os produtos importados com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    $"{error} produtos tiveram erro de importação. Favor verificar a lista e tentar novamente.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnImportStock_Load(object sender, EventArgs e)
        {

        }
    }
}