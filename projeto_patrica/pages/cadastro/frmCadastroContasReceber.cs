using Microsoft.VisualBasic;
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
    public partial class frmCadastroContasReceber : projeto_pratica.pages.cadastro.frmCadastro
    {
        private ContasReceber oContaReceber;
        private Cliente oCliente;
        private FormaPagamento aFormPag;

        private frmConsultaCliente oFrmConsultaCliente;
        private frmConsultaFormPag oFrmConsultaFormaPagamento;

        private CtrlContasReceber aCtrlContasReceber;
        private CtrlCliente aCtrlCliente;
        private CtrlFormPag aCtrlFormaPagamento;

        private bool _carregando;

        public frmCadastroContasReceber()
        {
            InitializeComponent();

            oContaReceber = new ContasReceber();
            oCliente = new Cliente();
            aFormPag = new FormaPagamento();

            aCtrlContasReceber = new CtrlContasReceber();
            aCtrlCliente = new CtrlCliente();
            aCtrlFormaPagamento = new CtrlFormPag();

            // Forms de consulta
            oFrmConsultaCliente = new frmConsultaCliente();
            oFrmConsultaFormaPagamento = new frmConsultaFormPag();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oContaReceber = (ContasReceber)obj;
            aCtrlContasReceber = (CtrlContasReceber)ctrl;
        }

        public void setFrmConsultaCliente(object obj)
        {
            oFrmConsultaCliente = (frmConsultaCliente)obj;
        }
        public void setFrmConsultaFormPag(object obj)
        {
            oFrmConsultaFormaPagamento = (frmConsultaFormPag)obj;
        }

        public override void LimparTxt()
        {
            _carregando = true;
            try
            {
                base.LimparTxt();
                txtCodigo.Clear();                 // ID (gerado pelo BD)
                txtSerie.Clear();
                txtNumDaNota.Clear();
                txtCodCliente.Clear();
                txtCliente.Clear();

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

                txtMultaValor.Text = "0,00";
                txtJuroValor.Text = "0,00";
                txtDesctValor.Text = "0,00";

                oContaReceber = new ContasReceber();
            }
            finally { _carregando = false; }
        }

        public override void CarregarTxt()
        {
            _carregando = true;
            try
            {
                base.CarregarTxt();

                // Cabeçalho vindo da NOTA DE SAÍDA
                if (oContaReceber.ANotaSaida != null)
                {
                    txtCodigo.Text = oContaReceber.ANotaSaida.Modelo?.ToString(); // apenas display
                    txtSerie.Text = oContaReceber.ANotaSaida.Serie;
                    txtNumDaNota.Text = oContaReceber.ANotaSaida.Numero;

                    if (oContaReceber.OCliente != null)
                    {
                        txtCodCliente.Text = oContaReceber.OCliente.Id.ToString();
                        txtCliente.Text = oContaReceber.OCliente.NomeRazaoSocial;
                    }
                }

                // Forma de pagamento
                if (oContaReceber.AFormaPagamento != null)
                {
                    txtCodFormaPagamento.Text = oContaReceber.AFormaPagamento.Id.ToString();
                    txtFormaPagamento.Text = oContaReceber.AFormaPagamento.Descricao;
                }

                // Dados da parcela
                txtNumParcela.Text = oContaReceber.NumeroParcela.ToString();
                dtpDataEmissao.Value = oContaReceber.DataEmissao;
                dtpDataVencimento.MinDate = dtpDataEmissao.Value.Date;
                dtpDataVencimento.Value = oContaReceber.DataVencimento;
                txtValorParcela.Text = oContaReceber.ValorParcela.ToString("F2");

                txtJuros.Text = oContaReceber.Juros.ToString("F2");
                txtMulta.Text = oContaReceber.Multa.ToString("F2");
                txtDesconto.Text = oContaReceber.Desconto.ToString("F2");

                if (oContaReceber.DataPagamento.HasValue)
                {
                    dtpDataPagamento.Value = oContaReceber.DataPagamento.Value;
                    dtpDataPagamento.Checked = true;
                }
                else
                {
                    dtpDataPagamento.Value = DateTime.Today;
                    dtpDataPagamento.Checked = false;
                }

                txtValorPago.Text = oContaReceber.ValorPago.HasValue ? oContaReceber.ValorPago.Value.ToString("F2") : "0,00";
                ckbStatus.Checked = oContaReceber.Ativo;

                txtDtCriacao.Text = oContaReceber.DtCriacao.ToString();
                txtDtAlt.Text = oContaReceber.DtAlt.ToString();

                bool cancelado = !oContaReceber.Ativo;
                lblMotivoCancelamento.Visible = cancelado;
                lblMotivoCancelamento.Text = "MOTIVO DE CANCELAMENTO";
                txtMotivoCancelamento.Visible = cancelado;
                txtMotivoCancelamento.Text = oContaReceber.MotivoCancelamento ?? "";

                decimal valorParcela = oContaReceber.ValorParcela;
                decimal multa = oContaReceber.Multa;
                decimal juros = oContaReceber.Juros;
                decimal desconto = oContaReceber.Desconto;

                txtMultaValor.Text = (valorParcela * (multa / 100m)).ToString("F2");
                txtJuroValor.Text = (valorParcela * (juros / 100m)).ToString("F2");
                txtDesctValor.Text = (valorParcela * (desconto / 100m)).ToString("F2");
            }
            finally { _carregando = false; }
        }

        private void PopulaObjetoDoForm()
        {
            // IDs de Nota e Cliente são definidos em CarregarTxt ou pelas pesquisas
            oContaReceber.NumeroParcela = int.Parse(txtNumParcela.Text);
            oContaReceber.DataEmissao = dtpDataEmissao.Value;
            oContaReceber.DataVencimento = dtpDataVencimento.Value;
            oContaReceber.ValorParcela = Convert.ToDecimal(txtValorParcela.Text);

            oContaReceber.Juros = Convert.ToDecimal(txtJuros.Text);
            oContaReceber.Multa = Convert.ToDecimal(txtMulta.Text);
            oContaReceber.Desconto = Convert.ToDecimal(txtDesconto.Text);

            oContaReceber.Ativo = ckbStatus.Checked;

            if (btnSave.Text == "Confirmar Recebimento")
            {
                oContaReceber.Situacao = 1; // 1 = Recebido
                oContaReceber.ValorPago = Convert.ToDecimal(txtValorPago.Text);
                oContaReceber.DataPagamento = dtpDataPagamento.Checked ? dtpDataPagamento.Value : (DateTime?)null;
            }
            else if (btnSave.Text == "Salvar")
            {
                oContaReceber.Situacao = 0; // Em aberto
                oContaReceber.ValorPago = null;
                oContaReceber.DataPagamento = null;
            }
        }

        public bool ValidacaoCampos()
        {
            if (btnSave.Text == "Confirmar Recebimento")
            {
                if (!dtpDataPagamento.Checked)
                {
                    MessageBox.Show("Selecione a data de recebimento.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(txtCodFormaPagamento.Text))
                {
                    MessageBox.Show("Selecione a forma de pagamento.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (!decimal.TryParse(txtValorPago.Text, out var valorPago) || valorPago <= 0)
                {
                    MessageBox.Show("O valor recebido deve ser maior que zero.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }

            if (btnSave.Text == "Confirmar Cancelamento")
                return true;

            MessageBox.Show(
                "Não é permitido criar Contas a Receber avulsa. As parcelas devem ser geradas pela Nota de Saída.",
                "Operação não permitida",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
            return false;
        }


        public override void BloqueiaTxt()
        {
            base.BloqueiaTxt();

            txtCodigo.Enabled = false;
            txtSerie.Enabled = false;
            txtNumDaNota.Enabled = false;
            txtCodCliente.Enabled = false;
            txtCliente.Enabled = false;
            btnPesquisarCliente.Enabled = false;

            txtNumParcela.Enabled = false;
            dtpDataEmissao.Enabled = false;
            dtpDataVencimento.Enabled = false;
            txtValorParcela.Enabled = false;

            txtCodFormaPagamento.Enabled = false;
            txtFormaPagamento.Enabled = false;
            btnPesquisarFormPag.Enabled = false;

            txtJuros.Enabled = false;
            txtMulta.Enabled = false;
            txtDesconto.Enabled = false;
            txtValorPago.Enabled = false;
            dtpDataPagamento.Enabled = false;

            bool recebido = oContaReceber.Situacao == 1;
            dtpDataPagamento.Visible = recebido;
            txtValorPago.Visible = recebido;
            lblDataPagamento.Visible = recebido;
            lblValorFinal.Visible = recebido;

            if (btnSave.Text == "Visualizar")
                btnSave.Visible = false;
            else
                btnSave.Visible = true;
        }

        public override void DesbloqueiaTxt()
        {
            base.DesbloqueiaTxt();

            txtCodigo.Enabled = false;
            txtSerie.Enabled = false;
            txtNumDaNota.Enabled = false;
            txtCodCliente.Enabled = false;
            btnPesquisarCliente.Enabled = false;

            txtNumParcela.Enabled = false;
            dtpDataEmissao.Enabled = false;
            dtpDataVencimento.Enabled = false;
            txtValorParcela.Enabled = false;

            txtCodFormaPagamento.Enabled = false;
            btnPesquisarFormPag.Enabled = false;
            txtJuros.Enabled = false;
            txtMulta.Enabled = false;
            txtDesconto.Enabled = false;

            dtpDataPagamento.Visible = false;
            txtValorPago.Visible = false;
            lblDataPagamento.Visible = false;
            lblValorFinal.Visible = false;
        }


        public void ModoBaixa()
        {
            base.DesbloqueiaTxt();

            txtCodigo.Enabled = false;
            txtSerie.Enabled = false;
            txtNumDaNota.Enabled = false;
            btnPesquisarCliente.Enabled = false;

            txtNumParcela.Enabled = false;
            dtpDataEmissao.Enabled = false;
            dtpDataVencimento.Enabled = false;
            txtValorParcela.Enabled = false;
            ckbStatus.Enabled = false;
            txtCodCliente.Enabled = false;

            btnSave.Visible = true;
            btnSave.Text = "Confirmar Recebimento";

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

            PopulaObjetoDoForm();

            try
            {
                string resultado = "";

                if (btnSave.Text == "Confirmar Cancelamento")
                {
                    if (MessageBox.Show("Tem certeza que deseja cancelar esta Conta a Receber?",
                                        "Confirmar Cancelamento",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;

                    string motivo = Interaction.InputBox("Informe o motivo do cancelamento:", "Motivo do Cancelamento");
                    if (string.IsNullOrWhiteSpace(motivo))
                    {
                        MessageBox.Show("O motivo é obrigatório para cancelar.", "Operação cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    oContaReceber.Ativo = false;
                    oContaReceber.MotivoCancelamento = motivo;

                    resultado = aCtrlContasReceber.Salvar(oContaReceber);
                    if (int.TryParse(resultado, out _))
                        MessageBox.Show("Conta a Receber cancelada com sucesso.");
                    else
                        throw new Exception(resultado);
                }
                else if (btnSave.Text == "Confirmar Recebimento")
                {
                    if (!ConfirmarBaixa()) return;

                    resultado = aCtrlContasReceber.Salvar(oContaReceber);
                    if (int.TryParse(resultado, out _))
                        MessageBox.Show("Conta a Receber baixada com sucesso.");
                    else
                        throw new Exception(resultado);
                }
                else
                {
                    
                    MessageBox.Show(
                        "Não é permitido criar Contas a Receber avulsa. Gere as parcelas pela Nota de Saída.",
                        "Operação não permitida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                base.Salvar(); 
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) 
                {
                    MessageBox.Show(
                        "Já existe uma parcela com esta Nota de Saída e Número de Parcela.",
                        "Erro: Item duplicado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else if (ex.Number == 547) 
                {
                    MessageBox.Show(
                        "Cliente ou Forma de Pagamento inválidos.",
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
        }


        private void btnPesquisarFornecedor_Click(object sender, EventArgs e)
        {
            oFrmConsultaCliente.ConhecaObj(oCliente, aCtrlCliente);
            oFrmConsultaCliente.ShowDialog();

            if (oCliente.Id != 0)
            {
                oContaReceber.OCliente = oCliente;
                txtCodCliente.Text = oCliente.Id.ToString();
                txtCliente.Text = oCliente.NomeRazaoSocial;
            }
        }

        private void btnPesquisarFormaPagamento_Click(object sender, EventArgs e)
        {
            oFrmConsultaFormaPagamento.ConhecaObj(aFormPag, aCtrlFormaPagamento);
            oFrmConsultaFormaPagamento.ShowDialog();

            if (aFormPag.Id != 0)
            {
                oContaReceber.AFormaPagamento = aFormPag;
                txtCodFormaPagamento.Text = aFormPag.Id.ToString();
                txtFormaPagamento.Text = aFormPag.Descricao;
            }
        }

        private void txtCodCliente_Leave(object sender, EventArgs e)
        {
            if (_carregando) return;

            if (string.IsNullOrWhiteSpace(txtCodCliente.Text))
            {
                oContaReceber.OCliente = new Cliente();
                txtCliente.Clear();
                return;
            }

            if (int.TryParse(txtCodCliente.Text, out int id) && id > 0)
            {
                oCliente = aCtrlCliente.BuscarPorId(id);
                if (oCliente != null)
                {
                    oContaReceber.OCliente = oCliente;
                    txtCodCliente.Text = oCliente.Id.ToString();
                    txtCliente.Text = oCliente.NomeRazaoSocial;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    oContaReceber.OCliente = new Cliente();
                    txtCodCliente.Clear();
                    txtCliente.Clear();
                }
            }
        }

        private void txtCodFormaPagamento_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodFormaPagamento.Text))
            {
                aFormPag = new FormaPagamento();
                oContaReceber.AFormaPagamento = new FormaPagamento();
                txtFormaPagamento.Clear();
                return;
            }

            if (!int.TryParse(txtCodFormaPagamento.Text, out int id) || id <= 0)
            {
                aFormPag = new FormaPagamento();
                oContaReceber.AFormaPagamento = new FormaPagamento();
                txtCodFormaPagamento.Clear();
                txtFormaPagamento.Clear();
                return;
            }

            // Busca no controller
            var fp = aCtrlFormaPagamento.BuscarPorId(id);
            if (fp != null)
            {
                aFormPag = fp;
                oContaReceber.AFormaPagamento = fp;
                txtCodFormaPagamento.Text = fp.Id.ToString();
                txtFormaPagamento.Text = fp.Descricao;
            }
            else
            {
                MessageBox.Show("Forma de pagamento não encontrada.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                aFormPag = new FormaPagamento();
                oContaReceber.AFormaPagamento = new FormaPagamento();
                txtCodFormaPagamento.Clear();
                txtFormaPagamento.Clear();
            }
        }

        private void RecalcularValorPago(object sender, EventArgs e)
        {
            // Base
            decimal.TryParse(txtValorParcela.Text, out decimal valorParcela);
            decimal.TryParse(txtJuros.Text, out decimal jurosPerc);       
            decimal.TryParse(txtMulta.Text, out decimal multaPerc);       
            decimal.TryParse(txtDesconto.Text, out decimal descontoPerc); 

            if (!dtpDataPagamento.Checked)
            {
                txtJuroValor.Text = "0,00";
                txtMultaValor.Text = "0,00";
                txtDesctValor.Text = "0,00";
                txtValorPago.Text = "0,00";
                return;
            }

            DateTime venc = dtpDataVencimento.Value.Date;
            DateTime pag = dtpDataPagamento.Value.Date;

            int diasAtraso = (pag - venc).Days;      
            int diasAdiantado = (venc - pag).Days;   

            decimal valorMulta = 0m;
            decimal valorJuros = 0m;
            decimal valorDesc = 0m;

            if (diasAtraso > 0)
            {
                valorMulta = valorParcela * (multaPerc / 100m);
                valorJuros = valorParcela * (jurosPerc / 100m) * diasAtraso;
                valorDesc = 0m;
            }
            else if (diasAdiantado > 0)
            {
                valorMulta = 0m;
                valorJuros = 0m;
                valorDesc = valorParcela * (descontoPerc / 100m) * diasAdiantado;
            }
            else
            {
                valorMulta = 0m;
                valorJuros = 0m;
                valorDesc = 0m;
            }

            txtMultaValor.Text = Math.Round(valorMulta, 2).ToString("F2");
            txtJuroValor.Text = Math.Round(valorJuros, 2).ToString("F2");
            txtDesctValor.Text = Math.Round(valorDesc, 2).ToString("F2");

            decimal total = valorParcela + valorMulta + valorJuros - valorDesc;
            if (total < 0) total = 0m;
            txtValorPago.Text = Math.Round(total, 2).ToString("F2");
        }

        private bool ConfirmarBaixa()
        {
            string dataPagto = dtpDataPagamento.Value.ToShortDateString();
            string valorFinal = txtValorPago.Text;

            string mensagem = $"Confirma o recebimento desta conta?\n\n" +
                              $"Data do Recebimento: {dataPagto}\n" +
                              $"Valor Recebido: R$ {valorFinal}";

            DialogResult resp = MessageBox.Show(mensagem, "Confirmar Recebimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNumero_KeyPress(sender, e);
        }
    }
}
