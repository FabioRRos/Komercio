using Komercio.ApplicationLayer;
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

namespace Komercio.UI.Forms.settings
{
    public partial class frmParametros : Form
    {
        private readonly ParametrosApp _parametrosServiceApp;

        public List<ParametroDTO> parametro = new List<ParametroDTO>();
        public List<ParametroDTO> parametroAtualizado = new List<ParametroDTO>();

        public frmParametros(ParametrosApp parametrosServiceApp)
        {
            _parametrosServiceApp = parametrosServiceApp;
            InitializeComponent();
        }

        private void frmParametros_Load(object sender, EventArgs e)
        {
            BuscarParametros();
        }



        private async void BuscarParametros() 
        {
            parametro = await _parametrosServiceApp.RetornarListaDeParametros();

            CarregarTabela(parametro);
        }


        private async void SalvaParametros()
        {
            dgwTabela.EndEdit();
            await _parametrosServiceApp.AtualizaStatusDaListaDeParametros(parametro);

           CarregarTabela(parametro);
        }


        private async void CarregarTabela(List<ParametroDTO> parametro)
        {
            dgwTabela.DataSource = parametro;

            dgwTabela.Columns["Parametro_name"].HeaderText = "Parâmetro";
            dgwTabela.Columns["Parametro_status"].HeaderText = "Status";
            dgwTabela.Columns["Parametro_Id"].Visible = false;

            dgwTabela.Columns["Parametro_name"].AutoSizeMode = (DataGridViewAutoSizeColumnMode)DataGridViewAutoSizeColumnsMode.AllCells;
            dgwTabela.RowHeadersVisible = false;
           
            dgwTabela.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwTabela.BackgroundColor = Color.White;
            dgwTabela.BorderStyle = BorderStyle.None;
        }

        private void mbtnSalvar_Click(object sender, EventArgs e)
        {
            SalvaParametros();
        }


    }
}
