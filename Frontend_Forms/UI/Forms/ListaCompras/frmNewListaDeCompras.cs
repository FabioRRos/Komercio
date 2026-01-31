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

namespace Komercio.UI.Forms.ListaCompras
{
    public partial class frmNewListaDeCompras : Form
    {
        private readonly ListaComprasApp _listaComprasApp;
        public  ServiceResponse<ListaComprasDTO> serviceResponse;


        public frmNewListaDeCompras(ListaComprasApp listacomprasApp)
        {
            _listaComprasApp = listacomprasApp;

            InitializeComponent();
        }

        private void mtbNomeLista_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (mtbNomeLista.Text == "")
            {
                MessageBox.Show("Por gentileza, digite o nome da lista de compras","Atenção",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CriarLista();




        }

        /// <summary>
        /// Cria a lista.
        /// </summary>
        public async Task CriarLista()
        {
            var newLista = new ListaComprasDTO();
            newLista.NomeDaLista = mtbNomeLista.Text;
            newLista.StatusLista = true;

            serviceResponse =  await _listaComprasApp.CriarListaComprasApp(newLista);// esse cara que está dando erro


            if (!serviceResponse.Sucesso)
            {
                MessageBox.Show("Não consegui criar, tente novamente mais tarde!", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Lista criada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            return;
        }
    }
}
