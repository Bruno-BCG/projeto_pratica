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
            this.clmJuro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMulta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDesct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDescricao,
            this.clmParcelas,
            this.clmJuro,
            this.clmMulta,
            this.clmDesct});
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clmCod
            // 
            this.clmCod.Width = 100;
            // 
            // clmDescricao
            // 
            this.clmDescricao.Text = "Descricao";
            this.clmDescricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmDescricao.Width = 120;
            // 
            // clmParcelas
            // 
            this.clmParcelas.Text = "Parcelas";
            this.clmParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmParcelas.Width = 80;
            // 
            // clmJuro
            // 
            this.clmJuro.Text = "Juro";
            this.clmJuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmJuro.Width = 80;
            // 
            // clmMulta
            // 
            this.clmMulta.Text = "Multa";
            this.clmMulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmMulta.Width = 80;
            // 
            // clmDesct
            // 
            this.clmDesct.Text = "Desconto";
            this.clmDesct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmDesct.Width = 80;
            // 
            // frmConsultaCondPag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 729);
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
		private System.Windows.Forms.ColumnHeader clmJuro;
		private System.Windows.Forms.ColumnHeader clmMulta;
		private System.Windows.Forms.ColumnHeader clmDesct;
	}
}
