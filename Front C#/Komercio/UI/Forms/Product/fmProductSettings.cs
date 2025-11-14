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

        private readonly ProductService _productService;
        List<ProductNotificationSettingsDTO> productListChenged = new List<ProductNotificationSettingsDTO>();



        public fmProductSettings(ProductService productService)
        {
            _productService = productService;

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
            productList = await _productService.GetProductNotificationSettingAsync();

            productList =  productList.OrderBy(p => p.Productname).ToList();

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

        private void dgwNotStick_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

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

        private void dgwNotStick_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dgwNotStick.Rows[e.RowIndex].Cells[e.ColumnIndex];
                ProductNotificationSettingsDTO prodChenged = new ProductNotificationSettingsDTO();

                foreach (var item in productListChenged)
                {
                    int idcontrole = Convert.ToInt32(dgwNotStick.Rows[e.RowIndex].Cells["Id_productNotification"].Value);
                    if (idcontrole == item.Id_productNotification)
                    {
                        item.Productstock = Convert.ToInt32(dgwNotStick.Rows[e.RowIndex].Cells["Productstock"].Value);
                        item.Notify_enabled = Convert.ToBoolean(dgwNotStick.Rows[e.RowIndex].Cells["Notify_enabled"].Value);
                        return;
                    }
                }

                prodChenged.Productname = dgwNotStick.Rows[e.RowIndex].Cells["Productname"].Value.ToString();
                prodChenged.Id_productNotification = Convert.ToInt32(dgwNotStick.Rows[e.RowIndex].Cells["Id_productNotification"].Value);
                prodChenged.Productstock = Convert.ToInt32(dgwNotStick.Rows[e.RowIndex].Cells["Productstock"].Value);
                prodChenged.Notify_enabled = Convert.ToBoolean(dgwNotStick.Rows[e.RowIndex].Cells["Notify_enabled"].Value);

                productListChenged.Add(prodChenged);
            }
        }

        private async void mbtnSalvar_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        public async void SaveChanges()
        {


            bool retorno = await _productService.PutProductNotification(productListChenged);

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
