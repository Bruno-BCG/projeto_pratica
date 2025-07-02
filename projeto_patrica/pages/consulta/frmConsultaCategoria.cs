using projeto_pratica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.consulta
{
    public partial class frmConsultaCategoria : projeto_pratica.pages.consulta.frmConsulta
    {
        public frmConsultaCategoria()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmCadastroCategoria afrmCadastroCategoria = new frmCadastroCategoria();
            afrmCadastroCategoria.ShowDialog();
        }
    }
}
