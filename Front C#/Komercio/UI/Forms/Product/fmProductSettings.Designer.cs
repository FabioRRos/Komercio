namespace Komercio.UI.Forms.Product
{
    partial class fmProductSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmProductSettings));
            this.tpStockNotification = new System.Windows.Forms.TabPage();
            this.dgwNotStick = new System.Windows.Forms.DataGridView();
            this.tbControlProductSettings = new System.Windows.Forms.TabControl();
            this.mbtnSalvar = new MaterialSkin.Controls.MaterialButton();
            this.tpStockNotification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwNotStick)).BeginInit();
            this.tbControlProductSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpStockNotification
            // 
            this.tpStockNotification.Controls.Add(this.dgwNotStick);
            this.tpStockNotification.Location = new System.Drawing.Point(4, 22);
            this.tpStockNotification.Name = "tpStockNotification";
            this.tpStockNotification.Padding = new System.Windows.Forms.Padding(3);
            this.tpStockNotification.Size = new System.Drawing.Size(484, 360);
            this.tpStockNotification.TabIndex = 0;
            this.tpStockNotification.Text = "Notificação estoque";
            this.tpStockNotification.UseVisualStyleBackColor = true;
            // 
            // dgwNotStick
            // 
            this.dgwNotStick.AllowUserToAddRows = false;
            this.dgwNotStick.AllowUserToDeleteRows = false;
            this.dgwNotStick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwNotStick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwNotStick.Location = new System.Drawing.Point(3, 3);
            this.dgwNotStick.Name = "dgwNotStick";
            this.dgwNotStick.Size = new System.Drawing.Size(478, 354);
            this.dgwNotStick.TabIndex = 0;
            this.dgwNotStick.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwNotStick_CellEndEdit);
            this.dgwNotStick.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwNotStick_CellValueChanged);
            this.dgwNotStick.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgwNotStick_EditingControlShowing);
            // 
            // tbControlProductSettings
            // 
            this.tbControlProductSettings.Controls.Add(this.tpStockNotification);
            this.tbControlProductSettings.Location = new System.Drawing.Point(12, 12);
            this.tbControlProductSettings.Name = "tbControlProductSettings";
            this.tbControlProductSettings.SelectedIndex = 0;
            this.tbControlProductSettings.Size = new System.Drawing.Size(492, 386);
            this.tbControlProductSettings.TabIndex = 0;
            // 
            // mbtnSalvar
            // 
            this.mbtnSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtnSalvar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtnSalvar.Depth = 0;
            this.mbtnSalvar.HighEmphasis = true;
            this.mbtnSalvar.Icon = null;
            this.mbtnSalvar.Location = new System.Drawing.Point(197, 400);
            this.mbtnSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtnSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtnSalvar.Name = "mbtnSalvar";
            this.mbtnSalvar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtnSalvar.Size = new System.Drawing.Size(76, 36);
            this.mbtnSalvar.TabIndex = 1;
            this.mbtnSalvar.Text = "Salvar";
            this.mbtnSalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtnSalvar.UseAccentColor = false;
            this.mbtnSalvar.UseVisualStyleBackColor = true;
            this.mbtnSalvar.Click += new System.EventHandler(this.mbtnSalvar_Click);
            // 
            // fmProductSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 440);
            this.Controls.Add(this.mbtnSalvar);
            this.Controls.Add(this.tbControlProductSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmProductSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habilitar notificações";
            this.Load += new System.EventHandler(this.fmProductSettings_Load);
            this.tpStockNotification.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwNotStick)).EndInit();
            this.tbControlProductSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tpStockNotification;
        private System.Windows.Forms.TabControl tbControlProductSettings;
        private System.Windows.Forms.DataGridView dgwNotStick;
        private MaterialSkin.Controls.MaterialButton mbtnSalvar;
    }
}