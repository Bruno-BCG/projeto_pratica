namespace projeto_pratica.pages.consulta
{
	partial class frmConsultaCondPag
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.clmDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clmParcelas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// listV
			// 
			this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDescricao,
            this.clmParcelas});
			this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
			// 
			// clmDescricao
			// 
			this.clmDescricao.Text = "Descricao";
			this.clmDescricao.Width = 120;
			// 
			// clmParcelas
			// 
			this.clmParcelas.Text = "Parcelas";
			this.clmParcelas.Width = 80;
			// 
			// frmConsultaCondPag
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Name = "frmConsultaCondPag";
			this.ShowIcon = true;
			this.Text = "Consulta de Condicao de Pagamentos";
			this.Load += new System.EventHandler(this.frmConsultaCondPag_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.ColumnHeader clmDescricao;
		private System.Windows.Forms.ColumnHeader clmParcelas;
	}
}
