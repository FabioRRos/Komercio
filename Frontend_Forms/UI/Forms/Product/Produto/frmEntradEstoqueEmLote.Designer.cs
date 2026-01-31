namespace Komercio.UI.Forms.Product.Produto
{
    partial class frmEntradEstoqueEmLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntradEstoqueEmLote));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgwListaDeProdutos = new System.Windows.Forms.DataGridView();
            this.tcPassos = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mtbDiretorio = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnMapearESalvar = new MaterialSkin.Controls.MaterialButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.mbtLoadArquivo = new MaterialSkin.Controls.MaterialButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.mPBload = new MaterialSkin.Controls.MaterialProgressBar();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaDeProdutos)).BeginInit();
            this.tcPassos.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgwListaDeProdutos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tcPassos, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgwListaDeProdutos
            // 
            this.dgwListaDeProdutos.AllowUserToAddRows = false;
            this.dgwListaDeProdutos.AllowUserToDeleteRows = false;
            this.dgwListaDeProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListaDeProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwListaDeProdutos.Location = new System.Drawing.Point(3, 93);
            this.dgwListaDeProdutos.Name = "dgwListaDeProdutos";
            this.dgwListaDeProdutos.ReadOnly = true;
            this.dgwListaDeProdutos.Size = new System.Drawing.Size(638, 354);
            this.dgwListaDeProdutos.TabIndex = 0;
            // 
            // tcPassos
            // 
            this.tcPassos.Controls.Add(this.tabPage1);
            this.tcPassos.Controls.Add(this.tabPage2);
            this.tcPassos.Controls.Add(this.tabPage3);
            this.tcPassos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPassos.Location = new System.Drawing.Point(3, 3);
            this.tcPassos.Name = "tcPassos";
            this.tcPassos.SelectedIndex = 0;
            this.tcPassos.Size = new System.Drawing.Size(638, 84);
            this.tcPassos.TabIndex = 1;
            this.tcPassos.SelectedIndexChanged += new System.EventHandler(this.tcPassos_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mtbDiretorio);
            this.tabPage1.Controls.Add(this.btnMapearESalvar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(630, 58);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Passo 1 - Salve o arquivo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mtbDiretorio
            // 
            this.mtbDiretorio.AnimateReadOnly = false;
            this.mtbDiretorio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDiretorio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDiretorio.Depth = 0;
            this.mtbDiretorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDiretorio.HideSelection = true;
            this.mtbDiretorio.Hint = "Caminho onde será salvo o arquivo";
            this.mtbDiretorio.LeadingIcon = null;
            this.mtbDiretorio.Location = new System.Drawing.Point(87, 10);
            this.mtbDiretorio.MaxLength = 32767;
            this.mtbDiretorio.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDiretorio.Name = "mtbDiretorio";
            this.mtbDiretorio.PasswordChar = '\0';
            this.mtbDiretorio.PrefixSuffixText = null;
            this.mtbDiretorio.ReadOnly = false;
            this.mtbDiretorio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDiretorio.SelectedText = "";
            this.mtbDiretorio.SelectionLength = 0;
            this.mtbDiretorio.SelectionStart = 0;
            this.mtbDiretorio.ShortcutsEnabled = true;
            this.mtbDiretorio.Size = new System.Drawing.Size(316, 36);
            this.mtbDiretorio.TabIndex = 1;
            this.mtbDiretorio.TabStop = false;
            this.mtbDiretorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDiretorio.TrailingIcon = null;
            this.mtbDiretorio.UseSystemPasswordChar = false;
            this.mtbDiretorio.UseTallSize = false;
            // 
            // btnMapearESalvar
            // 
            this.btnMapearESalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMapearESalvar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMapearESalvar.Depth = 0;
            this.btnMapearESalvar.HighEmphasis = true;
            this.btnMapearESalvar.Icon = null;
            this.btnMapearESalvar.Location = new System.Drawing.Point(410, 10);
            this.btnMapearESalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnMapearESalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMapearESalvar.Name = "btnMapearESalvar";
            this.btnMapearESalvar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMapearESalvar.Size = new System.Drawing.Size(76, 36);
            this.btnMapearESalvar.TabIndex = 0;
            this.btnMapearESalvar.Text = "Salvar";
            this.btnMapearESalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMapearESalvar.UseAccentColor = false;
            this.btnMapearESalvar.UseVisualStyleBackColor = true;
            this.btnMapearESalvar.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.mbtLoadArquivo);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(630, 58);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Passo 2 - Carregue os arquivos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(139, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Confira a quantidade dos itens que serão imputados no estoque.";
            // 
            // mbtLoadArquivo
            // 
            this.mbtLoadArquivo.AutoSize = false;
            this.mbtLoadArquivo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtLoadArquivo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtLoadArquivo.Depth = 0;
            this.mbtLoadArquivo.HighEmphasis = true;
            this.mbtLoadArquivo.Icon = null;
            this.mbtLoadArquivo.Location = new System.Drawing.Point(168, 8);
            this.mbtLoadArquivo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtLoadArquivo.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtLoadArquivo.Name = "mbtLoadArquivo";
            this.mbtLoadArquivo.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtLoadArquivo.Size = new System.Drawing.Size(253, 30);
            this.mbtLoadArquivo.TabIndex = 0;
            this.mbtLoadArquivo.Text = "Carregar arquivo de estoque";
            this.mbtLoadArquivo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtLoadArquivo.UseAccentColor = false;
            this.mbtLoadArquivo.UseVisualStyleBackColor = true;
            this.mbtLoadArquivo.Click += new System.EventHandler(this.mbtLoadArquivo_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.mPBload);
            this.tabPage3.Controls.Add(this.materialButton1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(630, 58);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Passo 3 - Salve a entrada";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // mPBload
            // 
            this.mPBload.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.mPBload.Depth = 0;
            this.mPBload.ForeColor = System.Drawing.Color.Magenta;
            this.mPBload.Location = new System.Drawing.Point(6, 47);
            this.mPBload.MouseState = MaterialSkin.MouseState.HOVER;
            this.mPBload.Name = "mPBload";
            this.mPBload.Size = new System.Drawing.Size(618, 5);
            this.mPBload.Step = 1;
            this.mPBload.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.mPBload.TabIndex = 1;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(196, 6);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(202, 36);
            this.materialButton1.TabIndex = 0;
            this.materialButton1.Text = "Iniciar Processamento";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click_1);
            // 
            // frmEntradEstoqueEmLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEntradEstoqueEmLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada em estoque";
            this.Load += new System.EventHandler(this.frmEntradEstoqueEmLote_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwListaDeProdutos)).EndInit();
            this.tcPassos.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgwListaDeProdutos;
        private System.Windows.Forms.TabControl tcPassos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialButton btnMapearESalvar;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDiretorio;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialButton mbtLoadArquivo;
        private MaterialSkin.Controls.MaterialProgressBar mPBload;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}