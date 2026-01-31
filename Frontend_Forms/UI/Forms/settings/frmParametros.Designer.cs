namespace Komercio.UI.Forms.settings
{
    partial class frmParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametros));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgwTabela = new System.Windows.Forms.DataGridView();
            this.mbtnSalvar = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTabela)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgwTabela, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mbtnSalvar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(318, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgwTabela
            // 
            this.dgwTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTabela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwTabela.Location = new System.Drawing.Point(3, 93);
            this.dgwTabela.Name = "dgwTabela";
            this.dgwTabela.Size = new System.Drawing.Size(312, 354);
            this.dgwTabela.TabIndex = 0;
            // 
            // mbtnSalvar
            // 
            this.mbtnSalvar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mbtnSalvar.AutoSize = false;
            this.mbtnSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtnSalvar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtnSalvar.Depth = 0;
            this.mbtnSalvar.HighEmphasis = true;
            this.mbtnSalvar.Icon = null;
            this.mbtnSalvar.Location = new System.Drawing.Point(80, 29);
            this.mbtnSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtnSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtnSalvar.Name = "mbtnSalvar";
            this.mbtnSalvar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtnSalvar.Size = new System.Drawing.Size(158, 32);
            this.mbtnSalvar.TabIndex = 1;
            this.mbtnSalvar.Text = "Salvar";
            this.mbtnSalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtnSalvar.UseAccentColor = false;
            this.mbtnSalvar.UseVisualStyleBackColor = true;
            this.mbtnSalvar.Click += new System.EventHandler(this.mbtnSalvar_Click);
            // 
            // frmParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmParametros";
            this.Text = "Parâmetros do sistema";
            this.Load += new System.EventHandler(this.frmParametros_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTabela)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgwTabela;
        private MaterialSkin.Controls.MaterialButton mbtnSalvar;
    }
}