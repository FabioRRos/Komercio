using Komercio.ApplicationLayer;
using Komercio.Models;
using Komercio.Services;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms
{
    public partial class frmFechamentoCaixa : Form
    {
        private CaixaService _caixaService;
        private CashmovementsService _cashmovementsService;
        private EmployeeService _employeeService;
        private FormaPagamentoService _formaPagamentoservice;
        private ProductService _productService;

        //objetos e variaveis utilizadas em todo o código
        private List<CaixaDTO> _caixaDTO = new List<CaixaDTO>();
        private ValoresFechamentoDTO valoresFechamento = new ValoresFechamentoDTO();
        private ValoresFechamentoDTO valoresInputFechamento = new ValoresFechamentoDTO();
        internal string _cupom;
        private CaixaDTO fechamento = new CaixaDTO();

        private ParametrosApp  _parametrosApp;


        //listas utilizadas no código
        private List<CashovementsDTO> movimentacaoCaixa = new List<CashovementsDTO>();
        private List<FormaPagamentoDTO> formaPagamento = new List<FormaPagamentoDTO>();
        private List<SalesItensDTO> salesItensDTO = new List<SalesItensDTO>();   


        private string _receiptText = string.Empty;
        readonly string Printer = ConfigurationManager.AppSettings["Printer"];
        readonly string nomeFantasia = ConfigurationManager.AppSettings["NomeFantasia"];
        readonly string razaoSocial = ConfigurationManager.AppSettings["RazaoSocial"];
        readonly string cNPJ = ConfigurationManager.AppSettings["CNPJ"];
        readonly string endereco = ConfigurationManager.AppSettings["Endereco"];
        readonly string cidade = ConfigurationManager.AppSettings["Cidade"];
        readonly string contato = ConfigurationManager.AppSettings["Contato"];
        private string _funcionarioNome;



        public frmFechamentoCaixa(CaixaService caixaService,
            CashmovementsService cashMovement,
            List<CaixaDTO> caixa,
            EmployeeService employeeService,
            ParametrosApp parametrosApp,
            FormaPagamentoService formaPagamentoservice,
            ProductService productService)
        {
            _caixaService = caixaService;
            _caixaDTO = caixa;
            _cashmovementsService = cashMovement;
            _employeeService = employeeService;
            _parametrosApp = parametrosApp;
            _formaPagamentoservice = formaPagamentoservice;
            InitializeComponent();
            _productService = productService;
        }

        private void frmCaixa_Load(object sender, EventArgs e)
        {
            ValidationLogin();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            CarregaLista();
            loadMTB();
            


        }

        private void ValidationLogin()
        {
            using (frmLogin login = new frmLogin(_employeeService))
            {
                var retorno = login.ShowDialog();

                if (retorno == DialogResult.OK)
                {
                    fechamento.VendedorID = login.employeersId;
                    _funcionarioNome = login.funcionario;
                }
                else
                {
                    MessageBox.Show("ACESSO NEGADO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
            }
        }


        
        private void loadMTB()
        {
            mtbDinheiro.Text = 0.ToString();
            mtbDebito.Text = 0.ToString();
            mtbCredito.Text = 0.ToString();
            mtbPix.Text = 0.ToString();
            mtbConta.Text = 0.ToString();
            mtbSangria.Text = 0.ToString();

            mtbDinheiro.Hint = "Dinheiro";
            mtbDebito.Hint = "Débito";
            mtbCredito.Hint = "Crédito";
            mtbPix.Hint = "Pix";
            mtbConta.Hint = "Conta";
            mtbSangria.Hint = "Sangria";
        }

       

        private async void CarregaLista()
        {
             movimentacaoCaixa = await _cashmovementsService.GetCashMovement();
            formaPagamento = await _formaPagamentoservice.GetFormaPagamento();

            if (movimentacaoCaixa == null) {
                MessageBox.Show("Alguma coisa deu errado");
                return;
            }
            CarregaProdutos();
            CalculaValores();
        }

        private async void CarregaProdutos()
        {
            foreach (var idvenda in movimentacaoCaixa)
            {
                if (idvenda.saleId != 0)
                {
                    var retorno = await _productService.BuscaItemVenda(idvenda.saleId);
                    foreach(var item in retorno)
                    {
                        salesItensDTO.Add(item);
                    }
                    
                }
            }
        }

        private void CalculaValores()
        {


            foreach (var pagamento in formaPagamento)
            {

                switch (pagamento.FormaDePagamento)
                {
                    case "Dinheiro":
                        {
                            valoresFechamento.Dinheiro += pagamento.ValorPago;
                        }
                        break;
                    case "Débito":
                        {
                            valoresFechamento.Debito += pagamento.ValorPago;
                        }
                        break;
                    case "Crédito":
                        {
                            valoresFechamento.Credito += pagamento.ValorPago;
                        }
                        break;
                    case "PIX":
                        {
                            valoresFechamento.Pix += pagamento.ValorPago;
                        }
                        break;
                    case "Conta":
                        {
                            valoresFechamento.Conta += pagamento.ValorPago;
                        }
                        break;

                    default: break;
                }
            }
            foreach (var moviment in movimentacaoCaixa)
            {
                if (moviment.paymentMethod == "Sangria")
                    {
                        valoresFechamento.Sangria += moviment.amount;

                    }
                }

            foreach (var caixa in _caixaDTO)
            {
                if (caixa.ChangeType == "entrada")
                {
                    valoresFechamento.Entrada += caixa.ValueChanged;
                }
                else if (caixa.ChangeType == "retirada")
                {
                    valoresFechamento.Saida += caixa.ValueChanged;
                }
            }

           // var valorfinal = valoresFechamento.Entrada + _caixaDTO[0].ValueChanged - valoresFechamento.Saida;
         //  MessageBox.Show($"VALORES DO CAIXA: {valorfinal.ToString("C2")}");

            valoresFechamento.Restante = valoresFechamento.Dinheiro + _caixaDTO[0].ValueChanged - valoresFechamento.Sangria ;

            //preciso tratar caso essa conta fique negativa.

            MostrarValores();

        }




        private void mlbStatusCaixa_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox24_Click(object sender, EventArgs e)
        {

        }



        private void validaCaixa()
        {
            valoresInputFechamento.Dinheiro = float.Parse(mtbDinheiro.Text.Replace("R$",""));
            valoresInputFechamento.Debito = float.Parse(mtbDebito.Text.Replace("R$", ""));
            valoresInputFechamento.Credito = float.Parse(mtbCredito.Text.Replace("R$", ""));
            valoresInputFechamento.Pix = float.Parse(mtbPix.Text.Replace("R$", ""));
            valoresInputFechamento.Conta = float.Parse(mtbConta.Text.Replace("R$", ""));
            valoresInputFechamento.Sangria = float.Parse(mtbSangria.Text.Replace("R$", ""));

            //##############################
        }

        private void MostrarValores()
        {
            mtbDinheiro.HelperText = valoresFechamento.Dinheiro.ToString("C2");
            mtbDebito.HelperText = valoresFechamento.Debito.ToString("C2");
            mtbCredito.HelperText = valoresFechamento.Credito.ToString("C2");
            mtbPix.HelperText = valoresFechamento.Pix.ToString("C2");
            mtbConta.HelperText = valoresFechamento.Conta.ToString("C2");
            mtbSangria.HelperText = valoresFechamento.Sangria.ToString("C2");

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mtbDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbPix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbSangria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbDinheiro_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbDinheiro.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbDinheiro.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbDinheiro.SelectionStart = mtbDinheiro.Text.Length;
        }

        private void mtbDebito_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbDebito.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbDebito.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbDebito.SelectionStart = mtbDebito.Text.Length;
        }

        private void mtbCredito_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbCredito.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbCredito.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbCredito.SelectionStart = mtbCredito.Text.Length;

        }

        private void mtbPix_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbPix.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbPix.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbPix.SelectionStart = mtbPix.Text.Length;

        }

        private void mtbConta_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbConta.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbConta.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbConta.SelectionStart = mtbConta.Text.Length;

        }

        private void mtbSangria_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbSangria.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbSangria.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbSangria.SelectionStart = mtbSangria.Text.Length;
        }


        private void CupomFiscal()
        {           
            var sb = new StringBuilder();
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("");
            sb.AppendLine($"     *** {nomeFantasia} ***");
            sb.AppendLine("          CUPOM NAO FISCAL");
            sb.AppendLine("");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("");
            sb.AppendLine($"DATA FECHAMENTO: {DateTime.Now}"); sb.AppendLine($"RAZAO SOCIAL: {razaoSocial}");
            sb.AppendLine($"CNPJ: {cNPJ}");
            sb.AppendLine($"ENDERECO:{endereco}");
            sb.AppendLine($"{cidade}");
            sb.AppendLine($"FONE/WHATSAPP:{contato}");
            sb.AppendLine("");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"FUNCIONÁRIO:{_funcionarioNome}");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("-------- FECHAMENTO DO CAIXA ---------");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("");
            sb.AppendLine($"CAIXA NA ABERTURA : {_caixaDTO[0].ValueChanged.ToString("C2")}");
            sb.AppendLine($"DINHEIRO : {valoresFechamento.Dinheiro.ToString("C2")}");
            sb.AppendLine($"DEBITO : {valoresFechamento.Debito.ToString("C2")}");
            sb.AppendLine($"CREDITO : {valoresFechamento.Credito.ToString("C2")}");
            sb.AppendLine($"PIX : {valoresFechamento.Pix.ToString("C2")}");
            sb.AppendLine($"CONTA : {valoresFechamento.Conta.ToString("C2")}");
            sb.AppendLine($"SANGRIA : {valoresFechamento.Sangria.ToString("C2")}");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"Restante em caixa: {valoresFechamento.Restante.ToString("C2")}");
            sb.AppendLine("");
            //Parte da lista de produtos
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("--------- LISTA DE PRODUTOS ----------");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("QTD - DESCRICAO");
            sb.AppendLine("--------------------------------------");
            foreach (var itens in salesItensDTO)
            {
                string qtd = itens.Quantity.ToString().PadLeft(3);
                string nome = itens.ProductName.ToUpper();

                if (nome.Length > 32)
                {
                    nome = nome.Substring(0, 32);
                }

                sb.AppendLine(qtd + " - " + nome);

            }


            if (mcbJustDif.Checked == true)
            {
                sb.AppendLine("");
                sb.AppendLine("--------------------------------------");
                sb.AppendLine("----- VALOR DO CAIXA DIVERGÊNTE ------");
                sb.AppendLine("--------------------------------------");
                sb.AppendLine($"Valor em sistema: {valoresFechamento.Dinheiro.ToString("C2")}");
                sb.AppendLine($"Valor em caixa: {mtbDinheiro.Text}");
                sb.AppendLine("--------- Justificativa --------------");
                sb.AppendLine($"{mtbJustificativa.Text}");
                sb.AppendLine("--------------------------------------");
            }

            rtbCupon.Text = sb.ToString();
            _cupom = sb.ToString();
        }




        private void rtbCupon_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            validaCaixa();
            CupomFiscal();
        }

        private async void mbtFechar_Click(object sender, EventArgs e)
        {
           if (!ValidaValores())
                return;
            FechamentoCaixa();

            CupomFiscal();

            var retorno = await VerificaStatusParametro(3);

            if (retorno)
            {
                printCupom.Print();

            }

            // imprimir o cupom com o valor alterado pela diferença de dinheiro no caixa.

        }

        private async Task<bool> VerificaStatusParametro(int id)
        {
            var status = await _parametrosApp.ConsultaStatusParametro(id);

            return status;
        }

        private async void FechamentoCaixa()
        {
           var retorno =  await _caixaService.UpdateCaixaTransactionAsync(ValoresFechamento());

            if (!retorno)
            {
                MessageBox.Show("Não foi posivel realizar o fechamento");
                return;
            }
            MessageBox.Show("Fechamento realizado com sucesso!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private CaixaDTO ValoresFechamento()
        {

            fechamento.ValueChanged = valoresFechamento.Restante;
            fechamento.ChangeType = "retirada";
            fechamento.ChangeOrigin = "Fechamento";
            fechamento.ChangeDate = DateTime.Now;
            fechamento.Status = false;
            if (mcbJustDif.Checked == true)
            {
                var valorCaixaDinheiro = valoresFechamento.Dinheiro - float.Parse(mtbDinheiro.Text.Replace("R$", ""));
                fechamento.Observations = mtbJustificativa.Text + $" - Diferença em caixa é de: {valorCaixaDinheiro.ToString("C2")}";
            }
            else
            {
                fechamento.Observations = "Caixa fechado sem alterações.";
            }

            return fechamento;
            
        }

        private bool ValidaValores() 
        {

            try {
                if (float.Parse(mtbDinheiro.Text.Replace("R$","")) != (float)Math.Round((decimal)valoresFechamento.Dinheiro, 2))
                {
                    if (mcbJustDif.Checked == true)
                    {
                        if (mtbJustificativa.Text == "")
                        {
                            MessageBox.Show("É necessário justificar as diferenças no caixa!!!");
                            return false;
                        }

                    }
                    else
                    {

                        MessageBox.Show("O valor em Dineiro informado não bate com o valor em sistema.");
                        return false;
                    }
                }

                if (float.Parse(mtbDebito.Text.Replace("R$", "")) != (float)Math.Round((decimal)valoresFechamento.Debito, 2))
                    {
                        MessageBox.Show("O valor em Débito informado não bate com o valor em sistema.");
                    return false;
                }
                if (float.Parse(mtbCredito.Text.Replace("R$", ""))!= (float)Math.Round((decimal)valoresFechamento.Credito, 2)) 
                    {
                        MessageBox.Show("O valor em Crédito informado não bate com o valor em sistema.");
                    return false;
                }
                if (float.Parse(mtbPix.Text.Replace("R$", "")) != (float)Math.Round((decimal)valoresFechamento.Pix, 2))
                    {
                        MessageBox.Show("O valor em PIX informado não bate com o valor em sistema.");
                    return false;
                }
                
                 if (float.Parse(mtbConta.Text.Replace("R$", ""))!= (float)Math.Round((decimal)valoresFechamento.Conta, 2)) 
                    {
                        MessageBox.Show("O valor em Conta informado não bate com o valor em sistema.");
                    return false;
                }
                if (float.Parse(mtbSangria.Text.Replace("R$", ""))!= (float)Math.Round((decimal)valoresFechamento.Sangria, 2)) 
                    { 
                        
                        MessageBox.Show("O valor da sangria informado não bate com o valor em sistema.");
                    return false;
                }

            }

            catch
            {
                MessageBox.Show("Valores invalidos. Tente novamente");
                return false;
            }

            return true;
        }

        private void mcbJustDif_CheckedChanged(object sender, EventArgs e)
        {
            if (mcbJustDif.Checked)
            {
                mtbJustificativa.Enabled = true;
            }
            else
            {
                mtbJustificativa.Enabled = false;
                mtbJustificativa.Text = string.Empty;
            }
        }

        private void printCupom_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fonte = new Font("Consolas", 8);
            float y = 0;
            float margem = 5;
            float alturaLinha = fonte.GetHeight(e.Graphics);

            // evita erros
            if (string.IsNullOrWhiteSpace(_cupom))
                return;

            string[] linhas = _cupom.Split('\n');

            foreach (var linha in linhas)
            {
                e.Graphics.DrawString(linha, fonte, Brushes.Black, margem, y);
                y += alturaLinha;
            }
        }
    }
}
