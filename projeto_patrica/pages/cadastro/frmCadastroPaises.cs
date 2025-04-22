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

			if (string.IsNullOrWhiteSpace(txtPais.Text) || string.IsNullOrWhiteSpace(txtDDI.Text))
			{
				MessageBox.Show("Campo obrigatório não preenchido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (int.TryParse(txtCodigo.Text, out int paisId) && paisId > 0)
			{
				oPais.Id = paisId;
			}

			oPais.Nome = txtPais.Text;
			oPais.Moeda = txtMoeda.Text;
			oPais.Sigla = txtSigla.Text;
			oPais.Ddi = txtDDI.Text;

			if (btnSave.Text == "Salvar")
			{
				string resultado = aCtrlPais.Salvar(oPais);

				if (int.TryParse(resultado, out int novoId))
				{
					txtCodigo.Text = novoId.ToString();
					MessageBox.Show($"O país '{oPais.Nome}' foi salvo com o código {txtCodigo.Text}.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (btnSave.Text == "Excluir")
			{
				string resultado = aCtrlPais.Excluir(oPais);

				if (resultado == "OK")
				{
					MessageBox.Show("País excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
