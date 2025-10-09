namespace projeto_pratica.pages.consulta
{
    partial class frmConsultaNotasEntrada
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
            this.clmCodForn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDtEmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDtCheg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmModelo,
            this.clmSerie,
            this.clmNumero,
            this.clmCodForn,
            this.clmFornecedor,
            this.clmDtEmissao,
            this.clmDtCheg});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
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
            // clmCodForn
            // 
            this.clmCodForn.Text = "Cod. Fornecedor";
            this.clmCodForn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmCodForn.Width = 80;
            // 
            // clmFornecedor
            // 
            this.clmFornecedor.Text = "Fornecerdor";
            this.clmFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmFornecedor.Width = 240;
            // 
            // clmDtEmissao
            // 
            this.clmDtEmissao.Text = "Emissao";
            this.clmDtEmissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmDtEmissao.Width = 100;
            // 
            // clmDtCheg
            // 
            this.clmDtCheg.Text = "Chegada";
            this.clmDtCheg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmDtCheg.Width = 100;
            // 
            // frmConsultaNotasEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Name = "frmConsultaNotasEntrada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmModelo;
        private System.Windows.Forms.ColumnHeader clmSerie;
        private System.Windows.Forms.ColumnHeader clmNumero;
        private System.Windows.Forms.ColumnHeader clmCodForn;
        private System.Windows.Forms.ColumnHeader clmFornecedor;
        private System.Windows.Forms.ColumnHeader clmDtEmissao;
        private System.Windows.Forms.ColumnHeader clmDtCheg;
    }
}
