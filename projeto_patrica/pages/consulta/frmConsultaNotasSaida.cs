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
    public partial class frmConsultaNotasSaida : projeto_pratica.pages.consulta.frmConsulta
    {
        private frmCadastroNotaSaida aFrmCadastroNotaSaida;
        private NotaSaida aNotaSaida;
        private CtrlNotaSaida aCtrlNotaSaida;

        public frmConsultaNotasSaida()
        {
            InitializeComponent();
            aCtrlNotaSaida = new CtrlNotaSaida();
            aNotaSaida = new NotaSaida();
            aFrmCadastroNotaSaida = new frmCadastroNotaSaida();

            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null)
            {
                aFrmCadastroNotaSaida = (frmCadastroNotaSaida)obj; 
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aNotaSaida = (NotaSaida)obj;               
            aCtrlNotaSaida = (CtrlNotaSaida)ctrl;     
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            aFrmCadastroNotaSaida.DesbloqueiaTxt();
            aFrmCadastroNotaSaida.ConhecaObj(aNotaSaida, aCtrlNotaSaida);
            aFrmCadastroNotaSaida.LimparTxt();
            aFrmCadastroNotaSaida.ShowDialog();

            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            aFrmCadastroNotaSaida.ConhecaObj(aNotaSaida, aCtrlNotaSaida);
            aFrmCadastroNotaSaida.BloqueiaTxt();
            aFrmCadastroNotaSaida.btnSave.Enabled = false;
            aFrmCadastroNotaSaida.btnSave.Visible = false;
            aFrmCadastroNotaSaida.ShowDialog();
            aFrmCadastroNotaSaida.DesbloqueiaTxt();
            aFrmCadastroNotaSaida.btnSave.Enabled = true;
            aFrmCadastroNotaSaida.btnSave.Visible = true;
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();

            if (aCtrlNotaSaida.ExistemParcelasPagasPorNota(aNotaSaida.Id))
            {
                MessageBox.Show(
                    "Não é possível cancelar esta Nota de Saída.\nHá parcelas de Contas a Receber já baixadas (pagas).",
                    "Ação bloqueada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            string aux = aFrmCadastroNotaSaida.btnSave.Text;
            aFrmCadastroNotaSaida.btnSave.Text = "Excluir";
            aFrmCadastroNotaSaida.ConhecaObj(aNotaSaida, aCtrlNotaSaida);
            aFrmCadastroNotaSaida.BloqueiaTxt();
            aFrmCadastroNotaSaida.ShowDialog(this);
            aFrmCadastroNotaSaida.DesbloqueiaTxt();
            aFrmCadastroNotaSaida.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            this.listV.Items.Clear();

            var lista = aCtrlNotaSaida.Listar(); 

            foreach (var nota in lista)
            {
    
                ListViewItem item = new ListViewItem(Convert.ToString(nota.Id));

                item.SubItems.Add(nota.Modelo);
                item.SubItems.Add(nota.Serie);
                item.SubItems.Add(nota.Numero);
                item.SubItems.Add(nota.OCliente?.Id.ToString() ?? "N/D");
                item.SubItems.Add(nota.OCliente?.NomeRazaoSocial ?? "N/D");
                item.SubItems.Add(nota.DataEmissao.ToShortDateString());
                item.SubItems.Add(nota.SubTotalProdutos.ToString());     
                item.SubItems.Add(nota.MotivoCancelamento ?? "N/D");
                item.SubItems.Add(nota.Ativo ? "Não" : "Cancelado");

                item.Tag = nota; 
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                var selecionada = (NotaSaida)listV.SelectedItems[0].Tag;

                aNotaSaida.Id = selecionada.Id;
                aNotaSaida.DtCriacao = selecionada.DtCriacao;
                aNotaSaida.DtAlt = selecionada.DtAlt;
                aNotaSaida.Ativo = selecionada.Ativo;

                aNotaSaida.Modelo = selecionada.Modelo;
                aNotaSaida.Serie = selecionada.Serie;
                aNotaSaida.Numero = selecionada.Numero;
                aNotaSaida.DataEmissao = selecionada.DataEmissao;

                aNotaSaida.OCliente = selecionada.OCliente;
                aNotaSaida.OFuncionario = selecionada.OFuncionario;
                aNotaSaida.ACondicaoPagamento = selecionada.ACondicaoPagamento;
                aNotaSaida.ItensDaNota = selecionada.ItensDaNota;

                aNotaSaida.MotivoCancelamento = selecionada.MotivoCancelamento;

                bool temParcelaRecebida = aCtrlNotaSaida.ExistemParcelasPagasPorNota(selecionada.Id);

                // Só permite cancelar se está ativa e NÃO tem parcela recebida
                btnExcluir.Enabled = selecionada.Ativo && !temParcelaRecebida;
                btnAlterar.Enabled = true;
            }
            else
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
            }
        }
    }
}
