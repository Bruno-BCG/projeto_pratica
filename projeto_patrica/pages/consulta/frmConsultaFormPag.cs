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
	public partial class frmConsultaFormPag : projeto_pratica.pages.consulta.frmConsulta
	{
		private frmCadastroFormPag oFrmCadastroFormPag;
		private FormaPagamento aFormPag;
		private CtrlFormPag aCtrlFormPag;

		public frmConsultaFormPag()
		{
			InitializeComponent();
		}

		public override void setFrmCadastro(object obj)
		{
			base.setFrmCadastro(obj);
			if (obj != null)
			{
				oFrmCadastroFormPag = (frmCadastroFormPag)obj;
			}
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			aFormPag = (FormaPagamento)obj;
			aCtrlFormPag = (CtrlFormPag)ctrl;
			this.CarregaLV();
		}

		public override void CarregaLV()
		{
			this.listV.Items.Clear();
			var lista = aCtrlFormPag.Listar();
			foreach (var cond in lista)
			{
				ListViewItem item = new ListViewItem(Convert.ToString(cond.Id));
				item.SubItems.Add(cond.Descricao);
				listV.Items.Add(item);
			}
		}

		public override void Incluir()
		{
			base.Incluir();
			oFrmCadastroFormPag.ConhecaObj(aFormPag, aCtrlFormPag);
			oFrmCadastroFormPag.LimparTxt();
			oFrmCadastroFormPag.ShowDialog();
			this.CarregaLV();
		}

		public override void Alterar()
		{
			base.Incluir();
			oFrmCadastroFormPag.ConhecaObj(aFormPag, aCtrlFormPag);
			oFrmCadastroFormPag.CarregarTxt();
			oFrmCadastroFormPag.ShowDialog();
			this.CarregaLV();
		}

		public override void Excluir()
		{
			string aux = oFrmCadastroFormPag.btnSave.Text;
			oFrmCadastroFormPag.btnSave.Text = "Excluir";
			oFrmCadastroFormPag.ConhecaObj(aFormPag, aCtrlFormPag);
			oFrmCadastroFormPag.CarregarTxt();
			oFrmCadastroFormPag.BloqueiaTxt();
			oFrmCadastroFormPag.ShowDialog(this);
			oFrmCadastroFormPag.DesbloqueiaTxt();
			oFrmCadastroFormPag.btnSave.Text = aux;
			this.CarregaLV();
		}

		private void listV_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listV.SelectedItems.Count > 0)
			{
				btnExcluir.Enabled = true;
				btnAlterar.Enabled = true;
				ListViewItem item = listV.SelectedItems[0]; // Get selected row

				// Store data in an object (already available in ListView)
				aFormPag = new FormaPagamento
				{
					Id = Convert.ToInt32(item.Text), // First column (ID)
					Descricao = item.SubItems[1].Text, // Second column (Description)
				};
			}
		}
	}
}
