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
    public partial class frmDescarte : Form
    {
        private readonly ProductService _productService;

        public frmDescarte(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private void frmDescarte_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
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


            UpdateProduct();
            this.Close();
        }
        

        private async void UpdateProduct()
        {
            var temp = await _productService.PutProductInStock(mtbCodBarras.Text, 1);


            if (temp != null)
            {
                MessageBox.Show("Produto atualizado com sucesso");
            }
        }
    }
}
