namespace Komercio.UI.Forms.Transactions
{
    partial class fmCustomerTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmCustomerTransactions));
            this.mtbName = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtSearch = new MaterialSkin.Controls.MaterialButton();
            this.mtbDoc = new MaterialSkin.Controls.MaterialTextBox2();
            this.dgvCustomerList = new System.Windows.Forms.DataGridView();
            this.mbtCancel = new MaterialSkin.Controls.MaterialButton();
            this.dgvTransactionsList = new System.Windows.Forms.DataGridView();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvItensVenda = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mlbTotalDebito = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.mlbCliente = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.mtbTroco = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbRegistraPagamento = new MaterialSkin.Controls.MaterialButton();
            this.mtbOBS = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbFunc = new MaterialSkin.Controls.MaterialComboBox();
            this.mtbDinheiro = new MaterialSkin.Controls.MaterialButton();
            this.mtbPix = new MaterialSkin.Controls.MaterialButton();
            this.mtbCredito = new MaterialSkin.Controls.MaterialButton();
            this.mtbDebito = new MaterialSkin.Controls.MaterialButton();
            this.mtbPaymentValue = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtbName
            // 
            this.mtbName.AnimateReadOnly = false;
            this.mtbName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbName.Depth = 0;
            this.mtbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbName.HideSelection = true;
            this.mtbName.Hint = "Nome do cliente";
            this.mtbName.LeadingIcon = null;
            this.mtbName.Location = new System.Drawing.Point(345, 25);
            this.mtbName.MaxLength = 32767;
            this.mtbName.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbName.Name = "mtbName";
            this.mtbName.PasswordChar = '\0';
            this.mtbName.PrefixSuffixText = null;
            this.mtbName.ReadOnly = false;
            this.mtbName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbName.SelectedText = "";
            this.mtbName.SelectionLength = 0;
            this.mtbName.SelectionStart = 0;
            this.mtbName.ShortcutsEnabled = true;
            this.mtbName.Size = new System.Drawing.Size(217, 36);
            this.mtbName.TabIndex = 0;
            this.mtbName.TabStop = false;
            this.mtbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbName.TrailingIcon = null;
            this.mtbName.UseSystemPasswordChar = false;
            this.mtbName.UseTallSize = false;
            this.mtbName.Enter += new System.EventHandler(this.mtbName_Enter);
            // 
            // mbtSearch
            // 
            this.mbtSearch.AutoSize = false;
            this.mbtSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtSearch.Depth = 0;
            this.mbtSearch.HighEmphasis = true;
            this.mbtSearch.Icon = null;
            this.mbtSearch.Location = new System.Drawing.Point(587, 25);
            this.mbtSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtSearch.Name = "mbtSearch";
            this.mbtSearch.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtSearch.Size = new System.Drawing.Size(75, 36);
            this.mbtSearch.TabIndex = 1;
            this.mbtSearch.Text = "Buscar";
            this.mbtSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtSearch.UseAccentColor = false;
            this.mbtSearch.UseVisualStyleBackColor = true;
            this.mbtSearch.Click += new System.EventHandler(this.mbtSearch_Click);
            // 
            // mtbDoc
            // 
            this.mtbDoc.AnimateReadOnly = false;
            this.mtbDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDoc.Depth = 0;
            this.mtbDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDoc.HideSelection = true;
            this.mtbDoc.Hint = "CPF/CNPJ";
            this.mtbDoc.LeadingIcon = null;
            this.mtbDoc.Location = new System.Drawing.Point(345, 79);
            this.mtbDoc.MaxLength = 32767;
            this.mtbDoc.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDoc.Name = "mtbDoc";
            this.mtbDoc.PasswordChar = '\0';
            this.mtbDoc.PrefixSuffixText = null;
            this.mtbDoc.ReadOnly = false;
            this.mtbDoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDoc.SelectedText = "";
            this.mtbDoc.SelectionLength = 0;
            this.mtbDoc.SelectionStart = 0;
            this.mtbDoc.ShortcutsEnabled = true;
            this.mtbDoc.Size = new System.Drawing.Size(217, 36);
            this.mtbDoc.TabIndex = 3;
            this.mtbDoc.TabStop = false;
            this.mtbDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDoc.TrailingIcon = null;
            this.mtbDoc.UseSystemPasswordChar = false;
            this.mtbDoc.UseTallSize = false;
            this.mtbDoc.Click += new System.EventHandler(this.mtbDoc_Click);
            this.mtbDoc.Enter += new System.EventHandler(this.mtbDoc_Enter);
            this.mtbDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDoc_KeyPress);
            // 
            // dgvCustomerList
            // 
            this.dgvCustomerList.AllowUserToAddRows = false;
            this.dgvCustomerList.AllowUserToDeleteRows = false;
            this.dgvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerList.Location = new System.Drawing.Point(12, 25);
            this.dgvCustomerList.Name = "dgvCustomerList";
            this.dgvCustomerList.ReadOnly = true;
            this.dgvCustomerList.Size = new System.Drawing.Size(317, 90);
            this.dgvCustomerList.TabIndex = 5;
            this.dgvCustomerList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerList_CellDoubleClick);
            // 
            // mbtCancel
            // 
            this.mbtCancel.AutoSize = false;
            this.mbtCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtCancel.Depth = 0;
            this.mbtCancel.HighEmphasis = true;
            this.mbtCancel.Icon = null;
            this.mbtCancel.Location = new System.Drawing.Point(587, 79);
            this.mbtCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtCancel.Name = "mbtCancel";
            this.mbtCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtCancel.Size = new System.Drawing.Size(75, 36);
            this.mbtCancel.TabIndex = 6;
            this.mbtCancel.Text = "Limpar";
            this.mbtCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtCancel.UseAccentColor = false;
            this.mbtCancel.UseVisualStyleBackColor = true;
            this.mbtCancel.Click += new System.EventHandler(this.mbtCancel_Click);
            // 
            // dgvTransactionsList
            // 
            this.dgvTransactionsList.AllowUserToAddRows = false;
            this.dgvTransactionsList.AllowUserToDeleteRows = false;
            this.dgvTransactionsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionsList.Location = new System.Drawing.Point(12, 148);
            this.dgvTransactionsList.Name = "dgvTransactionsList";
            this.dgvTransactionsList.ReadOnly = true;
            this.dgvTransactionsList.Size = new System.Drawing.Size(650, 185);
            this.dgvTransactionsList.TabIndex = 7;
            this.dgvTransactionsList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionsList_CellDoubleClick);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(12, 126);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(203, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Movimentação da caderneta";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(12, 343);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(104, 19);
            this.materialLabel2.TabIndex = 10;
            this.materialLabel2.Text = "Itens da venda";
            // 
            // dgvItensVenda
            // 
            this.dgvItensVenda.AllowUserToAddRows = false;
            this.dgvItensVenda.AllowUserToDeleteRows = false;
            this.dgvItensVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensVenda.Location = new System.Drawing.Point(12, 364);
            this.dgvItensVenda.Name = "dgvItensVenda";
            this.dgvItensVenda.ReadOnly = true;
            this.dgvItensVenda.Size = new System.Drawing.Size(650, 132);
            this.dgvItensVenda.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Komercio.Properties.Resources.icone_de_l_argent_symbole_png_rose2;
            this.pictureBox1.Location = new System.Drawing.Point(680, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // mlbTotalDebito
            // 
            this.mlbTotalDebito.AutoSize = true;
            this.mlbTotalDebito.Depth = 0;
            this.mlbTotalDebito.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mlbTotalDebito.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.mlbTotalDebito.Location = new System.Drawing.Point(762, 57);
            this.mlbTotalDebito.MouseState = MaterialSkin.MouseState.HOVER;
            this.mlbTotalDebito.Name = "mlbTotalDebito";
            this.mlbTotalDebito.Size = new System.Drawing.Size(160, 58);
            this.mlbTotalDebito.TabIndex = 13;
            this.mlbTotalDebito.Text = "R$ 0,00";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(677, 11);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(53, 19);
            this.materialLabel3.TabIndex = 14;
            this.materialLabel3.Text = "Cliente:";
            // 
            // mlbCliente
            // 
            this.mlbCliente.AutoSize = true;
            this.mlbCliente.Depth = 0;
            this.mlbCliente.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mlbCliente.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.mlbCliente.Location = new System.Drawing.Point(736, 9);
            this.mlbCliente.MouseState = MaterialSkin.MouseState.HOVER;
            this.mlbCliente.Name = "mlbCliente";
            this.mlbCliente.Size = new System.Drawing.Size(25, 24);
            this.mlbCliente.TabIndex = 15;
            this.mlbCliente.Text = " -- ";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(677, 45);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(106, 19);
            this.materialLabel4.TabIndex = 16;
            this.materialLabel4.Text = "Saldo devedor:";
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.mtbTroco);
            this.materialCard1.Controls.Add(this.mtbRegistraPagamento);
            this.materialCard1.Controls.Add(this.mtbOBS);
            this.materialCard1.Controls.Add(this.mtbFunc);
            this.materialCard1.Controls.Add(this.mtbDinheiro);
            this.materialCard1.Controls.Add(this.mtbPix);
            this.materialCard1.Controls.Add(this.mtbCredito);
            this.materialCard1.Controls.Add(this.mtbDebito);
            this.materialCard1.Controls.Add(this.mtbPaymentValue);
            this.materialCard1.Depth = 0;
            this.materialCard1.Enabled = false;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(680, 148);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(342, 348);
            this.materialCard1.TabIndex = 17;
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
            this.mtbTroco.Hint = "Troco";
            this.mtbTroco.LeadingIcon = null;
            this.mtbTroco.Location = new System.Drawing.Point(51, 98);
            this.mtbTroco.MaxLength = 32767;
            this.mtbTroco.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbTroco.Name = "mtbTroco";
            this.mtbTroco.PasswordChar = '\0';
            this.mtbTroco.PrefixSuffixText = null;
            this.mtbTroco.ReadOnly = true;
            this.mtbTroco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbTroco.SelectedText = "";
            this.mtbTroco.SelectionLength = 0;
            this.mtbTroco.SelectionStart = 0;
            this.mtbTroco.ShortcutsEnabled = true;
            this.mtbTroco.Size = new System.Drawing.Size(250, 36);
            this.mtbTroco.TabIndex = 9;
            this.mtbTroco.TabStop = false;
            this.mtbTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbTroco.TrailingIcon = null;
            this.mtbTroco.UseSystemPasswordChar = false;
            this.mtbTroco.UseTallSize = false;
            this.mtbTroco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbTroco_KeyPress);
            // 
            // mtbRegistraPagamento
            // 
            this.mtbRegistraPagamento.AutoSize = false;
            this.mtbRegistraPagamento.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbRegistraPagamento.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbRegistraPagamento.Depth = 0;
            this.mtbRegistraPagamento.HighEmphasis = true;
            this.mtbRegistraPagamento.Icon = null;
            this.mtbRegistraPagamento.Location = new System.Drawing.Point(93, 270);
            this.mtbRegistraPagamento.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbRegistraPagamento.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbRegistraPagamento.Name = "mtbRegistraPagamento";
            this.mtbRegistraPagamento.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbRegistraPagamento.Size = new System.Drawing.Size(158, 36);
            this.mtbRegistraPagamento.TabIndex = 8;
            this.mtbRegistraPagamento.Text = "Registrar pagamento";
            this.mtbRegistraPagamento.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbRegistraPagamento.UseAccentColor = false;
            this.mtbRegistraPagamento.UseVisualStyleBackColor = true;
            this.mtbRegistraPagamento.Click += new System.EventHandler(this.mtbRegistraPagamento_Click);
            // 
            // mtbOBS
            // 
            this.mtbOBS.AnimateReadOnly = false;
            this.mtbOBS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbOBS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbOBS.Depth = 0;
            this.mtbOBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbOBS.HideSelection = true;
            this.mtbOBS.Hint = "Observações.";
            this.mtbOBS.LeadingIcon = null;
            this.mtbOBS.Location = new System.Drawing.Point(51, 186);
            this.mtbOBS.MaxLength = 32767;
            this.mtbOBS.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbOBS.Name = "mtbOBS";
            this.mtbOBS.PasswordChar = '\0';
            this.mtbOBS.PrefixSuffixText = null;
            this.mtbOBS.ReadOnly = false;
            this.mtbOBS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbOBS.SelectedText = "";
            this.mtbOBS.SelectionLength = 0;
            this.mtbOBS.SelectionStart = 0;
            this.mtbOBS.ShortcutsEnabled = true;
            this.mtbOBS.Size = new System.Drawing.Size(250, 36);
            this.mtbOBS.TabIndex = 7;
            this.mtbOBS.TabStop = false;
            this.mtbOBS.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbOBS.TrailingIcon = null;
            this.mtbOBS.UseSystemPasswordChar = false;
            this.mtbOBS.UseTallSize = false;
            // 
            // mtbFunc
            // 
            this.mtbFunc.AutoResize = false;
            this.mtbFunc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mtbFunc.Depth = 0;
            this.mtbFunc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mtbFunc.DropDownHeight = 118;
            this.mtbFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mtbFunc.DropDownWidth = 121;
            this.mtbFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mtbFunc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mtbFunc.FormattingEnabled = true;
            this.mtbFunc.Hint = "Vendedor";
            this.mtbFunc.IntegralHeight = false;
            this.mtbFunc.ItemHeight = 29;
            this.mtbFunc.Location = new System.Drawing.Point(51, 145);
            this.mtbFunc.MaxDropDownItems = 4;
            this.mtbFunc.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbFunc.Name = "mtbFunc";
            this.mtbFunc.Size = new System.Drawing.Size(250, 35);
            this.mtbFunc.StartIndex = 0;
            this.mtbFunc.TabIndex = 6;
            this.mtbFunc.UseTallSize = false;
            // 
            // mtbDinheiro
            // 
            this.mtbDinheiro.AutoSize = false;
            this.mtbDinheiro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbDinheiro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbDinheiro.Depth = 0;
            this.mtbDinheiro.HighEmphasis = true;
            this.mtbDinheiro.Icon = null;
            this.mtbDinheiro.Location = new System.Drawing.Point(259, 53);
            this.mtbDinheiro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbDinheiro.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbDinheiro.Name = "mtbDinheiro";
            this.mtbDinheiro.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbDinheiro.Size = new System.Drawing.Size(75, 36);
            this.mtbDinheiro.TabIndex = 4;
            this.mtbDinheiro.Text = "Dinheiro";
            this.mtbDinheiro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbDinheiro.UseAccentColor = false;
            this.mtbDinheiro.UseVisualStyleBackColor = true;
            this.mtbDinheiro.Click += new System.EventHandler(this.mtbDinheiro_Click);
            // 
            // mtbPix
            // 
            this.mtbPix.AutoSize = false;
            this.mtbPix.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbPix.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbPix.Depth = 0;
            this.mtbPix.HighEmphasis = true;
            this.mtbPix.Icon = null;
            this.mtbPix.Location = new System.Drawing.Point(176, 53);
            this.mtbPix.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbPix.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbPix.Name = "mtbPix";
            this.mtbPix.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbPix.Size = new System.Drawing.Size(75, 36);
            this.mtbPix.TabIndex = 3;
            this.mtbPix.Text = "Pix";
            this.mtbPix.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbPix.UseAccentColor = false;
            this.mtbPix.UseVisualStyleBackColor = true;
            this.mtbPix.Click += new System.EventHandler(this.mtbPix_Click);
            // 
            // mtbCredito
            // 
            this.mtbCredito.AutoSize = false;
            this.mtbCredito.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbCredito.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbCredito.Depth = 0;
            this.mtbCredito.HighEmphasis = true;
            this.mtbCredito.Icon = null;
            this.mtbCredito.Location = new System.Drawing.Point(93, 53);
            this.mtbCredito.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbCredito.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbCredito.Name = "mtbCredito";
            this.mtbCredito.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbCredito.Size = new System.Drawing.Size(75, 36);
            this.mtbCredito.TabIndex = 2;
            this.mtbCredito.Text = "Crédito";
            this.mtbCredito.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbCredito.UseAccentColor = false;
            this.mtbCredito.UseVisualStyleBackColor = true;
            this.mtbCredito.Click += new System.EventHandler(this.mtbCredito_Click);
            // 
            // mtbDebito
            // 
            this.mtbDebito.AutoSize = false;
            this.mtbDebito.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbDebito.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbDebito.Depth = 0;
            this.mtbDebito.HighEmphasis = true;
            this.mtbDebito.Icon = null;
            this.mtbDebito.Location = new System.Drawing.Point(10, 53);
            this.mtbDebito.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbDebito.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbDebito.Name = "mtbDebito";
            this.mtbDebito.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbDebito.Size = new System.Drawing.Size(75, 36);
            this.mtbDebito.TabIndex = 1;
            this.mtbDebito.Text = "Débito";
            this.mtbDebito.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbDebito.UseAccentColor = false;
            this.mtbDebito.UseVisualStyleBackColor = true;
            this.mtbDebito.Click += new System.EventHandler(this.mtbDebito_Click);
            // 
            // mtbPaymentValue
            // 
            this.mtbPaymentValue.AnimateReadOnly = false;
            this.mtbPaymentValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbPaymentValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbPaymentValue.Depth = 0;
            this.mtbPaymentValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbPaymentValue.HideSelection = true;
            this.mtbPaymentValue.Hint = "Valor a pagar";
            this.mtbPaymentValue.LeadingIcon = null;
            this.mtbPaymentValue.Location = new System.Drawing.Point(51, 10);
            this.mtbPaymentValue.MaxLength = 32767;
            this.mtbPaymentValue.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbPaymentValue.Name = "mtbPaymentValue";
            this.mtbPaymentValue.PasswordChar = '\0';
            this.mtbPaymentValue.PrefixSuffixText = null;
            this.mtbPaymentValue.ReadOnly = false;
            this.mtbPaymentValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbPaymentValue.SelectedText = "";
            this.mtbPaymentValue.SelectionLength = 0;
            this.mtbPaymentValue.SelectionStart = 0;
            this.mtbPaymentValue.ShortcutsEnabled = true;
            this.mtbPaymentValue.Size = new System.Drawing.Size(250, 36);
            this.mtbPaymentValue.TabIndex = 0;
            this.mtbPaymentValue.TabStop = false;
            this.mtbPaymentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbPaymentValue.TrailingIcon = null;
            this.mtbPaymentValue.UseAccent = false;
            this.mtbPaymentValue.UseSystemPasswordChar = false;
            this.mtbPaymentValue.UseTallSize = false;
            this.mtbPaymentValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbPaymentValue_KeyPress);
            this.mtbPaymentValue.TextChanged += new System.EventHandler(this.mtbPaymentValue_TextChanged);
            // 
            // fmCustomerTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 503);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.mlbCliente);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.mlbTotalDebito);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.dgvItensVenda);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dgvTransactionsList);
            this.Controls.Add(this.mbtCancel);
            this.Controls.Add(this.dgvCustomerList);
            this.Controls.Add(this.mtbDoc);
            this.Controls.Add(this.mbtSearch);
            this.Controls.Add(this.mtbName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmCustomerTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visualizar débitos";
            this.Load += new System.EventHandler(this.fmCustomerTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 mtbName;
        private MaterialSkin.Controls.MaterialButton mbtSearch;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDoc;
        private System.Windows.Forms.DataGridView dgvCustomerList;
        private MaterialSkin.Controls.MaterialButton mbtCancel;
        private System.Windows.Forms.DataGridView dgvTransactionsList;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DataGridView dgvItensVenda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel mlbTotalDebito;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel mlbCliente;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialTextBox2 mtbPaymentValue;
        private MaterialSkin.Controls.MaterialButton mtbDinheiro;
        private MaterialSkin.Controls.MaterialButton mtbPix;
        private MaterialSkin.Controls.MaterialButton mtbCredito;
        private MaterialSkin.Controls.MaterialButton mtbDebito;
        private MaterialSkin.Controls.MaterialComboBox mtbFunc;
        private MaterialSkin.Controls.MaterialButton mtbRegistraPagamento;
        private MaterialSkin.Controls.MaterialTextBox2 mtbOBS;
        private MaterialSkin.Controls.MaterialTextBox2 mtbTroco;
    }
}