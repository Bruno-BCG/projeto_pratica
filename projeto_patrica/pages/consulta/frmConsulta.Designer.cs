﻿namespace projeto_pratica.pages.consulta
{
	partial class frmConsulta
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
			this.btnExcluir = new System.Windows.Forms.Button();
			this.btnAlterar = new System.Windows.Forms.Button();
			this.btnIncluir = new System.Windows.Forms.Button();
			this.btnPesquisar = new System.Windows.Forms.Button();
			this.listV = new System.Windows.Forms.ListView();
			this.clmCod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// txtCodigo
			// 
			this.txtCodigo.Size = new System.Drawing.Size(212, 22);
			// 
			// btnExcluir
			// 
			this.btnExcluir.Location = new System.Drawing.Point(634, 408);
			this.btnExcluir.Name = "btnExcluir";
			this.btnExcluir.Size = new System.Drawing.Size(80, 35);
			this.btnExcluir.TabIndex = 2;
			this.btnExcluir.Text = "Excluir";
			this.btnExcluir.UseVisualStyleBackColor = true;
			this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
			// 
			// btnAlterar
			// 
			this.btnAlterar.Location = new System.Drawing.Point(548, 408);
			this.btnAlterar.Name = "btnAlterar";
			this.btnAlterar.Size = new System.Drawing.Size(80, 35);
			this.btnAlterar.TabIndex = 3;
			this.btnAlterar.Text = "Alterar";
			this.btnAlterar.UseVisualStyleBackColor = true;
			this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
			// 
			// btnIncluir
			// 
			this.btnIncluir.Location = new System.Drawing.Point(462, 408);
			this.btnIncluir.Name = "btnIncluir";
			this.btnIncluir.Size = new System.Drawing.Size(80, 35);
			this.btnIncluir.TabIndex = 4;
			this.btnIncluir.Text = "Incluir";
			this.btnIncluir.UseVisualStyleBackColor = true;
			this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
			// 
			// btnPesquisar
			// 
			this.btnPesquisar.Location = new System.Drawing.Point(259, 43);
			this.btnPesquisar.Name = "btnPesquisar";
			this.btnPesquisar.Size = new System.Drawing.Size(80, 28);
			this.btnPesquisar.TabIndex = 6;
			this.btnPesquisar.Text = "Pesquisar";
			this.btnPesquisar.UseVisualStyleBackColor = true;
			this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
			// 
			// listV
			// 
			this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmCod});
			this.listV.FullRowSelect = true;
			this.listV.GridLines = true;
			this.listV.HideSelection = false;
			this.listV.Location = new System.Drawing.Point(24, 77);
			this.listV.Name = "listV";
			this.listV.Size = new System.Drawing.Size(776, 305);
			this.listV.TabIndex = 7;
			this.listV.UseCompatibleStateImageBehavior = false;
			this.listV.View = System.Windows.Forms.View.Details;
			// 
			// clmCod
			// 
			this.clmCod.Text = "Codigo";
			this.clmCod.Width = 80;
			// 
			// frmConsulta
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.ClientSize = new System.Drawing.Size(844, 476);
			this.Controls.Add(this.listV);
			this.Controls.Add(this.btnPesquisar);
			this.Controls.Add(this.btnIncluir);
			this.Controls.Add(this.btnAlterar);
			this.Controls.Add(this.btnExcluir);
			this.Name = "frmConsulta";
			this.Text = "Consulta";
			this.Controls.SetChildIndex(this.btnSair, 0);
			this.Controls.SetChildIndex(this.txtCodigo, 0);
			this.Controls.SetChildIndex(this.btnExcluir, 0);
			this.Controls.SetChildIndex(this.btnAlterar, 0);
			this.Controls.SetChildIndex(this.btnIncluir, 0);
			this.Controls.SetChildIndex(this.btnPesquisar, 0);
			this.Controls.SetChildIndex(this.listV, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnAlterar;
		private System.Windows.Forms.Button btnIncluir;
		protected System.Windows.Forms.Button btnExcluir;
		private System.Windows.Forms.Button btnPesquisar;
		protected System.Windows.Forms.ListView listV;
		protected System.Windows.Forms.ColumnHeader clmCod;
	}
}
