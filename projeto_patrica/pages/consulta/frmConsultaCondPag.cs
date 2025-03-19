﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using projeto_pratica.pages.cadastro;
using projeto_pratica.classes;
using System.Collections;
using projeto_pratica.controllers;

namespace projeto_pratica.pages.consulta
{
	public partial class frmConsultaCondPag : projeto_pratica.pages.consulta.frmConsulta
	{
		private frmCadastroCondpag oFrmCadastroCondpag;
		private CondicaoPagamento aCondPag;
		private CtrlCondPag aCtrlCondPag;
		public frmConsultaCondPag()
		{
			InitializeComponent();
			oFrmCadastroCondpag = new frmCadastroCondpag();
		}

		public override void setFrmCadastro(object obj)
		{
			base.setFrmCadastro(obj);
			if (obj != null)
			{
				oFrmCadastroCondpag = (frmCadastroCondpag)obj;
			}
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			aCondPag = (CondicaoPagamento)obj;
			aCtrlCondPag = (CtrlCondPag)ctrl;
			this.CarregaLV();
		}

		public override void CarregaLV()
		{
			this.listV.Items.Clear();
			var lista = aCtrlCondPag.Listar();
			foreach (var cond in lista)
			{
				ListViewItem item = new ListViewItem(Convert.ToString(cond.Id));
				item.SubItems.Add(cond.Descricao);
				item.SubItems.Add(Convert.ToString(cond.NumParcelas));
				listV.Items.Add(item);
			}
		}

		public override void Incluir()
		{
			base.Incluir();
			oFrmCadastroCondpag.ConhecaObj(aCondPag, aCtrlCondPag);
			oFrmCadastroCondpag.LimparTxt();
			oFrmCadastroCondpag.ShowDialog();
			this.CarregaLV();
		}

		public override void Alterar()
		{
			base.Incluir();
			oFrmCadastroCondpag.ConhecaObj(aCondPag, aCtrlCondPag);
			oFrmCadastroCondpag.CarregarTxt();
			oFrmCadastroCondpag.ShowDialog();
		}

		public override void Excluir()
		{
			base.Excluir();
			oFrmCadastroCondpag.ConhecaObj(aCondPag, aCtrlCondPag);
			oFrmCadastroCondpag.CarregarTxt();
			oFrmCadastroCondpag.BloqueiaTxt();
			oFrmCadastroCondpag.ShowDialog(this);
			oFrmCadastroCondpag.DesbloqueiaTxt();
		}

		private void listV_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listV.SelectedItems.Count > 0)
			{
				ListViewItem item = listV.SelectedItems[0]; // Get selected row

				// Store data in an object (already available in ListView)
				aCondPag = new CondicaoPagamento
				{
					Id = Convert.ToInt32(item.Text), // First column (ID)
					Descricao = item.SubItems[1].Text, // Second column (Description)
					NumParcelas = Convert.ToInt32(item.SubItems[2].Text) // Third column (NumParcelas)
				};
			}
		}
	}
}
