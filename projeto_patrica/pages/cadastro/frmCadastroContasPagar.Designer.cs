namespace projeto_pratica.pages.cadastro
{
    partial class frmCadastroContasPagar
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
            this.txtNumDaNota = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblNumNota = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.dtpDataEmissao = new System.Windows.Forms.DateTimePicker();
            this.dtpDataVencimento = new System.Windows.Forms.DateTimePicker();
            this.txtCodForn = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.lblDataVencimento = new System.Windows.Forms.Label();
            this.lblDataEmissao = new System.Windows.Forms.Label();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.lblNumParcela = new System.Windows.Forms.Label();
            this.txtNumParcela = new System.Windows.Forms.TextBox();
            this.lblValorParcela = new System.Windows.Forms.Label();
            this.txtValorParcela = new System.Windows.Forms.TextBox();
            this.lblDataPagamento = new System.Windows.Forms.Label();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.lblMulta = new System.Windows.Forms.Label();
            this.lblJuros = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.txtMulta = new System.Windows.Forms.TextBox();
            this.txtJuros = new System.Windows.Forms.TextBox();
            this.lblValorFinal = new System.Windows.Forms.Label();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.txtCodFormaPagamento = new System.Windows.Forms.TextBox();
            this.txtFormaPagamento = new System.Windows.Forms.TextBox();
            this.lblMotivoCancelamento = new System.Windows.Forms.Label();
            this.dtpDataPagamento = new System.Windows.Forms.DateTimePicker();
            this.txtMotivoCancelamento = new System.Windows.Forms.TextBox();
            this.btnPesquisarProd = new System.Windows.Forms.Button();
            this.btnPesquisarFormPag = new System.Windows.Forms.Button();
            this.txtMultaValor = new System.Windows.Forms.TextBox();
            this.txtJuroValor = new System.Windows.Forms.TextBox();
            this.txtDesctValor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = false;
            this.lblCod.Location = new System.Drawing.Point(20, 27);
            this.lblCod.Size = new System.Drawing.Size(61, 16);
            this.lblCod.Text = "Modelo *";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(779, 667);
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.AutoSize = false;
            this.lblDataAlteracao.Location = new System.Drawing.Point(207, 655);
            // 
            // lblDataCriacao
            // 
            this.lblDataCriacao.AutoSize = false;
            this.lblDataCriacao.Location = new System.Drawing.Point(21, 655);
            // 
            // lblUserAlt
            // 
            this.lblUserAlt.AutoSize = false;
            this.lblUserAlt.Location = new System.Drawing.Point(411, 655);
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Location = new System.Drawing.Point(21, 673);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Location = new System.Drawing.Point(211, 673);
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Location = new System.Drawing.Point(414, 673);
            // 
            // ckbStatus
            // 
            this.ckbStatus.AutoSize = false;
            this.ckbStatus.Location = new System.Drawing.Point(946, 48);
            // 
            // btnSair
            // 
            this.btnSair.AutoSize = false;
            this.btnSair.Location = new System.Drawing.Point(903, 667);
            this.btnSair.Size = new System.Drawing.Size(118, 34);
            // 
            // txtCodigo
            // 
            this.txtCodigo.ShortcutsEnabled = false;
            this.txtCodigo.Size = new System.Drawing.Size(65, 22);
            // 
            // txtNumDaNota
            // 
            this.txtNumDaNota.Location = new System.Drawing.Point(175, 46);
            this.txtNumDaNota.Name = "txtNumDaNota";
            this.txtNumDaNota.ReadOnly = true;
            this.txtNumDaNota.ShortcutsEnabled = false;
            this.txtNumDaNota.Size = new System.Drawing.Size(129, 22);
            this.txtNumDaNota.TabIndex = 105;
            this.txtNumDaNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(107, 46);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ReadOnly = true;
            this.txtSerie.ShortcutsEnabled = false;
            this.txtSerie.Size = new System.Drawing.Size(46, 22);
            this.txtSerie.TabIndex = 106;
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNumNota
            // 
            this.lblNumNota.Location = new System.Drawing.Point(172, 27);
            this.lblNumNota.Name = "lblNumNota";
            this.lblNumNota.Size = new System.Drawing.Size(98, 16);
            this.lblNumNota.TabIndex = 103;
            this.lblNumNota.Text = "Núm. da Nota *";
            // 
            // lblSerie
            // 
            this.lblSerie.Location = new System.Drawing.Point(104, 27);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(47, 16);
            this.lblSerie.TabIndex = 104;
            this.lblSerie.Text = "Série *";
            // 
            // dtpDataEmissao
            // 
            this.dtpDataEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEmissao.Location = new System.Drawing.Point(763, 49);
            this.dtpDataEmissao.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataEmissao.Name = "dtpDataEmissao";
            this.dtpDataEmissao.Size = new System.Drawing.Size(115, 22);
            this.dtpDataEmissao.TabIndex = 114;
            this.dtpDataEmissao.ValueChanged += new System.EventHandler(this.dtpDataEmissao_ValueChanged);
            // 
            // dtpDataVencimento
            // 
            this.dtpDataVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataVencimento.Location = new System.Drawing.Point(763, 105);
            this.dtpDataVencimento.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataVencimento.Name = "dtpDataVencimento";
            this.dtpDataVencimento.Size = new System.Drawing.Size(109, 22);
            this.dtpDataVencimento.TabIndex = 113;
            // 
            // txtCodForn
            // 
            this.txtCodForn.Location = new System.Drawing.Point(324, 47);
            this.txtCodForn.Name = "txtCodForn";
            this.txtCodForn.ShortcutsEnabled = false;
            this.txtCodForn.Size = new System.Drawing.Size(60, 22);
            this.txtCodForn.TabIndex = 110;
            this.txtCodForn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodForn.Click += new System.EventHandler(this.txtCodForn_Leave);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(390, 46);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.ShortcutsEnabled = false;
            this.txtFornecedor.Size = new System.Drawing.Size(214, 22);
            this.txtFornecedor.TabIndex = 111;
            // 
            // lblDataVencimento
            // 
            this.lblDataVencimento.Location = new System.Drawing.Point(760, 87);
            this.lblDataVencimento.Name = "lblDataVencimento";
            this.lblDataVencimento.Size = new System.Drawing.Size(138, 16);
            this.lblDataVencimento.TabIndex = 107;
            this.lblDataVencimento.Text = "Data de Vencimento *";
            // 
            // lblDataEmissao
            // 
            this.lblDataEmissao.Location = new System.Drawing.Point(760, 31);
            this.lblDataEmissao.Name = "lblDataEmissao";
            this.lblDataEmissao.Size = new System.Drawing.Size(119, 16);
            this.lblDataEmissao.TabIndex = 108;
            this.lblDataEmissao.Text = "Data de Emissão *";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.Location = new System.Drawing.Point(321, 27);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(85, 16);
            this.lblFornecedor.TabIndex = 109;
            this.lblFornecedor.Text = "Fornecedor *";
            // 
            // lblNumParcela
            // 
            this.lblNumParcela.Location = new System.Drawing.Point(20, 111);
            this.lblNumParcela.Name = "lblNumParcela";
            this.lblNumParcela.Size = new System.Drawing.Size(115, 16);
            this.lblNumParcela.TabIndex = 103;
            this.lblNumParcela.Text = "Núm. da Parcela *";
            // 
            // txtNumParcela
            // 
            this.txtNumParcela.Location = new System.Drawing.Point(23, 130);
            this.txtNumParcela.Name = "txtNumParcela";
            this.txtNumParcela.ShortcutsEnabled = false;
            this.txtNumParcela.Size = new System.Drawing.Size(83, 22);
            this.txtNumParcela.TabIndex = 105;
            this.txtNumParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorParcela
            // 
            this.lblValorParcela.Location = new System.Drawing.Point(143, 111);
            this.lblValorParcela.Name = "lblValorParcela";
            this.lblValorParcela.Size = new System.Drawing.Size(144, 16);
            this.lblValorParcela.TabIndex = 103;
            this.lblValorParcela.Text = "Valor da Parcela (R$) *";
            // 
            // txtValorParcela
            // 
            this.txtValorParcela.Location = new System.Drawing.Point(146, 130);
            this.txtValorParcela.Name = "txtValorParcela";
            this.txtValorParcela.ShortcutsEnabled = false;
            this.txtValorParcela.Size = new System.Drawing.Size(189, 22);
            this.txtValorParcela.TabIndex = 105;
            this.txtValorParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDataPagamento
            // 
            this.lblDataPagamento.Location = new System.Drawing.Point(469, 250);
            this.lblDataPagamento.Name = "lblDataPagamento";
            this.lblDataPagamento.Size = new System.Drawing.Size(136, 16);
            this.lblDataPagamento.TabIndex = 108;
            this.lblDataPagamento.Text = "Data do Pagamento *";
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.Location = new System.Drawing.Point(19, 250);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(146, 16);
            this.lblFormaPagamento.TabIndex = 151;
            this.lblFormaPagamento.Text = "Forma de Pagamento *";
            // 
            // lblDesconto
            // 
            this.lblDesconto.Location = new System.Drawing.Point(591, 179);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(88, 16);
            this.lblDesconto.TabIndex = 154;
            this.lblDesconto.Text = "Desconto (%)";
            // 
            // lblMulta
            // 
            this.lblMulta.Location = new System.Drawing.Point(21, 180);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(63, 16);
            this.lblMulta.TabIndex = 155;
            this.lblMulta.Text = "Multa (%)";
            // 
            // lblJuros
            // 
            this.lblJuros.Location = new System.Drawing.Point(299, 179);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(63, 16);
            this.lblJuros.TabIndex = 156;
            this.lblJuros.Text = "Juros (%)";
            // 
            // txtDesconto
            // 
            this.txtDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesconto.Location = new System.Drawing.Point(589, 198);
            this.txtDesconto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.ShortcutsEnabled = false;
            this.txtDesconto.Size = new System.Drawing.Size(82, 22);
            this.txtDesconto.TabIndex = 159;
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesconto.Leave += new System.EventHandler(this.RecalcularValorPago);
            // 
            // txtMulta
            // 
            this.txtMulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMulta.Location = new System.Drawing.Point(24, 198);
            this.txtMulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMulta.Name = "txtMulta";
            this.txtMulta.ShortcutsEnabled = false;
            this.txtMulta.Size = new System.Drawing.Size(82, 22);
            this.txtMulta.TabIndex = 158;
            this.txtMulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMulta.Leave += new System.EventHandler(this.RecalcularValorPago);
            // 
            // txtJuros
            // 
            this.txtJuros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJuros.Location = new System.Drawing.Point(302, 198);
            this.txtJuros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.ShortcutsEnabled = false;
            this.txtJuros.Size = new System.Drawing.Size(82, 22);
            this.txtJuros.TabIndex = 157;
            this.txtJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJuros.Leave += new System.EventHandler(this.RecalcularValorPago);
            // 
            // lblValorFinal
            // 
            this.lblValorFinal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblValorFinal.Location = new System.Drawing.Point(22, 328);
            this.lblValorFinal.Name = "lblValorFinal";
            this.lblValorFinal.Size = new System.Drawing.Size(210, 20);
            this.lblValorFinal.TabIndex = 103;
            this.lblValorFinal.Text = "Valor Final da Parcela (R$)";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(25, 346);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.ReadOnly = true;
            this.txtValorPago.ShortcutsEnabled = false;
            this.txtValorPago.Size = new System.Drawing.Size(131, 22);
            this.txtValorPago.TabIndex = 105;
            this.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodFormaPagamento
            // 
            this.txtCodFormaPagamento.Location = new System.Drawing.Point(23, 269);
            this.txtCodFormaPagamento.Name = "txtCodFormaPagamento";
            this.txtCodFormaPagamento.ShortcutsEnabled = false;
            this.txtCodFormaPagamento.Size = new System.Drawing.Size(60, 22);
            this.txtCodFormaPagamento.TabIndex = 161;
            this.txtCodFormaPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFormaPagamento
            // 
            this.txtFormaPagamento.Location = new System.Drawing.Point(88, 269);
            this.txtFormaPagamento.Name = "txtFormaPagamento";
            this.txtFormaPagamento.ReadOnly = true;
            this.txtFormaPagamento.ShortcutsEnabled = false;
            this.txtFormaPagamento.Size = new System.Drawing.Size(214, 22);
            this.txtFormaPagamento.TabIndex = 162;
            // 
            // lblMotivoCancelamento
            // 
            this.lblMotivoCancelamento.Location = new System.Drawing.Point(22, 424);
            this.lblMotivoCancelamento.Name = "lblMotivoCancelamento";
            this.lblMotivoCancelamento.Size = new System.Drawing.Size(156, 16);
            this.lblMotivoCancelamento.TabIndex = 165;
            this.lblMotivoCancelamento.Text = "Motivo de Cancelamento";
            this.lblMotivoCancelamento.Visible = false;
            // 
            // dtpDataPagamento
            // 
            this.dtpDataPagamento.Checked = false;
            this.dtpDataPagamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataPagamento.Location = new System.Drawing.Point(470, 269);
            this.dtpDataPagamento.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataPagamento.Name = "dtpDataPagamento";
            this.dtpDataPagamento.Size = new System.Drawing.Size(135, 22);
            this.dtpDataPagamento.TabIndex = 166;
            // 
            // txtMotivoCancelamento
            // 
            this.txtMotivoCancelamento.Location = new System.Drawing.Point(23, 443);
            this.txtMotivoCancelamento.Name = "txtMotivoCancelamento";
            this.txtMotivoCancelamento.ReadOnly = true;
            this.txtMotivoCancelamento.ShortcutsEnabled = false;
            this.txtMotivoCancelamento.Size = new System.Drawing.Size(131, 22);
            this.txtMotivoCancelamento.TabIndex = 167;
            this.txtMotivoCancelamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPesquisarProd
            // 
            this.btnPesquisarProd.Location = new System.Drawing.Point(611, 43);
            this.btnPesquisarProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarProd.Name = "btnPesquisarProd";
            this.btnPesquisarProd.Size = new System.Drawing.Size(97, 28);
            this.btnPesquisarProd.TabIndex = 168;
            this.btnPesquisarProd.Text = "Pesquisar";
            this.btnPesquisarProd.UseVisualStyleBackColor = true;
            this.btnPesquisarProd.Click += new System.EventHandler(this.btnPesquisarFornecedor_Click);
            // 
            // btnPesquisarFormPag
            // 
            this.btnPesquisarFormPag.Location = new System.Drawing.Point(312, 266);
            this.btnPesquisarFormPag.Margin = new System.Windows.Forms.Padding(4);
            this.btnPesquisarFormPag.Name = "btnPesquisarFormPag";
            this.btnPesquisarFormPag.Size = new System.Drawing.Size(97, 28);
            this.btnPesquisarFormPag.TabIndex = 169;
            this.btnPesquisarFormPag.Text = "Pesquisar";
            this.btnPesquisarFormPag.UseVisualStyleBackColor = true;
            this.btnPesquisarFormPag.Click += new System.EventHandler(this.btnPesquisarFormaPagamento_Click);
            // 
            // txtMultaValor
            // 
            this.txtMultaValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMultaValor.Location = new System.Drawing.Point(123, 198);
            this.txtMultaValor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMultaValor.Name = "txtMultaValor";
            this.txtMultaValor.ReadOnly = true;
            this.txtMultaValor.ShortcutsEnabled = false;
            this.txtMultaValor.Size = new System.Drawing.Size(134, 22);
            this.txtMultaValor.TabIndex = 170;
            this.txtMultaValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtJuroValor
            // 
            this.txtJuroValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJuroValor.Location = new System.Drawing.Point(403, 198);
            this.txtJuroValor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJuroValor.Name = "txtJuroValor";
            this.txtJuroValor.ReadOnly = true;
            this.txtJuroValor.ShortcutsEnabled = false;
            this.txtJuroValor.Size = new System.Drawing.Size(134, 22);
            this.txtJuroValor.TabIndex = 173;
            this.txtJuroValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDesctValor
            // 
            this.txtDesctValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesctValor.Location = new System.Drawing.Point(693, 198);
            this.txtDesctValor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDesctValor.Name = "txtDesctValor";
            this.txtDesctValor.ReadOnly = true;
            this.txtDesctValor.ShortcutsEnabled = false;
            this.txtDesctValor.Size = new System.Drawing.Size(134, 22);
            this.txtDesctValor.TabIndex = 174;
            this.txtDesctValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmCadastroContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1041, 721);
            this.Controls.Add(this.txtDesctValor);
            this.Controls.Add(this.txtJuroValor);
            this.Controls.Add(this.txtMultaValor);
            this.Controls.Add(this.btnPesquisarFormPag);
            this.Controls.Add(this.btnPesquisarProd);
            this.Controls.Add(this.txtMotivoCancelamento);
            this.Controls.Add(this.dtpDataPagamento);
            this.Controls.Add(this.lblMotivoCancelamento);
            this.Controls.Add(this.txtCodFormaPagamento);
            this.Controls.Add(this.txtFormaPagamento);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.lblMulta);
            this.Controls.Add(this.lblJuros);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.txtMulta);
            this.Controls.Add(this.txtJuros);
            this.Controls.Add(this.lblFormaPagamento);
            this.Controls.Add(this.dtpDataEmissao);
            this.Controls.Add(this.dtpDataVencimento);
            this.Controls.Add(this.txtCodForn);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.lblDataPagamento);
            this.Controls.Add(this.lblDataVencimento);
            this.Controls.Add(this.lblDataEmissao);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.txtValorParcela);
            this.Controls.Add(this.lblValorFinal);
            this.Controls.Add(this.txtNumParcela);
            this.Controls.Add(this.lblValorParcela);
            this.Controls.Add(this.txtNumDaNota);
            this.Controls.Add(this.lblNumParcela);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.lblNumNota);
            this.Controls.Add(this.lblSerie);
            this.Name = "frmCadastroContasPagar";
            this.Text = "Cadastro de Contas a Pagar";
            this.Controls.SetChildIndex(this.lblSerie, 0);
            this.Controls.SetChildIndex(this.lblNumNota, 0);
            this.Controls.SetChildIndex(this.txtSerie, 0);
            this.Controls.SetChildIndex(this.lblNumParcela, 0);
            this.Controls.SetChildIndex(this.txtNumDaNota, 0);
            this.Controls.SetChildIndex(this.lblValorParcela, 0);
            this.Controls.SetChildIndex(this.txtNumParcela, 0);
            this.Controls.SetChildIndex(this.lblValorFinal, 0);
            this.Controls.SetChildIndex(this.txtValorParcela, 0);
            this.Controls.SetChildIndex(this.txtValorPago, 0);
            this.Controls.SetChildIndex(this.lblFornecedor, 0);
            this.Controls.SetChildIndex(this.lblDataEmissao, 0);
            this.Controls.SetChildIndex(this.lblDataVencimento, 0);
            this.Controls.SetChildIndex(this.lblDataPagamento, 0);
            this.Controls.SetChildIndex(this.txtFornecedor, 0);
            this.Controls.SetChildIndex(this.txtCodForn, 0);
            this.Controls.SetChildIndex(this.dtpDataVencimento, 0);
            this.Controls.SetChildIndex(this.dtpDataEmissao, 0);
            this.Controls.SetChildIndex(this.lblFormaPagamento, 0);
            this.Controls.SetChildIndex(this.txtJuros, 0);
            this.Controls.SetChildIndex(this.txtMulta, 0);
            this.Controls.SetChildIndex(this.txtDesconto, 0);
            this.Controls.SetChildIndex(this.lblJuros, 0);
            this.Controls.SetChildIndex(this.lblMulta, 0);
            this.Controls.SetChildIndex(this.lblDesconto, 0);
            this.Controls.SetChildIndex(this.txtFormaPagamento, 0);
            this.Controls.SetChildIndex(this.txtCodFormaPagamento, 0);
            this.Controls.SetChildIndex(this.lblMotivoCancelamento, 0);
            this.Controls.SetChildIndex(this.dtpDataPagamento, 0);
            this.Controls.SetChildIndex(this.txtMotivoCancelamento, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblCod, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.lblDataCriacao, 0);
            this.Controls.SetChildIndex(this.txtDtCriacao, 0);
            this.Controls.SetChildIndex(this.lblDataAlteracao, 0);
            this.Controls.SetChildIndex(this.txtDtAlt, 0);
            this.Controls.SetChildIndex(this.lblUserAlt, 0);
            this.Controls.SetChildIndex(this.txtUserAlt, 0);
            this.Controls.SetChildIndex(this.ckbStatus, 0);
            this.Controls.SetChildIndex(this.btnPesquisarProd, 0);
            this.Controls.SetChildIndex(this.btnPesquisarFormPag, 0);
            this.Controls.SetChildIndex(this.txtMultaValor, 0);
            this.Controls.SetChildIndex(this.txtJuroValor, 0);
            this.Controls.SetChildIndex(this.txtDesctValor, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumDaNota;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblNumNota;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.DateTimePicker dtpDataEmissao;
        private System.Windows.Forms.DateTimePicker dtpDataVencimento;
        private System.Windows.Forms.TextBox txtCodForn;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label lblDataVencimento;
        private System.Windows.Forms.Label lblDataEmissao;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Label lblNumParcela;
        private System.Windows.Forms.TextBox txtNumParcela;
        private System.Windows.Forms.Label lblValorParcela;
        private System.Windows.Forms.TextBox txtValorParcela;
        private System.Windows.Forms.Label lblDataPagamento;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.Label lblMulta;
        private System.Windows.Forms.Label lblJuros;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.TextBox txtMulta;
        private System.Windows.Forms.TextBox txtJuros;
        private System.Windows.Forms.Label lblValorFinal;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.TextBox txtCodFormaPagamento;
        private System.Windows.Forms.TextBox txtFormaPagamento;
        private System.Windows.Forms.Label lblMotivoCancelamento;
        private System.Windows.Forms.DateTimePicker dtpDataPagamento;
        private System.Windows.Forms.TextBox txtMotivoCancelamento;
        private System.Windows.Forms.Button btnPesquisarProd;
        private System.Windows.Forms.Button btnPesquisarFormPag;
        private System.Windows.Forms.TextBox txtMultaValor;
        private System.Windows.Forms.TextBox txtJuroValor;
        private System.Windows.Forms.TextBox txtDesctValor;
    }
}
