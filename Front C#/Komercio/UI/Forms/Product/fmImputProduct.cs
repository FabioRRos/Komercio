using Komercio.Models;
using Komercio.Services;
using MaterialSkin.Controls;
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

                    if (temp == null)
                    {                   
                        mtbCodBar.Text = "";
                        return;
                    }
                    else
                    {
                        mlvInput.Items.Add(1 + " -  " +  temp.productName.PadRight(200));
                       
                    }
                    await Task.Delay(500);
                    mtbCodBar.Text = "";
                    return;
                }
                catch
                {

                }
            }
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

            if (mtbCodBar.Text == "")
            {
                MessageBox.Show("O código de barras não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (stockToAdd <= 0)
            {
                MessageBox.Show("O estoque a ser adicionado deve ser maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var temp = await _productService.PutProductInStock(mtbCodBar.Text, stockToAdd);

            if (temp == null)
            {
                MessageBox.Show("Produto não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtbCodBar.Text = "";
                return;
            }
            else
            {
                mlvInput.Items.Add(stockToAdd + " -  " + temp.productName);

            }
           return;
        }
    }
}
