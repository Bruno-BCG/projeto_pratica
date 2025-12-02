using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.consulta
{
	public partial class frmConsulta : projeto_pratica.frmBase
	{
		public frmConsulta()
		{
			InitializeComponent();
		}

		public virtual void ConhecaObj(object obj, object ctrl)
		{

		}
		public virtual void setFrmCadastro(object obj)
		{

		}

		public virtual void Incluir()
		{

		}

		public virtual void Alterar()
		{

		}

		public virtual void Excluir()
		{

		}

		public virtual void Pesquisar()
		{

		}

		public virtual void CarregaLV()
		{

		}


		private void btnIncluir_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void btnAlterar_Click(object sender, EventArgs e)
		{
			Alterar();
		}

		private void btnExcluir_Click(object sender, EventArgs e)
		{
			Excluir();
		}

		private void btnPesquisar_Click(object sender, EventArgs e)
		{
			Pesquisar();
		}

		private void frmConsulta_Load(object sender, EventArgs e)
		{

		}
    }
}