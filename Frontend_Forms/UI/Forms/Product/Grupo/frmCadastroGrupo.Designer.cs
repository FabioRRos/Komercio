namespace Komercio.UI.Forms.Product
{
    partial class frmCadastroGrupo
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
            this.mtbGrupo = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtSalvar = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // mtbGrupo
            // 
            this.mtbGrupo.AnimateReadOnly = false;
            this.mtbGrupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbGrupo.Depth = 0;
            this.mtbGrupo.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbGrupo.HideSelection = true;
            this.mtbGrupo.Hint = "Nome do grupo";
            this.mtbGrupo.LeadingIcon = null;
            this.mtbGrupo.Location = new System.Drawing.Point(12, 23);
            this.mtbGrupo.MaxLength = 32767;
            this.mtbGrupo.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbGrupo.Name = "mtbGrupo";
            this.mtbGrupo.PasswordChar = '\0';
            this.mtbGrupo.PrefixSuffixText = null;
            this.mtbGrupo.ReadOnly = false;
            this.mtbGrupo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbGrupo.SelectedText = "";
            this.mtbGrupo.SelectionLength = 0;
            this.mtbGrupo.SelectionStart = 0;
            this.mtbGrupo.ShortcutsEnabled = true;
            this.mtbGrupo.Size = new System.Drawing.Size(250, 48);
            this.mtbGrupo.TabIndex = 0;
            this.mtbGrupo.TabStop = false;
            this.mtbGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbGrupo.TrailingIcon = null;
            this.mtbGrupo.UseSystemPasswordChar = false;
            // 
            // mbtSalvar
            // 
            this.mbtSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtSalvar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtSalvar.Depth = 0;
            this.mbtSalvar.HighEmphasis = true;
            this.mbtSalvar.Icon = null;
            this.mbtSalvar.Location = new System.Drawing.Point(73, 80);
            this.mbtSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtSalvar.Name = "mbtSalvar";
            this.mbtSalvar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtSalvar.Size = new System.Drawing.Size(128, 36);
            this.mbtSalvar.TabIndex = 1;
            this.mbtSalvar.Text = "Salvar Grupo";
            this.mbtSalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtSalvar.UseAccentColor = false;
            this.mbtSalvar.UseVisualStyleBackColor = true;
            this.mbtSalvar.Click += new System.EventHandler(this.mbtSalvar_Click);
            // 
            // frmCadastroGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 135);
            this.Controls.Add(this.mbtSalvar);
            this.Controls.Add(this.mtbGrupo);
            this.Name = "frmCadastroGrupo";
            this.Text = "Cadastrar Grupo";
            this.Load += new System.EventHandler(this.frmCadastroGrupo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mtbGrupo;
        private MaterialSkin.Controls.MaterialButton mbtSalvar;
    }
}