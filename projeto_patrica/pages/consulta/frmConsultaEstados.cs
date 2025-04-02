﻿using projeto_pratica;
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
using System.Collections;

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
            frmCadEstado.LimparTxt();
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
            this.listV.Items.Clear();

            var lista = aCtrlEstado.Listar();

            foreach (var oEstado in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oEstado.Id));

                item.SubItems.Add(oEstado.Nome);                   
                item.SubItems.Add(oEstado.Uf);                  
                item.SubItems.Add(Convert.ToString(oEstado.OPais.Id)); 
                item.SubItems.Add(oEstado.OPais.Nome);           

                // Add the item to the ListView
                listV.Items.Add(item);
            }
        }

        private void listV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
				btnExcluir.Enabled = true;
				btnAlterar.Enabled = true;
				ListViewItem selectedItem = listV.SelectedItems[0];

				oEstado.Id = Convert.ToInt32(selectedItem.Text);
				oEstado.Nome = selectedItem.SubItems[1].Text;  
				oEstado.Uf = selectedItem.SubItems[2].Text;     

				// Update the associated Pais
				oEstado.OPais.Id = Convert.ToInt32(selectedItem.SubItems[3].Text); 
				oEstado.OPais.Nome = selectedItem.SubItems[4].Text;
			}
        }
	}
}
