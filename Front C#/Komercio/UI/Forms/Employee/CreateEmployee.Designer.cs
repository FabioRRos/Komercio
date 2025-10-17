namespace Komercio.UI.Forms
{
    partial class fmCreateEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmCreateEmployee));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mtbEmployeeName = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbEmployeePassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtnNewEmployee = new MaterialSkin.Controls.MaterialButton();
            this.mbtnSaveNewEmployee = new MaterialSkin.Controls.MaterialButton();
            this.mbtnSeePassword = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome completo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Senha";
            // 
            // mtbEmployeeName
            // 
            this.mtbEmployeeName.AnimateReadOnly = false;
            this.mtbEmployeeName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbEmployeeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbEmployeeName.Depth = 0;
            this.mtbEmployeeName.Enabled = false;
            this.mtbEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbEmployeeName.HideSelection = true;
            this.mtbEmployeeName.LeadingIcon = null;
            this.mtbEmployeeName.Location = new System.Drawing.Point(37, 42);
            this.mtbEmployeeName.MaxLength = 32767;
            this.mtbEmployeeName.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbEmployeeName.Name = "mtbEmployeeName";
            this.mtbEmployeeName.PasswordChar = '\0';
            this.mtbEmployeeName.PrefixSuffixText = null;
            this.mtbEmployeeName.ReadOnly = false;
            this.mtbEmployeeName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbEmployeeName.SelectedText = "";
            this.mtbEmployeeName.SelectionLength = 0;
            this.mtbEmployeeName.SelectionStart = 0;
            this.mtbEmployeeName.ShortcutsEnabled = true;
            this.mtbEmployeeName.Size = new System.Drawing.Size(214, 48);
            this.mtbEmployeeName.TabIndex = 7;
            this.mtbEmployeeName.TabStop = false;
            this.mtbEmployeeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbEmployeeName.TrailingIcon = null;
            this.mtbEmployeeName.UseSystemPasswordChar = false;
            // 
            // mtbEmployeePassword
            // 
            this.mtbEmployeePassword.AnimateReadOnly = false;
            this.mtbEmployeePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbEmployeePassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbEmployeePassword.Depth = 0;
            this.mtbEmployeePassword.Enabled = false;
            this.mtbEmployeePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbEmployeePassword.HideSelection = true;
            this.mtbEmployeePassword.LeadingIcon = null;
            this.mtbEmployeePassword.Location = new System.Drawing.Point(37, 122);
            this.mtbEmployeePassword.MaxLength = 32767;
            this.mtbEmployeePassword.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbEmployeePassword.Name = "mtbEmployeePassword";
            this.mtbEmployeePassword.PasswordChar = '•';
            this.mtbEmployeePassword.PrefixSuffixText = null;
            this.mtbEmployeePassword.ReadOnly = false;
            this.mtbEmployeePassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbEmployeePassword.SelectedText = "";
            this.mtbEmployeePassword.SelectionLength = 0;
            this.mtbEmployeePassword.SelectionStart = 0;
            this.mtbEmployeePassword.ShortcutsEnabled = true;
            this.mtbEmployeePassword.Size = new System.Drawing.Size(143, 48);
            this.mtbEmployeePassword.TabIndex = 8;
            this.mtbEmployeePassword.TabStop = false;
            this.mtbEmployeePassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbEmployeePassword.TrailingIcon = null;
            this.mtbEmployeePassword.UseSystemPasswordChar = false;
            // 
            // mbtnNewEmployee
            // 
            this.mbtnNewEmployee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtnNewEmployee.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtnNewEmployee.Depth = 0;
            this.mbtnNewEmployee.HighEmphasis = true;
            this.mbtnNewEmployee.Icon = null;
            this.mbtnNewEmployee.Location = new System.Drawing.Point(37, 194);
            this.mbtnNewEmployee.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtnNewEmployee.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtnNewEmployee.Name = "mbtnNewEmployee";
            this.mbtnNewEmployee.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtnNewEmployee.Size = new System.Drawing.Size(64, 36);
            this.mbtnNewEmployee.TabIndex = 9;
            this.mbtnNewEmployee.Text = "Novo";
            this.mbtnNewEmployee.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtnNewEmployee.UseAccentColor = false;
            this.mbtnNewEmployee.UseVisualStyleBackColor = true;
            this.mbtnNewEmployee.Click += new System.EventHandler(this.mbtnNewEmployee_Click);
            // 
            // mbtnSaveNewEmployee
            // 
            this.mbtnSaveNewEmployee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtnSaveNewEmployee.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtnSaveNewEmployee.Depth = 0;
            this.mbtnSaveNewEmployee.HighEmphasis = true;
            this.mbtnSaveNewEmployee.Icon = null;
            this.mbtnSaveNewEmployee.Location = new System.Drawing.Point(175, 194);
            this.mbtnSaveNewEmployee.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtnSaveNewEmployee.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtnSaveNewEmployee.Name = "mbtnSaveNewEmployee";
            this.mbtnSaveNewEmployee.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtnSaveNewEmployee.Size = new System.Drawing.Size(76, 36);
            this.mbtnSaveNewEmployee.TabIndex = 10;
            this.mbtnSaveNewEmployee.Text = "Salvar";
            this.mbtnSaveNewEmployee.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtnSaveNewEmployee.UseAccentColor = false;
            this.mbtnSaveNewEmployee.UseVisualStyleBackColor = true;
            this.mbtnSaveNewEmployee.Click += new System.EventHandler(this.mbtnSaveNewEmployee_Click);
            // 
            // mbtnSeePassword
            // 
            this.mbtnSeePassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtnSeePassword.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtnSeePassword.Depth = 0;
            this.mbtnSeePassword.HighEmphasis = true;
            this.mbtnSeePassword.Icon = null;
            this.mbtnSeePassword.Location = new System.Drawing.Point(187, 134);
            this.mbtnSeePassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtnSeePassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtnSeePassword.Name = "mbtnSeePassword";
            this.mbtnSeePassword.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtnSeePassword.Size = new System.Drawing.Size(64, 36);
            this.mbtnSeePassword.TabIndex = 11;
            this.mbtnSeePassword.Text = "Ver";
            this.mbtnSeePassword.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtnSeePassword.UseAccentColor = false;
            this.mbtnSeePassword.UseVisualStyleBackColor = true;
            this.mbtnSeePassword.Click += new System.EventHandler(this.mbtnSeePassword_Click);
            // 
            // fmCreateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.mbtnSeePassword);
            this.Controls.Add(this.mbtnSaveNewEmployee);
            this.Controls.Add(this.mbtnNewEmployee);
            this.Controls.Add(this.mtbEmployeePassword);
            this.Controls.Add(this.mtbEmployeeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmCreateEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Funcionário";
            this.Load += new System.EventHandler(this.fmCreateEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialTextBox2 mtbEmployeeName;
        private MaterialSkin.Controls.MaterialTextBox2 mtbEmployeePassword;
        private MaterialSkin.Controls.MaterialButton mbtnNewEmployee;
        private MaterialSkin.Controls.MaterialButton mbtnSaveNewEmployee;
        private MaterialSkin.Controls.MaterialButton mbtnSeePassword;
    }
}