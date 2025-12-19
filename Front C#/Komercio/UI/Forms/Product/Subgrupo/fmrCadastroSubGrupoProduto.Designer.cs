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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgwSubgrupo = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mcbGrupo = new MaterialSkin.Controls.MaterialComboBox();
            this.mtbSubgrupo = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtCadastrar = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSubgrupo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.dgwSubgrupo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(528, 237);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // dgwSubgrupo
            // 
            this.dgwSubgrupo.AllowUserToAddRows = false;
            this.dgwSubgrupo.AllowUserToDeleteRows = false;
            this.dgwSubgrupo.AllowUserToOrderColumns = true;
            this.dgwSubgrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSubgrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwSubgrupo.Location = new System.Drawing.Point(399, 3);
            this.dgwSubgrupo.Name = "dgwSubgrupo";
            this.dgwSubgrupo.ReadOnly = true;
            this.dgwSubgrupo.Size = new System.Drawing.Size(126, 231);
            this.dgwSubgrupo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mcbGrupo);
            this.groupBox1.Controls.Add(this.mtbSubgrupo);
            this.groupBox1.Controls.Add(this.mbtCadastrar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 231);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro de subgrupos";
            // 
            // mcbGrupo
            // 
            this.mcbGrupo.AutoResize = false;
            this.mcbGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mcbGrupo.Depth = 0;
            this.mcbGrupo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mcbGrupo.DropDownHeight = 174;
            this.mcbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcbGrupo.DropDownWidth = 121;
            this.mcbGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mcbGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mcbGrupo.FormattingEnabled = true;
            this.mcbGrupo.Hint = "Selecione o grupo para cadastrar o subgrupo";
            this.mcbGrupo.IntegralHeight = false;
            this.mcbGrupo.ItemHeight = 43;
            this.mcbGrupo.Location = new System.Drawing.Point(9, 28);
            this.mcbGrupo.MaxDropDownItems = 4;
            this.mcbGrupo.MouseState = MaterialSkin.MouseState.OUT;
            this.mcbGrupo.Name = "mcbGrupo";
            this.mcbGrupo.Size = new System.Drawing.Size(372, 49);
            this.mcbGrupo.StartIndex = 0;
            this.mcbGrupo.TabIndex = 6;
            this.mcbGrupo.SelectedIndexChanged += new System.EventHandler(this.mcbGrupo_SelectedIndexChanged);
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
            this.mtbSubgrupo.Location = new System.Drawing.Point(9, 122);
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
            this.mtbSubgrupo.TabIndex = 5;
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
            this.mbtCadastrar.Location = new System.Drawing.Point(284, 122);
            this.mbtCadastrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtCadastrar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtCadastrar.Name = "mbtCadastrar";
            this.mbtCadastrar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtCadastrar.Size = new System.Drawing.Size(97, 48);
            this.mbtCadastrar.TabIndex = 4;
            this.mbtCadastrar.Text = "Salvar";
            this.mbtCadastrar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtCadastrar.UseAccentColor = false;
            this.mbtCadastrar.UseVisualStyleBackColor = true;
            this.mbtCadastrar.Click += new System.EventHandler(this.mbtCadastrar_Click);
            // 
            // fmrCadastroSubGrupoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 237);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "fmrCadastroSubGrupoProduto";
            this.Text = "Cadastro subgrupo";
            this.Load += new System.EventHandler(this.fmrCadastroSubGrupoProduto_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSubgrupo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgwSubgrupo;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialComboBox mcbGrupo;
        private MaterialSkin.Controls.MaterialTextBox2 mtbSubgrupo;
        private MaterialSkin.Controls.MaterialButton mbtCadastrar;
    }
}