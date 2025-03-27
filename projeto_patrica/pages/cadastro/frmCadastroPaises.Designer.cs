namespace projeto_pratica
{
	partial class frmCadastroPais
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
			this.lblPais = new System.Windows.Forms.Label();
			this.txtPais = new System.Windows.Forms.TextBox();
			this.txtSigla = new System.Windows.Forms.TextBox();
			this.lblSigla = new System.Windows.Forms.Label();
			this.txtMoeda = new System.Windows.Forms.TextBox();
			this.lblMoeda = new System.Windows.Forms.Label();
			this.lblDDI = new System.Windows.Forms.Label();
			this.txtDDI = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblCod
			// 
			this.lblCod.Location = new System.Drawing.Point(25, 19);
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(28, 38);
			// 
			// lblPais
			// 
			this.lblPais.AutoSize = true;
			this.lblPais.Location = new System.Drawing.Point(25, 87);
			this.lblPais.Name = "lblPais";
			this.lblPais.Size = new System.Drawing.Size(37, 16);
			this.lblPais.TabIndex = 4;
			this.lblPais.Text = "País:";
			// 
			// txtPais
			// 
			this.txtPais.Location = new System.Drawing.Point(28, 106);
			this.txtPais.MaxLength = 55;
			this.txtPais.Name = "txtPais";
			this.txtPais.Size = new System.Drawing.Size(266, 22);
			this.txtPais.TabIndex = 5;
			// 
			// txtSigla
			// 
			this.txtSigla.Location = new System.Drawing.Point(28, 181);
			this.txtSigla.MaxLength = 3;
			this.txtSigla.Name = "txtSigla";
			this.txtSigla.Size = new System.Drawing.Size(65, 22);
			this.txtSigla.TabIndex = 7;
			// 
			// lblSigla
			// 
			this.lblSigla.AutoSize = true;
			this.lblSigla.Location = new System.Drawing.Point(25, 161);
			this.lblSigla.Name = "lblSigla";
			this.lblSigla.Size = new System.Drawing.Size(41, 16);
			this.lblSigla.TabIndex = 6;
			this.lblSigla.Text = "Sigla:";
			// 
			// txtMoeda
			// 
			this.txtMoeda.Location = new System.Drawing.Point(28, 257);
			this.txtMoeda.MaxLength = 3;
			this.txtMoeda.Name = "txtMoeda";
			this.txtMoeda.Size = new System.Drawing.Size(266, 22);
			this.txtMoeda.TabIndex = 9;
			// 
			// lblMoeda
			// 
			this.lblMoeda.AutoSize = true;
			this.lblMoeda.Location = new System.Drawing.Point(25, 237);
			this.lblMoeda.Name = "lblMoeda";
			this.lblMoeda.Size = new System.Drawing.Size(53, 16);
			this.lblMoeda.TabIndex = 8;
			this.lblMoeda.Text = "Moeda:";
			// 
			// lblDDI
			// 
			this.lblDDI.AutoSize = true;
			this.lblDDI.Location = new System.Drawing.Point(25, 313);
			this.lblDDI.Name = "lblDDI";
			this.lblDDI.Size = new System.Drawing.Size(30, 16);
			this.lblDDI.TabIndex = 10;
			this.lblDDI.Text = "DDI";
			// 
			// txtDDI
			// 
			this.txtDDI.Location = new System.Drawing.Point(28, 332);
			this.txtDDI.MaxLength = 5;
			this.txtDDI.Name = "txtDDI";
			this.txtDDI.Size = new System.Drawing.Size(266, 22);
			this.txtDDI.TabIndex = 11;
			// 
			// frmCadastroPais
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(839, 485);
			this.Controls.Add(this.txtDDI);
			this.Controls.Add(this.lblDDI);
			this.Controls.Add(this.txtMoeda);
			this.Controls.Add(this.lblMoeda);
			this.Controls.Add(this.txtSigla);
			this.Controls.Add(this.lblSigla);
			this.Controls.Add(this.txtPais);
			this.Controls.Add(this.lblPais);
			this.Name = "frmCadastroPais";
			this.Text = "Cadastro Países";
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.lblCod, 0);
			this.Controls.SetChildIndex(this.lblPais, 0);
			this.Controls.SetChildIndex(this.btnSair, 0);
			this.Controls.SetChildIndex(this.txtCodigo, 0);
			this.Controls.SetChildIndex(this.txtPais, 0);
			this.Controls.SetChildIndex(this.lblSigla, 0);
			this.Controls.SetChildIndex(this.txtSigla, 0);
			this.Controls.SetChildIndex(this.lblMoeda, 0);
			this.Controls.SetChildIndex(this.txtMoeda, 0);
			this.Controls.SetChildIndex(this.lblDDI, 0);
			this.Controls.SetChildIndex(this.txtDDI, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblPais;
		private System.Windows.Forms.TextBox txtPais;
		private System.Windows.Forms.TextBox txtSigla;
		private System.Windows.Forms.Label lblSigla;
		private System.Windows.Forms.TextBox txtMoeda;
		private System.Windows.Forms.Label lblMoeda;
		private System.Windows.Forms.Label lblDDI;
		private System.Windows.Forms.TextBox txtDDI;
	}
}
