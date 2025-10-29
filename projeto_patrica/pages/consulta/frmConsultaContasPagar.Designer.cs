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
            this.components = new System.ComponentModel.Container();
            this.clmModelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmModelo,
            this.clmSerie,
            this.clmNumNota,
            this.clmIdFornecedor,
            this.clmFornecedor,
            this.clmValorParcela,
            this.clmFormaPagamento,
            this.clmDataEmissao,
            this.clmDataVencimento,
            this.clmAtivo});
            // 
            // clmModelo
            // 
            this.clmModelo.Text = "Modelo";
            this.clmModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmModelo.Width = 80;
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
            this.clmIdFornecedor.Width = 100;
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
            this.clmValorParcela.Width = 100;
            // 
            // clmDataEmissao
            // 
            this.clmDataEmissao.Text = "Data Emissão";
            this.clmDataEmissao.Width = 120;
            // 
            // clmDataVencimento
            // 
            this.clmDataVencimento.Text = "Data Vencimento";
            this.clmDataVencimento.Width = 120;
            // 
            // clmAtivo
            // 
            this.clmAtivo.Text = "Status";
            this.clmAtivo.Width = 80;
            // 
            // clmFormaPagamento
            // 
            this.clmFormaPagamento.Text = "Forma de Pagamento";
            this.clmFormaPagamento.Width = 150;
          
        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmModelo;
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
    }
}
