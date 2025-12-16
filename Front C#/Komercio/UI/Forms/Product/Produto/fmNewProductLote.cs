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

namespace Komercio.UI.Forms.Product
{
    public partial class btnImportStock : Form
    {
        private string _caminhoArquivo;
        private readonly ProductService _productService;
        internal ProductDTO _productDTO = new ProductDTO();

        public btnImportStock(ProductService productService)
        {
            _productService = productService;
            InitializeComponent();
        }

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
        public List<string> ErrorProductList = new List<string>();




        public void LoadItens(string caminhoArquivo)
        {

            if (caminhoArquivo == null)
            {
                return;
            }

          (ProductList,ErrorProductList) =   _productDTO.FileImport(caminhoArquivo);
            int qtdError = ErrorProductList.Count;

            if (qtdError > 0)
            {
                MessageBox.Show(qtdError + "itens com erro de formatação não puderam ser importados", "ERRO DE IMPORTAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                dgwImportList.DataSource = ProductList;
            VisualizeDG();
        }

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private  void materialButton1_Click(object sender, EventArgs e)
        {
            var error = 0;

            foreach (var product in ProductList)
            {
                try
                {
                    CreateProductAsync(product);
                }
                catch 
                {
                    error++;
                }

            }

            if (error == 0)
            {
                MessageBox.Show("Todos os produtos imporatdos com sucesso!", "Sucesso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
            }
            else
            {
                MessageBox.Show(error + "produtos tiveram erro de importação. Favor verificar a lista e tentar novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

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


        private async void CreateProductAsync(ProductDTO product)
        {

            await _productService.CreateProductAsync(product);


        }

        private void btnImportStock_Load(object sender, EventArgs e)
        {

        }
    }
}
