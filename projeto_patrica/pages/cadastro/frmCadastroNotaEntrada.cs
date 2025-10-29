using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace projeto_pratica.pages.cadastro
{
    public partial class frmCadastroNotaEntrada : projeto_pratica.pages.cadastro.frmCadastro
    {
        private NotaEntrada aNotaEntrada;
        private CtrlNotaEntrada aCtrlNotaEntrada;
        private bool _isBlockingControls = false; // <--- ADICIONE ESTA LINHA

        // Objetos temporários para receber dados das telas de consulta
        private Fornecedor oFornecedor;
        private Produto oProduto;
        private CondicaoPagamento aCondPag;
        private ItensNotaEntrada _itemSelecionado; // Para gerenciar o item selecionado na lista

        // Controladores para as entidades relacionadas
        private CtrlFornecedor aCtrlFornecedor;
        private CtrlProduto aCtrlProduto;
        private CtrlCondPag aCtrlCondPag;

        // Forms de consulta
        private frmConsultaFornecedor aFrmConsultaFornecedor;
        private frmConsultaProduto aFrmConsultaProduto;
        private frmConsultaCondPag aFrmConsultaCondPag;

        public frmCadastroNotaEntrada()
        {
            InitializeComponent();
            // Inicializa o objeto principal e seu controlador
            aNotaEntrada = new NotaEntrada();
            aCtrlNotaEntrada = new CtrlNotaEntrada();

            // Inicializa objetos e controladores de apoio
            oFornecedor = new Fornecedor();
            oProduto = new Produto();
            aCondPag = new CondicaoPagamento();

            aCtrlFornecedor = new CtrlFornecedor();
            aCtrlProduto = new CtrlProduto();
            aCtrlCondPag = new CtrlCondPag();

            // Inicializa os formulários de consulta
            aFrmConsultaFornecedor = new frmConsultaFornecedor();
            aFrmConsultaProduto = new frmConsultaProduto();
            aFrmConsultaCondPag = new frmConsultaCondPag();

            LimparTxt(); // Garante que o form comece limpo e com valores padrão
        }
        public void setFrmConsultaFornecedor(object obj)
        {
            aFrmConsultaFornecedor = (frmConsultaFornecedor)obj;
        }
        public void setFrmConsultaProduto(object obj)
        {
            aFrmConsultaProduto = (frmConsultaProduto)obj;
        }
        public void setFrmConsultaCondPag(object obj)
        {
            aFrmConsultaCondPag = (frmConsultaCondPag)obj;
        }


        public override void ConhecaObj(object obj, object ctrl)
        {
            aNotaEntrada = (NotaEntrada)obj;
            aCtrlNotaEntrada = (CtrlNotaEntrada)ctrl;
            CarregarTxt();
        }

        public override void Salvar()
        {

            if (btnSave.Text == "Salvar")
            {
                try
                {
                    PopulaObjetoDoForm();

                    if (aNotaEntrada.OFornecedor == null || aNotaEntrada.OFornecedor.Id == 0)
                    {
                        MessageBox.Show("É obrigatório selecionar um fornecedor.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (aNotaEntrada.ItensDaNota.Count == 0)
                    {
                        MessageBox.Show("A nota de entrada deve conter pelo menos um item.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string resultado = aCtrlNotaEntrada.Salvar(aNotaEntrada);

                    if (int.TryParse(resultado, out int idSalvo))
                    {
                        aNotaEntrada.Id = idSalvo;
                        txtCodigo.Text = idSalvo.ToString();
                        MessageBox.Show("Nota de Entrada salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (MessageBox.Show("Tem certeza que deseja cancelar esta Nota de Entrada?\nEsta ação reverterá o estoque.",
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
                        aNotaEntrada.Ativo = false;
                        aNotaEntrada.MotivoCancelamento = motivo; 

                        string resultado = aCtrlNotaEntrada.Salvar(aNotaEntrada);

                        if (int.TryParse(resultado, out int idSalvo))
                        {
                            MessageBox.Show("Nota de Entrada cancelada com sucesso! O estoque foi revertido.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            aNotaEntrada = new NotaEntrada();
            _itemSelecionado = null;

            txtCodigo.Clear();
            txtSerie.Clear();
            txtNum.Clear();
            txtCodForn.Clear();
            txtFornecedor.Clear();
            dtpDataEmissao.Value = DateTime.Now;
            dtpDataChegada.Value = DateTime.Now;
            ckbStatus.Checked = true;

            LimpaCamposItem();
            listVProdutos.Items.Clear();

            txtValFrete.Text = "0,00";
            txtSeguro.Text = "0,00";
            txtDespesas.Text = "0,00";

            txtCodCondPag.Clear(); 
            txtCondPag.Clear();
            listVCondPag.Items.Clear();

            AtualizaTotalNota();
        }

        public override void BloqueiaTxt()
        {
            base.BloqueiaTxt();
            this.txtValFrete.Leave -= new System.EventHandler(this.txtValoresRodape_Leave);
            this.txtSeguro.Leave -= new System.EventHandler(this.txtValoresRodape_Leave);
            this.txtDespesas.Leave -= new System.EventHandler(this.txtValoresRodape_Leave);
            // --- TextBoxes ---
            this.txtSerie.Enabled = false;
            this.txtNum.Enabled = false;
            this.txtCodForn.Enabled = false;
            this.txtFornecedor.Enabled = false;
            this.txtCodProd.Enabled = false;
            this.txtQtd.Enabled = false;
            this.txtValUnit.Enabled = false;
            this.txtProduto.Enabled = false;
            this.txtSeguro.Enabled = false;
            this.txtValFrete.Enabled = false;
            this.txtValTotal.Enabled = false;
            this.txtDespesas.Enabled = false;
            this.txtCodCondPag.Enabled = false;
            this.txtCondPag.Enabled = false;

            // --- Buttons ---
            this.btnPesquisarForn.Enabled = false;
            this.btnPesquisarProd.Enabled = false;
            this.btnAdicionar.Enabled = false;
            this.btnAlterar.Enabled = false;
            this.btnExcluir.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnPesquisarCondPag.Enabled = false;

            this.dtpDataChegada.Enabled = false;
            this.dtpDataEmissao.Enabled = false;

            this.listVCondPag.Enabled = false;
            this.listVProdutos.Enabled = false;

        }

        public override void DesbloqueiaTxt()
        {
            base.DesbloqueiaTxt();
            

            // --- TextBoxes ---
            this.txtSerie.Enabled = true;
            this.txtNum.Enabled = true;
            this.txtCodForn.Enabled = true;
            this.txtFornecedor.Enabled = true;
            this.txtCodProd.Enabled = true;
            this.txtQtd.Enabled = true;
            this.txtValUnit.Enabled = true;
            this.txtProduto.Enabled = true;
            this.txtSeguro.Enabled = true;
            this.txtValFrete.Enabled = true;
            this.txtValTotal.Enabled = true;
            this.txtDespesas.Enabled = true;
            this.txtCodCondPag.Enabled = true;
            this.txtCondPag.Enabled = true;

            // --- Buttons ---
            this.btnPesquisarForn.Enabled = true;
            this.btnPesquisarProd.Enabled = true;
            this.btnAdicionar.Enabled = true;
            this.btnAlterar.Enabled = true;
            this.btnExcluir.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnPesquisarCondPag.Enabled = true;

            this.dtpDataChegada.Enabled = true;
            this.dtpDataEmissao.Enabled = true;

            this.listVCondPag.Enabled = true;
            this.listVProdutos.Enabled = true;
            this.txtValFrete.Leave += new System.EventHandler(this.txtValoresRodape_Leave);
            this.txtSeguro.Leave += new System.EventHandler(this.txtValoresRodape_Leave);
            this.txtDespesas.Leave += new System.EventHandler(this.txtValoresRodape_Leave);
        }

        public override void CarregarTxt()
        {
            if (aNotaEntrada == null) return;

            txtCodigo.Text = aNotaEntrada.Modelo;
            txtSerie.Text = aNotaEntrada.Serie;
            txtNum.Text = aNotaEntrada.Numero;
            ckbStatus.Checked = aNotaEntrada.Ativo;
            dtpDataEmissao.Value = aNotaEntrada.DataEmissao;
            dtpDataChegada.Value = aNotaEntrada.DataChegada;

            if (aNotaEntrada.OFornecedor != null)
            {
                txtCodForn.Text = aNotaEntrada.OFornecedor.Id.ToString();
                txtFornecedor.Text = aNotaEntrada.OFornecedor.NomeRazaoSocial;
            }

            txtValFrete.Text = aNotaEntrada.ValorFrete.ToString("F2");
            txtSeguro.Text = aNotaEntrada.ValorSeguro.ToString("F2");
            txtDespesas.Text = aNotaEntrada.OutrasDespesas.ToString("F2");
            txtValTotal.Text = aNotaEntrada.ValorTotalNota.ToString("F2");

            if (aNotaEntrada.ACondicaoPagamento != null)
            {
                txtCodCondPag.Text = aNotaEntrada.ACondicaoPagamento.Id.ToString();
                txtCondPag.Text = aNotaEntrada.ACondicaoPagamento.Descricao;
                AtualizaListViewParcelas();
            }
            txtDtCriacao.Text = aNotaEntrada.DtCriacao.ToString();
            txtDtAlt.Text = aNotaEntrada.DtAlt.ToString();


            AtualizaListViewItens();
        }

        private void AdicionarItem()
        {
            if (!ValidaCamposItem(out ItensNotaEntrada novoItem)) return;

            aNotaEntrada.ItensDaNota.Add(novoItem);
            AtualizaListViewItens();
            LimpaCamposItem();
            AtualizaTotalNota();
        }

        private void AlterarItem()
        {
            if (_itemSelecionado == null)
            {
                MessageBox.Show("Nenhum item selecionado para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidaCamposItem(out ItensNotaEntrada itemAlterado)) return;

            _itemSelecionado.OProduto = itemAlterado.OProduto;
            _itemSelecionado.Qtd = itemAlterado.Qtd;
            _itemSelecionado.ValorUnitario = itemAlterado.ValorUnitario;
            _itemSelecionado.DtAlt = DateTime.Now;

            AtualizaListViewItens();
            LimpaCamposItem();
            AtualizaTotalNota();
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
                aNotaEntrada.ItensDaNota.Remove(_itemSelecionado);
                AtualizaListViewItens();
                LimpaCamposItem();
                AtualizaTotalNota();
            }
        }

        private void PopulaObjetoDoForm()
        {
            aNotaEntrada.Modelo = txtCodigo.Text; 
            aNotaEntrada.Serie = txtSerie.Text;
            aNotaEntrada.Numero = txtNum.Text;
            aNotaEntrada.Ativo = ckbStatus.Checked;
            aNotaEntrada.DataEmissao = dtpDataEmissao.Value;
            aNotaEntrada.DataChegada = dtpDataChegada.Value;

            aNotaEntrada.ValorFrete = decimal.TryParse(txtValFrete.Text, out var frete) ? frete : 0;
            aNotaEntrada.ValorSeguro = decimal.TryParse(txtSeguro.Text, out var seguro) ? seguro : 0;
            aNotaEntrada.OutrasDespesas = decimal.TryParse(txtDespesas.Text, out var despesas) ? despesas : 0;

            if (aNotaEntrada.Id > 0) aNotaEntrada.DtAlt = DateTime.Now;
            else aNotaEntrada.DtCriacao = DateTime.Now;
        }

        private bool ValidaCamposItem(out ItensNotaEntrada item)
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
                MessageBox.Show("O valor unitário deve ser um número válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            item = new ItensNotaEntrada
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
            foreach (var item in aNotaEntrada.ItensDaNota)
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
            if (aNotaEntrada.ACondicaoPagamento?.ParcelasCondPag == null) return;

            foreach (var p in aNotaEntrada.ACondicaoPagamento.ParcelasCondPag)
            {
                var lvi = new ListViewItem(p.NumeroParcela.ToString());
                lvi.SubItems.Add(p.Prazo.ToString());
                lvi.SubItems.Add(p.Percentual.ToString("F2"));
                lvi.SubItems.Add(p.AFormPag.Descricao);
                lvi.SubItems.Add((aNotaEntrada.ValorTotalNota * (p.Percentual/100)).ToString());
                listVCondPag.Items.Add(lvi);
            }
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

        private void MudarEstadoBotoesItem(bool emModoEdicao)
        {
            btnAdicionar.Enabled = !emModoEdicao;
            btnAlterar.Enabled = emModoEdicao;
            btnExcluir.Enabled = emModoEdicao;
            btnCancelar.Enabled = emModoEdicao;
        }

        private void btnAdicionar_Click(object sender, EventArgs e) => AdicionarItem();
        private void btnAlterar_Click(object sender, EventArgs e) => AlterarItem();
        private void btnExcluir_Click(object sender, EventArgs e) => ExcluirItem();
        private void btnCancelar_Click(object sender, EventArgs e) => LimpaCamposItem();

        private void listVProdutos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listVProdutos.SelectedItems.Count > 0)
            {
                _itemSelecionado = (ItensNotaEntrada)listVProdutos.SelectedItems[0].Tag;
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
        private void AtualizaTotalNota()
        {

            txtValTotal.Text = aNotaEntrada.ValorTotalNota.ToString("C2");
            AtualizaListViewParcelas();
        }

        private void txtValoresRodape_Leave(object sender, EventArgs e)
        {
            // Chame o novo método
            AtualizaObjetoPeloRodape();
        }
        private void AtualizaObjetoPeloRodape()
        {
            // Este método SIM, lê dos TextBoxes e escreve no objeto
            aNotaEntrada.ValorFrete = decimal.TryParse(txtValFrete.Text, out var frete) ? frete : 0;
            aNotaEntrada.ValorSeguro = decimal.TryParse(txtSeguro.Text, out var seguro) ? seguro : 0;
            aNotaEntrada.OutrasDespesas = decimal.TryParse(txtDespesas.Text, out var despesas) ? despesas : 0;

            // E então recalcula o total
            AtualizaTotalNota();

        }

        private void btnPesquisarForn_Click(object sender, EventArgs e)
        {
            aFrmConsultaFornecedor.ConhecaObj(oFornecedor, aCtrlFornecedor);
            aFrmConsultaFornecedor.ShowDialog();

            aNotaEntrada.OFornecedor = oFornecedor;
            txtCodForn.Text = aNotaEntrada.OFornecedor?.Id.ToString() ?? "";
            txtFornecedor.Text = aNotaEntrada.OFornecedor?.NomeRazaoSocial ?? "";
        }

        private void btnPesquisarProd_Click(object sender, EventArgs e)
        {
            aFrmConsultaProduto.ConhecaObj(oProduto, aCtrlProduto);
            aFrmConsultaProduto.ShowDialog();

            txtCodProd.Text = oProduto?.Id.ToString() ?? "";
            txtProduto.Text = oProduto?.Nome ?? "";
        }

        private void btnPesquisarCondPag_Click(object sender, EventArgs e) // Pesquisar CondPag
        {
            aFrmConsultaCondPag.ConhecaObj(aCondPag, aCtrlCondPag);
            aFrmConsultaCondPag.ShowDialog();

            aNotaEntrada.ACondicaoPagamento = aCondPag;
            txtCodCondPag.Text = aNotaEntrada.ACondicaoPagamento?.Id.ToString() ?? "";
            txtCondPag.Text = aNotaEntrada.ACondicaoPagamento?.Descricao ?? "";
            AtualizaListViewParcelas();
        }

        private void dtpDataEmissao_ValueChanged(object sender, EventArgs e)
        {
            this.dtpDataEmissao.ValueChanged -= dtpDataEmissao_ValueChanged;

            if (dtpDataEmissao.Value < DateTime.Now)
            {
                dtpDataEmissao.Value = DateTime.Now;
            }
            else if (dtpDataEmissao.Value >= dtpDataChegada.Value)
            {
                dtpDataEmissao.Value = dtpDataChegada.Value;
            }

            this.dtpDataEmissao.ValueChanged += dtpDataEmissao_ValueChanged;
        }

        private void dtpDataChegada_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDataEmissao.Value >= dtpDataChegada.Value)
            {
                dtpDataChegada.Value = dtpDataEmissao.Value;
            }
        }

        private void txtCodForn_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodForn.Text))
            {
                // Limpa se o usuário apagar o código
                aNotaEntrada.OFornecedor = new Fornecedor();
                txtFornecedor.Clear();
                return;
            }

            if (int.TryParse(txtCodForn.Text, out int id))
            {
                // Busca o fornecedor no controlador
                oFornecedor = aCtrlFornecedor.BuscarPorId(id);
                if (oFornecedor != null)
                {
                    aNotaEntrada.OFornecedor = oFornecedor;
                    txtCodForn.Text = oFornecedor.Id.ToString();
                    txtFornecedor.Text = oFornecedor.NomeRazaoSocial;
                }
                else
                {
                    MessageBox.Show("Fornecedor não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    aNotaEntrada.OFornecedor = new Fornecedor();
                    txtCodForn.Clear();
                    txtFornecedor.Clear();
                }
            }
        }

        private void txtCodProd_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodProd.Text))
            {
                oProduto = new Produto();
                txtProduto.Clear();
                return;
            }

            if (int.TryParse(txtCodProd.Text, out int id))
            {
                oProduto = aCtrlProduto.BuscarPorId(id);
                if (oProduto != null)
                {
                    txtCodProd.Text = oProduto.Id.ToString();
                    txtProduto.Text = oProduto.Nome;
                    // Opcional: preencher valor unitário se o DAO o trouxer
                    // txtValUnit.Text = oProduto.Venda.ToString("F2"); 
                }
                else
                {
                    MessageBox.Show("Produto não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    oProduto = new Produto();
                    txtCodProd.Clear();
                    txtProduto.Clear();
                }
            }
        }

        private void txtCodCondPag_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodCondPag.Text))
            {
                aNotaEntrada.ACondicaoPagamento = new CondicaoPagamento();
                txtCondPag.Clear();
                AtualizaListViewParcelas();
                return;
            }

            if (int.TryParse(txtCodCondPag.Text, out int id))
            {
                aCondPag = aCtrlCondPag.BuscarPorId(id);
                if (aCondPag != null)
                {
                    aNotaEntrada.ACondicaoPagamento = aCondPag;
                    txtCodCondPag.Text = aCondPag.Id.ToString();
                    txtCondPag.Text = aCondPag.Descricao;
                    AtualizaTotalNota(); // Recalcula o total E as parcelas
                }
                else
                {
                    MessageBox.Show("Condição de Pagamento não encontrada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    aNotaEntrada.ACondicaoPagamento = new CondicaoPagamento();
                    txtCodCondPag.Clear();
                    txtCondPag.Clear();
                    AtualizaListViewParcelas();
                }
            }
        }
    }
}
