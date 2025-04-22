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

			if (string.IsNullOrWhiteSpace(txtCidade.Text) || string.IsNullOrWhiteSpace(txtDDD.Text))
			{
				MessageBox.Show("Os campos Cidade e DDD são obrigatórios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			aCidade.Nome = txtCidade.Text;
			aCidade.Ddd = txtDDD.Text;
			aCidade.OEstado.Nome = txtEstado.Text;

			if (int.TryParse(txtIdEstado.Text, out int estadoId))
			{
				aCidade.OEstado.Id = estadoId;
			}

			if (int.TryParse(txtCodigo.Text, out int cidadeId) && cidadeId > 0)
			{
				aCidade.Id = cidadeId;
			}

			if (btnSave.Text == "Salvar")
			{
				string resultado = aCtrlCidade.Salvar(aCidade);

				if (int.TryParse(resultado, out int novoId))
				{
					txtCodigo.Text = novoId.ToString();
					MessageBox.Show($"Cidade '{aCidade.Nome}' foi salva com sucesso com o código {novoId}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (btnSave.Text == "Excluir")
			{
				string resultado = aCtrlCidade.Excluir(aCidade);

				if (resultado == "OK")
				{
					MessageBox.Show("Cidade excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show($"Erro ao excluir: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
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
