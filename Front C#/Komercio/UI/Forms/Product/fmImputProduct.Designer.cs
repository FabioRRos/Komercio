namespace Komercio.UI.Forms.Product
{
    partial class fmImputProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmImputProduct));
            this.mtbCodBar = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbStock = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.msOptionsInput = new MaterialSkin.Controls.MaterialSwitch();
            this.mbtSave = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.mlvInput = new MaterialSkin.Controls.MaterialListView();
            this.QTD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Produto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // mtbCodBar
            // 
            this.mtbCodBar.AnimateReadOnly = false;
            this.mtbCodBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCodBar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCodBar.Depth = 0;
            this.mtbCodBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCodBar.HelperText = "Automárico só com o leitor";
            this.mtbCodBar.HideSelection = true;
            this.mtbCodBar.Hint = "Código de barras";
            this.mtbCodBar.LeadingIcon = null;
            this.mtbCodBar.Location = new System.Drawing.Point(23, 40);
            this.mtbCodBar.MaxLength = 32767;
            this.mtbCodBar.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCodBar.Name = "mtbCodBar";
            this.mtbCodBar.PasswordChar = '\0';
            this.mtbCodBar.PrefixSuffixText = null;
            this.mtbCodBar.ReadOnly = false;
            this.mtbCodBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCodBar.SelectedText = "";
            this.mtbCodBar.SelectionLength = 0;
            this.mtbCodBar.SelectionStart = 0;
            this.mtbCodBar.ShortcutsEnabled = true;
            this.mtbCodBar.ShowAssistiveText = true;
            this.mtbCodBar.Size = new System.Drawing.Size(250, 64);
            this.mtbCodBar.TabIndex = 0;
            this.mtbCodBar.TabStop = false;
            this.mtbCodBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCodBar.TrailingIcon = null;
            this.mtbCodBar.UseSystemPasswordChar = false;
            this.mtbCodBar.TextChanged += new System.EventHandler(this.mtbCodBar_TextChanged);
            // 
            // mtbStock
            // 
            this.mtbStock.AnimateReadOnly = false;
            this.mtbStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbStock.Depth = 0;
            this.mtbStock.Enabled = false;
            this.mtbStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbStock.HideSelection = true;
            this.mtbStock.Hint = "Quantidade";
            this.mtbStock.LeadingIcon = null;
            this.mtbStock.Location = new System.Drawing.Point(23, 113);
            this.mtbStock.MaxLength = 32767;
            this.mtbStock.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbStock.Name = "mtbStock";
            this.mtbStock.PasswordChar = '\0';
            this.mtbStock.PrefixSuffixText = null;
            this.mtbStock.ReadOnly = false;
            this.mtbStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbStock.SelectedText = "";
            this.mtbStock.SelectionLength = 0;
            this.mtbStock.SelectionStart = 0;
            this.mtbStock.ShortcutsEnabled = true;
            this.mtbStock.Size = new System.Drawing.Size(250, 48);
            this.mtbStock.TabIndex = 3;
            this.mtbStock.TabStop = false;
            this.mtbStock.Text = "1";
            this.mtbStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbStock.TrailingIcon = null;
            this.mtbStock.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel1.Location = new System.Drawing.Point(20, 180);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(49, 17);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "Manual";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel2.Location = new System.Drawing.Point(198, 180);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(75, 17);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "Automatico";
            // 
            // msOptionsInput
            // 
            this.msOptionsInput.AutoSize = true;
            this.msOptionsInput.Checked = true;
            this.msOptionsInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.msOptionsInput.Depth = 0;
            this.msOptionsInput.Location = new System.Drawing.Point(109, 171);
            this.msOptionsInput.Margin = new System.Windows.Forms.Padding(0);
            this.msOptionsInput.MouseLocation = new System.Drawing.Point(-1, -1);
            this.msOptionsInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.msOptionsInput.Name = "msOptionsInput";
            this.msOptionsInput.Ripple = true;
            this.msOptionsInput.Size = new System.Drawing.Size(58, 37);
            this.msOptionsInput.TabIndex = 9;
            this.msOptionsInput.UseVisualStyleBackColor = true;
            this.msOptionsInput.CheckedChanged += new System.EventHandler(this.msOptionsInput_CheckedChanged);
            // 
            // mbtSave
            // 
            this.mbtSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtSave.Depth = 0;
            this.mbtSave.Enabled = false;
            this.mbtSave.HighEmphasis = true;
            this.mbtSave.Icon = null;
            this.mbtSave.Location = new System.Drawing.Point(109, 244);
            this.mbtSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtSave.Name = "mbtSave";
            this.mbtSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtSave.Size = new System.Drawing.Size(76, 36);
            this.mbtSave.TabIndex = 10;
            this.mbtSave.Text = "Salvar";
            this.mbtSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtSave.UseAccentColor = false;
            this.mbtSave.UseVisualStyleBackColor = true;
            this.mbtSave.Click += new System.EventHandler(this.mbtSave_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel5.Location = new System.Drawing.Point(420, 9);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(58, 17);
            this.materialLabel5.TabIndex = 12;
            this.materialLabel5.Text = "Entradas";
            // 
            // mlvInput
            // 
            this.mlvInput.AutoSizeTable = false;
            this.mlvInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mlvInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mlvInput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.QTD,
            this.Produto,
            this.columnHeader1});
            this.mlvInput.Depth = 0;
            this.mlvInput.FullRowSelect = true;
            this.mlvInput.HideSelection = false;
            this.mlvInput.Location = new System.Drawing.Point(308, 38);
            this.mlvInput.MinimumSize = new System.Drawing.Size(200, 100);
            this.mlvInput.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mlvInput.MouseState = MaterialSkin.MouseState.OUT;
            this.mlvInput.Name = "mlvInput";
            this.mlvInput.OwnerDraw = true;
            this.mlvInput.Size = new System.Drawing.Size(298, 240);
            this.mlvInput.TabIndex = 13;
            this.mlvInput.UseCompatibleStateImageBehavior = false;
            this.mlvInput.View = System.Windows.Forms.View.Details;
            // 
            // QTD
            // 
            this.QTD.Text = "QTD";
            // 
            // Produto
            // 
            this.Produto.Text = "Produto";
            this.Produto.Width = 150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // fmImputProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 294);
            this.Controls.Add(this.mlvInput);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.mbtSave);
            this.Controls.Add(this.msOptionsInput);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.mtbStock);
            this.Controls.Add(this.mtbCodBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmImputProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entrada estoque";
            this.Load += new System.EventHandler(this.fmImputProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mtbCodBar;
        private MaterialSkin.Controls.MaterialTextBox2 mtbStock;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSwitch msOptionsInput;
        private MaterialSkin.Controls.MaterialButton mbtSave;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialListView mlvInput;
        private System.Windows.Forms.ColumnHeader QTD;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}