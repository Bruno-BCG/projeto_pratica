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
            this.lblQtd = new System.Windows.Forms.Label();
            this.txtValUnit = new System.Windows.Forms.TextBox();
            this.lblValUnit = new System.Windows.Forms.Label();
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
            this.clmValParc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtCodCondPag = new System.Windows.Forms.TextBox();
            this.lblCondPag = new System.Windows.Forms.Label();
            this.txtCondPag = new System.Windows.Forms.TextBox();
            this.btnPesquisarCondPag = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCod
            // 
            this.lblCod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCod.Size = new System.Drawing.Size(69, 16);
            this.lblCod.Text = "MODELO*";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1233, 946);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.Location = new System.Drawing.Point(263, 934);
            this.lblDataAlteracao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // lblDataCriacao
            // 
            this.lblDataCriacao.Location = new System.Drawing.Point(72, 934);
            this.lblDataCriacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // lblUserAlt
            // 
            this.lblUserAlt.Location = new System.Drawing.Point(465, 934);
            this.lblUserAlt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Location = new System.Drawing.Point(75, 953);
            this.txtDtCriacao.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Location = new System.Drawing.Point(265, 953);
            this.txtDtAlt.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Location = new System.Drawing.Point(468, 953);
            this.txtUserAlt.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(1397, 47);
            this.ckbStatus.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(1368, 946);
            this.btnSair.Margin = new System.Windows.Forms.Padding(5);
            // 
            // txtCodigo
            // 
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Size = new System.Drawing.Size(148, 22);
            this.txtCodigo.Text = "";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(192, 27);
            this.lblSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(52, 16);
            this.lblSerie.TabIndex = 2;
            this.lblSerie.Text = "SERIE*";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(196, 46);
            this.txtSerie.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerie.MaxLength = 255;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(109, 22);
            this.txtSerie.TabIndex = 2;
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(317, 26);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(72, 16);
            this.lblNumero.TabIndex = 32;
            this.lblNumero.Text = "NUMERO*";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(321, 46);
            this.txtNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtNum.MaxLength = 255;
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(132, 22);
            this.txtNum.TabIndex = 35;
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodForn
            // 
            this.txtCodForn.Location = new System.Drawing.Point(524, 44);
            this.txtCodForn.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodForn.MaxLength = 255;
            this.txtCodForn.Name = "txtCodForn";
            this.txtCodForn.Size = new System.Drawing.Size(53, 22);
            this.txtCodForn.TabIndex = 36;
            this.txtCodForn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodForn.Leave += new System.EventHandler(this.txtCodForn_Leave);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(599, 44);
            this.txtFornecedor.Margin = new System.Windows.Forms.Padding(4);
            this.txtFornecedor.MaxLength = 255;
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(283, 22);
            this.txtFornecedor.TabIndex = 38;
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(520, 25);
            this.lblFornecedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(107, 16);
            this.lblFornecedor.TabIndex = 37;
            this.lblFornecedor.Text = "FORNECEDOR*";
            // 
            // btnPesquisarForn
            // 
            this.btnPesquisarForn.Location = new System.Drawing.Point(891, 42);
            this.btnPesquisarForn.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarForn.Name = "btnPesquisarForn";
            this.btnPesquisarForn.Size = new System.Drawing.Size(97, 28);
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
            this.dtpDataEmissao.Location = new System.Drawing.Point(1052, 42);
            this.dtpDataEmissao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDataEmissao.MaxDate = new System.DateTime(2999, 12, 30, 0, 0, 0, 0);
            this.dtpDataEmissao.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataEmissao.Name = "dtpDataEmissao";
            this.dtpDataEmissao.Size = new System.Drawing.Size(125, 22);
            this.dtpDataEmissao.TabIndex = 40;
            this.dtpDataEmissao.Value = new System.DateTime(2025, 7, 1, 0, 0, 0, 0);
            this.dtpDataEmissao.ValueChanged += new System.EventHandler(this.dtpDataEmissao_ValueChanged);
            // 
            // dtpDataChegada
            // 
            this.dtpDataChegada.Checked = false;
            this.dtpDataChegada.CustomFormat = "";
            this.dtpDataChegada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataChegada.Location = new System.Drawing.Point(1233, 42);
            this.dtpDataChegada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDataChegada.MaxDate = new System.DateTime(2999, 12, 30, 0, 0, 0, 0);
            this.dtpDataChegada.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataChegada.Name = "dtpDataChegada";
            this.dtpDataChegada.Size = new System.Drawing.Size(125, 22);
            this.dtpDataChegada.TabIndex = 41;
            this.dtpDataChegada.Value = new System.DateTime(2025, 7, 1, 0, 0, 0, 0);
            this.dtpDataChegada.ValueChanged += new System.EventHandler(this.dtpDataChegada_ValueChanged);
            // 
            // lblEmissao
            // 
            this.lblEmissao.AutoSize = true;
            this.lblEmissao.Location = new System.Drawing.Point(1048, 25);
            this.lblEmissao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmissao.Name = "lblEmissao";
            this.lblEmissao.Size = new System.Drawing.Size(112, 16);
            this.lblEmissao.TabIndex = 42;
            this.lblEmissao.Text = "DATA EMISSÃO*";
            // 
            // lblChegada
            // 
            this.lblChegada.AutoSize = true;
            this.lblChegada.Location = new System.Drawing.Point(1229, 23);
            this.lblChegada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChegada.Name = "lblChegada";
            this.lblChegada.Size = new System.Drawing.Size(118, 16);
            this.lblChegada.TabIndex = 43;
            this.lblChegada.Text = "DATA CHEGADA*";
            // 
            // txtCodProd
            // 
            this.txtCodProd.Location = new System.Drawing.Point(25, 128);
            this.txtCodProd.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodProd.MaxLength = 255;
            this.txtCodProd.Name = "txtCodProd";
            this.txtCodProd.Size = new System.Drawing.Size(53, 22);
            this.txtCodProd.TabIndex = 44;
            this.txtCodProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodProd.Leave += new System.EventHandler(this.txtCodProd_Leave);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(21, 110);
            this.lblProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(75, 16);
            this.lblProduto.TabIndex = 45;
            this.lblProduto.Text = "PRODUTO";
            // 
            // txtQtd
            // 
            this.txtQtd.Location = new System.Drawing.Point(468, 128);
            this.txtQtd.Margin = new System.Windows.Forms.Padding(4);
            this.txtQtd.MaxLength = 255;
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(165, 22);
            this.txtQtd.TabIndex = 46;
            this.txtQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQtd
            // 
            this.lblQtd.AutoSize = true;
            this.lblQtd.Location = new System.Drawing.Point(464, 110);
            this.lblQtd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(96, 16);
            this.lblQtd.TabIndex = 47;
            this.lblQtd.Text = "QUANTIDADE";
            // 
            // txtValUnit
            // 
            this.txtValUnit.Location = new System.Drawing.Point(664, 128);
            this.txtValUnit.Margin = new System.Windows.Forms.Padding(4);
            this.txtValUnit.MaxLength = 255;
            this.txtValUnit.Name = "txtValUnit";
            this.txtValUnit.Size = new System.Drawing.Size(161, 22);
            this.txtValUnit.TabIndex = 48;
            this.txtValUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValUnit
            // 
            this.lblValUnit.AutoSize = true;
            this.lblValUnit.Location = new System.Drawing.Point(660, 110);
            this.lblValUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValUnit.Name = "lblValUnit";
            this.lblValUnit.Size = new System.Drawing.Size(119, 16);
            this.lblValUnit.TabIndex = 49;
            this.lblValUnit.Text = "VALOR UNITARIO";
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(88, 128);
            this.txtProduto.Margin = new System.Windows.Forms.Padding(4);
            this.txtProduto.MaxLength = 255;
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ReadOnly = true;
            this.txtProduto.Size = new System.Drawing.Size(240, 22);
            this.txtProduto.TabIndex = 52;
            // 
            // btnPesquisarProd
            // 
            this.btnPesquisarProd.Location = new System.Drawing.Point(340, 126);
            this.btnPesquisarProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarProd.Name = "btnPesquisarProd";
            this.btnPesquisarProd.Size = new System.Drawing.Size(97, 28);
            this.btnPesquisarProd.TabIndex = 53;
            this.btnPesquisarProd.Text = "Pesquisar";
            this.btnPesquisarProd.UseVisualStyleBackColor = true;
            this.btnPesquisarProd.Click += new System.EventHandler(this.btnPesquisarProd_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(855, 124);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(97, 28);
            this.btnAdicionar.TabIndex = 54;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(976, 124);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(97, 28);
            this.btnAlterar.TabIndex = 55;
            this.btnAlterar.Text = "Salvar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(1107, 126);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(97, 28);
            this.btnExcluir.TabIndex = 56;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1233, 126);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 28);
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
            this.listVProdutos.Location = new System.Drawing.Point(25, 181);
            this.listVProdutos.Margin = new System.Windows.Forms.Padding(4);
            this.listVProdutos.Name = "listVProdutos";
            this.listVProdutos.Size = new System.Drawing.Size(1395, 335);
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
            this.txtSeguro.Location = new System.Drawing.Point(221, 570);
            this.txtSeguro.Margin = new System.Windows.Forms.Padding(4);
            this.txtSeguro.MaxLength = 255;
            this.txtSeguro.Name = "txtSeguro";
            this.txtSeguro.Size = new System.Drawing.Size(161, 22);
            this.txtSeguro.TabIndex = 61;
            this.txtSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSeguro
            // 
            this.lblSeguro.AutoSize = true;
            this.lblSeguro.Location = new System.Drawing.Point(217, 551);
            this.lblSeguro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeguro.Name = "lblSeguro";
            this.lblSeguro.Size = new System.Drawing.Size(65, 16);
            this.lblSeguro.TabIndex = 62;
            this.lblSeguro.Text = "SEGURO";
            // 
            // txtValFrete
            // 
            this.txtValFrete.Location = new System.Drawing.Point(25, 570);
            this.txtValFrete.Margin = new System.Windows.Forms.Padding(4);
            this.txtValFrete.MaxLength = 255;
            this.txtValFrete.Name = "txtValFrete";
            this.txtValFrete.Size = new System.Drawing.Size(165, 22);
            this.txtValFrete.TabIndex = 59;
            this.txtValFrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValFrete
            // 
            this.lblValFrete.AutoSize = true;
            this.lblValFrete.Location = new System.Drawing.Point(21, 551);
            this.lblValFrete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValFrete.Name = "lblValFrete";
            this.lblValFrete.Size = new System.Drawing.Size(100, 16);
            this.lblValFrete.TabIndex = 60;
            this.lblValFrete.Text = "VALOR FRETE";
            // 
            // txtValTotal
            // 
            this.txtValTotal.Location = new System.Drawing.Point(608, 570);
            this.txtValTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtValTotal.MaxLength = 255;
            this.txtValTotal.Name = "txtValTotal";
            this.txtValTotal.ReadOnly = true;
            this.txtValTotal.Size = new System.Drawing.Size(161, 22);
            this.txtValTotal.TabIndex = 65;
            this.txtValTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(604, 551);
            this.lblValorTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(99, 16);
            this.lblValorTotal.TabIndex = 66;
            this.lblValorTotal.Text = "VALOR TOTAL";
            // 
            // txtDespesas
            // 
            this.txtDespesas.Location = new System.Drawing.Point(412, 570);
            this.txtDespesas.Margin = new System.Windows.Forms.Padding(4);
            this.txtDespesas.MaxLength = 255;
            this.txtDespesas.Name = "txtDespesas";
            this.txtDespesas.Size = new System.Drawing.Size(165, 22);
            this.txtDespesas.TabIndex = 63;
            this.txtDespesas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDespesas
            // 
            this.lblDespesas.AutoSize = true;
            this.lblDespesas.Location = new System.Drawing.Point(408, 551);
            this.lblDespesas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDespesas.Name = "lblDespesas";
            this.lblDespesas.Size = new System.Drawing.Size(80, 16);
            this.lblDespesas.TabIndex = 64;
            this.lblDespesas.Text = "DESPESAS";
            // 
            // listVCondPag
            // 
            this.listVCondPag.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmParcela,
            this.clmPrazo,
            this.clmPorcent,
            this.clmFormPag,
            this.clmValParc});
            this.listVCondPag.FullRowSelect = true;
            this.listVCondPag.GridLines = true;
            this.listVCondPag.HideSelection = false;
            this.listVCondPag.Location = new System.Drawing.Point(16, 716);
            this.listVCondPag.Margin = new System.Windows.Forms.Padding(4);
            this.listVCondPag.Name = "listVCondPag";
            this.listVCondPag.Size = new System.Drawing.Size(1404, 164);
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
            this.clmFormPag.Width = 159;
            // 
            // clmValParc
            // 
            this.clmValParc.Text = "VALOR";
            this.clmValParc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmValParc.Width = 100;
            // 
            // txtCodCondPag
            // 
            this.txtCodCondPag.Location = new System.Drawing.Point(25, 683);
            this.txtCodCondPag.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCondPag.MaxLength = 255;
            this.txtCodCondPag.Name = "txtCodCondPag";
            this.txtCodCondPag.Size = new System.Drawing.Size(76, 22);
            this.txtCodCondPag.TabIndex = 68;
            this.txtCodCondPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodCondPag.Leave += new System.EventHandler(this.txtCodCondPag_Leave);
            // 
            // lblCondPag
            // 
            this.lblCondPag.AutoSize = true;
            this.lblCondPag.Location = new System.Drawing.Point(21, 665);
            this.lblCondPag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCondPag.Name = "lblCondPag";
            this.lblCondPag.Size = new System.Drawing.Size(166, 16);
            this.lblCondPag.TabIndex = 69;
            this.lblCondPag.Text = "CONDIÇÃO PAGAMENTO";
            // 
            // txtCondPag
            // 
            this.txtCondPag.Location = new System.Drawing.Point(125, 683);
            this.txtCondPag.Margin = new System.Windows.Forms.Padding(4);
            this.txtCondPag.MaxLength = 255;
            this.txtCondPag.Name = "txtCondPag";
            this.txtCondPag.ReadOnly = true;
            this.txtCondPag.Size = new System.Drawing.Size(236, 22);
            this.txtCondPag.TabIndex = 70;
            // 
            // btnPesquisarCondPag
            // 
            this.btnPesquisarCondPag.Location = new System.Drawing.Point(371, 681);
            this.btnPesquisarCondPag.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarCondPag.Name = "btnPesquisarCondPag";
            this.btnPesquisarCondPag.Size = new System.Drawing.Size(97, 28);
            this.btnPesquisarCondPag.TabIndex = 71;
            this.btnPesquisarCondPag.Text = "Pesquisar";
            this.btnPesquisarCondPag.UseVisualStyleBackColor = true;
            this.btnPesquisarCondPag.Click += new System.EventHandler(this.btnPesquisarCondPag_Click);
            // 
            // frmCadastroNotaEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1500, 986);
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
            this.Controls.Add(this.lblValUnit);
            this.Controls.Add(this.txtQtd);
            this.Controls.Add(this.lblQtd);
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
            this.Margin = new System.Windows.Forms.Padding(5);
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
            this.Controls.SetChildIndex(this.lblQtd, 0);
            this.Controls.SetChildIndex(this.txtQtd, 0);
            this.Controls.SetChildIndex(this.lblValUnit, 0);
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
        private System.Windows.Forms.Label lblQtd;
        private System.Windows.Forms.TextBox txtValUnit;
        private System.Windows.Forms.Label lblValUnit;
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
        private System.Windows.Forms.ColumnHeader clmValParc;
    }
}
