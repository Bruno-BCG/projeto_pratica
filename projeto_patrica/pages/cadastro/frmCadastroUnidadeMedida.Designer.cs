namespace projeto_pratica.pages.cadastro
{
    partial class frmCadastroUnidadeMedida
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
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtUniMedida = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(20, 111);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(153, 16);
            this.lblMarca.TabIndex = 36;
            this.lblMarca.Text = "UNIDADE DE MEDIDA:*";
            // 
            // txtUniMedida
            // 
            this.txtUniMedida.Location = new System.Drawing.Point(24, 130);
            this.txtUniMedida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUniMedida.Name = "txtUniMedida";
            this.txtUniMedida.Size = new System.Drawing.Size(175, 22);
            this.txtUniMedida.TabIndex = 35;
            // 
            // frmCadastroUnidadeMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1005, 721);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txtUniMedida);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmCadastroUnidadeMedida";
            this.Text = "Cadastro de Unidade de Medida";
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
            this.Controls.SetChildIndex(this.txtUniMedida, 0);
            this.Controls.SetChildIndex(this.lblMarca, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtUniMedida;
    }
}
