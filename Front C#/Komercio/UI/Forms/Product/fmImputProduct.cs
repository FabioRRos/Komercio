using Komercio.Models;
using Komercio.Services;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komercio.UI.Forms.Product
{
    public partial class fmImputProduct : Form
    {
        private readonly ProductService _productService;
        public fmImputProduct(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }
        private BindingList<ProductDTO> productListUpdateStock = new BindingList<ProductDTO>();
        private void msOptionsInput_CheckedChanged(object sender, EventArgs e)
        {
            if (msOptionsInput.Checked == false)
            {
                mbtSave.Enabled = true;
                mtbStock.Enabled = true;
                mtbStock.Text = "0";
            }
            if (msOptionsInput.Checked == true)
            {
                mbtSave.Enabled = false;
                mtbStock.Enabled = false;
                mtbStock.Text = "1";
            }
        }

        private void mtbCodBar_Enter(object sender, EventArgs e)
        {

        }

        private async void mtbCodBar_TextChanged(object sender, EventArgs e)
        {
            if (msOptionsInput.Checked == true)
            {
                if (mtbCodBar.Text =="")
                {
                    return;
                }
                try
                {
                    var temp = await _productService.PutProductInStock(mtbCodBar.Text, 1);
                    productListUpdateStock.Add(temp);
                    await Task.Delay(500);
                    mtbCodBar.Text = "";
                    UpdateDataGrid();
                    return;

                }
                catch
                {

                }

            }

        }


        private void UpdateDataGrid()
        {

            dgUpdateList.DataSource = productListUpdateStock;
            dgUpdateList.Columns["idProduct"].Visible = false;
            dgUpdateList.Columns["productPrice"].Visible = false;
            dgUpdateList.Columns["productCodBar"].Visible = false;
            dgUpdateList.Columns["productGroup"].Visible = false;
            dgUpdateList.Columns["productSubgroup"].Visible = false;
            dgUpdateList.Columns["productStock"].Visible = false;
            dgUpdateList.Columns["productStatus"].Visible = false;
            dgUpdateList.Columns["productName"].HeaderText = "Produto";
            dgUpdateList.Columns["productName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgUpdateList.AllowUserToAddRows = false;
        }

        private void fmImputProduct_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

        }

        private async void mbtSave_Click(object sender, EventArgs e)
        {
            var stockToAdd = int.Parse(mtbStock.Text);
            var temp = await _productService.PutProductInStock(mtbCodBar.Text, stockToAdd);
            productListUpdateStock.Add(temp);
            await Task.Delay(500);
            mtbCodBar.Text = "";
            UpdateDataGrid();
            return;
        }
    }
}
