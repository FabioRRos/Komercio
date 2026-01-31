namespace Komercio.UI.Forms
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.mtbLoginEmployeer = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbPasswordEmployeer = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.mbtVer = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // mtbLoginEmployeer
            // 
            this.mtbLoginEmployeer.AnimateReadOnly = false;
            this.mtbLoginEmployeer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbLoginEmployeer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbLoginEmployeer.Depth = 0;
            this.mtbLoginEmployeer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbLoginEmployeer.HideSelection = true;
            this.mtbLoginEmployeer.Hint = "Usuário";
            this.mtbLoginEmployeer.LeadingIcon = null;
            this.mtbLoginEmployeer.Location = new System.Drawing.Point(18, 17);
            this.mtbLoginEmployeer.MaxLength = 32767;
            this.mtbLoginEmployeer.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbLoginEmployeer.Name = "mtbLoginEmployeer";
            this.mtbLoginEmployeer.PasswordChar = '\0';
            this.mtbLoginEmployeer.PrefixSuffixText = "Primeira letra do nome + . + sobrenome.";
            this.mtbLoginEmployeer.ReadOnly = false;
            this.mtbLoginEmployeer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbLoginEmployeer.SelectedText = "";
            this.mtbLoginEmployeer.SelectionLength = 0;
            this.mtbLoginEmployeer.SelectionStart = 0;
            this.mtbLoginEmployeer.ShortcutsEnabled = true;
            this.mtbLoginEmployeer.ShowAssistiveText = true;
            this.mtbLoginEmployeer.Size = new System.Drawing.Size(250, 64);
            this.mtbLoginEmployeer.TabIndex = 0;
            this.mtbLoginEmployeer.TabStop = false;
            this.mtbLoginEmployeer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbLoginEmployeer.TrailingIcon = null;
            this.mtbLoginEmployeer.UseSystemPasswordChar = false;
            // 
            // mtbPasswordEmployeer
            // 
            this.mtbPasswordEmployeer.AnimateReadOnly = false;
            this.mtbPasswordEmployeer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbPasswordEmployeer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbPasswordEmployeer.Depth = 0;
            this.mtbPasswordEmployeer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbPasswordEmployeer.HideSelection = true;
            this.mtbPasswordEmployeer.Hint = "Senha";
            this.mtbPasswordEmployeer.LeadingIcon = null;
            this.mtbPasswordEmployeer.Location = new System.Drawing.Point(18, 101);
            this.mtbPasswordEmployeer.MaxLength = 32767;
            this.mtbPasswordEmployeer.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbPasswordEmployeer.Name = "mtbPasswordEmployeer";
            this.mtbPasswordEmployeer.PasswordChar = '\0';
            this.mtbPasswordEmployeer.PrefixSuffixText = null;
            this.mtbPasswordEmployeer.ReadOnly = false;
            this.mtbPasswordEmployeer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbPasswordEmployeer.SelectedText = "";
            this.mtbPasswordEmployeer.SelectionLength = 0;
            this.mtbPasswordEmployeer.SelectionStart = 0;
            this.mtbPasswordEmployeer.ShortcutsEnabled = true;
            this.mtbPasswordEmployeer.ShowAssistiveText = true;
            this.mtbPasswordEmployeer.Size = new System.Drawing.Size(250, 64);
            this.mtbPasswordEmployeer.TabIndex = 1;
            this.mtbPasswordEmployeer.TabStop = false;
            this.mtbPasswordEmployeer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbPasswordEmployeer.TrailingIcon = null;
            this.mtbPasswordEmployeer.UseSystemPasswordChar = false;
            this.mtbPasswordEmployeer.TextChanged += new System.EventHandler(this.mtbPasswordEmployeer_TextChanged);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(50, 172);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(77, 36);
            this.materialButton1.TabIndex = 2;
            this.materialButton1.Text = "Entrar";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // mbtVer
            // 
            this.mbtVer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtVer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtVer.Depth = 0;
            this.mbtVer.HighEmphasis = true;
            this.mbtVer.Icon = null;
            this.mbtVer.Location = new System.Drawing.Point(157, 172);
            this.mbtVer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtVer.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtVer.Name = "mbtVer";
            this.mbtVer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtVer.Size = new System.Drawing.Size(64, 36);
            this.mbtVer.TabIndex = 3;
            this.mbtVer.Text = "Ver";
            this.mbtVer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtVer.UseAccentColor = false;
            this.mbtVer.UseVisualStyleBackColor = true;
            this.mbtVer.Click += new System.EventHandler(this.mbtVer_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 249);
            this.Controls.Add(this.mbtVer);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.mtbPasswordEmployeer);
            this.Controls.Add(this.mtbLoginEmployeer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mtbLoginEmployeer;
        private MaterialSkin.Controls.MaterialTextBox2 mtbPasswordEmployeer;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton mbtVer;
    }
}