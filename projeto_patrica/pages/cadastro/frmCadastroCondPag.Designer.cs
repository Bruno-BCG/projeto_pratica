namespace projeto_pratica.pages.cadastro
{
	partial class frmCadastroCondpag
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
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.lblDescricao = new System.Windows.Forms.Label();
			this.txtDescricao = new System.Windows.Forms.TextBox();
			this.txtParcelas = new System.Windows.Forms.TextBox();
			this.lblParcelas = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.TabIndex = 4;
			// 
			// btnSair
			// 
			this.btnSair.TabIndex = 5;
			// 
			// lblDescricao
			// 
			this.lblDescricao.AutoSize = true;
			this.lblDescricao.Location = new System.Drawing.Point(21, 89);
			this.lblDescricao.Name = "lblDescricao";
			this.lblDescricao.Size = new System.Drawing.Size(75, 16);
			this.lblDescricao.TabIndex = 3;
			this.lblDescricao.Text = "Descricao: ";
			// 
			// txtDescricao
			// 
			this.txtDescricao.Location = new System.Drawing.Point(24, 108);
			this.txtDescricao.MaxLength = 99;
			this.txtDescricao.Name = "txtDescricao";
			this.txtDescricao.Size = new System.Drawing.Size(100, 22);
			this.txtDescricao.TabIndex = 2;
			// 
			// txtParcelas
			// 
			this.txtParcelas.Location = new System.Drawing.Point(24, 173);
			this.txtParcelas.MaxLength = 3;
			this.txtParcelas.Name = "txtParcelas";
			this.txtParcelas.Size = new System.Drawing.Size(100, 22);
			this.txtParcelas.TabIndex = 3;
			// 
			// lblParcelas
			// 
			this.lblParcelas.AutoSize = true;
			this.lblParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblParcelas.Location = new System.Drawing.Point(21, 154);
			this.lblParcelas.Name = "lblParcelas";
			this.lblParcelas.Size = new System.Drawing.Size(144, 16);
			this.lblParcelas.TabIndex = 5;
			this.lblParcelas.Text = "Numeros de Parcelas: ";
			// 
			// frmCadastroCondpag
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(844, 476);
			this.Controls.Add(this.txtParcelas);
			this.Controls.Add(this.lblParcelas);
			this.Controls.Add(this.txtDescricao);
			this.Controls.Add(this.lblDescricao);
			this.Name = "frmCadastroCondpag";
			this.Text = "Cadastro de Condicao de Pagamento";
			this.Controls.SetChildIndex(this.lblDescricao, 0);
			this.Controls.SetChildIndex(this.txtDescricao, 0);
			this.Controls.SetChildIndex(this.btnSair, 0);
			this.Controls.SetChildIndex(this.txtCodigo, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.lblCod, 0);
			this.Controls.SetChildIndex(this.lblParcelas, 0);
			this.Controls.SetChildIndex(this.txtParcelas, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		protected System.Windows.Forms.Label lblDescricao;
		protected System.Windows.Forms.TextBox txtDescricao;
		protected System.Windows.Forms.Label lblParcelas;
		protected System.Windows.Forms.TextBox txtParcelas;
	}
}
