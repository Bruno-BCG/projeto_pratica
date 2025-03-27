using projeto_pratica;
using projeto_pratica.pages.consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.cadastro;

namespace projeto_pratica
{
    public partial class frmConsultaCidade : frmConsulta
    {
        frmCadastroCidade frmCadCidade;
        Cidade aCidade;
        CtrlCidade aCtrlCidade;
        public frmConsultaCidade()
        {
            InitializeComponent();
            frmCadCidade = new frmCadastroCidade();
        }

        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null )
            {
                frmCadCidade = (frmCadastroCidade)obj;
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aCidade = (Cidade)obj;
            aCtrlCidade = (CtrlCidade)ctrl;
            CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            frmCadCidade.ConhecaObj(aCidade, aCtrlCidade);
            frmCadCidade.LimparTxt();
            frmCadCidade.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            frmCadCidade.ConhecaObj(aCidade, aCtrlCidade);
            frmCadCidade.CarregarTxt();
            frmCadCidade.ShowDialog();
        }
        public override void Excluir()
        {
            base.Excluir();
            frmCadCidade.ConhecaObj(aCidade, aCtrlCidade);
            frmCadCidade.CarregarTxt();
            frmCadCidade.BloqueiaTxt();
            frmCadCidade.ShowDialog(this);
            frmCadCidade.DesbloqueiaTxt();
        }

        public override void CarregaLV()
        {
			this.listV.Items.Clear();
			ListViewItem item = new ListViewItem(Convert.ToString(aCidade.Id));
            item.SubItems.Add(aCidade.Nome);    
            item.SubItems.Add(aCidade.Ddd);
            item.SubItems.Add(Convert.ToString(aCidade.OEstado.Id));
            item.SubItems.Add(aCidade.OEstado.Nome);
            listV.Items.Add(item);
        }
    }
}
