﻿using projeto_pratica.classes;
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
    public partial class frmConsultaNotasEntrada : projeto_pratica.pages.consulta.frmConsulta
    {
        private frmCadastroNotaEntrada aFrmCadastroNotaEntrada;
        private NotaEntrada aNotaEntrada;
        private CtrlNotaEntrada aCtrlNotaEntrada;


        public frmConsultaNotasEntrada()
        {
            InitializeComponent();
            aCtrlNotaEntrada = new CtrlNotaEntrada();
            aNotaEntrada = new NotaEntrada();
            aFrmCadastroNotaEntrada = new frmCadastroNotaEntrada();
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;

        }
        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null)
            {
                aFrmCadastroNotaEntrada = (frmCadastroNotaEntrada)obj;
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aNotaEntrada = (NotaEntrada)obj;
            aCtrlNotaEntrada = (CtrlNotaEntrada)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            aFrmCadastroNotaEntrada.DesbloqueiaTxt();
            aFrmCadastroNotaEntrada.ConhecaObj(new NotaEntrada(), aCtrlNotaEntrada);
            aFrmCadastroNotaEntrada.LimparTxt();
            aFrmCadastroNotaEntrada.ShowDialog();
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            aFrmCadastroNotaEntrada.ConhecaObj(aNotaEntrada, aCtrlNotaEntrada);
            aFrmCadastroNotaEntrada.BloqueiaTxt();
            aFrmCadastroNotaEntrada.btnSave.Enabled = false;
            aFrmCadastroNotaEntrada.btnSave.Visible = false;
            aFrmCadastroNotaEntrada.ShowDialog();
            aFrmCadastroNotaEntrada.DesbloqueiaTxt();
            aFrmCadastroNotaEntrada.btnSave.Enabled = true;
            aFrmCadastroNotaEntrada.btnSave.Visible = true;
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = aFrmCadastroNotaEntrada.btnSave.Text;
            aFrmCadastroNotaEntrada.btnSave.Text = "Excluir";
            aFrmCadastroNotaEntrada.ConhecaObj(aNotaEntrada, aCtrlNotaEntrada);
            aFrmCadastroNotaEntrada.BloqueiaTxt();
            aFrmCadastroNotaEntrada.ShowDialog(this);
            aFrmCadastroNotaEntrada.DesbloqueiaTxt();
            aFrmCadastroNotaEntrada.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            this.listV.Items.Clear();
            var lista = aCtrlNotaEntrada.Listar(); // Utiliza o método Listar do controller

            foreach (var nota in lista)
            {
                // A primeira coluna (Código) é adicionada ao criar o ListViewItem
                ListViewItem item = new ListViewItem(Convert.ToString(nota.Id));

                // Adiciona as sub-colunas
                item.SubItems.Add(nota.Modelo);
                item.SubItems.Add(nota.Serie);
                item.SubItems.Add(nota.Numero);
                item.SubItems.Add(nota.OFornecedor?.Id.ToString() ?? "N/D");
                item.SubItems.Add(nota.OFornecedor?.NomeRazaoSocial ?? "N/D");
                item.SubItems.Add(nota.DataEmissao.ToShortDateString());
                item.SubItems.Add(nota.DataChegada.ToShortDateString());
                item.SubItems.Add(nota.ValorTotalNota.ToString());
                item.SubItems.Add(nota.MotivoCancelamento ?? "N/D");
                item.SubItems.Add(nota.Ativo ? "Não" : "Cancelado");

                item.Tag = nota; // Armazena o objeto completo na Tag para uso posterior
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                // Quando um item é selecionado, copiamos o objeto da Tag para a variável 'aNotaEntrada'
                // para que os métodos Alterar() e Excluir() saibam qual objeto usar.
                var selecionada = (NotaEntrada)listV.SelectedItems[0].Tag;

                // Propriedades da classe Pai
                aNotaEntrada.Id = selecionada.Id;
                aNotaEntrada.DtCriacao = selecionada.DtCriacao;
                aNotaEntrada.DtAlt = selecionada.DtAlt;
                aNotaEntrada.Ativo = selecionada.Ativo;

                // Propriedades da NotaEntrada
                aNotaEntrada.Modelo = selecionada.Modelo;
                aNotaEntrada.Serie = selecionada.Serie;
                aNotaEntrada.Numero = selecionada.Numero;
                aNotaEntrada.DataEmissao = selecionada.DataEmissao;
                aNotaEntrada.DataChegada = selecionada.DataChegada;

                // Valores
                aNotaEntrada.ValorFrete = selecionada.ValorFrete;
                aNotaEntrada.ValorSeguro = selecionada.ValorSeguro;
                aNotaEntrada.OutrasDespesas = selecionada.OutrasDespesas;

                // Objetos complexos (atribuição de referência)
                aNotaEntrada.OFornecedor = selecionada.OFornecedor;
                aNotaEntrada.ACondicaoPagamento = selecionada.ACondicaoPagamento;

                // Listas (atribuição de referência)
                aNotaEntrada.ItensDaNota = selecionada.ItensDaNota;

                aNotaEntrada.MotivoCancelamento = selecionada.MotivoCancelamento;

                if (selecionada.Ativo == false)
                {
                    btnExcluir.Enabled = false;
                    btnAlterar.Enabled = true;
                }
                else
                {
                    btnExcluir.Enabled = true;
                    btnAlterar.Enabled = true;
                }
            }
            else
            {
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
            }
        }

        private void frmConsultaNotasEntrada_Load(object sender, EventArgs e)
        {
            // Carrega a lista assim que o formulário é aberto
            CarregaLV();
        }

        private void frmConsultaNotasEntrada_Load_1(object sender, EventArgs e)
        {

        }
    }
}
