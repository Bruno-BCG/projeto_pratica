namespace projeto_pratica.pages.cadastro
{
	partial class frmCadastroCliente
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
			this.SuspendLayout();
			// 
			// rbtnFisicaqqq
			// 
			this.rbtnFisicaqqq.Checked = true;
			this.rbtnFisicaqqq.TabIndex = 29;
			this.rbtnFisicaqqq.CheckedChanged += new System.EventHandler(this.rbtnFisicaqqq_CheckedChanged);
			// 
			// rbtnJuridico
			// 
			this.rbtnJuridico.TabIndex = 28;
			this.rbtnJuridico.TabStop = false;
			this.rbtnJuridico.CheckedChanged += new System.EventHandler(this.rbtnJuridico_CheckedChanged);
			// 
			// btnPesquisarCidade
			// 
			this.btnPesquisarCidade.Click += new System.EventHandler(this.btnPesquisarCidade_Click);
			// 
			// lblDataAlteracao
			// 
			this.lblDataAlteracao.Location = new System.Drawing.Point(281, 651);
			// 
			// txtDtAlt
			// 
			this.txtDtAlt.Location = new System.Drawing.Point(284, 670);
			// 
			// frmCadastroCliente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Name = "frmCadastroCliente";
			this.Text = "Cadastro Cliente";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}
