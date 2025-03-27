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
		frmConsultaPais aFrmConsPais;
		frmConsultaEstados aFrmConsEstados;
		frmConsultaCidade aFrmConsCidade;

		frmCadastroCondpag aFrmCadCondPag;
		frmCadastroFormPag aFrmCadFormPag;
		frmCadastroPais aFrmCadPais;
		frmCadastroEstado aFrmCadEstado;
		frmCadastroCidade aFrmCadCidade;

		public Interfaces()
		{
			aFrmConsCondPag = new frmConsultaCondPag();
			aFrmConsFormPag = new frmConsultaFormPag();
			aFrmConsPais = new frmConsultaPais();
			aFrmConsEstados = new frmConsultaEstados();
			aFrmConsCidade = new frmConsultaCidade();

			aFrmCadCondPag = new frmCadastroCondpag();
			aFrmCadFormPag = new frmCadastroFormPag();
			aFrmCadPais = new frmCadastroPais();
			aFrmCadEstado = new frmCadastroEstado();
			aFrmCadCidade = new frmCadastroCidade();

			aFrmConsCondPag.setFrmCadastro(aFrmCadCondPag);
			aFrmConsFormPag.setFrmCadastro(aFrmCadFormPag);
			aFrmConsCidade.setFrmCadastro(aFrmCadCidade);
			aFrmConsEstados.setFrmCadastro(aFrmCadEstado);
			aFrmConsPais.setFrmCadastro(aFrmCadPais);

			aFrmCadCidade.setFrmConsultaEstado(aFrmConsEstados);
			aFrmCadEstado.setFrmConsultaPais(aFrmConsPais);
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

		public void PecaCidade(Cidade aCidade, CtrlCidade aCtrlCidade)
		{
			aFrmConsCidade.ConhecaObj(aCidade, aCtrlCidade);
			aFrmConsCidade.ShowDialog();
		}

		public void PecaEstado(Estado oEstado, CtrlEstado aCtrlEstado)
		{
			aFrmConsEstados.ConhecaObj(oEstado, aCtrlEstado);
			aFrmConsEstados.ShowDialog();
		}

		public void PecaPais(Pais oPais, CtrlPaises aCtrlPais)
		{
			aFrmConsPais.ConhecaObj(oPais, aCtrlPais);
			aFrmConsPais.ShowDialog();
		}
	}
}
