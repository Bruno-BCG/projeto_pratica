﻿namespace projeto_pratica.pages.cadastro
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
            this.txtCondPag = new System.Windows.Forms.TextBox();
            this.lblCondPag = new System.Windows.Forms.Label();
            this.btnPesquisarCondPag = new System.Windows.Forms.Button();
            this.txtLimiteCredito = new System.Windows.Forms.TextBox();
            this.lblLimiteCredito = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // txtApelido
            // 
            this.txtApelido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // lblNome
            // 
            this.lblNome.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblNome.Size = new System.Drawing.Size(86, 13);
            this.lblNome.Text = "FORNECEDOR*";
            // 
            // txtEmail
            // 
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(17, 270);
            this.txtCpf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // lblCPF
            // 
            this.lblCPF.Location = new System.Drawing.Point(17, 254);
            this.lblCPF.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // txtRg
            // 
            this.txtRg.Location = new System.Drawing.Point(216, 270);
            this.txtRg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // lblRG
            // 
            this.lblRG.Location = new System.Drawing.Point(214, 254);
            this.lblRG.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // lblDtNascimento
            // 
            this.lblDtNascimento.Location = new System.Drawing.Point(398, 254);
            this.lblDtNascimento.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.Location = new System.Drawing.Point(401, 270);
            this.dtpDataNascimento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDataNascimento.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDataNascimento.Size = new System.Drawing.Size(131, 20);
            // 
            // rbtnFisica
            // 
            this.rbtnFisica.Checked = true;
            this.rbtnFisica.Location = new System.Drawing.Point(284, 10);
            this.rbtnFisica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnFisica.CheckedChanged += new System.EventHandler(this.rbtnFisicaqqq_CheckedChanged);
            // 
            // rbtnJuridico
            // 
            this.rbtnJuridico.Location = new System.Drawing.Point(374, 10);
            this.rbtnJuridico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnJuridico.TabStop = false;
            this.rbtnJuridico.CheckedChanged += new System.EventHandler(this.rbtnJuridico_CheckedChanged);
            // 
            // txtEndereco
            // 
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // txtCep
            // 
            this.txtCep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // txtBairro
            // 
            this.txtBairro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(124, 214);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCidade.Size = new System.Drawing.Size(198, 20);
            // 
            // lblNomCidade
            // 
            this.lblNomCidade.Location = new System.Drawing.Point(122, 199);
            this.lblNomCidade.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // txtCodCidade
            // 
            this.txtCodCidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // lblCodCidade
            // 
            this.lblCodCidade.Location = new System.Drawing.Point(15, 199);
            this.lblCodCidade.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // btnPesquisarCidade
            // 
            this.btnPesquisarCidade.Location = new System.Drawing.Point(338, 212);
            this.btnPesquisarCidade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPesquisarCidade.Click += new System.EventHandler(this.btnPesquisarCidade_Click);
            // 
            // txtTel
            // 
            this.txtTel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // txtNum
            // 
            this.txtNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(416, 199);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // txtComple
            // 
            this.txtComple.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // txtEstado
            // 
            this.txtEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(558, 540);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(626, 60);
            this.ckbStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(650, 540);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // txtCondPag
            // 
            this.txtCondPag.Enabled = false;
            this.txtCondPag.Location = new System.Drawing.Point(17, 368);
            this.txtCondPag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCondPag.Name = "txtCondPag";
            this.txtCondPag.ReadOnly = true;
            this.txtCondPag.Size = new System.Drawing.Size(203, 20);
            this.txtCondPag.TabIndex = 40;
            // 
            // lblCondPag
            // 
            this.lblCondPag.AutoSize = true;
            this.lblCondPag.Location = new System.Drawing.Point(17, 353);
            this.lblCondPag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCondPag.Name = "lblCondPag";
            this.lblCondPag.Size = new System.Drawing.Size(156, 13);
            this.lblCondPag.TabIndex = 41;
            this.lblCondPag.Text = "CONDIÇÃO DE PAGAMENTO*";
            // 
            // btnPesquisarCondPag
            // 
            this.btnPesquisarCondPag.Location = new System.Drawing.Point(224, 366);
            this.btnPesquisarCondPag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPesquisarCondPag.Name = "btnPesquisarCondPag";
            this.btnPesquisarCondPag.Size = new System.Drawing.Size(67, 24);
            this.btnPesquisarCondPag.TabIndex = 42;
            this.btnPesquisarCondPag.Text = "Pesquisar";
            this.btnPesquisarCondPag.UseVisualStyleBackColor = true;
            this.btnPesquisarCondPag.Click += new System.EventHandler(this.lblPesquisarCondPag_Click);
            // 
            // txtLimiteCredito
            // 
            this.txtLimiteCredito.Location = new System.Drawing.Point(326, 368);
            this.txtLimiteCredito.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLimiteCredito.Name = "txtLimiteCredito";
            this.txtLimiteCredito.Size = new System.Drawing.Size(154, 20);
            this.txtLimiteCredito.TabIndex = 43;
            // 
            // lblLimiteCredito
            // 
            this.lblLimiteCredito.AutoSize = true;
            this.lblLimiteCredito.Location = new System.Drawing.Point(324, 353);
            this.lblLimiteCredito.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLimiteCredito.Name = "lblLimiteCredito";
            this.lblLimiteCredito.Size = new System.Drawing.Size(111, 13);
            this.lblLimiteCredito.TabIndex = 44;
            this.lblLimiteCredito.Text = "LIMITE DE CRÉDITO";
            // 
            // frmCadastroFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.lblLimiteCredito);
            this.Controls.Add(this.txtLimiteCredito);
            this.Controls.Add(this.btnPesquisarCondPag);
            this.Controls.Add(this.lblCondPag);
            this.Controls.Add(this.txtCondPag);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmCadastroFornecedor";
            this.Text = "Cadastro Fornecedor";
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.rbtnFisica, 0);
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
            this.Controls.SetChildIndex(this.lblCodCidade, 0);
            this.Controls.SetChildIndex(this.txtCodCidade, 0);
            this.Controls.SetChildIndex(this.lblNomCidade, 0);
            this.Controls.SetChildIndex(this.txtCidade, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCidade, 0);
            this.Controls.SetChildIndex(this.lblTel, 0);
            this.Controls.SetChildIndex(this.txtTel, 0);
            this.Controls.SetChildIndex(this.ckbStatus, 0);
            this.Controls.SetChildIndex(this.lblNum, 0);
            this.Controls.SetChildIndex(this.txtNum, 0);
            this.Controls.SetChildIndex(this.txtComple, 0);
            this.Controls.SetChildIndex(this.lblComple, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.lblDataCriacao, 0);
            this.Controls.SetChildIndex(this.lblDataAlteracao, 0);
            this.Controls.SetChildIndex(this.lblUserAlt, 0);
            this.Controls.SetChildIndex(this.txtDtCriacao, 0);
            this.Controls.SetChildIndex(this.txtDtAlt, 0);
            this.Controls.SetChildIndex(this.txtUserAlt, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblCod, 0);
            this.Controls.SetChildIndex(this.txtCondPag, 0);
            this.Controls.SetChildIndex(this.lblCondPag, 0);
            this.Controls.SetChildIndex(this.btnPesquisarCondPag, 0);
            this.Controls.SetChildIndex(this.txtLimiteCredito, 0);
            this.Controls.SetChildIndex(this.lblLimiteCredito, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnPesquisarCondPag;
		protected System.Windows.Forms.Label lblCondPag;
		protected System.Windows.Forms.TextBox txtCondPag;
		protected System.Windows.Forms.TextBox txtLimiteCredito;
		protected System.Windows.Forms.Label lblLimiteCredito;
	}
}
