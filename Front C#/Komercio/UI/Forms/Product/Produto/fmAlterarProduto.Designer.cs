namespace Komercio.UI.Forms.Product.Produto
{
    partial class fmAlterarProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAlterarProduto));
            this.mcbSubGroup = new MaterialSkin.Controls.MaterialComboBox();
            this.mcbGroup = new MaterialSkin.Controls.MaterialComboBox();
            this.mtbProductStock = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtSaveProduct = new MaterialSkin.Controls.MaterialButton();
            this.msProductStatus = new MaterialSkin.Controls.MaterialSwitch();
            this.mtbProductCodeBar = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbProductPrice = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbProductName = new MaterialSkin.Controls.MaterialTextBox2();
            this.mepBuscaDescricao = new MaterialSkin.Controls.MaterialExpansionPanel();
            this.dgwListaProdutos = new System.Windows.Forms.DataGridView();
            this.mtbBusca = new MaterialSkin.Controls.MaterialTextBox2();
            this.mepBuscaDescricao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // mcbSubGroup
            // 
            this.mcbSubGroup.AutoResize = false;
            this.mcbSubGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mcbSubGroup.Depth = 0;
            this.mcbSubGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mcbSubGroup.DropDownHeight = 174;
            this.mcbSubGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcbSubGroup.DropDownWidth = 121;
            this.mcbSubGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mcbSubGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mcbSubGroup.FormattingEnabled = true;
            this.mcbSubGroup.Hint = "Subgrupo do produto";
            this.mcbSubGroup.IntegralHeight = false;
            this.mcbSubGroup.ItemHeight = 43;
            this.mcbSubGroup.Location = new System.Drawing.Point(265, 157);
            this.mcbSubGroup.MaxDropDownItems = 4;
            this.mcbSubGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.mcbSubGroup.Name = "mcbSubGroup";
            this.mcbSubGroup.Size = new System.Drawing.Size(197, 49);
            this.mcbSubGroup.StartIndex = 0;
            this.mcbSubGroup.TabIndex = 13;
            // 
            // mcbGroup
            // 
            this.mcbGroup.AutoResize = false;
            this.mcbGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mcbGroup.Depth = 0;
            this.mcbGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mcbGroup.DropDownHeight = 174;
            this.mcbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcbGroup.DropDownWidth = 121;
            this.mcbGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mcbGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mcbGroup.FormattingEnabled = true;
            this.mcbGroup.Hint = "Grupo do produto";
            this.mcbGroup.IntegralHeight = false;
            this.mcbGroup.ItemHeight = 43;
            this.mcbGroup.Location = new System.Drawing.Point(12, 288);
            this.mcbGroup.MaxDropDownItems = 4;
            this.mcbGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.mcbGroup.Name = "mcbGroup";
            this.mcbGroup.Size = new System.Drawing.Size(250, 49);
            this.mcbGroup.StartIndex = 0;
            this.mcbGroup.TabIndex = 12;
            this.mcbGroup.SelectedIndexChanged += new System.EventHandler(this.mcbGroup_SelectedIndexChanged);
            this.mcbGroup.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mcbGroup_MouseClick);
            // 
            // mtbProductStock
            // 
            this.mtbProductStock.AnimateReadOnly = false;
            this.mtbProductStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbProductStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbProductStock.Depth = 0;
            this.mtbProductStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbProductStock.HideSelection = true;
            this.mtbProductStock.Hint = "Quantidade";
            this.mtbProductStock.LeadingIcon = null;
            this.mtbProductStock.Location = new System.Drawing.Point(268, 211);
            this.mtbProductStock.MaxLength = 32767;
            this.mtbProductStock.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbProductStock.Name = "mtbProductStock";
            this.mtbProductStock.PasswordChar = '\0';
            this.mtbProductStock.PrefixSuffixText = null;
            this.mtbProductStock.ReadOnly = true;
            this.mtbProductStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbProductStock.SelectedText = "";
            this.mtbProductStock.SelectionLength = 0;
            this.mtbProductStock.SelectionStart = 0;
            this.mtbProductStock.ShortcutsEnabled = true;
            this.mtbProductStock.Size = new System.Drawing.Size(194, 48);
            this.mtbProductStock.TabIndex = 14;
            this.mtbProductStock.TabStop = false;
            this.mtbProductStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProductStock.TrailingIcon = null;
            this.mtbProductStock.UseSystemPasswordChar = false;
            // 
            // mbtSaveProduct
            // 
            this.mbtSaveProduct.AutoSize = false;
            this.mbtSaveProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtSaveProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtSaveProduct.Depth = 0;
            this.mbtSaveProduct.HighEmphasis = true;
            this.mbtSaveProduct.Icon = null;
            this.mbtSaveProduct.Location = new System.Drawing.Point(384, 288);
            this.mbtSaveProduct.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtSaveProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtSaveProduct.Name = "mbtSaveProduct";
            this.mbtSaveProduct.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtSaveProduct.Size = new System.Drawing.Size(78, 49);
            this.mbtSaveProduct.TabIndex = 16;
            this.mbtSaveProduct.Text = "Salvar";
            this.mbtSaveProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtSaveProduct.UseAccentColor = false;
            this.mbtSaveProduct.UseVisualStyleBackColor = true;
            this.mbtSaveProduct.Click += new System.EventHandler(this.mbtSaveProduct_Click);
            // 
            // msProductStatus
            // 
            this.msProductStatus.AutoSize = true;
            this.msProductStatus.Checked = true;
            this.msProductStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.msProductStatus.Depth = 0;
            this.msProductStatus.Location = new System.Drawing.Point(265, 295);
            this.msProductStatus.Margin = new System.Windows.Forms.Padding(0);
            this.msProductStatus.MouseLocation = new System.Drawing.Point(-1, -1);
            this.msProductStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.msProductStatus.Name = "msProductStatus";
            this.msProductStatus.Ripple = true;
            this.msProductStatus.Size = new System.Drawing.Size(94, 37);
            this.msProductStatus.TabIndex = 15;
            this.msProductStatus.Text = "Ativo";
            this.msProductStatus.UseVisualStyleBackColor = true;
            // 
            // mtbProductCodeBar
            // 
            this.mtbProductCodeBar.AnimateReadOnly = false;
            this.mtbProductCodeBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbProductCodeBar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbProductCodeBar.Depth = 0;
            this.mtbProductCodeBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbProductCodeBar.HelperText = "Digite o código e pressione enter.";
            this.mtbProductCodeBar.HideSelection = true;
            this.mtbProductCodeBar.Hint = "Código de barras";
            this.mtbProductCodeBar.LeadingIcon = null;
            this.mtbProductCodeBar.Location = new System.Drawing.Point(12, 211);
            this.mtbProductCodeBar.MaxLength = 32767;
            this.mtbProductCodeBar.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbProductCodeBar.Name = "mtbProductCodeBar";
            this.mtbProductCodeBar.PasswordChar = '\0';
            this.mtbProductCodeBar.PrefixSuffixText = null;
            this.mtbProductCodeBar.ReadOnly = true;
            this.mtbProductCodeBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbProductCodeBar.SelectedText = "";
            this.mtbProductCodeBar.SelectionLength = 0;
            this.mtbProductCodeBar.SelectionStart = 0;
            this.mtbProductCodeBar.ShortcutsEnabled = true;
            this.mtbProductCodeBar.ShowAssistiveText = true;
            this.mtbProductCodeBar.Size = new System.Drawing.Size(250, 64);
            this.mtbProductCodeBar.TabIndex = 11;
            this.mtbProductCodeBar.TabStop = false;
            this.mtbProductCodeBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProductCodeBar.TrailingIcon = null;
            this.mtbProductCodeBar.UseSystemPasswordChar = false;
            // 
            // mtbProductPrice
            // 
            this.mtbProductPrice.AnimateReadOnly = false;
            this.mtbProductPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbProductPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbProductPrice.Depth = 0;
            this.mtbProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbProductPrice.HideSelection = true;
            this.mtbProductPrice.Hint = "Preço unitário";
            this.mtbProductPrice.LeadingIcon = null;
            this.mtbProductPrice.Location = new System.Drawing.Point(12, 157);
            this.mtbProductPrice.MaxLength = 32767;
            this.mtbProductPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbProductPrice.Name = "mtbProductPrice";
            this.mtbProductPrice.PasswordChar = '\0';
            this.mtbProductPrice.PrefixSuffixText = null;
            this.mtbProductPrice.ReadOnly = false;
            this.mtbProductPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbProductPrice.SelectedText = "";
            this.mtbProductPrice.SelectionLength = 0;
            this.mtbProductPrice.SelectionStart = 0;
            this.mtbProductPrice.ShortcutsEnabled = true;
            this.mtbProductPrice.Size = new System.Drawing.Size(250, 48);
            this.mtbProductPrice.TabIndex = 10;
            this.mtbProductPrice.TabStop = false;
            this.mtbProductPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProductPrice.TrailingIcon = null;
            this.mtbProductPrice.UseSystemPasswordChar = false;
            this.mtbProductPrice.TextChanged += new System.EventHandler(this.mtbProductPrice_TextChanged);
            // 
            // mtbProductName
            // 
            this.mtbProductName.AnimateReadOnly = false;
            this.mtbProductName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbProductName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbProductName.Depth = 0;
            this.mtbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbProductName.HideSelection = true;
            this.mtbProductName.Hint = "Descrição do produto";
            this.mtbProductName.LeadingIcon = null;
            this.mtbProductName.Location = new System.Drawing.Point(12, 103);
            this.mtbProductName.MaxLength = 32767;
            this.mtbProductName.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbProductName.Name = "mtbProductName";
            this.mtbProductName.PasswordChar = '\0';
            this.mtbProductName.PrefixSuffixText = null;
            this.mtbProductName.ReadOnly = false;
            this.mtbProductName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbProductName.SelectedText = "";
            this.mtbProductName.SelectionLength = 0;
            this.mtbProductName.SelectionStart = 0;
            this.mtbProductName.ShortcutsEnabled = true;
            this.mtbProductName.Size = new System.Drawing.Size(450, 48);
            this.mtbProductName.TabIndex = 9;
            this.mtbProductName.TabStop = false;
            this.mtbProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProductName.TrailingIcon = null;
            this.mtbProductName.UseSystemPasswordChar = false;
            // 
            // mepBuscaDescricao
            // 
            this.mepBuscaDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mepBuscaDescricao.CancelButtonText = "";
            this.mepBuscaDescricao.Collapse = true;
            this.mepBuscaDescricao.Controls.Add(this.dgwListaProdutos);
            this.mepBuscaDescricao.Controls.Add(this.mtbBusca);
            this.mepBuscaDescricao.Depth = 0;
            this.mepBuscaDescricao.Description = "";
            this.mepBuscaDescricao.ExpandHeight = 333;
            this.mepBuscaDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mepBuscaDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mepBuscaDescricao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mepBuscaDescricao.Location = new System.Drawing.Point(12, 24);
            this.mepBuscaDescricao.Margin = new System.Windows.Forms.Padding(16, 1, 16, 0);
            this.mepBuscaDescricao.MouseState = MaterialSkin.MouseState.HOVER;
            this.mepBuscaDescricao.Name = "mepBuscaDescricao";
            this.mepBuscaDescricao.Padding = new System.Windows.Forms.Padding(24, 64, 24, 16);
            this.mepBuscaDescricao.ShowCollapseExpand = false;
            this.mepBuscaDescricao.Size = new System.Drawing.Size(450, 48);
            this.mepBuscaDescricao.TabIndex = 17;
            this.mepBuscaDescricao.Title = "Buscar produto";
            this.mepBuscaDescricao.ValidationButtonText = "";
            this.mepBuscaDescricao.Paint += new System.Windows.Forms.PaintEventHandler(this.mepBuscaDescricao_Paint);
            // 
            // dgwListaProdutos
            // 
            this.dgwListaProdutos.AllowUserToAddRows = false;
            this.dgwListaProdutos.AllowUserToDeleteRows = false;
            this.dgwListaProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListaProdutos.Location = new System.Drawing.Point(27, 108);
            this.dgwListaProdutos.Name = "dgwListaProdutos";
            this.dgwListaProdutos.ReadOnly = true;
            this.dgwListaProdutos.Size = new System.Drawing.Size(396, 160);
            this.dgwListaProdutos.TabIndex = 3;
            this.dgwListaProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // mtbBusca
            // 
            this.mtbBusca.AnimateReadOnly = false;
            this.mtbBusca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbBusca.Depth = 0;
            this.mtbBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbBusca.HideSelection = true;
            this.mtbBusca.Hint = "Digite o nome do produto";
            this.mtbBusca.LeadingIcon = null;
            this.mtbBusca.Location = new System.Drawing.Point(27, 48);
            this.mtbBusca.MaxLength = 32767;
            this.mtbBusca.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbBusca.Name = "mtbBusca";
            this.mtbBusca.PasswordChar = '\0';
            this.mtbBusca.PrefixSuffixText = null;
            this.mtbBusca.ReadOnly = false;
            this.mtbBusca.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbBusca.SelectedText = "";
            this.mtbBusca.SelectionLength = 0;
            this.mtbBusca.SelectionStart = 0;
            this.mtbBusca.ShortcutsEnabled = true;
            this.mtbBusca.Size = new System.Drawing.Size(396, 48);
            this.mtbBusca.TabIndex = 2;
            this.mtbBusca.TabStop = false;
            this.mtbBusca.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbBusca.TrailingIcon = null;
            this.mtbBusca.UseSystemPasswordChar = false;
            this.mtbBusca.TextChanged += new System.EventHandler(this.mtbBusca_TextChanged);
            // 
            // fmAlterarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 382);
            this.Controls.Add(this.mepBuscaDescricao);
            this.Controls.Add(this.mcbSubGroup);
            this.Controls.Add(this.mcbGroup);
            this.Controls.Add(this.mtbProductStock);
            this.Controls.Add(this.mbtSaveProduct);
            this.Controls.Add(this.msProductStatus);
            this.Controls.Add(this.mtbProductCodeBar);
            this.Controls.Add(this.mtbProductPrice);
            this.Controls.Add(this.mtbProductName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmAlterarProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Produto";
            this.Load += new System.EventHandler(this.fmAlterarProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmAlterarProduto_KeyDown);
            this.mepBuscaDescricao.ResumeLayout(false);
            this.mepBuscaDescricao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox mcbSubGroup;
        private MaterialSkin.Controls.MaterialComboBox mcbGroup;
        private MaterialSkin.Controls.MaterialTextBox2 mtbProductStock;
        private MaterialSkin.Controls.MaterialButton mbtSaveProduct;
        private MaterialSkin.Controls.MaterialSwitch msProductStatus;
        private MaterialSkin.Controls.MaterialTextBox2 mtbProductCodeBar;
        private MaterialSkin.Controls.MaterialTextBox2 mtbProductPrice;
        private MaterialSkin.Controls.MaterialTextBox2 mtbProductName;
        private MaterialSkin.Controls.MaterialExpansionPanel mepBuscaDescricao;
        private System.Windows.Forms.DataGridView dgwListaProdutos;
        private MaterialSkin.Controls.MaterialTextBox2 mtbBusca;
    }
}