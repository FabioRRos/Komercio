namespace Komercio.UI.Forms.Product
{
    partial class fmCreateGroupAndSubgroup
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
            this.mtcCad = new MaterialSkin.Controls.MaterialTabControl();
            this.tpGroup = new System.Windows.Forms.TabPage();
            this.tbSubGroup = new System.Windows.Forms.TabPage();
            this.mtbSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.btNewGroup = new MaterialSkin.Controls.MaterialButton();
            this.btSaveNewGroup = new MaterialSkin.Controls.MaterialButton();
            this.mtbGroup = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbSubgroup = new MaterialSkin.Controls.MaterialTextBox2();
            this.btSaveSubGroup = new MaterialSkin.Controls.MaterialButton();
            this.btNewSubgroup = new MaterialSkin.Controls.MaterialButton();
            this.mtcCad.SuspendLayout();
            this.tpGroup.SuspendLayout();
            this.tbSubGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtcCad
            // 
            this.mtcCad.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.mtcCad.Controls.Add(this.tpGroup);
            this.mtcCad.Controls.Add(this.tbSubGroup);
            this.mtcCad.Depth = 0;
            this.mtcCad.Location = new System.Drawing.Point(2, 66);
            this.mtcCad.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtcCad.Multiline = true;
            this.mtcCad.Name = "mtcCad";
            this.mtcCad.SelectedIndex = 0;
            this.mtcCad.Size = new System.Drawing.Size(397, 209);
            this.mtcCad.TabIndex = 0;
            // 
            // tpGroup
            // 
            this.tpGroup.Controls.Add(this.mtbGroup);
            this.tpGroup.Controls.Add(this.btSaveNewGroup);
            this.tpGroup.Controls.Add(this.btNewGroup);
            this.tpGroup.Location = new System.Drawing.Point(4, 25);
            this.tpGroup.Name = "tpGroup";
            this.tpGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tpGroup.Size = new System.Drawing.Size(389, 180);
            this.tpGroup.TabIndex = 0;
            this.tpGroup.Text = "Novo grupo";
            this.tpGroup.UseVisualStyleBackColor = true;
            // 
            // tbSubGroup
            // 
            this.tbSubGroup.Controls.Add(this.mtbSubgroup);
            this.tbSubGroup.Controls.Add(this.btSaveSubGroup);
            this.tbSubGroup.Controls.Add(this.btNewSubgroup);
            this.tbSubGroup.Location = new System.Drawing.Point(4, 25);
            this.tbSubGroup.Name = "tbSubGroup";
            this.tbSubGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tbSubGroup.Size = new System.Drawing.Size(389, 180);
            this.tbSubGroup.TabIndex = 1;
            this.tbSubGroup.Text = "Novo Subgrupo";
            this.tbSubGroup.UseVisualStyleBackColor = true;
            // 
            // mtbSelector
            // 
            this.mtbSelector.BaseTabControl = this.mtcCad;
            this.mtbSelector.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.mtbSelector.Depth = 0;
            this.mtbSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbSelector.Location = new System.Drawing.Point(6, 12);
            this.mtbSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbSelector.Name = "mtbSelector";
            this.mtbSelector.Size = new System.Drawing.Size(388, 48);
            this.mtbSelector.TabIndex = 1;
            this.mtbSelector.Text = "materialTabSelector1";
            // 
            // btNewGroup
            // 
            this.btNewGroup.AutoSize = false;
            this.btNewGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btNewGroup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btNewGroup.Depth = 0;
            this.btNewGroup.HighEmphasis = true;
            this.btNewGroup.Icon = null;
            this.btNewGroup.Location = new System.Drawing.Point(16, 122);
            this.btNewGroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btNewGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btNewGroup.Name = "btNewGroup";
            this.btNewGroup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btNewGroup.Size = new System.Drawing.Size(158, 36);
            this.btNewGroup.TabIndex = 0;
            this.btNewGroup.Text = "Novo Grupo";
            this.btNewGroup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btNewGroup.UseAccentColor = false;
            this.btNewGroup.UseVisualStyleBackColor = true;
            this.btNewGroup.Click += new System.EventHandler(this.btNewGroup_Click);
            // 
            // btSaveNewGroup
            // 
            this.btSaveNewGroup.AutoSize = false;
            this.btSaveNewGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSaveNewGroup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btSaveNewGroup.Depth = 0;
            this.btSaveNewGroup.Enabled = false;
            this.btSaveNewGroup.HighEmphasis = true;
            this.btSaveNewGroup.Icon = null;
            this.btSaveNewGroup.Location = new System.Drawing.Point(218, 122);
            this.btSaveNewGroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSaveNewGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btSaveNewGroup.Name = "btSaveNewGroup";
            this.btSaveNewGroup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btSaveNewGroup.Size = new System.Drawing.Size(158, 36);
            this.btSaveNewGroup.TabIndex = 1;
            this.btSaveNewGroup.Text = "Salvar Grupo";
            this.btSaveNewGroup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btSaveNewGroup.UseAccentColor = false;
            this.btSaveNewGroup.UseVisualStyleBackColor = true;
            // 
            // mtbGroup
            // 
            this.mtbGroup.AnimateReadOnly = false;
            this.mtbGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbGroup.Depth = 0;
            this.mtbGroup.Enabled = false;
            this.mtbGroup.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbGroup.HelperText = "Por exemplo: Pelicula fosca";
            this.mtbGroup.HideSelection = true;
            this.mtbGroup.Hint = "Grupo";
            this.mtbGroup.LeadingIcon = null;
            this.mtbGroup.Location = new System.Drawing.Point(79, 35);
            this.mtbGroup.MaxLength = 32767;
            this.mtbGroup.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbGroup.Name = "mtbGroup";
            this.mtbGroup.PasswordChar = '\0';
            this.mtbGroup.PrefixSuffixText = null;
            this.mtbGroup.ReadOnly = false;
            this.mtbGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbGroup.SelectedText = "";
            this.mtbGroup.SelectionLength = 0;
            this.mtbGroup.SelectionStart = 0;
            this.mtbGroup.ShortcutsEnabled = true;
            this.mtbGroup.ShowAssistiveText = true;
            this.mtbGroup.Size = new System.Drawing.Size(250, 64);
            this.mtbGroup.TabIndex = 2;
            this.mtbGroup.TabStop = false;
            this.mtbGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbGroup.TrailingIcon = null;
            this.mtbGroup.UseSystemPasswordChar = false;
            // 
            // mtbSubgroup
            // 
            this.mtbSubgroup.AnimateReadOnly = false;
            this.mtbSubgroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbSubgroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbSubgroup.Depth = 0;
            this.mtbSubgroup.Enabled = false;
            this.mtbSubgroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbSubgroup.HelperText = "Exemplo: Moto G75";
            this.mtbSubgroup.HideSelection = true;
            this.mtbSubgroup.Hint = "SubGrupo";
            this.mtbSubgroup.LeadingIcon = null;
            this.mtbSubgroup.Location = new System.Drawing.Point(79, 35);
            this.mtbSubgroup.MaxLength = 32767;
            this.mtbSubgroup.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbSubgroup.Name = "mtbSubgroup";
            this.mtbSubgroup.PasswordChar = '\0';
            this.mtbSubgroup.PrefixSuffixText = null;
            this.mtbSubgroup.ReadOnly = false;
            this.mtbSubgroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbSubgroup.SelectedText = "";
            this.mtbSubgroup.SelectionLength = 0;
            this.mtbSubgroup.SelectionStart = 0;
            this.mtbSubgroup.ShortcutsEnabled = true;
            this.mtbSubgroup.ShowAssistiveText = true;
            this.mtbSubgroup.Size = new System.Drawing.Size(250, 64);
            this.mtbSubgroup.TabIndex = 5;
            this.mtbSubgroup.TabStop = false;
            this.mtbSubgroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbSubgroup.TrailingIcon = null;
            this.mtbSubgroup.UseSystemPasswordChar = false;
            // 
            // btSaveSubGroup
            // 
            this.btSaveSubGroup.AutoSize = false;
            this.btSaveSubGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btSaveSubGroup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btSaveSubGroup.Depth = 0;
            this.btSaveSubGroup.Enabled = false;
            this.btSaveSubGroup.HighEmphasis = true;
            this.btSaveSubGroup.Icon = null;
            this.btSaveSubGroup.Location = new System.Drawing.Point(218, 122);
            this.btSaveSubGroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btSaveSubGroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btSaveSubGroup.Name = "btSaveSubGroup";
            this.btSaveSubGroup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btSaveSubGroup.Size = new System.Drawing.Size(158, 36);
            this.btSaveSubGroup.TabIndex = 4;
            this.btSaveSubGroup.Text = "Salvar Subgrupo";
            this.btSaveSubGroup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btSaveSubGroup.UseAccentColor = false;
            this.btSaveSubGroup.UseVisualStyleBackColor = true;
            // 
            // btNewSubgroup
            // 
            this.btNewSubgroup.AutoSize = false;
            this.btNewSubgroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btNewSubgroup.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btNewSubgroup.Depth = 0;
            this.btNewSubgroup.HighEmphasis = true;
            this.btNewSubgroup.Icon = null;
            this.btNewSubgroup.Location = new System.Drawing.Point(16, 122);
            this.btNewSubgroup.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btNewSubgroup.MouseState = MaterialSkin.MouseState.HOVER;
            this.btNewSubgroup.Name = "btNewSubgroup";
            this.btNewSubgroup.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btNewSubgroup.Size = new System.Drawing.Size(158, 36);
            this.btNewSubgroup.TabIndex = 3;
            this.btNewSubgroup.Text = "Novo Subgrupo";
            this.btNewSubgroup.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btNewSubgroup.UseAccentColor = false;
            this.btNewSubgroup.UseVisualStyleBackColor = true;
            this.btNewSubgroup.Click += new System.EventHandler(this.btNewSubgroup_Click);
            // 
            // fmCreateGroupAndSubgroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 279);
            this.Controls.Add(this.mtbSelector);
            this.Controls.Add(this.mtcCad);
            this.Name = "fmCreateGroupAndSubgroup";
            this.Text = "fmCreateGroupAndSubgroup";
            this.Load += new System.EventHandler(this.fmCreateGroupAndSubgroup_Load);
            this.mtcCad.ResumeLayout(false);
            this.tpGroup.ResumeLayout(false);
            this.tbSubGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl mtcCad;
        private System.Windows.Forms.TabPage tpGroup;
        private System.Windows.Forms.TabPage tbSubGroup;
        private MaterialSkin.Controls.MaterialTabSelector mtbSelector;
        private MaterialSkin.Controls.MaterialButton btSaveNewGroup;
        private MaterialSkin.Controls.MaterialButton btNewGroup;
        private MaterialSkin.Controls.MaterialTextBox2 mtbGroup;
        private MaterialSkin.Controls.MaterialTextBox2 mtbSubgroup;
        private MaterialSkin.Controls.MaterialButton btSaveSubGroup;
        private MaterialSkin.Controls.MaterialButton btNewSubgroup;
    }
}