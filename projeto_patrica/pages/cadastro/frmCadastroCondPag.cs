using projeto_pratica.classes;
using projeto_pratica.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.cadastro
{
	public partial class frmCadastroCondpag : projeto_pratica.pages.cadastro.frmCadastro
	{
		private CondicaoPagamento oCondicaoPagamento;
		private CtrlCondPag aCtrlCondPag;

		public frmCadastroCondpag()
		{
			InitializeComponent();
			oCondicaoPagamento = new CondicaoPagamento();
			aCtrlCondPag = new CtrlCondPag();
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			oCondicaoPagamento = (CondicaoPagamento)obj;
			aCtrlCondPag = (CtrlCondPag)ctrl;
			this.CarregarTxt();
		}

		public override void LimparTxt()
		{
			base.LimparTxt();
			this.txtCodigo.Text = "0";
			this.txtDescricao.Clear();
			this.txtParcelas.Clear();
		}

		public override void Salvar()
		{
			base.Salvar();

			if (string.IsNullOrWhiteSpace(txtDescricao.Text) || string.IsNullOrWhiteSpace(txtParcelas.Text))
			{
				MessageBox.Show("Campo obrigatório não preenchido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			oCondicaoPagamento.Descricao = txtDescricao.Text;
			oCondicaoPagamento.NumParcelas = Convert.ToInt32(txtParcelas.Text);
			
			string resultado = aCtrlCondPag.Salvar(oCondicaoPagamento);

			if (int.TryParse(resultado, out int novoId))
			{
				txtCodigo.Text = novoId.ToString();
				MessageBox.Show($"A condição de pagamento '{oCondicaoPagamento.Descricao}' foi salva com o código {txtCodigo.Text}.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public override void CarregarTxt()
		{
			base.CarregarTxt();
			this.txtCodigo.Text = Convert.ToString(oCondicaoPagamento.Id);
			this.txtDescricao.Text = oCondicaoPagamento.Descricao;
			this.txtParcelas.Text = Convert.ToString(oCondicaoPagamento.NumParcelas);
		}

		public override void BloqueiaTxt()
		{
			base.BloqueiaTxt();
			this.txtCodigo.Enabled = false;
			this.txtDescricao.Enabled = false;
			this.txtParcelas.Enabled = false;
		}

		public override void DesbloqueiaTxt()
		{
			base.DesbloqueiaTxt();
			this.txtCodigo.Enabled = true;
			this.txtDescricao.Enabled = true;
			this.txtParcelas.Enabled = true;
		}
	}
}