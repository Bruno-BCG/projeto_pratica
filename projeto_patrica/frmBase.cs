using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_pratica
{
	public partial class frmBase : Form
	{
		public frmBase()
		{
			InitializeComponent();
		}

		public virtual void Sair()
		{
			Close();
		}

		private void btnSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void frmBase_Load(object sender, EventArgs e)
		{

		}
	}
}
