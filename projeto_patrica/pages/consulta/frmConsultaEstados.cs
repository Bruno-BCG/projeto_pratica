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
    public partial class frmConsultaEstados : frmConsulta
    {
        frmCadastroEstado frmCadEstado;
        Estado oEstado;
        CtrlEstado aCtrlEstado;
        public frmConsultaEstados()
        {
            InitializeComponent();
            frmCadEstado = new frmCadastroEstado();
        }

        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null)
            {
                frmCadEstado = (frmCadastroEstado)obj;
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oEstado = (Estado)obj;
            aCtrlEstado = (CtrlEstado)ctrl;
            CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            frmCadEstado.ConhecaObj(oEstado, aCtrlEstado);
            frmCadEstado.CarregarTxt();
            frmCadEstado.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            frmCadEstado.ConhecaObj(oEstado, aCtrlEstado);
            frmCadEstado.CarregarTxt();
            frmCadEstado.ShowDialog();
        }

        public override void Excluir()
        {
            base.Excluir();
            frmCadEstado.ConhecaObj(oEstado, aCtrlEstado);
            frmCadEstado.CarregarTxt();
            frmCadEstado.BloqueiaTxt();
            frmCadEstado.ShowDialog(this);
            frmCadEstado.DesbloqueiaTxt();  
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
			this.listV.Items.Clear();
			ListViewItem item = new ListViewItem(Convert.ToString(oEstado.Id));
            item.SubItems.Add(oEstado.Nome);
            item.SubItems.Add(oEstado.Uf);
            item.SubItems.Add(Convert.ToString(oEstado.Id));
            item.SubItems.Add(oEstado.OPais.Nome);
            listV.Items.Add(item);
        }

    }
}
