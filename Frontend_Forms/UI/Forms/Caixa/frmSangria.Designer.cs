namespace Komercio.UI.Forms.Caixa
{
    partial class frmSangria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSangria));
            this.mtbValorSangria = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbJustificativa = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtSalvar = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // mtbValorSangria
            // 
            this.mtbValorSangria.AnimateReadOnly = false;
            this.mtbValorSangria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbValorSangria.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbValorSangria.Depth = 0;
            this.mtbValorSangria.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbValorSangria.HideSelection = true;
            this.mtbValorSangria.Hint = "Valor retirado";
            this.mtbValorSangria.LeadingIcon = null;
            this.mtbValorSangria.Location = new System.Drawing.Point(13, 12);
            this.mtbValorSangria.MaxLength = 32767;
            this.mtbValorSangria.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbValorSangria.Name = "mtbValorSangria";
            this.mtbValorSangria.PasswordChar = '\0';
            this.mtbValorSangria.PrefixSuffixText = null;
            this.mtbValorSangria.ReadOnly = false;
            this.mtbValorSangria.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbValorSangria.SelectedText = "";
            this.mtbValorSangria.SelectionLength = 0;
            this.mtbValorSangria.SelectionStart = 0;
            this.mtbValorSangria.ShortcutsEnabled = true;
            this.mtbValorSangria.Size = new System.Drawing.Size(250, 48);
            this.mtbValorSangria.TabIndex = 0;
            this.mtbValorSangria.TabStop = false;
            this.mtbValorSangria.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbValorSangria.TrailingIcon = null;
            this.mtbValorSangria.UseSystemPasswordChar = false;
            this.mtbValorSangria.Click += new System.EventHandler(this.mtbValorSangria_Click);
            this.mtbValorSangria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbValorSangria_KeyPress);
            this.mtbValorSangria.TextChanged += new System.EventHandler(this.mtbValorSangria_TextChanged);
            // 
            // mtbJustificativa
            // 
            this.mtbJustificativa.AnimateReadOnly = false;
            this.mtbJustificativa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbJustificativa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbJustificativa.Depth = 0;
            this.mtbJustificativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbJustificativa.HelperText = "Ex: Compra de papel";
            this.mtbJustificativa.HideSelection = true;
            this.mtbJustificativa.Hint = "Justificativa";
            this.mtbJustificativa.LeadingIcon = null;
            this.mtbJustificativa.Location = new System.Drawing.Point(13, 93);
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
            this.mtbJustificativa.ShowAssistiveText = true;
            this.mtbJustificativa.Size = new System.Drawing.Size(250, 64);
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
            this.mbtSalvar.Location = new System.Drawing.Point(100, 172);
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
            // frmSangria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 231);
            this.Controls.Add(this.mbtSalvar);
            this.Controls.Add(this.mtbJustificativa);
            this.Controls.Add(this.mtbValorSangria);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSangria";
            this.Text = "Sangria";
            this.Load += new System.EventHandler(this.frmSangria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mtbValorSangria;
        private MaterialSkin.Controls.MaterialTextBox2 mtbJustificativa;
        private MaterialSkin.Controls.MaterialButton mbtSalvar;
    }
}