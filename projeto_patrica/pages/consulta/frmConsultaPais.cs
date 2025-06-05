using projeto_pratica;
using projeto_pratica.pages.consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.cadastro;
using projeto_pratica.daos;


namespace projeto_pratica
{
    public partial class frmConsultaPais : frmConsulta
    {
        frmCadastroPais frmCadPais;
        Pais oPais;
        CtrlPaises aCtrlPais;
        public frmConsultaPais()
        {
            InitializeComponent();
            frmCadPais = new frmCadastroPais();
        }

        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null )
            {
                frmCadPais = (frmCadastroPais)obj;
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oPais = (Pais)obj;
            aCtrlPais = (CtrlPaises)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            frmCadPais.ConhecaObj(oPais, aCtrlPais);
            frmCadPais.LimparTxt();
            frmCadPais.ShowDialog();        
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Incluir();
            frmCadPais.ConhecaObj(oPais, aCtrlPais);
            frmCadPais.CarregarTxt();
            frmCadPais.ShowDialog();
			this.CarregaLV();
		}

        public override void Excluir()
        {
            base.Excluir();

			string aux = frmCadPais.btnSave.Text;
			frmCadPais.btnSave.Text = "Excluir";
			frmCadPais.ConhecaObj(oPais, aCtrlPais);
			frmCadPais.CarregarTxt();
			frmCadPais.BloqueiaTxt();
			frmCadPais.ShowDialog(this);
			frmCadPais.DesbloqueiaTxt();
			frmCadPais.btnSave.Text = aux;
			this.CarregaLV();
		}

        public override void CarregaLV()
        {
            this.listV.Items.Clear();
            var lista = aCtrlPais.ListarPaises();
            foreach (var oPais in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(oPais.Id));

                item.SubItems.Add(oPais.Nome);
                item.SubItems.Add(oPais.Sigla);
                item.SubItems.Add(oPais.Moeda);
                item.SubItems.Add(oPais.Ddi);
                item.Tag = oPais;
                listV.Items.Add(item);
            }
        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (listV.SelectedItems.Count > 0)
			{
				btnExcluir.Enabled = true;
				btnAlterar.Enabled = true;
				var selecionado = (Pais)listV.SelectedItems[0].Tag;

				// Preenche o objeto já conhecido, sem substituir a referência
				oPais.Id = selecionado.Id;
				oPais.Nome = selecionado.Nome;
				oPais.Sigla = selecionado.Sigla;
				oPais.Moeda = selecionado.Moeda;
				oPais.Ddi = selecionado.Ddi;
			}
		}

        private void frmConsultaPais_Load(object sender, EventArgs e)
        {

        }
    }
}
