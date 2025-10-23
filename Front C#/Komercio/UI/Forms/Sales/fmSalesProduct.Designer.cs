namespace Komercio.UI.Forms.Sales
{
    partial class fmSalesProduct
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Cód Barras");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Produto");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Preço unitário");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Quantidade");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Preço final");
            this.mepSearchProduct = new MaterialSkin.Controls.MaterialExpansionPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.materialTextBox22 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTextBox21 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTextBox23 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTextBox24 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTextBox25 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTextBox26 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTextBox27 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.mtbTotalCarrinho = new MaterialSkin.Controls.MaterialTextBox2();
            this.mepSearchProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mepSearchProduct
            // 
            this.mepSearchProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mepSearchProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mepSearchProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mepSearchProduct.CancelButtonText = "Cancelar";
            this.mepSearchProduct.Collapse = true;
            this.mepSearchProduct.Controls.Add(this.dataGridView1);
            this.mepSearchProduct.Controls.Add(this.materialTextBox22);
            this.mepSearchProduct.Controls.Add(this.materialTextBox21);
            this.mepSearchProduct.Depth = 0;
            this.mepSearchProduct.Description = "";
            this.mepSearchProduct.ExpandHeight = 401;
            this.mepSearchProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mepSearchProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mepSearchProduct.Location = new System.Drawing.Point(507, 32);
            this.mepSearchProduct.Margin = new System.Windows.Forms.Padding(16, 1, 16, 0);
            this.mepSearchProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.mepSearchProduct.Name = "mepSearchProduct";
            this.mepSearchProduct.Padding = new System.Windows.Forms.Padding(24, 64, 24, 16);
            this.mepSearchProduct.ShowCollapseExpand = false;
            this.mepSearchProduct.Size = new System.Drawing.Size(286, 48);
            this.mepSearchProduct.TabIndex = 1;
            this.mepSearchProduct.Title = "Busca manual de produtos";
            this.mepSearchProduct.UseAccentColor = true;
            this.mepSearchProduct.ValidationButtonText = "INCLUIR";
            this.mepSearchProduct.Paint += new System.Windows.Forms.PaintEventHandler(this.mepSearchProduct_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 209);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(267, 132);
            this.dataGridView1.TabIndex = 4;
            // 
            // materialTextBox22
            // 
            this.materialTextBox22.AnimateReadOnly = false;
            this.materialTextBox22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox22.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox22.Depth = 0;
            this.materialTextBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox22.HelperText = "Selecione o item depois incluir";
            this.materialTextBox22.HideSelection = true;
            this.materialTextBox22.Hint = "Descrução do produto";
            this.materialTextBox22.LeadingIcon = null;
            this.materialTextBox22.Location = new System.Drawing.Point(8, 122);
            this.materialTextBox22.MaxLength = 32767;
            this.materialTextBox22.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox22.Name = "materialTextBox22";
            this.materialTextBox22.PasswordChar = '\0';
            this.materialTextBox22.PrefixSuffixText = null;
            this.materialTextBox22.ReadOnly = false;
            this.materialTextBox22.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox22.SelectedText = "";
            this.materialTextBox22.SelectionLength = 0;
            this.materialTextBox22.SelectionStart = 0;
            this.materialTextBox22.ShortcutsEnabled = true;
            this.materialTextBox22.ShowAssistiveText = true;
            this.materialTextBox22.Size = new System.Drawing.Size(267, 64);
            this.materialTextBox22.TabIndex = 3;
            this.materialTextBox22.TabStop = false;
            this.materialTextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox22.TrailingIcon = null;
            this.materialTextBox22.UseSystemPasswordChar = false;
            // 
            // materialTextBox21
            // 
            this.materialTextBox21.AnimateReadOnly = false;
            this.materialTextBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox21.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox21.Depth = 0;
            this.materialTextBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox21.HelperText = "Selecione o item depois incluir";
            this.materialTextBox21.HideSelection = true;
            this.materialTextBox21.Hint = "Código de barras";
            this.materialTextBox21.LeadingIcon = null;
            this.materialTextBox21.Location = new System.Drawing.Point(8, 53);
            this.materialTextBox21.MaxLength = 32767;
            this.materialTextBox21.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox21.Name = "materialTextBox21";
            this.materialTextBox21.PasswordChar = '\0';
            this.materialTextBox21.PrefixSuffixText = null;
            this.materialTextBox21.ReadOnly = false;
            this.materialTextBox21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox21.SelectedText = "";
            this.materialTextBox21.SelectionLength = 0;
            this.materialTextBox21.SelectionStart = 0;
            this.materialTextBox21.ShortcutsEnabled = true;
            this.materialTextBox21.ShowAssistiveText = true;
            this.materialTextBox21.Size = new System.Drawing.Size(267, 64);
            this.materialTextBox21.TabIndex = 2;
            this.materialTextBox21.TabStop = false;
            this.materialTextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox21.TrailingIcon = null;
            this.materialTextBox21.UseSystemPasswordChar = false;
            this.materialTextBox21.Click += new System.EventHandler(this.materialTextBox21_Click);
            // 
            // materialTextBox23
            // 
            this.materialTextBox23.AnimateReadOnly = true;
            this.materialTextBox23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox23.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox23.Depth = 0;
            this.materialTextBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox23.HelperText = "Código de barras";
            this.materialTextBox23.HideSelection = true;
            this.materialTextBox23.Hint = "Código de Barras";
            this.materialTextBox23.LeadingIcon = null;
            this.materialTextBox23.Location = new System.Drawing.Point(12, 35);
            this.materialTextBox23.MaxLength = 32767;
            this.materialTextBox23.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox23.Name = "materialTextBox23";
            this.materialTextBox23.PasswordChar = '\0';
            this.materialTextBox23.PrefixSuffixText = null;
            this.materialTextBox23.ReadOnly = false;
            this.materialTextBox23.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox23.SelectedText = "";
            this.materialTextBox23.SelectionLength = 0;
            this.materialTextBox23.SelectionStart = 0;
            this.materialTextBox23.ShortcutsEnabled = true;
            this.materialTextBox23.ShowAssistiveText = true;
            this.materialTextBox23.Size = new System.Drawing.Size(151, 64);
            this.materialTextBox23.TabIndex = 2;
            this.materialTextBox23.TabStop = false;
            this.materialTextBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox23.TrailingIcon = null;
            this.materialTextBox23.UseSystemPasswordChar = false;
            // 
            // materialTextBox24
            // 
            this.materialTextBox24.AnimateReadOnly = false;
            this.materialTextBox24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox24.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox24.Depth = 0;
            this.materialTextBox24.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox24.HideSelection = true;
            this.materialTextBox24.Hint = "Descrição do produto";
            this.materialTextBox24.LeadingIcon = null;
            this.materialTextBox24.Location = new System.Drawing.Point(182, 35);
            this.materialTextBox24.MaxLength = 32767;
            this.materialTextBox24.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox24.Name = "materialTextBox24";
            this.materialTextBox24.PasswordChar = '\0';
            this.materialTextBox24.PrefixSuffixText = null;
            this.materialTextBox24.ReadOnly = false;
            this.materialTextBox24.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox24.SelectedText = "";
            this.materialTextBox24.SelectionLength = 0;
            this.materialTextBox24.SelectionStart = 0;
            this.materialTextBox24.ShortcutsEnabled = true;
            this.materialTextBox24.Size = new System.Drawing.Size(306, 48);
            this.materialTextBox24.TabIndex = 3;
            this.materialTextBox24.TabStop = false;
            this.materialTextBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox24.TrailingIcon = null;
            this.materialTextBox24.UseSystemPasswordChar = false;
            // 
            // materialTextBox25
            // 
            this.materialTextBox25.AnimateReadOnly = false;
            this.materialTextBox25.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox25.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox25.Depth = 0;
            this.materialTextBox25.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox25.HideSelection = true;
            this.materialTextBox25.Hint = "Preço unitário";
            this.materialTextBox25.LeadingIcon = null;
            this.materialTextBox25.Location = new System.Drawing.Point(12, 126);
            this.materialTextBox25.MaxLength = 32767;
            this.materialTextBox25.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox25.Name = "materialTextBox25";
            this.materialTextBox25.PasswordChar = '\0';
            this.materialTextBox25.PrefixSuffixText = null;
            this.materialTextBox25.ReadOnly = false;
            this.materialTextBox25.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox25.SelectedText = "";
            this.materialTextBox25.SelectionLength = 0;
            this.materialTextBox25.SelectionStart = 0;
            this.materialTextBox25.ShortcutsEnabled = true;
            this.materialTextBox25.Size = new System.Drawing.Size(151, 48);
            this.materialTextBox25.TabIndex = 4;
            this.materialTextBox25.TabStop = false;
            this.materialTextBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox25.TrailingIcon = null;
            this.materialTextBox25.UseSystemPasswordChar = false;
            // 
            // materialTextBox26
            // 
            this.materialTextBox26.AnimateReadOnly = false;
            this.materialTextBox26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox26.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox26.Depth = 0;
            this.materialTextBox26.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox26.HideSelection = true;
            this.materialTextBox26.Hint = "Quantidade";
            this.materialTextBox26.LeadingIcon = null;
            this.materialTextBox26.Location = new System.Drawing.Point(182, 126);
            this.materialTextBox26.MaxLength = 32767;
            this.materialTextBox26.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox26.Name = "materialTextBox26";
            this.materialTextBox26.PasswordChar = '\0';
            this.materialTextBox26.PrefixSuffixText = null;
            this.materialTextBox26.ReadOnly = false;
            this.materialTextBox26.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox26.SelectedText = "";
            this.materialTextBox26.SelectionLength = 0;
            this.materialTextBox26.SelectionStart = 0;
            this.materialTextBox26.ShortcutsEnabled = true;
            this.materialTextBox26.Size = new System.Drawing.Size(151, 48);
            this.materialTextBox26.TabIndex = 5;
            this.materialTextBox26.TabStop = false;
            this.materialTextBox26.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox26.TrailingIcon = null;
            this.materialTextBox26.UseSystemPasswordChar = false;
            // 
            // materialTextBox27
            // 
            this.materialTextBox27.AnimateReadOnly = false;
            this.materialTextBox27.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox27.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox27.Depth = 0;
            this.materialTextBox27.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox27.HideSelection = true;
            this.materialTextBox27.Hint = "Preço final";
            this.materialTextBox27.LeadingIcon = null;
            this.materialTextBox27.Location = new System.Drawing.Point(339, 126);
            this.materialTextBox27.MaxLength = 32767;
            this.materialTextBox27.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox27.Name = "materialTextBox27";
            this.materialTextBox27.PasswordChar = '\0';
            this.materialTextBox27.PrefixSuffixText = null;
            this.materialTextBox27.ReadOnly = false;
            this.materialTextBox27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox27.SelectedText = "";
            this.materialTextBox27.SelectionLength = 0;
            this.materialTextBox27.SelectionStart = 0;
            this.materialTextBox27.ShortcutsEnabled = true;
            this.materialTextBox27.Size = new System.Drawing.Size(151, 48);
            this.materialTextBox27.TabIndex = 6;
            this.materialTextBox27.TabStop = false;
            this.materialTextBox27.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox27.TrailingIcon = null;
            this.materialTextBox27.UseSystemPasswordChar = false;
            // 
            // materialListView1
            // 
            this.materialListView1.AutoSizeTable = false;
            this.materialListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView1.Depth = 0;
            this.materialListView1.FullRowSelect = true;
            this.materialListView1.HideSelection = false;
            this.materialListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.materialListView1.Location = new System.Drawing.Point(12, 192);
            this.materialListView1.MinimumSize = new System.Drawing.Size(200, 100);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.Size = new System.Drawing.Size(478, 243);
            this.materialListView1.TabIndex = 7;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
            // 
            // mtbTotalCarrinho
            // 
            this.mtbTotalCarrinho.AnimateReadOnly = true;
            this.mtbTotalCarrinho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbTotalCarrinho.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbTotalCarrinho.Depth = 0;
            this.mtbTotalCarrinho.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbTotalCarrinho.HideSelection = true;
            this.mtbTotalCarrinho.Hint = "Valor total do carrinho";
            this.mtbTotalCarrinho.LeadingIcon = global::Komercio.Properties.Resources.Carrinho;
            this.mtbTotalCarrinho.Location = new System.Drawing.Point(507, 126);
            this.mtbTotalCarrinho.MaxLength = 32767;
            this.mtbTotalCarrinho.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbTotalCarrinho.Name = "mtbTotalCarrinho";
            this.mtbTotalCarrinho.PasswordChar = '\0';
            this.mtbTotalCarrinho.PrefixSuffixText = null;
            this.mtbTotalCarrinho.ReadOnly = false;
            this.mtbTotalCarrinho.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbTotalCarrinho.SelectedText = "";
            this.mtbTotalCarrinho.SelectionLength = 0;
            this.mtbTotalCarrinho.SelectionStart = 0;
            this.mtbTotalCarrinho.ShortcutsEnabled = true;
            this.mtbTotalCarrinho.Size = new System.Drawing.Size(286, 48);
            this.mtbTotalCarrinho.TabIndex = 13;
            this.mtbTotalCarrinho.TabStop = false;
            this.mtbTotalCarrinho.Text = "R$ 50,00";
            this.mtbTotalCarrinho.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbTotalCarrinho.TrailingIcon = null;
            this.mtbTotalCarrinho.UseSystemPasswordChar = false;
            // 
            // fmSalesProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mepSearchProduct);
            this.Controls.Add(this.mtbTotalCarrinho);
            this.Controls.Add(this.materialListView1);
            this.Controls.Add(this.materialTextBox27);
            this.Controls.Add(this.materialTextBox26);
            this.Controls.Add(this.materialTextBox25);
            this.Controls.Add(this.materialTextBox24);
            this.Controls.Add(this.materialTextBox23);
            this.Name = "fmSalesProduct";
            this.Text = "fmSalesProduct";
            this.Load += new System.EventHandler(this.fmSalesProduct_Load);
            this.mepSearchProduct.ResumeLayout(false);
            this.mepSearchProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialExpansionPanel mepSearchProduct;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox22;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox23;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox24;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox25;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox26;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox27;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private MaterialSkin.Controls.MaterialTextBox2 mtbTotalCarrinho;
    }
}