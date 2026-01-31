namespace Komercio.UI.Forms.ListaCompras
{
    partial class frmNewListaDeCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewListaDeCompras));
            this.btnSalvar = new MaterialSkin.Controls.MaterialButton();
            this.mtbNomeLista = new MaterialSkin.Controls.MaterialTextBox2();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSalvar.Depth = 0;
            this.btnSalvar.HighEmphasis = true;
            this.btnSalvar.Icon = null;
            this.btnSalvar.Location = new System.Drawing.Point(122, 137);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSalvar.Size = new System.Drawing.Size(76, 36);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSalvar.UseAccentColor = false;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // mtbNomeLista
            // 
            this.mtbNomeLista.AnimateReadOnly = false;
            this.mtbNomeLista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbNomeLista.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbNomeLista.Depth = 0;
            this.mtbNomeLista.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbNomeLista.HelperText = "Sugestão: Lista_Janeiro";
            this.mtbNomeLista.HideSelection = true;
            this.mtbNomeLista.Hint = "Nome da lista";
            this.mtbNomeLista.LeadingIcon = null;
            this.mtbNomeLista.Location = new System.Drawing.Point(49, 60);
            this.mtbNomeLista.MaxLength = 32767;
            this.mtbNomeLista.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbNomeLista.Name = "mtbNomeLista";
            this.mtbNomeLista.PasswordChar = '\0';
            this.mtbNomeLista.PrefixSuffixText = null;
            this.mtbNomeLista.ReadOnly = false;
            this.mtbNomeLista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbNomeLista.SelectedText = "";
            this.mtbNomeLista.SelectionLength = 0;
            this.mtbNomeLista.SelectionStart = 0;
            this.mtbNomeLista.ShortcutsEnabled = true;
            this.mtbNomeLista.Size = new System.Drawing.Size(250, 48);
            this.mtbNomeLista.TabIndex = 1;
            this.mtbNomeLista.TabStop = false;
            this.mtbNomeLista.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbNomeLista.TrailingIcon = null;
            this.mtbNomeLista.UseSystemPasswordChar = false;
            this.mtbNomeLista.Click += new System.EventHandler(this.mtbNomeLista_Click);
            // 
            // frmNewListaDeCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 224);
            this.Controls.Add(this.mtbNomeLista);
            this.Controls.Add(this.btnSalvar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewListaDeCompras";
            this.Text = "Nova lista de compra";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnSalvar;
        private MaterialSkin.Controls.MaterialTextBox2 mtbNomeLista;
    }
}