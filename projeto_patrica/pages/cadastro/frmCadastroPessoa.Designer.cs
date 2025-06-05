namespace projeto_pratica.pages.cadastro
{
	partial class frmCadastroPessoa
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
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.rbtnFisica = new System.Windows.Forms.RadioButton();
            this.rbtnJuridico = new System.Windows.Forms.RadioButton();
            this.txtApelido = new System.Windows.Forms.TextBox();
            this.lblApelido = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtRg = new System.Windows.Forms.TextBox();
            this.lblRG = new System.Windows.Forms.Label();
            this.lblDtNascimento = new System.Windows.Forms.Label();
            this.dtpDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.lblCEP = new System.Windows.Forms.Label();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.lblBairro = new System.Windows.Forms.Label();
            this.btnPesquisarCidade = new System.Windows.Forms.Button();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblNomCidade = new System.Windows.Forms.Label();
            this.txtCodCidade = new System.Windows.Forms.TextBox();
            this.lblCodCidade = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.txtComple = new System.Windows.Forms.TextBox();
            this.lblComple = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCod
            // 
            this.lblCod.Location = new System.Drawing.Point(15, 45);
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 15;
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.Location = new System.Drawing.Point(212, 529);
            // 
            // lblDataCriacao
            // 
            this.lblDataCriacao.Location = new System.Drawing.Point(56, 529);
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Location = new System.Drawing.Point(58, 544);
            this.txtDtCriacao.Size = new System.Drawing.Size(140, 20);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Location = new System.Drawing.Point(214, 544);
            this.txtDtAlt.Size = new System.Drawing.Size(140, 20);
            // 
            // btnSair
            // 
            this.btnSair.TabIndex = 16;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(17, 60);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(137, 45);
            this.lblNome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(140, 60);
            this.txtNome.Margin = new System.Windows.Forms.Padding(2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(227, 20);
            this.txtNome.TabIndex = 2;
            // 
            // rbtnFisica
            // 
            this.rbtnFisica.AutoSize = true;
            this.rbtnFisica.Location = new System.Drawing.Point(301, 10);
            this.rbtnFisica.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFisica.Name = "rbtnFisica";
            this.rbtnFisica.Size = new System.Drawing.Size(90, 17);
            this.rbtnFisica.TabIndex = 5;
            this.rbtnFisica.TabStop = true;
            this.rbtnFisica.Text = "Pessoa Fisica";
            this.rbtnFisica.UseVisualStyleBackColor = true;
            // 
            // rbtnJuridico
            // 
            this.rbtnJuridico.AutoSize = true;
            this.rbtnJuridico.Location = new System.Drawing.Point(391, 10);
            this.rbtnJuridico.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnJuridico.Name = "rbtnJuridico";
            this.rbtnJuridico.Size = new System.Drawing.Size(99, 17);
            this.rbtnJuridico.TabIndex = 6;
            this.rbtnJuridico.TabStop = true;
            this.rbtnJuridico.Text = "Pessoa Juridica";
            this.rbtnJuridico.UseVisualStyleBackColor = true;
            // 
            // txtApelido
            // 
            this.txtApelido.Location = new System.Drawing.Point(374, 60);
            this.txtApelido.Margin = new System.Windows.Forms.Padding(2);
            this.txtApelido.Name = "txtApelido";
            this.txtApelido.Size = new System.Drawing.Size(174, 20);
            this.txtApelido.TabIndex = 3;
            // 
            // lblApelido
            // 
            this.lblApelido.AutoSize = true;
            this.lblApelido.Location = new System.Drawing.Point(372, 45);
            this.lblApelido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApelido.Name = "lblApelido";
            this.lblApelido.Size = new System.Drawing.Size(56, 13);
            this.lblApelido.TabIndex = 7;
            this.lblApelido.Text = "APELIDO:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(168, 315);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(229, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(166, 300);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 13);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "EMAIL:";
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(17, 269);
            this.txtCpf.Margin = new System.Windows.Forms.Padding(2);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(180, 20);
            this.txtCpf.TabIndex = 10;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(15, 254);
            this.lblCPF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(27, 13);
            this.lblCPF.TabIndex = 11;
            this.lblCPF.Text = "CPF";
            // 
            // txtRg
            // 
            this.txtRg.Location = new System.Drawing.Point(214, 266);
            this.txtRg.Margin = new System.Windows.Forms.Padding(2);
            this.txtRg.Name = "txtRg";
            this.txtRg.Size = new System.Drawing.Size(174, 20);
            this.txtRg.TabIndex = 11;
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Location = new System.Drawing.Point(212, 251);
            this.lblRG.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(23, 13);
            this.lblRG.TabIndex = 13;
            this.lblRG.Text = "RG";
            // 
            // lblDtNascimento
            // 
            this.lblDtNascimento.AutoSize = true;
            this.lblDtNascimento.Location = new System.Drawing.Point(408, 251);
            this.lblDtNascimento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDtNascimento.Name = "lblDtNascimento";
            this.lblDtNascimento.Size = new System.Drawing.Size(110, 13);
            this.lblDtNascimento.TabIndex = 16;
            this.lblDtNascimento.Text = "DATA NASCIMENTO";
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.Checked = false;
            this.dtpDataNascimento.CustomFormat = "";
            this.dtpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNascimento.Location = new System.Drawing.Point(411, 267);
            this.dtpDataNascimento.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDataNascimento.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDataNascimento.Name = "dtpDataNascimento";
            this.dtpDataNascimento.Size = new System.Drawing.Size(155, 20);
            this.dtpDataNascimento.TabIndex = 12;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(140, 113);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(2);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(170, 20);
            this.txtEndereco.TabIndex = 6;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(137, 98);
            this.lblEndereco.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(70, 13);
            this.lblEndereco.TabIndex = 19;
            this.lblEndereco.Text = "ENDEREÇO:";
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(17, 113);
            this.txtCep.Margin = new System.Windows.Forms.Padding(2);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(112, 20);
            this.txtCep.TabIndex = 5;
            // 
            // lblCEP
            // 
            this.lblCEP.AutoSize = true;
            this.lblCEP.Location = new System.Drawing.Point(15, 98);
            this.lblCEP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCEP.Name = "lblCEP";
            this.lblCEP.Size = new System.Drawing.Size(28, 13);
            this.lblCEP.TabIndex = 21;
            this.lblCEP.Text = "CEP";
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(454, 113);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(2);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(111, 20);
            this.txtBairro.TabIndex = 7;
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(452, 98);
            this.lblBairro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(51, 13);
            this.lblBairro.TabIndex = 23;
            this.lblBairro.Text = "BAIRRO:";
            // 
            // btnPesquisarCidade
            // 
            this.btnPesquisarCidade.Location = new System.Drawing.Point(338, 211);
            this.btnPesquisarCidade.Margin = new System.Windows.Forms.Padding(2);
            this.btnPesquisarCidade.Name = "btnPesquisarCidade";
            this.btnPesquisarCidade.Size = new System.Drawing.Size(67, 24);
            this.btnPesquisarCidade.TabIndex = 9;
            this.btnPesquisarCidade.Text = "Pesquisar";
            this.btnPesquisarCidade.UseVisualStyleBackColor = true;
            // 
            // txtCidade
            // 
            this.txtCidade.Enabled = false;
            this.txtCidade.Location = new System.Drawing.Point(127, 214);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(2);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.ReadOnly = true;
            this.txtCidade.Size = new System.Drawing.Size(208, 20);
            this.txtCidade.TabIndex = 8;
            // 
            // lblNomCidade
            // 
            this.lblNomCidade.AutoSize = true;
            this.lblNomCidade.Location = new System.Drawing.Point(124, 198);
            this.lblNomCidade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomCidade.Name = "lblNomCidade";
            this.lblNomCidade.Size = new System.Drawing.Size(50, 13);
            this.lblNomCidade.TabIndex = 30;
            this.lblNomCidade.Text = "CIDADE:";
            // 
            // txtCodCidade
            // 
            this.txtCodCidade.Enabled = false;
            this.txtCodCidade.Location = new System.Drawing.Point(17, 214);
            this.txtCodCidade.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodCidade.Name = "txtCodCidade";
            this.txtCodCidade.ReadOnly = true;
            this.txtCodCidade.Size = new System.Drawing.Size(90, 20);
            this.txtCodCidade.TabIndex = 27;
            // 
            // lblCodCidade
            // 
            this.lblCodCidade.AutoSize = true;
            this.lblCodCidade.Location = new System.Drawing.Point(15, 198);
            this.lblCodCidade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodCidade.Name = "lblCodCidade";
            this.lblCodCidade.Size = new System.Drawing.Size(95, 13);
            this.lblCodCidade.TabIndex = 26;
            this.lblCodCidade.Text = "CODIGO CIDADE:";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(17, 315);
            this.txtTel.Margin = new System.Windows.Forms.Padding(2);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(131, 20);
            this.txtTel.TabIndex = 13;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(15, 300);
            this.lblTel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(66, 13);
            this.lblTel.TabIndex = 33;
            this.lblTel.Text = "TELEFONE:";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(326, 113);
            this.txtNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(111, 20);
            this.txtNum.TabIndex = 34;
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(324, 98);
            this.lblNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(58, 13);
            this.lblNum.TabIndex = 35;
            this.lblNum.Text = "NUMERO:";
            // 
            // txtComple
            // 
            this.txtComple.Location = new System.Drawing.Point(17, 161);
            this.txtComple.Margin = new System.Windows.Forms.Padding(2);
            this.txtComple.Name = "txtComple";
            this.txtComple.Size = new System.Drawing.Size(292, 20);
            this.txtComple.TabIndex = 36;
            // 
            // lblComple
            // 
            this.lblComple.AutoSize = true;
            this.lblComple.Location = new System.Drawing.Point(17, 143);
            this.lblComple.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComple.Name = "lblComple";
            this.lblComple.Size = new System.Drawing.Size(93, 13);
            this.lblComple.TabIndex = 37;
            this.lblComple.Text = "COMPLEMENTO:";
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(418, 214);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(148, 20);
            this.txtEstado.TabIndex = 38;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(416, 198);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(54, 13);
            this.lblEstado.TabIndex = 39;
            this.lblEstado.Text = "ESTADO:";
            // 
            // frmCadastroPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblComple);
            this.Controls.Add(this.txtComple);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.btnPesquisarCidade);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.lblNomCidade);
            this.Controls.Add(this.txtCodCidade);
            this.Controls.Add(this.lblCodCidade);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.lblBairro);
            this.Controls.Add(this.txtCep);
            this.Controls.Add(this.lblCEP);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.dtpDataNascimento);
            this.Controls.Add(this.lblDtNascimento);
            this.Controls.Add(this.txtRg);
            this.Controls.Add(this.lblRG);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtApelido);
            this.Controls.Add(this.lblApelido);
            this.Controls.Add(this.rbtnJuridico);
            this.Controls.Add(this.rbtnFisica);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Name = "frmCadastroPessoa";
            this.Text = "Cadastro Pessoa";
            this.Controls.SetChildIndex(this.ckbStatus, 0);
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
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		protected System.Windows.Forms.TextBox txtNome;
		protected System.Windows.Forms.TextBox txtApelido;
		protected System.Windows.Forms.Label lblNome;
		protected System.Windows.Forms.Label lblApelido;
		protected System.Windows.Forms.TextBox txtEmail;
		protected System.Windows.Forms.Label lblEmail;
		protected System.Windows.Forms.TextBox txtCpf;
		protected System.Windows.Forms.Label lblCPF;
		protected System.Windows.Forms.TextBox txtRg;
		protected System.Windows.Forms.Label lblRG;
		protected System.Windows.Forms.Label lblDtNascimento;
		protected System.Windows.Forms.DateTimePicker dtpDataNascimento;
		protected System.Windows.Forms.RadioButton rbtnFisica;
		protected System.Windows.Forms.RadioButton rbtnJuridico;
		protected System.Windows.Forms.TextBox txtEndereco;
		protected System.Windows.Forms.Label lblEndereco;
		protected System.Windows.Forms.TextBox txtCep;
		protected System.Windows.Forms.Label lblCEP;
		protected System.Windows.Forms.TextBox txtBairro;
		protected System.Windows.Forms.Label lblBairro;
		protected System.Windows.Forms.TextBox txtCidade;
		protected System.Windows.Forms.Label lblNomCidade;
		protected System.Windows.Forms.TextBox txtCodCidade;
		protected System.Windows.Forms.Label lblCodCidade;
		protected System.Windows.Forms.Button btnPesquisarCidade;
		protected System.Windows.Forms.TextBox txtTel;
		protected System.Windows.Forms.Label lblTel;
		protected System.Windows.Forms.TextBox txtNum;
		protected System.Windows.Forms.Label lblNum;
		protected System.Windows.Forms.Label lblEstado;
		protected System.Windows.Forms.TextBox txtComple;
		protected System.Windows.Forms.Label lblComple;
		protected System.Windows.Forms.TextBox txtEstado;
	}
}
