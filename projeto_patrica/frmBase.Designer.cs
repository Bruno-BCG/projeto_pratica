﻿namespace projeto_pratica
{
	partial class frmBase
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
			this.btnSair = new System.Windows.Forms.Button();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSair
			// 
			this.btnSair.AutoSize = true;
			this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSair.Location = new System.Drawing.Point(862, 657);
			this.btnSair.Name = "btnSair";
			this.btnSair.Size = new System.Drawing.Size(117, 35);
			this.btnSair.TabIndex = 0;
			this.btnSair.Text = "Sair";
			this.btnSair.UseVisualStyleBackColor = true;
			this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(24, 46);
			this.txtCodigo.MaxLength = 99;
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(119, 22);
			this.txtCodigo.TabIndex = 1;
			// 
			// frmBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.btnSair);
			this.Name = "frmBase";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmBase";
			this.Load += new System.EventHandler(this.frmBase_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		protected System.Windows.Forms.Button btnSair;
		public System.Windows.Forms.TextBox txtCodigo;
	}
}