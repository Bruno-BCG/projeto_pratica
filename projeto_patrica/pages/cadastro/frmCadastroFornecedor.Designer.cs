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
			this.lblInscrEst = new System.Windows.Forms.Label();
			this.txtInscEst = new System.Windows.Forms.TextBox();
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
			this.lblDtNascimento.Location = new System.Drawing.Point(623, 239);
			// 
			// dtpDataNascimento
			// 
			this.dtpDataNascimento.Location = new System.Drawing.Point(627, 259);
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
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(627, 398);
			// 
			// btnSair
			// 
			this.btnSair.Location = new System.Drawing.Point(720, 398);
			// 
			// lblInscrEst
			// 
			this.lblInscrEst.AutoSize = true;
			this.lblInscrEst.Location = new System.Drawing.Point(433, 240);
			this.lblInscrEst.Name = "lblInscrEst";
			this.lblInscrEst.Size = new System.Drawing.Size(117, 16);
			this.lblInscrEst.TabIndex = 38;
			this.lblInscrEst.Text = "Inscrição Estadual";
			// 
			// txtInscEst
			// 
			this.txtInscEst.Location = new System.Drawing.Point(436, 258);
			this.txtInscEst.Name = "txtInscEst";
			this.txtInscEst.Size = new System.Drawing.Size(147, 22);
			this.txtInscEst.TabIndex = 39;
			// 
			// frmCadastroFornecedor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(826, 468);
			this.Controls.Add(this.txtInscEst);
			this.Controls.Add(this.lblInscrEst);
			this.Name = "frmCadastroFornecedor";
			this.Text = "Cadastro Fornecedor";
			this.Controls.SetChildIndex(this.lblNome, 0);
			this.Controls.SetChildIndex(this.txtNome, 0);
			this.Controls.SetChildIndex(this.rbtnFisicaqqq, 0);
			this.Controls.SetChildIndex(this.rbtnJuridico, 0);
			this.Controls.SetChildIndex(this.lblApelido, 0);
			this.Controls.SetChildIndex(this.txtApelido, 0);
			this.Controls.SetChildIndex(this.lblEmail, 0);
			this.Controls.SetChildIndex(this.txtEmail, 0);
			this.Controls.SetChildIndex(this.lblCPF, 0);
			this.Controls.SetChildIndex(this.txtCpf, 0);
			this.Controls.SetChildIndex(this.lblRG, 0);
			this.Controls.SetChildIndex(this.txtRg, 0);
			this.Controls.SetChildIndex(this.lblDtNascimento, 0);
			this.Controls.SetChildIndex(this.dtpDataNascimento, 0);
			this.Controls.SetChildIndex(this.lblEndereco, 0);
			this.Controls.SetChildIndex(this.txtEndereco, 0);
			this.Controls.SetChildIndex(this.lblCEP, 0);
			this.Controls.SetChildIndex(this.txtCep, 0);
			this.Controls.SetChildIndex(this.lblBairro, 0);
			this.Controls.SetChildIndex(this.txtBairro, 0);
			this.Controls.SetChildIndex(this.btnSair, 0);
			this.Controls.SetChildIndex(this.txtCodigo, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.lblCod, 0);
			this.Controls.SetChildIndex(this.lblCodCidade, 0);
			this.Controls.SetChildIndex(this.txtCodCidade, 0);
			this.Controls.SetChildIndex(this.lblNomCidade, 0);
			this.Controls.SetChildIndex(this.txtCidade, 0);
			this.Controls.SetChildIndex(this.btnPesquisarCidade, 0);
			this.Controls.SetChildIndex(this.lblTel, 0);
			this.Controls.SetChildIndex(this.txtTel, 0);
			this.Controls.SetChildIndex(this.ckbStatus, 0);
			this.Controls.SetChildIndex(this.lblInscrEst, 0);
			this.Controls.SetChildIndex(this.txtInscEst, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblInscrEst;
		private System.Windows.Forms.TextBox txtInscEst;
	}
}
