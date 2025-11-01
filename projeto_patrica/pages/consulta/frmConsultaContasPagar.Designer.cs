namespace projeto_pratica.pages.consulta
{
    partial class frmConsultaContasPagar
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
            this.clmSerie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNumNota = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmIdFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmValorParcela = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataEmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDataVencimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFiltros = new System.Windows.Forms.Label();
            this.btnDarBaixa = new System.Windows.Forms.Button();
            this.clmFormaPagamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBaixa = new System.Windows.Forms.Button();
            this.clmNumParc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmModelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMotCancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExcluir
            // 
            this.btnExcluir.Text = "Cancelar";
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmModelo,
            this.clmSerie,
            this.clmNumNota,
            this.clmIdFornecedor,
            this.clmFornecedor,
            this.clmNumParc,
            this.clmValorParcela,
            this.clmFormaPagamento,
            this.clmDataEmissao,
            this.clmDataVencimento,
            this.clmAtivo,
            this.clmMotCancel});
            this.listV.Location = new System.Drawing.Point(24, 85);
            this.listV.Size = new System.Drawing.Size(1288, 709);
            this.listV.SelectedIndexChanged += new System.EventHandler(this.ListV_SelectedIndexChanged);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Text = "Visualizar";
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(703, 819);
            // 
            // clmSerie
            // 
            this.clmSerie.Text = "Série";
            this.clmSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmSerie.Width = 80;
            // 
            // clmNumNota
            // 
            this.clmNumNota.Text = "Nº Nota";
            this.clmNumNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmNumNota.Width = 150;
            // 
            // clmIdFornecedor
            // 
            this.clmIdFornecedor.Text = "Cód. Fornecedor";
            this.clmIdFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmIdFornecedor.Width = 136;
            // 
            // clmFornecedor
            // 
            this.clmFornecedor.Text = "Fornecedor";
            this.clmFornecedor.Width = 250;
            // 
            // clmValorParcela
            // 
            this.clmValorParcela.Text = "Valor da Parcela";
            this.clmValorParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmValorParcela.Width = 147;
            // 
            // clmDataEmissao
            // 
            this.clmDataEmissao.Text = "Data Emissão";
            this.clmDataEmissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmDataEmissao.Width = 120;
            // 
            // clmDataVencimento
            // 
            this.clmDataVencimento.Text = "Data Vencimento";
            this.clmDataVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmDataVencimento.Width = 120;
            // 
            // clmAtivo
            // 
            this.clmAtivo.Text = "Status";
            this.clmAtivo.Width = 80;
            // 
            // lblFiltros
            // 
            this.lblFiltros.Location = new System.Drawing.Point(0, 0);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(100, 23);
            this.lblFiltros.TabIndex = 0;
            // 
            // btnDarBaixa
            // 
            this.btnDarBaixa.Location = new System.Drawing.Point(0, 0);
            this.btnDarBaixa.Name = "btnDarBaixa";
            this.btnDarBaixa.Size = new System.Drawing.Size(75, 23);
            this.btnDarBaixa.TabIndex = 0;
            // 
            // clmFormaPagamento
            // 
            this.clmFormaPagamento.Text = "Forma de Pagamento";
            this.clmFormaPagamento.Width = 150;
            // 
            // btnBaixa
            // 
            this.btnBaixa.Location = new System.Drawing.Point(826, 820);
            this.btnBaixa.Name = "btnBaixa";
            this.btnBaixa.Size = new System.Drawing.Size(117, 33);
            this.btnBaixa.TabIndex = 8;
            this.btnBaixa.Text = "Dar Baixa";
            this.btnBaixa.UseVisualStyleBackColor = true;
            this.btnBaixa.Click += new System.EventHandler(this.btnBaixa_Click);
            // 
            // clmNumParc
            // 
            this.clmNumParc.Text = "Numero Parcela";
            this.clmNumParc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmNumParc.Width = 120;
            // 
            // clmModelo
            // 
            this.clmModelo.Text = "Modelo";
            this.clmModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmModelo.Width = 120;
            // 
            // clmMotCancel
            // 
            this.clmMotCancel.Text = "Motivo Cancelamento";
            this.clmMotCancel.Width = 320;
            // 
            // frmConsultaContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1344, 897);
            this.Controls.Add(this.btnBaixa);
            this.Name = "frmConsultaContasPagar";
            this.Controls.SetChildIndex(this.btnExcluir, 0);
            this.Controls.SetChildIndex(this.btnAlterar, 0);
            this.Controls.SetChildIndex(this.btnIncluir, 0);
            this.Controls.SetChildIndex(this.listV, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.btnBaixa, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader clmSerie;
        private System.Windows.Forms.ColumnHeader clmNumNota;
        private System.Windows.Forms.ColumnHeader clmIdFornecedor;
        private System.Windows.Forms.ColumnHeader clmFornecedor;
        private System.Windows.Forms.ColumnHeader clmValorParcela;
        private System.Windows.Forms.ColumnHeader clmDataEmissao;
        private System.Windows.Forms.ColumnHeader clmDataVencimento;
        private System.Windows.Forms.ColumnHeader clmAtivo;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.ComboBox comboBoxFiltroStatus;
        private System.Windows.Forms.Button btnDarBaixa;
        private System.Windows.Forms.ColumnHeader clmFormaPagamento;
        private System.Windows.Forms.Button btnBaixa;
        private System.Windows.Forms.ColumnHeader clmNumParc;
        private System.Windows.Forms.ColumnHeader clmModelo;
        private System.Windows.Forms.ColumnHeader clmMotCancel;
    }
}
