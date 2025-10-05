using projeto_pratica.pages.cadastro;
using System;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;

namespace projeto_pratica.pages.consulta
{
    public partial class frmConsultaUnidadeMedida : projeto_pratica.pages.consulta.frmConsulta
    {
        frmCadastroUnidadeMedida frmCadUniMedida;
        UnidadeMedida oUnidadeMedida;
        CtrlUniMedida aCtrlUniMedida;

        public frmConsultaUnidadeMedida()
        {
            InitializeComponent();
            frmCadUniMedida = new frmCadastroUnidadeMedida();
        }

        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null)
            {
                frmCadUniMedida = (frmCadastroUnidadeMedida)obj;
            }
        }


        public override void ConhecaObj(object obj, object ctrl)
        {
            oUnidadeMedida = (UnidadeMedida)obj;
            aCtrlUniMedida = (CtrlUniMedida)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            frmCadUniMedida.ConhecaObj(oUnidadeMedida, aCtrlUniMedida);
            frmCadUniMedida.LimparTxt();
            frmCadUniMedida.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            frmCadUniMedida.ConhecaObj(oUnidadeMedida, aCtrlUniMedida);
            frmCadUniMedida.CarregarTxt();
            frmCadUniMedida.ShowDialog();
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = frmCadUniMedida.btnSave.Text;
            frmCadUniMedida.btnSave.Text = "Excluir";
            frmCadUniMedida.ConhecaObj(oUnidadeMedida, aCtrlUniMedida);
            frmCadUniMedida.CarregarTxt();
            frmCadUniMedida.BloqueiaTxt();
            frmCadUniMedida.ShowDialog(this);
            frmCadUniMedida.DesbloqueiaTxt();
            frmCadUniMedida.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            this.listV.Items.Clear();
            var lista = aCtrlUniMedida.Listar();
            foreach (var uniMedida in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(uniMedida.Id));
                item.SubItems.Add(uniMedida.Nome);
                item.Tag = uniMedida;
                listV.Items.Add(item);
            }
        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                var selecionado = (UnidadeMedida)listV.SelectedItems[0].Tag;

                oUnidadeMedida.Id = selecionado.Id;
                oUnidadeMedida.Nome = selecionado.Nome;
                oUnidadeMedida.DtCriacao = selecionado.DtCriacao;
                oUnidadeMedida.DtAlt = selecionado.DtAlt;
            }
        }
    }
}