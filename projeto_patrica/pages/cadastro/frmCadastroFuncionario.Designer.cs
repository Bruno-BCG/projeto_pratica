namespace projeto_pratica.pages.cadastro
{
	partial class frmCadastroFuncionario
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
			this.txtMatricula = new System.Windows.Forms.TextBox();
			this.lblMatricula = new System.Windows.Forms.Label();
			this.lblCargo = new System.Windows.Forms.Label();
			this.txtCargo = new System.Windows.Forms.TextBox();
			this.lblSalBruto = new System.Windows.Forms.Label();
			this.txtSalBruto = new System.Windows.Forms.TextBox();
			this.lblSalLiquido = new System.Windows.Forms.Label();
			this.txtSalLiquido = new System.Windows.Forms.TextBox();
			this.lblDtAdmissao = new System.Windows.Forms.Label();
			this.dtpDataAdmissao = new System.Windows.Forms.DateTimePicker();
			this.lblCargaHoraria = new System.Windows.Forms.Label();
			this.txtCargaHoraria = new System.Windows.Forms.TextBox();
			this.lblTurno = new System.Windows.Forms.Label();
			this.txtTurno = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtEmail
			// 
			this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
			// 
			// txtCpf
			// 
			this.txtCpf.Location = new System.Drawing.Point(23, 267);
			this.txtCpf.TabIndex = 11;
			// 
			// lblCPF
			// 
			this.lblCPF.Location = new System.Drawing.Point(20, 248);
			// 
			// txtRg
			// 
			this.txtRg.Location = new System.Drawing.Point(224, 267);
			this.txtRg.TabIndex = 12;
			// 
			// lblRG
			// 
			this.lblRG.Location = new System.Drawing.Point(221, 248);
			// 
			// lblDtNascimento
			// 
			this.lblDtNascimento.Location = new System.Drawing.Point(434, 246);
			// 
			// dtpDataNascimento
			// 
			this.dtpDataNascimento.CustomFormat = " dd MMM yyyy";
			this.dtpDataNascimento.Location = new System.Drawing.Point(436, 265);
			this.dtpDataNascimento.TabIndex = 13;
			this.dtpDataNascimento.Value = new System.DateTime(2025, 4, 9, 21, 24, 33, 0);
			// 
			// rbtnFisicaqqq
			// 
			this.rbtnFisicaqqq.Checked = true;
			this.rbtnFisicaqqq.Enabled = false;
			// 
			// rbtnJuridico
			// 
			this.rbtnJuridico.Enabled = false;
			this.rbtnJuridico.TabStop = false;
			// 
			// txtCidade
			// 
			this.txtCidade.TabIndex = 9;
			// 
			// txtCodCidade
			// 
			this.txtCodCidade.TabIndex = 8;
			// 
			// btnPesquisarCidade
			// 
			this.btnPesquisarCidade.TabIndex = 10;
			this.btnPesquisarCidade.Click += new System.EventHandler(this.btnPesquisarCidade_Click);
			// 
			// txtTel
			// 
			this.txtTel.TabIndex = 14;
			// 
			// ckbStatus
			// 
			this.ckbStatus.TabIndex = 15;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(719, 659);
			this.btnSave.TabIndex = 22;
			// 
			// lblDataAlteracao
			// 
			this.lblDataAlteracao.Location = new System.Drawing.Point(247, 646);
			// 
			// lblDataCriacao
			// 
			this.lblDataCriacao.Location = new System.Drawing.Point(29, 646);
			// 
			// lblUserAlt
			// 
			this.lblUserAlt.Location = new System.Drawing.Point(477, 646);
			// 
			// txtDtCriacao
			// 
			this.txtDtCriacao.Location = new System.Drawing.Point(32, 665);
			// 
			// txtDtAlt
			// 
			this.txtDtAlt.Location = new System.Drawing.Point(250, 665);
			// 
			// txtUserAlt
			// 
			this.txtUserAlt.Location = new System.Drawing.Point(480, 665);
			// 
			// btnSair
			// 
			this.btnSair.Location = new System.Drawing.Point(866, 659);
			this.btnSair.TabIndex = 23;
			// 
			// txtMatricula
			// 
			this.txtMatricula.Location = new System.Drawing.Point(23, 394);
			this.txtMatricula.Name = "txtMatricula";
			this.txtMatricula.Size = new System.Drawing.Size(173, 22);
			this.txtMatricula.TabIndex = 16;
			// 
			// lblMatricula
			// 
			this.lblMatricula.AutoSize = true;
			this.lblMatricula.Location = new System.Drawing.Point(20, 375);
			this.lblMatricula.Name = "lblMatricula";
			this.lblMatricula.Size = new System.Drawing.Size(61, 16);
			this.lblMatricula.TabIndex = 38;
			this.lblMatricula.Text = "Matricula";
			// 
			// lblCargo
			// 
			this.lblCargo.AutoSize = true;
			this.lblCargo.Location = new System.Drawing.Point(221, 375);
			this.lblCargo.Name = "lblCargo";
			this.lblCargo.Size = new System.Drawing.Size(44, 16);
			this.lblCargo.TabIndex = 40;
			this.lblCargo.Text = "Cargo";
			// 
			// txtCargo
			// 
			this.txtCargo.Location = new System.Drawing.Point(224, 394);
			this.txtCargo.Name = "txtCargo";
			this.txtCargo.Size = new System.Drawing.Size(173, 22);
			this.txtCargo.TabIndex = 17;
			// 
			// lblSalBruto
			// 
			this.lblSalBruto.AutoSize = true;
			this.lblSalBruto.Location = new System.Drawing.Point(20, 427);
			this.lblSalBruto.Name = "lblSalBruto";
			this.lblSalBruto.Size = new System.Drawing.Size(84, 16);
			this.lblSalBruto.TabIndex = 42;
			this.lblSalBruto.Text = "Salario Bruto";
			// 
			// txtSalBruto
			// 
			this.txtSalBruto.Location = new System.Drawing.Point(24, 446);
			this.txtSalBruto.Name = "txtSalBruto";
			this.txtSalBruto.Size = new System.Drawing.Size(172, 22);
			this.txtSalBruto.TabIndex = 18;
			// 
			// lblSalLiquido
			// 
			this.lblSalLiquido.AutoSize = true;
			this.lblSalLiquido.Location = new System.Drawing.Point(221, 427);
			this.lblSalLiquido.Name = "lblSalLiquido";
			this.lblSalLiquido.Size = new System.Drawing.Size(97, 16);
			this.lblSalLiquido.TabIndex = 44;
			this.lblSalLiquido.Text = "Salario Liquido";
			// 
			// txtSalLiquido
			// 
			this.txtSalLiquido.Location = new System.Drawing.Point(224, 446);
			this.txtSalLiquido.Name = "txtSalLiquido";
			this.txtSalLiquido.Size = new System.Drawing.Size(173, 22);
			this.txtSalLiquido.TabIndex = 19;
			// 
			// lblDtAdmissao
			// 
			this.lblDtAdmissao.AutoSize = true;
			this.lblDtAdmissao.Location = new System.Drawing.Point(433, 427);
			this.lblDtAdmissao.Name = "lblDtAdmissao";
			this.lblDtAdmissao.Size = new System.Drawing.Size(100, 16);
			this.lblDtAdmissao.TabIndex = 46;
			this.lblDtAdmissao.Text = "Data Admissao";
			// 
			// dtpDataAdmissao
			// 
			this.dtpDataAdmissao.Location = new System.Drawing.Point(436, 446);
			this.dtpDataAdmissao.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.dtpDataAdmissao.Name = "dtpDataAdmissao";
			this.dtpDataAdmissao.Size = new System.Drawing.Size(204, 22);
			this.dtpDataAdmissao.TabIndex = 20;
			// 
			// lblCargaHoraria
			// 
			this.lblCargaHoraria.AutoSize = true;
			this.lblCargaHoraria.Location = new System.Drawing.Point(624, 373);
			this.lblCargaHoraria.Name = "lblCargaHoraria";
			this.lblCargaHoraria.Size = new System.Drawing.Size(92, 16);
			this.lblCargaHoraria.TabIndex = 49;
			this.lblCargaHoraria.Text = "Carga Horaria";
			// 
			// txtCargaHoraria
			// 
			this.txtCargaHoraria.Location = new System.Drawing.Point(627, 392);
			this.txtCargaHoraria.Name = "txtCargaHoraria";
			this.txtCargaHoraria.Size = new System.Drawing.Size(137, 22);
			this.txtCargaHoraria.TabIndex = 21;
			// 
			// lblTurno
			// 
			this.lblTurno.AutoSize = true;
			this.lblTurno.Location = new System.Drawing.Point(433, 373);
			this.lblTurno.Name = "lblTurno";
			this.lblTurno.Size = new System.Drawing.Size(42, 16);
			this.lblTurno.TabIndex = 51;
			this.lblTurno.Text = "Turno";
			// 
			// txtTurno
			// 
			this.txtTurno.Location = new System.Drawing.Point(436, 392);
			this.txtTurno.Name = "txtTurno";
			this.txtTurno.Size = new System.Drawing.Size(137, 22);
			this.txtTurno.TabIndex = 50;
			// 
			// frmCadastroFuncionario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Controls.Add(this.lblTurno);
			this.Controls.Add(this.txtTurno);
			this.Controls.Add(this.lblCargaHoraria);
			this.Controls.Add(this.txtCargaHoraria);
			this.Controls.Add(this.dtpDataAdmissao);
			this.Controls.Add(this.lblDtAdmissao);
			this.Controls.Add(this.lblSalLiquido);
			this.Controls.Add(this.txtSalLiquido);
			this.Controls.Add(this.lblSalBruto);
			this.Controls.Add(this.txtSalBruto);
			this.Controls.Add(this.lblCargo);
			this.Controls.Add(this.txtCargo);
			this.Controls.Add(this.lblMatricula);
			this.Controls.Add(this.txtMatricula);
			this.Name = "frmCadastroFuncionario";
			this.Text = "Cadastro Funcionario";
			this.Load += new System.EventHandler(this.frmCadastroFuncionario_Load);
			this.Controls.SetChildIndex(this.txtMatricula, 0);
			this.Controls.SetChildIndex(this.lblMatricula, 0);
			this.Controls.SetChildIndex(this.txtCargo, 0);
			this.Controls.SetChildIndex(this.lblCargo, 0);
			this.Controls.SetChildIndex(this.txtSalBruto, 0);
			this.Controls.SetChildIndex(this.lblSalBruto, 0);
			this.Controls.SetChildIndex(this.txtSalLiquido, 0);
			this.Controls.SetChildIndex(this.lblSalLiquido, 0);
			this.Controls.SetChildIndex(this.lblDtAdmissao, 0);
			this.Controls.SetChildIndex(this.dtpDataAdmissao, 0);
			this.Controls.SetChildIndex(this.txtCargaHoraria, 0);
			this.Controls.SetChildIndex(this.lblCargaHoraria, 0);
			this.Controls.SetChildIndex(this.txtTurno, 0);
			this.Controls.SetChildIndex(this.lblTurno, 0);
			this.Controls.SetChildIndex(this.lblNum, 0);
			this.Controls.SetChildIndex(this.txtNum, 0);
			this.Controls.SetChildIndex(this.lblDataCriacao, 0);
			this.Controls.SetChildIndex(this.lblDataAlteracao, 0);
			this.Controls.SetChildIndex(this.lblUserAlt, 0);
			this.Controls.SetChildIndex(this.txtDtCriacao, 0);
			this.Controls.SetChildIndex(this.txtDtAlt, 0);
			this.Controls.SetChildIndex(this.txtUserAlt, 0);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtMatricula;
		private System.Windows.Forms.Label lblMatricula;
		private System.Windows.Forms.Label lblCargo;
		private System.Windows.Forms.TextBox txtCargo;
		private System.Windows.Forms.Label lblSalBruto;
		private System.Windows.Forms.TextBox txtSalBruto;
		private System.Windows.Forms.Label lblSalLiquido;
		private System.Windows.Forms.TextBox txtSalLiquido;
		private System.Windows.Forms.Label lblDtAdmissao;
		private System.Windows.Forms.DateTimePicker dtpDataAdmissao;
		private System.Windows.Forms.Label lblCargaHoraria;
		private System.Windows.Forms.TextBox txtCargaHoraria;
		private System.Windows.Forms.Label lblTurno;
		private System.Windows.Forms.TextBox txtTurno;
	}
}
