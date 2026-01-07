using Komercio.ApplicationLayer;
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
        private readonly ProdutoApp _produtoApp;
        public fmImputProduct( ProdutoApp produtoApp)
        {
            InitializeComponent();
           

            _produtoApp = produtoApp;
        }
        private void msOptionsInput_CheckedChanged(object sender, EventArgs e)
        {
            if (msOptionsInput.Checked == false)
            {
                mbtSave.Enabled = true;
                mtbStock.Enabled = true;
                mtbStock.Text = "0";
                mtbprecoentrada.Enabled = true;
            }
            if (msOptionsInput.Checked == true)
            {
                mbtSave.Enabled = false;
                mtbStock.Enabled = false;
                mtbStock.Text = "1";
                mtbprecoentrada.Enabled = false;
            }
        }


        //AQUI EU DOU A ENTRADA SE TUDO DER CERTO SE DER ERRO, AI EU TRATO.
        //Entrada automática
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
                    var temp = await _produtoApp.EntradaEstoqueCodigoDeBarras(mtbCodBar.Text,1,0); // Aqui vou deixar zero
                                                                                                   // pois em entrada automatica não há
                                                                                                   // a adição de valores.

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
        //garante que o form fique do tamanho que foi planejado.
        private void fmImputProduct_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }
        //entrada manual
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

            int quantidade = 0;
            try
            {
                quantidade = int.Parse(mtbStock.Text);
            }
            catch
            {
                MessageBox.Show("Quantidade invalida!!!");
            }

            float preco = 0;
            try
            {

            preco = float.Parse(mtbprecoentrada.Text.Replace("R$", "").Replace(".", "").Replace(",", ".").Trim())/100;
            }
            catch
            {
                
            }

            var temp = await _produtoApp.EntradaEstoqueCodigoDeBarras(mtbCodBar.Text, quantidade, preco); 

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

        private void mtbprecoentrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mtbprecoentrada_TextChanged(object sender, EventArgs e)
        {
            string texto = mtbprecoentrada.Text.Replace("R$", "").Replace(",", "").Replace(".", "").TrimStart('0');

            if (texto.Length == 0)
                texto = "0";

            decimal valor = Convert.ToDecimal(texto) / 100;
            mtbprecoentrada.Text = string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", valor);
            mtbprecoentrada.SelectionStart = mtbprecoentrada.Text.Length;
        }
    }
}
