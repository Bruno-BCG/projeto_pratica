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
            this.clCPF,
            this.clRG,
            this.clDtNasc,
            this.clEmail,
            this.clTelefone,
            this.clMatricula,
            this.clCargo,
            this.clSalarioBruto,
            this.clSalarioLiquido,
            this.clDtAdmissao,
            this.clCargaHoraria,
            this.clTurno,
            this.clStatus});
            this.listV.Size = new System.Drawing.Size(1288, 709);
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5);
            // 
            // clTipo
            // 
            this.clTipo.Text = "Tipo";
            this.clTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clTipo.Width = 50;
            // 
            // clNome
            // 
            this.clNome.Text = "Nome";
            this.clNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clNome.Width = 240;
            // 
            // clApelido
            // 
            this.clApelido.Text = "Apelido";
            this.clApelido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clApelido.Width = 240;
            // 
            // clDtNasc
            // 
            this.clDtNasc.Text = "Data Nascimento";
            this.clDtNasc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clDtNasc.Width = 150;
            // 
            // clCPF
            // 
            this.clCPF.Text = "CPF";
            this.clCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clCPF.Width = 200;
            // 
            // clEmail
            // 
            this.clEmail.Text = "Email";
            this.clEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clEmail.Width = 200;
            // 
            // clTelefone
            // 
            this.clTelefone.Text = "Telefone";
            this.clTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clTelefone.Width = 150;
            // 
            // clStatus
            // 
            this.clStatus.Text = "Ativo";
            this.clStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clStatus.Width = 50;
            // 
            // clRG
            // 
            this.clRG.Text = "RG";
            this.clRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clRG.Width = 200;
            // 
            // clMatricula
            // 
            this.clMatricula.Text = "Matricula";
            this.clMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clMatricula.Width = 200;
            // 
            // clCargo
            // 
            this.clCargo.Text = "Cargo";
            this.clCargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clCargo.Width = 240;
            // 
            // clSalarioBruto
            // 
            this.clSalarioBruto.Text = "Salario Bruto";
            this.clSalarioBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clSalarioBruto.Width = 200;
            // 
            // clSalarioLiquido
            // 
            this.clSalarioLiquido.Text = "Salario Liquido";
            this.clSalarioLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clSalarioLiquido.Width = 200;
            // 
            // clDtAdmissao
            // 
            this.clDtAdmissao.Text = "Data Admissao";
            this.clDtAdmissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clDtAdmissao.Width = 200;
            // 
            // clCargaHoraria
            // 
            this.clCargaHoraria.Text = "Carga Horaria";
            this.clCargaHoraria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clCargaHoraria.Width = 200;
            // 
            // clTurno
            // 
            this.clTurno.Text = "Turno";
            this.clTurno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clTurno.Width = 150;
            // 
            // frmConsultaFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1344, 897);
            this.Margin = new System.Windows.Forms.Padding(5);
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
