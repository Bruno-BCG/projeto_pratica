namespace projeto_pratica.pages.cadastro
{
    partial class frmCadastroProduto
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
            this.lblProd = new System.Windows.Forms.Label();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.lblCodBar = new System.Windows.Forms.Label();
            this.txtCodBar = new System.Windows.Forms.TextBox();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblUniMed = new System.Windows.Forms.Label();
            this.txtUniMed = new System.Windows.Forms.TextBox();
            this.lblEstoque = new System.Windows.Forms.Label();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.lblCusto = new System.Windows.Forms.Label();
            this.txtCusto = new System.Windows.Forms.TextBox();
            this.lblVenda = new System.Windows.Forms.Label();
            this.txtVenda = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.btnUniMed = new System.Windows.Forms.Button();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.btnMarca = new System.Windows.Forms.Button();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtCodFornecedor = new System.Windows.Forms.TextBox();
            this.txtCodUniMed = new System.Windows.Forms.TextBox();
            this.txtCodCategoria = new System.Windows.Forms.TextBox();
            this.txtCodMarca = new System.Windows.Forms.TextBox();
            this.listV = new System.Windows.Forms.ListView();
            this.clmCod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFornecedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddForn = new System.Windows.Forms.Button();
            this.btnExcluirParc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCod
            // 
            this.lblCod.Location = new System.Drawing.Point(20, 31);
            this.lblCod.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(554, 526);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            // 
            // lblDataAlteracao
            // 
            this.lblDataAlteracao.Location = new System.Drawing.Point(180, 517);
            this.lblDataAlteracao.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // lblDataCriacao
            // 
            this.lblDataCriacao.Location = new System.Drawing.Point(39, 517);
            this.lblDataCriacao.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // lblUserAlt
            // 
            this.lblUserAlt.Location = new System.Drawing.Point(334, 517);
            this.lblUserAlt.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // txtDtCriacao
            // 
            this.txtDtCriacao.Location = new System.Drawing.Point(41, 531);
            this.txtDtCriacao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // txtDtAlt
            // 
            this.txtDtAlt.Location = new System.Drawing.Point(182, 531);
            this.txtDtAlt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDtAlt.Size = new System.Drawing.Size(123, 20);
            // 
            // txtUserAlt
            // 
            this.txtUserAlt.Location = new System.Drawing.Point(332, 531);
            this.txtUserAlt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserAlt.Size = new System.Drawing.Size(147, 20);
            // 
            // ckbStatus
            // 
            this.ckbStatus.Location = new System.Drawing.Point(693, 47);
            this.ckbStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(650, 526);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(22, 47);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3);
            this.txtCodigo.Size = new System.Drawing.Size(113, 20);
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Location = new System.Drawing.Point(180, 31);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(68, 13);
            this.lblProd.TabIndex = 34;
            this.lblProd.Text = "PRODUTO:*";
            // 
            // txtProd
            // 
            this.txtProd.Location = new System.Drawing.Point(182, 47);
            this.txtProd.Name = "txtProd";
            this.txtProd.Size = new System.Drawing.Size(227, 20);
            this.txtProd.TabIndex = 33;
            // 
            // lblCodBar
            // 
            this.lblCodBar.AutoSize = true;
            this.lblCodBar.Location = new System.Drawing.Point(433, 31);
            this.lblCodBar.Name = "lblCodBar";
            this.lblCodBar.Size = new System.Drawing.Size(121, 13);
            this.lblCodBar.TabIndex = 36;
            this.lblCodBar.Text = "CODIGO DE BARRAS:*";
            // 
            // txtCodBar
            // 
            this.txtCodBar.Location = new System.Drawing.Point(435, 47);
            this.txtCodBar.Name = "txtCodBar";
            this.txtCodBar.Size = new System.Drawing.Size(248, 20);
            this.txtCodBar.TabIndex = 35;
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(20, 182);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(89, 13);
            this.lblFornecedor.TabIndex = 38;
            this.lblFornecedor.Text = "FORNECEDOR:*";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(380, 84);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(76, 13);
            this.lblCategoria.TabIndex = 40;
            this.lblCategoria.Text = "CATEGORIA:*";
            // 
            // lblUniMed
            // 
            this.lblUniMed.AutoSize = true;
            this.lblUniMed.Location = new System.Drawing.Point(20, 84);
            this.lblUniMed.Name = "lblUniMed";
            this.lblUniMed.Size = new System.Drawing.Size(108, 13);
            this.lblUniMed.TabIndex = 42;
            this.lblUniMed.Text = "UNIDADE MEDIDA:*";
            // 
            // txtUniMed
            // 
            this.txtUniMed.Location = new System.Drawing.Point(99, 101);
            this.txtUniMed.Name = "txtUniMed";
            this.txtUniMed.ReadOnly = true;
            this.txtUniMed.Size = new System.Drawing.Size(157, 20);
            this.txtUniMed.TabIndex = 41;
            // 
            // lblEstoque
            // 
            this.lblEstoque.AutoSize = true;
            this.lblEstoque.Location = new System.Drawing.Point(308, 450);
            this.lblEstoque.Name = "lblEstoque";
            this.lblEstoque.Size = new System.Drawing.Size(100, 13);
            this.lblEstoque.TabIndex = 44;
            this.lblEstoque.Text = "ESTOQUE ATUAL:";
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(310, 466);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.ReadOnly = true;
            this.txtEstoque.Size = new System.Drawing.Size(108, 20);
            this.txtEstoque.TabIndex = 43;
            this.txtEstoque.Text = "0";
            // 
            // lblCusto
            // 
            this.lblCusto.AutoSize = true;
            this.lblCusto.Location = new System.Drawing.Point(20, 450);
            this.lblCusto.Name = "lblCusto";
            this.lblCusto.Size = new System.Drawing.Size(51, 13);
            this.lblCusto.TabIndex = 46;
            this.lblCusto.Text = "CUSTO:*";
            // 
            // txtCusto
            // 
            this.txtCusto.Location = new System.Drawing.Point(22, 466);
            this.txtCusto.Name = "txtCusto";
            this.txtCusto.Size = new System.Drawing.Size(119, 20);
            this.txtCusto.TabIndex = 45;
            // 
            // lblVenda
            // 
            this.lblVenda.AutoSize = true;
            this.lblVenda.Location = new System.Drawing.Point(159, 450);
            this.lblVenda.Name = "lblVenda";
            this.lblVenda.Size = new System.Drawing.Size(109, 13);
            this.lblVenda.TabIndex = 48;
            this.lblVenda.Text = "PREÇO DE VENDA:*";
            // 
            // txtVenda
            // 
            this.txtVenda.Location = new System.Drawing.Point(161, 466);
            this.txtVenda.Name = "txtVenda";
            this.txtVenda.Size = new System.Drawing.Size(135, 20);
            this.txtVenda.TabIndex = 47;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Enabled = false;
            this.txtFornecedor.Location = new System.Drawing.Point(99, 198);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(154, 20);
            this.txtFornecedor.TabIndex = 37;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(458, 101);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.ReadOnly = true;
            this.txtCategoria.Size = new System.Drawing.Size(154, 20);
            this.txtCategoria.TabIndex = 39;
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Location = new System.Drawing.Point(268, 187);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(94, 29);
            this.btnFornecedor.TabIndex = 49;
            this.btnFornecedor.Text = "Pesquisar";
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.Location = new System.Drawing.Point(621, 95);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(85, 29);
            this.btnCategoria.TabIndex = 50;
            this.btnCategoria.Text = "Pesquisar";
            this.btnCategoria.UseVisualStyleBackColor = true;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // btnUniMed
            // 
            this.btnUniMed.Location = new System.Drawing.Point(268, 95);
            this.btnUniMed.Name = "btnUniMed";
            this.btnUniMed.Size = new System.Drawing.Size(94, 29);
            this.btnUniMed.TabIndex = 51;
            this.btnUniMed.Text = "Pesquisar";
            this.btnUniMed.UseVisualStyleBackColor = true;
            this.btnUniMed.Click += new System.EventHandler(this.btnUniMed_Click);
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(99, 149);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.ReadOnly = true;
            this.txtMarca.Size = new System.Drawing.Size(154, 20);
            this.txtMarca.TabIndex = 52;
            // 
            // btnMarca
            // 
            this.btnMarca.Location = new System.Drawing.Point(268, 143);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(94, 29);
            this.btnMarca.TabIndex = 53;
            this.btnMarca.Text = "Pesquisar";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(20, 132);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(52, 13);
            this.lblMarca.TabIndex = 54;
            this.lblMarca.Text = "MARCA:*";
            // 
            // txtCodFornecedor
            // 
            this.txtCodFornecedor.Enabled = false;
            this.txtCodFornecedor.Location = new System.Drawing.Point(22, 198);
            this.txtCodFornecedor.Name = "txtCodFornecedor";
            this.txtCodFornecedor.ReadOnly = true;
            this.txtCodFornecedor.Size = new System.Drawing.Size(66, 20);
            this.txtCodFornecedor.TabIndex = 55;
            // 
            // txtCodUniMed
            // 
            this.txtCodUniMed.Enabled = false;
            this.txtCodUniMed.Location = new System.Drawing.Point(22, 101);
            this.txtCodUniMed.Name = "txtCodUniMed";
            this.txtCodUniMed.ReadOnly = true;
            this.txtCodUniMed.Size = new System.Drawing.Size(64, 20);
            this.txtCodUniMed.TabIndex = 58;
            // 
            // txtCodCategoria
            // 
            this.txtCodCategoria.Enabled = false;
            this.txtCodCategoria.Location = new System.Drawing.Point(381, 101);
            this.txtCodCategoria.Name = "txtCodCategoria";
            this.txtCodCategoria.ReadOnly = true;
            this.txtCodCategoria.Size = new System.Drawing.Size(69, 20);
            this.txtCodCategoria.TabIndex = 58;
            // 
            // txtCodMarca
            // 
            this.txtCodMarca.Enabled = false;
            this.txtCodMarca.Location = new System.Drawing.Point(22, 149);
            this.txtCodMarca.Name = "txtCodMarca";
            this.txtCodMarca.ReadOnly = true;
            this.txtCodMarca.Size = new System.Drawing.Size(63, 20);
            this.txtCodMarca.TabIndex = 58;
            // 
            // listV
            // 
            this.listV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmCod,
            this.clmFornecedor});
            this.listV.FullRowSelect = true;
            this.listV.GridLines = true;
            this.listV.HideSelection = false;
            this.listV.Location = new System.Drawing.Point(22, 232);
            this.listV.Margin = new System.Windows.Forms.Padding(2);
            this.listV.Name = "listV";
            this.listV.Size = new System.Drawing.Size(698, 206);
            this.listV.TabIndex = 59;
            this.listV.UseCompatibleStateImageBehavior = false;
            this.listV.View = System.Windows.Forms.View.Details;
            this.listV.SelectedIndexChanged += new System.EventHandler(this.listV_SelectedIndexChanged);
            // 
            // clmCod
            // 
            this.clmCod.Text = "Codigo";
            this.clmCod.Width = 100;
            // 
            // clmFornecedor
            // 
            this.clmFornecedor.Text = "Fornecedor";
            this.clmFornecedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmFornecedor.Width = 350;
            // 
            // btnAddForn
            // 
            this.btnAddForn.Location = new System.Drawing.Point(367, 182);
            this.btnAddForn.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddForn.Name = "btnAddForn";
            this.btnAddForn.Size = new System.Drawing.Size(97, 36);
            this.btnAddForn.TabIndex = 60;
            this.btnAddForn.Text = "Adicionar Fornecedor";
            this.btnAddForn.UseVisualStyleBackColor = true;
            this.btnAddForn.Click += new System.EventHandler(this.btnAddForn_Click);
            // 
            // btnExcluirParc
            // 
            this.btnExcluirParc.Enabled = false;
            this.btnExcluirParc.Location = new System.Drawing.Point(468, 183);
            this.btnExcluirParc.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcluirParc.Name = "btnExcluirParc";
            this.btnExcluirParc.Size = new System.Drawing.Size(97, 36);
            this.btnExcluirParc.TabIndex = 62;
            this.btnExcluirParc.Text = "Excluir";
            this.btnExcluirParc.UseVisualStyleBackColor = true;
            this.btnExcluirParc.Click += new System.EventHandler(this.btnExcluirParc_Click);
            // 
            // frmCadastroProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(754, 586);
            this.Controls.Add(this.btnExcluirParc);
            this.Controls.Add(this.btnAddForn);
            this.Controls.Add(this.listV);
            this.Controls.Add(this.txtCodMarca);
            this.Controls.Add(this.txtCodCategoria);
            this.Controls.Add(this.txtCodUniMed);
            this.Controls.Add(this.txtCodFornecedor);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.btnMarca);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.btnUniMed);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnFornecedor);
            this.Controls.Add(this.lblVenda);
            this.Controls.Add(this.txtVenda);
            this.Controls.Add(this.lblCusto);
            this.Controls.Add(this.txtCusto);
            this.Controls.Add(this.lblEstoque);
            this.Controls.Add(this.txtEstoque);
            this.Controls.Add(this.lblUniMed);
            this.Controls.Add(this.txtUniMed);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.lblCodBar);
            this.Controls.Add(this.txtCodBar);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.txtProd);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCadastroProduto";
            this.Text = "Cadastro de Produto";
            this.Controls.SetChildIndex(this.txtProd, 0);
            this.Controls.SetChildIndex(this.lblProd, 0);
            this.Controls.SetChildIndex(this.txtCodBar, 0);
            this.Controls.SetChildIndex(this.lblCodBar, 0);
            this.Controls.SetChildIndex(this.txtFornecedor, 0);
            this.Controls.SetChildIndex(this.lblFornecedor, 0);
            this.Controls.SetChildIndex(this.txtCategoria, 0);
            this.Controls.SetChildIndex(this.lblCategoria, 0);
            this.Controls.SetChildIndex(this.txtUniMed, 0);
            this.Controls.SetChildIndex(this.lblUniMed, 0);
            this.Controls.SetChildIndex(this.txtEstoque, 0);
            this.Controls.SetChildIndex(this.lblEstoque, 0);
            this.Controls.SetChildIndex(this.txtCusto, 0);
            this.Controls.SetChildIndex(this.lblCusto, 0);
            this.Controls.SetChildIndex(this.txtVenda, 0);
            this.Controls.SetChildIndex(this.lblVenda, 0);
            this.Controls.SetChildIndex(this.btnFornecedor, 0);
            this.Controls.SetChildIndex(this.btnCategoria, 0);
            this.Controls.SetChildIndex(this.btnUniMed, 0);
            this.Controls.SetChildIndex(this.txtMarca, 0);
            this.Controls.SetChildIndex(this.btnMarca, 0);
            this.Controls.SetChildIndex(this.lblMarca, 0);
            this.Controls.SetChildIndex(this.txtCodFornecedor, 0);
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
            this.Controls.SetChildIndex(this.txtCodUniMed, 0);
            this.Controls.SetChildIndex(this.txtCodCategoria, 0);
            this.Controls.SetChildIndex(this.txtCodMarca, 0);
            this.Controls.SetChildIndex(this.listV, 0);
            this.Controls.SetChildIndex(this.btnAddForn, 0);
            this.Controls.SetChildIndex(this.btnExcluirParc, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.TextBox txtProd;
        private System.Windows.Forms.Label lblCodBar;
        private System.Windows.Forms.TextBox txtCodBar;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblUniMed;
        private System.Windows.Forms.TextBox txtUniMed;
        private System.Windows.Forms.Label lblEstoque;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label lblCusto;
        private System.Windows.Forms.TextBox txtCusto;
        private System.Windows.Forms.Label lblVenda;
        private System.Windows.Forms.TextBox txtVenda;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Button btnUniMed;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.TextBox txtCodFornecedor;
        private System.Windows.Forms.TextBox txtCodUniMed;
        private System.Windows.Forms.TextBox txtCodCategoria;
        private System.Windows.Forms.TextBox txtCodMarca;
        private System.Windows.Forms.Button btnAddForn;
        private System.Windows.Forms.Button btnExcluirParc;
        private System.Windows.Forms.ColumnHeader clmCod;
        private System.Windows.Forms.ColumnHeader clmFornecedor;
        private System.Windows.Forms.ListView listV;
    }
}
