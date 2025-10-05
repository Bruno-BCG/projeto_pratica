using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.cadastro;
using System;
using System.Linq;
using System.Windows.Forms;

namespace projeto_pratica.pages.consulta
{
    public partial class frmConsultaProduto : projeto_pratica.pages.consulta.frmConsulta
    {
        frmCadastroProduto frmCadProduto;
        Produto oProduto;
        CtrlProduto aCtrlProduto;
        public frmConsultaProduto()
        {
            InitializeComponent();
            frmCadProduto = new frmCadastroProduto();
        }

        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null)
            {
                frmCadProduto = (frmCadastroProduto)obj;
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oProduto = (Produto)obj;
            aCtrlProduto = (CtrlProduto)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            frmCadProduto.ConhecaObj(oProduto, aCtrlProduto);
            frmCadProduto.LimparTxt();
            frmCadProduto.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            frmCadProduto.ConhecaObj(oProduto, aCtrlProduto);
            frmCadProduto.CarregarTxt();
            frmCadProduto.ShowDialog();
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = frmCadProduto.btnSave.Text;
            frmCadProduto.btnSave.Text = "Excluir";
            frmCadProduto.ConhecaObj(oProduto, aCtrlProduto);
            frmCadProduto.CarregarTxt();
            frmCadProduto.BloqueiaTxt();
            frmCadProduto.ShowDialog(this);
            frmCadProduto.DesbloqueiaTxt();
            frmCadProduto.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            this.listV.Items.Clear();
            var lista = aCtrlProduto.Listar();

            foreach (var produto in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(produto.Id));
                item.SubItems.Add(produto.Nome);
                item.SubItems.Add(produto.AUnidadeMedida.Nome);
                item.SubItems.Add(produto.ACategoria.Nome);
                item.SubItems.Add(produto.AMarca.Nome);
                item.SubItems.Add(produto.Custo.ToString("C"));
                item.SubItems.Add(produto.Venda.ToString("C"));
                item.SubItems.Add(produto.Estoque.ToString());

                // A marca não está na sua grade visual, mas se precisar, adicione uma coluna para ela.

                item.Tag = produto;
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;

                var selecionado = (Produto)listV.SelectedItems[0].Tag;

                // Atribuição individual dos campos...
                oProduto.Id = selecionado.Id;
                oProduto.Nome = selecionado.Nome;
                oProduto.Codbar = selecionado.Codbar;
                oProduto.Custo = selecionado.Custo;
                oProduto.Venda = selecionado.Venda;
                oProduto.Estoque = selecionado.Estoque;
                oProduto.DtCriacao = selecionado.DtCriacao;
                oProduto.DtAlt = selecionado.DtAlt;
                oProduto.OFornecedor = selecionado.OFornecedor; // A lista de fornecedores também é copiada
                oProduto.AUnidadeMedida = selecionado.AUnidadeMedida;
                oProduto.ACategoria = selecionado.ACategoria;
                oProduto.AMarca = selecionado.AMarca;
              
            }
            else
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
            }
        }
    }
}