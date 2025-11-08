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
    public partial class fmProductSettings : Form
    {

        private readonly ProductService _productService;


        public fmProductSettings(ProductService productService)
        {
            _productService = productService;

            InitializeComponent();
        }

        private void fmProductSettings_Load(object sender, EventArgs e)
        {
            LoadDGProductSettings();


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
    }
}
