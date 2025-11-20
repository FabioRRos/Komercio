namespace Komercio.UI.Forms.Product
{
    partial class fmCreateProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmCreateProduct));
            this.mtbProductName = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbProductPrice = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbProductCodeBar = new MaterialSkin.Controls.MaterialTextBox2();
            this.msProductStatus = new MaterialSkin.Controls.MaterialSwitch();
            this.mbtNewProduct = new MaterialSkin.Controls.MaterialButton();
            this.mbtSaveProduct = new MaterialSkin.Controls.MaterialButton();
            this.mtbProductStock = new MaterialSkin.Controls.MaterialTextBox2();
            this.mcbGroup = new MaterialSkin.Controls.MaterialComboBox();
            this.mcbSubGroup = new MaterialSkin.Controls.MaterialComboBox();
            this.SuspendLayout();
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
            this.mtbProductName.Location = new System.Drawing.Point(12, 16);
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
            this.mtbProductName.Size = new System.Drawing.Size(250, 48);
            this.mtbProductName.TabIndex = 0;
            this.mtbProductName.TabStop = false;
            this.mtbProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProductName.TrailingIcon = null;
            this.mtbProductName.UseSystemPasswordChar = false;
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
            this.mtbProductPrice.Location = new System.Drawing.Point(12, 70);
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
            this.mtbProductPrice.TabIndex = 1;
            this.mtbProductPrice.TabStop = false;
            this.mtbProductPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProductPrice.TrailingIcon = null;
            this.mtbProductPrice.UseSystemPasswordChar = false;
            this.mtbProductPrice.TextChanged += new System.EventHandler(this.mtbProductPrice_TextChanged);
            // 
            // mtbProductCodeBar
            // 
            this.mtbProductCodeBar.AnimateReadOnly = false;
            this.mtbProductCodeBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbProductCodeBar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbProductCodeBar.Depth = 0;
            this.mtbProductCodeBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbProductCodeBar.HideSelection = true;
            this.mtbProductCodeBar.Hint = "Código de barras";
            this.mtbProductCodeBar.LeadingIcon = null;
            this.mtbProductCodeBar.Location = new System.Drawing.Point(12, 124);
            this.mtbProductCodeBar.MaxLength = 32767;
            this.mtbProductCodeBar.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbProductCodeBar.Name = "mtbProductCodeBar";
            this.mtbProductCodeBar.PasswordChar = '\0';
            this.mtbProductCodeBar.PrefixSuffixText = null;
            this.mtbProductCodeBar.ReadOnly = false;
            this.mtbProductCodeBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbProductCodeBar.SelectedText = "";
            this.mtbProductCodeBar.SelectionLength = 0;
            this.mtbProductCodeBar.SelectionStart = 0;
            this.mtbProductCodeBar.ShortcutsEnabled = true;
            this.mtbProductCodeBar.Size = new System.Drawing.Size(250, 48);
            this.mtbProductCodeBar.TabIndex = 2;
            this.mtbProductCodeBar.TabStop = false;
            this.mtbProductCodeBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProductCodeBar.TrailingIcon = null;
            this.mtbProductCodeBar.UseSystemPasswordChar = false;
            // 
            // msProductStatus
            // 
            this.msProductStatus.AutoSize = true;
            this.msProductStatus.Checked = true;
            this.msProductStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.msProductStatus.Depth = 0;
            this.msProductStatus.Location = new System.Drawing.Point(312, 130);
            this.msProductStatus.Margin = new System.Windows.Forms.Padding(0);
            this.msProductStatus.MouseLocation = new System.Drawing.Point(-1, -1);
            this.msProductStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.msProductStatus.Name = "msProductStatus";
            this.msProductStatus.Ripple = true;
            this.msProductStatus.Size = new System.Drawing.Size(94, 37);
            this.msProductStatus.TabIndex = 6;
            this.msProductStatus.Text = "Ativo";
            this.msProductStatus.UseVisualStyleBackColor = true;
            // 
            // mbtNewProduct
            // 
            this.mbtNewProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtNewProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtNewProduct.Depth = 0;
            this.mbtNewProduct.HighEmphasis = true;
            this.mbtNewProduct.Icon = null;
            this.mbtNewProduct.Location = new System.Drawing.Point(312, 190);
            this.mbtNewProduct.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtNewProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtNewProduct.Name = "mbtNewProduct";
            this.mbtNewProduct.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtNewProduct.Size = new System.Drawing.Size(64, 36);
            this.mbtNewProduct.TabIndex = 0;
            this.mbtNewProduct.Text = "Novo";
            this.mbtNewProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtNewProduct.UseAccentColor = false;
            this.mbtNewProduct.UseVisualStyleBackColor = true;
            this.mbtNewProduct.Click += new System.EventHandler(this.mbtNewProduct_Click);
            // 
            // mbtSaveProduct
            // 
            this.mbtSaveProduct.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtSaveProduct.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtSaveProduct.Depth = 0;
            this.mbtSaveProduct.HighEmphasis = true;
            this.mbtSaveProduct.Icon = null;
            this.mbtSaveProduct.Location = new System.Drawing.Point(433, 190);
            this.mbtSaveProduct.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtSaveProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtSaveProduct.Name = "mbtSaveProduct";
            this.mbtSaveProduct.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtSaveProduct.Size = new System.Drawing.Size(76, 36);
            this.mbtSaveProduct.TabIndex = 7;
            this.mbtSaveProduct.Text = "Salvar";
            this.mbtSaveProduct.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtSaveProduct.UseAccentColor = false;
            this.mbtSaveProduct.UseVisualStyleBackColor = true;
            this.mbtSaveProduct.Click += new System.EventHandler(this.mbtSaveProduct_Click);
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
            this.mtbProductStock.Location = new System.Drawing.Point(312, 70);
            this.mtbProductStock.MaxLength = 32767;
            this.mtbProductStock.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbProductStock.Name = "mtbProductStock";
            this.mtbProductStock.PasswordChar = '\0';
            this.mtbProductStock.PrefixSuffixText = null;
            this.mtbProductStock.ReadOnly = false;
            this.mtbProductStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbProductStock.SelectedText = "";
            this.mtbProductStock.SelectionLength = 0;
            this.mtbProductStock.SelectionStart = 0;
            this.mtbProductStock.ShortcutsEnabled = true;
            this.mtbProductStock.Size = new System.Drawing.Size(197, 48);
            this.mtbProductStock.TabIndex = 5;
            this.mtbProductStock.TabStop = false;
            this.mtbProductStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProductStock.TrailingIcon = null;
            this.mtbProductStock.UseSystemPasswordChar = false;
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
            this.mcbGroup.Location = new System.Drawing.Point(12, 177);
            this.mcbGroup.MaxDropDownItems = 4;
            this.mcbGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.mcbGroup.Name = "mcbGroup";
            this.mcbGroup.Size = new System.Drawing.Size(250, 49);
