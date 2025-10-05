namespace projeto_pratica.pages.consulta
{
	partial class frmConsultaFornecedor
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
            this.clCidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clEndereco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clRG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clBairro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clCondPag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clCep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clLimitCredit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clAtivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.clCep,
            this.clBairro,
            this.clEndereco,
            this.clCidade,
            this.clCondPag,
            this.clLimitCredit,
            this.clAtivo});
            this.listV.Location = new System.Drawing.Point(18, 60);
            this.listV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listV.Size = new System.Drawing.Size(967, 577);
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // clTipo
            // 
            this.clTipo.Text = "Tipo";
            this.clTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.clDtNasc.Width = 120;
            // 
            // clCPF
            // 
            this.clCPF.Text = "CPF";
            this.clCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clCPF.Width = 240;
            // 
            // clEmail
            // 
            this.clEmail.Text = "Email";
            this.clEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clEmail.Width = 240;
            // 
            // clTelefone
            // 
            this.clTelefone.Text = "Telefone";
            this.clTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clTelefone.Width = 120;
            // 
            // clCidade
            // 
            this.clCidade.Text = "Cidade";
            this.clCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clCidade.Width = 240;
            // 
            // clEndereco
            // 
            this.clEndereco.Text = "Endereco";
            this.clEndereco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clEndereco.Width = 240;
            // 
            // clRG
            // 
            this.clRG.Text = "RG";
            this.clRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clRG.Width = 240;
            // 
            // clBairro
            // 
            this.clBairro.Text = "Bairro";
            this.clBairro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clBairro.Width = 120;
            // 
            // clCondPag
            // 
            this.clCondPag.Text = "Condicao Pagamento";
            this.clCondPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clCondPag.Width = 120;
            // 
            // clCep
            // 
            this.clCep.Text = "Cep";
            this.clCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clCep.Width = 120;
            // 
            // clLimitCredit
            // 
            this.clLimitCredit.Text = "Limite Credito";
            this.clLimitCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clLimitCredit.Width = 120;
            // 
            // clAtivo
            // 
            this.clAtivo.Text = "Ativo";
            this.clAtivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmConsultaFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmConsultaFornecedor";
            this.Text = "Consulta de Clientes";
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
		private System.Windows.Forms.ColumnHeader clEndereco;
		private System.Windows.Forms.ColumnHeader clRG;
		private System.Windows.Forms.ColumnHeader clBairro;
        private System.Windows.Forms.ColumnHeader clCep;
        private System.Windows.Forms.ColumnHeader clCondPag;
        private System.Windows.Forms.ColumnHeader clLimitCredit;
        private System.Windows.Forms.ColumnHeader clAtivo;
    }
}
