namespace projeto_pratica.pages.consulta
{
    partial class frmConsultaNotasSaida
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
            this.clmModelo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSerie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNumero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCodCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDtEmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMotivoCancelamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.clmNumero,
            this.clmCodCliente,
            this.clmCliente,
            this.clmDtEmissao,
            this.clmTotal,
            this.clmMotivoCancelamento,
            this.clmAtivo});
            this.listV.Size = new System.Drawing.Size(1288, 709);
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Text = "Visualizar";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5);
            // 
            // clmModelo
            // 
            this.clmModelo.Text = "Modelo";
            this.clmModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmModelo.Width = 80;
            // 
            // clmSerie
            // 
            this.clmSerie.Text = "Serie";
            this.clmSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmSerie.Width = 80;
            // 
            // clmNumero
            // 
            this.clmNumero.Text = "Numero";
            this.clmNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmNumero.Width = 100;
            // 
            // clmCodCliente
            // 
            this.clmCodCliente.Text = "Cod. Cliente";
            this.clmCodCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmCodCliente.Width = 80;
            // 
            // clmCliente
            // 
            this.clmCliente.Text = "Cliente";
            this.clmCliente.Width = 240;
            // 
            // clmDtEmissao
            // 
            this.clmDtEmissao.Text = "Emissao";
            this.clmDtEmissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmDtEmissao.Width = 100;
            // 
            // clmTotal
            // 
            this.clmTotal.Text = "Valor Total";
            this.clmTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmTotal.Width = 100;
            // 
            // clmMotivoCancelamento
            // 
            this.clmMotivoCancelamento.Text = "Motivo Cancelamento";
            this.clmMotivoCancelamento.Width = 360;
            // 
            // clmAtivo
            // 
            this.clmAtivo.Text = "Cancelado";
            this.clmAtivo.Width = 120;
            // 
            // frmConsultaNotasSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1344, 897);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmConsultaNotasSaida";
            this.Text = "Consulta de Notas de Saida";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmModelo;
        private System.Windows.Forms.ColumnHeader clmSerie;
        private System.Windows.Forms.ColumnHeader clmNumero;
        private System.Windows.Forms.ColumnHeader clmCodCliente;
        private System.Windows.Forms.ColumnHeader clmCliente;
        private System.Windows.Forms.ColumnHeader clmDtEmissao;
        private System.Windows.Forms.ColumnHeader clmTotal;
        private System.Windows.Forms.ColumnHeader clmMotivoCancelamento;
        private System.Windows.Forms.ColumnHeader clmAtivo;
    }
}
