﻿using Microsoft.VisualBasic;
using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.daos;
using projeto_pratica.pages.consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.cadastro
{
    public partial class frmCadastroContasPagar : projeto_pratica.pages.cadastro.frmCadastro
    {
        private ContasPagar oContaPagar;
        private Fornecedor oFornecedor;
        private FormaPagamento aFormPag;
               
        private frmConsultaFornecedor oFrmConsultaFornecedor;
        private frmConsultaFormPag oFrmConsultaFormaPagamento;

        private CtrlContasPagar aCtrlContasPagar;
        private CtrlFornecedor aCtrlFornecedor;
        private CtrlFormPag aCtrlFormaPagamento;

        public frmCadastroContasPagar()
        {
            InitializeComponent();
            oContaPagar = new ContasPagar();
            oFornecedor = new Fornecedor();
            aFormPag = new FormaPagamento();

            aCtrlContasPagar = new CtrlContasPagar();

            aCtrlFornecedor = new CtrlFornecedor();
            aCtrlFormaPagamento = new CtrlFormPag();

            // Inicializa forms de consulta
            oFrmConsultaFornecedor = new frmConsultaFornecedor();
            oFrmConsultaFormaPagamento = new frmConsultaFormPag();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oContaPagar = (ContasPagar)obj;
            aCtrlContasPagar = (CtrlContasPagar)ctrl;
        }

        public void setFrmConsultaFornecedor(object obj)
        {
            oFrmConsultaFornecedor = (frmConsultaFornecedor)obj;
        }
        public void setFrmConsultaFormPag(object obj)
        {
            oFrmConsultaFormaPagamento = (frmConsultaFormPag)obj;
        }


        public override void LimparTxt()
        {
            base.LimparTxt();
            txtCodigo.Clear(); // ID da Conta (será preenchido pelo banco)
            txtSerie.Clear();
            txtNumDaNota.Clear();
            txtCodForn.Clear();
            txtFornecedor.Clear();
            txtNumParcela.Text = "1";
            dtpDataEmissao.Value = DateTime.Today;
            dtpDataVencimento.MinDate = dtpDataEmissao.Value.Date;
            dtpDataVencimento.Value = DateTime.Today;
            txtValorParcela.Text = "0,00";
            txtFormaPagamento.Clear();
            txtCodFormaPagamento.Clear();
            txtJuros.Text = "0,00";
            txtMulta.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtValorPago.Text = "0,00";
            dtpDataPagamento.Value = DateTime.Today;
            dtpDataPagamento.Checked = false;

            lblMotivoCancelamento.Visible = false;
            txtMotivoCancelamento.Visible = false;
            txtMotivoCancelamento.Text = "";

            txtMultaValor.Text = "0,00";
            txtJuroValor.Text = "0,00";
            txtDesctValor.Text = "0,00";

            oContaPagar = new ContasPagar();
        }

        public override void CarregarTxt()
        {
            base.CarregarTxt();

            txtCodigo.Text = oContaPagar.ANotaEntrada.Modelo.ToString();

            txtSerie.Text = oContaPagar.ANotaEntrada.Serie;
            txtNumDaNota.Text = oContaPagar.ANotaEntrada.Numero;

            txtCodForn.Text = oContaPagar.OFornecedor.Id.ToString();
            txtFornecedor.Text = oContaPagar.OFornecedor.NomeRazaoSocial;

            txtCodFormaPagamento.Text = oContaPagar.AFormaPagamento.Id.ToString();
            txtFormaPagamento.Text = oContaPagar.AFormaPagamento.Descricao;

            txtNumParcela.Text = oContaPagar.NumeroParcela.ToString();
            dtpDataEmissao.Value = oContaPagar.DataEmissao;
            dtpDataVencimento.MinDate = dtpDataEmissao.Value.Date;
            dtpDataVencimento.Value = oContaPagar.DataVencimento;
            txtValorParcela.Text = oContaPagar.ValorParcela.ToString("F2");

            txtJuros.Text = oContaPagar.Juros.ToString("F2");
            txtMulta.Text = oContaPagar.Multa.ToString("F2");
            txtDesconto.Text = oContaPagar.Desconto.ToString("F2");

            if (oContaPagar.DataPagamento.HasValue)
            {
                dtpDataPagamento.Value = oContaPagar.DataPagamento.Value;
                dtpDataPagamento.Checked = true;
            }
            else
            {
                dtpDataPagamento.Value = DateTime.Today;
                dtpDataPagamento.Checked = false;
            }

            txtValorPago.Text = oContaPagar.ValorPago.HasValue ? oContaPagar.ValorPago.Value.ToString("F2") : "0,00";
            ckbStatus.Checked = oContaPagar.Ativo;

            txtDtCriacao.Text = oContaPagar.DtCriacao.ToString();
            txtDtAlt.Text = oContaPagar.DtAlt.ToString();

            bool cancelado = !oContaPagar.Ativo;
            lblMotivoCancelamento.Visible = cancelado;
            txtMotivoCancelamento.Visible = cancelado;
            txtMotivoCancelamento.Text = oContaPagar.MotivoCancelamento ?? "";

            decimal valorParcela = oContaPagar.ValorParcela;
            decimal multa = oContaPagar.Multa;
            decimal juros = oContaPagar.Juros;
            decimal desconto = oContaPagar.Desconto;

            txtMultaValor.Text = (valorParcela * (multa / 100)).ToString("F2");
            txtJuroValor.Text = (valorParcela * (juros / 100)).ToString("F2");
            txtDesctValor.Text = (valorParcela * (desconto / 100)).ToString("F2");
        }

        private void PopulaObjetoDoForm()
        {
            // IDs de Nota e Fornecedor são definidos em CarregarTxt ou nas pesquisas
            oContaPagar.NumeroParcela = int.Parse(txtNumParcela.Text);
            oContaPagar.DataEmissao = dtpDataEmissao.Value;
            oContaPagar.DataVencimento = dtpDataVencimento.Value;
            oContaPagar.ValorParcela = Convert.ToDecimal(txtValorParcela.Text);

            oContaPagar.Juros = Convert.ToDecimal(txtJuros.Text);
            oContaPagar.Multa = Convert.ToDecimal(txtMulta.Text);
            oContaPagar.Desconto = Convert.ToDecimal(txtDesconto.Text);

            oContaPagar.Ativo = ckbStatus.Checked;

            if (btnSave.Text == "Confirmar Pagamento")
            {
                oContaPagar.Situacao = 1; // 1 = Pago
                oContaPagar.ValorPago = Convert.ToDecimal(txtValorPago.Text);
                oContaPagar.DataPagamento = dtpDataPagamento.Checked ? dtpDataPagamento.Value : (DateTime?)null;
            }
            else if (btnSave.Text == "Salvar")
            {
                oContaPagar.Situacao = 0; 
                oContaPagar.ValorPago = null;
                oContaPagar.DataPagamento = null;
            }
        }

        public bool ValidacaoCampos()
        {

            if (btnSave.Text == "Salvar")
            {
                if (string.IsNullOrWhiteSpace(txtCodForn.Text) ||
                    string.IsNullOrWhiteSpace(txtNumParcela.Text) ||
                    string.IsNullOrWhiteSpace(txtCodFormaPagamento.Text) ||
                    !decimal.TryParse(txtValorParcela.Text, out decimal vlr) || vlr <= 0)
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios (*). O Valor da Parcela deve ser maior que zero.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (btnSave.Text == "Confirmar Pagamento")
            {
                if (!dtpDataPagamento.Checked)
                {
                    MessageBox.Show("Selecione uma data de pagamento.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txtCodFormaPagamento.Text))
                {
                    MessageBox.Show("Selecione a forma de pagamento.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!decimal.TryParse(txtValorPago.Text, out decimal valorPago) || valorPago <= 0)
                {
                    MessageBox.Show("O Valor Final (Pago) deve ser maior que zero.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtValorPago.Focus();
                    return false;
                }
            }

            return true;
        }

        public override void BloqueiaTxt()
        {
            // Modo "Visualizar" ou "Cancelar"
            base.BloqueiaTxt();

            txtCodigo.Enabled = false;
            txtSerie.Enabled = false;
            txtNumDaNota.Enabled = false;
            txtCodForn.Enabled = false;
            txtFornecedor.Enabled = false;
            btnPesquisarProd.Enabled = false; // Botão Fornecedor
            txtNumParcela.Enabled = false;
            dtpDataEmissao.Enabled = false;
            dtpDataVencimento.Enabled = false;
            txtValorParcela.Enabled = false;
            txtCodFormaPagamento.Enabled = false;
            txtFormaPagamento.Enabled = false;
            btnPesquisarFormPag.Enabled = false; // Botão Forma Pagamento
            txtJuros.Enabled = false;
            txtMulta.Enabled = false;
            txtDesconto.Enabled = false;
            txtValorPago.Enabled = false;
            dtpDataPagamento.Enabled = false;

            bool pago = oContaPagar.Situacao == 1;
            dtpDataPagamento.Visible = pago;
            txtValorPago.Visible = pago;
            lblDataPagamento.Visible = pago;
            lblValorFinal.Visible = pago;

            if (btnSave.Text == "Visualizar")
            {
                btnSave.Visible = false;
            }
            else // "Confirmar Cancelamento"
            {
                btnSave.Visible = true;
            }
        }

        public override void DesbloqueiaTxt()
        {
            // Modo "Inclusão" (Salvar)
            base.DesbloqueiaTxt();

            txtCodigo.Enabled = false; // ID da Conta
            txtSerie.Enabled = false; // Vem da nota
            txtNumDaNota.Enabled = false; // Vem da nota

            txtCodForn.Enabled = true;
            btnPesquisarProd.Enabled = true; // Botão Fornecedor
            txtNumParcela.Enabled = true;
            dtpDataEmissao.Enabled = true;
            dtpDataVencimento.Enabled = true;
            txtValorParcela.Enabled = true;
            txtCodFormaPagamento.Enabled = true;
            btnPesquisarFormPag.Enabled = true; // Botão Forma Pagamento
            txtJuros.Enabled = true;
            txtMulta.Enabled = true;
            txtDesconto.Enabled = true;

            btnSave.Visible = true;
            ckbStatus.Enabled = false;

            // Esconde campos de pagamento/cancelamento
            dtpDataPagamento.Visible = false;
            txtValorPago.Visible = false;
            lblDataPagamento.Visible = false;
            lblValorFinal.Visible = false;
            lblMotivoCancelamento.Visible = false;
            txtMotivoCancelamento.Visible = false;
        }

        public void ModoBaixa()
        {
            base.DesbloqueiaTxt();

            txtCodigo.Enabled = false;
            txtSerie.Enabled = false;
            txtNumDaNota.Enabled = false;
            btnPesquisarProd.Enabled = false; 
            txtNumParcela.Enabled = false;
            dtpDataEmissao.Enabled = false;
            dtpDataVencimento.Enabled = false;
            txtValorParcela.Enabled = false;
            ckbStatus.Enabled = false;
            txtCodForn.Enabled = false;

            btnSave.Visible = true;

            txtCodFormaPagamento.Enabled = true;
            btnPesquisarFormPag.Enabled = true; 
            txtJuros.Enabled = true;
            txtMulta.Enabled = true;
            txtDesconto.Enabled = true;
            dtpDataPagamento.Enabled = true;

            dtpDataPagamento.Visible = true;
            txtValorPago.Visible = true;
            lblDataPagamento.Visible = true;
            lblValorFinal.Visible = true;

            dtpDataPagamento.MinDate = dtpDataEmissao.Value.Date;
            dtpDataPagamento.MaxDate = DateTime.Today;
            dtpDataPagamento.Checked = true;

            RecalcularValorPago(null, null);
        }

        public override void Salvar()
        {
            if (!ValidacaoCampos())
                return;

            PopulaObjetoDoForm(); // Preenche o objeto com dados da tela

            try
            {
                string resultado = "";
                if (btnSave.Text == "Confirmar Cancelamento")
                {
                    if (MessageBox.Show("Tem certeza que deseja cancelar esta Conta a Pagar?",
                                        "Confirmar Cancelamento",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string motivo = Interaction.InputBox("Por favor, informe o motivo do cancelamento:", "Motivo do Cancelamento");

                        if (string.IsNullOrWhiteSpace(motivo))
                        {
                            MessageBox.Show("O motivo é obrigatório para cancelar a conta.", "Operação Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        oContaPagar.Ativo = false;
                        oContaPagar.MotivoCancelamento = motivo;

                        resultado = aCtrlContasPagar.Salvar(oContaPagar); 

                        if (int.TryParse(resultado, out _))
                            MessageBox.Show("Conta a Pagar cancelada com sucesso.");
                        else
                            throw new Exception(resultado);
                    }
                    else
                    {
                        return; // Usuário desistiu
                    }
                }
                else if (btnSave.Text == "Confirmar Pagamento")
                {
                    if (ConfirmarBaixa())
                    {
                        resultado = aCtrlContasPagar.Salvar(oContaPagar); // Chama o UPDATE do DAO
                        if (int.TryParse(resultado, out _))
                            MessageBox.Show("Conta a Pagar baixada com sucesso.");
                        else
                            throw new Exception(resultado);
                    }
                    else
                    {
                        return; // Usuário não confirmou a baixa
                    }
                }
                else // "Salvar" (Conta Avulsa)
                {
                    resultado = aCtrlContasPagar.Salvar(oContaPagar); // Chama o INSERT do DAO
                    if (int.TryParse(resultado, out int idSalvo))
                    {
                        oContaPagar.Id = idSalvo;
                        txtCodigo.Text = idSalvo.ToString();
                        MessageBox.Show("Conta a Pagar salva com sucesso.");
                    }
                    else
                    {
                        throw new Exception(resultado);
                    }
                }

                base.Salvar(); // Fecha o formulário
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Violação de Unique Key
                {
                    MessageBox.Show(
                        "Não foi possível salvar.\n\nJá existe uma parcela com esta Nota de Entrada e Número de Parcela.",
                        "Erro: Item duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else if (ex.Number == 547) // Violação de Foreign Key
                {
                    MessageBox.Show(
                       "Não foi possível salvar.\n\nO Fornecedor ou a Forma de Pagamento especificada não existe.",
                       "Erro: Referência inválida",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                   );
                }
                else
                {
                    MessageBox.Show("Erro ao salvar no banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Close();
        }


        private void btnPesquisarFornecedor_Click(object sender, EventArgs e)
        {
            oFrmConsultaFornecedor.ConhecaObj(oFornecedor, aCtrlFornecedor);
            oFrmConsultaFornecedor.ShowDialog();

            if (oFornecedor.Id != 0)
            {
                oContaPagar.OFornecedor = oFornecedor;
                txtCodForn.Text = oFornecedor.Id.ToString();
                txtFornecedor.Text = oFornecedor.NomeRazaoSocial;
            }
        }

        private void btnPesquisarFormaPagamento_Click(object sender, EventArgs e)
        {
            oFrmConsultaFormaPagamento.ConhecaObj(aFormPag, aCtrlFormaPagamento);
            oFrmConsultaFormaPagamento.ShowDialog();

            if (aFormPag.Id != 0)
            {
                oContaPagar.AFormaPagamento = aFormPag;
                txtCodFormaPagamento.Text = aFormPag.Id.ToString();
                txtFormaPagamento.Text = aFormPag.Descricao;
            }
        }

        private void RecalcularValorPago(object sender, EventArgs e)
        {
            decimal.TryParse(txtValorParcela.Text, out decimal valorParcela);
            decimal.TryParse(txtJuros.Text, out decimal juros);
            decimal.TryParse(txtMulta.Text, out decimal multa);
            decimal.TryParse(txtDesconto.Text, out decimal desconto);

            decimal valorJuros = valorParcela * (juros / 100);
            decimal valorMulta = valorParcela * (multa / 100);
            decimal valorDesconto = valorParcela * (desconto / 100);

            txtJuroValor.Text = valorJuros.ToString("F2");
            txtMultaValor.Text = valorMulta.ToString("F2");
            txtDesctValor.Text = valorDesconto.ToString("F2");

            decimal total = 0; 

            if (dtpDataPagamento.Checked)
            {
                total = valorParcela;

                if (dtpDataPagamento.Value.Date > dtpDataVencimento.Value.Date)
                {
                    total += valorMulta;
                    total += valorJuros;
                }
                else
                {
                    total -= valorDesconto;
                    total += valorJuros; 
                }
            }
            txtValorPago.Text = total.ToString("F2");
        }

        private bool ConfirmarBaixa()
        {
            string dataPagto = dtpDataPagamento.Value.ToShortDateString();
            string valorFinal = txtValorPago.Text;

            string mensagem = $"Confirma a baixa desta conta?\n\n" +
                              $"Data do Pagamento: {dataPagto}\n" +
                              $"Valor Final: R$ {valorFinal}";

            DialogResult resp = MessageBox.Show(mensagem, "Confirmar Baixa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return resp == DialogResult.Yes;
        }


        private void dtpDataEmissao_ValueChanged(object sender, EventArgs e)
        {
            dtpDataVencimento.MinDate = dtpDataEmissao.Value.Date;
            if (dtpDataVencimento.Value < dtpDataVencimento.MinDate)
            {
                dtpDataVencimento.Value = dtpDataVencimento.MinDate;
            }
        }

        private void txtCodForn_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodForn.Text))
            {
                // Limpa se o usuário apagar o código
                oContaPagar.OFornecedor = new Fornecedor();
                txtFornecedor.Clear();
                return;
            }

            if (int.TryParse(txtCodForn.Text, out int id))
            {
                // Busca o fornecedor no controlador
                oFornecedor = aCtrlFornecedor.BuscarPorId(id);
                if (oFornecedor != null)
                {
                    oContaPagar.OFornecedor = oFornecedor;
                    txtCodForn.Text = oFornecedor.Id.ToString();
                    txtFornecedor.Text = oFornecedor.NomeRazaoSocial;
                }
                else
                {
                    MessageBox.Show("Fornecedor não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    oContaPagar.OFornecedor = new Fornecedor();
                    txtCodForn.Clear();
                    txtFornecedor.Clear();
                }
            }
        }
    }
}
