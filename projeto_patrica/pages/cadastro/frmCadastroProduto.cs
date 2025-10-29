using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.consulta;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projeto_pratica.pages.cadastro
{
    public partial class frmCadastroProduto : projeto_pratica.pages.cadastro.frmCadastro
    {
        // Objeto principal e seu controlador
        private Produto oProduto;
        private CtrlProduto aCtrlProduto;

        // Objetos e controladores para entidades relacionadas
        private Fornecedor oFornecedorSelecionado; // Guarda o fornecedor selecionado na busca ou na lista
        private CtrlFornecedor aCtrlFornecedor;
        private CtrlMarca aCtrlMarca;
        private CtrlCategoria aCtrlCategoria;
        private CtrlUniMedida aCtrlUniMedida;

        // Formulários de consulta
        private frmConsultaFornecedor aFormConsultaFornecedor;
        private frmConsultaMarca aFormConsultaMarca;
        private frmConsultaCategoria aFormConsultaCategoria;
        private frmConsultaUnidadeMedida aFormConsultaUnidadeMedida;

        // Lista para controlar fornecedores removidos durante a edição
        private List<Fornecedor> fornecedoresRemovidos = new List<Fornecedor>();

        public frmCadastroProduto()
        {
            InitializeComponent();

            // Instanciando objetos principais
            oProduto = new Produto();
            aCtrlProduto = new CtrlProduto();
            // Instanciando controladores
            aCtrlFornecedor = new CtrlFornecedor();
            aCtrlMarca = new CtrlMarca();
            aCtrlCategoria = new CtrlCategoria();
            aCtrlUniMedida = new CtrlUniMedida();
            // Instanciando formulários de consulta
            aFormConsultaFornecedor = new frmConsultaFornecedor();
            aFormConsultaMarca = new frmConsultaMarca();
            aFormConsultaCategoria = new frmConsultaCategoria();
            aFormConsultaUnidadeMedida = new frmConsultaUnidadeMedida();

            oFornecedorSelecionado = new Fornecedor();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oProduto = (Produto)obj;
            aCtrlProduto = (CtrlProduto)ctrl;
            this.CarregarTxt();
        }

        public void setFrmConsultaFornecedor(object obj)
        {
            aFormConsultaFornecedor = (frmConsultaFornecedor)obj;
        }

        public void setFrmConsultaMarca(object obj)
        {
            aFormConsultaMarca = (frmConsultaMarca)obj;
        }

        public void setFrmConsultaCategoria(object obj)
        {
            aFormConsultaCategoria = (frmConsultaCategoria)obj;
        }

        public void setFrmConsultaUnidadeMedida(object obj)
        {
            aFormConsultaUnidadeMedida = (frmConsultaUnidadeMedida)obj;
        }

        public override void LimparTxt()
        {
            base.LimparTxt();
            // Limpa campos do Produto
            txtCodigo.Text = "0";
            txtProd.Clear();
            txtCodBar.Clear();
            txtCusto.Clear();
            txtVenda.Clear();
            txtEstoque.Text = "0";
            ckbStatus.Checked = true;

            // Limpa campos de entidades relacionadas
            txtCodMarca.Clear();
            txtMarca.Clear();
            txtCodCategoria.Clear();
            txtCategoria.Clear();
            txtCodUniMed.Clear();
            txtUniMed.Clear();

            LimparCamposFornecedor();

            // Limpa a lista visual
            listV.Items.Clear();
            oProduto = new Produto(); // Reseta o objeto
        }

        private void LimparCamposFornecedor()
        {
            txtCodFornecedor.Clear();
            txtFornecedor.Clear();
            oFornecedorSelecionado = new Fornecedor();
        }

        public override void CarregarTxt()
        {
            base.CarregarTxt();
            txtCodigo.Text = oProduto.Id.ToString();
            txtProd.Text = oProduto.Nome;
            txtCodBar.Text = oProduto.Codbar;
            txtCusto.Text = oProduto.Custo.ToString();
            txtVenda.Text = oProduto.Venda.ToString();
            txtPercentLucro.Text = oProduto.PercentLucro.ToString();
            txtEstoque.Text = oProduto.Estoque.ToString();
            ckbStatus.Checked = oProduto.Ativo;

            txtDtCriacao.Text = oProduto.DtCriacao.ToString();
            txtDtAlt.Text = oProduto.DtAlt.ToString();

            // Carrega campos de objetos relacionados
            if (oProduto.AMarca != null)
            {
                txtCodMarca.Text = oProduto.AMarca.Id.ToString();
                txtMarca.Text = oProduto.AMarca.Nome;
            }
            if (oProduto.ACategoria != null)
            {
                txtCodCategoria.Text = oProduto.ACategoria.Id.ToString();
                txtCategoria.Text = oProduto.ACategoria.Nome;
            }
            if (oProduto.AUnidadeMedida != null)
            {
                txtCodUniMed.Text = oProduto.AUnidadeMedida.Id.ToString();
                txtUniMed.Text = oProduto.AUnidadeMedida.Nome;
            }

            CarregaLV();
        }

        public override void Salvar()
        {
            base.Salvar();

            // Validações básicas
            if (string.IsNullOrWhiteSpace(txtProd.Text) || string.IsNullOrWhiteSpace(txtCodBar.Text) || string.IsNullOrWhiteSpace(txtProd.Text)
                || string.IsNullOrWhiteSpace(txtCodUniMed.Text) || string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Campos obrigatórios (*) não preenchidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Preenche o objeto Produto com os dados da tela
            oProduto.Nome = txtProd.Text;
            oProduto.Codbar = txtCodBar.Text;
            oProduto.Venda = Convert.ToDouble(txtVenda.Text);
            oProduto.Ativo = ckbStatus.Checked;
            oProduto.PercentLucro = Convert.ToDouble(txtPercentLucro.Text);

            if (oProduto.Id > 0)
                oProduto.DtAlt = DateTime.Now;
            else
                oProduto.DtCriacao = DateTime.Now;

            // Lógica de Salvar ou Excluir
            if (btnSave.Text == "Salvar")
            {
                string resultado = aCtrlProduto.Salvar(oProduto);

                if (int.TryParse(resultado, out int novoId))
                {
                    txtCodigo.Text = novoId.ToString();
                    MessageBox.Show("Produto salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnSave.Text == "Excluir")
            {
                string resultado = aCtrlProduto.Excluir(oProduto);
                if (resultado == "OK")
                {
                    MessageBox.Show("Produto excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show($"Erro ao excluir: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CarregaLV()
        {
            listV.Items.Clear();
            if (oProduto.OFornecedor != null)
            {
                foreach (var fornecedor in oProduto.OFornecedor)
                {
                    ListViewItem item = new ListViewItem(fornecedor.Id.ToString());
                    item.SubItems.Add(fornecedor.NomeRazaoSocial); // Supondo que a classe Fornecedor tem a propriedade Nome
                    item.Tag = fornecedor;
                    listV.Items.Add(item);
                }
            }
        }

        private void AdicionarFornecedor()
        {
            if (oFornecedorSelecionado == null || oFornecedorSelecionado.Id == 0)
            {
                MessageBox.Show("Nenhum fornecedor selecionado. Use o botão 'Pesquisar' para encontrar um.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Evita adicionar fornecedores duplicados
            if (oProduto.OFornecedor.Exists(f => f.Id == oFornecedorSelecionado.Id))
            {
                MessageBox.Show("Este fornecedor já foi adicionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oProduto.OFornecedor.Add(oFornecedorSelecionado);
            CarregaLV();
            LimparCamposFornecedor();
        }

        private void RemoverFornecedor()
        {
            if (listV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um fornecedor na lista para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Fornecedor fornecedorParaRemover = (Fornecedor)listV.SelectedItems[0].Tag;

            oProduto.OFornecedor.Remove(fornecedorParaRemover);

            // Se o fornecedor já estava salvo no banco, adiciona à lista de remoção
            if (fornecedorParaRemover.Id > 0)
            {
                fornecedoresRemovidos.Add(fornecedorParaRemover);
            }

            CarregaLV();
        }

        // --- EVENTOS DE CLICK DOS BOTÕES ---

        private void btnAddForn_Click(object sender, EventArgs e)
        {
            AdicionarFornecedor();
        }

        private void btnExcluirParc_Click(object sender, EventArgs e)
        {
            // O nome do seu botão é btnExcluirParc, mas a função é remover fornecedor.
            RemoverFornecedor();
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                btnExcluirParc.Enabled = true;
            }
            else
            {
                btnExcluirParc.Enabled = false;
            }
        }

        // --- EVENTOS DE PESQUISA ---

        private void btnUniMed_Click(object sender, EventArgs e)
        {
            aFormConsultaUnidadeMedida.ConhecaObj(oProduto.AUnidadeMedida, aCtrlUniMedida);
            aFormConsultaUnidadeMedida.ShowDialog();
            txtCodUniMed.Text = oProduto.AUnidadeMedida.Id.ToString();
            txtUniMed.Text = oProduto.AUnidadeMedida.Nome;
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            aFormConsultaCategoria.ConhecaObj(oProduto.ACategoria, aCtrlCategoria);
            aFormConsultaCategoria.ShowDialog();
            txtCodCategoria.Text = oProduto.ACategoria.Id.ToString();
            txtCategoria.Text = oProduto.ACategoria.Nome;
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            aFormConsultaMarca.ConhecaObj(oProduto.AMarca, aCtrlMarca);
            aFormConsultaMarca.ShowDialog();
            txtCodMarca.Text = oProduto.AMarca.Id.ToString();
            txtMarca.Text = oProduto.AMarca.Nome;
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            aFormConsultaFornecedor.ConhecaObj(oFornecedorSelecionado, aCtrlFornecedor);
            aFormConsultaFornecedor.ShowDialog();
            txtCodFornecedor.Text = oFornecedorSelecionado.Id.ToString();
            txtFornecedor.Text = oFornecedorSelecionado.NomeRazaoSocial;
        }
    }
}