//this.mcbGroup.StartIndex = 0;
            this.mcbGroup.TabIndex = 3;
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
            this.mcbSubGroup.Location = new System.Drawing.Point(312, 16);
            this.mcbSubGroup.MaxDropDownItems = 4;
            this.mcbSubGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.mcbSubGroup.Name = "mcbSubGroup";
            this.mcbSubGroup.Size = new System.Drawing.Size(197, 49);
            this.mcbSubGroup.StartIndex = 0;
            this.mcbSubGroup.TabIndex = 4;
            // 
            // fmCreateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 240);
            this.Controls.Add(this.mcbSubGroup);
            this.Controls.Add(this.mcbGroup);
            this.Controls.Add(this.mtbProductStock);
            this.Controls.Add(this.mbtSaveProduct);
            this.Controls.Add(this.mbtNewProduct);
            this.Controls.Add(this.msProductStatus);
            this.Controls.Add(this.mtbProductCodeBar);
            this.Controls.Add(this.mtbProductPrice);
            this.Controls.Add(this.mtbProductName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmCreateProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro produtos - Manual";
            this.Load += new System.EventHandler(this.fmCreateProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mtbProductName;
        private MaterialSkin.Controls.MaterialTextBox2 mtbProductPrice;
        private MaterialSkin.Controls.MaterialTextBox2 mtbProductCodeBar;
        private MaterialSkin.Controls.MaterialSwitch msProductStatus;
        private MaterialSkin.Controls.MaterialButton mbtNewProduct;
        private MaterialSkin.Controls.MaterialButton mbtSaveProduct;
        private MaterialSkin.Controls.MaterialTextBox2 mtbProductStock;
        private MaterialSkin.Controls.MaterialComboBox mcbGroup;
        private MaterialSkin.Controls.MaterialComboBox mcbSubGroup;
    }
}