using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;

namespace projeto_pratica.pages.cadastro
{
	public partial class frmCadastroFormPag : projeto_pratica.pages.cadastro.frmCadastro
	{
		private FormaPagamento aFormaPagamento;
		private CtrlFormPag aCtrlFormPag;
		public frmCadastroFormPag()
		{
			InitializeComponent();
			aFormaPagamento = new FormaPagamento();
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			aFormaPagamento = (FormaPagamento)obj;
			aCtrlFormPag = (CtrlFormPag)ctrl;
		}

		public override void LimparTxt()
		{
			base.LimparTxt(); ;
			txtCodigo.Text = "0";
			txtDescricao.Clear();

			txtDtAlt.Clear();
			txtDtCriacao.Clear();
		}
		public override void CarregarTxt()
		{
			base.CarregarTxt();
			txtCodigo.Text = Convert.ToString(aFormaPagamento.Id);
			txtDescricao.Text = aFormaPagamento.Descricao;

			txtDtCriacao.Text = aFormaPagamento.DtCriacao.ToString();
			txtDtAlt.Text = aFormaPagamento.DtAlt.ToString();	
			
		}

		public override void BloqueiaTxt()
		{
			base.BloqueiaTxt();
			txtCodigo.Enabled = false;
			txtDescricao.Enabled = false;
		}

		public override void DesbloqueiaTxt()
		{
			base.DesbloqueiaTxt();
			txtCodigo.Enabled = true;
			txtDescricao.Enabled = true;
		}

		public override void Salvar()
		{
			base.Salvar();

			if (string.IsNullOrWhiteSpace(txtDescricao.Text))
			{
				MessageBox.Show("O campo descrição é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			aFormaPagamento.Descricao = txtDescricao.Text;

			// If it's an update, assign the ID
			if (int.TryParse(txtCodigo.Text, out int existingId))
			{
				aFormaPagamento.Id = existingId;
			}

			if (aFormaPagamento.Id > 0)
				aFormaPagamento.DtAlt = DateTime.Now;
			else
				aFormaPagamento.DtCriacao = DateTime.Now;

			if (btnSave.Text == "Salvar")
			{
				string resultado = aCtrlFormPag.Salvar(aFormaPagamento);

				if (int.TryParse(resultado, out int novoId))
				{
					txtCodigo.Text = novoId.ToString();
					MessageBox.Show($"Forma de pagamento '{aFormaPagamento.Descricao}' foi salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (btnSave.Text == "Excluir")
			{
				string resultado = aCtrlFormPag.Excluir(aFormaPagamento);

				if (resultado == "OK")
				{
					MessageBox.Show("Registro excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				} 
				else
				{
					MessageBox.Show($"Erro: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
