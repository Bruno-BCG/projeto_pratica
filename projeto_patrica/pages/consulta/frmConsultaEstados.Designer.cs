namespace projeto_pratica
{
    partial class frmConsultaEstados
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
			this.clUF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clPais = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clIdPais = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// listV
			// 
			this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clNome,
            this.clUF,
            this.clPais,
            this.clIdPais});
			this.listV.Location = new System.Drawing.Point(24, 75);
			this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
			// 
			// clNome
			// 
			this.clNome.Text = "Nome";
			this.clNome.Width = 116;
			// 
			// clUF
			// 
			this.clUF.Text = "UF";
			this.clUF.Width = 173;
			// 
			// clPais
			// 
			this.clPais.Text = "Pais";
			this.clPais.Width = 200;
			// 
			// clIdPais
			// 
			this.clIdPais.Text = "Cod. Pais";
			this.clIdPais.Width = 140;
			// 
			// frmConsultaEstados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Name = "frmConsultaEstados";
			this.Text = "Consulta Estados";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clNome;
        private System.Windows.Forms.ColumnHeader clUF;
        private System.Windows.Forms.ColumnHeader clPais;
        private System.Windows.Forms.ColumnHeader clIdPais;
    }
}
