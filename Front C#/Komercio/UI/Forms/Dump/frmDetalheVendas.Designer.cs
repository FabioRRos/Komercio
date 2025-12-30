namespace Komercio.UI.Forms.Dump
{
    partial class frmDetalheVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalheVendas));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mlvListaProduto = new MaterialSkin.Controls.MaterialListView();
            this.gbVenda = new System.Windows.Forms.GroupBox();
            this.mtbPagamento = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbOBS = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbVendedor = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbValorTotal = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbReimpressao = new MaterialSkin.Controls.MaterialButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbVenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.mlvListaProduto, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gbVenda, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 493);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mlvListaProduto
            // 
            this.mlvListaProduto.AutoSizeTable = false;
            this.mlvListaProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mlvListaProduto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mlvListaProduto.Depth = 0;
            this.mlvListaProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlvListaProduto.FullRowSelect = true;
            this.mlvListaProduto.HideSelection = false;
            this.mlvListaProduto.Location = new System.Drawing.Point(3, 153);
            this.mlvListaProduto.MinimumSize = new System.Drawing.Size(200, 100);
            this.mlvListaProduto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mlvListaProduto.MouseState = MaterialSkin.MouseState.OUT;
            this.mlvListaProduto.Name = "mlvListaProduto";
            this.mlvListaProduto.OwnerDraw = true;
            this.mlvListaProduto.Size = new System.Drawing.Size(794, 337);
            this.mlvListaProduto.TabIndex = 0;
            this.mlvListaProduto.UseCompatibleStateImageBehavior = false;
            this.mlvListaProduto.View = System.Windows.Forms.View.Details;
            // 
            // gbVenda
            // 
            this.gbVenda.Controls.Add(this.mtbReimpressao);
            this.gbVenda.Controls.Add(this.mtbPagamento);
            this.gbVenda.Controls.Add(this.mtbOBS);
            this.gbVenda.Controls.Add(this.mtbVendedor);
            this.gbVenda.Controls.Add(this.mtbValorTotal);
            this.gbVenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbVenda.Location = new System.Drawing.Point(3, 3);
            this.gbVenda.Name = "gbVenda";
            this.gbVenda.Size = new System.Drawing.Size(794, 144);
            this.gbVenda.TabIndex = 1;
            this.gbVenda.TabStop = false;
            this.gbVenda.Text = "gbVenda";
            // 
            // mtbPagamento
            // 
            this.mtbPagamento.AnimateReadOnly = false;
            this.mtbPagamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbPagamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbPagamento.Depth = 0;
            this.mtbPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbPagamento.HideSelection = true;
            this.mtbPagamento.Hint = "Forma de pagamento";
            this.mtbPagamento.LeadingIcon = null;
            this.mtbPagamento.Location = new System.Drawing.Point(202, 19);
            this.mtbPagamento.MaxLength = 32767;
            this.mtbPagamento.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbPagamento.Name = "mtbPagamento";
            this.mtbPagamento.PasswordChar = '\0';
            this.mtbPagamento.PrefixSuffixText = null;
            this.mtbPagamento.ReadOnly = true;
            this.mtbPagamento.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbPagamento.SelectedText = "";
            this.mtbPagamento.SelectionLength = 0;
            this.mtbPagamento.SelectionStart = 0;
            this.mtbPagamento.ShortcutsEnabled = true;
            this.mtbPagamento.Size = new System.Drawing.Size(168, 48);
            this.mtbPagamento.TabIndex = 3;
            this.mtbPagamento.TabStop = false;
            this.mtbPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbPagamento.TrailingIcon = null;
            this.mtbPagamento.UseSystemPasswordChar = false;
            // 
            // mtbOBS
            // 
            this.mtbOBS.AnimateReadOnly = false;
            this.mtbOBS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbOBS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbOBS.Depth = 0;
            this.mtbOBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbOBS.HideSelection = true;
            this.mtbOBS.Hint = "Obs da venda.";
            this.mtbOBS.LeadingIcon = null;
            this.mtbOBS.Location = new System.Drawing.Point(6, 83);
            this.mtbOBS.MaxLength = 32767;
            this.mtbOBS.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbOBS.Name = "mtbOBS";
            this.mtbOBS.PasswordChar = '\0';
            this.mtbOBS.PrefixSuffixText = null;
            this.mtbOBS.ReadOnly = true;
            this.mtbOBS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbOBS.SelectedText = "";
            this.mtbOBS.SelectionLength = 0;
            this.mtbOBS.SelectionStart = 0;
            this.mtbOBS.ShortcutsEnabled = true;
            this.mtbOBS.Size = new System.Drawing.Size(545, 48);
            this.mtbOBS.TabIndex = 2;
            this.mtbOBS.TabStop = false;
            this.mtbOBS.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbOBS.TrailingIcon = null;
            this.mtbOBS.UseSystemPasswordChar = false;
            // 
            // mtbVendedor
            // 
            this.mtbVendedor.AnimateReadOnly = false;
            this.mtbVendedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbVendedor.Depth = 0;
            this.mtbVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbVendedor.HideSelection = true;
            this.mtbVendedor.Hint = "Vendedor";
            this.mtbVendedor.LeadingIcon = null;
            this.mtbVendedor.Location = new System.Drawing.Point(389, 19);
            this.mtbVendedor.MaxLength = 32767;
            this.mtbVendedor.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbVendedor.Name = "mtbVendedor";
            this.mtbVendedor.PasswordChar = '\0';
            this.mtbVendedor.PrefixSuffixText = null;
            this.mtbVendedor.ReadOnly = true;
            this.mtbVendedor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbVendedor.SelectedText = "";
            this.mtbVendedor.SelectionLength = 0;
            this.mtbVendedor.SelectionStart = 0;
            this.mtbVendedor.ShortcutsEnabled = true;
            this.mtbVendedor.Size = new System.Drawing.Size(162, 48);
            this.mtbVendedor.TabIndex = 1;
            this.mtbVendedor.TabStop = false;
            this.mtbVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbVendedor.TrailingIcon = null;
            this.mtbVendedor.UseSystemPasswordChar = false;
            // 
            // mtbValorTotal
            // 
            this.mtbValorTotal.AnimateReadOnly = false;
            this.mtbValorTotal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbValorTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbValorTotal.Depth = 0;
            this.mtbValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbValorTotal.HideSelection = true;
            this.mtbValorTotal.Hint = "Valor total da venda";
            this.mtbValorTotal.LeadingIcon = null;
            this.mtbValorTotal.Location = new System.Drawing.Point(6, 19);
            this.mtbValorTotal.MaxLength = 32767;
            this.mtbValorTotal.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbValorTotal.Name = "mtbValorTotal";
            this.mtbValorTotal.PasswordChar = '\0';
            this.mtbValorTotal.PrefixSuffixText = null;
            this.mtbValorTotal.ReadOnly = true;
            this.mtbValorTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbValorTotal.SelectedText = "";
            this.mtbValorTotal.SelectionLength = 0;
            this.mtbValorTotal.SelectionStart = 0;
            this.mtbValorTotal.ShortcutsEnabled = true;
            this.mtbValorTotal.Size = new System.Drawing.Size(180, 48);
            this.mtbValorTotal.TabIndex = 0;
            this.mtbValorTotal.TabStop = false;
            this.mtbValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbValorTotal.TrailingIcon = null;
            this.mtbValorTotal.UseSystemPasswordChar = false;
            // 
            // mtbReimpressao
            // 
            this.mtbReimpressao.AutoSize = false;
            this.mtbReimpressao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbReimpressao.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbReimpressao.Depth = 0;
            this.mtbReimpressao.HighEmphasis = true;
            this.mtbReimpressao.Icon = null;
            this.mtbReimpressao.Location = new System.Drawing.Point(595, 19);
            this.mtbReimpressao.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbReimpressao.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbReimpressao.Name = "mtbReimpressao";
            this.mtbReimpressao.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbReimpressao.Size = new System.Drawing.Size(164, 48);
            this.mtbReimpressao.TabIndex = 4;
            this.mtbReimpressao.Text = "Imprimir cupom";
            this.mtbReimpressao.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbReimpressao.UseAccentColor = false;
            this.mtbReimpressao.UseVisualStyleBackColor = true;
            this.mtbReimpressao.Click += new System.EventHandler(this.mtbReimpressao_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // frmDetalheVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDetalheVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes venda";
            this.Load += new System.EventHandler(this.frmDetalheVendas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbVenda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialListView mlvListaProduto;
        private System.Windows.Forms.GroupBox gbVenda;
        private MaterialSkin.Controls.MaterialTextBox2 mtbPagamento;
        private MaterialSkin.Controls.MaterialTextBox2 mtbOBS;
        private MaterialSkin.Controls.MaterialTextBox2 mtbVendedor;
        private MaterialSkin.Controls.MaterialTextBox2 mtbValorTotal;
        private MaterialSkin.Controls.MaterialButton mtbReimpressao;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}