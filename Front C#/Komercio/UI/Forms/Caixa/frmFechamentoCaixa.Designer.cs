namespace Komercio.UI.Forms
{
    partial class frmFechamentoCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFechamentoCaixa));
            this.mtbDinheiro = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbDebito = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCredito = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbPix = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbConta = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtFechar = new MaterialSkin.Controls.MaterialButton();
            this.mtbSangria = new MaterialSkin.Controls.MaterialTextBox2();
            this.rtbCupon = new System.Windows.Forms.RichTextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.mtbJustificativa = new MaterialSkin.Controls.MaterialTextBox2();
            this.mcbJustDif = new MaterialSkin.Controls.MaterialCheckbox();
            this.SuspendLayout();
            // 
            // mtbDinheiro
            // 
            this.mtbDinheiro.AnimateReadOnly = false;
            this.mtbDinheiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDinheiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDinheiro.Depth = 0;
            this.mtbDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDinheiro.HideSelection = true;
            this.mtbDinheiro.Hint = "Dinheiro";
            this.mtbDinheiro.LeadingIcon = null;
            this.mtbDinheiro.Location = new System.Drawing.Point(23, 17);
            this.mtbDinheiro.MaxLength = 32767;
            this.mtbDinheiro.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDinheiro.Name = "mtbDinheiro";
            this.mtbDinheiro.PasswordChar = '\0';
            this.mtbDinheiro.PrefixSuffixText = null;
            this.mtbDinheiro.ReadOnly = false;
            this.mtbDinheiro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDinheiro.SelectedText = "";
            this.mtbDinheiro.SelectionLength = 0;
            this.mtbDinheiro.SelectionStart = 0;
            this.mtbDinheiro.ShortcutsEnabled = true;
            this.mtbDinheiro.ShowAssistiveText = true;
            this.mtbDinheiro.Size = new System.Drawing.Size(250, 64);
            this.mtbDinheiro.TabIndex = 1;
            this.mtbDinheiro.TabStop = false;
            this.mtbDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDinheiro.TrailingIcon = null;
            this.mtbDinheiro.UseSystemPasswordChar = false;
            this.mtbDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDinheiro_KeyPress);
            this.mtbDinheiro.TextChanged += new System.EventHandler(this.mtbDinheiro_TextChanged);
            // 
            // mtbDebito
            // 
            this.mtbDebito.AnimateReadOnly = false;
            this.mtbDebito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDebito.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDebito.Depth = 0;
            this.mtbDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDebito.HideSelection = true;
            this.mtbDebito.LeadingIcon = null;
            this.mtbDebito.Location = new System.Drawing.Point(23, 87);
            this.mtbDebito.MaxLength = 32767;
            this.mtbDebito.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDebito.Name = "mtbDebito";
            this.mtbDebito.PasswordChar = '\0';
            this.mtbDebito.PrefixSuffixText = null;
            this.mtbDebito.ReadOnly = false;
            this.mtbDebito.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDebito.SelectedText = "";
            this.mtbDebito.SelectionLength = 0;
            this.mtbDebito.SelectionStart = 0;
            this.mtbDebito.ShortcutsEnabled = true;
            this.mtbDebito.ShowAssistiveText = true;
            this.mtbDebito.Size = new System.Drawing.Size(250, 64);
            this.mtbDebito.TabIndex = 2;
            this.mtbDebito.TabStop = false;
            this.mtbDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDebito.TrailingIcon = null;
            this.mtbDebito.UseSystemPasswordChar = false;
            this.mtbDebito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDebito_KeyPress);
            this.mtbDebito.TextChanged += new System.EventHandler(this.mtbDebito_TextChanged);
            // 
            // mtbCredito
            // 
            this.mtbCredito.AnimateReadOnly = false;
            this.mtbCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCredito.Depth = 0;
            this.mtbCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCredito.HideSelection = true;
            this.mtbCredito.Hint = "Crédito";
            this.mtbCredito.LeadingIcon = null;
            this.mtbCredito.Location = new System.Drawing.Point(23, 157);
            this.mtbCredito.MaxLength = 32767;
            this.mtbCredito.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCredito.Name = "mtbCredito";
            this.mtbCredito.PasswordChar = '\0';
            this.mtbCredito.PrefixSuffixText = null;
            this.mtbCredito.ReadOnly = false;
            this.mtbCredito.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCredito.SelectedText = "";
            this.mtbCredito.SelectionLength = 0;
            this.mtbCredito.SelectionStart = 0;
            this.mtbCredito.ShortcutsEnabled = true;
            this.mtbCredito.ShowAssistiveText = true;
            this.mtbCredito.Size = new System.Drawing.Size(250, 64);
            this.mtbCredito.TabIndex = 3;
            this.mtbCredito.TabStop = false;
            this.mtbCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCredito.TrailingIcon = null;
            this.mtbCredito.UseSystemPasswordChar = false;
            this.mtbCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbCredito_KeyPress);
            this.mtbCredito.TextChanged += new System.EventHandler(this.mtbCredito_TextChanged);
            // 
            // mtbPix
            // 
            this.mtbPix.AnimateReadOnly = false;
            this.mtbPix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbPix.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbPix.Depth = 0;
            this.mtbPix.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbPix.HideSelection = true;
            this.mtbPix.Hint = "Pix";
            this.mtbPix.LeadingIcon = null;
            this.mtbPix.Location = new System.Drawing.Point(23, 227);
            this.mtbPix.MaxLength = 32767;
            this.mtbPix.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbPix.Name = "mtbPix";
            this.mtbPix.PasswordChar = '\0';
            this.mtbPix.PrefixSuffixText = null;
            this.mtbPix.ReadOnly = false;
            this.mtbPix.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbPix.SelectedText = "";
            this.mtbPix.SelectionLength = 0;
            this.mtbPix.SelectionStart = 0;
            this.mtbPix.ShortcutsEnabled = true;
            this.mtbPix.ShowAssistiveText = true;
            this.mtbPix.Size = new System.Drawing.Size(250, 64);
            this.mtbPix.TabIndex = 4;
            this.mtbPix.TabStop = false;
            this.mtbPix.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbPix.TrailingIcon = null;
            this.mtbPix.UseSystemPasswordChar = false;
            this.mtbPix.Click += new System.EventHandler(this.materialTextBox24_Click);
            this.mtbPix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbPix_KeyPress);
            this.mtbPix.TextChanged += new System.EventHandler(this.mtbPix_TextChanged);
            // 
            // mtbConta
            // 
            this.mtbConta.AnimateReadOnly = false;
            this.mtbConta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbConta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbConta.Depth = 0;
            this.mtbConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbConta.HideSelection = true;
            this.mtbConta.Hint = "Conta";
            this.mtbConta.LeadingIcon = null;
            this.mtbConta.Location = new System.Drawing.Point(23, 297);
            this.mtbConta.MaxLength = 32767;
            this.mtbConta.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbConta.Name = "mtbConta";
            this.mtbConta.PasswordChar = '\0';
            this.mtbConta.PrefixSuffixText = null;
            this.mtbConta.ReadOnly = false;
            this.mtbConta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbConta.SelectedText = "";
            this.mtbConta.SelectionLength = 0;
            this.mtbConta.SelectionStart = 0;
            this.mtbConta.ShortcutsEnabled = true;
            this.mtbConta.ShowAssistiveText = true;
            this.mtbConta.Size = new System.Drawing.Size(250, 64);
            this.mtbConta.TabIndex = 5;
            this.mtbConta.TabStop = false;
            this.mtbConta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbConta.TrailingIcon = null;
            this.mtbConta.UseSystemPasswordChar = false;
            this.mtbConta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbConta_KeyPress);
            this.mtbConta.TextChanged += new System.EventHandler(this.mtbConta_TextChanged);
            // 
            // mbtFechar
            // 
            this.mbtFechar.AutoSize = false;
            this.mbtFechar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtFechar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtFechar.Depth = 0;
            this.mbtFechar.HighEmphasis = true;
            this.mbtFechar.Icon = null;
            this.mbtFechar.Location = new System.Drawing.Point(450, 370);
            this.mbtFechar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtFechar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtFechar.Name = "mbtFechar";
            this.mbtFechar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtFechar.Size = new System.Drawing.Size(119, 36);
            this.mbtFechar.TabIndex = 8;
            this.mbtFechar.Text = "Fechar Caixa";
            this.mbtFechar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtFechar.UseAccentColor = true;
            this.mbtFechar.UseVisualStyleBackColor = true;
            this.mbtFechar.Click += new System.EventHandler(this.mbtFechar_Click);
            // 
            // mtbSangria
            // 
            this.mtbSangria.AnimateReadOnly = false;
            this.mtbSangria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbSangria.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbSangria.Depth = 0;
            this.mtbSangria.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbSangria.HideSelection = true;
            this.mtbSangria.Hint = "Sangria";
            this.mtbSangria.LeadingIcon = null;
            this.mtbSangria.Location = new System.Drawing.Point(23, 371);
            this.mtbSangria.MaxLength = 32767;
            this.mtbSangria.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbSangria.Name = "mtbSangria";
            this.mtbSangria.PasswordChar = '\0';
            this.mtbSangria.PrefixSuffixText = null;
            this.mtbSangria.ReadOnly = false;
            this.mtbSangria.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbSangria.SelectedText = "";
            this.mtbSangria.SelectionLength = 0;
            this.mtbSangria.SelectionStart = 0;
            this.mtbSangria.ShortcutsEnabled = true;
            this.mtbSangria.ShowAssistiveText = true;
            this.mtbSangria.Size = new System.Drawing.Size(250, 64);
            this.mtbSangria.TabIndex = 6;
            this.mtbSangria.TabStop = false;
            this.mtbSangria.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbSangria.TrailingIcon = null;
            this.mtbSangria.UseSystemPasswordChar = false;
            this.mtbSangria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbSangria_KeyPress);
            this.mtbSangria.TextChanged += new System.EventHandler(this.mtbSangria_TextChanged);
            // 
            // rtbCupon
            // 
            this.rtbCupon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbCupon.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbCupon.Location = new System.Drawing.Point(279, 17);
            this.rtbCupon.Name = "rtbCupon";
            this.rtbCupon.ReadOnly = true;
            this.rtbCupon.Size = new System.Drawing.Size(290, 344);
            this.rtbCupon.TabIndex = 9;
            this.rtbCupon.Text = "";
            this.rtbCupon.TextChanged += new System.EventHandler(this.rtbCupon_TextChanged);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(280, 371);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(147, 36);
            this.materialButton1.TabIndex = 7;
            this.materialButton1.Text = "Visualizar cupom";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // mtbJustificativa
            // 
            this.mtbJustificativa.AnimateReadOnly = false;
            this.mtbJustificativa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbJustificativa.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbJustificativa.Depth = 0;
            this.mtbJustificativa.Enabled = false;
            this.mtbJustificativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbJustificativa.HelperText = "Motivo da diferença.";
            this.mtbJustificativa.HideSelection = true;
            this.mtbJustificativa.Hint = "Justificativa";
            this.mtbJustificativa.LeadingIcon = null;
            this.mtbJustificativa.Location = new System.Drawing.Point(23, 441);
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
            this.mtbJustificativa.TabIndex = 10;
            this.mtbJustificativa.TabStop = false;
            this.mtbJustificativa.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbJustificativa.TrailingIcon = null;
            this.mtbJustificativa.UseSystemPasswordChar = false;
            // 
            // mcbJustDif
            // 
            this.mcbJustDif.AutoSize = true;
            this.mcbJustDif.Depth = 0;
            this.mcbJustDif.Location = new System.Drawing.Point(297, 441);
            this.mcbJustDif.Margin = new System.Windows.Forms.Padding(0);
            this.mcbJustDif.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mcbJustDif.MouseState = MaterialSkin.MouseState.HOVER;
            this.mcbJustDif.Name = "mcbJustDif";
            this.mcbJustDif.ReadOnly = false;
            this.mcbJustDif.Ripple = true;
            this.mcbJustDif.Size = new System.Drawing.Size(176, 37);
            this.mcbJustDif.TabIndex = 11;
            this.mcbJustDif.Text = "Justificar diferença.";
            this.mcbJustDif.UseVisualStyleBackColor = true;
            this.mcbJustDif.CheckedChanged += new System.EventHandler(this.mcbJustDif_CheckedChanged);
            // 
            // frmFechamentoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 506);
            this.Controls.Add(this.mcbJustDif);
            this.Controls.Add(this.mtbJustificativa);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.rtbCupon);
            this.Controls.Add(this.mtbSangria);
            this.Controls.Add(this.mbtFechar);
            this.Controls.Add(this.mtbConta);
            this.Controls.Add(this.mtbPix);
            this.Controls.Add(this.mtbCredito);
            this.Controls.Add(this.mtbDebito);
            this.Controls.Add(this.mtbDinheiro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFechamentoCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fechamento de caixa";
            this.Load += new System.EventHandler(this.frmCaixa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 mtbDinheiro;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDebito;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCredito;
        private MaterialSkin.Controls.MaterialTextBox2 mtbPix;
        private MaterialSkin.Controls.MaterialTextBox2 mtbConta;
        private MaterialSkin.Controls.MaterialButton mbtFechar;
        private MaterialSkin.Controls.MaterialTextBox2 mtbSangria;
        private System.Windows.Forms.RichTextBox rtbCupon;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialTextBox2 mtbJustificativa;
        private MaterialSkin.Controls.MaterialCheckbox mcbJustDif;
    }
}