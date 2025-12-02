using Microsoft.VisualBasic;
using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.daos;
using projeto_pratica.pages.consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.cadastro
{
    public partial class frmCadastroNotaSaida : projeto_pratica.pages.cadastro.frmCadastro
    {
        private NotaSaida aNotaSaida;
        private CtrlNotaSaida aCtrlNotaSaida;

        private Funcionario oFuncionario;
        private Cliente oCliente;
        private Produto oProduto;
        private CondicaoPagamento aCondPag;
        private ItensNotaSaida _itemSelecionado;

        private CtrlFuncionario aCtrlFuncionario;
        private CtrlCliente aCtrlCliente;
        private CtrlProduto aCtrlProduto;
        private CtrlCondPag aCtrlCondPag;

        private frmConsultaFuncionario aFrmConsultaFuncionario;
        private frmConsultaCliente aFrmConsultaCliente;
        private frmConsultaProduto aFrmConsultaProduto;
        private frmConsultaCondPag aFrmConsultaCondPag;

        public frmCadastroNotaSaida()
        {
            InitializeComponent();

            // modelo de entrada → saída: mesmo fluxo, trocando fornecedor→cliente+funcionário
            aNotaSaida = new NotaSaida();
            aCtrlNotaSaida = new CtrlNotaSaida();

            oFuncionario = new Funcionario();
            oCliente = new Cliente();
            oProduto = new Produto();
            aCondPag = new CondicaoPagamento();

            aCtrlFuncionario = new CtrlFuncionario();
            aCtrlCliente = new CtrlCliente();
            aCtrlProduto = new CtrlProduto();
            aCtrlCondPag = new CtrlCondPag();

            aFrmConsultaFuncionario = new frmConsultaFuncionario();
            aFrmConsultaCliente = new frmConsultaCliente();
            aFrmConsultaProduto = new frmConsultaProduto();
            aFrmConsultaCondPag = new frmConsultaCondPag();

            LimparTxt();
        }

        // setters usados por telas de consulta (se você as injeta de fora)
        public void setFrmConsultaFuncioanrio(object obj) => aFrmConsultaFuncionario = (frmConsultaFuncionario)obj;
        public void setFrmConsultaCliente(object obj) => aFrmConsultaCliente = (frmConsultaCliente)obj;
        public void setFrmConsultaProduto(object obj) => aFrmConsultaProduto = (frmConsultaProduto)obj;
        public void setFrmConsultaCondPag(object obj) => aFrmConsultaCondPag = (frmConsultaCondPag)obj;


        public override void ConhecaObj(object obj, object ctrl)
        {
            aNotaSaida = (NotaSaida)obj;
            aCtrlNotaSaida = (CtrlNotaSaida)ctrl;
            CarregarTxt();
        }

        public override void Salvar()
        {
            if (btnSave.Text == "Salvar")
            {
                try
                {
                    PopulaObjetoDoForm();

                    if (aNotaSaida.OCliente == null || aNotaSaida.OCliente.Id == 0)
                    {
                        MessageBox.Show("É obrigatório selecionar um cliente.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (aNotaSaida.OFuncionario == null || aNotaSaida.OFuncionario.Id == 0)
                    {
                        MessageBox.Show("É obrigatório selecionar um funcionário.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (aNotaSaida.ItensDaNota.Count == 0)
                    {
                        MessageBox.Show("A nota de saída deve conter pelo menos um item.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string resultado = aCtrlNotaSaida.Salvar(aNotaSaida);

                    if (int.TryParse(resultado, out int idSalvo))
                    {
                        aNotaSaida.Id = idSalvo;
                        txtCodigo.Text = idSalvo.ToString();
                        MessageBox.Show("Nota de Saída salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao salvar a nota: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnSave.Text == "Excluir")
            {
                if (MessageBox.Show("Tem certeza que deseja cancelar esta Nota de Saída?\nEsta ação reverterá a baixa de estoque.",
                                    "Confirmar Cancelamento",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string motivo = Interaction.InputBox("Por favor, informe o motivo do cancelamento:", "Motivo do Cancelamento");
                    if (string.IsNullOrWhiteSpace(motivo))
                    {
                        MessageBox.Show("O motivo é obrigatório para cancelar a nota.", "Operação Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        PopulaObjetoDoForm();
                        aNotaSaida.Ativo = false;
                        aNotaSaida.MotivoCancelamento = motivo;

                        string resultado = aCtrlNotaSaida.Salvar(aNotaSaida);

                        if (int.TryParse(resultado, out _))
                        {
                            MessageBox.Show("Nota de Saída cancelada com sucesso! A baixa de estoque foi revertida.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Erro ao cancelar a nota: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro inesperado ao cancelar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public override void LimparTxt()
        {
            base.LimparTxt();
            aNotaSaida = new NotaSaida();
            _itemSelecionado = null;

            txtCodigo.Text = "55";
            txtSerie.Text = "1";
            txtNum.Clear();

            txtCodCliente.Clear();
            txtCliente.Clear();

            txtCodFuncionario.Clear();
            txtFuncionario.Clear();

            dtpDataEmissao.Value = DateTime.Now;
            ckbStatus.Checked = true;

            LimpaCamposItem();
            listVProdutos.Items.Clear();

            txtCodCondPag.Clear();
            txtCondPag.Clear();
            listVCondPag.Items.Clear();

            txtValTotalNota.Text = "0,00";
            txtQtdTotal.Text = "0,00";
            txtCredCliente.Text = "0,00";
        }

        public override void BloqueiaTxt()
        {
            base.BloqueiaTxt();

            txtSerie.Enabled = false;
            txtNum.Enabled = false;
            txtCodCliente.Enabled = false;
            txtCliente.Enabled = false;
            txtCodFuncionario.Enabled = false;
            txtFuncionario.Enabled = false;

            txtCodProd.Enabled = false;
            txtQtd.Enabled = false;
            txtValUnit.Enabled = false;
            txtProduto.Enabled = false;

            txtCodCondPag.Enabled = false;
            txtCondPag.Enabled = false;

            btnPesquisarCliente.Enabled = false;
            btnPesquisarFunc.Enabled = false;
            btnPesquisarProd.Enabled = false;
            btnAdicionar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = false;
            btnPesquisarCondPag.Enabled = false;

            dtpDataEmissao.Enabled = false;

            listVCondPag.Enabled = false;
            listVProdutos.Enabled = false;
        }

        public override void DesbloqueiaTxt()
        {
            base.DesbloqueiaTxt();

            txtSerie.Enabled = true;
            txtNum.Enabled = true;
            txtCodCliente.Enabled = true;
            txtCliente.Enabled = true;
            txtCodFuncionario.Enabled = true;
            txtFuncionario.Enabled = true;

            txtCodProd.Enabled = true;
            txtQtd.Enabled = true;
            txtValUnit.Enabled = true;
            txtProduto.Enabled = true;

            txtCodCondPag.Enabled = true;
            txtCondPag.Enabled = true;

            btnPesquisarCliente.Enabled = true;
            btnPesquisarFunc.Enabled = true;
            btnPesquisarProd.Enabled = true;
            btnAdicionar.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnCancelar.Enabled = true;
            btnPesquisarCondPag.Enabled = true;

            dtpDataEmissao.Enabled = true;

            listVCondPag.Enabled = true;
            listVProdutos.Enabled = true;
        }

        public override void CarregarTxt()
        {
            if (aNotaSaida == null) return;

            txtCodigo.Text = aNotaSaida.Modelo;
            txtSerie.Text = aNotaSaida.Serie;
            txtNum.Text = aNotaSaida.Numero;
            ckbStatus.Checked = aNotaSaida.Ativo;
            dtpDataEmissao.Value = aNotaSaida.DataEmissao;

            if (aNotaSaida.OCliente != null)
            {
                txtCodCliente.Text = aNotaSaida.OCliente.Id.ToString();
                txtCliente.Text = aNotaSaida.OCliente.NomeRazaoSocial;
                if (aNotaSaida.OCliente.LimiteCredito > 0)
                    txtCredCliente.Text = aNotaSaida.OCliente.LimiteCredito.ToString("F2");
            }
            if (aNotaSaida.OFuncionario != null)
            {
                txtCodFuncionario.Text = aNotaSaida.OFuncionario.Id.ToString();
                txtFuncionario.Text = aNotaSaida.OFuncionario.NomeRazaoSocial;
            }

            if (aNotaSaida.ACondicaoPagamento != null)
            {
                txtCodCondPag.Text = aNotaSaida.ACondicaoPagamento.Id.ToString();
                txtCondPag.Text = aNotaSaida.ACondicaoPagamento.Descricao;
                AtualizaListViewParcelas();
            }

            AtualizaListViewItens();
            AtualizaTotaisRodape();
            txtDtCriacao.Text = aNotaSaida.DtCriacao.ToString();
            txtDtAlt.Text = aNotaSaida.DtAlt.ToString();
        }

        // ==== itens ====

        private void AdicionarItem()
        {
            if (!ValidaCamposItem(out ItensNotaSaida novoItem)) return;

            aNotaSaida.ItensDaNota.Add(novoItem);
            AtualizaListViewItens();
            LimpaCamposItem();
            AtualizaTotaisRodape();
        }

        private void AlterarItem()
        {
            if (_itemSelecionado == null)
            {
                MessageBox.Show("Nenhum item selecionado para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidaCamposItem(out ItensNotaSaida itemAlterado)) return;

            _itemSelecionado.OProduto = itemAlterado.OProduto;
            _itemSelecionado.Qtd = itemAlterado.Qtd;
            _itemSelecionado.ValorUnitario = itemAlterado.ValorUnitario;
            _itemSelecionado.DtAlt = DateTime.Now;

            AtualizaListViewItens();
            LimpaCamposItem();
            AtualizaTotaisRodape();
        }

        private void ExcluirItem()
        {
            if (_itemSelecionado == null)
            {
                MessageBox.Show("Nenhum item selecionado para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Deseja realmente remover o item selecionado?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                aNotaSaida.ItensDaNota.Remove(_itemSelecionado);
                AtualizaListViewItens();
                LimpaCamposItem();
                AtualizaTotaisRodape();
            }
        }

        private bool ValidaCamposItem(out ItensNotaSaida item)
        {
            item = null;
            if (string.IsNullOrWhiteSpace(txtCodProd.Text))
            {
                MessageBox.Show("Selecione um produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtQtd.Text, out decimal qtd) || qtd <= 0)
            {
                MessageBox.Show("A quantidade deve ser um número maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtValUnit.Text, out decimal valorUnit) || valorUnit < 0)
            {
                MessageBox.Show("O preço de venda deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            item = new ItensNotaSaida
            {
                OProduto = oProduto,
                Qtd = qtd,
                ValorUnitario = valorUnit
            };
            return true;
        }

        private void AtualizaListViewItens()
        {
            listVProdutos.Items.Clear();
            foreach (var item in aNotaSaida.ItensDaNota)
            {
                var lvi = new ListViewItem(item.OProduto.Id.ToString());
                lvi.SubItems.Add(item.OProduto.Nome);
                lvi.SubItems.Add(item.OProduto.AUnidadeMedida?.Nome ?? "N/D");
                lvi.SubItems.Add(item.Qtd.ToString("F2"));
                lvi.SubItems.Add(item.ValorUnitario.ToString("C2"));
                lvi.SubItems.Add(item.ValorTotal.ToString("C2"));
                lvi.Tag = item;
                listVProdutos.Items.Add(lvi);
            }
        }

        private void AtualizaListViewParcelas()
        {
            listVCondPag.Items.Clear();
            if (aNotaSaida.ACondicaoPagamento?.ParcelasCondPag == null ||
                !aNotaSaida.ACondicaoPagamento.ParcelasCondPag.Any())
            {
                return;
            }

            decimal valorTotalNota = aNotaSaida.SubTotalProdutos; 
            decimal valorAcumulado = 0;

            var parcelas = aNotaSaida.ACondicaoPagamento.ParcelasCondPag.ToList();
            int totalDeParcelas = parcelas.Count;

            for (int i = 0; i < totalDeParcelas; i++)
            {
                var p = parcelas[i];
                bool isUltimaParcela = (i == totalDeParcelas - 1);

                decimal valorParcela;
                if (isUltimaParcela)
                {
                    valorParcela = valorTotalNota - valorAcumulado;
                }
                else
                {
                    decimal percentualDaParcela = Convert.ToDecimal(p.Percentual) / 100;
                    valorParcela = Math.Round(valorTotalNota * percentualDaParcela, 2);
                    valorAcumulado += valorParcela;
                }

                var lvi = new ListViewItem(p.NumeroParcela.ToString());
                lvi.SubItems.Add(p.Prazo.ToString());
                lvi.SubItems.Add(p.Percentual.ToString("F2"));
                lvi.SubItems.Add(p.AFormPag.Descricao);
                lvi.SubItems.Add(valorParcela.ToString("F2"));

                listVCondPag.Items.Add(lvi);
            }
        }

        private void AtualizaTotaisRodape()
        {
            txtValTotalNota.Text = aNotaSaida.SubTotalProdutos.ToString("C2");
            txtQtdTotal.Text = aNotaSaida.ItensDaNota.Sum(i => i.Qtd).ToString("F2");
            AtualizaListViewParcelas();
        }

        // ==== handlers do formulário ====

        private void btnAdicionar_Click(object sender, EventArgs e) => AdicionarItem();
        private void btnAlterar_Click(object sender, EventArgs e) => AlterarItem();
        private void btnExcluir_Click(object sender, EventArgs e) => ExcluirItem();
        private void btnCancelar_Click(object sender, EventArgs e) => LimpaCamposItem();


        private void MudarEstadoBotoesItem(bool emModoEdicao)
        {
            btnAdicionar.Enabled = !emModoEdicao;
            btnAlterar.Enabled = emModoEdicao;
            btnExcluir.Enabled = emModoEdicao;
            btnCancelar.Enabled = emModoEdicao;
        }

        private void LimpaCamposItem()
        {
            txtCodProd.Clear();
            txtProduto.Clear();
            txtQtd.Clear();
            txtValUnit.Clear();
            oProduto = new Produto();
            _itemSelecionado = null;
            MudarEstadoBotoesItem(false);
        }

        // ==== buscas (cliente, funcionário, produto, condpag) ====

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            aFrmConsultaCliente.ConhecaObj(oCliente, aCtrlCliente);
            aFrmConsultaCliente.ShowDialog();

            aNotaSaida.OCliente = oCliente;
            txtCodCliente.Text = aNotaSaida.OCliente?.Id.ToString() ?? "";
            txtCliente.Text = aNotaSaida.OCliente?.NomeRazaoSocial ?? "";

            // Condição padrão do cliente, se houver:
            txtCodCondPag.Text = aNotaSaida.OCliente?.ACondPag?.Id > 0 ? aNotaSaida.OCliente.ACondPag.Id.ToString() : "";
            if (int.TryParse(txtCodCondPag.Text, out int id))
            {
                aCondPag = aCtrlCondPag.BuscarPorId(id);
                if (aCondPag != null)
                {
                    aNotaSaida.ACondicaoPagamento = aCondPag;
                    txtCondPag.Text = aCondPag.Descricao;
                    AtualizaTotaisRodape();
                }
                else
                {
                    aNotaSaida.ACondicaoPagamento = new CondicaoPagamento();
                    txtCondPag.Clear();
                    listVCondPag.Items.Clear();
                }
            }

            // crédito (se usar)
            if (aNotaSaida.OCliente != null)
                txtCredCliente.Text = aNotaSaida.OCliente.LimiteCredito.ToString("F2");
        }

        private void btnPesquisarFunc_Click(object sender, EventArgs e)
        {
            aFrmConsultaFuncionario.ConhecaObj(oFuncionario, aCtrlFuncionario);
            aFrmConsultaFuncionario.ShowDialog();

            aNotaSaida.OFuncionario = oFuncionario;
            txtCodFuncionario.Text = aNotaSaida.OFuncionario?.Id.ToString() ?? "";
            txtFuncionario.Text = aNotaSaida.OFuncionario?.NomeRazaoSocial ?? "";
        }

        private void btnPesquisarProd_Click(object sender, EventArgs e)
        {
            aFrmConsultaProduto.ConhecaObj(oProduto, aCtrlProduto);
            aFrmConsultaProduto.ShowDialog();

            txtCodProd.Text = oProduto?.Id.ToString() ?? "";
            txtProduto.Text = oProduto?.Nome ?? "";
            // Pré-preenche preço de venda do produto
            if (oProduto != null && oProduto.Id > 0)
                txtValUnit.Text = oProduto.Venda.ToString("F2");
        }

        private void txtCodCliente_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodCliente.Text))
            {
                aNotaSaida.OCliente = new Cliente();
                txtCliente.Clear();
                return;
            }

            if (int.TryParse(txtCodCliente.Text, out int id))
            {
                oCliente = aCtrlCliente.BuscarPorId(id);
                if (oCliente != null)
                {
                    aNotaSaida.OCliente = oCliente;
                    txtCodCliente.Text = oCliente.Id.ToString();
                    txtCliente.Text = oCliente.NomeRazaoSocial;

                    txtCredCliente.Text = oCliente.LimiteCredito.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    aNotaSaida.OCliente = new Cliente();
                    txtCodCliente.Clear();
                    txtCliente.Clear();
                    txtCredCliente.Text = "0,00";
                }
            }
        }

        private void txtCodFuncionario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodFuncionario.Text))
            {
                aNotaSaida.OFuncionario = new Funcionario();
                txtFuncionario.Clear();
                return;
            }

            if (int.TryParse(txtCodFuncionario.Text, out int id))
            {
                oFuncionario = aCtrlFuncionario.BuscarPorId(id);
                if (oFuncionario != null)
                {
                    aNotaSaida.OFuncionario = oFuncionario;
                    txtCodFuncionario.Text = oFuncionario.Id.ToString();
                    txtFuncionario.Text = oFuncionario.NomeRazaoSocial;
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    aNotaSaida.OFuncionario = new Funcionario();
                    txtCodFuncionario.Clear();
                    txtFuncionario.Clear();
                }
            }
        }

        private void txtCodProd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodProd.Text))
            {
                oProduto = new Produto();
                txtProduto.Clear();
                txtValUnit.Clear();
                return;
            }

            if (int.TryParse(txtCodProd.Text, out int id))
            {
                oProduto = aCtrlProduto.BuscarPorId(id);
                if (oProduto != null)
                {
                    txtCodProd.Text = oProduto.Id.ToString();
                    txtProduto.Text = oProduto.Nome;
                    txtValUnit.Text = oProduto.Venda.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    oProduto = new Produto();
                    txtCodProd.Clear();
                    txtProduto.Clear();
                    txtValUnit.Clear();
                }
            }
        }

        private void txtCodCondPag_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodCondPag.Text))
            {
                aNotaSaida.ACondicaoPagamento = new CondicaoPagamento();
                txtCondPag.Clear();
                listVCondPag.Items.Clear();
                return;
            }

            if (int.TryParse(txtCodCondPag.Text, out int id))
            {
                aCondPag = aCtrlCondPag.BuscarPorId(id);
                if (aCondPag != null)
                {
                    aNotaSaida.ACondicaoPagamento = aCondPag;
                    txtCodCondPag.Text = aCondPag.Id.ToString();
                    txtCondPag.Text = aCondPag.Descricao;
                    AtualizaTotaisRodape();
                }
                else
                {
                    MessageBox.Show("Condição de Pagamento não encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    aNotaSaida.ACondicaoPagamento = new CondicaoPagamento();
                    txtCodCondPag.Clear();
                    txtCondPag.Clear();
                    listVCondPag.Items.Clear();
                }
            }
        }

        // ==== utilidades ====

        private void PopulaObjetoDoForm()
        {
            aNotaSaida.Modelo = txtCodigo.Text;
            aNotaSaida.Serie = txtSerie.Text;
            aNotaSaida.Numero = txtNum.Text;
            aNotaSaida.Ativo = ckbStatus.Checked;
            aNotaSaida.DataEmissao = dtpDataEmissao.Value;

            // Objetos já atribuídos nos handlers de busca/leave:
            aNotaSaida.OCliente = aNotaSaida.OCliente ?? new Cliente();
            aNotaSaida.OFuncionario = aNotaSaida.OFuncionario ?? new Funcionario();

            if (aNotaSaida.Id > 0) aNotaSaida.DtAlt = DateTime.Now;
            else aNotaSaida.DtCriacao = DateTime.Now;
        }

        private void btnPesquisarCondPag_Click(object sender, EventArgs e)
        {
            aFrmConsultaCondPag.ConhecaObj(aCondPag, aCtrlCondPag);
            aFrmConsultaCondPag.ShowDialog();

            aNotaSaida.ACondicaoPagamento = aCondPag;
            txtCodCondPag.Text = aNotaSaida.ACondicaoPagamento?.Id.ToString() ?? "";
            txtCondPag.Text = aNotaSaida.ACondicaoPagamento?.Descricao ?? "";
            AtualizaListViewParcelas();
        }

        private void listVProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listVProdutos.SelectedItems.Count > 0)
            {
                _itemSelecionado = (ItensNotaSaida)listVProdutos.SelectedItems[0].Tag;
                oProduto = _itemSelecionado.OProduto;

                txtCodProd.Text = _itemSelecionado.OProduto.Id.ToString();
                txtProduto.Text = _itemSelecionado.OProduto.Nome;
                txtQtd.Text = _itemSelecionado.Qtd.ToString();
                txtValUnit.Text = _itemSelecionado.ValorUnitario.ToString();

                MudarEstadoBotoesItem(true);
            }
            else
            {
                _itemSelecionado = null;
                MudarEstadoBotoesItem(false);
            }
        }

    }
}
