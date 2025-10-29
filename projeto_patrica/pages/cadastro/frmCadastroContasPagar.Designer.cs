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
            this.txtCodFornecedor = new System.Windows.Forms.TextBox();
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
            this.button1 = new System.Windows.Forms.Button();
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
            // txtCodFornecedor
            // 
            this.txtCodFornecedor.Location = new System.Drawing.Point(324, 47);
            this.txtCodFornecedor.Name = "txtCodFornecedor";
            this.txtCodFornecedor.ShortcutsEnabled = false;
            this.txtCodFornecedor.Size = new System.Drawing.Size(60, 22);
            this.txtCodFornecedor.TabIndex = 110;
            this.txtCodFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.lblDataPagamento.Location = new System.Drawing.Point(468, 182);
            this.lblDataPagamento.Name = "lblDataPagamento";
            this.lblDataPagamento.Size = new System.Drawing.Size(136, 16);
            this.lblDataPagamento.TabIndex = 108;
            this.lblDataPagamento.Text = "Data do Pagamento *";
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.Location = new System.Drawing.Point(18, 182);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(146, 16);
            this.lblFormaPagamento.TabIndex = 151;
            this.lblFormaPagamento.Text = "Forma de Pagamento *";
            // 
            // lblDesconto
            // 
            this.lblDesconto.Location = new System.Drawing.Point(591, 111);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(88, 16);
            this.lblDesconto.TabIndex = 154;
            this.lblDesconto.Text = "Desconto (%)";
            // 
            // lblMulta
            // 
            this.lblMulta.Location = new System.Drawing.Point(369, 112);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(63, 16);
            this.lblMulta.TabIndex = 155;
            this.lblMulta.Text = "Multa (%)";
            // 
            // lblJuros
            // 
            this.lblJuros.Location = new System.Drawing.Point(479, 111);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(63, 16);
            this.lblJuros.TabIndex = 156;
            this.lblJuros.Text = "Juros (%)";
            // 
            // txtDesconto
            // 
            this.txtDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesconto.Location = new System.Drawing.Point(589, 130);
            this.txtDesconto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.ShortcutsEnabled = false;
            this.txtDesconto.Size = new System.Drawing.Size(82, 22);
            this.txtDesconto.TabIndex = 159;
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMulta
            // 
            this.txtMulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMulta.Location = new System.Drawing.Point(372, 130);
            this.txtMulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMulta.Name = "txtMulta";
            this.txtMulta.ShortcutsEnabled = false;
            this.txtMulta.Size = new System.Drawing.Size(82, 22);
            this.txtMulta.TabIndex = 158;
            this.txtMulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtJuros
            // 
            this.txtJuros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJuros.Location = new System.Drawing.Point(482, 130);
            this.txtJuros.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJuros.Name = "txtJuros";
            this.txtJuros.ShortcutsEnabled = false;
            this.txtJuros.Size = new System.Drawing.Size(82, 22);
            this.txtJuros.TabIndex = 157;
            this.txtJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblValorFinal
            // 
            this.lblValorFinal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblValorFinal.Location = new System.Drawing.Point(21, 260);
            this.lblValorFinal.Name = "lblValorFinal";
            this.lblValorFinal.Size = new System.Drawing.Size(210, 20);
            this.lblValorFinal.TabIndex = 103;
            this.lblValorFinal.Text = "Valor Final da Parcela (R$)";
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(24, 278);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.ReadOnly = true;
            this.txtValorPago.ShortcutsEnabled = false;
            this.txtValorPago.Size = new System.Drawing.Size(131, 22);
            this.txtValorPago.TabIndex = 105;
            this.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCodFormaPagamento
            // 
            this.txtCodFormaPagamento.Location = new System.Drawing.Point(22, 201);
            this.txtCodFormaPagamento.Name = "txtCodFormaPagamento";
            this.txtCodFormaPagamento.ShortcutsEnabled = false;
            this.txtCodFormaPagamento.Size = new System.Drawing.Size(60, 22);
            this.txtCodFormaPagamento.TabIndex = 161;
            this.txtCodFormaPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFormaPagamento
            // 
            this.txtFormaPagamento.Location = new System.Drawing.Point(87, 201);
            this.txtFormaPagamento.Name = "txtFormaPagamento";
            this.txtFormaPagamento.ReadOnly = true;
            this.txtFormaPagamento.ShortcutsEnabled = false;
            this.txtFormaPagamento.Size = new System.Drawing.Size(214, 22);
            this.txtFormaPagamento.TabIndex = 162;
            // 
            // lblMotivoCancelamento
            // 
            this.lblMotivoCancelamento.Location = new System.Drawing.Point(21, 356);
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
            this.dtpDataPagamento.Location = new System.Drawing.Point(469, 201);
            this.dtpDataPagamento.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataPagamento.Name = "dtpDataPagamento";
            this.dtpDataPagamento.Size = new System.Drawing.Size(135, 22);
            this.dtpDataPagamento.TabIndex = 166;
            // 
            // txtMotivoCancelamento
            // 
            this.txtMotivoCancelamento.Location = new System.Drawing.Point(22, 375);
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
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 198);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 28);
            this.button1.TabIndex = 169;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmCadastroContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1041, 721);
            this.Controls.Add(this.button1);
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
            this.Controls.Add(this.txtCodFornecedor);
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
            this.Controls.SetChildIndex(this.txtCodFornecedor, 0);
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
            this.Controls.SetChildIndex(this.button1, 0);
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
        private System.Windows.Forms.TextBox txtCodFornecedor;
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
        private System.Windows.Forms.Button button1;
    }
}
