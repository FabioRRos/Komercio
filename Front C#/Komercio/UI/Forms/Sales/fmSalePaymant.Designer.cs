namespace Komercio.UI.Forms.Sales
{
    partial class fmSalePaymant
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mtbFunc = new MaterialSkin.Controls.MaterialComboBox();
            this.mbtCancel = new MaterialSkin.Controls.MaterialButton();
            this.mbtConfirm = new MaterialSkin.Controls.MaterialButton();
            this.mbtcash = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.mlbTotal = new MaterialSkin.Controls.MaterialLabel();
            this.mtbValorRecebido = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbTroco = new MaterialSkin.Controls.MaterialTextBox2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbValues = new System.Windows.Forms.GroupBox();
            this.mtbcash = new MaterialSkin.Controls.MaterialButton();
            this.mtbSubTotal = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbDesc = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbAddValue = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbcardcred = new MaterialSkin.Controls.MaterialButton();
            this.mbtCarddeb = new MaterialSkin.Controls.MaterialButton();
            this.mbtPix = new MaterialSkin.Controls.MaterialButton();
            this.mbtCheque = new MaterialSkin.Controls.MaterialButton();
            this.mbtAccount = new MaterialSkin.Controls.MaterialButton();
            this.mtbObservacao = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbDoccument = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbFirstAndLastName = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtbFunc
            // 
            this.mtbFunc.AutoResize = false;
            this.mtbFunc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mtbFunc.Depth = 0;
            this.mtbFunc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mtbFunc.DropDownHeight = 174;
            this.mtbFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mtbFunc.DropDownWidth = 121;
            this.mtbFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mtbFunc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mtbFunc.Hint = "FUNCIONÁRIO";
            this.mtbFunc.IntegralHeight = false;
            this.mtbFunc.ItemHeight = 43;
            this.mtbFunc.Location = new System.Drawing.Point(365, 224);
            this.mtbFunc.MaxDropDownItems = 4;
            this.mtbFunc.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbFunc.Name = "mtbFunc";
            this.mtbFunc.Size = new System.Drawing.Size(294, 49);
            this.mtbFunc.StartIndex = 0;
            this.mtbFunc.TabIndex = 5;
            // 
            // mbtCancel
            // 
            this.mbtCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtCancel.Depth = 0;
            this.mbtCancel.HighEmphasis = true;
            this.mbtCancel.Icon = null;
            this.mbtCancel.Location = new System.Drawing.Point(15, 350);
            this.mbtCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtCancel.Name = "mbtCancel";
            this.mbtCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtCancel.Size = new System.Drawing.Size(96, 36);
            this.mbtCancel.TabIndex = 8;
            this.mbtCancel.Text = "CANCELAR";
            this.mbtCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtCancel.UseAccentColor = false;
            this.mbtCancel.Click += new System.EventHandler(this.mbtCancel_Click);
            // 
            // mbtConfirm
            // 
            this.mbtConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtConfirm.Depth = 0;
            this.mbtConfirm.HighEmphasis = true;
            this.mbtConfirm.Icon = null;
            this.mbtConfirm.Location = new System.Drawing.Point(206, 350);
            this.mbtConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtConfirm.Name = "mbtConfirm";
            this.mbtConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtConfirm.Size = new System.Drawing.Size(105, 36);
            this.mbtConfirm.TabIndex = 7;
            this.mbtConfirm.Text = "CONFIRMAR";
            this.mbtConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtConfirm.UseAccentColor = false;
            this.mbtConfirm.Click += new System.EventHandler(this.mbtConfirm_Click);
            // 
            // mbtcash
            // 
            this.mbtcash.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtcash.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtcash.Depth = 0;
            this.mbtcash.HighEmphasis = true;
            this.mbtcash.Icon = null;
            this.mbtcash.Location = new System.Drawing.Point(12, 190);
            this.mbtcash.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtcash.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtcash.Name = "mbtcash";
            this.mbtcash.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtcash.Size = new System.Drawing.Size(92, 36);
            this.mbtcash.TabIndex = 0;
            this.mbtcash.Text = "DINHEIRO";
            this.mbtcash.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtcash.UseAccentColor = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(365, 5);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(181, 23);
            this.materialLabel1.TabIndex = 11;
            this.materialLabel1.Text = "TOTAL A PAGAR";
            // 
            // mlbTotal
            // 
            this.mlbTotal.Depth = 0;
            this.mlbTotal.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mlbTotal.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.mlbTotal.Location = new System.Drawing.Point(425, 53);
            this.mlbTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.mlbTotal.Name = "mlbTotal";
            this.mlbTotal.Size = new System.Drawing.Size(234, 38);
            this.mlbTotal.TabIndex = 12;
            this.mlbTotal.Text = "R$ 0,00";
            // 
            // mtbValorRecebido
            // 
            this.mtbValorRecebido.AnimateReadOnly = false;
            this.mtbValorRecebido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbValorRecebido.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbValorRecebido.Depth = 0;
            this.mtbValorRecebido.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbValorRecebido.HideSelection = true;
            this.mtbValorRecebido.Hint = "VALOR RECEBIDO";
            this.mtbValorRecebido.LeadingIcon = null;
            this.mtbValorRecebido.Location = new System.Drawing.Point(365, 119);
            this.mtbValorRecebido.MaxLength = 32767;
            this.mtbValorRecebido.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbValorRecebido.Name = "mtbValorRecebido";
            this.mtbValorRecebido.PasswordChar = '\0';
            this.mtbValorRecebido.PrefixSuffixText = null;
            this.mtbValorRecebido.ReadOnly = false;
            this.mtbValorRecebido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbValorRecebido.SelectedText = "";
            this.mtbValorRecebido.SelectionLength = 0;
            this.mtbValorRecebido.SelectionStart = 0;
            this.mtbValorRecebido.ShortcutsEnabled = true;
            this.mtbValorRecebido.Size = new System.Drawing.Size(294, 48);
            this.mtbValorRecebido.TabIndex = 4;
            this.mtbValorRecebido.TabStop = false;
            this.mtbValorRecebido.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbValorRecebido.TrailingIcon = null;
            this.mtbValorRecebido.UseSystemPasswordChar = false;
            this.mtbValorRecebido.Leave += new System.EventHandler(this.mtbValorRecebido_Leave);
            this.mtbValorRecebido.TextChanged += new System.EventHandler(this.mtbValorRecebido_TextChanged);
            // 
            // mtbTroco
            // 
            this.mtbTroco.AnimateReadOnly = false;
            this.mtbTroco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbTroco.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbTroco.Depth = 0;
            this.mtbTroco.Enabled = false;
            this.mtbTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbTroco.HideSelection = true;
            this.mtbTroco.Hint = "TROCO";
            this.mtbTroco.LeadingIcon = null;
            this.mtbTroco.Location = new System.Drawing.Point(365, 171);
            this.mtbTroco.MaxLength = 32767;
            this.mtbTroco.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbTroco.Name = "mtbTroco";
            this.mtbTroco.PasswordChar = '\0';
            this.mtbTroco.PrefixSuffixText = null;
            this.mtbTroco.ReadOnly = false;
            this.mtbTroco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbTroco.SelectedText = "";
            this.mtbTroco.SelectionLength = 0;
            this.mtbTroco.SelectionStart = 0;
            this.mtbTroco.ShortcutsEnabled = true;
            this.mtbTroco.Size = new System.Drawing.Size(294, 48);
            this.mtbTroco.TabIndex = 16;
            this.mtbTroco.TabStop = false;
            this.mtbTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbTroco.TrailingIcon = null;
            this.mtbTroco.UseSystemPasswordChar = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Komercio.Properties.Resources.Carrinho;
            this.pictureBox1.Location = new System.Drawing.Point(365, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // gbValues
            // 
            this.gbValues.Controls.Add(this.mtbcash);
            this.gbValues.Controls.Add(this.mtbSubTotal);
            this.gbValues.Controls.Add(this.mtbDesc);
            this.gbValues.Controls.Add(this.mtbAddValue);
            this.gbValues.Controls.Add(this.mtbcardcred);
            this.gbValues.Controls.Add(this.mbtCarddeb);
            this.gbValues.Controls.Add(this.mbtPix);
            this.gbValues.Controls.Add(this.mbtCheque);
            this.gbValues.Controls.Add(this.mbtAccount);
            this.gbValues.Controls.Add(this.mtbObservacao);
            this.gbValues.Location = new System.Drawing.Point(9, 0);
            this.gbValues.Name = "gbValues";
            this.gbValues.Size = new System.Drawing.Size(308, 341);
            this.gbValues.TabIndex = 0;
            this.gbValues.TabStop = false;
            // 
            // mtbcash
            // 
            this.mtbcash.AutoSize = false;
            this.mtbcash.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbcash.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbcash.Depth = 0;
            this.mtbcash.HighEmphasis = true;
            this.mtbcash.Icon = null;
            this.mtbcash.Location = new System.Drawing.Point(6, 189);
            this.mtbcash.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbcash.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbcash.Name = "mtbcash";
            this.mtbcash.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbcash.Size = new System.Drawing.Size(75, 36);
            this.mtbcash.TabIndex = 28;
            this.mtbcash.TabStop = false;
            this.mtbcash.Text = "DINHEIRO";
            this.mtbcash.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbcash.UseAccentColor = false;
            this.mtbcash.UseVisualStyleBackColor = true;
            this.mtbcash.Click += new System.EventHandler(this.mtbcash_Click);
            // 
            // mtbSubTotal
            // 
            this.mtbSubTotal.AnimateReadOnly = false;
            this.mtbSubTotal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbSubTotal.Depth = 0;
            this.mtbSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbSubTotal.HideSelection = true;
            this.mtbSubTotal.Hint = "SUBTOTAL";
            this.mtbSubTotal.LeadingIcon = null;
            this.mtbSubTotal.Location = new System.Drawing.Point(6, 11);
            this.mtbSubTotal.MaxLength = 32767;
            this.mtbSubTotal.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbSubTotal.Name = "mtbSubTotal";
            this.mtbSubTotal.PasswordChar = '\0';
            this.mtbSubTotal.PrefixSuffixText = null;
            this.mtbSubTotal.ReadOnly = true;
            this.mtbSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbSubTotal.SelectedText = "";
            this.mtbSubTotal.SelectionLength = 0;
            this.mtbSubTotal.SelectionStart = 0;
            this.mtbSubTotal.ShortcutsEnabled = true;
            this.mtbSubTotal.Size = new System.Drawing.Size(294, 48);
            this.mtbSubTotal.TabIndex = 0;
            this.mtbSubTotal.TabStop = false;
            this.mtbSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbSubTotal.TrailingIcon = null;
            this.mtbSubTotal.UseSystemPasswordChar = false;
            // 
            // mtbDesc
            // 
            this.mtbDesc.AnimateReadOnly = false;
            this.mtbDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDesc.Depth = 0;
            this.mtbDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDesc.HideSelection = true;
            this.mtbDesc.Hint = "DESCONTO";
            this.mtbDesc.LeadingIcon = null;
            this.mtbDesc.Location = new System.Drawing.Point(6, 65);
            this.mtbDesc.MaxLength = 32767;
            this.mtbDesc.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDesc.Name = "mtbDesc";
            this.mtbDesc.PasswordChar = '\0';
            this.mtbDesc.PrefixSuffixText = null;
            this.mtbDesc.ReadOnly = false;
            this.mtbDesc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDesc.SelectedText = "";
            this.mtbDesc.SelectionLength = 0;
            this.mtbDesc.SelectionStart = 0;
            this.mtbDesc.ShortcutsEnabled = true;
            this.mtbDesc.Size = new System.Drawing.Size(294, 48);
            this.mtbDesc.TabIndex = 1;
            this.mtbDesc.TabStop = false;
            this.mtbDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDesc.TrailingIcon = null;
            this.mtbDesc.UseSystemPasswordChar = false;
            this.mtbDesc.Click += new System.EventHandler(this.mtbDesc_Click);
            this.mtbDesc.Leave += new System.EventHandler(this.mtbDesc_Leave_1);
            this.mtbDesc.TextChanged += new System.EventHandler(this.mtbDesc_TextChanged);
            // 
            // mtbAddValue
            // 
            this.mtbAddValue.AnimateReadOnly = false;
            this.mtbAddValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbAddValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbAddValue.Depth = 0;
            this.mtbAddValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbAddValue.HideSelection = true;
            this.mtbAddValue.Hint = "ACRÉSCIMO";
            this.mtbAddValue.LeadingIcon = null;
            this.mtbAddValue.Location = new System.Drawing.Point(6, 119);
            this.mtbAddValue.MaxLength = 32767;
            this.mtbAddValue.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbAddValue.Name = "mtbAddValue";
            this.mtbAddValue.PasswordChar = '\0';
            this.mtbAddValue.PrefixSuffixText = null;
            this.mtbAddValue.ReadOnly = false;
            this.mtbAddValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbAddValue.SelectedText = "";
            this.mtbAddValue.SelectionLength = 0;
            this.mtbAddValue.SelectionStart = 0;
            this.mtbAddValue.ShortcutsEnabled = true;
            this.mtbAddValue.Size = new System.Drawing.Size(294, 48);
            this.mtbAddValue.TabIndex = 2;
            this.mtbAddValue.TabStop = false;
            this.mtbAddValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbAddValue.TrailingIcon = null;
            this.mtbAddValue.UseSystemPasswordChar = false;
            this.mtbAddValue.Leave += new System.EventHandler(this.mtbAddValue_Leave_1);
            this.mtbAddValue.TextChanged += new System.EventHandler(this.mtbAddValue_TextChanged);
            // 
            // mtbcardcred
            // 
            this.mtbcardcred.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbcardcred.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbcardcred.Depth = 0;
            this.mtbcardcred.HighEmphasis = true;
            this.mtbcardcred.Icon = null;
            this.mtbcardcred.Location = new System.Drawing.Point(106, 189);
            this.mtbcardcred.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbcardcred.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbcardcred.Name = "mtbcardcred";
            this.mtbcardcred.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbcardcred.Size = new System.Drawing.Size(82, 36);
            this.mtbcardcred.TabIndex = 22;
            this.mtbcardcred.TabStop = false;
            this.mtbcardcred.Text = "CRÉDITO";
            this.mtbcardcred.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbcardcred.UseAccentColor = false;
            this.mtbcardcred.Click += new System.EventHandler(this.mtbcardcred_Click);
            // 
            // mbtCarddeb
            // 
            this.mbtCarddeb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtCarddeb.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtCarddeb.Depth = 0;
            this.mbtCarddeb.HighEmphasis = true;
            this.mbtCarddeb.Icon = null;
            this.mbtCarddeb.Location = new System.Drawing.Point(208, 189);
            this.mbtCarddeb.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtCarddeb.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtCarddeb.Name = "mbtCarddeb";
            this.mbtCarddeb.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtCarddeb.Size = new System.Drawing.Size(72, 36);
            this.mbtCarddeb.TabIndex = 23;
            this.mbtCarddeb.TabStop = false;
            this.mbtCarddeb.Text = "DÉBITO";
            this.mbtCarddeb.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtCarddeb.UseAccentColor = false;
            this.mbtCarddeb.Click += new System.EventHandler(this.mbtCarddeb_Click);
            // 
            // mbtPix
            // 
            this.mbtPix.AutoSize = false;
            this.mbtPix.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtPix.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtPix.Depth = 0;
            this.mbtPix.HighEmphasis = true;
            this.mbtPix.Icon = null;
            this.mbtPix.Location = new System.Drawing.Point(6, 239);
            this.mbtPix.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtPix.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtPix.Name = "mbtPix";
            this.mbtPix.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtPix.Size = new System.Drawing.Size(75, 36);
            this.mbtPix.TabIndex = 24;
            this.mbtPix.TabStop = false;
            this.mbtPix.Text = "PIX";
            this.mbtPix.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtPix.UseAccentColor = false;
            this.mbtPix.Click += new System.EventHandler(this.mbtPix_Click);
            // 
            // mbtCheque
            // 
            this.mbtCheque.AutoSize = false;
            this.mbtCheque.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtCheque.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtCheque.Depth = 0;
            this.mbtCheque.HighEmphasis = true;
            this.mbtCheque.Icon = null;
            this.mbtCheque.Location = new System.Drawing.Point(106, 239);
            this.mbtCheque.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtCheque.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtCheque.Name = "mbtCheque";
            this.mbtCheque.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtCheque.Size = new System.Drawing.Size(82, 36);
            this.mbtCheque.TabIndex = 25;
            this.mbtCheque.TabStop = false;
            this.mbtCheque.Text = "CHEQUE";
            this.mbtCheque.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtCheque.UseAccentColor = false;
            this.mbtCheque.Click += new System.EventHandler(this.mbtCheque_Click);
            // 
            // mbtAccount
            // 
            this.mbtAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtAccount.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtAccount.Depth = 0;
            this.mbtAccount.HighEmphasis = true;
            this.mbtAccount.Icon = null;
            this.mbtAccount.Location = new System.Drawing.Point(208, 239);
            this.mbtAccount.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtAccount.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtAccount.Name = "mbtAccount";
            this.mbtAccount.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtAccount.Size = new System.Drawing.Size(70, 36);
            this.mbtAccount.TabIndex = 26;
            this.mbtAccount.TabStop = false;
            this.mbtAccount.Text = "CONTA";
            this.mbtAccount.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtAccount.UseAccentColor = false;
            this.mbtAccount.Click += new System.EventHandler(this.mbtAccount_Click);
            // 
            // mtbObservacao
            // 
            this.mtbObservacao.AnimateReadOnly = false;
            this.mtbObservacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbObservacao.Depth = 0;
            this.mtbObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbObservacao.HideSelection = true;
            this.mtbObservacao.Hint = "OBSERVAÇÃO (opcional)";
            this.mtbObservacao.LeadingIcon = null;
            this.mtbObservacao.Location = new System.Drawing.Point(6, 289);
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
            this.mtbObservacao.Size = new System.Drawing.Size(294, 48);
            this.mtbObservacao.TabIndex = 3;
            this.mtbObservacao.TabStop = false;
            this.mtbObservacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbObservacao.TrailingIcon = null;
            this.mtbObservacao.UseSystemPasswordChar = false;
            // 
            // mtbDoccument
            // 
            this.mtbDoccument.AnimateReadOnly = false;
            this.mtbDoccument.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDoccument.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDoccument.Depth = 0;
            this.mtbDoccument.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDoccument.HelperText = "F4 - Novo cliente | F5 - Alterar cliente";
            this.mtbDoccument.HideSelection = true;
            this.mtbDoccument.Hint = "CPF/CNPJ CLIENTE";
            this.mtbDoccument.LeadingIcon = null;
            this.mtbDoccument.Location = new System.Drawing.Point(365, 279);
            this.mtbDoccument.MaxLength = 32767;
            this.mtbDoccument.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDoccument.Name = "mtbDoccument";
            this.mtbDoccument.PasswordChar = '\0';
            this.mtbDoccument.PrefixSuffixText = null;
            this.mtbDoccument.ReadOnly = false;
            this.mtbDoccument.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDoccument.SelectedText = "";
            this.mtbDoccument.SelectionLength = 0;
            this.mtbDoccument.SelectionStart = 0;
            this.mtbDoccument.ShortcutsEnabled = true;
            this.mtbDoccument.ShowAssistiveText = true;
            this.mtbDoccument.Size = new System.Drawing.Size(294, 64);
            this.mtbDoccument.TabIndex = 6;
            this.mtbDoccument.TabStop = false;
            this.mtbDoccument.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDoccument.TrailingIcon = null;
            this.mtbDoccument.UseSystemPasswordChar = false;
            this.mtbDoccument.Leave += new System.EventHandler(this.mtbDoccument_Leave);
            this.mtbDoccument.TextChanged += new System.EventHandler(this.mtbDoccument_TextChanged);
            // 
            // mtbFirstAndLastName
            // 
            this.mtbFirstAndLastName.AnimateReadOnly = false;
            this.mtbFirstAndLastName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbFirstAndLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbFirstAndLastName.Depth = 0;
            this.mtbFirstAndLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbFirstAndLastName.HideSelection = true;
            this.mtbFirstAndLastName.Hint = "CLIENTE";
            this.mtbFirstAndLastName.LeadingIcon = null;
            this.mtbFirstAndLastName.Location = new System.Drawing.Point(365, 348);
            this.mtbFirstAndLastName.MaxLength = 32767;
            this.mtbFirstAndLastName.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbFirstAndLastName.Name = "mtbFirstAndLastName";
            this.mtbFirstAndLastName.PasswordChar = '\0';
            this.mtbFirstAndLastName.PrefixSuffixText = null;
            this.mtbFirstAndLastName.ReadOnly = true;
            this.mtbFirstAndLastName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbFirstAndLastName.SelectedText = "";
            this.mtbFirstAndLastName.SelectionLength = 0;
            this.mtbFirstAndLastName.SelectionStart = 0;
            this.mtbFirstAndLastName.ShortcutsEnabled = true;
            this.mtbFirstAndLastName.Size = new System.Drawing.Size(294, 48);
            this.mtbFirstAndLastName.TabIndex = 21;
            this.mtbFirstAndLastName.TabStop = false;
            this.mtbFirstAndLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbFirstAndLastName.TrailingIcon = null;
            this.mtbFirstAndLastName.UseSystemPasswordChar = false;
            // 
            // fmSalePaymant
            // 
            this.ClientSize = new System.Drawing.Size(684, 410);
            this.Controls.Add(this.mtbFirstAndLastName);
            this.Controls.Add(this.mtbDoccument);
            this.Controls.Add(this.gbValues);
            this.Controls.Add(this.mbtCancel);
            this.Controls.Add(this.mbtConfirm);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.mlbTotal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mtbValorRecebido);
            this.Controls.Add(this.mtbTroco);
            this.Controls.Add(this.mtbFunc);
            this.Name = "fmSalePaymant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento da Venda";
            this.Load += new System.EventHandler(this.fmSalePaymant_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmSalePaymant_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbValues.ResumeLayout(false);
            this.gbValues.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialComboBox mtbFunc;
        private MaterialSkin.Controls.MaterialButton mbtCancel;
        private MaterialSkin.Controls.MaterialButton mbtConfirm;
        private MaterialSkin.Controls.MaterialButton mbtcash;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel mlbTotal;
        private MaterialSkin.Controls.MaterialTextBox2 mtbValorRecebido;
        private MaterialSkin.Controls.MaterialTextBox2 mtbTroco;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbValues;
        private MaterialSkin.Controls.MaterialButton mtbcash;
        private MaterialSkin.Controls.MaterialTextBox2 mtbSubTotal;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDesc;
        private MaterialSkin.Controls.MaterialTextBox2 mtbAddValue;
        private MaterialSkin.Controls.MaterialButton mtbcardcred;
        private MaterialSkin.Controls.MaterialButton mbtCarddeb;
        private MaterialSkin.Controls.MaterialButton mbtPix;
        private MaterialSkin.Controls.MaterialButton mbtCheque;
        private MaterialSkin.Controls.MaterialButton mbtAccount;
        private MaterialSkin.Controls.MaterialTextBox2 mtbObservacao;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDoccument;
        private MaterialSkin.Controls.MaterialTextBox2 mtbFirstAndLastName;
    }
}
