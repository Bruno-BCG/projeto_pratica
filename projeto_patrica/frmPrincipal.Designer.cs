﻿namespace projeto_pratica
{
	partial class frmPrincipal
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.condiçãoDePagamentopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.formaDePagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.condiçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.formaDePagamentoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.consultaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.menuStrip1.Size = new System.Drawing.Size(800, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.condiçãoDePagamentopToolStripMenuItem,
            this.formaDePagamentoToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
			this.cadastroToolStripMenuItem.Text = "Cadastro";
			// 
			// condiçãoDePagamentopToolStripMenuItem
			// 
			this.condiçãoDePagamentopToolStripMenuItem.Name = "condiçãoDePagamentopToolStripMenuItem";
			this.condiçãoDePagamentopToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
			this.condiçãoDePagamentopToolStripMenuItem.Text = "Condição de Pagamento";
			this.condiçãoDePagamentopToolStripMenuItem.Click += new System.EventHandler(this.condiçãoDePagamentopToolStripMenuItem_Click);
			// 
			// formaDePagamentoToolStripMenuItem
			// 
			this.formaDePagamentoToolStripMenuItem.Name = "formaDePagamentoToolStripMenuItem";
			this.formaDePagamentoToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
			this.formaDePagamentoToolStripMenuItem.Text = "Forma de Pagamento";
			this.formaDePagamentoToolStripMenuItem.Click += new System.EventHandler(this.formaDePagamentoToolStripMenuItem_Click);
			// 
			// consultaToolStripMenuItem
			// 
			this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.condiçãoToolStripMenuItem,
            this.formaDePagamentoToolStripMenuItem1});
			this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
			this.consultaToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
			this.consultaToolStripMenuItem.Text = "Consulta";
			// 
			// condiçãoToolStripMenuItem
			// 
			this.condiçãoToolStripMenuItem.Name = "condiçãoToolStripMenuItem";
			this.condiçãoToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
			this.condiçãoToolStripMenuItem.Text = "Condição de Pagamento";
			this.condiçãoToolStripMenuItem.Click += new System.EventHandler(this.condiçãoToolStripMenuItem_Click);
			// 
			// formaDePagamentoToolStripMenuItem1
			// 
			this.formaDePagamentoToolStripMenuItem1.Name = "formaDePagamentoToolStripMenuItem1";
			this.formaDePagamentoToolStripMenuItem1.Size = new System.Drawing.Size(255, 26);
			this.formaDePagamentoToolStripMenuItem1.Text = "Forma de Pagamento";
			// 
			// frmPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmPrincipal";
			this.Text = "Menu Principal";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem condiçãoDePagamentopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formaDePagamentoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem condiçãoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem formaDePagamentoToolStripMenuItem1;
	}
}

