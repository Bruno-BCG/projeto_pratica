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
            this.ckbStatus = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(657, 534);
            this.btnSair.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(565, 534);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(16, 22);
            this.lblCod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(52, 13);
            this.lblCod.TabIndex = 2;
            this.lblCod.Text = "CODIGO:";
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.AutoSize = true;
            this.lblDataAlteracao.Location = new System.Drawing.Point(218, 529);
            this.lblDataAlteracao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataAlteracao.Name = "lblDataAlteracao";
            this.lblDataAlteracao.Size = new System.Drawing.Size(110, 13);
            this.lblDataAlteracao.TabIndex = 25;
            this.lblDataAlteracao.Text = "Data Ultima Alteracao";
            // 
            // lblDataCriacao
            // 
            this.lblDataCriacao.AutoSize = true;
            this.lblDataCriacao.Location = new System.Drawing.Point(75, 529);
            this.lblDataCriacao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataCriacao.Name = "lblDataCriacao";
            this.lblDataCriacao.Size = new System.Drawing.Size(75, 13);
            this.lblDataCriacao.TabIndex = 24;
            this.lblDataCriacao.Text = "Data Cadastro";
            // 
            // lblUserAlt
            // 
            this.lblUserAlt.AutoSize = true;
            this.lblUserAlt.Location = new System.Drawing.Point(370, 529);
            this.lblUserAlt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserAlt.Name = "lblUserAlt";
            this.lblUserAlt.Size = new System.Drawing.Size(79, 13);
            this.lblUserAlt.TabIndex = 26;
            this.lblUserAlt.Text = "Usuario Alterou";
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Enabled = false;
            this.txtDtCriacao.Location = new System.Drawing.Point(77, 544);
            this.txtDtCriacao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDtCriacao.Name = "txtDtCriacao";
            this.txtDtCriacao.ReadOnly = true;
            this.txtDtCriacao.Size = new System.Drawing.Size(110, 20);
            this.txtDtCriacao.TabIndex = 27;
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Enabled = false;
            this.txtDtAlt.Location = new System.Drawing.Point(220, 544);
            this.txtDtAlt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDtAlt.Name = "txtDtAlt";
            this.txtDtAlt.ReadOnly = true;
            this.txtDtAlt.Size = new System.Drawing.Size(121, 20);
            this.txtDtAlt.TabIndex = 28;
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Enabled = false;
            this.txtUserAlt.Location = new System.Drawing.Point(372, 544);
            this.txtUserAlt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUserAlt.Name = "txtUserAlt";
            this.txtUserAlt.ReadOnly = true;
            this.txtUserAlt.Size = new System.Drawing.Size(140, 20);
            this.txtUserAlt.TabIndex = 29;
            // 
            // ckbStatus
            // 
            this.ckbStatus.AutoSize = true;
            this.ckbStatus.Checked = true;
            this.ckbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStatus.Enabled = false;
            this.ckbStatus.Location = new System.Drawing.Point(646, 39);
            this.ckbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckbStatus.Name = "ckbStatus";
            this.ckbStatus.Size = new System.Drawing.Size(50, 17);
            this.ckbStatus.TabIndex = 30;
            this.ckbStatus.Text = "Ativo";
            this.ckbStatus.UseVisualStyleBackColor = true;
            // 
            // frmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.ckbStatus);
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
            this.Controls.SetChildIndex(this.ckbStatus, 0);
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
		protected System.Windows.Forms.CheckBox ckbStatus;
	}
}
