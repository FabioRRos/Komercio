namespace Komercio.UI.Forms.Caixa
{
    partial class fmAberturaCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAberturaCaixa));
            this.mtbValorEntrada = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbObservacao = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtAbrirCaixa = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // mtbValorEntrada
            // 
            this.mtbValorEntrada.AnimateReadOnly = false;
            this.mtbValorEntrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbValorEntrada.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbValorEntrada.Depth = 0;
            this.mtbValorEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbValorEntrada.HideSelection = true;
            this.mtbValorEntrada.Hint = "Valor para abertura do caixa";
            this.mtbValorEntrada.LeadingIcon = null;
            this.mtbValorEntrada.Location = new System.Drawing.Point(12, 23);
            this.mtbValorEntrada.MaxLength = 32767;
            this.mtbValorEntrada.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbValorEntrada.Name = "mtbValorEntrada";
            this.mtbValorEntrada.PasswordChar = '\0';
            this.mtbValorEntrada.PrefixSuffixText = null;
            this.mtbValorEntrada.ReadOnly = false;
            this.mtbValorEntrada.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbValorEntrada.SelectedText = "";
            this.mtbValorEntrada.SelectionLength = 0;
            this.mtbValorEntrada.SelectionStart = 0;
            this.mtbValorEntrada.ShortcutsEnabled = true;
            this.mtbValorEntrada.Size = new System.Drawing.Size(250, 48);
            this.mtbValorEntrada.TabIndex = 0;
            this.mtbValorEntrada.TabStop = false;
            this.mtbValorEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbValorEntrada.TrailingIcon = null;
            this.mtbValorEntrada.UseSystemPasswordChar = false;
            this.mtbValorEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbValorEntrada_KeyPress);
            this.mtbValorEntrada.TextChanged += new System.EventHandler(this.mtbValorEntrada_TextChanged);
            // 
            // mtbObservacao
            // 
            this.mtbObservacao.AnimateReadOnly = false;
            this.mtbObservacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbObservacao.Depth = 0;
            this.mtbObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbObservacao.HideSelection = true;
            this.mtbObservacao.Hint = "Observações";
            this.mtbObservacao.LeadingIcon = null;
            this.mtbObservacao.Location = new System.Drawing.Point(12, 95);
            this.mtbObservacao.MaxLength = 32767;
            this.mtbObservacao.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbObservacao.Name = "mtbObservacao";
            this.mtbObservacao.PasswordChar = '\0';
            this.mtbObservacao.PrefixSuffixText = null;
            this.mtbObservacao.ReadOnly = false;
            this.mtbObservacao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbObservacao.SelectedText = "";
            this.mtbObservacao.SelectionLength = 0;
            this.mtbObservacao.SelectionStart = 0;
            this.mtbObservacao.ShortcutsEnabled = true;
            this.mtbObservacao.Size = new System.Drawing.Size(250, 48);
            this.mtbObservacao.TabIndex = 2;
            this.mtbObservacao.TabStop = false;
            this.mtbObservacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbObservacao.TrailingIcon = null;
            this.mtbObservacao.UseSystemPasswordChar = false;
            // 
            // mbtAbrirCaixa
            // 
            this.mbtAbrirCaixa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtAbrirCaixa.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtAbrirCaixa.Depth = 0;
            this.mbtAbrirCaixa.HighEmphasis = true;
            this.mbtAbrirCaixa.Icon = null;
            this.mbtAbrirCaixa.Location = new System.Drawing.Point(72, 166);
            this.mbtAbrirCaixa.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtAbrirCaixa.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtAbrirCaixa.Name = "mbtAbrirCaixa";
            this.mbtAbrirCaixa.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtAbrirCaixa.Size = new System.Drawing.Size(109, 36);
            this.mbtAbrirCaixa.TabIndex = 3;
            this.mbtAbrirCaixa.Text = "Abrir Caixa";
            this.mbtAbrirCaixa.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtAbrirCaixa.UseAccentColor = false;
            this.mbtAbrirCaixa.UseVisualStyleBackColor = true;
            this.mbtAbrirCaixa.Click += new System.EventHandler(this.mbtAbrirCaixa_Click);
            // 
            // fmAberturaCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 219);
            this.Controls.Add(this.mbtAbrirCaixa);
            this.Controls.Add(this.mtbObservacao);
            this.Controls.Add(this.mtbValorEntrada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmAberturaCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abertura de caixa";
            this.Load += new System.EventHandler(this.fmAberturaCaixa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mtbValorEntrada;
        private MaterialSkin.Controls.MaterialTextBox2 mtbObservacao;
        private MaterialSkin.Controls.MaterialButton mbtAbrirCaixa;
    }
}