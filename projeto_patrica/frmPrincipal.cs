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
		private Categoria aCategoria;
		private Marca aMarca;
		private UnidadeMedida aUniMedida;
		private Produto oProduto;
		private NotaEntrada aNotaEntrada;
		private ContasPagar aContasPagar;

		private Interfaces aInter;

		private CtrlCondPag aCtrlCondPag;
		private CtrlFormPag aCtrlFormPag;
		private CtrlPaises aCtrlPais;
		private CtrlEstado aCtrlEstado;
		private CtrlCidade aCtrlCidade;
		private CtrlCliente aCtrlCliente;
		private CtrlFuncionario aCtrlFuncionario;
		private CtrlFornecedor aCtrlFornecedor;
		private CtrlCategoria aCtrlCategoria;
		private CtrlMarca aCtrlMarca;
		private CtrlUniMedida aCtrlUniMedida;
		private CtrlProduto aCtrlProduto;
		private CtrlNotaEntrada aCtrlNotaEntrada;
		private CtrlContasPagar aCtrlContasPagar;

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
			aCategoria = new Categoria();
			aMarca = new Marca();
			aUniMedida = new UnidadeMedida();
			oProduto = new Produto();
			aNotaEntrada = new NotaEntrada();
			aContasPagar = new ContasPagar();

			aInter = new Interfaces();

			aCtrlCondPag = new CtrlCondPag();
			aCtrlFormPag = new CtrlFormPag();
			aCtrlPais = new CtrlPaises();
			aCtrlEstado = new CtrlEstado();
			aCtrlCidade = new CtrlCidade();
			aCtrlCliente = new CtrlCliente();
			aCtrlFuncionario = new CtrlFuncionario();
			aCtrlFornecedor = new CtrlFornecedor();
			aCtrlCategoria = new CtrlCategoria();
			aCtrlMarca = new CtrlMarca();
			aCtrlUniMedida = new CtrlUniMedida();
			aCtrlProduto = new CtrlProduto();
			aCtrlNotaEntrada = new CtrlNotaEntrada();
			aCtrlContasPagar = new CtrlContasPagar();
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
			aInter.PecaProduto(oProduto, aCtrlProduto);
		}

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
			aInter.PecaCategoria(aCategoria, aCtrlCategoria);
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
			aInter.PecaUniMedida(aUniMedida, aCtrlUniMedida);
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
			aInter.PecaMarca(aMarca, aCtrlMarca);
        }

        private void notaDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
			aInter.PecaNotaEntrada(aNotaEntrada, aCtrlNotaEntrada);
        }

        private void contasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
			aInter.PecaContasPagar(aContasPagar, aCtrlContasPagar);
        }
    }
}
