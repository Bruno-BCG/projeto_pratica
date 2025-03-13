using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.cadastro
{
	public partial class frmCadastro : projeto_pratica.frmBase
	{
		public frmCadastro()
		{
			InitializeComponent();
		}
		public virtual void ConhecaObj(object obj)
		{

		}

		public virtual void Salvar()
		{

		}
		public virtual void LimparTxt()
		{
			this.txtCodigo.Clear();
		}

		public virtual void CarregarTxt()
		{

		}

		public virtual void BloqueiaTxt()
		{
			this.txtCodigo.Enabled = false;
		}

		public virtual void DesbloqueiaTxt()
		{
			this.txtCodigo.Enabled = true;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Salvar();
		}
	}
}
