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
    public partial class frmConsultaUnidadeMedida : projeto_pratica.pages.consulta.frmConsulta
    {
        public frmConsultaUnidadeMedida()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmCadastroUnidadeMedida afrmCadastroUnidadeMedida = new frmCadastroUnidadeMedida();
            afrmCadastroUnidadeMedida.ShowDialog();
        }
    }
}
