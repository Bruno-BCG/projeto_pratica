namespace projeto_pratica
{
	partial class frmCadastroCidade
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblCidade = new System.Windows.Forms.Label();
			this.txtCidade = new System.Windows.Forms.TextBox();
			this.txtDDD = new System.Windows.Forms.TextBox();
			this.lblDDD = new System.Windows.Forms.Label();
			this.txtEstado = new System.Windows.Forms.TextBox();
			this.lblEstado = new System.Windows.Forms.Label();
			this.btnPesquisar = new System.Windows.Forms.Button();
			this.txtIdEstado = new System.Windows.Forms.TextBox();
			this.lblIdEstado = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblCod
			// 
			this.lblCod.Location = new System.Drawing.Point(29, 19);
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(28, 38);
			// 
			// lblCidade
			// 
			this.lblCidade.AutoSize = true;
			this.lblCidade.Location = new System.Drawing.Point(25, 87);
			this.lblCidade.Name = "lblCidade";
			this.lblCidade.Size = new System.Drawing.Size(54, 16);
			this.lblCidade.TabIndex = 4;
			this.lblCidade.Text = "Cidade:";
			// 
			// txtCidade
			// 
			this.txtCidade.Location = new System.Drawing.Point(28, 106);
			this.txtCidade.MaxLength = 55;
			this.txtCidade.Name = "txtCidade";
			this.txtCidade.Size = new System.Drawing.Size(228, 22);
			this.txtCidade.TabIndex = 5;
			// 
			// txtDDD
			// 
			this.txtDDD.Location = new System.Drawing.Point(28, 180);
			this.txtDDD.MaxLength = 3;
			this.txtDDD.Name = "txtDDD";
			this.txtDDD.Size = new System.Drawing.Size(65, 22);
			this.txtDDD.TabIndex = 7;
			// 
			// lblDDD
			// 
			this.lblDDD.AutoSize = true;
			this.lblDDD.Location = new System.Drawing.Point(25, 161);
			this.lblDDD.Name = "lblDDD";
			this.lblDDD.Size = new System.Drawing.Size(40, 16);
			this.lblDDD.TabIndex = 6;
			this.lblDDD.Text = "DDD:";
			// 
			// txtEstado
			// 
			this.txtEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.txtEstado.Location = new System.Drawing.Point(28, 316);
			this.txtEstado.MaxLength = 55;
			this.txtEstado.Name = "txtEstado";
			this.txtEstado.Size = new System.Drawing.Size(228, 22);
			this.txtEstado.TabIndex = 9;
			// 
			// lblEstado
			// 
			this.lblEstado.AutoSize = true;
			this.lblEstado.Location = new System.Drawing.Point(25, 297);
			this.lblEstado.Name = "lblEstado";
			this.lblEstado.Size = new System.Drawing.Size(53, 16);
			this.lblEstado.TabIndex = 8;
			this.lblEstado.Text = "Estado:";
			// 
			// btnPesquisar
			// 
			this.btnPesquisar.Location = new System.Drawing.Point(284, 315);
			this.btnPesquisar.Name = "btnPesquisar";
			this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
			this.btnPesquisar.TabIndex = 10;
			this.btnPesquisar.Text = "Pesquisar";
			this.btnPesquisar.UseVisualStyleBackColor = true;
			this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
			// 
			// txtIdEstado
			// 
			this.txtIdEstado.Location = new System.Drawing.Point(28, 250);
			this.txtIdEstado.MaxLength = 55;
			this.txtIdEstado.Name = "txtIdEstado";
			this.txtIdEstado.Size = new System.Drawing.Size(58, 22);
			this.txtIdEstado.TabIndex = 23;
			// 
			// lblIdEstado
			// 
			this.lblIdEstado.AutoSize = true;
			this.lblIdEstado.Location = new System.Drawing.Point(25, 231);
			this.lblIdEstado.Name = "lblIdEstado";
			this.lblIdEstado.Size = new System.Drawing.Size(100, 16);
			this.lblIdEstado.TabIndex = 22;
			this.lblIdEstado.Text = "Codigo Estado:";
			// 
			// frmCadastroCidade
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Controls.Add(this.txtIdEstado);
			this.Controls.Add(this.lblIdEstado);
			this.Controls.Add(this.btnPesquisar);
			this.Controls.Add(this.txtEstado);
			this.Controls.Add(this.lblEstado);
			this.Controls.Add(this.txtDDD);
			this.Controls.Add(this.lblDDD);
			this.Controls.Add(this.txtCidade);
			this.Controls.Add(this.lblCidade);
			this.Name = "frmCadastroCidade";
			this.Text = "Cadastro Cidades";
			this.Load += new System.EventHandler(this.frmCadastroCidades_Load);
			this.Controls.SetChildIndex(this.lblDataCriacao, 0);
			this.Controls.SetChildIndex(this.lblDataAlteracao, 0);
			this.Controls.SetChildIndex(this.lblUserAlt, 0);
			this.Controls.SetChildIndex(this.txtDtCriacao, 0);
			this.Controls.SetChildIndex(this.txtDtAlt, 0);
			this.Controls.SetChildIndex(this.txtUserAlt, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.lblCod, 0);
			this.Controls.SetChildIndex(this.lblCidade, 0);
			this.Controls.SetChildIndex(this.txtCidade, 0);
			this.Controls.SetChildIndex(this.lblDDD, 0);
			this.Controls.SetChildIndex(this.txtDDD, 0);
			this.Controls.SetChildIndex(this.lblEstado, 0);
			this.Controls.SetChildIndex(this.txtEstado, 0);
			this.Controls.SetChildIndex(this.btnPesquisar, 0);
			this.Controls.SetChildIndex(this.btnSair, 0);
			this.Controls.SetChildIndex(this.txtCodigo, 0);
			this.Controls.SetChildIndex(this.lblIdEstado, 0);
			this.Controls.SetChildIndex(this.txtIdEstado, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCidade;
		private System.Windows.Forms.TextBox txtCidade;
		private System.Windows.Forms.TextBox txtDDD;
		private System.Windows.Forms.Label lblDDD;
		private System.Windows.Forms.Label lblEstado;
		private System.Windows.Forms.TextBox txtEstado;
		private System.Windows.Forms.Button btnPesquisar;
		private System.Windows.Forms.TextBox txtIdEstado;
		private System.Windows.Forms.Label lblIdEstado;
	}
}
