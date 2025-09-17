using projeto_pratica.pages.cadastro;
using System;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;

namespace projeto_pratica.pages.consulta
{
    public partial class frmConsultaCategoria : projeto_pratica.pages.consulta.frmConsulta
    {
        frmCadastroCategoria frmCadCategoria;
        Categoria oCategoria;
        CtrlCategoria aCtrlCategoria;
        public frmConsultaCategoria()
        {
            InitializeComponent();
            frmCadCategoria = new frmCadastroCategoria();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oCategoria = (Categoria)obj;
            aCtrlCategoria = (CtrlCategoria)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            frmCadCategoria.ConhecaObj(oCategoria, aCtrlCategoria);
            frmCadCategoria.LimparTxt();
            frmCadCategoria.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            frmCadCategoria.ConhecaObj(oCategoria, aCtrlCategoria);
            frmCadCategoria.CarregarTxt();
            frmCadCategoria.ShowDialog();
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = frmCadCategoria.btnSave.Text;
            frmCadCategoria.btnSave.Text = "Excluir";
            frmCadCategoria.ConhecaObj(oCategoria, aCtrlCategoria);
            frmCadCategoria.CarregarTxt();
            frmCadCategoria.BloqueiaTxt();
            frmCadCategoria.ShowDialog(this);
            frmCadCategoria.DesbloqueiaTxt();
            frmCadCategoria.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            this.listV.Items.Clear();
            var lista = aCtrlCategoria.Listar();
            foreach (var categoria in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(categoria.Id));
                item.SubItems.Add(categoria.Nome);
                item.Tag = categoria;
                listV.Items.Add(item);
            }
        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                var selecionado = (Categoria)listV.SelectedItems[0].Tag;

                oCategoria.Id = selecionado.Id;
                oCategoria.Nome = selecionado.Nome;
                oCategoria.DtCriacao = selecionado.DtCriacao;
                oCategoria.DtAlt = selecionado.DtAlt;
            }
        }
    }
}