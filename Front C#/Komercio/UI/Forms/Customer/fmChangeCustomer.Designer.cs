namespace Komercio.UI.Forms.Customer
{
    partial class fmChangeCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmChangeCustomer));
            this.mbtSaveCustomer = new MaterialSkin.Controls.MaterialButton();
            this.mbtChangeCustomer = new MaterialSkin.Controls.MaterialButton();
            this.mtbCustomerEmail = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerCountry = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerState = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerCity = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerNeighborhood = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerAdress = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerZipcode = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerMobile = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerPhone = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerDocument = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerLastName = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCustomerFirstName = new MaterialSkin.Controls.MaterialTextBox2();
            this.dgvCustomerList = new System.Windows.Forms.DataGridView();
            this.mtbSeachName = new MaterialSkin.Controls.MaterialTextBox2();
            this.mcbActive = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.mtbCustomerId = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerList)).BeginInit();
            this.SuspendLayout();
            // 
            // mbtSaveCustomer
            // 
            this.mbtSaveCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtSaveCustomer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtSaveCustomer.Depth = 0;
            this.mbtSaveCustomer.HighEmphasis = true;
            this.mbtSaveCustomer.Icon = null;
            this.mbtSaveCustomer.Location = new System.Drawing.Point(141, 297);
            this.mbtSaveCustomer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtSaveCustomer.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtSaveCustomer.Name = "mbtSaveCustomer";
            this.mbtSaveCustomer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtSaveCustomer.Size = new System.Drawing.Size(76, 36);
            this.mbtSaveCustomer.TabIndex = 27;
            this.mbtSaveCustomer.Text = "Salvar";
            this.mbtSaveCustomer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtSaveCustomer.UseAccentColor = false;
            this.mbtSaveCustomer.UseVisualStyleBackColor = true;
            this.mbtSaveCustomer.Click += new System.EventHandler(this.mbtSaveCustomer_Click);
            // 
            // mbtChangeCustomer
            // 
            this.mbtChangeCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtChangeCustomer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtChangeCustomer.Depth = 0;
            this.mbtChangeCustomer.HighEmphasis = true;
            this.mbtChangeCustomer.Icon = null;
            this.mbtChangeCustomer.Location = new System.Drawing.Point(13, 297);
            this.mbtChangeCustomer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtChangeCustomer.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtChangeCustomer.Name = "mbtChangeCustomer";
            this.mbtChangeCustomer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtChangeCustomer.Size = new System.Drawing.Size(84, 36);
            this.mbtChangeCustomer.TabIndex = 26;
            this.mbtChangeCustomer.Text = "Alterar";
            this.mbtChangeCustomer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtChangeCustomer.UseAccentColor = false;
            this.mbtChangeCustomer.UseVisualStyleBackColor = true;
            this.mbtChangeCustomer.Click += new System.EventHandler(this.mbtNewCustomer_Click);
            // 
            // mtbCustomerEmail
            // 
            this.mtbCustomerEmail.AnimateReadOnly = false;
            this.mtbCustomerEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerEmail.Depth = 0;
            this.mtbCustomerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerEmail.HideSelection = true;
            this.mtbCustomerEmail.Hint = "Email";
            this.mtbCustomerEmail.LeadingIcon = null;
            this.mtbCustomerEmail.Location = new System.Drawing.Point(629, 290);
            this.mtbCustomerEmail.MaxLength = 32767;
            this.mtbCustomerEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerEmail.Name = "mtbCustomerEmail";
            this.mtbCustomerEmail.PasswordChar = '\0';
            this.mtbCustomerEmail.PrefixSuffixText = null;
            this.mtbCustomerEmail.ReadOnly = false;
            this.mtbCustomerEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerEmail.SelectedText = "";
            this.mtbCustomerEmail.SelectionLength = 0;
            this.mtbCustomerEmail.SelectionStart = 0;
            this.mtbCustomerEmail.ShortcutsEnabled = true;
            this.mtbCustomerEmail.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerEmail.TabIndex = 25;
            this.mtbCustomerEmail.TabStop = false;
            this.mtbCustomerEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerEmail.TrailingIcon = null;
            this.mtbCustomerEmail.UseSystemPasswordChar = false;
            // 
            // mtbCustomerCountry
            // 
            this.mtbCustomerCountry.AnimateReadOnly = false;
            this.mtbCustomerCountry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerCountry.Depth = 0;
            this.mtbCustomerCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerCountry.HideSelection = true;
            this.mtbCustomerCountry.Hint = "Pais";
            this.mtbCustomerCountry.LeadingIcon = null;
            this.mtbCustomerCountry.Location = new System.Drawing.Point(629, 236);
            this.mtbCustomerCountry.MaxLength = 32767;
            this.mtbCustomerCountry.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerCountry.Name = "mtbCustomerCountry";
            this.mtbCustomerCountry.PasswordChar = '\0';
            this.mtbCustomerCountry.PrefixSuffixText = null;
            this.mtbCustomerCountry.ReadOnly = false;
            this.mtbCustomerCountry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerCountry.SelectedText = "";
            this.mtbCustomerCountry.SelectionLength = 0;
            this.mtbCustomerCountry.SelectionStart = 0;
            this.mtbCustomerCountry.ShortcutsEnabled = true;
            this.mtbCustomerCountry.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerCountry.TabIndex = 24;
            this.mtbCustomerCountry.TabStop = false;
            this.mtbCustomerCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerCountry.TrailingIcon = null;
            this.mtbCustomerCountry.UseSystemPasswordChar = false;

            // 
            // mtbCustomerState
            // 
            this.mtbCustomerState.AnimateReadOnly = false;
            this.mtbCustomerState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerState.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerState.Depth = 0;
            this.mtbCustomerState.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerState.HideSelection = true;
            this.mtbCustomerState.Hint = "Estado";
            this.mtbCustomerState.LeadingIcon = null;
            this.mtbCustomerState.Location = new System.Drawing.Point(629, 182);
            this.mtbCustomerState.MaxLength = 32767;
            this.mtbCustomerState.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerState.Name = "mtbCustomerState";
            this.mtbCustomerState.PasswordChar = '\0';
            this.mtbCustomerState.PrefixSuffixText = null;
            this.mtbCustomerState.ReadOnly = false;
            this.mtbCustomerState.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerState.SelectedText = "";
            this.mtbCustomerState.SelectionLength = 0;
            this.mtbCustomerState.SelectionStart = 0;
            this.mtbCustomerState.ShortcutsEnabled = true;
            this.mtbCustomerState.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerState.TabIndex = 23;
            this.mtbCustomerState.TabStop = false;
            this.mtbCustomerState.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerState.TrailingIcon = null;
            this.mtbCustomerState.UseSystemPasswordChar = false;

            // 
            // mtbCustomerCity
            // 
            this.mtbCustomerCity.AnimateReadOnly = false;
            this.mtbCustomerCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerCity.Depth = 0;
            this.mtbCustomerCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerCity.HideSelection = true;
            this.mtbCustomerCity.Hint = "Cidade";
            this.mtbCustomerCity.LeadingIcon = null;
            this.mtbCustomerCity.Location = new System.Drawing.Point(629, 128);
            this.mtbCustomerCity.MaxLength = 32767;
            this.mtbCustomerCity.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerCity.Name = "mtbCustomerCity";
            this.mtbCustomerCity.PasswordChar = '\0';
            this.mtbCustomerCity.PrefixSuffixText = null;
            this.mtbCustomerCity.ReadOnly = false;
            this.mtbCustomerCity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerCity.SelectedText = "";
            this.mtbCustomerCity.SelectionLength = 0;
            this.mtbCustomerCity.SelectionStart = 0;
            this.mtbCustomerCity.ShortcutsEnabled = true;
            this.mtbCustomerCity.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerCity.TabIndex = 22;
            this.mtbCustomerCity.TabStop = false;
            this.mtbCustomerCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerCity.TrailingIcon = null;
            this.mtbCustomerCity.UseSystemPasswordChar = false;

            // 
            // mtbCustomerNeighborhood
            // 
            this.mtbCustomerNeighborhood.AnimateReadOnly = false;
            this.mtbCustomerNeighborhood.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerNeighborhood.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerNeighborhood.Depth = 0;
            this.mtbCustomerNeighborhood.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerNeighborhood.HideSelection = true;
            this.mtbCustomerNeighborhood.Hint = "Bairro";
            this.mtbCustomerNeighborhood.LeadingIcon = null;
            this.mtbCustomerNeighborhood.Location = new System.Drawing.Point(629, 74);
            this.mtbCustomerNeighborhood.MaxLength = 32767;
            this.mtbCustomerNeighborhood.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerNeighborhood.Name = "mtbCustomerNeighborhood";
            this.mtbCustomerNeighborhood.PasswordChar = '\0';
            this.mtbCustomerNeighborhood.PrefixSuffixText = null;
            this.mtbCustomerNeighborhood.ReadOnly = false;
            this.mtbCustomerNeighborhood.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerNeighborhood.SelectedText = "";
            this.mtbCustomerNeighborhood.SelectionLength = 0;
            this.mtbCustomerNeighborhood.SelectionStart = 0;
            this.mtbCustomerNeighborhood.ShortcutsEnabled = true;
            this.mtbCustomerNeighborhood.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerNeighborhood.TabIndex = 21;
            this.mtbCustomerNeighborhood.TabStop = false;
            this.mtbCustomerNeighborhood.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerNeighborhood.TrailingIcon = null;
            this.mtbCustomerNeighborhood.UseSystemPasswordChar = false;

            // 
            // mtbCustomerAdress
            // 
            this.mtbCustomerAdress.AnimateReadOnly = false;
            this.mtbCustomerAdress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerAdress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerAdress.Depth = 0;
            this.mtbCustomerAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerAdress.HideSelection = true;
            this.mtbCustomerAdress.Hint = "Endereço";
            this.mtbCustomerAdress.LeadingIcon = null;
            this.mtbCustomerAdress.Location = new System.Drawing.Point(629, 20);
            this.mtbCustomerAdress.MaxLength = 32767;
            this.mtbCustomerAdress.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerAdress.Name = "mtbCustomerAdress";
            this.mtbCustomerAdress.PasswordChar = '\0';
            this.mtbCustomerAdress.PrefixSuffixText = null;
            this.mtbCustomerAdress.ReadOnly = false;
            this.mtbCustomerAdress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerAdress.SelectedText = "";
            this.mtbCustomerAdress.SelectionLength = 0;
            this.mtbCustomerAdress.SelectionStart = 0;
            this.mtbCustomerAdress.ShortcutsEnabled = true;
            this.mtbCustomerAdress.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerAdress.TabIndex = 20;
            this.mtbCustomerAdress.TabStop = false;
            this.mtbCustomerAdress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerAdress.TrailingIcon = null;
            this.mtbCustomerAdress.UseSystemPasswordChar = false;

            // 
            // mtbCustomerZipcode
            // 
            this.mtbCustomerZipcode.AnimateReadOnly = false;
            this.mtbCustomerZipcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerZipcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerZipcode.Depth = 0;
            this.mtbCustomerZipcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerZipcode.HideSelection = true;
            this.mtbCustomerZipcode.Hint = "CEP";
            this.mtbCustomerZipcode.LeadingIcon = null;
            this.mtbCustomerZipcode.Location = new System.Drawing.Point(367, 290);
            this.mtbCustomerZipcode.MaxLength = 32767;
            this.mtbCustomerZipcode.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerZipcode.Name = "mtbCustomerZipcode";
            this.mtbCustomerZipcode.PasswordChar = '\0';
            this.mtbCustomerZipcode.PrefixSuffixText = null;
            this.mtbCustomerZipcode.ReadOnly = false;
            this.mtbCustomerZipcode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerZipcode.SelectedText = "";
            this.mtbCustomerZipcode.SelectionLength = 0;
            this.mtbCustomerZipcode.SelectionStart = 0;
            this.mtbCustomerZipcode.ShortcutsEnabled = true;
            this.mtbCustomerZipcode.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerZipcode.TabIndex = 19;
            this.mtbCustomerZipcode.TabStop = false;
            this.mtbCustomerZipcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerZipcode.TrailingIcon = null;
            this.mtbCustomerZipcode.UseSystemPasswordChar = false;

            this.mtbCustomerZipcode.Leave += new System.EventHandler(this.mtbCustomerZipcode_Leave);
            // 
            // mtbCustomerMobile
            // 
            this.mtbCustomerMobile.AnimateReadOnly = false;
            this.mtbCustomerMobile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerMobile.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerMobile.Depth = 0;
            this.mtbCustomerMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerMobile.HideSelection = true;
            this.mtbCustomerMobile.Hint = "Celular";
            this.mtbCustomerMobile.LeadingIcon = null;
            this.mtbCustomerMobile.Location = new System.Drawing.Point(367, 236);
            this.mtbCustomerMobile.MaxLength = 32767;
            this.mtbCustomerMobile.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerMobile.Name = "mtbCustomerMobile";
            this.mtbCustomerMobile.PasswordChar = '\0';
            this.mtbCustomerMobile.PrefixSuffixText = null;
            this.mtbCustomerMobile.ReadOnly = false;
            this.mtbCustomerMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerMobile.SelectedText = "";
            this.mtbCustomerMobile.SelectionLength = 0;
            this.mtbCustomerMobile.SelectionStart = 0;
            this.mtbCustomerMobile.ShortcutsEnabled = true;
            this.mtbCustomerMobile.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerMobile.TabIndex = 18;
            this.mtbCustomerMobile.TabStop = false;
            this.mtbCustomerMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerMobile.TrailingIcon = null;
            this.mtbCustomerMobile.UseSystemPasswordChar = false;

            this.mtbCustomerMobile.Leave += new System.EventHandler(this.mtbCustomerMobile_Leave);
            // 
            // mtbCustomerPhone
            // 
            this.mtbCustomerPhone.AnimateReadOnly = false;
            this.mtbCustomerPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerPhone.Depth = 0;
            this.mtbCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerPhone.HideSelection = true;
            this.mtbCustomerPhone.Hint = "Telefone fixo";
            this.mtbCustomerPhone.LeadingIcon = null;
            this.mtbCustomerPhone.Location = new System.Drawing.Point(367, 182);
            this.mtbCustomerPhone.MaxLength = 32767;
            this.mtbCustomerPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerPhone.Name = "mtbCustomerPhone";
            this.mtbCustomerPhone.PasswordChar = '\0';
            this.mtbCustomerPhone.PrefixSuffixText = null;
            this.mtbCustomerPhone.ReadOnly = false;
            this.mtbCustomerPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerPhone.SelectedText = "";
            this.mtbCustomerPhone.SelectionLength = 0;
            this.mtbCustomerPhone.SelectionStart = 0;
            this.mtbCustomerPhone.ShortcutsEnabled = true;
            this.mtbCustomerPhone.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerPhone.TabIndex = 17;
            this.mtbCustomerPhone.TabStop = false;
            this.mtbCustomerPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerPhone.TrailingIcon = null;
            this.mtbCustomerPhone.UseSystemPasswordChar = false;

            this.mtbCustomerPhone.Leave += new System.EventHandler(this.mtbCustomerPhone_Leave);
            // 
            // mtbCustomerDocument
            // 
            this.mtbCustomerDocument.AnimateReadOnly = false;
            this.mtbCustomerDocument.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerDocument.Depth = 0;
            this.mtbCustomerDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerDocument.HideSelection = true;
            this.mtbCustomerDocument.Hint = "CPF/CNPJ";
            this.mtbCustomerDocument.LeadingIcon = null;
            this.mtbCustomerDocument.Location = new System.Drawing.Point(367, 128);
            this.mtbCustomerDocument.MaxLength = 32767;
            this.mtbCustomerDocument.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerDocument.Name = "mtbCustomerDocument";
            this.mtbCustomerDocument.PasswordChar = '\0';
            this.mtbCustomerDocument.PrefixSuffixText = null;
            this.mtbCustomerDocument.ReadOnly = false;
            this.mtbCustomerDocument.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerDocument.SelectedText = "";
            this.mtbCustomerDocument.SelectionLength = 0;
            this.mtbCustomerDocument.SelectionStart = 0;
            this.mtbCustomerDocument.ShortcutsEnabled = true;
            this.mtbCustomerDocument.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerDocument.TabIndex = 16;
            this.mtbCustomerDocument.TabStop = false;
            this.mtbCustomerDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerDocument.TrailingIcon = null;
            this.mtbCustomerDocument.UseSystemPasswordChar = false;
            this.mtbCustomerDocument.Leave += new System.EventHandler(this.mtbCustomerDocument_Leave);
            // 
            // mtbCustomerLastName
            // 
            this.mtbCustomerLastName.AnimateReadOnly = false;
            this.mtbCustomerLastName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerLastName.Depth = 0;
            this.mtbCustomerLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerLastName.HideSelection = true;
            this.mtbCustomerLastName.Hint = "Sobrenome";
            this.mtbCustomerLastName.LeadingIcon = null;
            this.mtbCustomerLastName.Location = new System.Drawing.Point(367, 74);
            this.mtbCustomerLastName.MaxLength = 32767;
            this.mtbCustomerLastName.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerLastName.Name = "mtbCustomerLastName";
            this.mtbCustomerLastName.PasswordChar = '\0';
            this.mtbCustomerLastName.PrefixSuffixText = null;
            this.mtbCustomerLastName.ReadOnly = false;
            this.mtbCustomerLastName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerLastName.SelectedText = "";
            this.mtbCustomerLastName.SelectionLength = 0;
            this.mtbCustomerLastName.SelectionStart = 0;
            this.mtbCustomerLastName.ShortcutsEnabled = true;
            this.mtbCustomerLastName.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerLastName.TabIndex = 15;
            this.mtbCustomerLastName.TabStop = false;
            this.mtbCustomerLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerLastName.TrailingIcon = null;
            this.mtbCustomerLastName.UseSystemPasswordChar = false;

            // 
            // mtbCustomerFirstName
            // 
            this.mtbCustomerFirstName.AnimateReadOnly = false;
            this.mtbCustomerFirstName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerFirstName.Depth = 0;
            this.mtbCustomerFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerFirstName.HideSelection = true;
            this.mtbCustomerFirstName.Hint = "Nome";
            this.mtbCustomerFirstName.LeadingIcon = null;
            this.mtbCustomerFirstName.Location = new System.Drawing.Point(367, 20);
            this.mtbCustomerFirstName.MaxLength = 32767;
            this.mtbCustomerFirstName.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerFirstName.Name = "mtbCustomerFirstName";
            this.mtbCustomerFirstName.PasswordChar = '\0';
            this.mtbCustomerFirstName.PrefixSuffixText = null;
            this.mtbCustomerFirstName.ReadOnly = false;
            this.mtbCustomerFirstName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerFirstName.SelectedText = "";
            this.mtbCustomerFirstName.SelectionLength = 0;
            this.mtbCustomerFirstName.SelectionStart = 0;
            this.mtbCustomerFirstName.ShortcutsEnabled = true;
            this.mtbCustomerFirstName.Size = new System.Drawing.Size(250, 48);
            this.mtbCustomerFirstName.TabIndex = 14;
            this.mtbCustomerFirstName.TabStop = false;
            this.mtbCustomerFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerFirstName.TrailingIcon = null;
            this.mtbCustomerFirstName.UseSystemPasswordChar = false;

            // 
            // dgvCustomerList
            // 
            this.dgvCustomerList.AllowUserToAddRows = false;
            this.dgvCustomerList.AllowUserToDeleteRows = false;
            this.dgvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerList.Location = new System.Drawing.Point(11, 90);
            this.dgvCustomerList.Name = "dgvCustomerList";
            this.dgvCustomerList.ReadOnly = true;
            this.dgvCustomerList.Size = new System.Drawing.Size(344, 135);
            this.dgvCustomerList.TabIndex = 28;
            this.dgvCustomerList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerList_CellDoubleClick);
            // 
            // mtbSeachName
            // 
            this.mtbSeachName.AnimateReadOnly = false;
            this.mtbSeachName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbSeachName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbSeachName.Depth = 0;
            this.mtbSeachName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbSeachName.HelperText = "Digite o nome do cliente para localiza-lo";
            this.mtbSeachName.HideSelection = true;
            this.mtbSeachName.Hint = "Buscar Cliente";
            this.mtbSeachName.LeadingIcon = null;
            this.mtbSeachName.Location = new System.Drawing.Point(12, 20);
            this.mtbSeachName.MaxLength = 32767;
            this.mtbSeachName.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbSeachName.Name = "mtbSeachName";
            this.mtbSeachName.PasswordChar = '\0';
            this.mtbSeachName.PrefixSuffixText = null;
            this.mtbSeachName.ReadOnly = false;
            this.mtbSeachName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbSeachName.SelectedText = "";
            this.mtbSeachName.SelectionLength = 0;
            this.mtbSeachName.SelectionStart = 0;
            this.mtbSeachName.ShortcutsEnabled = true;
            this.mtbSeachName.ShowAssistiveText = true;
            this.mtbSeachName.Size = new System.Drawing.Size(344, 64);
            this.mtbSeachName.TabIndex = 29;
            this.mtbSeachName.TabStop = false;
            this.mtbSeachName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbSeachName.TrailingIcon = null;
            this.mtbSeachName.UseSystemPasswordChar = false;
            this.mtbSeachName.TextChanged += new System.EventHandler(this.mtbSeachName_TextChanged);
            // 
            // mcbActive
            // 
            this.mcbActive.AutoSize = true;
            this.mcbActive.Depth = 0;
            this.mcbActive.Location = new System.Drawing.Point(12, 242);
            this.mcbActive.Margin = new System.Windows.Forms.Padding(0);
            this.mcbActive.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mcbActive.MouseState = MaterialSkin.MouseState.HOVER;
            this.mcbActive.Name = "mcbActive";
            this.mcbActive.ReadOnly = false;
            this.mcbActive.Ripple = true;
            this.mcbActive.Size = new System.Drawing.Size(122, 37);
            this.mcbActive.TabIndex = 30;
            this.mcbActive.Text = "Cliente ativo";
            this.mcbActive.UseVisualStyleBackColor = true;

            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(260, 297);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(96, 36);
            this.materialButton1.TabIndex = 31;
            this.materialButton1.Text = "Cancelar";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // mtbCustomerId
            // 
            this.mtbCustomerId.AnimateReadOnly = false;
            this.mtbCustomerId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCustomerId.Depth = 0;
            this.mtbCustomerId.Enabled = false;
            this.mtbCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCustomerId.HideSelection = true;
            this.mtbCustomerId.Hint = "Id Cliente";
            this.mtbCustomerId.LeadingIcon = null;
            this.mtbCustomerId.Location = new System.Drawing.Point(163, 231);
            this.mtbCustomerId.MaxLength = 32767;
            this.mtbCustomerId.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCustomerId.Name = "mtbCustomerId";
            this.mtbCustomerId.PasswordChar = '\0';
            this.mtbCustomerId.PrefixSuffixText = null;
            this.mtbCustomerId.ReadOnly = false;
            this.mtbCustomerId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCustomerId.SelectedText = "";
            this.mtbCustomerId.SelectionLength = 0;
            this.mtbCustomerId.SelectionStart = 0;
            this.mtbCustomerId.ShortcutsEnabled = true;
            this.mtbCustomerId.Size = new System.Drawing.Size(192, 48);
            this.mtbCustomerId.TabIndex = 32;
            this.mtbCustomerId.TabStop = false;
            this.mtbCustomerId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCustomerId.TrailingIcon = null;
            this.mtbCustomerId.UseSystemPasswordChar = false;
            // 
            // fmChangeCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 346);
            this.Controls.Add(this.mtbCustomerId);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.mcbActive);
            this.Controls.Add(this.mtbSeachName);
            this.Controls.Add(this.dgvCustomerList);
            this.Controls.Add(this.mbtSaveCustomer);
            this.Controls.Add(this.mbtChangeCustomer);
            this.Controls.Add(this.mtbCustomerEmail);
            this.Controls.Add(this.mtbCustomerCountry);
            this.Controls.Add(this.mtbCustomerState);
            this.Controls.Add(this.mtbCustomerCity);
            this.Controls.Add(this.mtbCustomerNeighborhood);
            this.Controls.Add(this.mtbCustomerAdress);
            this.Controls.Add(this.mtbCustomerZipcode);
            this.Controls.Add(this.mtbCustomerMobile);
            this.Controls.Add(this.mtbCustomerPhone);
            this.Controls.Add(this.mtbCustomerDocument);
            this.Controls.Add(this.mtbCustomerLastName);
            this.Controls.Add(this.mtbCustomerFirstName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmChangeCustomer";
            this.Text = "Alterar cliente";
            this.Load += new System.EventHandler(this.fmChangeCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton mbtSaveCustomer;
        private MaterialSkin.Controls.MaterialButton mbtChangeCustomer;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerEmail;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerCountry;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerState;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerCity;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerNeighborhood;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerAdress;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerZipcode;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerMobile;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerPhone;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerDocument;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerLastName;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerFirstName;
        private System.Windows.Forms.DataGridView dgvCustomerList;
        private MaterialSkin.Controls.MaterialTextBox2 mtbSeachName;
        private MaterialSkin.Controls.MaterialCheckbox mcbActive;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCustomerId;
    }
}