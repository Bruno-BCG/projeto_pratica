using projeto_pratica;
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
    public partial class frmCadastroCidade : frmCadastro
    {
        private frmConsultaEstados frmConEstados;
        private Cidade aCidade;
        private CtrlCidade aCtrlCidade;
        public frmCadastroCidade()
        {
            InitializeComponent();
        }

        public override void ConhecaObj(object obj, object ctrl)
        {
            aCidade = (Cidade)obj;
            aCtrlCidade = (CtrlCidade)ctrl;
        }

        public void setFrmConsultaEstado(object obj)
        {
            frmConEstados = (frmConsultaEstados)obj;
        }

        public override void LimparTxt()
        {
            base.LimparTxt();
            this.txtCodigo.Text = "0";
            this.txtIdEstado.Text = "0";
            this.txtCidade.Clear();
            this.txtDDD.Clear();
            this.txtEstado.Clear();
        }

        public override void Salvar()
        {
            base.Salvar();
            if (txtCidade.Text == "" || txtDDD.Text == "")
            {
                MessageBox.Show("Campo obrigatório não preenchido!");

            }
            else
            {
                aCidade.Id = Convert.ToInt32(this.txtCodigo.Text);
                aCidade.Nome = this.txtCidade.Text;
                aCidade.Ddd = this.txtDDD.Text;
                aCidade.OEstado.Nome = this.txtEstado.Text;
                aCidade.OEstado.Id = Convert.ToInt32(this.txtIdEstado.Text);
                this.txtCodigo.Text = aCtrlCidade.Salvar(aCidade);
                MessageBox.Show("A cidade " + aCidade.Nome + " foi salvo com o código " + this.txtCodigo.Text);
            }
        }

        public override void CarregarTxt()
        {
            base.CarregarTxt();
            this.txtCodigo.Text = Convert.ToString(aCidade.Id);
            this.txtCidade.Text = aCidade.Nome;
            this.txtDDD.Text = aCidade.Ddd;
            this.txtEstado.Text = aCidade.OEstado.Nome;
            this.txtIdEstado.Text = Convert.ToString(aCidade.OEstado.Id);
        }

        public override void BloqueiaTxt()
        {
            base.BloqueiaTxt();
            this.txtCodigo.Enabled = false;
            this.txtIdEstado.Enabled = false;
            this.txtCidade.Enabled = false;
            this.txtDDD.Enabled = false;
            this.txtEstado.Enabled = false;
            this.btnPesquisar.Enabled = false;
        }

        public override void DesbloqueiaTxt()
        {
            base.DesbloqueiaTxt();
            this.txtCodigo.Enabled = true;
            this.txtIdEstado.Enabled=true;
            this.txtCidade.Enabled = true;
            this.txtDDD.Enabled = true;
            this.txtEstado.Enabled = true;
            this.btnPesquisar.Enabled=true;

        }

        private void frmCadastroCidades_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CtrlEstado aCtrlEstado = new CtrlEstado();
            frmConEstados.ConhecaObj(aCidade.OEstado, aCtrlEstado);
            frmConEstados.ShowDialog();
            txtEstado.Text = Convert.ToString(aCidade.OEstado.Nome);
            txtIdEstado.Text = Convert.ToString(aCidade.OEstado.Id);
        }
    }
}
