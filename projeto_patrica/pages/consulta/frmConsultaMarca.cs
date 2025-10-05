using projeto_pratica.classes;
using System;
using System.Windows.Forms;
using projeto_pratica.pages.cadastro;
using projeto_pratica.controllers;

namespace projeto_pratica.pages.consulta
{
    public partial class frmConsultaMarca : projeto_pratica.pages.consulta.frmConsulta
    {
        frmCadastroMarca frmCadMarca;
        Marca oMarca;
        CtrlMarca aCtrlMarca;
        public frmConsultaMarca()
        {
            InitializeComponent();
            frmCadMarca = new frmCadastroMarca();
        }
        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null)
            {
                frmCadMarca = (frmCadastroMarca)obj;
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oMarca = (Marca)obj;
            aCtrlMarca = (CtrlMarca)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            frmCadMarca.ConhecaObj(oMarca, aCtrlMarca);
            frmCadMarca.LimparTxt();
            frmCadMarca.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            frmCadMarca.ConhecaObj(oMarca, aCtrlMarca);
            frmCadMarca.CarregarTxt();
            frmCadMarca.ShowDialog();
            this.CarregaLV();
        }

        public override void Excluir()
        {
            base.Excluir();
            string aux = frmCadMarca.btnSave.Text;
            frmCadMarca.btnSave.Text = "Excluir";
            frmCadMarca.ConhecaObj(oMarca, aCtrlMarca);
            frmCadMarca.CarregarTxt();
            frmCadMarca.BloqueiaTxt();
            frmCadMarca.ShowDialog(this);
            frmCadMarca.DesbloqueiaTxt();
            frmCadMarca.btnSave.Text = aux;
            this.CarregaLV();
        }

        public override void CarregaLV()
        {
            this.listV.Items.Clear();
            var lista = aCtrlMarca.Listar();
            foreach (var marca in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(marca.Id));
                item.SubItems.Add(marca.Nome);
                item.Tag = marca;
                listV.Items.Add(item);
            }
        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listV.SelectedItems.Count > 0)
            {
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
                var selecionado = (Marca)listV.SelectedItems[0].Tag;

                // Preenche o objeto já conhecido
                oMarca.Id = selecionado.Id;
                oMarca.Nome = selecionado.Nome;
                oMarca.DtCriacao = selecionado.DtCriacao;
                oMarca.DtAlt = selecionado.DtAlt;
            }
        }
    }
}