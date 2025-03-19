using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.cadastro;
using projeto_pratica.pages.consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Interfaces
	{
		frmConsultaCondPag aFrmConsCondPag;
		frmConsultaFormPag aFrmConsFormPag;

		frmCadastroCondpag aFrmCadCondPag;
		frmCadastroFormPag aFrmCadFormPag;

		public Interfaces()
		{
			aFrmConsCondPag = new frmConsultaCondPag();
			aFrmConsFormPag = new frmConsultaFormPag();

			aFrmCadCondPag = new frmCadastroCondpag();
			aFrmCadFormPag = new frmCadastroFormPag();

			aFrmConsCondPag.setFrmCadastro(aFrmCadCondPag);
			aFrmConsFormPag.setFrmCadastro(aFrmCadFormPag);
		}

		public void PecaCondPag(CondicaoPagamento aCondPag, CtrlCondPag aCtrlCondPag)
		{
			aFrmConsCondPag.ConhecaObj(aCondPag, aCtrlCondPag);
			aFrmConsCondPag.ShowDialog();

		}
		public void PecaFormPag(FormaPagamento aFormPag, CtrlFormPag aCtrlFormPag)
		{
			aFrmConsFormPag.ConhecaObj(aFormPag, aCtrlFormPag);
			aFrmConsFormPag.ShowDialog();
		}
	}
}
