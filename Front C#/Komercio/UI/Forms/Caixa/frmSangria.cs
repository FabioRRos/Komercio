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

namespace Komercio.UI.Forms.Caixa
{
    public partial class frmSangria : Form
    {
            
        private CaixaService _caixaService;
        private EmployeeService _employeeService;
        internal CaixaDTO Sangria = new CaixaDTO();
        internal EmployeeDto employeer = new EmployeeDto();
        public frmSangria(CaixaService caixaService, EmployeeService employeeService)
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            _caixaService = caixaService;
            _employeeService = employeeService;
            InitializeComponent();
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
                    MessageBox.Show("ACESSO NEGADO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
            }
        }

        private void frmSangria_Load(object sender, EventArgs e)
        {
            ValidationLogin();

        }

        private void mtbValorSangria_Click(object sender, EventArgs e)
        {

        }

        private void mtbValorSangria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbValorSangria_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbValorSangria.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            float valor = float.Parse(texto) / 100;
            mtbValorSangria.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbValorSangria.SelectionStart = mtbValorSangria.Text.Length;

        }

        private void mbtSalvar_Click(object sender, EventArgs e)
        {
            if (mtbValorSangria.Text =="")
            {
                MessageBox.Show("Por gentileza, digite o valor retirado", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (mtbJustificativa.Text == "")
            {
                MessageBox.Show("Por gentileza, digite o valor retirado", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Sangria.ValueChanged = float.Parse(mtbValorSangria.Text.Replace("R$", ""));
            }
            catch
            {
                MessageBox.Show("Valor digitado é invalido!");
                return;
            }

            AberturaCaixa();
        }
        private async void AberturaCaixa()
        {
            var retorno = await _caixaService.UpdateCaixaTransactionAsync(ValoresAbertura());

            if (!retorno)
            {
                MessageBox.Show("Não foi posivel realizar a sangria");
                return;
            }
            MessageBox.Show("Sangria realizada com sucesso!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private CaixaDTO ValoresAbertura()
        {


            Sangria.ChangeType = "retirada";
            Sangria.ChangeOrigin = "Sangria";
            Sangria.VendedorID = employeer.Id;
            Sangria.ChangeDate = DateTime.Now;
            Sangria.Status = true;
            Sangria.Observations = mtbJustificativa.Text;

            return Sangria;

        }
    }
}
