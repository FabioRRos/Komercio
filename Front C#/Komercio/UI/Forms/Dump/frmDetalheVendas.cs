using Komercio.ApplicationLayer;
using Komercio.Models;
using Komercio.Services;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Dump
{
    public partial class frmDetalheVendas : Form
    {

        private List<SalesItensDTO> salesItensDTO = new List<SalesItensDTO>();
        private SaleReportDTO _saleReportDTO;
        private ReportService _reportService;
        private DumpApp _dumpApp;
        private string _conteudoCupom;


        public frmDetalheVendas(SaleReportDTO saleReportDTO,
            ReportService reportService,
            DumpApp dumpApp)
        {
            InitializeComponent();
            _saleReportDTO = saleReportDTO;
            _reportService = reportService;

            _dumpApp = dumpApp;
        }

        private async void frmDetalheVendas_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;


            LoadParametrosDaListView();
            CarregaLista();
            CustomizeCampos();

            this.Text = $"Venda Id {_saleReportDTO.SaleId}";
        }


        private void CustomizeCampos()
        {
            gbVenda.Text = $"Cliente - {_saleReportDTO.CustomerName}. | Venda realizada em: {_saleReportDTO.SaleDate.ToString("d")}";

            //Valor da venda
            mtbValorTotal.Text = _saleReportDTO.TotalAmount.ToString("C2");
            mtbValorTotal.Hint = "Valor total da venda";

            //Forma de pagamento
            mtbPagamento.Text = _saleReportDTO.PaymantMethod;
            mtbPagamento.Hint = "Forma de pagamento";

            //vendedor
            mtbVendedor.Text = _saleReportDTO.SallerName.ToString();
            mtbVendedor.Hint = "Vendedor";

            // OBS da venda

            mtbOBS.Text = _saleReportDTO.SaleNotes;
            mtbOBS.Hint = "Obs da venda.";

        }

        /// <summary>
        /// Carrega o grid bonitinho.
        /// </summary>
        private void LoadParametrosDaListView()
        {
            //Configuração
            mlvListaProduto.View = View.Details;
            mlvListaProduto.FullRowSelect = true;
            mlvListaProduto.HideSelection = false;
            mlvListaProduto.BorderStyle = BorderStyle.None;
            mlvListaProduto.MultiSelect = false;
            mlvListaProduto.OwnerDraw = true;

            //Garante o vazio
            mlvListaProduto.Columns.Clear();

            //Colunas
            int larguraTotal = mlvListaProduto.Width;

            mlvListaProduto.Columns.Add("Produto", (int)(larguraTotal * 0.65));
            mlvListaProduto.Columns.Add("Valor Unit.", 100, HorizontalAlignment.Right);
            mlvListaProduto.Columns.Add("Qtd", 60, HorizontalAlignment.Center);
            mlvListaProduto.Columns.Add("Total", 100, HorizontalAlignment.Right);


      

        }

        /// <summary>
        /// Com o ID da venda eu consigo retornar os itens da venda.
        /// </summary>
        private async void CarregaLista()
        {

            salesItensDTO = await _reportService.GetProductList(_saleReportDTO.SaleId);
            MostraListaNaTela();
        }

        /// <summary>
        /// Carrega os itens da venda na tela.
        /// </summary>
        private void MostraListaNaTela()
        {
            mlvListaProduto.BeginUpdate();
            mlvListaProduto.Items.Clear();

            foreach (var produto in salesItensDTO)
            {
                ListViewItem item = new ListViewItem(produto.ProductName);

                item.SubItems.Add(produto.UnitPrice.ToString("C2"));
                item.SubItems.Add(produto.Quantity.ToString());
                item.SubItems.Add(produto.Total.ToString("C2"));

                item.Tag = produto;

                mlvListaProduto.Items.Add(item);
            }

            mlvListaProduto.EndUpdate();
        }
        /// <summary>
        /// Imprime o cupom fiscal salvo na maquina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtbReimpressao_Click(object sender, EventArgs e)
        {
            CarregaCupomParaImpressao();

            if (_conteudoCupom == null)
            {
                MessageBox.Show("Não pode localizar o cupom. Me desculpe!",":(");
                return;
            }
            else
            {
                printDocument1.Print();
            }
        }



        private void CarregaCupomParaImpressao()
        {
            string pasta = @"C:\Komercio\log\Cupom";
            string prefixo = $"Cupom_{_saleReportDTO.SaleId}_";

            _conteudoCupom = null;

            string[] arquivos = Directory.GetFiles(pasta, prefixo + "*.txt");

            if (arquivos.Length > 0)
            {
                string caminhoCupom = arquivos
                    .OrderByDescending(File.GetCreationTime)
                    .First();

                _conteudoCupom = File.ReadAllText(caminhoCupom, Encoding.UTF8);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Font fonte = new Font("Consolas", 8);
            float y = 0;
            float margem = 5;
            float alturaLinha = fonte.GetHeight(e.Graphics);

            // evita erros
            if (string.IsNullOrWhiteSpace(_conteudoCupom))
                return;

            string[] linhas = _conteudoCupom.Split('\n');

            foreach (var linha in linhas)
            {
                e.Graphics.DrawString(linha, fonte, Brushes.Black, margem, y);
                y += alturaLinha;
            }
        }

        private async void mtbExcluirVenda_Click(object sender, EventArgs e)
        {

            var response = MessageBox.Show("Deseja mesmo excluir esta venda?\nNão haverá volta!", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (response == DialogResult.Yes)
            {

                var retorno = await ExcluirVenda(_saleReportDTO.SaleId);


                if (retorno)
                {
                    MessageBox.Show("Venda excluida com sucesso!", "Sucesso!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tivemos problema com a exclusão, tente mais tarde!", "OPS");
                }

            }
        }

        private  async Task<bool> ExcluirVenda(int id)
        {
            var retorno = false;
            retorno = await _dumpApp.ExcluirVendaApp(id);

            return retorno;
        }
    }
}
