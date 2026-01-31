namespace Komercio.UI.Forms.ListaCompras
{
    partial class frmAdicionarItensListaDeCompras
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gblistaCompras = new System.Windows.Forms.GroupBox();
            this.mbtSalvar = new MaterialSkin.Controls.MaterialButton();
            this.dgProdutos = new System.Windows.Forms.DataGridView();
            this.mtbBuscarProduto = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbObs = new MaterialSkin.Controls.MaterialTextBox2();
            this.mbtNovoProd = new MaterialSkin.Controls.MaterialButton();
            this.btnAddLista = new MaterialSkin.Controls.MaterialButton();
            this.mtbQtd = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbCodBar = new MaterialSkin.Controls.MaterialTextBox2();
            this.mtbProduto = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnCarregaLista = new MaterialSkin.Controls.MaterialButton();
            this.mcbListaCompra = new MaterialSkin.Controls.MaterialComboBox();
            this.mtbNovaLista = new MaterialSkin.Controls.MaterialButton();
            this.dgvItens = new System.Windows.Forms.DataGridView();
            this.mtbRemover = new MaterialSkin.Controls.MaterialButton();
            this.btnCancelar = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.gblistaCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gblistaCompras, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvItens, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(953, 552);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gblistaCompras
            // 
            this.gblistaCompras.Controls.Add(this.btnCancelar);
            this.gblistaCompras.Controls.Add(this.mtbRemover);
            this.gblistaCompras.Controls.Add(this.mbtSalvar);
            this.gblistaCompras.Controls.Add(this.dgProdutos);
            this.gblistaCompras.Controls.Add(this.mtbBuscarProduto);
            this.gblistaCompras.Controls.Add(this.mtbObs);
            this.gblistaCompras.Controls.Add(this.mbtNovoProd);
            this.gblistaCompras.Controls.Add(this.btnAddLista);
            this.gblistaCompras.Controls.Add(this.mtbQtd);
            this.gblistaCompras.Controls.Add(this.mtbCodBar);
            this.gblistaCompras.Controls.Add(this.mtbProduto);
            this.gblistaCompras.Controls.Add(this.btnCarregaLista);
            this.gblistaCompras.Controls.Add(this.mcbListaCompra);
            this.gblistaCompras.Controls.Add(this.mtbNovaLista);
            this.gblistaCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gblistaCompras.Location = new System.Drawing.Point(3, 3);
            this.gblistaCompras.Name = "gblistaCompras";
            this.gblistaCompras.Size = new System.Drawing.Size(947, 224);
            this.gblistaCompras.TabIndex = 0;
            this.gblistaCompras.TabStop = false;
            this.gblistaCompras.Enter += new System.EventHandler(this.gblistaCompras_Enter);
            // 
            // mbtSalvar
            // 
            this.mbtSalvar.AutoSize = false;
            this.mbtSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtSalvar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtSalvar.Depth = 0;
            this.mbtSalvar.Enabled = false;
            this.mbtSalvar.HighEmphasis = true;
            this.mbtSalvar.Icon = null;
            this.mbtSalvar.Location = new System.Drawing.Point(432, 170);
            this.mbtSalvar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtSalvar.Name = "mbtSalvar";
            this.mbtSalvar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtSalvar.Size = new System.Drawing.Size(82, 40);
            this.mbtSalvar.TabIndex = 12;
            this.mbtSalvar.Text = "Salvar";
            this.mbtSalvar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtSalvar.UseAccentColor = true;
            this.mbtSalvar.UseVisualStyleBackColor = true;
            this.mbtSalvar.Click += new System.EventHandler(this.mbtSalvar_Click);
            // 
            // dgProdutos
            // 
            this.dgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProdutos.Enabled = false;
            this.dgProdutos.Location = new System.Drawing.Point(689, 71);
            this.dgProdutos.Name = "dgProdutos";
            this.dgProdutos.Size = new System.Drawing.Size(250, 139);
            this.dgProdutos.TabIndex = 11;
            this.dgProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProdutos_CellDoubleClick);
            // 
            // mtbBuscarProduto
            // 
            this.mtbBuscarProduto.AnimateReadOnly = false;
            this.mtbBuscarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbBuscarProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbBuscarProduto.Depth = 0;
            this.mtbBuscarProduto.Enabled = false;
            this.mtbBuscarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbBuscarProduto.HideSelection = true;
            this.mtbBuscarProduto.Hint = "Buscar produto";
            this.mtbBuscarProduto.LeadingIcon = null;
            this.mtbBuscarProduto.Location = new System.Drawing.Point(689, 17);
            this.mtbBuscarProduto.MaxLength = 32767;
            this.mtbBuscarProduto.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbBuscarProduto.Name = "mtbBuscarProduto";
            this.mtbBuscarProduto.PasswordChar = '\0';
            this.mtbBuscarProduto.PrefixSuffixText = null;
            this.mtbBuscarProduto.ReadOnly = false;
            this.mtbBuscarProduto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbBuscarProduto.SelectedText = "";
            this.mtbBuscarProduto.SelectionLength = 0;
            this.mtbBuscarProduto.SelectionStart = 0;
            this.mtbBuscarProduto.ShortcutsEnabled = true;
            this.mtbBuscarProduto.Size = new System.Drawing.Size(250, 48);
            this.mtbBuscarProduto.TabIndex = 10;
            this.mtbBuscarProduto.TabStop = false;
            this.mtbBuscarProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbBuscarProduto.TrailingIcon = null;
            this.mtbBuscarProduto.UseSystemPasswordChar = false;
            this.mtbBuscarProduto.TextChanged += new System.EventHandler(this.mtbBuscarProduto_TextChanged);
            // 
            // mtbObs
            // 
            this.mtbObs.AnimateReadOnly = false;
            this.mtbObs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbObs.Depth = 0;
            this.mtbObs.Enabled = false;
            this.mtbObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbObs.HelperText = "Por exemplo: encomenda para Aline";
            this.mtbObs.HideSelection = true;
            this.mtbObs.Hint = "Obs";
            this.mtbObs.LeadingIcon = null;
            this.mtbObs.Location = new System.Drawing.Point(10, 102);
            this.mtbObs.MaxLength = 32767;
            this.mtbObs.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbObs.Name = "mtbObs";
            this.mtbObs.PasswordChar = '\0';
            this.mtbObs.PrefixSuffixText = null;
            this.mtbObs.ReadOnly = false;
            this.mtbObs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbObs.SelectedText = "";
            this.mtbObs.SelectionLength = 0;
            this.mtbObs.SelectionStart = 0;
            this.mtbObs.ShortcutsEnabled = true;
            this.mtbObs.ShowAssistiveText = true;
            this.mtbObs.Size = new System.Drawing.Size(504, 64);
            this.mtbObs.TabIndex = 9;
            this.mtbObs.TabStop = false;
            this.mtbObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbObs.TrailingIcon = null;
            this.mtbObs.UseSystemPasswordChar = false;
            // 
            // mbtNovoProd
            // 
            this.mbtNovoProd.AutoSize = false;
            this.mbtNovoProd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mbtNovoProd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mbtNovoProd.Depth = 0;
            this.mbtNovoProd.Enabled = false;
            this.mbtNovoProd.HighEmphasis = true;
            this.mbtNovoProd.Icon = null;
            this.mbtNovoProd.Location = new System.Drawing.Point(524, 102);
            this.mbtNovoProd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mbtNovoProd.MouseState = MaterialSkin.MouseState.HOVER;
            this.mbtNovoProd.Name = "mbtNovoProd";
            this.mbtNovoProd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mbtNovoProd.Size = new System.Drawing.Size(140, 48);
            this.mbtNovoProd.TabIndex = 8;
            this.mbtNovoProd.Text = "Novo produto";
            this.mbtNovoProd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mbtNovoProd.UseAccentColor = false;
            this.mbtNovoProd.UseVisualStyleBackColor = true;
            this.mbtNovoProd.Click += new System.EventHandler(this.mbtNovoProd_Click);
            // 
            // btnAddLista
            // 
            this.btnAddLista.AutoSize = false;
            this.btnAddLista.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddLista.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddLista.Depth = 0;
            this.btnAddLista.Enabled = false;
            this.btnAddLista.HighEmphasis = true;
            this.btnAddLista.Icon = null;
            this.btnAddLista.Location = new System.Drawing.Point(10, 170);
            this.btnAddLista.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddLista.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddLista.Name = "btnAddLista";
            this.btnAddLista.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddLista.Size = new System.Drawing.Size(271, 40);
            this.btnAddLista.TabIndex = 6;
            this.btnAddLista.Text = "Adicionar na lista de compra";
            this.btnAddLista.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddLista.UseAccentColor = false;
            this.btnAddLista.UseVisualStyleBackColor = true;
            this.btnAddLista.Click += new System.EventHandler(this.btnAddLista_Click);
            // 
            // mtbQtd
            // 
            this.mtbQtd.AnimateReadOnly = false;
            this.mtbQtd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbQtd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbQtd.Depth = 0;
            this.mtbQtd.Enabled = false;
            this.mtbQtd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbQtd.HideSelection = true;
            this.mtbQtd.Hint = "Qtd";
            this.mtbQtd.LeadingIcon = null;
            this.mtbQtd.Location = new System.Drawing.Point(446, 60);
            this.mtbQtd.MaxLength = 32767;
            this.mtbQtd.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbQtd.Name = "mtbQtd";
            this.mtbQtd.PasswordChar = '\0';
            this.mtbQtd.PrefixSuffixText = null;
            this.mtbQtd.ReadOnly = false;
            this.mtbQtd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbQtd.SelectedText = "";
            this.mtbQtd.SelectionLength = 0;
            this.mtbQtd.SelectionStart = 0;
            this.mtbQtd.ShortcutsEnabled = true;
            this.mtbQtd.Size = new System.Drawing.Size(68, 36);
            this.mtbQtd.TabIndex = 5;
            this.mtbQtd.TabStop = false;
            this.mtbQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbQtd.TrailingIcon = null;
            this.mtbQtd.UseSystemPasswordChar = false;
            this.mtbQtd.UseTallSize = false;
            // 
            // mtbCodBar
            // 
            this.mtbCodBar.AnimateReadOnly = false;
            this.mtbCodBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbCodBar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbCodBar.Depth = 0;
            this.mtbCodBar.Enabled = false;
            this.mtbCodBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbCodBar.HideSelection = true;
            this.mtbCodBar.Hint = "Cod. de barras";
            this.mtbCodBar.LeadingIcon = null;
            this.mtbCodBar.Location = new System.Drawing.Point(287, 60);
            this.mtbCodBar.MaxLength = 32767;
            this.mtbCodBar.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbCodBar.Name = "mtbCodBar";
            this.mtbCodBar.PasswordChar = '\0';
            this.mtbCodBar.PrefixSuffixText = null;
            this.mtbCodBar.ReadOnly = true;
            this.mtbCodBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbCodBar.SelectedText = "";
            this.mtbCodBar.SelectionLength = 0;
            this.mtbCodBar.SelectionStart = 0;
            this.mtbCodBar.ShortcutsEnabled = true;
            this.mtbCodBar.Size = new System.Drawing.Size(153, 36);
            this.mtbCodBar.TabIndex = 4;
            this.mtbCodBar.TabStop = false;
            this.mtbCodBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbCodBar.TrailingIcon = null;
            this.mtbCodBar.UseSystemPasswordChar = false;
            this.mtbCodBar.UseTallSize = false;
            // 
            // mtbProduto
            // 
            this.mtbProduto.AnimateReadOnly = false;
            this.mtbProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mtbProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtbProduto.Depth = 0;
            this.mtbProduto.Enabled = false;
            this.mtbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mtbProduto.HideSelection = true;
            this.mtbProduto.Hint = "Produto";
            this.mtbProduto.LeadingIcon = null;
            this.mtbProduto.Location = new System.Drawing.Point(9, 60);
            this.mtbProduto.MaxLength = 32767;
            this.mtbProduto.MouseState = MaterialSkin.MouseState.OUT;
            this.mtbProduto.Name = "mtbProduto";
            this.mtbProduto.PasswordChar = '\0';
            this.mtbProduto.PrefixSuffixText = null;
            this.mtbProduto.ReadOnly = true;
            this.mtbProduto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mtbProduto.SelectedText = "";
            this.mtbProduto.SelectionLength = 0;
            this.mtbProduto.SelectionStart = 0;
            this.mtbProduto.ShortcutsEnabled = true;
            this.mtbProduto.Size = new System.Drawing.Size(272, 36);
            this.mtbProduto.TabIndex = 3;
            this.mtbProduto.TabStop = false;
            this.mtbProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mtbProduto.TrailingIcon = null;
            this.mtbProduto.UseSystemPasswordChar = false;
            this.mtbProduto.UseTallSize = false;
            this.mtbProduto.TextChanged += new System.EventHandler(this.mtbProduto_TextChanged);
            // 
            // btnCarregaLista
            // 
            this.btnCarregaLista.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCarregaLista.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCarregaLista.Depth = 0;
            this.btnCarregaLista.Enabled = false;
            this.btnCarregaLista.HighEmphasis = true;
            this.btnCarregaLista.Icon = null;
            this.btnCarregaLista.Location = new System.Drawing.Point(524, 17);
            this.btnCarregaLista.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCarregaLista.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCarregaLista.Name = "btnCarregaLista";
            this.btnCarregaLista.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCarregaLista.Size = new System.Drawing.Size(140, 36);
            this.btnCarregaLista.TabIndex = 2;
            this.btnCarregaLista.Text = "Carregar Lista";
            this.btnCarregaLista.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCarregaLista.UseAccentColor = false;
            this.btnCarregaLista.UseVisualStyleBackColor = true;
            this.btnCarregaLista.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // mcbListaCompra
            // 
            this.mcbListaCompra.AutoResize = false;
            this.mcbListaCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mcbListaCompra.Depth = 0;
            this.mcbListaCompra.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.mcbListaCompra.DropDownHeight = 118;
            this.mcbListaCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mcbListaCompra.DropDownWidth = 121;
            this.mcbListaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mcbListaCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mcbListaCompra.FormattingEnabled = true;
            this.mcbListaCompra.Hint = "Selecione a lista de compra";
            this.mcbListaCompra.IntegralHeight = false;
            this.mcbListaCompra.ItemHeight = 29;
            this.mcbListaCompra.Location = new System.Drawing.Point(9, 17);
            this.mcbListaCompra.MaxDropDownItems = 4;
            this.mcbListaCompra.MouseState = MaterialSkin.MouseState.OUT;
            this.mcbListaCompra.Name = "mcbListaCompra";
            this.mcbListaCompra.Size = new System.Drawing.Size(505, 35);
            this.mcbListaCompra.StartIndex = 0;
            this.mcbListaCompra.TabIndex = 1;
            this.mcbListaCompra.UseTallSize = false;
            this.mcbListaCompra.SelectedIndexChanged += new System.EventHandler(this.mcbListaCompra_SelectedIndexChanged);
            this.mcbListaCompra.TabIndexChanged += new System.EventHandler(this.mcbListaCompra_TabIndexChanged);
            // 
            // mtbNovaLista
            // 
            this.mtbNovaLista.AutoSize = false;
            this.mtbNovaLista.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbNovaLista.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbNovaLista.Depth = 0;
            this.mtbNovaLista.HighEmphasis = true;
            this.mtbNovaLista.Icon = null;
            this.mtbNovaLista.Location = new System.Drawing.Point(524, 60);
            this.mtbNovaLista.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbNovaLista.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbNovaLista.Name = "mtbNovaLista";
            this.mtbNovaLista.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbNovaLista.Size = new System.Drawing.Size(140, 35);
            this.mtbNovaLista.TabIndex = 0;
            this.mtbNovaLista.Text = "Nova lista";
            this.mtbNovaLista.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbNovaLista.UseAccentColor = false;
            this.mtbNovaLista.UseVisualStyleBackColor = true;
            this.mtbNovaLista.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // dgvItens
            // 
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItens.Location = new System.Drawing.Point(3, 233);
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.Size = new System.Drawing.Size(947, 316);
            this.dgvItens.TabIndex = 1;
            // 
            // mtbRemover
            // 
            this.mtbRemover.AutoSize = false;
            this.mtbRemover.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mtbRemover.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.mtbRemover.Depth = 0;
            this.mtbRemover.Enabled = false;
            this.mtbRemover.HighEmphasis = true;
            this.mtbRemover.Icon = null;
            this.mtbRemover.Location = new System.Drawing.Point(289, 170);
            this.mtbRemover.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mtbRemover.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtbRemover.Name = "mtbRemover";
            this.mtbRemover.NoAccentTextColor = System.Drawing.Color.Empty;
            this.mtbRemover.Size = new System.Drawing.Size(135, 40);
            this.mtbRemover.TabIndex = 13;
            this.mtbRemover.Text = "Remover item";
            this.mtbRemover.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.mtbRemover.UseAccentColor = false;
            this.mtbRemover.UseVisualStyleBackColor = true;
            this.mtbRemover.Click += new System.EventHandler(this.mtbRemover_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = false;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancelar.Depth = 0;
            this.btnCancelar.HighEmphasis = true;
            this.btnCancelar.Icon = null;
            this.btnCancelar.Location = new System.Drawing.Point(524, 170);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancelar.Size = new System.Drawing.Size(140, 40);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancelar.UseAccentColor = false;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmAdicionarItensListaDeCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 552);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAdicionarItensListaDeCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdicionarItensListaDeCompras";
            this.Load += new System.EventHandler(this.frmAdicionarItensListaDeCompras_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gblistaCompras.ResumeLayout(false);
            this.gblistaCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gblistaCompras;
        private MaterialSkin.Controls.MaterialComboBox mcbListaCompra;
        private MaterialSkin.Controls.MaterialButton mtbNovaLista;
        private MaterialSkin.Controls.MaterialButton btnCarregaLista;
        private System.Windows.Forms.DataGridView dgvItens;
        private MaterialSkin.Controls.MaterialButton btnAddLista;
        private MaterialSkin.Controls.MaterialTextBox2 mtbQtd;
        private MaterialSkin.Controls.MaterialTextBox2 mtbCodBar;
        private MaterialSkin.Controls.MaterialTextBox2 mtbProduto;
        private MaterialSkin.Controls.MaterialButton mbtNovoProd;
        private System.Windows.Forms.DataGridView dgProdutos;
        private MaterialSkin.Controls.MaterialTextBox2 mtbBuscarProduto;
        private MaterialSkin.Controls.MaterialTextBox2 mtbObs;
        private MaterialSkin.Controls.MaterialButton mbtSalvar;
        private MaterialSkin.Controls.MaterialButton mtbRemover;
        private MaterialSkin.Controls.MaterialButton btnCancelar;
    }
}