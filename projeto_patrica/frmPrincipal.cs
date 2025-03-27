using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using projeto_pratica.pages.cadastro;
using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.daos;


namespace projeto_pratica
{
	public partial class frmPrincipal : Form
	{
		private CondicaoPagamento aCondPag;
		private FormaPagamento aFormPag;
		private Pais oPais;
		private Estado oEstado;
		private Cidade aCidade;

		private Interfaces aInter;

		private CtrlCondPag aCtrlCondPag;
		private CtrlFormPag aCtrlFormPag;
		private CtrlPaises aCtrlPais;
		private CtrlEstado aCtrlEstado;
		private CtrlCidade aCtrlCidade;

		public frmPrincipal()
		{
			InitializeComponent();
			aCondPag = new CondicaoPagamento();
			aFormPag = new FormaPagamento();
			oPais = new Pais();
			oEstado = new Estado();
			aCidade = new Cidade();

			aInter = new Interfaces();

			aCtrlCondPag = new CtrlCondPag();
			aCtrlFormPag = new CtrlFormPag();
			aCtrlPais = new CtrlPaises();
			aCtrlEstado = new CtrlEstado();
			aCtrlCidade = new CtrlCidade();

		}	

		private void condiçãoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aInter.PecaCondPag(aCondPag, aCtrlCondPag);
		}

		private void formaDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			aInter.PecaFormPag(aFormPag, aCtrlFormPag);
		}

		private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aInter.PecaCidade(aCidade, aCtrlCidade);

		}

		private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aInter.PecaEstado(oEstado, aCtrlEstado);

		}

		private void paisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aInter.PecaPais(oPais, aCtrlPais);

		}
	}
}
