using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Dump
{
    public partial class fmSalesDump : Form
    {
        private readonly HttpClient _httpClient;
        private readonly ReportService _reportService;
        //Lista que vem da API
        private List<SaleReportDTO> reportDTO = new List<SaleReportDTO>();
        //Lista filtrada
        private List<SaleReportDTO> reportFiltro = new List<SaleReportDTO>();
        //controle para saber se o filtro está ativo ou não
        bool filtroactive = false;

        public fmSalesDump(string baseUrl)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
            _reportService = new ReportService(baseUrl);

            InitializeComponent();
        }
        private void fmSalesDump_Load(object sender, EventArgs e)
        {
            LoadDGVReport();
        }

        public async void LoadDGVReport()
        {

            reportDTO = await _reportService.ReturnDumpSale();
            dgvSalesDump.DataSource = reportDTO;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;




            DataGridStyle();
            DataGridColumns();
            StatusInicialComponentes();
            TotalVendaPeriodo(reportDTO);
            Vendedores();
        }

        public void StatusInicialComponentes()
        {
            mtbDataInicial.Text = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
            mtbDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


        }

        public void TotalVendaPeriodo(List<SaleReportDTO> list)
        {
            
            float total = 0;
            foreach (var report in list) 
            {
                total += report.FinalAmount;
            }


            mtbTotalPeriodo.Text = total.ToString("C2");



        }


        public void DataGridStyle()
        {
            
            dgvSalesDump.BackgroundColor = Color.White;
            dgvSalesDump.BorderStyle = BorderStyle.None;
            dgvSalesDump.RowHeadersVisible = false;
            dgvSalesDump.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void DataGridColumns()
        {

            dgvSalesDump.Columns["SaleId"].Visible = false;
            dgvSalesDump.Columns["Saletime"].Visible = false;
            dgvSalesDump.Columns["SaleNotes"].Visible = false;


            dgvSalesDump.Columns["TotalAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSalesDump.Columns["FinalAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSalesDump.Columns["SaleDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvSalesDump.Columns["PaymantMethod"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


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


        }

        private void mtbDataInicial_TextChanged(object sender, EventArgs e)
        {

            mtbDataInicial.TextChanged -= mtbDataInicial_TextChanged;

            string texto = new string(mtbDataInicial.Text.Where(char.IsDigit).ToArray());

            if (texto.Length >= 2 && texto.Length < 4)
                texto = texto.Insert(2, "/");
            else if (texto.Length >= 4 && texto.Length < 8)
                texto = texto.Insert(2, "/").Insert(5, "/");
            else if (texto.Length >= 8)
                texto = texto.Insert(2, "/").Insert(5, "/").Substring(0, 10);

            mtbDataInicial.Text = texto;

            mtbDataInicial.SelectionStart = mtbDataInicial.Text.Length;

            mtbDataInicial.TextChanged += mtbDataInicial_TextChanged;


        }

        private void mtbDataFinal_TextChanged(object sender, EventArgs e)
        {
            mtbDataFinal.TextChanged -= mtbDataFinal_TextChanged;

            string texto = new string(mtbDataFinal.Text.Where(char.IsDigit).ToArray());

            if (texto.Length >= 2 && texto.Length < 4)
                texto = texto.Insert(2, "/");
            else if (texto.Length >= 4 && texto.Length < 8)
                texto = texto.Insert(2, "/").Insert(5, "/");
            else if (texto.Length >= 8)
                texto = texto.Insert(2, "/").Insert(5, "/").Substring(0, 10);

            mtbDataFinal.Text = texto;

            mtbDataFinal.SelectionStart = mtbDataFinal.Text.Length;

            mtbDataFinal.TextChanged += mtbDataFinal_TextChanged;

        }

        private void mbtFiltarData_Click(object sender, EventArgs e)
        {
            FiltroData();
            filtroactive = true;
            
        }


        private void FiltroData()
        {


            DateTime dataInicial = DateTime.Parse(mtbDataInicial.Text);
            DateTime dataFinal = DateTime.Parse(mtbDataFinal.Text);

            reportFiltro.Clear();

            foreach (SaleReportDTO sale in reportDTO)
            {
               
                if (sale.SaleDate >= dataInicial && sale.SaleDate  <= dataFinal)
                {
                reportFiltro.Add(sale);
                }
            }
            
            dgvSalesDump.DataSource = reportFiltro;
            TotalVendaPeriodo(reportFiltro);

            DataGridStyle();
        }



        private void mbtLimparFiltro_Click(object sender, EventArgs e)
        {
            filtroactive = false;
            LoadDGVReport();
            StatusInicialComponentes();

        }

        List<string> vendedorList = new List<string>();

        private void Vendedores()
        {
            
            foreach (SaleReportDTO sale in reportDTO)
            {

               
                    if (!vendedorList.Contains(sale.SallerName))
                    {
                    vendedorList.Add(sale.SallerName);
                    mcbSallerName.Items.Add(sale.SallerName);
                }
            }

            
        }


        private void FiltroPorVendedores()
        {
            var lista = new List<SaleReportDTO>();
            switch (filtroactive)
            {
                case true:
                    {
                        foreach (SaleReportDTO sale in reportFiltro)
                        {
                            DateTime dataInicial = DateTime.Parse(mtbDataInicial.Text);
                            DateTime dataFinal = DateTime.Parse(mtbDataFinal.Text);
                            if (sale.SallerName == mcbSallerName.Text && sale.SaleDate >= dataInicial && sale.SaleDate <= dataFinal)
                            {
                                lista.Add(sale);
                            }
                        }
                    }break;
                case false:
                    {
                        foreach (SaleReportDTO sale in reportDTO)
                        {
                            if (sale.SallerName == mcbSallerName.Text)
                            {
                                lista.Add(sale);

                            }
                        }
                    }break;

                default: return;
            }


            dgvSalesDump.DataSource = lista;
            TotalVendaPeriodo(lista);
        }

        private void mcbSallerName_TextChanged(object sender, EventArgs e)
        {
            if (mcbSallerName.SelectedIndex == -1)
            {
                FiltroData();
                // LoadDGVReport();
                return;
            }
            FiltroPorVendedores();
        }

        private void mtbLimparVendedor_Click(object sender, EventArgs e)
        {
            mcbSallerName.SelectedIndex = -1;
        }
    }
}
