using Komercio.Models;
using Komercio.Services;
using MeuProjetoWinForms.Models;
using MeuProjetoWinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Komercio.UI.Forms.Caixa
{
    public partial class fmAberturaCaixa : Form
    {
        private CaixaService _caixaService;
        private EmployeeService _employeeService;
        internal CaixaDTO Abertura = new CaixaDTO();
        internal EmployeeDto employeer = new EmployeeDto();

        public fmAberturaCaixa(CaixaService caixaService, EmployeeService employeeService)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            _caixaService = caixaService;
            _employeeService = employeeService;

           
            InitializeComponent();
        }

        private void fmAberturaCaixa_Load(object sender, EventArgs e)
        {
            ValidationLogin();
        }

        private void ValidationLogin()
        {
            using (frmLogin login = new frmLogin(_employeeService))
            {
                var retorno = login.ShowDialog();

                if (retorno == DialogResult.OK)
                {
                    employeer.Id = login.employeersId;
                }
                else
                {
                    MessageBox.Show("ACESSO NEGADO","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    this.Close();
                }
            }
        }


        private void mtbValorEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbValorEntrada_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbValorEntrada.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbValorEntrada.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbValorEntrada.SelectionStart = mtbValorEntrada.Text.Length;
        }

        private void mbtAbrirCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                Abertura.ValueChanged = float.Parse(mtbValorEntrada.Text.Replace("R$",""));
            }
            catch 
            {
                MessageBox.Show("Valor digitado é invalido!");
                return;
            };

            AberturaCaixa();


        }

        private async void AberturaCaixa()
        {
            var retorno = await _caixaService.UpdateCaixaTransactionAsync(ValoresAbertura());

            if (!retorno)
            {
                MessageBox.Show("Não foi posivel realizar a abertura");
                return;
            }
            MessageBox.Show("Abertura realizada com sucesso!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private CaixaDTO ValoresAbertura()
        {

          
            Abertura.ChangeType = "entrada";
            Abertura.ChangeOrigin = "Abertura";
            Abertura.VendedorID = employeer.Id;
            Abertura.ChangeDate = DateTime.Now;
            Abertura.Status = true;
            Abertura.Observations = mtbObservacao.Text;

            return Abertura;

        }
    }
}
