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
            this.lblLimiteCredito = new System.Windows.Forms.Label();
            this.txtLimiteCredito = new System.Windows.Forms.TextBox();
            this.btnPesquisarCondPag = new System.Windows.Forms.Button();
            this.lblCondPag = new System.Windows.Forms.Label();
            this.txtCondPag = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.Size = new System.Drawing.Size(56, 13);
            this.lblNome.Text = "CLIENTE*";
            // 
            // rbtnFisica
            // 
            this.rbtnFisica.Checked = true;
            this.rbtnFisica.Location = new System.Drawing.Point(282, 10);
            this.rbtnFisica.TabIndex = 29;
            this.rbtnFisica.CheckedChanged += new System.EventHandler(this.rbtnFisicaqqq_CheckedChanged);
            // 
            // rbtnJuridico
            // 
            this.rbtnJuridico.Location = new System.Drawing.Point(372, 10);
            this.rbtnJuridico.TabIndex = 28;
            this.rbtnJuridico.TabStop = false;
            this.rbtnJuridico.CheckedChanged += new System.EventHandler(this.rbtnJuridico_CheckedChanged);
            // 
            // btnPesquisarCidade
            // 
            this.btnPesquisarCidade.Click += new System.EventHandler(this.btnPesquisarCidade_Click);
            // 
            // btnSave
            // 
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.Location = new System.Drawing.Point(211, 529);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Location = new System.Drawing.Point(213, 544);
            // 
            // lblLimiteCredito
            // 
            this.lblLimiteCredito.AutoSize = true;
            this.lblLimiteCredito.Location = new System.Drawing.Point(324, 357);
            this.lblLimiteCredito.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLimiteCredito.Name = "lblLimiteCredito";
            this.lblLimiteCredito.Size = new System.Drawing.Size(117, 13);
            this.lblLimiteCredito.TabIndex = 49;
            this.lblLimiteCredito.Text = "LIMITE DE CRÉDITO; ";
            // 
            // txtLimiteCredito
            // 
            this.txtLimiteCredito.Location = new System.Drawing.Point(326, 372);
            this.txtLimiteCredito.Margin = new System.Windows.Forms.Padding(2);
            this.txtLimiteCredito.Name = "txtLimiteCredito";
            this.txtLimiteCredito.Size = new System.Drawing.Size(154, 20);
            this.txtLimiteCredito.TabIndex = 48;
            // 
            // btnPesquisarCondPag
            // 
            this.btnPesquisarCondPag.Location = new System.Drawing.Point(224, 370);
            this.btnPesquisarCondPag.Margin = new System.Windows.Forms.Padding(2);
            this.btnPesquisarCondPag.Name = "btnPesquisarCondPag";
            this.btnPesquisarCondPag.Size = new System.Drawing.Size(67, 24);
            this.btnPesquisarCondPag.TabIndex = 47;
            this.btnPesquisarCondPag.Text = "Pesquisar";
            this.btnPesquisarCondPag.UseVisualStyleBackColor = true;
            this.btnPesquisarCondPag.Click += new System.EventHandler(this.btnPesquisarCondPag_Click);
            // 
            // lblCondPag
            // 
            this.lblCondPag.AutoSize = true;
            this.lblCondPag.Location = new System.Drawing.Point(17, 357);
            this.lblCondPag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCondPag.Name = "lblCondPag";
            this.lblCondPag.Size = new System.Drawing.Size(155, 13);
            this.lblCondPag.TabIndex = 46;
            this.lblCondPag.Text = "CONDIÇÃO DE PAGAMENTO:";
            // 
            // txtCondPag
            // 
            this.txtCondPag.Enabled = false;
            this.txtCondPag.Location = new System.Drawing.Point(17, 372);
            this.txtCondPag.Margin = new System.Windows.Forms.Padding(2);
            this.txtCondPag.Name = "txtCondPag";
            this.txtCondPag.ReadOnly = true;
            this.txtCondPag.Size = new System.Drawing.Size(203, 20);
            this.txtCondPag.TabIndex = 45;
            // 
            // frmCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.lblLimiteCredito);
            this.Controls.Add(this.txtLimiteCredito);
            this.Controls.Add(this.btnPesquisarCondPag);
            this.Controls.Add(this.lblCondPag);
            this.Controls.Add(this.txtCondPag);
            this.Name = "frmCadastroCliente";
            this.Text = "Cadastro Cliente";
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

		protected System.Windows.Forms.Label lblLimiteCredito;
		protected System.Windows.Forms.TextBox txtLimiteCredito;
		private System.Windows.Forms.Button btnPesquisarCondPag;
		protected System.Windows.Forms.Label lblCondPag;
		protected System.Windows.Forms.TextBox txtCondPag;
	}
}
