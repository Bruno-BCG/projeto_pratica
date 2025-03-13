using projeto_pratica.classes;
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
using projeto_patrica.classes;


namespace projeto_pratica
{
	public partial class frmPrincipal : Form
	{
		private condicaoPagamento aCondPag;

        private interfaces aInter;

        public frmPrincipal()
		{
			InitializeComponent();
			aCondPag = new condicaoPagamento();

			aInter = new interfaces();

		}	

	
		private void condiçãoDePagamentopToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void condiçãoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aInter.PecaCondPag(aCondPag);
		}
	}
}
