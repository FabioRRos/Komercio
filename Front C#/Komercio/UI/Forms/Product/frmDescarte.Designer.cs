namespace Komercio.UI.Forms.Product
{
    partial class frmDescarte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescarte));
            this.mtbCodBarras = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbJustificativa = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtSalvar = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // mtbCodBarras
            // 
            this.mtbCodBarras.AnimateReadOnly = false;
            this.mtbCodBarras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCodBarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCodBarras.Depth = 0;
            this.mtbCodBarras.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCodBarras.HideSelection = true;
            this.mtbCodBarras.Hint = "Código de barras";
            this.mtbCodBarras.LeadingIcon = null;
            this.mtbCodBarras.Location = new System.Drawing.Point(9, 12);
            this.mtbCodBarras.MaxLength = 32767;
            this.mtbCodBarras.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCodBarras.Name = "mtbCodBarras";
            this.mtbCodBarras.PasswordChar = '\0';
            this.mtbCodBarras.PrefixSuffixText = null;
            this.mtbCodBarras.ReadOnly = false;
            this.mtbCodBarras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCodBarras.SelectedText = "";
            this.mtbCodBarras.SelectionLength = 0;
            this.mtbCodBarras.SelectionStart = 0;
            this.mtbCodBarras.ShortcutsEnabled = true;
            this.mtbCodBarras.Size = new System.Drawing.Size(250, 48);
            this.mtbCodBarras.TabIndex = 0;
            this.mtbCodBarras.TabStop = false;
            this.mtbCodBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCodBarras.TrailingIcon = null;
            this.mtbCodBarras.UseSystemPasswordChar = false;
            // 
            // mtbJustificativa
            // 
            this.mtbJustificativa.AnimateReadOnly = false;
            this.mtbJustificativa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbJustificativa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbJustificativa.Depth = 0;
            this.mtbJustificativa.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbJustificativa.HideSelection = true;
            this.mtbJustificativa.Hint = "Justificativa";
            this.mtbJustificativa.LeadingIcon = null;
            this.mtbJustificativa.Location = new System.Drawing.Point(9, 84);
            this.mtbJustificativa.MaxLength = 32767;
            this.mtbJustificativa.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbJustificativa.Name = "mtbJustificativa";
            this.mtbJustificativa.PasswordChar = '\0';
            this.mtbJustificativa.PrefixSuffixText = null;
            this.mtbJustificativa.ReadOnly = false;
            this.mtbJustificativa.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbJustificativa.SelectedText = "";
            this.mtbJustificativa.SelectionLength = 0;
            this.mtbJustificativa.SelectionStart = 0;
            this.mtbJustificativa.ShortcutsEnabled = true;
            this.mtbJustificativa.Size = new System.Drawing.Size(250, 48);
            this.mtbJustificativa.TabIndex = 1;
            this.mtbJustificativa.TabStop = false;
            this.mtbJustificativa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbJustificativa.TrailingIcon = null;
            this.mtbJustificativa.UseSystemPasswordChar = false;
            // 
            // mbtSalvar
            // 
            this.mbtSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtSalvar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtSalvar.Depth = 0;
            this.mbtSalvar.HighEmphasis = true;
            this.mbtSalvar.Icon = null;
            this.mbtSalvar.Location = new System.Drawing.Point(96, 151);
            this.mbtSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtSalvar.Name = "mbtSalvar";
            this.mbtSalvar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtSalvar.Size = new System.Drawing.Size(76, 36);
            this.mbtSalvar.TabIndex = 2;
            this.mbtSalvar.Text = "Salvar";
            this.mbtSalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtSalvar.UseAccentColor = false;
            this.mbtSalvar.UseVisualStyleBackColor = true;
            this.mbtSalvar.Click += new System.EventHandler(this.mbtSalvar_Click);
            // 
            // frmDescarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 202);
            this.Controls.Add(this.mbtSalvar);
            this.Controls.Add(this.mtbJustificativa);
            this.Controls.Add(this.mtbCodBarras);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDescarte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descarte de produto";
            this.Load += new System.EventHandler(this.frmDescarte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mtbCodBarras;
        private MaterialSkin.Controls.MaterialTextBox2 mtbJustificativa;
        private MaterialSkin.Controls.MaterialButton mbtSalvar;
    }
}