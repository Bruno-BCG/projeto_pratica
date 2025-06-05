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
using System.Collections;
using projeto_pratica.daos;

namespace projeto_pratica
{
    public partial class frmConsultaCidade : frmConsulta
    {
        frmCadastroCidade frmCadCidade;
        Cidade aCidade;
        CtrlCidade aCtrlCidade;
        public frmConsultaCidade()
        {
            InitializeComponent();
            frmCadCidade = new frmCadastroCidade();
        }

        public override void setFrmCadastro(object obj)
        {
            base.setFrmCadastro(obj);
            if (obj != null)
            {
                frmCadCidade = (frmCadastroCidade)obj;
            }
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aCidade = (Cidade)obj;
            aCtrlCidade = (CtrlCidade)ctrl;
            this.CarregaLV();
        }

        public override void Incluir()
        {
            base.Incluir();
            frmCadCidade.ConhecaObj(aCidade, aCtrlCidade);
            frmCadCidade.LimparTxt();
            frmCadCidade.ShowDialog();
            this.CarregaLV();
        }

        public override void Alterar()
        {
            base.Alterar();
            frmCadCidade.ConhecaObj(aCidade, aCtrlCidade);
            frmCadCidade.CarregarTxt();
            frmCadCidade.ShowDialog();
            this.CarregaLV();
		}
		public override void Excluir()
        {
			string aux = frmCadCidade.btnSave.Text;
			frmCadCidade.btnSave.Text = "Excluir";
			frmCadCidade.ConhecaObj(aCidade, aCtrlCidade);
			frmCadCidade.CarregarTxt();
			frmCadCidade.BloqueiaTxt();
			frmCadCidade.ShowDialog(this);
			frmCadCidade.DesbloqueiaTxt();
			frmCadCidade.btnSave.Text = aux;
			this.CarregaLV();
        }

        public override void CarregaLV()
        {
            this.listV.Items.Clear();

            var lista = aCtrlCidade.Listar();

            foreach (var aCidade in lista)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(aCidade.Id));

                item.SubItems.Add(aCidade.Nome);
                item.SubItems.Add(aCidade.Ddd);
                item.SubItems.Add(Convert.ToString(aCidade.OEstado.Id));
                item.SubItems.Add(aCidade.OEstado.Nome);
                item.Tag = aCidade;
                listV.Items.Add(item);
            }

        }

		private void listV_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listV.SelectedItems.Count > 0)
			{
                btnExcluir.Enabled = true;
                btnAlterar.Enabled = true;
				var selectedItem = (Cidade)listV.SelectedItems[0].Tag;

				aCidade.Id = selectedItem.Id; 
				aCidade.Nome = selectedItem.Nome;    
				aCidade.Ddd = selectedItem.Ddd;    

				aCidade.OEstado = selectedItem.OEstado; 

			}
		}
	}
}
