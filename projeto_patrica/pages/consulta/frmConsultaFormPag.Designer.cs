﻿namespace projeto_pratica.pages.consulta
{
	partial class frmConsultaFormPag
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
			this.clmDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// listV
			// 
			this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDesc});
			this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
			// 
			// clmDesc
			// 
			this.clmDesc.Text = "Descrição";
			this.clmDesc.Width = 100;
			// 
			// frmConsultaFormPag
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Name = "frmConsultaFormPag";
			this.Text = "Consulta de Forma de Pagamento";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ColumnHeader clmDesc;
	}
}
