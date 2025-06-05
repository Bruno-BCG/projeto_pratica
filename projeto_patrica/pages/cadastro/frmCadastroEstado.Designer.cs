namespace projeto_pratica
{
    partial class frmCadastroEstado
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
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtUf = new System.Windows.Forms.TextBox();
            this.lblUf = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.lblPais = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtIdPais = new System.Windows.Forms.TextBox();
            this.lblIdPais = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCod
            // 
            this.lblCod.Location = new System.Drawing.Point(22, 15);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(21, 31);
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(19, 71);
            this.lblCidade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(61, 13);
            this.lblCidade.TabIndex = 4;
            this.lblCidade.Text = "ESTADO: *";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(21, 86);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEstado.MaxLength = 55;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(192, 20);
            this.txtEstado.TabIndex = 5;
            // 
            // txtUf
            // 
            this.txtUf.Location = new System.Drawing.Point(21, 135);
            this.txtUf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUf.MaxLength = 3;
            this.txtUf.Name = "txtUf";
            this.txtUf.Size = new System.Drawing.Size(76, 20);
            this.txtUf.TabIndex = 7;
            // 
            // lblUf
            // 
            this.lblUf.AutoSize = true;
            this.lblUf.Location = new System.Drawing.Point(19, 119);
            this.lblUf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUf.Name = "lblUf";
            this.lblUf.Size = new System.Drawing.Size(31, 13);
            this.lblUf.TabIndex = 6;
            this.lblUf.Text = "UF: *";
            // 
            // txtPais
            // 
            this.txtPais.Enabled = false;
            this.txtPais.Location = new System.Drawing.Point(21, 247);
            this.txtPais.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPais.MaxLength = 55;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(192, 20);
            this.txtPais.TabIndex = 9;
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(19, 232);
            this.lblPais.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(34, 13);
            this.lblPais.TabIndex = 8;
            this.lblPais.Text = "PAIS:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(216, 247);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(62, 19);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtIdPais
            // 
            this.txtIdPais.Enabled = false;
            this.txtIdPais.Location = new System.Drawing.Point(21, 193);
            this.txtIdPais.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIdPais.MaxLength = 55;
            this.txtIdPais.Name = "txtIdPais";
            this.txtIdPais.Size = new System.Drawing.Size(44, 20);
            this.txtIdPais.TabIndex = 25;
            // 
            // lblIdPais
            // 
            this.lblIdPais.AutoSize = true;
            this.lblIdPais.Location = new System.Drawing.Point(19, 178);
            this.lblIdPais.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdPais.Name = "lblIdPais";
            this.lblIdPais.Size = new System.Drawing.Size(82, 13);
            this.lblIdPais.TabIndex = 24;
            this.lblIdPais.Text = "CÓDIGO PAIS: ";
            // 
            // frmCadastroEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.txtIdPais);
            this.Controls.Add(this.lblIdPais);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.lblPais);
            this.Controls.Add(this.txtUf);
            this.Controls.Add(this.lblUf);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblCidade);
            this.Name = "frmCadastroEstado";
            this.Text = "Cadastro Estado";
            this.Controls.SetChildIndex(this.ckbStatus, 0);
            this.Controls.SetChildIndex(this.lblDataCriacao, 0);
            this.Controls.SetChildIndex(this.lblDataAlteracao, 0);
            this.Controls.SetChildIndex(this.lblUserAlt, 0);
            this.Controls.SetChildIndex(this.txtDtCriacao, 0);
            this.Controls.SetChildIndex(this.txtDtAlt, 0);
            this.Controls.SetChildIndex(this.txtUserAlt, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.lblCod, 0);
            this.Controls.SetChildIndex(this.btnSair, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.lblCidade, 0);
            this.Controls.SetChildIndex(this.txtEstado, 0);
            this.Controls.SetChildIndex(this.lblUf, 0);
            this.Controls.SetChildIndex(this.txtUf, 0);
            this.Controls.SetChildIndex(this.lblPais, 0);
            this.Controls.SetChildIndex(this.txtPais, 0);
            this.Controls.SetChildIndex(this.btnPesquisar, 0);
            this.Controls.SetChildIndex(this.lblIdPais, 0);
            this.Controls.SetChildIndex(this.txtIdPais, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtUf;
        private System.Windows.Forms.Label lblUf;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtIdPais;
        private System.Windows.Forms.Label lblIdPais;
    }
}
