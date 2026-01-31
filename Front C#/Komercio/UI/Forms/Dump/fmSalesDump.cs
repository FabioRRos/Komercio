using Komercio.ApplicationLayer;
using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Dump
{
    public partial class fmSalesDump : Form
    {
        private readonly HttpClient _httpClient;
        private readonly ReportService _reportService;
        private DumpApp _dumpApp;

        // Lista que vem da API
        private List<SaleReportDTO> reportDTO = new List<SaleReportDTO>();

        // Lista filtrada
        private List<SaleReportDTO> reportFiltro = new List<SaleReportDTO>();

        // Controle de filtro ativo
        private bool filtroactive = false;

        // Lista de vendedores
        private List<string> vendedorList = new List<string>();

        public fmSalesDump(string baseUrl,
            DumpApp dumpApp)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };

            _reportService = new ReportService(baseUrl);

            InitializeComponent();
            _dumpApp = dumpApp;
        }

        private async void fmSalesDump_Load(object sender, EventArgs e)
        {
            await LoadDGVReport();
        }

        public async Task LoadDGVReport()
        {
            reportDTO = await _reportService.ReturnDumpSale();

            AjustaPorData(reportDTO);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;

            TotalVendaPeriodo(reportDTO);
        }

        /// <summary>
        /// Coloca a lista no DataGrid
        /// </summary>
        public void AjustaPorData(List<SaleReportDTO> list)
        {
            dgvSalesDump.DataSource = list;
            mlbTotalVendas.Text = list.Count.ToString();


            DataGridColumns();
            DataGridStyle();
            StatusInicialComponentes();
            Vendedores();
        }

        /// <summary>
        /// Inicializa filtros de data (Hoje - 30 dias)
        /// </summary>
        public void StatusInicialComponentes()
        {
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "dd/MM/yyyy";

            dtpFim.Format = DateTimePickerFormat.Custom;
            dtpFim.CustomFormat = "dd/MM/yyyy";

            dtpInicio.Value = DateTime.Now.AddDays(-30);
            dtpFim.Value = DateTime.Now;
        }

        /// <summary>
        /// Soma total de vendas do período
        /// </summary>
        public void TotalVendaPeriodo(List<SaleReportDTO> list)
        {
            float total = 0;

            foreach (var report in list)
            {
                total += report.FinalAmount;
            }

            mtbTotalPeriodo.Text = total.ToString("C2");
        }

        /// <summary>
        /// Estilo do DataGrid
        /// </summary>
        public void DataGridStyle()
        {
            dgvSalesDump.BackgroundColor = Color.White;
            dgvSalesDump.BorderStyle = BorderStyle.None;
            dgvSalesDump.RowHeadersVisible = false;
        }

        /// <summary>
        /// Formatação das colunas
        /// </summary>
        public void DataGridColumns()
        {
            dgvSalesDump.Columns["SaleId"].Visible = false;
            dgvSalesDump.Columns["Saletime"].Visible = false;
            dgvSalesDump.Columns["SaleNotes"].Visible = false;

            dgvSalesDump.Columns["CustomerName"].HeaderText = "Cliente";
            dgvSalesDump.Columns["CustomerDocument"].HeaderText = "CPF/CNPJ";
            dgvSalesDump.Columns["SallerName"].HeaderText = "Vendedor";
            dgvSalesDump.Columns["TotalAmount"].HeaderText = "Valor da venda";
            dgvSalesDump.Columns["DiscountAmount"].HeaderText = "Desconto";
            dgvSalesDump.Columns["FinalAmount"].HeaderText = "Valor Final";
            dgvSalesDump.Columns["SaleDate"].HeaderText = "Data venda";
            dgvSalesDump.Columns["PaymantMethod"].HeaderText = "Forma pagamento";

            dgvSalesDump.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
            dgvSalesDump.Columns["DiscountAmount"].DefaultCellStyle.Format = "C2";
            dgvSalesDump.Columns["FinalAmount"].DefaultCellStyle.Format = "C2";

            dgvSalesDump.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Aplica filtro por data
        /// </summary>
        private void FiltroData()
        {
            DateTime dataInicial = dtpInicio.Value.Date;
            DateTime dataFinal = dtpFim.Value.Date.AddDays(1).AddSeconds(-1);

            reportFiltro.Clear();

            foreach (SaleReportDTO sale in reportDTO)
            {
                if (sale.SaleDate >= dataInicial &&
                    sale.SaleDate <= dataFinal)
                {
                    reportFiltro.Add(sale);
                }
            }

            dgvSalesDump.DataSource = reportFiltro;
            mlbTotalVendas.Text = reportFiltro.Count.ToString();
            TotalVendaPeriodo(reportFiltro);
            DataGridStyle();

            filtroactive = true;
        }

        private void mbtFiltarData_Click(object sender, EventArgs e)
        {
            FiltroData();
        }

        private void mbtLimparFiltro_Click(object sender, EventArgs e)
        {
            filtroactive = false;

            dgvSalesDump.DataSource = reportDTO;
            mlbTotalVendas.Text = reportDTO.Count.ToString();

            TotalVendaPeriodo(reportDTO);

            StatusInicialComponentes();
        }

        /// <summary>
        /// Carrega vendedores únicos
        /// </summary>
        private void Vendedores()
        {
            vendedorList.Clear();
            mcbSallerName.Items.Clear();

            foreach (SaleReportDTO sale in reportDTO)
            {
                if (!vendedorList.Contains(sale.SallerName))
                {
                    vendedorList.Add(sale.SallerName);
                    mcbSallerName.Items.Add(sale.SallerName);
                }
            }
        }

        /// <summary>
        /// Filtro por vendedor
        /// </summary>
        private void FiltroPorVendedores()
        {
            var lista = new List<SaleReportDTO>();

            DateTime dataInicial = dtpInicio.Value.Date;
            DateTime dataFinal = dtpFim.Value.Date.AddDays(1).AddSeconds(-1);

            if (filtroactive)
            {
                foreach (SaleReportDTO sale in reportFiltro)
                {
                    if (sale.SallerName == mcbSallerName.Text &&
                        sale.SaleDate >= dataInicial &&
                        sale.SaleDate <= dataFinal)
                    {
                        lista.Add(sale);
                    }
                }
            }
            else
            {
                foreach (SaleReportDTO sale in reportDTO)
                {
                    if (sale.SallerName == mcbSallerName.Text)
                    {
                        lista.Add(sale);
                    }
                }
            }

            dgvSalesDump.DataSource = lista;
            mlbTotalVendas.Text = lista.Count.ToString();


            TotalVendaPeriodo(lista);
        }

        private void mcbSallerName_TextChanged(object sender, EventArgs e)
        {
            if (mcbSallerName.SelectedIndex == -1)
            {
                FiltroData();
                return;
            }

            FiltroPorVendedores();
        }

        private void mtbLimparVendedor_Click(object sender, EventArgs e)
        {
            mcbSallerName.SelectedIndex = -1;
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpInicio.Value >= dtpFim.Value)
            {
                dtpFim.Value = dtpInicio.Value;
            }
        }

        private void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFim.Value < dtpInicio.Value)
            {
                dtpInicio.Value = dtpFim.Value;
            }
        }

        private async void dgvSalesDump_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            int saleIdSelecionado = Convert.ToInt32(
                dgvSalesDump.Rows[e.RowIndex].Cells["SaleId"].Value
            );

            SalesDTO vendaSelecionada = null;

            foreach (var venda in reportDTO)
            {
                if (venda.SaleId == saleIdSelecionado)
                {
                    frmDetalheVendas frmDetalhesVendas = new frmDetalheVendas(venda, _reportService, _dumpApp);
                    var retorno = frmDetalhesVendas.ShowDialog();
                    if (retorno == DialogResult.OK)
                    {
                        await LoadDGVReport();
                    }

                    return;
                }
            }

            if (vendaSelecionada == null)
            {
                MessageBox.Show("Venda não encontrada.");
                return;
            }


        }


    }
}
