using projeto_pratica;
using projeto_pratica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;

namespace projeto_pratica
{
    public partial class frmCadastroPais : frmCadastro
    {
        private Pais oPais;
        private CtrlPaises aCtrlPais;
        public frmCadastroPais()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oPais = (Pais)obj;
            aCtrlPais = (CtrlPaises)ctrl;
        }

        public override void LimparTxt()
        {
            base.LimparTxt();
            this.txtCodigo.Text = "0";
            this.txtMoeda.Clear();
            this.txtPais.Clear();
            this.txtSigla.Clear();
            this.txtDDI.Clear();            
        }

        public override void Salvar()
        {
            base.Salvar();
            if (txtPais.Text == "" || txtDDI.Text == "")
            {
                MessageBox.Show("Campo obrigatório não preenchido!");

            }
            else
            {
                oPais.Id = Convert.ToInt32(this.txtCodigo.Text);
                oPais.Moeda = this.txtMoeda.Text;
                oPais.Nome = this.txtPais.Text;
                oPais.Sigla = this.txtSigla.Text;
                oPais.Ddi = this.txtDDI.Text;
                this.txtCodigo.Text = aCtrlPais.Salvar(oPais);//oPais.Salvar();
                MessageBox.Show("O pais " + oPais.Nome + " foi salvo com o código " + this.txtCodigo.Text);
            }
        }               

        public override void CarregarTxt()
        {
            base.CarregarTxt();
            this.txtCodigo.Text = Convert.ToString(oPais.Id);
            this.txtMoeda.Text = oPais.Moeda;
            this.txtPais.Text = oPais.Nome;
            this.txtSigla.Text = oPais.Sigla;
            this.txtDDI.Text = oPais.Ddi;
        }

        public override void BloqueiaTxt()
        {
            base.BloqueiaTxt();
            this.txtCodigo.Enabled = false;
            this.txtMoeda.Enabled = false;
            this.txtPais.Enabled = false;
            this.txtSigla.Enabled = false;
            this.txtDDI.Enabled = false;
        }

        public override void DesbloqueiaTxt()
        {
            base.DesbloqueiaTxt();
            this.txtCodigo.Enabled = true;
            this.txtMoeda.Enabled = true;
            this.txtPais.Enabled = true;
            this.txtSigla.Enabled = true;
            this.txtDDI.Enabled = true;
        }
    }
}
