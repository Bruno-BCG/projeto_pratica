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
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clNome,
            this.clUF,
            this.clPais});
            this.listV.Location = new System.Drawing.Point(18, 61);
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clNome
            // 
            this.clNome.Text = "Nome";
            this.clNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clNome.Width = 120;
            // 
            // clUF
            // 
            this.clUF.Text = "UF";
            this.clUF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clUF.Width = 120;
            // 
            // clPais
            // 
            this.clPais.Text = "Pais";
            this.clPais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clPais.Width = 120;
            // 
            // frmConsultaEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Name = "frmConsultaEstados";
            this.Text = "Consulta Estados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clNome;
        private System.Windows.Forms.ColumnHeader clUF;
        private System.Windows.Forms.ColumnHeader clPais;
    }
}
