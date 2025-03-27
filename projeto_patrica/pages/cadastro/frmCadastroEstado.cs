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
    public partial class frmCadastroEstado : frmCadastro
    {
        private frmConsultaPais frmConPais;
        private Estado oEstado;
        private CtrlEstado aCtrlEstado;

        public frmCadastroEstado()
        {
            InitializeComponent();
        }

        public void setFrmConsultaPais(object obj)
        {
            frmConPais = (frmConsultaPais)obj;
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            oEstado = (Estado)obj;
            aCtrlEstado = (CtrlEstado)ctrl;
        }

        public override void LimparTxt()
        {
            base.LimparTxt();
            this.txtCodigo.Text = "0";
            this.txtEstado.Clear();
            this.txtPais.Clear();
            this.txtUf.Clear();
            this.txtPais.Clear();
            this.txtIdPais.Text = "0";
        }

        public override void Salvar()
        {
            base.Salvar();
            if (txtEstado.Text == "" || txtUf.Text == "")
            {
                MessageBox.Show("Campo obrigatório não preenchido!");
            }
            else
            {
                oEstado.Id = Convert.ToInt32(this.txtCodigo.Text);
                oEstado.Nome = this.txtEstado.Text;
                oEstado.Uf = this.txtUf.Text;
                oEstado.OPais.Nome = this.txtPais.Text;
                oEstado.OPais.Id = Convert.ToInt32(this.txtIdPais.Text);
                this.txtCodigo.Text = aCtrlEstado.Salvar(oEstado);
                MessageBox.Show("O estado " + oEstado.Nome + " foi salvo com o código " + this.txtCodigo.Text);
            }
        }

        public override void CarregarTxt()
        {
            base.CarregarTxt();
            this.txtCodigo.Text = Convert.ToString(oEstado.Id);
            this.txtEstado.Text = oEstado.Nome;
            this.txtPais.Text = oEstado.OPais.Nome;
            this.txtUf.Text = oEstado.Uf;
            this.txtPais.Text = oEstado.OPais.Nome;
            this.txtIdPais.Text = Convert.ToString(oEstado.OPais.Id);
        }

        public override void BloqueiaTxt()
        {
            base.BloqueiaTxt();
            this.txtCodigo.Enabled = false;
            this.txtEstado.Enabled = false;
            this.txtPais.Enabled = false;
            this.txtUf.Enabled = false;
            this.txtPais.Enabled = false;
            this.txtIdPais.Enabled = false;
        }

        public override void DesbloqueiaTxt()
        {
            base.DesbloqueiaTxt();
            this.txtCodigo.Enabled = true;
            this.txtEstado.Enabled = true;
            this.txtPais.Enabled = true;
            this.txtUf.Enabled = true;
            this.txtPais.Enabled = true;
            this.txtIdPais.Enabled=true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmConPais.ConhecaObj(oEstado.OPais, aCtrlEstado);
            frmConPais.ShowDialog();
            txtPais.Text = Convert.ToString(oEstado.OPais.Nome);
            txtIdPais.Text = Convert.ToString(oEstado.OPais.Id);
        }

    }
}
