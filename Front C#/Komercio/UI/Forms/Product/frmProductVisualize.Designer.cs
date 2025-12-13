namespace Komercio.UI.Forms.Product
{
    partial class frmProductVisualize
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.mtbNomeProduto = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtLimparFiltros = new MaterialSkin.Controls.MaterialButton();
            this.mgbGrupo = new MaterialSkin.Controls.MaterialComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mgbGrupo);
            this.panel1.Controls.Add(this.mbtLimparFiltros);
            this.panel1.Controls.Add(this.mtbNomeProduto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 98);
            this.panel1.TabIndex = 0;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProdutos.Location = new System.Drawing.Point(0, 98);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.Size = new System.Drawing.Size(611, 409);
            this.dgvProdutos.TabIndex = 1;
            // 
            // mtbNomeProduto
            // 
            this.mtbNomeProduto.AnimateReadOnly = false;
            this.mtbNomeProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbNomeProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbNomeProduto.Depth = 0;
            this.mtbNomeProduto.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbNomeProduto.HideSelection = true;
            this.mtbNomeProduto.Hint = "Nome do produto";
            this.mtbNomeProduto.LeadingIcon = null;
            this.mtbNomeProduto.Location = new System.Drawing.Point(22, 24);
            this.mtbNomeProduto.MaxLength = 32767;
            this.mtbNomeProduto.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbNomeProduto.Name = "mtbNomeProduto";
            this.mtbNomeProduto.PasswordChar = '\0';
            this.mtbNomeProduto.PrefixSuffixText = null;
            this.mtbNomeProduto.ReadOnly = false;
            this.mtbNomeProduto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbNomeProduto.SelectedText = "";
            this.mtbNomeProduto.SelectionLength = 0;
            this.mtbNomeProduto.SelectionStart = 0;
            this.mtbNomeProduto.ShortcutsEnabled = true;
            this.mtbNomeProduto.Size = new System.Drawing.Size(182, 48);
            this.mtbNomeProduto.TabIndex = 0;
            this.mtbNomeProduto.TabStop = false;
            this.mtbNomeProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbNomeProduto.TrailingIcon = null;
            this.mtbNomeProduto.UseSystemPasswordChar = false;
            this.mtbNomeProduto.Click += new System.EventHandler(this.mtbNomeProduto_Click);
            this.mtbNomeProduto.TextChanged += new System.EventHandler(this.mtbNomeProduto_TextChanged);
            // 
            // mbtLimparFiltros
            // 
            this.mbtLimparFiltros.AutoSize = false;
            this.mbtLimparFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtLimparFiltros.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtLimparFiltros.Depth = 0;
            this.mbtLimparFiltros.HighEmphasis = true;
            this.mbtLimparFiltros.Icon = null;
            this.mbtLimparFiltros.Location = new System.Drawing.Point(444, 24);
            this.mbtLimparFiltros.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtLimparFiltros.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtLimparFiltros.Name = "mbtLimparFiltros";
            this.mbtLimparFiltros.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtLimparFiltros.Size = new System.Drawing.Size(127, 48);
            this.mbtLimparFiltros.TabIndex = 4;
            this.mbtLimparFiltros.Text = "Limpar Filtros";
            this.mbtLimparFiltros.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtLimparFiltros.UseAccentColor = false;
            this.mbtLimparFiltros.UseVisualStyleBackColor = true;
            this.mbtLimparFiltros.Click += new System.EventHandler(this.mbtLimparFiltros_Click);
            // 
            // mgbGrupo
            // 
            this.mgbGrupo.AutoResize = false;
            this.mgbGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mgbGrupo.Depth = 0;
            this.mgbGrupo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mgbGrupo.DropDownHeight = 174;
            this.mgbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mgbGrupo.DropDownWidth = 121;
            this.mgbGrupo.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mgbGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mgbGrupo.FormattingEnabled = true;
            this.mgbGrupo.Hint = "Grupo do produto";
            this.mgbGrupo.IntegralHeight = false;
            this.mgbGrupo.ItemHeight = 43;
            this.mgbGrupo.Location = new System.Drawing.Point(226, 24);
            this.mgbGrupo.MaxDropDownItems = 4;
            this.mgbGrupo.MouseState = MaterialSkin.MouseState.OUT;
            this.mgbGrupo.Name = "mgbGrupo";
            this.mgbGrupo.Size = new System.Drawing.Size(192, 49);
            this.mgbGrupo.StartIndex = 0;
            this.mgbGrupo.TabIndex = 2;
            this.mgbGrupo.SelectedIndexChanged += new System.EventHandler(this.mgbGrupo_SelectedIndexChanged);
            // 
            // frmProductVisualize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 507);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.panel1);
            this.Name = "frmProductVisualize";
            this.Text = "frmProductVisualize";
            this.Load += new System.EventHandler(this.frmProductVisualize_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialComboBox mgbGrupo;
        private MaterialSkin.Controls.MaterialButton mbtLimparFiltros;
        private MaterialSkin.Controls.MaterialTextBox2 mtbNomeProduto;
        private System.Windows.Forms.DataGridView dgvProdutos;
    }
}