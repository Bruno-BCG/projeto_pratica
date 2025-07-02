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
using projeto_pratica.pages.consulta;


namespace projeto_pratica
{
	public partial class frmPrincipal : Form
	{
		private CondicaoPagamento aCondPag;
		private FormaPagamento aFormPag;
		private Pais oPais;
		private Estado oEstado;
		private Cidade aCidade;
		private Cliente oCliente;
		private Funcionario oFuncionario;
		private Fornecedor oFornecedor;

		private Interfaces aInter;

		private CtrlCondPag aCtrlCondPag;
		private CtrlFormPag aCtrlFormPag;
		private CtrlPaises aCtrlPais;
		private CtrlEstado aCtrlEstado;
		private CtrlCidade aCtrlCidade;
		private CtrlCliente aCtrlCliente;
		private CtrlFuncionario aCtrlFuncionario;
		private CtrlFornecedor aCtrlFornecedor;

		public frmPrincipal()
		{
			InitializeComponent();
			aCondPag = new CondicaoPagamento();
			aFormPag = new FormaPagamento();
			oPais = new Pais();
			oEstado = new Estado();
			aCidade = new Cidade();
			oCliente = new Cliente();
			oFuncionario = new Funcionario();
			oFornecedor = new Fornecedor();

			aInter = new Interfaces();

			aCtrlCondPag = new CtrlCondPag();
			aCtrlFormPag = new CtrlFormPag();
			aCtrlPais = new CtrlPaises();
			aCtrlEstado = new CtrlEstado();
			aCtrlCidade = new CtrlCidade();
			aCtrlCliente = new CtrlCliente();
			aCtrlFuncionario = new CtrlFuncionario();
			aCtrlFornecedor = new CtrlFornecedor();

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

		private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aInter.PecaCliente(oCliente, aCtrlCliente);
		}

		private void funcionarioToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aInter.PecaFuncioanrio(oFuncionario, aCtrlFuncionario);
		}

		private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			aInter.PecaFornecedor(oFornecedor, aCtrlFornecedor);
		}

		private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmConsultaProduto afrmConProduto = new frmConsultaProduto();
			afrmConProduto.ShowDialog();
		}

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
			frmConsultaCategoria afrmConCategoria = new frmConsultaCategoria();
			afrmConCategoria.ShowDialog();
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
			frmConsultaUnidadeMedida afrmConUnidadeMedida = new frmConsultaUnidadeMedida();
			afrmConUnidadeMedida.ShowDialog();
        }
    }
}
