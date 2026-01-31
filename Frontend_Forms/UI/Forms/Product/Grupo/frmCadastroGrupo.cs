using Komercio.ApplicationLayer;
using Komercio.Models;
using Komercio.Services;
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
    public partial class frmCadastroGrupo : Form
    {
        private ProductgroupDTO productGroup = new ProductgroupDTO();
        private readonly ProdutoApp _produtoApp;
        public frmCadastroGrupo(ProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;
            InitializeComponent();
        }

        private void frmCadastroGrupo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private async void CadastroGrupo()
        {
            bool retorno;
            retorno = await _produtoApp.CadastrarGrupoDeProduto(productGroup);
            if (retorno) MessageBox.Show("Grupo Criado com sucesso!");
            return;
        }

        private void mbtSalvar_Click(object sender, EventArgs e)
        {
            if (mtbGrupo.Text == "") MessageBox.Show("Por gentileza, digite o nome do grupo!!", "Atenção!!");

            productGroup.ProductgroupName = mtbGrupo.Text;

            CadastroGrupo();

        }
    }
}
