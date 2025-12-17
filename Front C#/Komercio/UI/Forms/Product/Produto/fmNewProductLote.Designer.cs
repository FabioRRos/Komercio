namespace Komercio.UI.Forms.Product
{
    partial class btnImportStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnImportStock));
            this.mtbDirectorySearcher = new MaterialSkin.Controls.MaterialButton();
            this.dgwImportList = new System.Windows.Forms.DataGridView();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgwImportList)).BeginInit();
            this.SuspendLayout();
            // 
            // mtbDirectorySearcher
            // 
            this.mtbDirectorySearcher.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbDirectorySearcher.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbDirectorySearcher.Depth = 0;
            this.mtbDirectorySearcher.HighEmphasis = true;
            this.mtbDirectorySearcher.Icon = null;
            this.mtbDirectorySearcher.Location = new System.Drawing.Point(28, 15);
            this.mtbDirectorySearcher.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbDirectorySearcher.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbDirectorySearcher.Name = "mtbDirectorySearcher";
            this.mtbDirectorySearcher.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbDirectorySearcher.Size = new System.Drawing.Size(163, 36);
            this.mtbDirectorySearcher.TabIndex = 0;
            this.mtbDirectorySearcher.Text = "Procurar arquivo";
            this.mtbDirectorySearcher.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbDirectorySearcher.UseAccentColor = false;
            this.mtbDirectorySearcher.UseVisualStyleBackColor = true;
            this.mtbDirectorySearcher.Click += new System.EventHandler(this.mtbDirectorySearcher_Click);
            // 
            // dgwImportList
            // 
            this.dgwImportList.AllowUserToAddRows = false;
            this.dgwImportList.AllowUserToDeleteRows = false;
            this.dgwImportList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwImportList.Location = new System.Drawing.Point(12, 79);
            this.dgwImportList.Name = "dgwImportList";
            this.dgwImportList.ReadOnly = true;
            this.dgwImportList.Size = new System.Drawing.Size(596, 207);
            this.dgwImportList.TabIndex = 1;
            //this.dgwImportList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.Enabled = false;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(431, 15);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(163, 36);
            this.materialButton1.TabIndex = 2;
            this.materialButton1.Text = "Importar para estoque";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // btnImportStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 299);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.dgwImportList);
            this.Controls.Add(this.mtbDirectorySearcher);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "btnImportStock";
            this.Text = "Cadastro em lote";
            this.Load += new System.EventHandler(this.btnImportStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwImportList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton mtbDirectorySearcher;
        private System.Windows.Forms.DataGridView dgwImportList;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}