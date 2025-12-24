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

namespace Komercio.UI.Forms.Sales
{
    public partial class frmMultiplosPagamentos : Form
    {
        public List<FormaPagamentoDTO> formaPagamento = new List<FormaPagamentoDTO>();


        private float _valorPago = 0;
        private float _valorDevido;

        public frmMultiplosPagamentos(float valorDevido)
        {
            InitializeComponent();
            _valorDevido = valorDevido;
            RefreshValor();
        }


        private void RefreshValor()
        {
            float dinheiro = 0;
            float pix = 0;
            float debito = 0;
            float credito = 0;
            float conta = 0;

            float.TryParse(mtbDinheiro.Text.Replace("R$", ""), out dinheiro);
            float.TryParse(mtbPix.Text.Replace("R$", ""), out pix);
            float.TryParse(mtbDebito.Text.Replace("R$", ""), out debito);
            float.TryParse(mtbCredito.Text.Replace("R$", ""), out credito);
            float.TryParse(mtbConta.Text.Replace("R$", ""), out conta);

            _valorPago = dinheiro + pix + debito + credito + conta;

            mtbPago.Text = _valorPago.ToString("C2");


            mtbPago.Hint = "Valor pago";

        }


        private void frmMultiplosPagamentos_Load(object sender, EventArgs e)
        {
            mtbDevido.Text = _valorDevido.ToString("C2");
            mtbDevido.Hint = "Valor compra";

        }


        private void mbtDinheiro_Click(object sender, EventArgs e)
        {
            if (mbtDinheiro.UseAccentColor == false)
            {
                mbtDinheiro.UseAccentColor = true;
                mtbDinheiro.Enabled = true;
                mtbDinheiro.Focus();
            }
            else
            {
                mbtDinheiro.UseAccentColor = false;
                mtbDinheiro.Enabled = false;
                mtbDinheiro.Text = string.Empty;

            }

        }


        private void mbtPix_Click(object sender, EventArgs e)
        {
            if (mbtPix.UseAccentColor == false)
            {
                mbtPix.UseAccentColor = true;
                mtbPix.Enabled = true;
            }
            else
            {
                mbtPix.UseAccentColor = false;
                mtbPix.Enabled = false;
                mtbPix.Text = string.Empty;
            }
        }

        private void mbtDebito_Click(object sender, EventArgs e)
        {
            if (mbtDebito.UseAccentColor == false)
            {
                mbtDebito.UseAccentColor = true;
                mtbDebito.Enabled = true;
            }
            else
            {
                mbtDebito.UseAccentColor = false;
                mtbDebito.Enabled = false;
                mtbDebito.Text = string.Empty;
            }
        }

        private void mbtCredito_Click(object sender, EventArgs e)
        {
            if (mbtCredito.UseAccentColor == false)
            {
                mbtCredito.UseAccentColor = true;
                mtbCredito.Enabled = true;
            }
            else
            {
                mbtCredito.UseAccentColor = false;
                mtbCredito.Enabled = false;
                mtbCredito.Text = string.Empty;
            }
        }

        private void mbtConta_Click(object sender, EventArgs e)
        {
            if (mbtConta.UseAccentColor == false)
            {
                mbtConta.UseAccentColor = true;
                mtbConta.Enabled = true;
            }
            else
            {
                mbtConta.UseAccentColor = false;
                mtbConta.Enabled = false;
                mtbConta.Text = string.Empty;
            }
        }

        private void mtbVoltarPagamento_Click(object sender, EventArgs e)
        {
            CarregaLista();

            var valorOk = ValidaPagamento();

            if (!valorOk)
            {
                MessageBox.Show("Por gantileza, informe o valor corretamente");
                return;
            }


            if (formaPagamento.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
 
        }

        private bool ValidaPagamento()
        {
            float resultado = _valorDevido - _valorPago;

            if (resultado == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void CarregaLista()
        {
            if (mtbDinheiro.Enabled == true)
            {
                if (mtbDinheiro.Text == "")
                {
                    MessageBox.Show("Por gentileza, digite o valor de pagamento em dinheiro!",
                        "ATENÇÃO!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                FormaPagamentoDTO fp = new FormaPagamentoDTO();

                fp.FormaDePagamento = "Dinheiro";
                var valor = float.Parse(mtbDinheiro.Text.Replace("R$", ""));
                fp.ValorPago = valor;

                formaPagamento.Add(fp);
            }


            if (mtbPix.Enabled == true)
            {
                if (mtbPix.Text.Replace("R$","") == "" || mtbPix.Text == "R$ 0,00" )
                {
                    MessageBox.Show("Por gentileza, digite o valor de pagamento em PIX!",
                        "ATENÇÃO!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                FormaPagamentoDTO fp = new FormaPagamentoDTO();

                fp.FormaDePagamento = "PIX";
                var valor = float.Parse(mtbPix.Text.Replace("R$", ""));
                fp.ValorPago = valor;

                formaPagamento.Add(fp);
            }

            if (mtbDebito.Enabled == true)
            {
                if (mtbDebito.Text.Replace("R$", "") == "" || mtbDebito.Text == "R$ 0,00")
                {
                    MessageBox.Show("Por gentileza, digite o valor de pagamento em Débito!",
                        "ATENÇÃO!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                FormaPagamentoDTO fp = new FormaPagamentoDTO();

                fp.FormaDePagamento = "Débito";
                var valor = float.Parse(mtbDebito.Text.Replace("R$", ""));
                fp.ValorPago = valor;

                formaPagamento.Add(fp);
            }

            if (mtbCredito.Enabled == true)
            {
                if (mtbCredito.Text.Replace("R$", "") == "" || mtbCredito.Text == "R$ 0,00")
                {
                    MessageBox.Show("Por gentileza, digite o valor de pagamento em Crédito!",
                        "ATENÇÃO!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                FormaPagamentoDTO fp = new FormaPagamentoDTO();

                fp.FormaDePagamento = "Crédito";
                var valor = float.Parse(mtbCredito.Text.Replace("R$", ""));
                fp.ValorPago = valor;

                formaPagamento.Add(fp);
            }
            if (mtbConta.Enabled == true)
            {
                if (mtbConta.Text.Replace("R$","") == "" || mtbConta.Text == "R$ 0,00")
                {
                    MessageBox.Show("Por gentileza, digite o valor de pagamento em conta!",
                        "ATENÇÃO!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                FormaPagamentoDTO fp = new FormaPagamentoDTO();

                fp.FormaDePagamento = "Conta";
                var valor = float.Parse(mtbConta.Text.Replace("R$", ""));
                fp.ValorPago = valor;

                formaPagamento.Add(fp);
            }

        }

        private void mtbDinheiro_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbDinheiro.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbDinheiro.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbDinheiro.SelectionStart = mtbDinheiro.Text.Length;
            RefreshValor();
        }

        private void mtbPix_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbPix.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbPix.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbPix.SelectionStart = mtbPix.Text.Length;
            RefreshValor();
        }

        private void mtbDebito_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbDebito.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbDebito.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbDebito.SelectionStart = mtbDebito.Text.Length;
            RefreshValor();

        }

        private void mtbCredito_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbCredito.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbCredito.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbCredito.SelectionStart = mtbCredito.Text.Length;
            RefreshValor();

        }

        private void mtbConta_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbConta.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbConta.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbConta.SelectionStart = mtbConta.Text.Length;
            RefreshValor();

        }

        private void mtbDinheiro_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void mtbDinheiro_KeyPress(object sender, KeyPressEventArgs e)
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

        private void mtbConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
