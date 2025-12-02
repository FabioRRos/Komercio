using Komercio.Models;
using Komercio.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms
{
    public partial class frmCaixa : Form
    {
        private CaixaService _caixaService;
        private CashmovementsService _cashmovementsService;

        //objetos e variaveis utilizadas em todo o código
        private List<CaixaDTO> _caixaDTO = new List<CaixaDTO>();
        private ValoresFechamentoDTO valoresFechamento = new ValoresFechamentoDTO();
        private ValoresFechamentoDTO valoresInputFechamento = new ValoresFechamentoDTO();
        internal string cupom;
        private CaixaDTO fechamento = new CaixaDTO();


        //listas utilizadas no código
        private List<CashovementsDTO> movimentacaoCaixa = new List<CashovementsDTO>();


        private string _receiptText = string.Empty;
        readonly string Printer = ConfigurationManager.AppSettings["Printer"];
        readonly string nomeFantasia = ConfigurationManager.AppSettings["NomeFantasia"];
        readonly string razaoSocial = ConfigurationManager.AppSettings["RazaoSocial"];
        readonly string cNPJ = ConfigurationManager.AppSettings["CNPJ"];
        readonly string endereco = ConfigurationManager.AppSettings["Endereco"];
        readonly string cidade = ConfigurationManager.AppSettings["Cidade"];
        readonly string contato = ConfigurationManager.AppSettings["Contato"];



        public frmCaixa(CaixaService caixaService, CashmovementsService cashMovement, List<CaixaDTO> caixa)
        {
            _caixaService = caixaService;
            _caixaDTO = caixa;
            _cashmovementsService = cashMovement;
            InitializeComponent();
        }

        private void frmCaixa_Load(object sender, EventArgs e)
        {
            CarregaLista();
            loadMTB();   


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

            if (movimentacaoCaixa == null) {
                MessageBox.Show("Alguma coisa deu errado");
                return;
            }

            CalculaValores();
        }

        private void CalculaValores()
        {
            foreach (var moviment in movimentacaoCaixa)
            {
                switch (moviment.paymentMethod)
                {
                    case "Dinheiro":
                        {
                            valoresFechamento.Dinheiro += moviment.amount;
                        }
                        break;
                    case "Débito":
                        {
                            valoresFechamento.Debito += moviment.amount;
                        }
                        break;
                    case "Crédito":
                        {
                            valoresFechamento.Credito += moviment.amount;
                        }
                        break;
                    case "Pix":
                        {
                            valoresFechamento.Pix += moviment.amount;
                        }
                        break;
                    case "Conta":
                        {
                            valoresFechamento.Conta += moviment.amount;
                        }
                        break;
                    case "Sangria":
                        {
                            valoresFechamento.Sangria += moviment.amount;
                        }
                        break;
                    default: break;
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
            sb.AppendLine($"     *** {nomeFantasia} ***");
            sb.AppendLine("          CUPOM NAO FISCAL");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"RAZAO SOCIAL: {razaoSocial}");
            sb.AppendLine($"CNPJ: {cNPJ}");
            sb.AppendLine($"ENDERECO:{endereco}");
            sb.AppendLine($"{cidade}");
            sb.AppendLine($"FONE/WHATSAPP:{contato}");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine("-------- FECHAMENTO DO CAIXA ---------");
            sb.AppendLine("--------------------------------------");
            sb.AppendLine($"CAIXA NA ABERTURA : {_caixaDTO[0].ValueChanged.ToString("C2")}");
            sb.AppendLine($"DINHEIRO : {valoresFechamento.Dinheiro.ToString("C2")}");
            sb.AppendLine($"DEBITO : {valoresFechamento.Credito.ToString("C2")}");
            sb.AppendLine($"CREDITO : {valoresFechamento.Credito.ToString("C2")}");
            sb.AppendLine($"PIX : {valoresFechamento.Pix.ToString("C2")}");
            sb.AppendLine($"CONTA : {valoresFechamento.Conta.ToString("C2")}");
            sb.AppendLine($"SANGRIA : {valoresFechamento.Sangria.ToString("C2")}");
            sb.AppendLine($"DATA: {DateTime.Now}");
            sb.AppendLine("--------------------------------------");

            sb.AppendLine($"Restante em caixa: {valoresFechamento.Restante.ToString("C2")}");
            sb.AppendLine("--------------------------------------");
            rtbCupon.Text = sb.ToString();

        }

        private void rtbCupon_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

            validaCaixa();
             CupomFiscal();
        }

        private void mbtFechar_Click(object sender, EventArgs e)
        {
           if (!ValidaValores())
                return;
            FechamentoCaixa();

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
            fechamento.VendedorID = 1;
            fechamento.ChangeDate = DateTime.Now;
            fechamento.Status = false;
            fechamento.Observations = "Fechamento do caixa pelo funcionário 1";

            return fechamento;
            
        }

        private bool ValidaValores()
        {
            try {
                if (float.Parse(mtbDinheiro.Text.Replace("R$","")) != valoresFechamento.Dinheiro) 
                {
                    MessageBox.Show("O valor em Dineiro informado não bate com o valor em sistema.");
                    return false;
                }

                if (float.Parse(mtbDebito.Text.Replace("R$", "")) != valoresFechamento.Debito)
                    {
                        MessageBox.Show("O valor em Débito informado não bate com o valor em sistema.");
                    return false;
                }
                if (float.Parse(mtbCredito.Text.Replace("R$", ""))!= valoresFechamento.Credito) 
                    {
                        MessageBox.Show("O valor em Crédito informado não bate com o valor em sistema.");
                    return false;
                }
                if (float.Parse(mtbPix.Text.Replace("R$", "")) != valoresFechamento.Pix)
                    {
                        MessageBox.Show("O valor em PIX informado não bate com o valor em sistema.");
                    return false;
                }
                
                 if (float.Parse(mtbConta.Text.Replace("R$", ""))!= valoresFechamento.Conta) 
                    {
                        MessageBox.Show("O valor em Conta informado não bate com o valor em sistema.");
                    return false;
                }
                if (float.Parse(mtbSangria.Text.Replace("R$", ""))!= valoresFechamento.Sangria) 
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
    }
}
