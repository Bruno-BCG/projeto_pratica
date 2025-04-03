namespace projeto_pratica
{
    partial class frmConsultaPais
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
			this.clNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clSigla = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clMoeda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clDDI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// btnExcluir
			// 

			// 
			// listV
			// 
			this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clNome,
            this.clSigla,
            this.clMoeda,
            this.clDDI});
			this.listV.SelectedIndexChanged += new System.EventHandler(this.ListV_SelectedIndexChanged);
			// 
			// clNome
			// 
			this.clNome.Text = "Nome";
			this.clNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clNome.Width = 200;
			// 
			// clSigla
			// 
			this.clSigla.Text = "Sigla";
			this.clSigla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// clMoeda
			// 
			this.clMoeda.Text = "Moeda";
			this.clMoeda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clMoeda.Width = 114;
			// 
			// clDDI
			// 
			this.clDDI.Text = "DDI";
			this.clDDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.clDDI.Width = 61;
			// 
			// frmConsultaPais
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(813, 450);
			this.Name = "frmConsultaPais";
			this.Text = "Consulta Países";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clNome;
        private System.Windows.Forms.ColumnHeader clSigla;
        private System.Windows.Forms.ColumnHeader clMoeda;
        private System.Windows.Forms.ColumnHeader clDDI;
    }
}
