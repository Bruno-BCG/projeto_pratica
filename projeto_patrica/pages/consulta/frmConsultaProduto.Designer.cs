namespace projeto_pratica.pages.consulta
{
    partial class frmConsultaProduto
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
            this.clmProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUniMed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCatego = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCusto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEstoque = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMarca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmProduto,
            this.clmUniMed,
            this.clmCatego,
            this.clmMarca,
            this.clmCusto,
            this.clmVenda,
            this.clmEstoque});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5);
            // 
            // clmProduto
            // 
            this.clmProduto.Text = "Produto";
            this.clmProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmProduto.Width = 320;
            // 
            // clmUniMed
            // 
            this.clmUniMed.Text = "Unidade Medida";
            this.clmUniMed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmUniMed.Width = 100;
            // 
            // clmCatego
            // 
            this.clmCatego.Text = "Categoria";
            this.clmCatego.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmCatego.Width = 120;
            // 
            // clmCusto
            // 
            this.clmCusto.Text = "Custo";
            this.clmCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmCusto.Width = 120;
            // 
            // clmVenda
            // 
            this.clmVenda.Text = "Valor Venda";
            this.clmVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmVenda.Width = 120;
            // 
            // clmEstoque
            // 
            this.clmEstoque.Text = "Estoque";
            this.clmEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmEstoque.Width = 120;
            // 
            // clmMarca
            // 
            this.clmMarca.Text = "Marca";
            this.clmMarca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmMarca.Width = 120;
            // 
            // frmConsultaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1344, 897);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmConsultaProduto";
            this.Text = "Consulta de Produto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader clmProduto;
        private System.Windows.Forms.ColumnHeader clmUniMed;
        private System.Windows.Forms.ColumnHeader clmCatego;
        private System.Windows.Forms.ColumnHeader clmCusto;
        private System.Windows.Forms.ColumnHeader clmVenda;
        private System.Windows.Forms.ColumnHeader clmEstoque;
        private System.Windows.Forms.ColumnHeader clmMarca;
    }
}
