namespace projeto_pratica.pages.cadastro
{
    partial class frmCadastroNotaSaida
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
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnPesquisarCliente = new System.Windows.Forms.Button();
            this.dtpDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.lblEmissao = new System.Windows.Forms.Label();
            this.txtCodProd = new System.Windows.Forms.TextBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.lblQtd = new System.Windows.Forms.Label();
            this.txtValUnit = new System.Windows.Forms.TextBox();
            this.lblPrecoVend = new System.Windows.Forms.Label();
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
            this.txtValTotalNota = new System.Windows.Forms.TextBox();
            this.lblValorTotalNota = new System.Windows.Forms.Label();
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
            this.btnPesquisarFunc = new System.Windows.Forms.Button();
            this.txtFuncionario = new System.Windows.Forms.TextBox();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.txtCodFuncionario = new System.Windows.Forms.TextBox();
            this.txtCredCliente = new System.Windows.Forms.TextBox();
            this.lblCredCliente = new System.Windows.Forms.Label();
            this.txtQtdTotal = new System.Windows.Forms.TextBox();
            this.lblQtdProdutos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = false;
            this.lblCod.Location = new System.Drawing.Point(21, 26);
            this.lblCod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCod.Size = new System.Drawing.Size(85, 20);
            this.lblCod.Text = "MODELO*";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1445, 884);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.AutoSize = false;
            this.lblDataAlteracao.Location = new System.Drawing.Point(261, 871);
            this.lblDataAlteracao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataAlteracao.Size = new System.Drawing.Size(173, 20);
            // 
            // lblDataCriacao
            // 
            this.lblDataCriacao.AutoSize = false;
            this.lblDataCriacao.Location = new System.Drawing.Point(69, 871);
            this.lblDataCriacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataCriacao.Size = new System.Drawing.Size(117, 20);
            // 
            // lblUserAlt
            // 
            this.lblUserAlt.AutoSize = false;
            this.lblUserAlt.Location = new System.Drawing.Point(464, 871);
            this.lblUserAlt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserAlt.Size = new System.Drawing.Size(124, 20);
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Location = new System.Drawing.Point(75, 890);
            this.txtDtCriacao.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Location = new System.Drawing.Point(264, 890);
            this.txtDtAlt.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Location = new System.Drawing.Point(467, 890);
            this.txtUserAlt.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(1629, 47);
            this.ckbStatus.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // btnSair
            // 
            this.btnSair.AutoSize = false;
            this.btnSair.Location = new System.Drawing.Point(1571, 884);
            this.btnSair.Margin = new System.Windows.Forms.Padding(5);
            // 
            // txtCodigo
            // 
            this.txtCodigo.ReadOnly = false;
            this.txtCodigo.Size = new System.Drawing.Size(148, 22);
            this.txtCodigo.Text = "55";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSerie
            // 
            this.lblSerie.Location = new System.Drawing.Point(191, 28);
            this.lblSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(65, 20);
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
            this.txtSerie.Text = "1";
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNumero
            // 
            this.lblNumero.Location = new System.Drawing.Point(316, 26);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(91, 20);
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
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(479, 46);
            this.txtCodCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodCliente.MaxLength = 255;
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(53, 22);
            this.txtCodCliente.TabIndex = 36;
            this.txtCodCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodCliente.Leave += new System.EventHandler(this.txtCodCliente_Leave);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(555, 46);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCliente.MaxLength = 255;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(283, 22);
            this.txtCliente.TabIndex = 38;
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(476, 23);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(133, 20);
            this.lblCliente.TabIndex = 37;
            this.lblCliente.Text = "CLIENTE:*";
            // 
            // btnPesquisarCliente
            // 
            this.btnPesquisarCliente.Location = new System.Drawing.Point(845, 43);
            this.btnPesquisarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(97, 28);
            this.btnPesquisarCliente.TabIndex = 39;
            this.btnPesquisarCliente.Text = "Pesquisar";
            this.btnPesquisarCliente.UseVisualStyleBackColor = true;
            this.btnPesquisarCliente.Click += new System.EventHandler(this.btnPesquisarCliente_Click);
            // 
            // dtpDataEmissao
            // 
            this.dtpDataEmissao.Checked = false;
            this.dtpDataEmissao.CustomFormat = "";
            this.dtpDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmissao.Location = new System.Drawing.Point(1475, 48);
            this.dtpDataEmissao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDataEmissao.MaxDate = new System.DateTime(2999, 12, 30, 0, 0, 0, 0);
            this.dtpDataEmissao.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataEmissao.Name = "dtpDataEmissao";
            this.dtpDataEmissao.Size = new System.Drawing.Size(125, 22);
            this.dtpDataEmissao.TabIndex = 40;
            this.dtpDataEmissao.Value = new System.DateTime(2025, 7, 1, 0, 0, 0, 0);
            // 
            // lblEmissao
            // 
            this.lblEmissao.Location = new System.Drawing.Point(1472, 25);
            this.lblEmissao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmissao.Name = "lblEmissao";
            this.lblEmissao.Size = new System.Drawing.Size(140, 20);
            this.lblEmissao.TabIndex = 42;
            this.lblEmissao.Text = "DATA EMISSÃO*";
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
            this.lblProduto.Location = new System.Drawing.Point(21, 110);
            this.lblProduto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(93, 20);
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
            this.lblQtd.Location = new System.Drawing.Point(464, 110);
            this.lblQtd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(120, 20);
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
            // lblPrecoVend
            // 
            this.lblPrecoVend.Location = new System.Drawing.Point(661, 110);
            this.lblPrecoVend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecoVend.Name = "lblPrecoVend";
            this.lblPrecoVend.Size = new System.Drawing.Size(220, 14);
            this.lblPrecoVend.TabIndex = 49;
            this.lblPrecoVend.Text = "PREÇO DE VENDA (R$)";
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
            this.btnAdicionar.Location = new System.Drawing.Point(859, 124);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(97, 30);
            this.btnAdicionar.TabIndex = 54;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(964, 124);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(97, 30);
            this.btnAlterar.TabIndex = 55;
            this.btnAlterar.Text = "Salvar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(1069, 124);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(97, 30);
            this.btnExcluir.TabIndex = 56;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1173, 124);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 30);
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
            this.listVProdutos.Location = new System.Drawing.Point(23, 177);
            this.listVProdutos.Margin = new System.Windows.Forms.Padding(4);
            this.listVProdutos.Name = "listVProdutos";
            this.listVProdutos.Size = new System.Drawing.Size(1587, 335);
            this.listVProdutos.TabIndex = 58;
            this.listVProdutos.UseCompatibleStateImageBehavior = false;
            this.listVProdutos.View = System.Windows.Forms.View.Details;
            this.listVProdutos.SelectedIndexChanged += new System.EventHandler(this.listVProdutos_SelectedIndexChanged);
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
            // txtValTotalNota
            // 
            this.txtValTotalNota.Location = new System.Drawing.Point(619, 545);
            this.txtValTotalNota.Margin = new System.Windows.Forms.Padding(4);
            this.txtValTotalNota.MaxLength = 255;
            this.txtValTotalNota.Name = "txtValTotalNota";
            this.txtValTotalNota.ReadOnly = true;
            this.txtValTotalNota.Size = new System.Drawing.Size(263, 22);
            this.txtValTotalNota.TabIndex = 65;
            this.txtValTotalNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorTotalNota
            // 
            this.lblValorTotalNota.Location = new System.Drawing.Point(616, 526);
            this.lblValorTotalNota.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorTotalNota.Name = "lblValorTotalNota";
            this.lblValorTotalNota.Size = new System.Drawing.Size(265, 15);
            this.lblValorTotalNota.TabIndex = 66;
            this.lblValorTotalNota.Text = "VALOR TOTAL DA NOTA";
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
            this.listVCondPag.Location = new System.Drawing.Point(24, 674);
            this.listVCondPag.Margin = new System.Windows.Forms.Padding(4);
            this.listVCondPag.Name = "listVCondPag";
            this.listVCondPag.Size = new System.Drawing.Size(1596, 164);
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
            this.txtCodCondPag.Location = new System.Drawing.Point(24, 644);
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
            this.lblCondPag.Location = new System.Drawing.Point(20, 626);
            this.lblCondPag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCondPag.Name = "lblCondPag";
            this.lblCondPag.Size = new System.Drawing.Size(208, 18);
            this.lblCondPag.TabIndex = 69;
            this.lblCondPag.Text = "CONDIÇÃO PAGAMENTO";
            // 
            // txtCondPag
            // 
            this.txtCondPag.Location = new System.Drawing.Point(124, 644);
            this.txtCondPag.Margin = new System.Windows.Forms.Padding(4);
            this.txtCondPag.MaxLength = 255;
            this.txtCondPag.Name = "txtCondPag";
            this.txtCondPag.ReadOnly = true;
            this.txtCondPag.Size = new System.Drawing.Size(236, 22);
            this.txtCondPag.TabIndex = 70;
            // 
            // btnPesquisarCondPag
            // 
            this.btnPesquisarCondPag.Location = new System.Drawing.Point(371, 642);
            this.btnPesquisarCondPag.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarCondPag.Name = "btnPesquisarCondPag";
            this.btnPesquisarCondPag.Size = new System.Drawing.Size(97, 27);
            this.btnPesquisarCondPag.TabIndex = 71;
            this.btnPesquisarCondPag.Text = "Pesquisar";
            this.btnPesquisarCondPag.UseVisualStyleBackColor = true;
            this.btnPesquisarCondPag.Click += new System.EventHandler(this.btnPesquisarCondPag_Click);
            // 
            // btnPesquisarFunc
            // 
            this.btnPesquisarFunc.Location = new System.Drawing.Point(1339, 46);
            this.btnPesquisarFunc.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarFunc.Name = "btnPesquisarFunc";
            this.btnPesquisarFunc.Size = new System.Drawing.Size(97, 28);
            this.btnPesquisarFunc.TabIndex = 75;
            this.btnPesquisarFunc.Text = "Pesquisar";
            this.btnPesquisarFunc.UseVisualStyleBackColor = true;
            this.btnPesquisarFunc.Click += new System.EventHandler(this.btnPesquisarFunc_Click);
            // 
            // txtFuncionario
            // 
            this.txtFuncionario.Location = new System.Drawing.Point(1045, 47);
            this.txtFuncionario.Margin = new System.Windows.Forms.Padding(4);
            this.txtFuncionario.MaxLength = 255;
            this.txtFuncionario.Name = "txtFuncionario";
            this.txtFuncionario.ReadOnly = true;
            this.txtFuncionario.Size = new System.Drawing.Size(283, 22);
            this.txtFuncionario.TabIndex = 74;
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.Location = new System.Drawing.Point(968, 23);
            this.lblFuncionario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(133, 20);
            this.lblFuncionario.TabIndex = 73;
            this.lblFuncionario.Text = "FUNCIONARIO:*";
            // 
            // txtCodFuncionario
            // 
            this.txtCodFuncionario.Location = new System.Drawing.Point(971, 47);
            this.txtCodFuncionario.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodFuncionario.MaxLength = 255;
            this.txtCodFuncionario.Name = "txtCodFuncionario";
            this.txtCodFuncionario.Size = new System.Drawing.Size(53, 22);
            this.txtCodFuncionario.TabIndex = 72;
            this.txtCodFuncionario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodFuncionario.Leave += new System.EventHandler(this.txtCodFuncionario_Leave);
            // 
            // txtCredCliente
            // 
            this.txtCredCliente.Location = new System.Drawing.Point(25, 545);
            this.txtCredCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCredCliente.MaxLength = 255;
            this.txtCredCliente.Name = "txtCredCliente";
            this.txtCredCliente.ReadOnly = true;
            this.txtCredCliente.Size = new System.Drawing.Size(193, 22);
            this.txtCredCliente.TabIndex = 76;
            this.txtCredCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCredCliente
            // 
            this.lblCredCliente.Location = new System.Drawing.Point(21, 526);
            this.lblCredCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCredCliente.Name = "lblCredCliente";
            this.lblCredCliente.Size = new System.Drawing.Size(267, 20);
            this.lblCredCliente.TabIndex = 77;
            this.lblCredCliente.Text = "CREDITO DO CLIENTE:";
            // 
            // txtQtdTotal
            // 
            this.txtQtdTotal.Location = new System.Drawing.Point(319, 545);
            this.txtQtdTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtQtdTotal.MaxLength = 255;
            this.txtQtdTotal.Name = "txtQtdTotal";
            this.txtQtdTotal.ReadOnly = true;
            this.txtQtdTotal.Size = new System.Drawing.Size(105, 22);
            this.txtQtdTotal.TabIndex = 78;
            this.txtQtdTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQtdProdutos
            // 
            this.lblQtdProdutos.Location = new System.Drawing.Point(315, 526);
            this.lblQtdProdutos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQtdProdutos.Name = "lblQtdProdutos";
            this.lblQtdProdutos.Size = new System.Drawing.Size(293, 20);
            this.lblQtdProdutos.TabIndex = 79;
            this.lblQtdProdutos.Text = "QUANTIDADE TOTAL DE PRODUTOS:";
            // 
            // frmCadastroNotaSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1713, 946);
            this.Controls.Add(this.txtQtdTotal);
            this.Controls.Add(this.lblQtdProdutos);
            this.Controls.Add(this.txtCredCliente);
            this.Controls.Add(this.lblCredCliente);
            this.Controls.Add(this.btnPesquisarFunc);
            this.Controls.Add(this.txtFuncionario);
            this.Controls.Add(this.lblFuncionario);
            this.Controls.Add(this.txtCodFuncionario);
            this.Controls.Add(this.btnPesquisarCondPag);
            this.Controls.Add(this.txtCondPag);
            this.Controls.Add(this.txtCodCondPag);
            this.Controls.Add(this.lblCondPag);
            this.Controls.Add(this.listVCondPag);
            this.Controls.Add(this.txtValTotalNota);
            this.Controls.Add(this.lblValorTotalNota);
            this.Controls.Add(this.listVProdutos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnPesquisarProd);
            this.Controls.Add(this.txtProduto);
            this.Controls.Add(this.txtValUnit);
            this.Controls.Add(this.lblPrecoVend);
            this.Controls.Add(this.txtQtd);
            this.Controls.Add(this.lblQtd);
            this.Controls.Add(this.txtCodProd);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.lblEmissao);
            this.Controls.Add(this.dtpDataEmissao);
            this.Controls.Add(this.btnPesquisarCliente);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblSerie);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCadastroNotaSaida";
            this.Text = "Cadastro de Notas de Saida";
            this.Controls.SetChildIndex(this.lblSerie, 0);
            this.Controls.SetChildIndex(this.txtSerie, 0);
            this.Controls.SetChildIndex(this.lblNumero, 0);
            this.Controls.SetChildIndex(this.txtNum, 0);
            this.Controls.SetChildIndex(this.txtCodCliente, 0);
            this.Controls.SetChildIndex(this.lblCliente, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCliente, 0);
            this.Controls.SetChildIndex(this.dtpDataEmissao, 0);
            this.Controls.SetChildIndex(this.lblEmissao, 0);
            this.Controls.SetChildIndex(this.lblProduto, 0);
            this.Controls.SetChildIndex(this.txtCodProd, 0);
            this.Controls.SetChildIndex(this.lblQtd, 0);
            this.Controls.SetChildIndex(this.txtQtd, 0);
            this.Controls.SetChildIndex(this.lblPrecoVend, 0);
            this.Controls.SetChildIndex(this.txtValUnit, 0);
            this.Controls.SetChildIndex(this.txtProduto, 0);
            this.Controls.SetChildIndex(this.btnPesquisarProd, 0);
            this.Controls.SetChildIndex(this.btnAdicionar, 0);
            this.Controls.SetChildIndex(this.btnAlterar, 0);
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.listVProdutos, 0);
            this.Controls.SetChildIndex(this.lblValorTotalNota, 0);
            this.Controls.SetChildIndex(this.txtValTotalNota, 0);
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
            this.Controls.SetChildIndex(this.txtCodFuncionario, 0);
            this.Controls.SetChildIndex(this.lblFuncionario, 0);
            this.Controls.SetChildIndex(this.txtFuncionario, 0);
            this.Controls.SetChildIndex(this.btnPesquisarFunc, 0);
            this.Controls.SetChildIndex(this.lblCredCliente, 0);
            this.Controls.SetChildIndex(this.txtCredCliente, 0);
            this.Controls.SetChildIndex(this.lblQtdProdutos, 0);
            this.Controls.SetChildIndex(this.txtQtdTotal, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnPesquisarCliente;
        protected System.Windows.Forms.DateTimePicker dtpDataEmissao;
        private System.Windows.Forms.Label lblEmissao;
        private System.Windows.Forms.TextBox txtCodProd;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.Label lblQtd;
        private System.Windows.Forms.TextBox txtValUnit;
        private System.Windows.Forms.Label lblPrecoVend;
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
        private System.Windows.Forms.Label lblValorTotalNota;
        private System.Windows.Forms.TextBox txtValTotalNota;
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
        private System.Windows.Forms.Button btnPesquisarFunc;
        private System.Windows.Forms.TextBox txtFuncionario;
        private System.Windows.Forms.Label lblFuncionario;
        private System.Windows.Forms.TextBox txtCodFuncionario;
        private System.Windows.Forms.TextBox txtCredCliente;
        private System.Windows.Forms.Label lblCredCliente;
        private System.Windows.Forms.TextBox txtQtdTotal;
        private System.Windows.Forms.Label lblQtdProdutos;
    }
}
