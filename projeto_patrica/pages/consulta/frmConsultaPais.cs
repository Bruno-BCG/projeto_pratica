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
            CarregaLV();
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
        }

        public override void Excluir()
        {
            base.Excluir();
            frmCadPais.ConhecaObj(oPais, aCtrlPais);
            frmCadPais.CarregarTxt();
            frmCadPais.BloqueiaTxt();
            frmCadPais.ShowDialog(this);
            frmCadPais.DesbloqueiaTxt();
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
                listV.Items.Add(item);
            }
        }

        private void ListV_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (listV.SelectedItems.Count > 0)
			{
				btnExcluir.Enabled = true;
				btnAlterar.Enabled = true;
				ListViewItem selectedItem = listV.SelectedItems[0];

				oPais.Id = Convert.ToInt32(selectedItem.Text); 
				oPais.Nome = selectedItem.SubItems[1].Text;    
				oPais.Sigla = selectedItem.SubItems[2].Text;   
				oPais.Moeda = selectedItem.SubItems[3].Text; 
				oPais.Ddi = selectedItem.SubItems[4].Text;     
			}
		}

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }
    }
}
