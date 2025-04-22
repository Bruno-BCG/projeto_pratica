namespace projeto_pratica.pages.consulta
{
	partial class frmConsultaFuncionario
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
			this.clTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clApelido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clDtNasc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clCPF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clTelefone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clRG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clMatricula = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clCargo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clSalarioBruto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clSalarioLiquido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clDtAdmissao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clCargaHoraria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clTurno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// listV
			// 
			this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clTipo,
            this.clNome,
            this.clApelido,
            this.clDtNasc,
            this.clCPF,
            this.clRG,
            this.clEmail,
            this.clTelefone,
            this.clStatus,
            this.clMatricula,
            this.clCargo,
            this.clSalarioBruto,
            this.clSalarioLiquido,
            this.clDtAdmissao,
            this.clCargaHoraria,
            this.clTurno,
            this.clCidade});
			this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
			// 
			// clTipo
			// 
			this.clTipo.Text = "Tipo";
			// 
			// clNome
			// 
			this.clNome.Text = "Nome";
			// 
			// clApelido
			// 
			this.clApelido.Text = "Apelido";
			// 
			// clDtNasc
			// 
			this.clDtNasc.Text = "Data Nascimento";
			// 
			// clCPF
			// 
			this.clCPF.Text = "CPF";
			// 
			// clEmail
			// 
			this.clEmail.Text = "Email";
			// 
			// clTelefone
			// 
			this.clTelefone.Text = "Telefone";
			// 
			// clStatus
			// 
			this.clStatus.Text = "Status";
			// 
			// clCidade
			// 
			this.clCidade.Text = "Cidade";
			// 
			// clRG
			// 
			this.clRG.Text = "RG";
			this.clRG.Width = 107;
			// 
			// clMatricula
			// 
			this.clMatricula.Text = "Matricula";
			this.clMatricula.Width = 84;
			// 
			// clCargo
			// 
			this.clCargo.Text = "Cargo";
			this.clCargo.Width = 134;
			// 
			// clSalarioBruto
			// 
			this.clSalarioBruto.Text = "Salario Bruto";
			this.clSalarioBruto.Width = 151;
			// 
			// clSalarioLiquido
			// 
			this.clSalarioLiquido.Text = "Salario Liquido";
			this.clSalarioLiquido.Width = 163;
			// 
			// clDtAdmissao
			// 
			this.clDtAdmissao.Text = "Data Admissao";
			this.clDtAdmissao.Width = 186;
			// 
			// clCargaHoraria
			// 
			this.clCargaHoraria.Text = "Carga Horaria";
			this.clCargaHoraria.Width = 186;
			// 
			// clTurno
			// 
			this.clTurno.Text = "Turno";
			// 
			// frmConsultaFuncionario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Name = "frmConsultaFuncionario";
			this.Text = "Consulta de Funcionarios";
			this.Load += new System.EventHandler(this.frmConsultaFuncionario_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ColumnHeader clTipo;
		private System.Windows.Forms.ColumnHeader clNome;
		private System.Windows.Forms.ColumnHeader clApelido;
		private System.Windows.Forms.ColumnHeader clDtNasc;
		private System.Windows.Forms.ColumnHeader clCidade;
		private System.Windows.Forms.ColumnHeader clCPF;
		private System.Windows.Forms.ColumnHeader clEmail;
		private System.Windows.Forms.ColumnHeader clTelefone;
		private System.Windows.Forms.ColumnHeader clStatus;
		private System.Windows.Forms.ColumnHeader clRG;
		private System.Windows.Forms.ColumnHeader clMatricula;
		private System.Windows.Forms.ColumnHeader clCargo;
		private System.Windows.Forms.ColumnHeader clSalarioBruto;
		private System.Windows.Forms.ColumnHeader clSalarioLiquido;
		private System.Windows.Forms.ColumnHeader clDtAdmissao;
		private System.Windows.Forms.ColumnHeader clCargaHoraria;
		private System.Windows.Forms.ColumnHeader clTurno;
	}
}
