namespace Komercio.UI.Forms.Sales
{
    partial class frmMultiplosPagamentos
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
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.mtbPago = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbDevido = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbVoltarPagamento = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mbtDinheiro = new MaterialSkin.Controls.MaterialButton();
            this.mbtPix = new MaterialSkin.Controls.MaterialButton();
            this.mbtDebito = new MaterialSkin.Controls.MaterialButton();
            this.mbtCredito = new MaterialSkin.Controls.MaterialButton();
            this.mbtConta = new MaterialSkin.Controls.MaterialButton();
            this.mtbDinheiro = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbPix = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbDebito = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCredito = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbConta = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialCard1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.mtbPago);
            this.materialCard1.Controls.Add(this.mtbDevido);
            this.materialCard1.Controls.Add(this.mtbVoltarPagamento);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(0, 0);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(418, 108);
            this.materialCard1.TabIndex = 0;
            // 
            // mtbPago
            // 
            this.mtbPago.AnimateReadOnly = false;
            this.mtbPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbPago.Depth = 0;
            this.mtbPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbPago.HideSelection = true;
            this.mtbPago.Hint = "Valor pago";
            this.mtbPago.LeadingIcon = null;
            this.mtbPago.Location = new System.Drawing.Point(224, 9);
            this.mtbPago.MaxLength = 32767;
            this.mtbPago.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbPago.Name = "mtbPago";
            this.mtbPago.PasswordChar = '\0';
            this.mtbPago.PrefixSuffixText = null;
            this.mtbPago.ReadOnly = true;
            this.mtbPago.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbPago.SelectedText = "";
            this.mtbPago.SelectionLength = 0;
            this.mtbPago.SelectionStart = 0;
            this.mtbPago.ShortcutsEnabled = true;
            this.mtbPago.Size = new System.Drawing.Size(180, 48);
            this.mtbPago.TabIndex = 2;
            this.mtbPago.TabStop = false;
            this.mtbPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbPago.TrailingIcon = null;
            this.mtbPago.UseSystemPasswordChar = false;
            // 
            // mtbDevido
            // 
            this.mtbDevido.AnimateReadOnly = false;
            this.mtbDevido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDevido.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDevido.Depth = 0;
            this.mtbDevido.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDevido.HideSelection = true;
            this.mtbDevido.Hint = "Valor compra";
            this.mtbDevido.LeadingIcon = null;
            this.mtbDevido.Location = new System.Drawing.Point(14, 9);
            this.mtbDevido.MaxLength = 32767;
            this.mtbDevido.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDevido.Name = "mtbDevido";
            this.mtbDevido.PasswordChar = '\0';
            this.mtbDevido.PrefixSuffixText = null;
            this.mtbDevido.ReadOnly = true;
            this.mtbDevido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDevido.SelectedText = "";
            this.mtbDevido.SelectionLength = 0;
            this.mtbDevido.SelectionStart = 0;
            this.mtbDevido.ShortcutsEnabled = true;
            this.mtbDevido.Size = new System.Drawing.Size(184, 48);
            this.mtbDevido.TabIndex = 1;
            this.mtbDevido.TabStop = false;
            this.mtbDevido.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDevido.TrailingIcon = null;
            this.mtbDevido.UseSystemPasswordChar = false;
            // 
            // mtbVoltarPagamento
            // 
            this.mtbVoltarPagamento.AutoSize = false;
            this.mtbVoltarPagamento.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbVoltarPagamento.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbVoltarPagamento.Depth = 0;
            this.mtbVoltarPagamento.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mtbVoltarPagamento.HighEmphasis = true;
            this.mtbVoltarPagamento.Icon = null;
            this.mtbVoltarPagamento.Location = new System.Drawing.Point(14, 65);
            this.mtbVoltarPagamento.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbVoltarPagamento.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbVoltarPagamento.Name = "mtbVoltarPagamento";
            this.mtbVoltarPagamento.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbVoltarPagamento.Size = new System.Drawing.Size(390, 29);
            this.mtbVoltarPagamento.TabIndex = 0;
            this.mtbVoltarPagamento.Text = "Continuar";
            this.mtbVoltarPagamento.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbVoltarPagamento.UseAccentColor = false;
            this.mtbVoltarPagamento.UseVisualStyleBackColor = true;
            this.mtbVoltarPagamento.Click += new System.EventHandler(this.mtbVoltarPagamento_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.mbtDinheiro, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mbtPix, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mbtDebito, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.mbtCredito, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.mbtConta, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.mtbDinheiro, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mtbPix, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mtbDebito, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.mtbCredito, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.mtbConta, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 108);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 369);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // mbtDinheiro
            // 
            this.mbtDinheiro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtDinheiro.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtDinheiro.Depth = 0;
            this.mbtDinheiro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbtDinheiro.HighEmphasis = true;
            this.mbtDinheiro.Icon = null;
            this.mbtDinheiro.Location = new System.Drawing.Point(4, 6);
            this.mbtDinheiro.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtDinheiro.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtDinheiro.Name = "mbtDinheiro";
            this.mbtDinheiro.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtDinheiro.Size = new System.Drawing.Size(159, 61);
            this.mbtDinheiro.TabIndex = 0;
            this.mbtDinheiro.Text = "Dinheiro";
            this.mbtDinheiro.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtDinheiro.UseAccentColor = false;
            this.mbtDinheiro.UseVisualStyleBackColor = true;
            this.mbtDinheiro.Click += new System.EventHandler(this.mbtDinheiro_Click);
            // 
            // mbtPix
            // 
            this.mbtPix.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtPix.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtPix.Depth = 0;
            this.mbtPix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbtPix.HighEmphasis = true;
            this.mbtPix.Icon = null;
            this.mbtPix.Location = new System.Drawing.Point(4, 79);
            this.mbtPix.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtPix.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtPix.Name = "mbtPix";
            this.mbtPix.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtPix.Size = new System.Drawing.Size(159, 61);
            this.mbtPix.TabIndex = 1;
            this.mbtPix.Text = "Pix";
            this.mbtPix.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtPix.UseAccentColor = false;
            this.mbtPix.UseVisualStyleBackColor = true;
            this.mbtPix.Click += new System.EventHandler(this.mbtPix_Click);
            // 
            // mbtDebito
            // 
            this.mbtDebito.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtDebito.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtDebito.Depth = 0;
            this.mbtDebito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbtDebito.HighEmphasis = true;
            this.mbtDebito.Icon = null;
            this.mbtDebito.Location = new System.Drawing.Point(4, 152);
            this.mbtDebito.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtDebito.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtDebito.Name = "mbtDebito";
            this.mbtDebito.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtDebito.Size = new System.Drawing.Size(159, 61);
            this.mbtDebito.TabIndex = 2;
            this.mbtDebito.Text = "Debito";
            this.mbtDebito.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtDebito.UseAccentColor = false;
            this.mbtDebito.UseVisualStyleBackColor = true;
            this.mbtDebito.Click += new System.EventHandler(this.mbtDebito_Click);
            // 
            // mbtCredito
            // 
            this.mbtCredito.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtCredito.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtCredito.Depth = 0;
            this.mbtCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbtCredito.HighEmphasis = true;
            this.mbtCredito.Icon = null;
            this.mbtCredito.Location = new System.Drawing.Point(4, 225);
            this.mbtCredito.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtCredito.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtCredito.Name = "mbtCredito";
            this.mbtCredito.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtCredito.Size = new System.Drawing.Size(159, 61);
            this.mbtCredito.TabIndex = 3;
            this.mbtCredito.Text = "Credito";
            this.mbtCredito.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtCredito.UseAccentColor = false;
            this.mbtCredito.UseVisualStyleBackColor = true;
            this.mbtCredito.Click += new System.EventHandler(this.mbtCredito_Click);
            // 
            // mbtConta
            // 
            this.mbtConta.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtConta.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtConta.Depth = 0;
            this.mbtConta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbtConta.HighEmphasis = true;
            this.mbtConta.Icon = null;
            this.mbtConta.Location = new System.Drawing.Point(4, 298);
            this.mbtConta.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtConta.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtConta.Name = "mbtConta";
            this.mbtConta.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtConta.Size = new System.Drawing.Size(159, 65);
            this.mbtConta.TabIndex = 4;
            this.mbtConta.Text = "Conta";
            this.mbtConta.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtConta.UseAccentColor = false;
            this.mbtConta.UseVisualStyleBackColor = true;
            this.mbtConta.Click += new System.EventHandler(this.mbtConta_Click);
            // 
            // mtbDinheiro
            // 
            this.mtbDinheiro.AnimateReadOnly = false;
            this.mtbDinheiro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDinheiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDinheiro.Depth = 0;
            this.mtbDinheiro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtbDinheiro.Enabled = false;
            this.mtbDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDinheiro.HideSelection = true;
            this.mtbDinheiro.Hint = "Dinheiro";
            this.mtbDinheiro.LeadingIcon = null;
            this.mtbDinheiro.Location = new System.Drawing.Point(170, 3);
            this.mtbDinheiro.MaxLength = 32767;
            this.mtbDinheiro.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDinheiro.Name = "mtbDinheiro";
            this.mtbDinheiro.PasswordChar = '\0';
            this.mtbDinheiro.PrefixSuffixText = null;
            this.mtbDinheiro.ReadOnly = false;
            this.mtbDinheiro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDinheiro.SelectedText = "";
            this.mtbDinheiro.SelectionLength = 0;
            this.mtbDinheiro.SelectionStart = 0;
            this.mtbDinheiro.ShortcutsEnabled = true;
            this.mtbDinheiro.ShowAssistiveText = true;
            this.mtbDinheiro.Size = new System.Drawing.Size(245, 64);
            this.mtbDinheiro.TabIndex = 5;
            this.mtbDinheiro.TabStop = false;
            this.mtbDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDinheiro.TrailingIcon = null;
            this.mtbDinheiro.UseSystemPasswordChar = false;
            this.mtbDinheiro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbDinheiro_KeyDown);
            this.mtbDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDinheiro_KeyPress);
            this.mtbDinheiro.TextChanged += new System.EventHandler(this.mtbDinheiro_TextChanged);
            // 
            // mtbPix
            // 
            this.mtbPix.AnimateReadOnly = false;
            this.mtbPix.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbPix.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbPix.Depth = 0;
            this.mtbPix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtbPix.Enabled = false;
            this.mtbPix.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbPix.HideSelection = true;
            this.mtbPix.Hint = "Pix";
            this.mtbPix.LeadingIcon = null;
            this.mtbPix.Location = new System.Drawing.Point(170, 76);
            this.mtbPix.MaxLength = 32767;
            this.mtbPix.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbPix.Name = "mtbPix";
            this.mtbPix.PasswordChar = '\0';
            this.mtbPix.PrefixSuffixText = null;
            this.mtbPix.ReadOnly = false;
            this.mtbPix.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbPix.SelectedText = "";
            this.mtbPix.SelectionLength = 0;
            this.mtbPix.SelectionStart = 0;
            this.mtbPix.ShortcutsEnabled = true;
            this.mtbPix.ShowAssistiveText = true;
            this.mtbPix.Size = new System.Drawing.Size(245, 64);
            this.mtbPix.TabIndex = 6;
            this.mtbPix.TabStop = false;
            this.mtbPix.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbPix.TrailingIcon = null;
            this.mtbPix.UseSystemPasswordChar = false;
            this.mtbPix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbPix_KeyPress);
            this.mtbPix.TextChanged += new System.EventHandler(this.mtbPix_TextChanged);
            // 
            // mtbDebito
            // 
            this.mtbDebito.AnimateReadOnly = false;
            this.mtbDebito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbDebito.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbDebito.Depth = 0;
            this.mtbDebito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtbDebito.Enabled = false;
            this.mtbDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbDebito.HideSelection = true;
            this.mtbDebito.Hint = "Debito";
            this.mtbDebito.LeadingIcon = null;
            this.mtbDebito.Location = new System.Drawing.Point(170, 149);
            this.mtbDebito.MaxLength = 32767;
            this.mtbDebito.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbDebito.Name = "mtbDebito";
            this.mtbDebito.PasswordChar = '\0';
            this.mtbDebito.PrefixSuffixText = null;
            this.mtbDebito.ReadOnly = false;
            this.mtbDebito.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbDebito.SelectedText = "";
            this.mtbDebito.SelectionLength = 0;
            this.mtbDebito.SelectionStart = 0;
            this.mtbDebito.ShortcutsEnabled = true;
            this.mtbDebito.ShowAssistiveText = true;
            this.mtbDebito.Size = new System.Drawing.Size(245, 64);
            this.mtbDebito.TabIndex = 7;
            this.mtbDebito.TabStop = false;
            this.mtbDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbDebito.TrailingIcon = null;
            this.mtbDebito.UseSystemPasswordChar = false;
            this.mtbDebito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbDebito_KeyPress);
            this.mtbDebito.TextChanged += new System.EventHandler(this.mtbDebito_TextChanged);
            // 
            // mtbCredito
            // 
            this.mtbCredito.AnimateReadOnly = false;
            this.mtbCredito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCredito.Depth = 0;
            this.mtbCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtbCredito.Enabled = false;
            this.mtbCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCredito.HideSelection = true;
            this.mtbCredito.Hint = "Credito";
            this.mtbCredito.LeadingIcon = null;
            this.mtbCredito.Location = new System.Drawing.Point(170, 222);
            this.mtbCredito.MaxLength = 32767;
            this.mtbCredito.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCredito.Name = "mtbCredito";
            this.mtbCredito.PasswordChar = '\0';
            this.mtbCredito.PrefixSuffixText = null;
            this.mtbCredito.ReadOnly = false;
            this.mtbCredito.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCredito.SelectedText = "";
            this.mtbCredito.SelectionLength = 0;
            this.mtbCredito.SelectionStart = 0;
            this.mtbCredito.ShortcutsEnabled = true;
            this.mtbCredito.ShowAssistiveText = true;
            this.mtbCredito.Size = new System.Drawing.Size(245, 64);
            this.mtbCredito.TabIndex = 8;
            this.mtbCredito.TabStop = false;
            this.mtbCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCredito.TrailingIcon = null;
            this.mtbCredito.UseSystemPasswordChar = false;
            this.mtbCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbCredito_KeyPress);
            this.mtbCredito.TextChanged += new System.EventHandler(this.mtbCredito_TextChanged);
            // 
            // mtbConta
            // 
            this.mtbConta.AnimateReadOnly = false;
            this.mtbConta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbConta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbConta.Depth = 0;
            this.mtbConta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtbConta.Enabled = false;
            this.mtbConta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbConta.HideSelection = true;
            this.mtbConta.Hint = "Conta";
            this.mtbConta.LeadingIcon = null;
            this.mtbConta.Location = new System.Drawing.Point(170, 295);
            this.mtbConta.MaxLength = 32767;
            this.mtbConta.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbConta.Name = "mtbConta";
            this.mtbConta.PasswordChar = '\0';
            this.mtbConta.PrefixSuffixText = null;
            this.mtbConta.ReadOnly = false;
            this.mtbConta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbConta.SelectedText = "";
            this.mtbConta.SelectionLength = 0;
            this.mtbConta.SelectionStart = 0;
            this.mtbConta.ShortcutsEnabled = true;
            this.mtbConta.ShowAssistiveText = true;
            this.mtbConta.Size = new System.Drawing.Size(245, 64);
            this.mtbConta.TabIndex = 9;
            this.mtbConta.TabStop = false;
            this.mtbConta.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbConta.TrailingIcon = null;
            this.mtbConta.UseSystemPasswordChar = false;
            this.mtbConta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbConta_KeyPress);
            this.mtbConta.TextChanged += new System.EventHandler(this.mtbConta_TextChanged);
            // 
            // frmMultiplosPagamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 477);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.materialCard1);
            this.Name = "frmMultiplosPagamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multiplos pagamento";
            this.Load += new System.EventHandler(this.frmMultiplosPagamentos_Load);
            this.materialCard1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton mbtDinheiro;
        private MaterialSkin.Controls.MaterialButton mbtPix;
        private MaterialSkin.Controls.MaterialButton mbtDebito;
        private MaterialSkin.Controls.MaterialButton mbtCredito;
        private MaterialSkin.Controls.MaterialButton mbtConta;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDinheiro;
        private MaterialSkin.Controls.MaterialTextBox2 mtbPix;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDebito;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCredito;
        private MaterialSkin.Controls.MaterialTextBox2 mtbConta;
        private MaterialSkin.Controls.MaterialTextBox2 mtbPago;
        private MaterialSkin.Controls.MaterialTextBox2 mtbDevido;
        private MaterialSkin.Controls.MaterialButton mtbVoltarPagamento;
    }
}