﻿namespace projeto_pratica.pages.cadastro
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
            this.dtpDataDemissao = new System.Windows.Forms.DateTimePicker();
            this.lblDtDemissao = new System.Windows.Forms.Label();
            this.cbTurno = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.Size = new System.Drawing.Size(85, 13);
            this.lblNome.Text = "FUNCIONARIO*";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(169, 320);
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(166, 305);
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(17, 260);
            this.txtCpf.TabIndex = 11;
            // 
            // lblCPF
            // 
            this.lblCPF.Location = new System.Drawing.Point(17, 245);
            // 
            // txtRg
            // 
            this.txtRg.Location = new System.Drawing.Point(226, 260);
            this.txtRg.TabIndex = 12;
            // 
            // lblRG
            // 
            this.lblRG.Location = new System.Drawing.Point(224, 245);
            // 
            // lblDtNascimento
            // 
            this.lblDtNascimento.Location = new System.Drawing.Point(412, 243);
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.CustomFormat = " dd MMM yyyy";
            this.dtpDataNascimento.Location = new System.Drawing.Point(413, 258);
            this.dtpDataNascimento.TabIndex = 13;
            this.dtpDataNascimento.Value = new System.DateTime(2025, 4, 9, 21, 24, 33, 0);
            // 
            // rbtnFisica
            // 
            this.rbtnFisica.Checked = true;
            this.rbtnFisica.Enabled = false;
            // 
            // rbtnJuridico
            // 
            this.rbtnJuridico.Enabled = false;
            this.rbtnJuridico.TabStop = false;
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(129, 210);
            this.txtCidade.TabIndex = 9;
            // 
            // lblNomCidade
            // 
            this.lblNomCidade.Location = new System.Drawing.Point(127, 195);
            // 
            // txtCodCidade
            // 
            this.txtCodCidade.Location = new System.Drawing.Point(17, 210);
            this.txtCodCidade.TabIndex = 8;
            // 
            // lblCodCidade
            // 
            this.lblCodCidade.Location = new System.Drawing.Point(17, 195);
            // 
            // btnPesquisarCidade
            // 
            this.btnPesquisarCidade.Location = new System.Drawing.Point(345, 208);
            this.btnPesquisarCidade.TabIndex = 10;
            this.btnPesquisarCidade.Click += new System.EventHandler(this.btnPesquisarCidade_Click);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(17, 320);
            this.txtTel.TabIndex = 14;
            // 
            // lblTel
            // 
            this.lblTel.Location = new System.Drawing.Point(16, 305);
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(424, 195);
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(426, 210);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(539, 535);
            this.btnSave.TabIndex = 22;
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.Location = new System.Drawing.Point(185, 525);
            // 
            // lblDataCriacao
            // 
            this.lblDataCriacao.Location = new System.Drawing.Point(22, 525);
            // 
            // lblUserAlt
            // 
            this.lblUserAlt.Location = new System.Drawing.Point(358, 525);
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Location = new System.Drawing.Point(24, 540);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Location = new System.Drawing.Point(188, 540);
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Location = new System.Drawing.Point(360, 540);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(641, 60);
            this.ckbStatus.TabIndex = 15;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(650, 535);
            this.btnSair.TabIndex = 23;
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(17, 423);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(131, 20);
            this.txtMatricula.TabIndex = 16;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Location = new System.Drawing.Point(15, 408);
            this.lblMatricula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(50, 13);
            this.lblMatricula.TabIndex = 38;
            this.lblMatricula.Text = "Matricula";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(166, 408);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(35, 13);
            this.lblCargo.TabIndex = 40;
            this.lblCargo.Text = "Cargo";
            this.lblCargo.Click += new System.EventHandler(this.lblCargo_Click);
            // 
            // txtCargo
            // 
            this.txtCargo.Location = new System.Drawing.Point(168, 423);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(131, 20);
            this.txtCargo.TabIndex = 17;
            // 
            // lblSalBruto
            // 
            this.lblSalBruto.AutoSize = true;
            this.lblSalBruto.Location = new System.Drawing.Point(15, 357);
            this.lblSalBruto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSalBruto.Name = "lblSalBruto";
            this.lblSalBruto.Size = new System.Drawing.Size(67, 13);
            this.lblSalBruto.TabIndex = 42;
            this.lblSalBruto.Text = "Salario Bruto";
            this.lblSalBruto.Click += new System.EventHandler(this.lblSalBruto_Click);
            // 
            // txtSalBruto
            // 
            this.txtSalBruto.Location = new System.Drawing.Point(17, 372);
            this.txtSalBruto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSalBruto.Name = "txtSalBruto";
            this.txtSalBruto.Size = new System.Drawing.Size(130, 20);
            this.txtSalBruto.TabIndex = 18;
            // 
            // lblSalLiquido
            // 
            this.lblSalLiquido.AutoSize = true;
            this.lblSalLiquido.Location = new System.Drawing.Point(163, 357);
            this.lblSalLiquido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSalLiquido.Name = "lblSalLiquido";
            this.lblSalLiquido.Size = new System.Drawing.Size(76, 13);
            this.lblSalLiquido.TabIndex = 44;
            this.lblSalLiquido.Text = "Salario Liquido";
            this.lblSalLiquido.Click += new System.EventHandler(this.lblSalLiquido_Click);
            // 
            // txtSalLiquido
            // 
            this.txtSalLiquido.Location = new System.Drawing.Point(165, 372);
            this.txtSalLiquido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSalLiquido.Name = "txtSalLiquido";
            this.txtSalLiquido.Size = new System.Drawing.Size(131, 20);
            this.txtSalLiquido.TabIndex = 19;
            // 
            // lblDtAdmissao
            // 
            this.lblDtAdmissao.AutoSize = true;
            this.lblDtAdmissao.Location = new System.Drawing.Point(322, 357);
            this.lblDtAdmissao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDtAdmissao.Name = "lblDtAdmissao";
            this.lblDtAdmissao.Size = new System.Drawing.Size(78, 13);
            this.lblDtAdmissao.TabIndex = 46;
            this.lblDtAdmissao.Text = "Data Admissao";
            // 
            // dtpDataAdmissao
            // 
            this.dtpDataAdmissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataAdmissao.Location = new System.Drawing.Point(324, 372);
            this.dtpDataAdmissao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDataAdmissao.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataAdmissao.Name = "dtpDataAdmissao";
            this.dtpDataAdmissao.Size = new System.Drawing.Size(154, 20);
            this.dtpDataAdmissao.TabIndex = 20;
            // 
            // lblCargaHoraria
            // 
            this.lblCargaHoraria.AutoSize = true;
            this.lblCargaHoraria.Location = new System.Drawing.Point(468, 406);
            this.lblCargaHoraria.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCargaHoraria.Name = "lblCargaHoraria";
            this.lblCargaHoraria.Size = new System.Drawing.Size(72, 13);
            this.lblCargaHoraria.TabIndex = 49;
            this.lblCargaHoraria.Text = "Carga Horaria";
            // 
            // txtCargaHoraria
            // 
            this.txtCargaHoraria.Location = new System.Drawing.Point(470, 422);
            this.txtCargaHoraria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCargaHoraria.Name = "txtCargaHoraria";
            this.txtCargaHoraria.Size = new System.Drawing.Size(104, 20);
            this.txtCargaHoraria.TabIndex = 21;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(325, 406);
            this.lblTurno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(35, 13);
            this.lblTurno.TabIndex = 51;
            this.lblTurno.Text = "Turno";
            this.lblTurno.Click += new System.EventHandler(this.lblTurno_Click);
            // 
            // dtpDataDemissao
            // 
            this.dtpDataDemissao.Enabled = false;
            this.dtpDataDemissao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDemissao.Location = new System.Drawing.Point(506, 370);
            this.dtpDataDemissao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDataDemissao.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataDemissao.Name = "dtpDataDemissao";
            this.dtpDataDemissao.Size = new System.Drawing.Size(154, 20);
            this.dtpDataDemissao.TabIndex = 52;
            // 
            // lblDtDemissao
            // 
            this.lblDtDemissao.AutoSize = true;
            this.lblDtDemissao.Location = new System.Drawing.Point(503, 355);
            this.lblDtDemissao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDtDemissao.Name = "lblDtDemissao";
            this.lblDtDemissao.Size = new System.Drawing.Size(79, 13);
            this.lblDtDemissao.TabIndex = 53;
            this.lblDtDemissao.Text = "Data Demissão";
            // 
            // cbTurno
            // 
            this.cbTurno.FormattingEnabled = true;
            this.cbTurno.Items.AddRange(new object[] {
            "Diurno",
            "Vespertino",
            "Noturno"});
            this.cbTurno.Location = new System.Drawing.Point(326, 423);
            this.cbTurno.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTurno.Name = "cbTurno";
            this.cbTurno.Size = new System.Drawing.Size(111, 21);
            this.cbTurno.TabIndex = 54;
            // 
            // frmCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.cbTurno);
            this.Controls.Add(this.dtpDataDemissao);
            this.Controls.Add(this.lblDtDemissao);
            this.Controls.Add(this.lblTurno);
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
            this.Controls.SetChildIndex(this.txtComple, 0);
            this.Controls.SetChildIndex(this.lblComple, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
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
            this.Controls.SetChildIndex(this.lblDtDemissao, 0);
            this.Controls.SetChildIndex(this.dtpDataDemissao, 0);
            this.Controls.SetChildIndex(this.cbTurno, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.DateTimePicker dtpDataDemissao;
		protected System.Windows.Forms.Label lblDtDemissao;
		protected System.Windows.Forms.TextBox txtMatricula;
		protected System.Windows.Forms.Label lblMatricula;
		protected System.Windows.Forms.Label lblCargo;
		protected System.Windows.Forms.TextBox txtCargo;
		protected System.Windows.Forms.Label lblSalBruto;
		protected System.Windows.Forms.TextBox txtSalBruto;
		protected System.Windows.Forms.Label lblSalLiquido;
		protected System.Windows.Forms.TextBox txtSalLiquido;
		protected System.Windows.Forms.Label lblDtAdmissao;
		protected System.Windows.Forms.DateTimePicker dtpDataAdmissao;
		protected System.Windows.Forms.Label lblCargaHoraria;
		protected System.Windows.Forms.TextBox txtCargaHoraria;
		protected System.Windows.Forms.Label lblTurno;
		private System.Windows.Forms.ComboBox cbTurno;
	}
}
