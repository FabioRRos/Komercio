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
        private readonly ProductService _productService;
        private readonly EmployeeService _employeeService;
        private DescarteProdutoDTO descarteProdutoDTO = new DescarteProdutoDTO();

        public frmDescarte(ProductService productService, EmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _productService = productService;
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
            var temp = await _productService.PutDescarteProduto(descarteProdutoDTO);


            if (temp != false)
            {
                MessageBox.Show("Produto atualizado com sucesso");
            }
        }

        private void ValidationLogin()
        {
            using (frmLogin login = new frmLogin(_employeeService))
            {
                var retorno = login.ShowDialog();

                if (retorno == DialogResult.OK)
                {
                    descarteProdutoDTO.Id_funcionario = login.employeersId;
                }
                else
                {
                    MessageBox.Show("ACESSO NEGADO", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
            }
        }
    }
}
