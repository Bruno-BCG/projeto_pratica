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
            this.listV = new System.Windows.Forms.ListView();
            this.clmNumParc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPrazo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFormPag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtCodFormPag = new System.Windows.Forms.TextBox();
            this.lblFormPag = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.lblNumParc = new System.Windows.Forms.Label();
            this.txtNumParc = new System.Windows.Forms.TextBox();
            this.btnCriarParc = new System.Windows.Forms.Button();
            this.btnExcluirParc = new System.Windows.Forms.Button();
            this.btnAlterarParc = new System.Windows.Forms.Button();
            this.cbFormaPagamentos = new System.Windows.Forms.ComboBox();
            this.lblPrazo = new System.Windows.Forms.Label();
            this.txtPrazo = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtJuro = new System.Windows.Forms.TextBox();
            this.lblJuros = new System.Windows.Forms.Label();
            this.txtMulta = new System.Windows.Forms.TextBox();
            this.lblMulta = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(556, 536);
            this.btnSave.TabIndex = 12;
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.Location = new System.Drawing.Point(203, 529);
            // 
            // lblDataCriacao
            // 
            this.lblDataCriacao.Location = new System.Drawing.Point(33, 529);
            // 
            // lblUserAlt
            // 
            this.lblUserAlt.Location = new System.Drawing.Point(364, 529);
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Location = new System.Drawing.Point(35, 544);
            this.txtDtCriacao.Size = new System.Drawing.Size(140, 20);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Location = new System.Drawing.Point(206, 544);
            this.txtDtAlt.Size = new System.Drawing.Size(140, 20);
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Location = new System.Drawing.Point(367, 544);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(635, 37);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(648, 536);
            this.btnSair.TabIndex = 13;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Size = new System.Drawing.Size(42, 20);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(94, 22);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(79, 13);
            this.lblDescricao.TabIndex = 3;
            this.lblDescricao.Text = "DESCRIÇÃO: *";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(97, 37);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescricao.MaxLength = 99;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(200, 20);
            this.txtDescricao.TabIndex = 2;
            // 
            // txtParcelas
            // 
            this.txtParcelas.Location = new System.Drawing.Point(18, 89);
            this.txtParcelas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParcelas.MaxLength = 3;
            this.txtParcelas.Name = "txtParcelas";
            this.txtParcelas.Size = new System.Drawing.Size(126, 20);
            this.txtParcelas.TabIndex = 3;
            // 
            // lblParcelas
            // 
            this.lblParcelas.AutoSize = true;
            this.lblParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParcelas.Location = new System.Drawing.Point(16, 74);
            this.lblParcelas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParcelas.Name = "lblParcelas";
            this.lblParcelas.Size = new System.Drawing.Size(132, 13);
            this.lblParcelas.TabIndex = 5;
            this.lblParcelas.Text = "NUMERO DE PARCELAS";
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNumParc,
            this.clmPrazo,
            this.clmPercent,
            this.clmFormPag});
            this.listV.FullRowSelect = true;
            this.listV.GridLines = true;
            this.listV.HideSelection = false;
            this.listV.Location = new System.Drawing.Point(18, 169);
            this.listV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listV.Name = "listV";
            this.listV.Size = new System.Drawing.Size(719, 355);
            this.listV.TabIndex = 6;
            this.listV.UseCompatibleStateImageBehavior = false;
            this.listV.View = System.Windows.Forms.View.Details;
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clmNumParc
            // 
            this.clmNumParc.Text = "Parcela";
            this.clmNumParc.Width = 300;
            // 
            // clmPrazo
            // 
            this.clmPrazo.Text = "Prazo";
            this.clmPrazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // clmPercent
            // 
            this.clmPercent.Text = "Porcentagem";
            this.clmPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmPercent.Width = 100;
            // 
            // clmFormPag
            // 
            this.clmFormPag.Text = "Forma de Pagamento";
            this.clmFormPag.Width = 150;
            // 
            // txtCodFormPag
            // 
            this.txtCodFormPag.Enabled = false;
            this.txtCodFormPag.Location = new System.Drawing.Point(162, 89);
            this.txtCodFormPag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCodFormPag.Name = "txtCodFormPag";
            this.txtCodFormPag.Size = new System.Drawing.Size(42, 20);
            this.txtCodFormPag.TabIndex = 7;
            // 
            // lblFormPag
            // 
            this.lblFormPag.AutoSize = true;
            this.lblFormPag.Location = new System.Drawing.Point(159, 73);
            this.lblFormPag.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormPag.Name = "lblFormPag";
            this.lblFormPag.Size = new System.Drawing.Size(134, 13);
            this.lblFormPag.TabIndex = 8;
            this.lblFormPag.Text = "FORMA DE PAGAMENTO";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(284, 119);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(93, 13);
            this.lblPercent.TabIndex = 12;
            this.lblPercent.Text = "PORCENTAGEM:";
            // 
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(286, 135);
            this.txtPercent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(100, 20);
            this.txtPercent.TabIndex = 7;
            // 
            // lblNumParc
            // 
            this.lblNumParc.AutoSize = true;
            this.lblNumParc.Location = new System.Drawing.Point(16, 119);
            this.lblNumParc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumParc.Name = "lblNumParc";
            this.lblNumParc.Size = new System.Drawing.Size(128, 13);
            this.lblNumParc.TabIndex = 14;
            this.lblNumParc.Text = "NUMERO DA PARCELA:";
            // 
            // txtNumParc
            // 
            this.txtNumParc.Location = new System.Drawing.Point(18, 135);
            this.txtNumParc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNumParc.Name = "txtNumParc";
            this.txtNumParc.Size = new System.Drawing.Size(123, 20);
            this.txtNumParc.TabIndex = 5;
            // 
            // btnCriarParc
            // 
            this.btnCriarParc.Location = new System.Drawing.Point(399, 132);
            this.btnCriarParc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCriarParc.Name = "btnCriarParc";
            this.btnCriarParc.Size = new System.Drawing.Size(82, 25);
            this.btnCriarParc.TabIndex = 8;
            this.btnCriarParc.Text = "Criar Parcela";
            this.btnCriarParc.UseVisualStyleBackColor = true;
            this.btnCriarParc.Click += new System.EventHandler(this.btnCriarParc_Click);
            // 
            // btnExcluirParc
            // 
            this.btnExcluirParc.Enabled = false;
            this.btnExcluirParc.Location = new System.Drawing.Point(644, 132);
            this.btnExcluirParc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExcluirParc.Name = "btnExcluirParc";
            this.btnExcluirParc.Size = new System.Drawing.Size(77, 25);
            this.btnExcluirParc.TabIndex = 11;
            this.btnExcluirParc.Text = "Excluir";
            this.btnExcluirParc.UseVisualStyleBackColor = true;
            this.btnExcluirParc.Click += new System.EventHandler(this.btnExcluirFormPag_Click);
            // 
            // btnAlterarParc
            // 
            this.btnAlterarParc.Enabled = false;
            this.btnAlterarParc.Location = new System.Drawing.Point(568, 132);
            this.btnAlterarParc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAlterarParc.Name = "btnAlterarParc";
            this.btnAlterarParc.Size = new System.Drawing.Size(72, 25);
            this.btnAlterarParc.TabIndex = 10;
            this.btnAlterarParc.Text = "Alterar";
            this.btnAlterarParc.UseVisualStyleBackColor = true;
            this.btnAlterarParc.Click += new System.EventHandler(this.btnAlterarFormPag_Click);
            // 
            // cbFormaPagamentos
            // 
            this.cbFormaPagamentos.FormattingEnabled = true;
            this.cbFormaPagamentos.Location = new System.Drawing.Point(221, 89);
            this.cbFormaPagamentos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFormaPagamentos.Name = "cbFormaPagamentos";
            this.cbFormaPagamentos.Size = new System.Drawing.Size(195, 21);
            this.cbFormaPagamentos.TabIndex = 4;
            this.cbFormaPagamentos.SelectedIndexChanged += new System.EventHandler(this.cbFormaPagamentos_SelectedIndexChanged);
            this.cbFormaPagamentos.SelectionChangeCommitted += new System.EventHandler(this.cbFormaPagamentos_SelectedIndexChanged);
            // 
            // lblPrazo
            // 
            this.lblPrazo.AutoSize = true;
            this.lblPrazo.Location = new System.Drawing.Point(161, 119);
            this.lblPrazo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrazo.Name = "lblPrazo";
            this.lblPrazo.Size = new System.Drawing.Size(47, 13);
            this.lblPrazo.TabIndex = 20;
            this.lblPrazo.Text = "PRAZO:";
            // 
            // txtPrazo
            // 
            this.txtPrazo.Location = new System.Drawing.Point(164, 135);
            this.txtPrazo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrazo.Name = "txtPrazo";
            this.txtPrazo.Size = new System.Drawing.Size(102, 20);
            this.txtPrazo.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(486, 132);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(429, 85);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(78, 26);
            this.btnPesquisar.TabIndex = 21;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtJuro
            // 
            this.txtJuro.Location = new System.Drawing.Point(335, 37);
            this.txtJuro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtJuro.MaxLength = 3;
            this.txtJuro.Name = "txtJuro";
            this.txtJuro.Size = new System.Drawing.Size(70, 20);
            this.txtJuro.TabIndex = 30;
            this.txtJuro.Text = "0";
            // 
            // lblJuros
            // 
            this.lblJuros.AutoSize = true;
            this.lblJuros.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJuros.Location = new System.Drawing.Point(333, 22);
            this.lblJuros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(53, 13);
            this.lblJuros.TabIndex = 31;
            this.lblJuros.Text = "JUROS: *";
            // 
            // txtMulta
            // 
            this.txtMulta.Location = new System.Drawing.Point(422, 37);
            this.txtMulta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMulta.MaxLength = 3;
            this.txtMulta.Name = "txtMulta";
            this.txtMulta.Size = new System.Drawing.Size(70, 20);
            this.txtMulta.TabIndex = 32;
            this.txtMulta.Text = "0";
            // 
            // lblMulta
            // 
            this.lblMulta.AutoSize = true;
            this.lblMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMulta.Location = new System.Drawing.Point(420, 22);
            this.lblMulta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(54, 13);
            this.lblMulta.TabIndex = 33;
            this.lblMulta.Text = "MULTA: *";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(508, 37);
            this.txtDesconto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDesconto.MaxLength = 3;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(76, 20);
            this.txtDesconto.TabIndex = 34;
            this.txtDesconto.Text = "0";
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.Location = new System.Drawing.Point(506, 22);
            this.lblDesconto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(77, 13);
            this.lblDesconto.TabIndex = 35;
            this.lblDesconto.Text = "DESCONTO: *";
            // 
            // frmCadastroCondpag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.txtMulta);
            this.Controls.Add(this.lblMulta);
            this.Controls.Add(this.txtJuro);
            this.Controls.Add(this.lblJuros);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPrazo);
            this.Controls.Add(this.txtPrazo);
            this.Controls.Add(this.cbFormaPagamentos);
            this.Controls.Add(this.btnAlterarParc);
            this.Controls.Add(this.btnExcluirParc);
            this.Controls.Add(this.btnCriarParc);
            this.Controls.Add(this.lblNumParc);
            this.Controls.Add(this.txtNumParc);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.txtPercent);
            this.Controls.Add(this.lblFormPag);
            this.Controls.Add(this.txtCodFormPag);
            this.Controls.Add(this.txtParcelas);
            this.Controls.Add(this.lblParcelas);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.listV);
            this.Name = "frmCadastroCondpag";
            this.Text = "Cadastro de Condicao de Pagamento";
            this.Load += new System.EventHandler(this.frmCadastroCondpag_Load);
            this.Controls.SetChildIndex(this.listV, 0);
            this.Controls.SetChildIndex(this.lblDescricao, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.lblParcelas, 0);
            this.Controls.SetChildIndex(this.txtParcelas, 0);
            this.Controls.SetChildIndex(this.txtCodFormPag, 0);
            this.Controls.SetChildIndex(this.lblFormPag, 0);
            this.Controls.SetChildIndex(this.txtPercent, 0);
            this.Controls.SetChildIndex(this.lblPercent, 0);
            this.Controls.SetChildIndex(this.txtNumParc, 0);
            this.Controls.SetChildIndex(this.lblNumParc, 0);
            this.Controls.SetChildIndex(this.btnCriarParc, 0);
            this.Controls.SetChildIndex(this.btnExcluirParc, 0);
            this.Controls.SetChildIndex(this.btnAlterarParc, 0);
            this.Controls.SetChildIndex(this.cbFormaPagamentos, 0);
            this.Controls.SetChildIndex(this.txtPrazo, 0);
            this.Controls.SetChildIndex(this.lblPrazo, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnPesquisar, 0);
            this.Controls.SetChildIndex(this.lblJuros, 0);
            this.Controls.SetChildIndex(this.txtJuro, 0);
            this.Controls.SetChildIndex(this.lblMulta, 0);
            this.Controls.SetChildIndex(this.txtMulta, 0);
            this.Controls.SetChildIndex(this.lblDesconto, 0);
            this.Controls.SetChildIndex(this.txtDesconto, 0);
            this.Controls.SetChildIndex(this.ckbStatus, 0);
            this.Controls.SetChildIndex(this.lblDataCriacao, 0);
            this.Controls.SetChildIndex(this.lblDataAlteracao, 0);
            this.Controls.SetChildIndex(this.lblUserAlt, 0);
            this.Controls.SetChildIndex(this.txtDtCriacao, 0);
            this.Controls.SetChildIndex(this.txtDtAlt, 0);
            this.Controls.SetChildIndex(this.txtUserAlt, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblCod, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		protected System.Windows.Forms.Label lblDescricao;
		protected System.Windows.Forms.TextBox txtDescricao;
		protected System.Windows.Forms.Label lblParcelas;
		protected System.Windows.Forms.TextBox txtParcelas;
		private System.Windows.Forms.ListView listV;
		private System.Windows.Forms.ColumnHeader clmNumParc;
		private System.Windows.Forms.ColumnHeader clmPrazo;
		private System.Windows.Forms.ColumnHeader clmPercent;
		private System.Windows.Forms.ColumnHeader clmFormPag;
		private System.Windows.Forms.TextBox txtCodFormPag;
		private System.Windows.Forms.Label lblFormPag;
		private System.Windows.Forms.Label lblPercent;
		private System.Windows.Forms.TextBox txtPercent;
		private System.Windows.Forms.Label lblNumParc;
		private System.Windows.Forms.TextBox txtNumParc;
		private System.Windows.Forms.Button btnCriarParc;
		private System.Windows.Forms.Button btnExcluirParc;
		private System.Windows.Forms.Button btnAlterarParc;
		private System.Windows.Forms.ComboBox cbFormaPagamentos;
		private System.Windows.Forms.Label lblPrazo;
		private System.Windows.Forms.TextBox txtPrazo;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnPesquisar;
		protected System.Windows.Forms.TextBox txtJuro;
		protected System.Windows.Forms.Label lblJuros;
		protected System.Windows.Forms.TextBox txtMulta;
		protected System.Windows.Forms.Label lblMulta;
		protected System.Windows.Forms.TextBox txtDesconto;
		protected System.Windows.Forms.Label lblDesconto;
	}
}
