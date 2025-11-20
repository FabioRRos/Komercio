using Komercio.Models;
using Komercio.Services;
using MeuProjetoWinForms.Models;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Transactions
{
    public partial class fmCustomerTransactions : Form
    {
        //dependências
        private readonly CustomerService _customerService;
        private readonly CustomerTransactionService _customerTransactionService;
        private readonly EmployeeService _employeeService;

        // listas
        private List<CustomerDto> _customer = new List<CustomerDto>();
        private List<CustomerTransactionsDTO> _customerTransactions = new List<CustomerTransactionsDTO>();
        private List<SalesItensDTO> SalesItensList = new List<SalesItensDTO>();
        private List<EmployeeDto> employeerList = new List<EmployeeDto>();
        private CustomerTransactionsDTO customerTransaction = new CustomerTransactionsDTO();


        // variaveis internas
        private float totalDebito = 0;
        private string formaPagamento = string.Empty;


        public fmCustomerTransactions(CustomerService service, CustomerTransactionService customerTransactionService, EmployeeService employeeService)
        {
            _customerService = service;
            _customerTransactionService = customerTransactionService;
            _employeeService = employeeService;
            InitializeComponent();

        }

        private void fmCustomerTransactions_Load(object sender, EventArgs e)
        {
            LoadCustomerGrid();
            EmployeerList();


            // estilo do forms e botões
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            dgvTransactionsList.BackgroundColor = Color.White;
            dgvCustomerList.BackgroundColor = Color.White;
            dgvItensVenda.BackgroundColor = Color.White;

        }


        private async void LoadCustomerGrid()
        {
            
            _customer = await _customerService.GetAllCustomersAsync();
            _customer.RemoveAt(0); // remove o cliente balcão
            dgvCustomerList.DataSource = _customer;
            DesignerDataGrid();
        }

        private void DesignerDataGridTransactions()
        {
            // customização do grid            
            dgvTransactionsList.RowHeadersVisible = false;
            //dgvTransactionsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTransactionsList.BackgroundColor = Color.White;
            dgvTransactionsList.BorderStyle = BorderStyle.None;
            

            //descrição das colunas
           // dgvTransactionsList.Columns["SaleId"].HeaderText = "ID da transação";
            dgvTransactionsList.Columns["OriginType"].HeaderText = "Tipo da transação";
            dgvTransactionsList.Columns["TransactionValue"].HeaderText = "Valor da transação";
            dgvTransactionsList.Columns["TransactionDate"].HeaderText = "Data da transação";
            dgvTransactionsList.Columns["obs"].HeaderText = "Observações";
            dgvTransactionsList.Columns["seller"].HeaderText = "Vendedor";

            // deixa a coluna do tamanho necessário
            dgvTransactionsList.Columns["SaleId"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTransactionsList.Columns["OriginType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTransactionsList.Columns["TransactionValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTransactionsList.Columns["seller"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTransactionsList.Columns["obs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            //Remover colunas desnecessarias
            dgvTransactionsList.Columns["SaleId"].Visible = false;
            dgvTransactionsList.Columns["CustomerId"].Visible = false;
            dgvTransactionsList.Columns["TypePayment"].Visible = false;
            dgvTransactionsList.Columns["IdTransaction"].Visible = false;

            


        }
        private void DesignerDataGrid()
        {
            // descrição das colunas
            dgvCustomerList.Columns["customer_id"].HeaderText = "ID";
            dgvCustomerList.Columns["customer_first_name"].HeaderText = "Nome";
            dgvCustomerList.Columns["customer_last_name"].HeaderText = "Sobrenome";
            dgvCustomerList.Columns["customer_document"].HeaderText ="Documento";

            // customização do grid            
            dgvCustomerList.RowHeadersVisible = false;
            dgvCustomerList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCustomerList.BackgroundColor = Color.White;
            dgvCustomerList.BorderStyle = BorderStyle.None;


            //ocultar as colunas que não preciso mostrar
            dgvCustomerList.Columns["customer_phone"].Visible = false;
            dgvCustomerList.Columns["customer_mobile"].Visible = false;
            dgvCustomerList.Columns["customer_email"].Visible = false;
            dgvCustomerList.Columns["customer_address_line"].Visible = false;
            dgvCustomerList.Columns["customer_zip_code"].Visible = false;
            dgvCustomerList.Columns["customer_neighborhood"].Visible = false;
            dgvCustomerList.Columns["customer_city"].Visible = false;
            dgvCustomerList.Columns["customer_state"].Visible = false;
            dgvCustomerList.Columns["customer_country"].Visible = false;
            dgvCustomerList.Columns["customer_account_id"].Visible = false;
            dgvCustomerList.Columns["customer_status"].Visible = false;
        }

        private void DesignerDatagridSaleItens()
        {
            //descrição das colunas
            dgvItensVenda.Columns["ProductId"].HeaderText = "ID da venda";
            dgvItensVenda.Columns["ProductName"].HeaderText = "Nome do produto";
            dgvItensVenda.Columns["Quantity"].HeaderText = "Quantidade";
            dgvItensVenda.Columns["UnitPrice"].HeaderText = "Preço unitário";
            dgvItensVenda.Columns["Total"].HeaderText = "Preço total";

            // customização do grid            
            dgvItensVenda.RowHeadersVisible = false;
            dgvItensVenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvItensVenda.BackgroundColor = Color.White;
            dgvItensVenda.BorderStyle = BorderStyle.None;
            dgvItensVenda.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void mbtCancel_Click(object sender, EventArgs e)
        {
            mtbName.Clear();
            mtbDoc.Clear();
            dgvCustomerList.DataSource = _customer;
        }

        private void mtbName_Enter(object sender, EventArgs e)
        {
            mtbDoc.Clear();
        }

        private void mtbDoc_Enter(object sender, EventArgs e)
        {
            mtbName.Clear();
        }

        private void mtbDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mbtSearch_Click(object sender, EventArgs e)
        {
            if (mtbName.Text != string.Empty)
            {
                var filteredList = _customer.Where(c => c.customer_first_name.IndexOf(mtbName.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                dgvCustomerList.DataSource = filteredList;
            }
            else if (mtbDoc.Text != string.Empty)
            {
                var filteredList = _customer.Where(c => c.customer_document.IndexOf(mtbDoc.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                dgvCustomerList.DataSource = filteredList;
            }
            else
            {
                dgvCustomerList.DataSource = _customer;
            }
        }

        private async void dgvCustomerListLoad(int id)
        {
            _customerTransactions = await _customerTransactionService.GetCustomerTransactionServiceAsync(id);
            dgvTransactionsList.DataSource = _customerTransactions;
            DesignerDataGridTransactions();
            CalcDebito();
        }

        private void dgvCustomerList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvCustomerList.CurrentRow.Cells["customer_id"].Value);

            dgvCustomerListLoad(id);

            dgvItensVenda.DataSource = null;
            mlbCliente.Text = dgvCustomerList.CurrentRow.Cells["customer_first_name"].Value.ToString() + " " + dgvCustomerList.CurrentRow.Cells["customer_last_name"].Value.ToString();
        }

        private async void LoadSaleitensByTransactionId(int transactionId)
        {
           
            SalesItensList = await _customerTransactionService.GetSalesItensByTransactionIdAsync(transactionId);
            dgvItensVenda.DataSource = SalesItensList;

            DesignerDatagridSaleItens();
        }

        private void dgvTransactionsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(dgvTransactionsList.CurrentRow.Cells["SaleId"].Value);

            if (id == 0)
            {
                MessageBox.Show("Pagamento não possui itens.","Ops..",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            LoadSaleitensByTransactionId(id);
}

        public void CalcDebito()
        {
            float valorPago = 0;
            float valorDevido = 0;
            foreach (var transaction in _customerTransactions)
            {

                switch (transaction.OriginType)
                {
                    case "Pagamento":
                        valorPago += transaction.TransactionValue;
                        break;
                    case "Venda":
                        
                        valorDevido += transaction.TransactionValue;
                        break;
                }

            }
            totalDebito = valorDevido - valorPago;
            mlbTotalDebito.Text = totalDebito.ToString("C2");

            if (totalDebito <= 0)
            {
                MessageBox.Show("O cliente não possui débitos pendentes.","Informação",MessageBoxButtons.OK,MessageBoxIcon.Information);
                materialCard1.Enabled = false;
                mtbPaymentValue.Text = 0.ToString("C2");
                assetsBotoes();
                formaPagamento = string.Empty;

            }
            else
            {
                materialCard1.Enabled = true;
            }
        }

        private void mtbDoc_Click(object sender, EventArgs e)
        {

        }

        private void mtbPaymentValue_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbPaymentValue.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbPaymentValue.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbPaymentValue.SelectionStart = mtbPaymentValue.Text.Length;

            assetsBotoes();
            formaPagamento = string.Empty;
            mtbTroco.Text = 0.ToString("C2");
        }
        private bool excecaoPagamentoDinheiro()
        {
            mtbTroco.Text = 0.ToString("C2");
            if (float.Parse(mtbPaymentValue.Text.Replace("R$", "").Trim()) > totalDebito)
            {
                MessageBox.Show("O valor pago é maior do que o valor da divida.","ATENÇÃO!!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                mtbTroco.Text = 0.ToString("C2");
                mtbPaymentValue.Text = 0.ToString("C2");
                assetsBotoes();
                formaPagamento = string.Empty;
                return false;
            }

            return true;
        }

        private void assetsBotoes()
        {
            mtbDinheiro.UseAccentColor = false;
            mtbPix.UseAccentColor = false;
            mtbCredito.UseAccentColor = false;
            mtbDebito.UseAccentColor = false;

        }

        private void mtbDebito_Click(object sender, EventArgs e)
        {
            try
            {
                formaPagamento = "Débito";
              var err =   excecaoPagamentoDinheiro();
                if (err)
                {
                    assetsBotoes();
                    mtbDebito.UseAccentColor = true;
                }
                

            }
            catch
            {
                MessageBox.Show("Por gentileza, informe o valor do pagamento corretamente.");
            }
        }

        private void mtbCredito_Click(object sender, EventArgs e)
        {
            try
            {
                formaPagamento = "Crédito";
                var err = excecaoPagamentoDinheiro();
                if (err)
                {
                    assetsBotoes();
                    mtbCredito.UseAccentColor = true;
                }
            }
            catch
            {
                MessageBox.Show("Por gentileza, informe o valor do pagamento corretamente.");
            }
        }

        private void mtbPix_Click(object sender, EventArgs e)
        {
            try
            {
                formaPagamento = "PIX";
                var err = excecaoPagamentoDinheiro();
                if (err)
                {
                    assetsBotoes();
                    mtbPix.UseAccentColor = true;
                }
               
            }
            catch
            {
                MessageBox.Show("Por gentileza, informe o valor do pagamento corretamente.");
            }
        }

        private void mtbDinheiro_Click(object sender, EventArgs e)
        {
            try
            {
                formaPagamento = "Dinheiro";

                if (float.Parse(mtbPaymentValue.Text.Replace("R$", "").Trim()) < totalDebito)
                {
                    mtbTroco.Text =0.ToString("C2");
                    return;
                }
                var dindim = (float.Parse(mtbPaymentValue.Text.Replace("R$", "").Trim()) - totalDebito).ToString("C2");


                mtbTroco.Text = dindim;
                assetsBotoes();
                mtbDinheiro.UseAccentColor = true;
            }
            catch
            {
                MessageBox.Show("Por gentileza, informe o valor do pagamento corretamente.");
            }
        }

        private async void EmployeerList()
        {
            employeerList = await _employeeService.GetActiveEmployeeNamesAsync();


            foreach (var employee in employeerList)
            {
                mtbFunc.Items.Add(employee.EmployeeFullName);

            }
        }


        private void FinalizeSale()
        {
            customerTransaction.CustomerId = Convert.ToInt32(dgvCustomerList.CurrentRow.Cells["customer_id"].Value);
            customerTransaction.OriginType = "Pagamento";
            customerTransaction.TransactionValue = float.Parse(mtbPaymentValue.Text.Replace("R$", "").Trim()) - float.Parse(mtbTroco.Text.Replace("R$", "").Trim());
            customerTransaction.TransactionDate = DateTime.Now;
            customerTransaction.Obs = mtbOBS.Text;
            foreach (var emp in employeerList)
            {
                if (emp.EmployeeFullName == mtbFunc.Text)
                {
                    customerTransaction.Seller = emp.Id.ToString();
                }
            }
            customerTransaction.TypePayment = formaPagamento;
        }

        private async void mtbRegistraPagamento_Click(object sender, EventArgs e)
        {
            if (mtbPaymentValue.Text == "")
            {
                MessageBox.Show("Informe o valor do pagamento.");
                return;
            }

            if (string.IsNullOrEmpty(formaPagamento))
            {
                MessageBox.Show("Selecione a forma de pagamento.");
                return;
            }

            if (string.IsNullOrEmpty(mtbFunc.Text))
            {
                MessageBox.Show("Selecione o funcionário responsavel pelo pagamento.");
                return;
            }

            FinalizeSale();

           var retorno = MessageBox.Show("Deseja confirmar o pagamento?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if (retorno == DialogResult.Yes)
           {
               try
               {
                   var response = await  _customerTransactionService.PostCustomerTransactionAsync(customerTransaction);
                   if (response)
                   {
                       MessageBox.Show("Pagamento registrado com sucesso!");
                       dgvCustomerListLoad(customerTransaction.CustomerId);
                       mtbPaymentValue.Clear();
                       mtbOBS.Clear();
                       mtbFunc.Text = string.Empty;
                       mtbTroco.Clear();
                       formaPagamento = string.Empty;
                        ReloadForm();
                   }
                   else
                   {
                       MessageBox.Show("Erro ao registrar pagamento. Tente novamente.");
                   }
               }
               catch (Exception ex)
               {
                   MessageBox.Show("Erro ao registrar pagamento: " + ex.Message);
               }
           }
        }

        private void ReloadForm()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.fmCustomerTransactions_Load(null, null);
        }

        private void mtbPaymentValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
