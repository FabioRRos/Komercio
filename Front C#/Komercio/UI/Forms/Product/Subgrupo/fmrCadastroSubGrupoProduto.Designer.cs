namespace Komercio.UI.Forms.Product
{
    partial class fmrCadastroSubGrupoProduto
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgwSubgrupo = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mtbSubgrupo = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtCadastrar = new MaterialSkin.Controls.MaterialButton();
            this.dggroup = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSubgrupo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dggroup)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dggroup);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 363);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupos";
            // 
            // dgwSubgrupo
            // 
            this.dgwSubgrupo.AllowUserToAddRows = false;
            this.dgwSubgrupo.AllowUserToDeleteRows = false;
            this.dgwSubgrupo.AllowUserToOrderColumns = true;
            this.dgwSubgrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSubgrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwSubgrupo.Location = new System.Drawing.Point(203, 3);
            this.dgwSubgrupo.Name = "dgwSubgrupo";
            this.dgwSubgrupo.ReadOnly = true;
            this.dgwSubgrupo.Size = new System.Drawing.Size(194, 363);
            this.dgwSubgrupo.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.dgwSubgrupo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(669, 369);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mbtCadastrar);
            this.groupBox2.Controls.Add(this.mtbSubgrupo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(403, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 363);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadastro de subgrupos";
            // 
            // mtbSubgrupo
            // 
            this.mtbSubgrupo.AnimateReadOnly = false;
            this.mtbSubgrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbSubgrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbSubgrupo.Depth = 0;
            this.mtbSubgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbSubgrupo.HideSelection = true;
            this.mtbSubgrupo.Hint = "Digite o nome do subgrupo";
            this.mtbSubgrupo.LeadingIcon = null;
            this.mtbSubgrupo.Location = new System.Drawing.Point(8, 123);
            this.mtbSubgrupo.MaxLength = 32767;
            this.mtbSubgrupo.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbSubgrupo.Name = "mtbSubgrupo";
            this.mtbSubgrupo.PasswordChar = '\0';
            this.mtbSubgrupo.PrefixSuffixText = null;
            this.mtbSubgrupo.ReadOnly = false;
            this.mtbSubgrupo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbSubgrupo.SelectedText = "";
            this.mtbSubgrupo.SelectionLength = 0;
            this.mtbSubgrupo.SelectionStart = 0;
            this.mtbSubgrupo.ShortcutsEnabled = true;
            this.mtbSubgrupo.Size = new System.Drawing.Size(250, 48);
            this.mtbSubgrupo.TabIndex = 6;
            this.mtbSubgrupo.TabStop = false;
            this.mtbSubgrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbSubgrupo.TrailingIcon = null;
            this.mtbSubgrupo.UseSystemPasswordChar = false;
            // 
            // mbtCadastrar
            // 
            this.mbtCadastrar.AutoSize = false;
            this.mbtCadastrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtCadastrar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtCadastrar.Depth = 0;
            this.mbtCadastrar.HighEmphasis = true;
            this.mbtCadastrar.Icon = null;
            this.mbtCadastrar.Location = new System.Drawing.Point(83, 192);
            this.mbtCadastrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtCadastrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtCadastrar.Name = "mbtCadastrar";
            this.mbtCadastrar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtCadastrar.Size = new System.Drawing.Size(97, 48);
            this.mbtCadastrar.TabIndex = 7;
            this.mbtCadastrar.Text = "Salvar";
            this.mbtCadastrar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtCadastrar.UseAccentColor = false;
            this.mbtCadastrar.UseVisualStyleBackColor = true;
            this.mbtCadastrar.Click += new System.EventHandler(this.mbtCadastrar_Click_1);
            // 
            // dggroup
            // 
            this.dggroup.AllowUserToAddRows = false;
            this.dggroup.AllowUserToDeleteRows = false;
            this.dggroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dggroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dggroup.Location = new System.Drawing.Point(3, 16);
            this.dggroup.Name = "dggroup";
            this.dggroup.ReadOnly = true;
            this.dggroup.Size = new System.Drawing.Size(188, 344);
            this.dggroup.TabIndex = 1;
            this.dggroup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dggroup_CellContentClick);
            // 
            // fmrCadastroSubGrupoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 369);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "fmrCadastroSubGrupoProduto";
            this.Text = "Cadastro subgrupo";
            this.Load += new System.EventHandler(this.fmrCadastroSubGrupoProduto_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSubgrupo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dggroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dggroup;
        private System.Windows.Forms.DataGridView dgwSubgrupo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialButton mbtCadastrar;
        private MaterialSkin.Controls.MaterialTextBox2 mtbSubgrupo;
    }
}