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
        public void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == ',')
            {
                var tb = (TextBox)sender;

                string textoSemSelecao = tb.Text.Remove(tb.SelectionStart, tb.SelectionLength);

                if (textoSemSelecao.Contains(","))
                {
                    e.Handled = true;
                    return;
                }
                return; 
            }
            e.Handled = true;
        }
    }
}
