namespace projeto_pratica.pages.cadastro
{
    partial class frmCadastroNotaEntrada
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtCodForn = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.btnPesquisarForn = new System.Windows.Forms.Button();
            this.dtpDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.dtpDataChegada = new System.Windows.Forms.DateTimePicker();
            this.lblEmissao = new System.Windows.Forms.Label();
            this.lblChegada = new System.Windows.Forms.Label();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.btnPesquisarProd = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.listVProdutos = new System.Windows.Forms.ListView();
            this.clmCod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmProd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUnidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmQtd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPrecoUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSeguro = new System.Windows.Forms.TextBox();
            this.lblSeguro = new System.Windows.Forms.Label();
            this.txtValFrete = new System.Windows.Forms.TextBox();
            this.lblValFrete = new System.Windows.Forms.Label();
            this.txtValTotal = new System.Windows.Forms.TextBox();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.txtDespesas = new System.Windows.Forms.TextBox();
            this.lblDespesas = new System.Windows.Forms.Label();
            this.listVCondPag = new System.Windows.Forms.ListView();
            this.clmParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPrazo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPorcent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFormPag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtCodCondPag = new System.Windows.Forms.TextBox();
            this.lblCondPag = new System.Windows.Forms.Label();
            this.txtCondPag = new System.Windows.Forms.TextBox();
            this.btnPesquisarCondPag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCod
            // 
            this.lblCod.Size = new System.Drawing.Size(57, 13);
            this.lblCod.Text = "MODELO*";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(925, 769);
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.Location = new System.Drawing.Point(197, 759);
            // 
            // lblDataCriacao
            // 
            this.lblDataCriacao.Location = new System.Drawing.Point(54, 759);
            // 
            // lblUserAlt
            // 
            this.lblUserAlt.Location = new System.Drawing.Point(349, 759);
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Location = new System.Drawing.Point(56, 774);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Location = new System.Drawing.Point(199, 774);
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Location = new System.Drawing.Point(351, 774);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(1048, 38);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1026, 769);
            // 
            // txtCodigo
            // 
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Size = new System.Drawing.Size(112, 20);
            this.txtCodigo.Text = "";
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(144, 22);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(43, 13);
            this.lblSerie.TabIndex = 2;
            this.lblSerie.Text = "SERIE*";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(147, 37);
            this.txtSerie.MaxLength = 255;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(83, 20);
            this.txtSerie.TabIndex = 2;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(238, 21);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(59, 13);
            this.lblNumero.TabIndex = 32;
            this.lblNumero.Text = "NUMERO*";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(241, 37);
            this.txtNum.MaxLength = 255;
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 20);
            this.txtNum.TabIndex = 35;
            // 
            // txtCodForn
            // 
            this.txtCodForn.Location = new System.Drawing.Point(393, 36);
            this.txtCodForn.MaxLength = 255;
            this.txtCodForn.Name = "txtCodForn";
            this.txtCodForn.ReadOnly = true;
            this.txtCodForn.Size = new System.Drawing.Size(41, 20);
            this.txtCodForn.TabIndex = 36;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(449, 36);
            this.txtFornecedor.MaxLength = 255;
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(213, 20);
            this.txtFornecedor.TabIndex = 38;
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(390, 20);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(86, 13);
            this.lblFornecedor.TabIndex = 37;
            this.lblFornecedor.Text = "FORNECEDOR*";
            // 
            // btnPesquisarForn
            // 
            this.btnPesquisarForn.Location = new System.Drawing.Point(668, 34);
            this.btnPesquisarForn.Name = "btnPesquisarForn";
            this.btnPesquisarForn.Size = new System.Drawing.Size(73, 23);
            this.btnPesquisarForn.TabIndex = 39;
            this.btnPesquisarForn.Text = "Pesquisar";
            this.btnPesquisarForn.UseVisualStyleBackColor = true;
            this.btnPesquisarForn.Click += new System.EventHandler(this.btnPesquisarForn_Click);
            // 
            // dtpDataEmissao
            // 
            this.dtpDataEmissao.Checked = false;
            this.dtpDataEmissao.CustomFormat = "";
            this.dtpDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmissao.Location = new System.Drawing.Point(789, 34);
            this.dtpDataEmissao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataEmissao.MaxDate = new System.DateTime(2999, 12, 30, 0, 0, 0, 0);
            this.dtpDataEmissao.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataEmissao.Name = "dtpDataEmissao";
            this.dtpDataEmissao.Size = new System.Drawing.Size(95, 20);
            this.dtpDataEmissao.TabIndex = 40;
            this.dtpDataEmissao.Value = new System.DateTime(2025, 7, 1, 0, 0, 0, 0);
            // 
            // dtpDataChegada
            // 
            this.dtpDataChegada.Checked = false;
            this.dtpDataChegada.CustomFormat = "";
            this.dtpDataChegada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataChegada.Location = new System.Drawing.Point(925, 34);
            this.dtpDataChegada.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataChegada.MaxDate = new System.DateTime(2999, 12, 30, 0, 0, 0, 0);
            this.dtpDataChegada.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataChegada.Name = "dtpDataChegada";
            this.dtpDataChegada.Size = new System.Drawing.Size(95, 20);
            this.dtpDataChegada.TabIndex = 41;
            this.dtpDataChegada.Value = new System.DateTime(2025, 7, 1, 0, 0, 0, 0);
            // 
            // lblEmissao
            // 
            this.lblEmissao.AutoSize = true;
            this.lblEmissao.Location = new System.Drawing.Point(786, 20);
            this.lblEmissao.Name = "lblEmissao";
            this.lblEmissao.Size = new System.Drawing.Size(91, 13);
            this.lblEmissao.TabIndex = 42;
            this.lblEmissao.Text = "DATA EMISSÃO*";
            // 
            // lblChegada
            // 
            this.lblChegada.AutoSize = true;
            this.lblChegada.Location = new System.Drawing.Point(922, 19);
            this.lblChegada.Name = "lblChegada";
            this.lblChegada.Size = new System.Drawing.Size(95, 13);
            this.lblChegada.TabIndex = 43;
            this.lblChegada.Text = "DATA CHEGADA*";
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(19, 104);
            this.txtCodProd.MaxLength = 255;
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.ReadOnly = true;
            this.txtCodProd.Size = new System.Drawing.Size(41, 20);
            this.txtCodProd.TabIndex = 44;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(16, 89);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(61, 13);
            this.lblProduto.TabIndex = 45;
            this.lblProduto.Text = "PRODUTO";
            // 
            // txtQtd
            // 
            this.txtQtd.Location = new System.Drawing.Point(351, 104);
            this.txtQtd.MaxLength = 255;
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(125, 20);
            this.txtQtd.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "QUANTIDADE";
            // 
            // txtValUnit
            // 
            this.txtValUnit.Location = new System.Drawing.Point(498, 104);
            this.txtValUnit.MaxLength = 255;
            this.txtValUnit.Name = "txtValUnit";
            this.txtValUnit.Size = new System.Drawing.Size(122, 20);
            this.txtValUnit.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "VALOR UNITARIO";
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(66, 104);
            this.txtProduto.MaxLength = 255;
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ReadOnly = true;
            this.txtProduto.Size = new System.Drawing.Size(181, 20);
            this.txtProduto.TabIndex = 52;
            // 
            // btnPesquisarProd
            // 
            this.btnPesquisarProd.Location = new System.Drawing.Point(255, 102);
            this.btnPesquisarProd.Name = "btnPesquisarProd";
            this.btnPesquisarProd.Size = new System.Drawing.Size(73, 23);
            this.btnPesquisarProd.TabIndex = 53;
            this.btnPesquisarProd.Text = "Pesquisar";
            this.btnPesquisarProd.UseVisualStyleBackColor = true;
            this.btnPesquisarProd.Click += new System.EventHandler(this.btnPesquisarProd_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(641, 101);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(73, 23);
            this.btnAdicionar.TabIndex = 54;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(732, 101);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(73, 23);
            this.btnAlterar.TabIndex = 55;
            this.btnAlterar.Text = "Salvar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(830, 102);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(73, 23);
            this.btnExcluir.TabIndex = 56;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(925, 102);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 23);
            this.btnCancelar.TabIndex = 57;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // listVProdutos
            // 
            this.listVProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmCod,
            this.clmProd,
            this.clmUnidade,
            this.clmQtd,
            this.clmPrecoUnit,
            this.clmTotal});
            this.listVProdutos.FullRowSelect = true;
            this.listVProdutos.GridLines = true;
            this.listVProdutos.HideSelection = false;
            this.listVProdutos.Location = new System.Drawing.Point(19, 147);
            this.listVProdutos.Name = "listVProdutos";
            this.listVProdutos.Size = new System.Drawing.Size(1047, 273);
            this.listVProdutos.TabIndex = 58;
            this.listVProdutos.UseCompatibleStateImageBehavior = false;
            this.listVProdutos.View = System.Windows.Forms.View.Details;
            this.listVProdutos.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listVProdutos_ItemSelectionChanged);
            // 
            // clmCod
            // 
            this.clmCod.Text = "CODIGO";
            this.clmCod.Width = 80;
            // 
            // clmProd
            // 
            this.clmProd.Text = "PRODUTO";
            this.clmProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmProd.Width = 240;
            // 
            // clmUnidade
            // 
            this.clmUnidade.Text = "UNIDADE";
            this.clmUnidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmUnidade.Width = 80;
            // 
            // clmQtd
            // 
            this.clmQtd.Text = "QUANTIDADE";
            this.clmQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmQtd.Width = 120;
            // 
            // clmPrecoUnit
            // 
            this.clmPrecoUnit.Text = "PREÇO UNITARIO";
            this.clmPrecoUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmPrecoUnit.Width = 120;
            // 
            // clmTotal
            // 
            this.clmTotal.Text = "TOTAL";
            this.clmTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmTotal.Width = 80;
            // 
            // txtSeguro
            // 
            this.txtSeguro.Location = new System.Drawing.Point(166, 463);
            this.txtSeguro.MaxLength = 255;
            this.txtSeguro.Name = "txtSeguro";
            this.txtSeguro.Size = new System.Drawing.Size(122, 20);
            this.txtSeguro.TabIndex = 61;
            this.txtSeguro.TextChanged += new System.EventHandler(this.txtValoresRodape_Leave);
            // 
            // lblSeguro
            // 
            this.lblSeguro.AutoSize = true;
            this.lblSeguro.Location = new System.Drawing.Point(163, 448);
            this.lblSeguro.Name = "lblSeguro";
            this.lblSeguro.Size = new System.Drawing.Size(53, 13);
            this.lblSeguro.TabIndex = 62;
            this.lblSeguro.Text = "SEGURO";
            // 
            // txtValFrete
            // 
            this.txtValFrete.Location = new System.Drawing.Point(19, 463);
            this.txtValFrete.MaxLength = 255;
            this.txtValFrete.Name = "txtValFrete";
            this.txtValFrete.Size = new System.Drawing.Size(125, 20);
            this.txtValFrete.TabIndex = 59;
            this.txtValFrete.TextChanged += new System.EventHandler(this.txtValoresRodape_Leave);
            // 
            // lblValFrete
            // 
            this.lblValFrete.AutoSize = true;
            this.lblValFrete.Location = new System.Drawing.Point(16, 448);
            this.lblValFrete.Name = "lblValFrete";
            this.lblValFrete.Size = new System.Drawing.Size(81, 13);
            this.lblValFrete.TabIndex = 60;
            this.lblValFrete.Text = "VALOR FRETE";
            // 
            // txtValTotal
            // 
            this.txtValTotal.Location = new System.Drawing.Point(456, 463);
            this.txtValTotal.MaxLength = 255;
            this.txtValTotal.Name = "txtValTotal";
            this.txtValTotal.ReadOnly = true;
            this.txtValTotal.Size = new System.Drawing.Size(122, 20);
            this.txtValTotal.TabIndex = 65;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(453, 448);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(81, 13);
            this.lblValorTotal.TabIndex = 66;
            this.lblValorTotal.Text = "VALOR TOTAL";
            // 
            // txtDespesas
            // 
            this.txtDespesas.Location = new System.Drawing.Point(309, 463);
            this.txtDespesas.MaxLength = 255;
            this.txtDespesas.Name = "txtDespesas";
            this.txtDespesas.Size = new System.Drawing.Size(125, 20);
            this.txtDespesas.TabIndex = 63;
            this.txtDespesas.TextChanged += new System.EventHandler(this.txtValoresRodape_Leave);
            // 
            // lblDespesas
            // 
            this.lblDespesas.AutoSize = true;
            this.lblDespesas.Location = new System.Drawing.Point(306, 448);
            this.lblDespesas.Name = "lblDespesas";
            this.lblDespesas.Size = new System.Drawing.Size(64, 13);
            this.lblDespesas.TabIndex = 64;
            this.lblDespesas.Text = "DESPESAS";
            // 
            // listVCondPag
            // 
            this.listVCondPag.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmParcela,
            this.clmPrazo,
            this.clmPorcent,
            this.clmFormPag});
            this.listVCondPag.FullRowSelect = true;
            this.listVCondPag.GridLines = true;
            this.listVCondPag.HideSelection = false;
            this.listVCondPag.Location = new System.Drawing.Point(12, 582);
            this.listVCondPag.Name = "listVCondPag";
            this.listVCondPag.Size = new System.Drawing.Size(1054, 134);
            this.listVCondPag.TabIndex = 67;
            this.listVCondPag.UseCompatibleStateImageBehavior = false;
            this.listVCondPag.View = System.Windows.Forms.View.Details;
            // 
            // clmParcela
            // 
            this.clmParcela.Text = "PARCELA";
            this.clmParcela.Width = 100;
            // 
            // clmPrazo
            // 
            this.clmPrazo.Text = "PRAZO DIAS";
            this.clmPrazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmPrazo.Width = 240;
            // 
            // clmPorcent
            // 
            this.clmPorcent.Text = "PORCENTAGEM";
            this.clmPorcent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmPorcent.Width = 100;
            // 
            // clmFormPag
            // 
            this.clmFormPag.Text = "FORMA DE PAGAMENTO";
            this.clmFormPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmFormPag.Width = 159;
            // 
            // txtCodCondPag
            // 
            this.txtCodCondPag.Location = new System.Drawing.Point(19, 555);
            this.txtCodCondPag.MaxLength = 255;
            this.txtCodCondPag.Name = "txtCodCondPag";
            this.txtCodCondPag.ReadOnly = true;
            this.txtCodCondPag.Size = new System.Drawing.Size(58, 20);
            this.txtCodCondPag.TabIndex = 68;
            // 
            // lblCondPag
            // 
            this.lblCondPag.AutoSize = true;
            this.lblCondPag.Location = new System.Drawing.Point(16, 540);
            this.lblCondPag.Name = "lblCondPag";
            this.lblCondPag.Size = new System.Drawing.Size(134, 13);
            this.lblCondPag.TabIndex = 69;
            this.lblCondPag.Text = "CONDIÇÃO PAGAMENTO";
            // 
            // txtCondPag
            // 
            this.txtCondPag.Location = new System.Drawing.Point(94, 555);
            this.txtCondPag.MaxLength = 255;
            this.txtCondPag.Name = "txtCondPag";
            this.txtCondPag.ReadOnly = true;
            this.txtCondPag.Size = new System.Drawing.Size(178, 20);
            this.txtCondPag.TabIndex = 70;
            // 
            // btnPesquisarCondPag
            // 
            this.btnPesquisarCondPag.Location = new System.Drawing.Point(278, 553);
            this.btnPesquisarCondPag.Name = "btnPesquisarCondPag";
            this.btnPesquisarCondPag.Size = new System.Drawing.Size(73, 23);
            this.btnPesquisarCondPag.TabIndex = 71;
            this.btnPesquisarCondPag.Text = "Pesquisar";
            this.btnPesquisarCondPag.UseVisualStyleBackColor = true;
            this.btnPesquisarCondPag.Click += new System.EventHandler(this.btnPesquisarCondPag_Click);
            // 
            // frmCadastroNotaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1125, 845);
            this.Controls.Add(this.btnPesquisarCondPag);
            this.Controls.Add(this.txtCondPag);
            this.Controls.Add(this.txtCodCondPag);
            this.Controls.Add(this.lblCondPag);
            this.Controls.Add(this.listVCondPag);
            this.Controls.Add(this.txtValTotal);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.txtDespesas);
            this.Controls.Add(this.lblDespesas);
            this.Controls.Add(this.txtSeguro);
            this.Controls.Add(this.lblSeguro);
            this.Controls.Add(this.txtValFrete);
            this.Controls.Add(this.lblValFrete);
            this.Controls.Add(this.listVProdutos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnPesquisarProd);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.txtValUnit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQtd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodProd);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.lblChegada);
            this.Controls.Add(this.lblEmissao);
            this.Controls.Add(this.dtpDataChegada);
            this.Controls.Add(this.dtpDataEmissao);
            this.Controls.Add(this.btnPesquisarForn);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.txtCodForn);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblSerie);
            this.Name = "frmCadastroNotaEntrada";
            this.Controls.SetChildIndex(this.lblSerie, 0);
            this.Controls.SetChildIndex(this.txtSerie, 0);
            this.Controls.SetChildIndex(this.lblNumero, 0);
            this.Controls.SetChildIndex(this.txtNum, 0);
            this.Controls.SetChildIndex(this.txtCodForn, 0);
            this.Controls.SetChildIndex(this.lblFornecedor, 0);
            this.Controls.SetChildIndex(this.txtFornecedor, 0);
            this.Controls.SetChildIndex(this.btnPesquisarForn, 0);
            this.Controls.SetChildIndex(this.dtpDataEmissao, 0);
            this.Controls.SetChildIndex(this.dtpDataChegada, 0);
            this.Controls.SetChildIndex(this.lblEmissao, 0);
            this.Controls.SetChildIndex(this.lblChegada, 0);
            this.Controls.SetChildIndex(this.lblProduto, 0);
            this.Controls.SetChildIndex(this.txtCodProd, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtQtd, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtValUnit, 0);
            this.Controls.SetChildIndex(this.txtProduto, 0);
            this.Controls.SetChildIndex(this.btnPesquisarProd, 0);
            this.Controls.SetChildIndex(this.btnAdicionar, 0);
            this.Controls.SetChildIndex(this.btnAlterar, 0);
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.listVProdutos, 0);
            this.Controls.SetChildIndex(this.lblValFrete, 0);
            this.Controls.SetChildIndex(this.txtValFrete, 0);
            this.Controls.SetChildIndex(this.lblSeguro, 0);
            this.Controls.SetChildIndex(this.txtSeguro, 0);
            this.Controls.SetChildIndex(this.lblDespesas, 0);
            this.Controls.SetChildIndex(this.txtDespesas, 0);
            this.Controls.SetChildIndex(this.lblValorTotal, 0);
            this.Controls.SetChildIndex(this.txtValTotal, 0);
            this.Controls.SetChildIndex(this.listVCondPag, 0);
            this.Controls.SetChildIndex(this.lblCondPag, 0);
            this.Controls.SetChildIndex(this.txtCodCondPag, 0);
            this.Controls.SetChildIndex(this.txtCondPag, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblCod, 0);
            this.Controls.SetChildIndex(this.lblDataCriacao, 0);
            this.Controls.SetChildIndex(this.lblDataAlteracao, 0);
            this.Controls.SetChildIndex(this.lblUserAlt, 0);
            this.Controls.SetChildIndex(this.txtDtCriacao, 0);
            this.Controls.SetChildIndex(this.txtDtAlt, 0);
            this.Controls.SetChildIndex(this.txtUserAlt, 0);
            this.Controls.SetChildIndex(this.ckbStatus, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCondPag, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtCodForn;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Button btnPesquisarForn;
        protected System.Windows.Forms.DateTimePicker dtpDataEmissao;
        protected System.Windows.Forms.DateTimePicker dtpDataChegada;
        private System.Windows.Forms.Label lblEmissao;
        private System.Windows.Forms.Label lblChegada;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Button btnPesquisarProd;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ListView listVProdutos;
        private System.Windows.Forms.ColumnHeader clmCod;
        private System.Windows.Forms.ColumnHeader clmProd;
        private System.Windows.Forms.ColumnHeader clmUnidade;
        private System.Windows.Forms.ColumnHeader clmQtd;
        private System.Windows.Forms.ColumnHeader clmPrecoUnit;
        private System.Windows.Forms.ColumnHeader clmTotal;
        private System.Windows.Forms.TextBox txtSeguro;
        private System.Windows.Forms.Label lblSeguro;
        private System.Windows.Forms.TextBox txtValFrete;
        private System.Windows.Forms.Label lblValFrete;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.TextBox txtDespesas;
        private System.Windows.Forms.Label lblDespesas;
        private System.Windows.Forms.TextBox txtValTotal;
        private System.Windows.Forms.ListView listVCondPag;
        private System.Windows.Forms.ColumnHeader clmParcela;
        private System.Windows.Forms.ColumnHeader clmPrazo;
        private System.Windows.Forms.ColumnHeader clmPorcent;
        private System.Windows.Forms.ColumnHeader clmFormPag;
        private System.Windows.Forms.TextBox txtCodCondPag;
        private System.Windows.Forms.Label lblCondPag;
        private System.Windows.Forms.TextBox txtCondPag;
        private System.Windows.Forms.Button btnPesquisarCondPag;
    }
}
