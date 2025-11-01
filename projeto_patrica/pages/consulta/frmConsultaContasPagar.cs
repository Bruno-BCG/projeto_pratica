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
    public partial class frmConsultaContasPagar : projeto_pratica.pages.consulta.frmConsulta
    {
        private frmCadastroContasPagar frmCadConta;
        private ContasPagar oConta;
        private CtrlContasPagar aCtrlContasPagar;

        public frmConsultaContasPagar()
        {
            InitializeComponent();
            frmCadConta = new frmCadastroContasPagar();
        }

        // --- Métodos Herdados (Padrão) ---

        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null)
            {
                frmCadConta = (frmCadastroContasPagar)obj;
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oConta = (ContasPagar)obj;
            aCtrlContasPagar = (CtrlContasPagar)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            oConta = new ContasPagar();

            frmCadConta.ConhecaObj(oConta, aCtrlContasPagar);
            frmCadConta.LimparTxt();
            frmCadConta.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            frmCadConta.ConhecaObj(oConta, aCtrlContasPagar);
            frmCadConta.BloqueiaTxt();
            frmCadConta.CarregarTxt();
            frmCadConta.ShowDialog();
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = frmCadConta.btnSave.Text;
            frmCadConta.btnSave.Text = "Confirmar Cancelamento"; 

            frmCadConta.ConhecaObj(oConta, aCtrlContasPagar);
            frmCadConta.CarregarTxt();
            frmCadConta.BloqueiaTxt(); 

            frmCadConta.ShowDialog(this);

            frmCadConta.DesbloqueiaTxt();
            frmCadConta.btnSave.Text = aux;
            this.CarregaLV();
        }

        public void DarBaixa()
        {
            if (oConta == null || oConta.Id == 0)
            {
                MessageBox.Show("Nenhuma conta selecionada para dar baixa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string aux = frmCadConta.btnSave.Text;
            frmCadConta.btnSave.Text = "Confirmar Pagamento";

            frmCadConta.ConhecaObj(oConta, aCtrlContasPagar);
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

            var lista = aCtrlContasPagar.Listar();

            foreach (var conta in lista)
            {
                ListViewItem item = new ListViewItem(conta.Id.ToString());

                item.SubItems.Add(conta.ANotaEntrada.Modelo.ToString()); 
                item.SubItems.Add(conta.ANotaEntrada.Serie.ToString()); 
                item.SubItems.Add(conta.ANotaEntrada.Numero.ToString()); 
                item.SubItems.Add(conta.OFornecedor.Id.ToString());
                item.SubItems.Add(conta.OFornecedor.NomeRazaoSocial); 
                item.SubItems.Add(conta.NumeroParcela.ToString());
                item.SubItems.Add(conta.ValorParcela.ToString("C2")); 
                item.SubItems.Add(conta.AFormaPagamento.Descricao); 
                item.SubItems.Add(conta.DataEmissao.ToShortDateString()); 
                item.SubItems.Add(conta.DataVencimento.ToShortDateString()); 


                string status;
                if (!conta.Ativo)
                {
                    status = "Cancelado";
                }
                else
                {
                    // Situação 0 = Em Aberto, 1 = Pago
                    status = conta.Situacao == 0 ? "Em Aberto" : "Pago";
                }
                item.SubItems.Add(status); // clmAtivo
                item.SubItems.Add(conta.MotivoCancelamento.ToString());

                item.Tag = conta;
                listV.Items.Add(item);
            }
        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                var selecionado = (ContasPagar)listV.SelectedItems[0].Tag;

                oConta.Id = selecionado.Id;
                oConta.ANotaEntrada = selecionado.ANotaEntrada;
                oConta.OFornecedor = selecionado.OFornecedor;
                oConta.AFormaPagamento = selecionado.AFormaPagamento;
                oConta.NumeroParcela = selecionado.NumeroParcela;
                oConta.DataEmissao = selecionado.DataEmissao;
                oConta.DataVencimento = selecionado.DataVencimento;
                oConta.ValorParcela = selecionado.ValorParcela;
                oConta.Situacao = selecionado.Situacao;
                oConta.Juros = selecionado.Juros;
                oConta.Multa = selecionado.Multa;
                oConta.Desconto = selecionado.Desconto;
                oConta.ValorPago = selecionado.ValorPago;
                oConta.DataPagamento = selecionado.DataPagamento;
                oConta.MotivoCancelamento = selecionado.MotivoCancelamento;
                oConta.Ativo = selecionado.Ativo;

                btnAlterar.Enabled = true;

                btnExcluir.Enabled = selecionado.Ativo;

                btnBaixa.Enabled = selecionado.Ativo && selecionado.Situacao == 0;
            }
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                btnBaixa.Enabled = false;
            }
        }
        private void btnBaixa_Click(object sender, EventArgs e)
        {
            DarBaixa();
        }
    }
}

