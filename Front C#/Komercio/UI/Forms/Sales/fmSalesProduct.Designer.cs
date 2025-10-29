namespace Komercio.UI.Forms.Sales
{
    partial class fmSalesProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmSalesProduct));
            this.mepSearchProduct = new MaterialSkin.Controls.MaterialExpansionPanel();
            this.dbListaproduto = new System.Windows.Forms.DataGridView();
            this.materialTextBox22 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTextBox21 = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbBarCode = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbProductName = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbUnitPrice = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbQuantity = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbTotalproduct = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbStock = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbAddCar = new MaterialSkin.Controls.MaterialButton();
            this.mlbTotal = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvCarrinho = new System.Windows.Forms.DataGridView();
            this.mbtClear = new MaterialSkin.Controls.MaterialButton();
            this.mbtremove = new MaterialSkin.Controls.MaterialButton();
            this.mswAutoInput = new MaterialSkin.Controls.MaterialSwitch();
            this.mtbPayment = new MaterialSkin.Controls.MaterialButton();
            this.mepSearchProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbListaproduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).BeginInit();
            this.SuspendLayout();
            // 
            // mepSearchProduct
            // 
            this.mepSearchProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mepSearchProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mepSearchProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mepSearchProduct.CancelButtonText = "Cancelar";
            this.mepSearchProduct.Collapse = true;
            this.mepSearchProduct.Controls.Add(this.dbListaproduto);
            this.mepSearchProduct.Controls.Add(this.materialTextBox22);
            this.mepSearchProduct.Controls.Add(this.materialTextBox21);
            this.mepSearchProduct.Depth = 0;
            this.mepSearchProduct.Description = "";
            this.mepSearchProduct.ExpandHeight = 401;
            this.mepSearchProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mepSearchProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mepSearchProduct.Location = new System.Drawing.Point(12, 10);
            this.mepSearchProduct.Margin = new System.Windows.Forms.Padding(16, 1, 16, 0);
            this.mepSearchProduct.MouseState = MaterialSkin.MouseState.HOVER;
            this.mepSearchProduct.Name = "mepSearchProduct";
            this.mepSearchProduct.Padding = new System.Windows.Forms.Padding(24, 64, 24, 16);
            this.mepSearchProduct.ShowCollapseExpand = false;
            this.mepSearchProduct.Size = new System.Drawing.Size(672, 48);
            this.mepSearchProduct.TabIndex = 1;
            this.mepSearchProduct.Title = "Busca manual de produtos";
            this.mepSearchProduct.ValidationButtonText = "";
            // 
            // dbListaproduto
            // 
            this.dbListaproduto.AllowUserToAddRows = false;
            this.dbListaproduto.AllowUserToDeleteRows = false;
            this.dbListaproduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbListaproduto.Location = new System.Drawing.Point(8, 124);
            this.dbListaproduto.Name = "dbListaproduto";
            this.dbListaproduto.ReadOnly = true;
            this.dbListaproduto.Size = new System.Drawing.Size(643, 196);
            this.dbListaproduto.TabIndex = 4;
            this.dbListaproduto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbListaproduto_CellDoubleClick);
            // 
            // materialTextBox22
            // 
            this.materialTextBox22.AnimateReadOnly = false;
            this.materialTextBox22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox22.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox22.Depth = 0;
            this.materialTextBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox22.HelperText = "Selecione o item depois incluir";
            this.materialTextBox22.HideSelection = true;
            this.materialTextBox22.Hint = "Descrução do produto";
            this.materialTextBox22.LeadingIcon = null;
            this.materialTextBox22.Location = new System.Drawing.Point(8, 54);
            this.materialTextBox22.MaxLength = 32767;
            this.materialTextBox22.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox22.Name = "materialTextBox22";
            this.materialTextBox22.PasswordChar = '\0';
            this.materialTextBox22.PrefixSuffixText = null;
            this.materialTextBox22.ReadOnly = false;
            this.materialTextBox22.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox22.SelectedText = "";
            this.materialTextBox22.SelectionLength = 0;
            this.materialTextBox22.SelectionStart = 0;
            this.materialTextBox22.ShortcutsEnabled = true;
            this.materialTextBox22.ShowAssistiveText = true;
            this.materialTextBox22.Size = new System.Drawing.Size(309, 64);
            this.materialTextBox22.TabIndex = 3;
            this.materialTextBox22.TabStop = false;
            this.materialTextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox22.TrailingIcon = null;
            this.materialTextBox22.UseSystemPasswordChar = false;
            this.materialTextBox22.TextChanged += new System.EventHandler(this.materialTextBox22_TextChanged);
            // 
            // materialTextBox21
            // 
            this.materialTextBox21.AnimateReadOnly = false;
            this.materialTextBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox21.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox21.Depth = 0;
            this.materialTextBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox21.HelperText = "Selecione o item depois incluir";
            this.materialTextBox21.HideSelection = true;
            this.materialTextBox21.Hint = "Grupo do produto";
            this.materialTextBox21.LeadingIcon = null;
            this.materialTextBox21.Location = new System.Drawing.Point(379, 54);
            this.materialTextBox21.MaxLength = 32767;
            this.materialTextBox21.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox21.Name = "materialTextBox21";
            this.materialTextBox21.PasswordChar = '\0';
            this.materialTextBox21.PrefixSuffixText = null;
            this.materialTextBox21.ReadOnly = false;
            this.materialTextBox21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox21.SelectedText = "";
            this.materialTextBox21.SelectionLength = 0;
            this.materialTextBox21.SelectionStart = 0;
            this.materialTextBox21.ShortcutsEnabled = true;
            this.materialTextBox21.ShowAssistiveText = true;
            this.materialTextBox21.Size = new System.Drawing.Size(272, 64);
            this.materialTextBox21.TabIndex = 2;
            this.materialTextBox21.TabStop = false;
            this.materialTextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox21.TrailingIcon = null;
            this.materialTextBox21.UseSystemPasswordChar = false;
            this.materialTextBox21.TextChanged += new System.EventHandler(this.materialTextBox21_TextChanged);
            // 
            // mtbBarCode
            // 
            this.mtbBarCode.AnimateReadOnly = true;
            this.mtbBarCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbBarCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbBarCode.Depth = 0;
            this.mtbBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbBarCode.HelperText = "Código de barras";
            this.mtbBarCode.HideSelection = true;
            this.mtbBarCode.Hint = "Código de Barras";
            this.mtbBarCode.LeadingIcon = null;
            this.mtbBarCode.Location = new System.Drawing.Point(12, 72);
            this.mtbBarCode.MaxLength = 32767;
            this.mtbBarCode.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbBarCode.Name = "mtbBarCode";
            this.mtbBarCode.PasswordChar = '\0';
            this.mtbBarCode.PrefixSuffixText = null;
            this.mtbBarCode.ReadOnly = false;
            this.mtbBarCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbBarCode.SelectedText = "";
            this.mtbBarCode.SelectionLength = 0;
            this.mtbBarCode.SelectionStart = 0;
            this.mtbBarCode.ShortcutsEnabled = true;
            this.mtbBarCode.ShowAssistiveText = true;
            this.mtbBarCode.Size = new System.Drawing.Size(151, 64);
            this.mtbBarCode.TabIndex = 2;
            this.mtbBarCode.TabStop = false;
            this.mtbBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbBarCode.TrailingIcon = null;
            this.mtbBarCode.UseSystemPasswordChar = false;
            this.mtbBarCode.TextChanged += new System.EventHandler(this.mtbBarCode_TextChanged);
            // 
            // mtbProductName
            // 
            this.mtbProductName.AnimateReadOnly = false;
            this.mtbProductName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbProductName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbProductName.Depth = 0;
            this.mtbProductName.Enabled = false;
            this.mtbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbProductName.HideSelection = true;
            this.mtbProductName.Hint = "Descrição do produto";
            this.mtbProductName.LeadingIcon = null;
            this.mtbProductName.Location = new System.Drawing.Point(179, 72);
            this.mtbProductName.MaxLength = 32767;
            this.mtbProductName.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbProductName.Name = "mtbProductName";
            this.mtbProductName.PasswordChar = '\0';
            this.mtbProductName.PrefixSuffixText = null;
            this.mtbProductName.ReadOnly = false;
            this.mtbProductName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbProductName.SelectedText = "";
            this.mtbProductName.SelectionLength = 0;
            this.mtbProductName.SelectionStart = 0;
            this.mtbProductName.ShortcutsEnabled = true;
            this.mtbProductName.Size = new System.Drawing.Size(505, 48);
            this.mtbProductName.TabIndex = 3;
            this.mtbProductName.TabStop = false;
            this.mtbProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProductName.TrailingIcon = null;
            this.mtbProductName.UseSystemPasswordChar = false;
            // 
            // mtbUnitPrice
            // 
            this.mtbUnitPrice.AnimateReadOnly = false;
            this.mtbUnitPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbUnitPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbUnitPrice.Depth = 0;
            this.mtbUnitPrice.Enabled = false;
            this.mtbUnitPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbUnitPrice.HideSelection = true;
            this.mtbUnitPrice.Hint = "Preço unitário";
            this.mtbUnitPrice.LeadingIcon = null;
            this.mtbUnitPrice.Location = new System.Drawing.Point(179, 143);
            this.mtbUnitPrice.MaxLength = 32767;
            this.mtbUnitPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbUnitPrice.Name = "mtbUnitPrice";
            this.mtbUnitPrice.PasswordChar = '\0';
            this.mtbUnitPrice.PrefixSuffixText = null;
            this.mtbUnitPrice.ReadOnly = false;
            this.mtbUnitPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbUnitPrice.SelectedText = "";
            this.mtbUnitPrice.SelectionLength = 0;
            this.mtbUnitPrice.SelectionStart = 0;
            this.mtbUnitPrice.ShortcutsEnabled = true;
            this.mtbUnitPrice.Size = new System.Drawing.Size(151, 48);
            this.mtbUnitPrice.TabIndex = 4;
            this.mtbUnitPrice.TabStop = false;
            this.mtbUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbUnitPrice.TrailingIcon = null;
            this.mtbUnitPrice.UseSystemPasswordChar = false;
            // 
            // mtbQuantity
            // 
            this.mtbQuantity.AnimateReadOnly = false;
            this.mtbQuantity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbQuantity.Depth = 0;
            this.mtbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbQuantity.HideSelection = true;
            this.mtbQuantity.Hint = "Quantidade";
            this.mtbQuantity.LeadingIcon = null;
            this.mtbQuantity.Location = new System.Drawing.Point(346, 143);
            this.mtbQuantity.MaxLength = 32767;
            this.mtbQuantity.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbQuantity.Name = "mtbQuantity";
            this.mtbQuantity.PasswordChar = '\0';
            this.mtbQuantity.PrefixSuffixText = null;
            this.mtbQuantity.ReadOnly = false;
            this.mtbQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbQuantity.SelectedText = "";
            this.mtbQuantity.SelectionLength = 0;
            this.mtbQuantity.SelectionStart = 0;
            this.mtbQuantity.ShortcutsEnabled = true;
            this.mtbQuantity.ShowAssistiveText = true;
            this.mtbQuantity.Size = new System.Drawing.Size(151, 64);
            this.mtbQuantity.TabIndex = 5;
            this.mtbQuantity.TabStop = false;
            this.mtbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbQuantity.TrailingIcon = null;
            this.mtbQuantity.UseSystemPasswordChar = false;
            this.mtbQuantity.TextChanged += new System.EventHandler(this.mtbQuantity_TextChanged);
            // 
            // mtbTotalproduct
            // 
            this.mtbTotalproduct.AnimateReadOnly = false;
            this.mtbTotalproduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbTotalproduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbTotalproduct.Depth = 0;
            this.mtbTotalproduct.Enabled = false;
            this.mtbTotalproduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbTotalproduct.HideSelection = true;
            this.mtbTotalproduct.Hint = "Preço final";
            this.mtbTotalproduct.LeadingIcon = null;
            this.mtbTotalproduct.Location = new System.Drawing.Point(513, 143);
            this.mtbTotalproduct.MaxLength = 32767;
            this.mtbTotalproduct.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbTotalproduct.Name = "mtbTotalproduct";
            this.mtbTotalproduct.PasswordChar = '\0';
            this.mtbTotalproduct.PrefixSuffixText = null;
            this.mtbTotalproduct.ReadOnly = false;
            this.mtbTotalproduct.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbTotalproduct.SelectedText = "";
            this.mtbTotalproduct.SelectionLength = 0;
            this.mtbTotalproduct.SelectionStart = 0;
            this.mtbTotalproduct.ShortcutsEnabled = true;
            this.mtbTotalproduct.ShowAssistiveText = true;
            this.mtbTotalproduct.Size = new System.Drawing.Size(171, 64);
            this.mtbTotalproduct.TabIndex = 6;
            this.mtbTotalproduct.TabStop = false;
            this.mtbTotalproduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbTotalproduct.TrailingIcon = null;
            this.mtbTotalproduct.UseSystemPasswordChar = false;
            // 
            // mtbStock
            // 
            this.mtbStock.AnimateReadOnly = false;
            this.mtbStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbStock.Depth = 0;
            this.mtbStock.Enabled = false;
            this.mtbStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbStock.HideSelection = true;
            this.mtbStock.Hint = "Estoque atual";
            this.mtbStock.LeadingIcon = null;
            this.mtbStock.Location = new System.Drawing.Point(12, 143);
            this.mtbStock.MaxLength = 32767;
            this.mtbStock.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbStock.Name = "mtbStock";
            this.mtbStock.PasswordChar = '\0';
            this.mtbStock.PrefixSuffixText = null;
            this.mtbStock.ReadOnly = false;
            this.mtbStock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbStock.SelectedText = "";
            this.mtbStock.SelectionLength = 0;
            this.mtbStock.SelectionStart = 0;
            this.mtbStock.ShortcutsEnabled = true;
            this.mtbStock.Size = new System.Drawing.Size(151, 48);
            this.mtbStock.TabIndex = 14;
            this.mtbStock.TabStop = false;
            this.mtbStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbStock.TrailingIcon = null;
            this.mtbStock.UseSystemPasswordChar = false;
            // 
            // mtbAddCar
            // 
            this.mtbAddCar.AutoSize = false;
            this.mtbAddCar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbAddCar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbAddCar.Depth = 0;
            this.mtbAddCar.HighEmphasis = true;
            this.mtbAddCar.Icon = null;
            this.mtbAddCar.Location = new System.Drawing.Point(12, 213);
            this.mtbAddCar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbAddCar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbAddCar.Name = "mtbAddCar";
            this.mtbAddCar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbAddCar.Size = new System.Drawing.Size(151, 48);
            this.mtbAddCar.TabIndex = 15;
            this.mtbAddCar.Text = "Adicionar no carrinho";
            this.mtbAddCar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbAddCar.UseAccentColor = false;
            this.mtbAddCar.UseVisualStyleBackColor = true;
            this.mtbAddCar.Click += new System.EventHandler(this.mtbAddCar_Click);
            // 
            // mlbTotal
            // 
            this.mlbTotal.Depth = 0;
            this.mlbTotal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.mlbTotal.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mlbTotal.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.mlbTotal.Location = new System.Drawing.Point(72, 565);
            this.mlbTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.mlbTotal.Name = "mlbTotal";
            this.mlbTotal.Size = new System.Drawing.Size(282, 62);
            this.mlbTotal.TabIndex = 16;
            this.mlbTotal.Text = "R$0,00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::Komercio.Properties.Resources.Carrinho;
            this.pictureBox1.Image = global::Komercio.Properties.Resources.Carrinho;
            this.pictureBox1.InitialImage = global::Komercio.Properties.Resources.Carrinho;
            this.pictureBox1.Location = new System.Drawing.Point(12, 574);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // dgvCarrinho
            // 
            this.dgvCarrinho.AllowUserToAddRows = false;
            this.dgvCarrinho.AllowUserToDeleteRows = false;
            this.dgvCarrinho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrinho.Location = new System.Drawing.Point(12, 277);
            this.dgvCarrinho.Name = "dgvCarrinho";
            this.dgvCarrinho.ReadOnly = true;
            this.dgvCarrinho.Size = new System.Drawing.Size(672, 284);
            this.dgvCarrinho.TabIndex = 18;
            // 
            // mbtClear
            // 
            this.mbtClear.AutoSize = false;
            this.mbtClear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtClear.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtClear.Depth = 0;
            this.mbtClear.HighEmphasis = true;
            this.mbtClear.Icon = null;
            this.mbtClear.Location = new System.Drawing.Point(179, 213);
            this.mbtClear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtClear.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtClear.Name = "mbtClear";
            this.mbtClear.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtClear.Size = new System.Drawing.Size(151, 48);
            this.mbtClear.TabIndex = 19;
            this.mbtClear.Text = "Limpar";
            this.mbtClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtClear.UseAccentColor = false;
            this.mbtClear.UseVisualStyleBackColor = true;
            this.mbtClear.Click += new System.EventHandler(this.mbtClear_Click);
            // 
            // mbtremove
            // 
            this.mbtremove.AutoSize = false;
            this.mbtremove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtremove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtremove.Depth = 0;
            this.mbtremove.HighEmphasis = true;
            this.mbtremove.Icon = null;
            this.mbtremove.Location = new System.Drawing.Point(346, 213);
            this.mbtremove.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtremove.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtremove.Name = "mbtremove";
            this.mbtremove.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtremove.Size = new System.Drawing.Size(151, 48);
            this.mbtremove.TabIndex = 20;
            this.mbtremove.Text = "Remover";
            this.mbtremove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtremove.UseAccentColor = false;
            this.mbtremove.UseVisualStyleBackColor = true;
            this.mbtremove.Click += new System.EventHandler(this.mbtremove_Click);
            // 
            // mswAutoInput
            // 
            this.mswAutoInput.AutoSize = true;
            this.mswAutoInput.Depth = 0;
            this.mswAutoInput.Location = new System.Drawing.Point(513, 220);
            this.mswAutoInput.Margin = new System.Windows.Forms.Padding(0);
            this.mswAutoInput.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mswAutoInput.MouseState = MaterialSkin.MouseState.HOVER;
            this.mswAutoInput.Name = "mswAutoInput";
            this.mswAutoInput.Ripple = true;
            this.mswAutoInput.Size = new System.Drawing.Size(171, 37);
            this.mswAutoInput.TabIndex = 21;
            this.mswAutoInput.Text = "Entrada manual";
            this.mswAutoInput.UseVisualStyleBackColor = true;
            this.mswAutoInput.CheckedChanged += new System.EventHandler(this.mswAutoInput_CheckedChanged_1);
            // 
            // mtbPayment
            // 
            this.mtbPayment.AutoSize = false;
            this.mtbPayment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbPayment.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbPayment.Depth = 0;
            this.mtbPayment.HighEmphasis = true;
            this.mtbPayment.Icon = null;
            this.mtbPayment.Location = new System.Drawing.Point(530, 574);
            this.mtbPayment.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbPayment.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbPayment.Name = "mtbPayment";
            this.mtbPayment.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbPayment.Size = new System.Drawing.Size(121, 47);
            this.mtbPayment.TabIndex = 22;
            this.mtbPayment.Text = "Ir para pagamento";
            this.mtbPayment.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbPayment.UseAccentColor = false;
            this.mtbPayment.UseVisualStyleBackColor = true;
            this.mtbPayment.Click += new System.EventHandler(this.mtbPayment_Click);
            // 
            // fmSalesProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 636);
            this.Controls.Add(this.mtbPayment);
            this.Controls.Add(this.mepSearchProduct);
            this.Controls.Add(this.mswAutoInput);
            this.Controls.Add(this.mbtremove);
            this.Controls.Add(this.mbtClear);
            this.Controls.Add(this.dgvCarrinho);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mlbTotal);
            this.Controls.Add(this.mtbAddCar);
            this.Controls.Add(this.mtbStock);
            this.Controls.Add(this.mtbTotalproduct);
            this.Controls.Add(this.mtbQuantity);
            this.Controls.Add(this.mtbUnitPrice);
            this.Controls.Add(this.mtbProductName);
            this.Controls.Add(this.mtbBarCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmSalesProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova venda";
            this.Load += new System.EventHandler(this.fmSalesProduct_Load);
            this.mepSearchProduct.ResumeLayout(false);
            this.mepSearchProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbListaproduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialExpansionPanel mepSearchProduct;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox22;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
        private System.Windows.Forms.DataGridView dbListaproduto;
        private MaterialSkin.Controls.MaterialTextBox2 mtbBarCode;
        private MaterialSkin.Controls.MaterialTextBox2 mtbProductName;
        private MaterialSkin.Controls.MaterialTextBox2 mtbUnitPrice;
        private MaterialSkin.Controls.MaterialTextBox2 mtbQuantity;
        private MaterialSkin.Controls.MaterialTextBox2 mtbTotalproduct;
        private MaterialSkin.Controls.MaterialTextBox2 mtbStock;
        private MaterialSkin.Controls.MaterialButton mtbAddCar;
        private MaterialSkin.Controls.MaterialLabel mlbTotal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvCarrinho;
        private MaterialSkin.Controls.MaterialButton mbtClear;
        private MaterialSkin.Controls.MaterialButton mbtremove;
        private MaterialSkin.Controls.MaterialSwitch mswAutoInput;
        private MaterialSkin.Controls.MaterialButton mtbPayment;
    }
}