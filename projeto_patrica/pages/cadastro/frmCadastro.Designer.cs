namespace projeto_pratica.pages.cadastro
{
	partial class frmCadastro
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
			this.btnSave = new System.Windows.Forms.Button();
			this.lblCod = new System.Windows.Forms.Label();
			this.lblDataAlteracao = new System.Windows.Forms.Label();
			this.lblDataCriacao = new System.Windows.Forms.Label();
			this.lblUserAlt = new System.Windows.Forms.Label();
			this.txtDtCriacao = new System.Windows.Forms.TextBox();
			this.txtDtAlt = new System.Windows.Forms.TextBox();
			this.txtUserAlt = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSair
			// 
			this.btnSair.Location = new System.Drawing.Point(876, 657);
			this.btnSair.Size = new System.Drawing.Size(117, 35);
			this.btnSair.TabIndex = 1;
			// 
			// txtCodigo
			// 
			this.txtCodigo.ReadOnly = true;
			this.txtCodigo.Text = "0";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(753, 657);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(117, 35);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Salvar";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// lblCod
			// 
			this.lblCod.AutoSize = true;
			this.lblCod.Location = new System.Drawing.Point(21, 27);
			this.lblCod.Name = "lblCod";
			this.lblCod.Size = new System.Drawing.Size(57, 16);
			this.lblCod.TabIndex = 2;
			this.lblCod.Text = "Codigo: ";
			// 
			// lblDataAlteracao
			// 
			this.lblDataAlteracao.AutoSize = true;
			this.lblDataAlteracao.Location = new System.Drawing.Point(291, 651);
			this.lblDataAlteracao.Name = "lblDataAlteracao";
			this.lblDataAlteracao.Size = new System.Drawing.Size(138, 16);
			this.lblDataAlteracao.TabIndex = 25;
			this.lblDataAlteracao.Text = "Data Ultima Alteracao";
			// 
			// lblDataCriacao
			// 
			this.lblDataCriacao.AutoSize = true;
			this.lblDataCriacao.Location = new System.Drawing.Point(100, 651);
			this.lblDataCriacao.Name = "lblDataCriacao";
			this.lblDataCriacao.Size = new System.Drawing.Size(94, 16);
			this.lblDataCriacao.TabIndex = 24;
			this.lblDataCriacao.Text = "Data Cadastro";
			// 
			// lblUserAlt
			// 
			this.lblUserAlt.AutoSize = true;
			this.lblUserAlt.Location = new System.Drawing.Point(493, 651);
			this.lblUserAlt.Name = "lblUserAlt";
			this.lblUserAlt.Size = new System.Drawing.Size(99, 16);
			this.lblUserAlt.TabIndex = 26;
			this.lblUserAlt.Text = "Usuario Alterou";
			// 
			// txtDtCriacao
			// 
			this.txtDtCriacao.Enabled = false;
			this.txtDtCriacao.Location = new System.Drawing.Point(103, 670);
			this.txtDtCriacao.Name = "txtDtCriacao";
			this.txtDtCriacao.ReadOnly = true;
			this.txtDtCriacao.Size = new System.Drawing.Size(145, 22);
			this.txtDtCriacao.TabIndex = 27;
			// 
			// txtDtAlt
			// 
			this.txtDtAlt.Enabled = false;
			this.txtDtAlt.Location = new System.Drawing.Point(294, 670);
			this.txtDtAlt.Name = "txtDtAlt";
			this.txtDtAlt.ReadOnly = true;
			this.txtDtAlt.Size = new System.Drawing.Size(160, 22);
			this.txtDtAlt.TabIndex = 28;
			// 
			// txtUserAlt
			// 
			this.txtUserAlt.Enabled = false;
			this.txtUserAlt.Location = new System.Drawing.Point(496, 670);
			this.txtUserAlt.Name = "txtUserAlt";
			this.txtUserAlt.ReadOnly = true;
			this.txtUserAlt.Size = new System.Drawing.Size(185, 22);
			this.txtUserAlt.TabIndex = 29;
			// 
			// frmCadastro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Controls.Add(this.txtUserAlt);
			this.Controls.Add(this.txtDtAlt);
			this.Controls.Add(this.txtDtCriacao);
			this.Controls.Add(this.lblUserAlt);
			this.Controls.Add(this.lblDataAlteracao);
			this.Controls.Add(this.lblDataCriacao);
			this.Controls.Add(this.lblCod);
			this.Controls.Add(this.btnSave);
			this.Name = "frmCadastro";
			this.Text = "Cadastro";
			this.Controls.SetChildIndex(this.btnSair, 0);
			this.Controls.SetChildIndex(this.txtCodigo, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.lblCod, 0);
			this.Controls.SetChildIndex(this.lblDataCriacao, 0);
			this.Controls.SetChildIndex(this.lblDataAlteracao, 0);
			this.Controls.SetChildIndex(this.lblUserAlt, 0);
			this.Controls.SetChildIndex(this.txtDtCriacao, 0);
			this.Controls.SetChildIndex(this.txtDtAlt, 0);
			this.Controls.SetChildIndex(this.txtUserAlt, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		protected System.Windows.Forms.Label lblCod;
		public System.Windows.Forms.Button btnSave;
		protected System.Windows.Forms.Label lblDataAlteracao;
		protected System.Windows.Forms.Label lblDataCriacao;
		protected System.Windows.Forms.Label lblUserAlt;
		protected System.Windows.Forms.TextBox txtDtCriacao;
		protected System.Windows.Forms.TextBox txtDtAlt;
		protected System.Windows.Forms.TextBox txtUserAlt;
	}
}
