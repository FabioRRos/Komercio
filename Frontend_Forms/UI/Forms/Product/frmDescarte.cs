using Komercio.ApplicationLayer;
using Komercio.Models;
using Komercio.Services;
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

namespace Komercio.UI.Forms.Product
{
    public partial class frmDescarte : Form
    {


        private readonly EmployeeServiceApp _employeeServiceApp;
        private readonly ProdutoApp _produtoApp;

        private DescarteProdutoDTO descarteProdutoDTO = new DescarteProdutoDTO();

        public frmDescarte(ProdutoApp produtoApp,
                            EmployeeServiceApp employeeServiceApp)
        {
            InitializeComponent();


            _employeeServiceApp = employeeServiceApp;
            _produtoApp = produtoApp;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void frmDescarte_Load(object sender, EventArgs e)
        {
    
            ValidationLogin();
        }

        private void mbtSalvar_Click(object sender, EventArgs e)
        {
            if (mtbCodBarras.Text =="")
            {
                MessageBox.Show("Por gentileza, digite o código de barras!","ATENÇÃO!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mtbJustificativa.Text =="")
            {
                MessageBox.Show("Por gentileza, digite uma justificativa do descarte!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            descarteProdutoDTO.CodBarProduto = mtbCodBarras.Text;
            descarteProdutoDTO.Justificativa = mtbJustificativa.Text;

            UpdateProduct();
            this.Close();
        }
        

        private async void UpdateProduct()
        {
            var temp = await _produtoApp.AtualizaStatusDoProdutoEmDescarte(descarteProdutoDTO);


            if (temp != false)
            {
                MessageBox.Show("Produto atualizado com sucesso");
            }
        }

        private void ValidationLogin()
        {
                var (retorno,id) = _employeeServiceApp.ValidaLogin();

                if (retorno == DialogResult.OK)
                {
                    descarteProdutoDTO.Id_funcionario = id;
                }
                else
                {
                    MessageBox.Show("ACESSO NEGADO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
        }
    }
}
