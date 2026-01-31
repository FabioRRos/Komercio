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
using static System.Windows.Forms.LinkLabel;

namespace Komercio.UI.Forms.Product
{
    public partial class fmProductSettings : Form
    {

        List<ProductNotificationSettingsDTO> productListChenged = new List<ProductNotificationSettingsDTO>();
        private readonly ProdutoApp _produtoApp;

        public fmProductSettings(ProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;

            InitializeComponent();
        }

        private void fmProductSettings_Load(object sender, EventArgs e)
        {
            LoadDGProductSettings();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;


        }
        public void DataGridStyle()
        {

            dgwNotStick.BackgroundColor = Color.White;
            dgwNotStick.BorderStyle = BorderStyle.None;
            dgwNotStick.RowHeadersVisible = false;
            dgwNotStick.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        List<ProductNotificationSettingsDTO> productList = new List<ProductNotificationSettingsDTO>();
        private async void LoadDGProductSettings()
        {
            productList = await _produtoApp.ListaDeProdutosParaNotificacao();
            dgwNotStick.DataSource = productList;
            DataGridStyle();
            DGPorudctLayout();
        }

        private void DGPorudctLayout()
        {
            dgwNotStick.Columns["Id_productNotification"].Visible = false;
            dgwNotStick.Columns["Productname"].HeaderText = "Produto";
            dgwNotStick.Columns["Productstock"].HeaderText = "Notificar em:";
            dgwNotStick.Columns["Notify_enabled"].HeaderText = "Ativar Notificação?";
            dgwNotStick.Columns["Productname"].ReadOnly = true;
        }
        private void dgwNotStick_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgwNotStick.CurrentCell.ColumnIndex == 2) 
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= Tb_KeyPress; 
                    tb.KeyPress += Tb_KeyPress;
                }
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Só permite números, backspace e vírgula
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ',')
            {
                e.Handled = true; // bloqueia o caractere
            }
        }
        //Esse cara aqui é complicado kkk
        private void dgwNotStick_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // se linha e coluna forem maiores que 0 (tem itens) inicio o processo.
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Pega a celula clicada no DataGridView
                DataGridViewCell cell = dgwNotStick.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Cria uma nova variavel (na vdd obj~) de notificação de produto
                ProductNotificationSettingsDTO prodChenged = new ProductNotificationSettingsDTO();

                // corre a lista de produtos já alterados
                foreach (var item in productListChenged)
                {
                    // Pega o Id da notificação da linha clicada
                    int idcontrole = Convert.ToInt32(dgwNotStick.Rows[e.RowIndex].Cells["Id_productNotification"].Value);

                    // Verifica se já existe na linha alterada
                    if (idcontrole == item.Id_productNotification)
                    {
                        // Atualiza os valores
                        //Lembrando que ele atualiza tanto se habilitou a notificação quanto a
                        //quantidade de itens em estoque que ele quer marcar para notificar.

                        item.Productstock = Convert.ToInt32(dgwNotStick.Rows[e.RowIndex].Cells["Productstock"].Value);
                        item.Notify_enabled = Convert.ToBoolean(dgwNotStick.Rows[e.RowIndex].Cells["Notify_enabled"].Value);

                        // Sai porque os que precisava atualizar já foram atualizados
                        return;
                    }
                }

                // Se não encontrou o produto na lista cria um...
                prodChenged.Productname = dgwNotStick.Rows[e.RowIndex].Cells["Productname"].Value.ToString();
                prodChenged.Id_productNotification = Convert.ToInt32(dgwNotStick.Rows[e.RowIndex].Cells["Id_productNotification"].Value);
                prodChenged.Productstock = Convert.ToInt32(dgwNotStick.Rows[e.RowIndex].Cells["Productstock"].Value);
                prodChenged.Notify_enabled = Convert.ToBoolean(dgwNotStick.Rows[e.RowIndex].Cells["Notify_enabled"].Value);

                // ... e adiciona o novo produto alterado à lista
                productListChenged.Add(prodChenged);

                // fim kk
            }
        }

        private async void mbtnSalvar_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        public async void SaveChanges()
        {


            bool retorno = await _produtoApp.AtualizarListaDeProdutosParaNotificacao(productListChenged);

            if (retorno)
            {
                MessageBox.Show("Configurações salva com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Alguma coisa deu errado.... Tente novamente mais tarde!", "Estranho...", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Close();
        }
    }
}
