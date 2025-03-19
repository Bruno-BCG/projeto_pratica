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

        private Interfaces aInter;

		private CtrlCondPag aCtrlCondPag;
		private CtrlFormPag aCtrlFormPag;

        public frmPrincipal()
		{
			InitializeComponent();
			aCondPag = new CondicaoPagamento();
			aFormPag = new FormaPagamento();

			aInter = new Interfaces();

			aCtrlCondPag = new CtrlCondPag();
			aCtrlFormPag = new CtrlFormPag();

		}	

	
		private void condiçãoDePagamentopToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void condiçãoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aInter.PecaCondPag(aCondPag, aCtrlCondPag);
		}

		private void formaDePagamentoToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			aInter.PecaFormPag(aFormPag, aCtrlFormPag);
		}
	}
}
