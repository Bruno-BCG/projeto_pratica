﻿using projeto_pratica.classes;
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
		frmConsultaCliente aFrmConsCliente;
		frmConsultaFuncionario aFrmConsFuncionario;
		frmConsultaFornecedor aFrmConsFornecedor;
		frmConsultaCategoria aFrmConsCategoria;
		frmConsultaMarca aFrmConsMarca;
		frmConsultaUnidadeMedida aFrmConsUniMedida;
		frmConsultaProduto aFrmConsProduto;

		frmCadastroCondpag aFrmCadCondPag;
		frmCadastroFormPag aFrmCadFormPag;
		frmCadastroPais aFrmCadPais;
		frmCadastroEstado aFrmCadEstado;
		frmCadastroCidade aFrmCadCidade;
		frmCadastroCliente aFrmCadCliente;
		frmCadastroFuncionario aFrmCadFuncionario;
		frmCadastroFornecedor aFrmCadFornecedor;
		frmCadastroCategoria aFrmCadCategoria;
		frmCadastroMarca aFrmCadMarca;
		frmCadastroUnidadeMedida aFrmCadUniMedida;
		frmCadastroProduto aFrmCadProduto;


		public Interfaces()
		{
			aFrmConsCondPag = new frmConsultaCondPag();
			aFrmConsFormPag = new frmConsultaFormPag();
			aFrmConsPais = new frmConsultaPais();
			aFrmConsEstados = new frmConsultaEstados();
			aFrmConsCidade = new frmConsultaCidade();
			aFrmConsCliente = new frmConsultaCliente();
			aFrmConsFuncionario = new frmConsultaFuncionario();
			aFrmConsFornecedor = new frmConsultaFornecedor();
			aFrmConsCategoria = new frmConsultaCategoria();
			aFrmConsMarca = new frmConsultaMarca();
			aFrmConsUniMedida = new frmConsultaUnidadeMedida();
			aFrmConsProduto = new frmConsultaProduto();

			aFrmCadCondPag = new frmCadastroCondpag();
			aFrmCadFormPag = new frmCadastroFormPag();
			aFrmCadPais = new frmCadastroPais();
			aFrmCadEstado = new frmCadastroEstado();
			aFrmCadCidade = new frmCadastroCidade();
			aFrmCadCliente = new frmCadastroCliente();
			aFrmCadFuncionario = new frmCadastroFuncionario();
			aFrmCadFornecedor = new frmCadastroFornecedor();
			aFrmCadCategoria = new frmCadastroCategoria();
			aFrmCadMarca = new frmCadastroMarca();
			aFrmCadUniMedida = new frmCadastroUnidadeMedida();
			aFrmCadProduto = new frmCadastroProduto();

			aFrmConsCondPag.setFrmCadastro(aFrmCadCondPag);
			aFrmConsFormPag.setFrmCadastro(aFrmCadFormPag);
			aFrmConsCidade.setFrmCadastro(aFrmCadCidade);
			aFrmConsEstados.setFrmCadastro(aFrmCadEstado);
			aFrmConsPais.setFrmCadastro(aFrmCadPais);
			aFrmConsCliente.setFrmCadastro(aFrmCadCliente);
			aFrmConsFuncionario.setFrmCadastro(aFrmCadFuncionario);
			aFrmConsFornecedor.setFrmCadastro(aFrmCadFornecedor);
			aFrmConsCategoria.setFrmCadastro(aFrmCadCategoria);
			aFrmConsMarca.setFrmCadastro(aFrmCadMarca);
			aFrmConsUniMedida.setFrmCadastro(aFrmCadUniMedida);
			aFrmConsProduto.setFrmCadastro(aFrmCadProduto);

			aFrmCadCondPag.setFrmConsultaFormPag(aFrmConsFormPag);
			aFrmCadCliente.setFrmConsultaCidade(aFrmConsCidade);
			aFrmCadCliente.setFrmConsultaCondPag(aFrmConsCondPag);
			aFrmCadFuncionario.setFrmConsultaCidade(aFrmConsCidade);
			aFrmCadFornecedor.setFrmConsultaCidade(aFrmConsCidade);
			aFrmCadFornecedor.setFrmConsultaCondPag(aFrmConsCondPag);
			aFrmCadCidade.setFrmConsultaEstado(aFrmConsEstados);
			aFrmCadEstado.setFrmConsultaPais(aFrmConsPais);
			aFrmCadProduto.setFrmConsultaCategoria(aFrmConsCategoria);
			aFrmCadProduto.setFrmConsultaFornecedor(aFrmConsFornecedor);
			aFrmCadProduto.setFrmConsultaUnidadeMedida(aFrmConsUniMedida);
			aFrmCadProduto.setFrmConsultaMarca(aFrmConsMarca);
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

		public void PecaCliente(Cliente oCliente, CtrlCliente aCtrlCliente)
		{
			aFrmConsCliente.ConhecaObj(oCliente, aCtrlCliente);
			aFrmConsCliente.ShowDialog();
		}
		public void PecaFuncioanrio(Funcionario oFuncionario, CtrlFuncionario aCtrlFuncionario)
		{
			aFrmConsFuncionario.ConhecaObj(oFuncionario, aCtrlFuncionario);
			aFrmConsFuncionario.ShowDialog();
		}
		public void PecaFornecedor(Fornecedor oFornecedor, CtrlFornecedor aCtrlFornecedor)
		{
			aFrmConsFornecedor.ConhecaObj(oFornecedor, aCtrlFornecedor);
			aFrmConsFornecedor.ShowDialog();
		}

		public void PecaCategoria(Categoria aCategoria, CtrlCategoria aCtrlCategoria)
		{
			aFrmConsCategoria.ConhecaObj(aCategoria, aCtrlCategoria);
			aFrmConsCategoria.ShowDialog();
		}
		public void PecaMarca(Marca aMarca, CtrlMarca aCtrlMarca)
		{
			aFrmConsMarca.ConhecaObj(aMarca, aCtrlMarca);
			aFrmConsMarca.ShowDialog();
		}
		public void PecaUniMedida(UnidadeMedida aUniMedida, CtrlUniMedida aCtrlUniMedida)
		{
			aFrmConsUniMedida.ConhecaObj(aUniMedida, aCtrlUniMedida);
			aFrmConsUniMedida.ShowDialog();
		}
		public void PecaProduto(Produto oProduto, CtrlProduto aCtrlProduto)
		{
			aFrmConsProduto.ConhecaObj(oProduto, aCtrlProduto);
			aFrmConsProduto.ShowDialog();
		}
	}
}
