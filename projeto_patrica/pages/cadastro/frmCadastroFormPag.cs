using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using projeto_pratica.classes;

namespace projeto_pratica.pages.cadastro
{
	public partial class frmCadastroFormPag : projeto_pratica.pages.cadastro.frmCadastro
	{
		private formaPagamento aFormaPagamento;
		public frmCadastroFormPag()
		{
			InitializeComponent();
			aFormaPagamento = new formaPagamento();
		}

		public override void ConhecaObj(object obj)
		{
			base.ConhecaObj(obj);
		}

		public override void LimparTxt()
		{
			base.LimparTxt(); ;
			txtCodigo.Text = "0";
			txtDescricao.Clear();
		}
		public override void CarregarTxt()
		{
			base.CarregarTxt();
			txtCodigo.Text = Convert.ToString(aFormaPagamento.Id);
			txtDescricao.Text = aFormaPagamento.Descricao;
			
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
			if (int.TryParse(txtCodigo.Text, out int existingId) && existingId > 0)
			{
				aFormaPagamento.Id = existingId;
			}

			string resultado = formaPagamento.Salvar(aFormaPagamento);

			if (int.TryParse(resultado, out int novoId))
			{
				txtCodigo.Text = novoId.ToString();
				MessageBox.Show($"Forma de pagamento '{aFormaPagamento.Descricao}' foi salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

	}
}
