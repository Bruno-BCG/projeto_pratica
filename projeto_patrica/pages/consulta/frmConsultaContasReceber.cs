
using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.consulta
{

    public partial class frmConsultaContasReceber : projeto_pratica.pages.consulta.frmConsulta
    {
        private frmCadastroContasReceber frmCadConta;
        private ContasReceber oConta;
        private CtrlContasReceber aCtrlContasReceber;

        public frmConsultaContasReceber()
        {
            InitializeComponent();
            frmCadConta = new frmCadastroContasReceber();
            oConta = new ContasReceber();
            aCtrlContasReceber = new CtrlContasReceber();
        }

        // --- Métodos Herdados (Padrão) ---
        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null)
            {
                frmCadConta = (frmCadastroContasReceber)obj;
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oConta = (ContasReceber)obj;
            aCtrlContasReceber = (CtrlContasReceber)ctrl;
            this.CarregaLV();
        }

        // IMPORTANTE: nesta tela não existe “incluir avulso”.
        // O botão Incluir do Designer está com texto “Dar Baixa”, então chamamos DarBaixa().
        public override void Incluir()
        {
            DarBaixa();
        }

        public override void Alterar()
        {
            base.Alterar();
            frmCadConta.ConhecaObj(oConta, aCtrlContasReceber);
            frmCadConta.BloqueiaTxt();     // só visualizar
            frmCadConta.CarregarTxt();
            frmCadConta.ShowDialog(this);
            this.CarregaLV();
        }

        // Não é permitido cancelar conta a receber por aqui
        public override void Excluir()
        {
            MessageBox.Show(
                "Cancelar Contas a Receber não é permitido por esta tela.\n" +
                "As parcelas são geradas/canceladas a partir da Nota de Saída.",
                "Ação não disponível",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        public void DarBaixa()
        {
            if (oConta == null || oConta.Id == 0)
            {
                MessageBox.Show("Selecione uma conta em aberto para dar baixa.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!oConta.Ativo || oConta.Situacao == 1)
            {
                MessageBox.Show("Apenas contas ativas e em aberto podem receber baixa.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string aux = frmCadConta.btnSave.Text;
            frmCadConta.btnSave.Text = "Confirmar Recebimento";

            frmCadConta.ConhecaObj(oConta, aCtrlContasReceber);
            frmCadConta.CarregarTxt();
            frmCadConta.ModoBaixa();
            frmCadConta.ShowDialog(this);

            frmCadConta.DesbloqueiaTxt();
            frmCadConta.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            this.listV.Items.Clear();

            var lista = aCtrlContasReceber.Listar();

            foreach (var conta in lista)
            {
                // primeira coluna (oculta no base) recebe o Id
                ListViewItem item = new ListViewItem(conta.Id.ToString());

                // Colunas do Designer (modelo/serie/numero/cliente...)
                item.SubItems.Add(conta.ANotaSaida?.Modelo ?? "");                            // clmModelo
                item.SubItems.Add(conta.ANotaSaida?.Serie ?? "");                              // clmSerie
                item.SubItems.Add(conta.ANotaSaida?.Numero ?? "");                             // clmNumNota
                item.SubItems.Add(conta.OCliente?.Id.ToString() ?? "");                        // clmIdCliente
                item.SubItems.Add(conta.OCliente?.NomeRazaoSocial ?? "");                      // clmCliente
                item.SubItems.Add(conta.NumeroParcela.ToString());                             // clmNumParc
                item.SubItems.Add(conta.ValorParcela.ToString("C2"));                          // clmValorParcela
                item.SubItems.Add(conta.AFormaPagamento?.Descricao ?? "");                     // clmFormaPagamento
                item.SubItems.Add(conta.DataEmissao.ToShortDateString());                      // clmDataEmissao
                item.SubItems.Add(conta.DataVencimento.ToShortDateString());                   // clmDataVencimento

                string status;
                if (!conta.Ativo) status = "Cancelado";
                else status = (conta.Situacao == 0) ? "Em Aberto" : "Recebido";
                item.SubItems.Add(status);                                                     // clmAtivo

                item.SubItems.Add(conta.MotivoCancelamento ?? "");                             // clmMotCancel

                item.Tag = conta;
                listV.Items.Add(item);
            }
        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                var selecionado = (ContasReceber)listV.SelectedItems[0].Tag;

                // copia campos para o objeto atual
                oConta.Id = selecionado.Id;
                oConta.ANotaSaida = selecionado.ANotaSaida;
                oConta.OCliente = selecionado.OCliente;
                oConta.AFormaPagamento = selecionado.AFormaPagamento;
                oConta.NumeroParcela = selecionado.NumeroParcela;
                oConta.DataEmissao = selecionado.DataEmissao;
                oConta.DataVencimento = selecionado.DataVencimento;
                oConta.ValorParcela = selecionado.ValorParcela;
                oConta.Situacao = selecionado.Situacao; // 0=Em Aberto, 1=Recebido
                oConta.Juros = selecionado.Juros;
                oConta.Multa = selecionado.Multa;
                oConta.Desconto = selecionado.Desconto;
                oConta.ValorPago = selecionado.ValorPago;
                oConta.DataPagamento = selecionado.DataPagamento;
                oConta.MotivoCancelamento = selecionado.MotivoCancelamento;
                oConta.Ativo = selecionado.Ativo;

                // Habilitações: Visualizar sempre; Dar Baixa apenas se Ativo e Em Aberto; Excluir (cancelar) nunca.
                btnAlterar.Enabled = true;                                 // Visualizar
                btnIncluir.Enabled = selecionado.Ativo && selecionado.Situacao == 0; // Dar Baixa
                btnExcluir.Enabled = false;                                // Cancelar desabilitado
            }
            else
            {
                btnAlterar.Enabled = false;
                btnIncluir.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

        private void btnBaixa_Click(object sender, EventArgs e)
        {
            DarBaixa();
        }
    }
}


