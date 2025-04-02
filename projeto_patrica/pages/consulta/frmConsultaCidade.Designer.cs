namespace projeto_pratica
{
    partial class frmConsultaCidade
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
			this.clDDD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clIdEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// listV
			// 
			this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clNome,
            this.clDDD,
            this.clIdEstado,
            this.clEstado});
			this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
			// 
			// clNome
			// 
			this.clNome.Text = "Nome";
			this.clNome.Width = 198;
			// 
			// clDDD
			// 
			this.clDDD.Text = "DDD";
			// 
			// clEstado
			// 
			this.clEstado.Text = "Estado";
			this.clEstado.Width = 208;
			// 
			// clIdEstado
			// 
			this.clIdEstado.Text = "Cod. Estado";
			this.clIdEstado.Width = 86;
			// 
			// frmConsultaCidade
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(818, 461);
			this.Name = "frmConsultaCidade";
			this.Text = "Consulta Cidades";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clNome;
        private System.Windows.Forms.ColumnHeader clDDD;
        private System.Windows.Forms.ColumnHeader clEstado;
        private System.Windows.Forms.ColumnHeader clIdEstado;
    }
}
