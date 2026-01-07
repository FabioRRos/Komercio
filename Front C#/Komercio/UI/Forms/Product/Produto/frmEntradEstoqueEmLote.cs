using Komercio.ApplicationLayer;
using Komercio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Komercio.UI.Forms.Product.Produto
{
    public partial class frmEntradEstoqueEmLote : Form
    {

        private string _caminhoSaveArquivo;
        private string _caminhoLoadArquivo;


        private ProdutoApp _produtoApp;

        private List<ProductDTO> listaDeProdutosRetornado = new List<ProductDTO>();
        private List<ProductDTO> listaProdutoAlterado = new List<ProductDTO>();
        List<string> errorImput = new List<string>();




        public frmEntradEstoqueEmLote(ProdutoApp produtoApp)
        {
            InitializeComponent();
            _produtoApp = produtoApp;
        }

        /// <summary>
        /// LOAD DO FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEntradEstoqueEmLote_Load(object sender, EventArgs e)
        {
            //Carrega para a guia 1 - INICIAL
            LoadListaProdutos();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        /// <summary>
        /// AQUI É O CONTROLE DO QUE TEREMOS NO GRID DEPENDENDO DA GUIA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcPassos_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgwListaDeProdutos.DataSource = string.Empty;


            switch(tcPassos.SelectedIndex)
            {
                case 0: LoadGridDeProdutosInicialmente();break;
                case 1:
                    {
                        listaProdutoAlterado.Clear();
                    }
                    break;
                case 2:
                    {
                        CarregaArquivoNoGrid();
                        ConfigurarColunasProdutos();
                    }
                    ; break;

                default: dgwListaDeProdutos.DataSource = string.Empty;break;
            }

        }


        /// <summary>
        /// FORMATA A TABELA COM AS COLUNAS NECESSÁRIAS
        /// PODE SER REUTILIZADA
        /// </summary>
        private void ConfigurarColunasProdutos()
        {
            dgwListaDeProdutos.RowHeadersVisible = false;

            dgwListaDeProdutos.Columns["productName"].HeaderText = "Produto";
            dgwListaDeProdutos.Columns["productCodbar"].HeaderText = "Codigo de barras";
            dgwListaDeProdutos.Columns["productStock"].HeaderText = "QTD";
            dgwListaDeProdutos.Columns["ProductPrchasePrice"].HeaderText = "Preço de compra";

            dgwListaDeProdutos.Columns["productGroup"].Visible = false;
            dgwListaDeProdutos.Columns["productPrice"].Visible = false;
            dgwListaDeProdutos.Columns["idProduct"].Visible = false;
            dgwListaDeProdutos.Columns["productStatus"].Visible = false;
            dgwListaDeProdutos.Columns["productSubgroup"].Visible = false;


            dgwListaDeProdutos.Columns["productName"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)DataGridViewAutoSizeColumnsMode.AllCells;
            dgwListaDeProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }


        //##########################################################
        //###################### PRIMEIRA GUIA #####################
        //##########################################################

        private void materialButton1_Click(object sender, EventArgs e)
        {
            CaminhoParaSalvarArquivo();
            CriaArquivo();
        }


        private void CriaArquivo()
        {

            try
            {
                string nomeArquivo = "produtos.csv";

                string caminhoCompleto = Path.Combine(_caminhoSaveArquivo, nomeArquivo);

                using (StreamWriter writer = new StreamWriter(caminhoCompleto, false, Encoding.UTF8))
                {
                    writer.WriteLine("Descrição do Produto;Código De Barras;QUANTIDADE;Preço de compra");
                    
                    foreach (var item in listaDeProdutosRetornado)
                    {
                        string linha = item.productName + ";" + item.productCodbar + ";;" + item.ProductPrchasePrice;
                        writer.WriteLine(linha);
                    }
                }

                MessageBox.Show("Arquivo criado com sucesso!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "Não foi possível salvar o arquivo nessa pasta.",
                    "Acesso negado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

        }


        private void CaminhoParaSalvarArquivo()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                _caminhoSaveArquivo = folder.SelectedPath;
            }
            mtbDiretorio.Text= _caminhoSaveArquivo;
        }


        private async void LoadListaProdutos()
        {
            (listaDeProdutosRetornado,_) = await _produtoApp.BuscaListaDeProdutoEGrupo();
            LoadGridDeProdutosInicialmente();

        }


        private void LoadGridDeProdutosInicialmente()
        {
            dgwListaDeProdutos.DataSource = listaDeProdutosRetornado;
            ConfigurarColunasProdutos();
        }

        //##########################################################
        //####################### SEGUNDA GUIA #####################
        //##########################################################
        private void mbtLoadArquivo_Click(object sender, EventArgs e)
        {
            loadArquvio();
        }

        /// <summary>
        /// Carrega o arquivo que salvei.
        /// </summary>
        private void loadArquvio()
        {

            OpenFileDialog abrir = new OpenFileDialog();

            abrir.Filter = "Arquivos CSV (*.CSV)|*.CSV";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                _caminhoLoadArquivo = abrir.FileName;
            }

            CarregaArquivoNaLista();
            CarregaArquivoNoGrid();
            ConfigurarColunasProdutos();
        }

        /// <summary>
        /// Abre o arquivo e salva em uma lista de produto (pra eu não precisar criar outra lista).
        /// </summary>
        private void CarregaArquivoNaLista()
        {
            string[] rows;

            try
            {
                 rows = File.ReadAllLines(_caminhoLoadArquivo);

            }
            catch
            {
                return;
            }

            for (int i = 0; i < rows.Length; i++)
            {

                    string[] campos = rows[i].Split(';');
                    try
                    {
                    if (campos[0] == "Descrição do Produto")
                    {
                        continue;
                    }
                        ProductDTO Product = new ProductDTO
                        {
                            productName = campos[0],
                            productCodbar = campos[1],
                            productStock = int.Parse(campos[2]),
                            ProductPrchasePrice = float.Parse(campos[3]),
                        };
                        listaProdutoAlterado.Add(Product);
                    }
                    catch
                    {
                        errorImput.Add(rows[i]);
                        continue;
                    }
            }

        }

        /// <summary>
        /// Carrega a lista dos itens importados na guia 2 e manterei para a gia 3. Se voltar pra 2, zera a contagem.
        /// </summary>
        private async void CarregaArquivoNoGrid()
        {
            dgwListaDeProdutos.DataSource = listaProdutoAlterado;
        }


        //##########################################################
        //##################### Terceira GUIA #%####################
        //##########################################################


        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            if (listaProdutoAlterado.Count<=0)
            {
                MessageBox.Show("Primeiro carregue o arquivo no PASSO 2", "ATENÇÃO!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CorreListaSave();
            SaveItensError();

            MessageBox.Show($"Entrada no estoque com sucesso!\nItens que deram erro foram salvos em:\n{_caminhoLoadArquivo}", "Concluido!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        public async void CorreListaSave()
        {
            int valorCarregado = 0;


            foreach (var item in listaProdutoAlterado) 
            {
                valorCarregado += await SaveItens(item);
                    
                LoadBarrinha(valorCarregado);
            }
        }

        private void LoadBarrinha(int valorCarregado)
        {
            int valor = listaProdutoAlterado.Count;

            try
            {
                mPBload.Maximum = valor;
                mPBload.Value = valorCarregado;
            }

            catch
            {
               
            }
            
        }
        private async Task<int> SaveItens(ProductDTO item)
        {
          var retorno =   await _produtoApp.EntradaEstoqueCodigoDeBarras(item.productCodbar,item.productStock,item.ProductPrchasePrice);

            if (retorno.productCodbar == item.productCodbar)
            {
                return 1;
            }
            else
            {
                string linhaerro = item.productName + ";" + item.productCodbar;
                errorImput.Add(linhaerro);
                return 0;
            }
        }


        private void SaveItensError()
        {

            if (errorImput == null || errorImput.Count == 0)
                return;

            string diretorio = Path.GetDirectoryName(_caminhoLoadArquivo);

            string caminhoErro = Path.Combine(diretorio, "Itens_nao_carregados.csv");

            using (StreamWriter writer = new StreamWriter(caminhoErro, false, Encoding.UTF8))
            {
                foreach (string linha in errorImput)
                {
                    writer.WriteLine(linha);
                }
            }

        }

    }
}
