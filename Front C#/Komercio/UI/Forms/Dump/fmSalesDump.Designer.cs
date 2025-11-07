namespace Komercio.UI.Forms.Dump
{
    partial class fmSalesDump
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
            this.dgvSalesDump = new System.Windows.Forms.DataGridView();
            this.mtbDataInicial = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbDataFinal = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtFiltarData = new MaterialSkin.Controls.MaterialButton();
            this.mbtLimparFiltro = new MaterialSkin.Controls.MaterialButton();
            this.mtbTotalPeriodo = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.mcbSallerName = new MaterialSkin.Controls.MaterialComboBox();
            this.mtbLimparVendedor = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDump)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSalesDump
            // 
            this.dgvSalesDump.AllowUserToAddRows = false;
            this.dgvSalesDump.AllowUserToDeleteRows = false;
            this.dgvSalesDump.AllowUserToOrderColumns = true;
            this.dgvSalesDump.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesDump.Location = new System.Drawing.Point(12, 145);
            this.dgvSalesDump.Name = "dgvSalesDump";
            this.dgvSalesDump.ReadOnly = true;
            this.dgvSalesDump.Size = new System.Drawing.Size(809, 293);
            this.dgvSalesDump.TabIndex = 0;
            // 
            // mtbDataInicial
            // 
            this.mtbDataInicial.AnimateReadOnly = true;
            this.mtbDataInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDataInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDataInicial.Depth = 0;
            this.mtbDataInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDataInicial.HideSelection = true;
            this.mtbDataInicial.Hint = "Data Inicial";
            this.mtbDataInicial.LeadingIcon = null;
            this.mtbDataInicial.Location = new System.Drawing.Point(12, 42);
            this.mtbDataInicial.MaxLength = 32767;
            this.mtbDataInicial.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDataInicial.Name = "mtbDataInicial";
            this.mtbDataInicial.PasswordChar = '\0';
            this.mtbDataInicial.PrefixSuffixText = null;
            this.mtbDataInicial.ReadOnly = false;
            this.mtbDataInicial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDataInicial.SelectedText = "";
            this.mtbDataInicial.SelectionLength = 0;
            this.mtbDataInicial.SelectionStart = 0;
            this.mtbDataInicial.ShortcutsEnabled = true;
            this.mtbDataInicial.Size = new System.Drawing.Size(146, 36);
            this.mtbDataInicial.TabIndex = 1;
            this.mtbDataInicial.TabStop = false;
            this.mtbDataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDataInicial.TrailingIcon = null;
            this.mtbDataInicial.UseSystemPasswordChar = false;
            this.mtbDataInicial.UseTallSize = false;
            this.mtbDataInicial.TextChanged += new System.EventHandler(this.mtbDataInicial_TextChanged);
            // 
            // mtbDataFinal
            // 
            this.mtbDataFinal.AnimateReadOnly = true;
            this.mtbDataFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDataFinal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDataFinal.Depth = 0;
            this.mtbDataFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDataFinal.HideSelection = true;
            this.mtbDataFinal.Hint = "Data Final";
            this.mtbDataFinal.LeadingIcon = null;
            this.mtbDataFinal.Location = new System.Drawing.Point(176, 42);
            this.mtbDataFinal.MaxLength = 32767;
            this.mtbDataFinal.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDataFinal.Name = "mtbDataFinal";
            this.mtbDataFinal.PasswordChar = '\0';
            this.mtbDataFinal.PrefixSuffixText = null;
            this.mtbDataFinal.ReadOnly = false;
            this.mtbDataFinal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDataFinal.SelectedText = "";
            this.mtbDataFinal.SelectionLength = 0;
            this.mtbDataFinal.SelectionStart = 0;
            this.mtbDataFinal.ShortcutsEnabled = true;
            this.mtbDataFinal.Size = new System.Drawing.Size(146, 36);
            this.mtbDataFinal.TabIndex = 2;
            this.mtbDataFinal.TabStop = false;
            this.mtbDataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDataFinal.TrailingIcon = null;
            this.mtbDataFinal.UseSystemPasswordChar = false;
            this.mtbDataFinal.UseTallSize = false;
            this.mtbDataFinal.TextChanged += new System.EventHandler(this.mtbDataFinal_TextChanged);
            // 
            // mbtFiltarData
            // 
            this.mbtFiltarData.AutoSize = false;
            this.mbtFiltarData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtFiltarData.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtFiltarData.Depth = 0;
            this.mbtFiltarData.HighEmphasis = true;
            this.mbtFiltarData.Icon = null;
            this.mbtFiltarData.Location = new System.Drawing.Point(13, 87);
            this.mbtFiltarData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtFiltarData.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtFiltarData.Name = "mbtFiltarData";
            this.mbtFiltarData.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtFiltarData.Size = new System.Drawing.Size(145, 36);
            this.mbtFiltarData.TabIndex = 3;
            this.mbtFiltarData.Text = "Filtrar";
            this.mbtFiltarData.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtFiltarData.UseAccentColor = false;
            this.mbtFiltarData.UseVisualStyleBackColor = true;
            this.mbtFiltarData.Click += new System.EventHandler(this.mbtFiltarData_Click);
            // 
            // mbtLimparFiltro
            // 
            this.mbtLimparFiltro.AutoSize = false;
            this.mbtLimparFiltro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtLimparFiltro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtLimparFiltro.Depth = 0;
            this.mbtLimparFiltro.HighEmphasis = true;
            this.mbtLimparFiltro.Icon = null;
            this.mbtLimparFiltro.Location = new System.Drawing.Point(176, 87);
            this.mbtLimparFiltro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtLimparFiltro.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtLimparFiltro.Name = "mbtLimparFiltro";
            this.mbtLimparFiltro.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtLimparFiltro.Size = new System.Drawing.Size(146, 36);
            this.mbtLimparFiltro.TabIndex = 4;
            this.mbtLimparFiltro.Text = "Limpar Filtros";
            this.mbtLimparFiltro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtLimparFiltro.UseAccentColor = false;
            this.mbtLimparFiltro.UseVisualStyleBackColor = true;
            this.mbtLimparFiltro.Click += new System.EventHandler(this.mbtLimparFiltro_Click);
            // 
            // mtbTotalPeriodo
            // 
            this.mtbTotalPeriodo.AnimateReadOnly = true;
            this.mtbTotalPeriodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbTotalPeriodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbTotalPeriodo.Depth = 0;
            this.mtbTotalPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbTotalPeriodo.HideSelection = true;
            this.mtbTotalPeriodo.Hint = "Total vendido no periodo";
            this.mtbTotalPeriodo.LeadingIcon = null;
            this.mtbTotalPeriodo.Location = new System.Drawing.Point(359, 42);
            this.mtbTotalPeriodo.MaxLength = 32767;
            this.mtbTotalPeriodo.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbTotalPeriodo.Name = "mtbTotalPeriodo";
            this.mtbTotalPeriodo.PasswordChar = '\0';
            this.mtbTotalPeriodo.PrefixSuffix = MaterialSkin.Controls.MaterialTextBox2.PrefixSuffixTypes.Prefix;
            this.mtbTotalPeriodo.PrefixSuffixText = null;
            this.mtbTotalPeriodo.ReadOnly = true;
            this.mtbTotalPeriodo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbTotalPeriodo.SelectedText = "";
            this.mtbTotalPeriodo.SelectionLength = 0;
            this.mtbTotalPeriodo.SelectionStart = 0;
            this.mtbTotalPeriodo.ShortcutsEnabled = true;
            this.mtbTotalPeriodo.Size = new System.Drawing.Size(208, 36);
            this.mtbTotalPeriodo.TabIndex = 5;
            this.mtbTotalPeriodo.TabStop = false;
            this.mtbTotalPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbTotalPeriodo.TrailingIcon = null;
            this.mtbTotalPeriodo.UseSystemPasswordChar = false;
            this.mtbTotalPeriodo.UseTallSize = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(12, 20);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(81, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "Data inicial";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(173, 20);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(71, 19);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "Data final";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(356, 20);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(177, 19);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Total vendido no periodo";
            // 
            // mcbSallerName
            // 
            this.mcbSallerName.AutoResize = false;
            this.mcbSallerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mcbSallerName.Depth = 0;
            this.mcbSallerName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mcbSallerName.DropDownHeight = 118;
            this.mcbSallerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcbSallerName.DropDownWidth = 121;
            this.mcbSallerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mcbSallerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mcbSallerName.FormattingEnabled = true;
            this.mcbSallerName.Hint = "Vendedor";
            this.mcbSallerName.IntegralHeight = false;
            this.mcbSallerName.ItemHeight = 29;
            this.mcbSallerName.Location = new System.Drawing.Point(613, 42);
            this.mcbSallerName.MaxDropDownItems = 4;
            this.mcbSallerName.MouseState = MaterialSkin.MouseState.OUT;
            this.mcbSallerName.Name = "mcbSallerName";
            this.mcbSallerName.Size = new System.Drawing.Size(208, 35);
            this.mcbSallerName.StartIndex = 0;
            this.mcbSallerName.TabIndex = 9;
            this.mcbSallerName.UseTallSize = false;
            this.mcbSallerName.TextChanged += new System.EventHandler(this.mcbSallerName_TextChanged);
            // 
            // mtbLimparVendedor
            // 
            this.mtbLimparVendedor.AutoSize = false;
            this.mtbLimparVendedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbLimparVendedor.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbLimparVendedor.Depth = 0;
            this.mtbLimparVendedor.HighEmphasis = true;
            this.mtbLimparVendedor.Icon = null;
            this.mtbLimparVendedor.Location = new System.Drawing.Point(651, 86);
            this.mtbLimparVendedor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbLimparVendedor.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbLimparVendedor.Name = "mtbLimparVendedor";
            this.mtbLimparVendedor.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbLimparVendedor.Size = new System.Drawing.Size(145, 36);
            this.mtbLimparVendedor.TabIndex = 10;
            this.mtbLimparVendedor.Text = "Limpar vendedor";
            this.mtbLimparVendedor.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbLimparVendedor.UseAccentColor = false;
            this.mtbLimparVendedor.UseVisualStyleBackColor = true;
            this.mtbLimparVendedor.Click += new System.EventHandler(this.mtbLimparVendedor_Click);
            // 
            // fmSalesDump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 450);
            this.Controls.Add(this.mtbLimparVendedor);
            this.Controls.Add(this.mcbSallerName);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.mtbTotalPeriodo);
            this.Controls.Add(this.mbtLimparFiltro);
            this.Controls.Add(this.mbtFiltarData);
            this.Controls.Add(this.mtbDataFinal);
            this.Controls.Add(this.mtbDataInicial);
            this.Controls.Add(this.dgvSalesDump);
            this.Name = "fmSalesDump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fmSalesDump";
            this.Load += new System.EventHandler(this.fmSalesDump_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesDump)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalesDump;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDataInicial;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDataFinal;
        private MaterialSkin.Controls.MaterialButton mbtFiltarData;
        private MaterialSkin.Controls.MaterialButton mbtLimparFiltro;
        private MaterialSkin.Controls.MaterialTextBox2 mtbTotalPeriodo;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialComboBox mcbSallerName;
        private MaterialSkin.Controls.MaterialButton mtbLimparVendedor;
    }
}