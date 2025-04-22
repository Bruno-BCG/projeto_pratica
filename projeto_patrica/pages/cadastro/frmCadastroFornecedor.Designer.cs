namespace projeto_pratica.pages.cadastro
{
	partial class frmCadastroFornecedor
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
			// txtCpf
			// 
			this.txtCpf.Location = new System.Drawing.Point(23, 259);
			// 
			// lblCPF
			// 
			this.lblCPF.Location = new System.Drawing.Point(20, 240);
			// 
			// txtRg
			// 
			this.txtRg.Location = new System.Drawing.Point(224, 259);
			// 
			// lblRG
			// 
			this.lblRG.Location = new System.Drawing.Point(221, 240);
			// 
			// lblDtNascimento
			// 
			this.lblDtNascimento.Location = new System.Drawing.Point(432, 239);
			// 
			// dtpDataNascimento
			// 
			this.dtpDataNascimento.Location = new System.Drawing.Point(436, 259);
			this.dtpDataNascimento.Size = new System.Drawing.Size(173, 22);
			// 
			// rbtnFisicaqqq
			// 
			this.rbtnFisicaqqq.Checked = true;
			this.rbtnFisicaqqq.Location = new System.Drawing.Point(297, 12);
			this.rbtnFisicaqqq.CheckedChanged += new System.EventHandler(this.rbtnFisicaqqq_CheckedChanged);
			// 
			// rbtnJuridico
			// 
			this.rbtnJuridico.TabStop = false;
			this.rbtnJuridico.CheckedChanged += new System.EventHandler(this.rbtnJuridico_CheckedChanged);
			// 
			// btnPesquisarCidade
			// 
			this.btnPesquisarCidade.Click += new System.EventHandler(this.btnPesquisarCidade_Click);
			// 
			// lblTel
			// 
			this.lblTel.Location = new System.Drawing.Point(20, 307);
			// 
			// ckbStatus
			// 
			this.ckbStatus.Location = new System.Drawing.Point(627, 74);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(744, 664);
			// 
			// btnSair
			// 
			this.btnSair.Location = new System.Drawing.Point(867, 664);
			// 
			// frmCadastroFornecedor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Name = "frmCadastroFornecedor";
			this.Text = "Cadastro Fornecedor";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}
