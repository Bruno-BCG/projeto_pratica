using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.consulta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projeto_pratica.pages.cadastro
{
	public partial class frmCadastroCondpag : projeto_pratica.pages.cadastro.frmCadastro
	{
		private CondicaoPagamento oCondicaoPagamento;
		private CtrlCondPag aCtrlCondPag;
		private ParcelaCondPag oParcelaCondPag;
		private CtrlParcCondPag aCtrlParcCondPag;
		private CtrlFormPag aCtrlFormaPag;
		private frmConsultaFormPag aFormConsultaFormPag;
		private List<ParcelaCondPag> parcelasRemovidas = new List<ParcelaCondPag>();

		public frmCadastroCondpag()
		{
			InitializeComponent();
			oCondicaoPagamento = new CondicaoPagamento();
			oParcelaCondPag = new ParcelaCondPag();
			aCtrlCondPag = new CtrlCondPag();
			aCtrlParcCondPag = new CtrlParcCondPag();
			aCtrlFormaPag = new CtrlFormPag();
			aFormConsultaFormPag = new frmConsultaFormPag();
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			oCondicaoPagamento = (CondicaoPagamento)obj;
			aCtrlCondPag = (CtrlCondPag)ctrl;
			CarregarComboBoxFormaPag();
			this.CarregaLV();
		}

		public void setFrmConsultaFormPag(object obj)
		{
			aFormConsultaFormPag = (frmConsultaFormPag)obj;
		}

		public override void LimparTxt()
		{
			base.LimparTxt();
			this.txtCodigo.Text = "0";
			this.txtDescricao.Clear();
			this.txtParcelas.Clear();
			this.txtJuro.Clear();
			this.txtMulta.Clear();
			this.txtDesconto.Clear();


			this.txtCodFormPag.Clear();
			this.cbFormaPagamentos.SelectedIndex = -1;
			this.txtPrazo.Clear();
			this.txtNumParc.Clear();
			this.txtPercent.Clear();

			this.listV.Items.Clear();
		}

		public void LimparTxtParcela()
		{
			txtNumParc.Clear();
			txtPrazo.Clear();
			txtPercent.Clear();
			cbFormaPagamentos.SelectedIndex = -1;
			txtCodFormPag.Clear();

		}

		public override void Salvar()
		{
			base.Salvar();

			if (string.IsNullOrWhiteSpace(txtDescricao.Text) || string.IsNullOrWhiteSpace(txtParcelas.Text) || string.IsNullOrWhiteSpace(txtJuro.Text) || string.IsNullOrWhiteSpace(txtMulta.Text) || string.IsNullOrWhiteSpace(txtDesconto.Text) || string.IsNullOrWhiteSpace(txtParcelas.Text))
			{
				MessageBox.Show("Campo obrigatório não preenchido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

            // Soma dos percentuais das parcelas
            decimal somaPercentuais = 0;
            foreach (var p in oCondicaoPagamento.ParcelasCondPag)
                somaPercentuais += p.Percentual;

            decimal desconto = Convert.ToDecimal(txtDesconto.Text);
            decimal totalEsperado = 100 - desconto;

            if (Math.Round(somaPercentuais, 2) != Math.Round(totalEsperado, 2))
            {
                MessageBox.Show(
                    $"A soma dos percentuais das parcelas ({somaPercentuais:F2}%) deve ser igual a {totalEsperado:F2}%.",
                    "Erro de Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            oCondicaoPagamento.Descricao = txtDescricao.Text;
			oCondicaoPagamento.NumParcelas = Convert.ToInt32(txtParcelas.Text);
			oCondicaoPagamento.Juro = Convert.ToDouble(txtJuro.Text);
			oCondicaoPagamento.Multa = Convert.ToDouble(txtMulta.Text);
			oCondicaoPagamento.Desconto = Convert.ToDouble(txtDesconto.Text);


			if (int.TryParse(txtCodigo.Text, out int condPagId))
			{
				oCondicaoPagamento.Id = condPagId;
			}
			if (oCondicaoPagamento.Id > 0)
				oCondicaoPagamento.DtAlt = DateTime.Now;
			else
				oCondicaoPagamento.DtCriacao = DateTime.Now;

			if (btnSave.Text == "Salvar")
			{
				string resultado = aCtrlCondPag.Salvar(oCondicaoPagamento);

				if (int.TryParse(resultado, out int novoId))
				{
					oCondicaoPagamento.Id = novoId;

					foreach (var parcela in oCondicaoPagamento.ParcelasCondPag)
					{
						parcela.CondPagId = novoId;
						aCtrlParcCondPag.Salvar(parcela);
					}

					foreach (var parcelaRemovida in parcelasRemovidas)
					{
						aCtrlParcCondPag.Excluir(parcelaRemovida);
					}

					parcelasRemovidas.Clear();

					txtCodigo.Text = novoId.ToString();
					MessageBox.Show($"A condição de pagamento '{oCondicaoPagamento.Descricao}' foi salva com o código {txtCodigo.Text}, e todas as parcelas foram cadastradas.",
						"Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (btnSave.Text == "Excluir")
			{
				string resultado = aCtrlCondPag.Excluir(oCondicaoPagamento);

				if (resultado == "OK")
				{
					MessageBox.Show("Condição de pagamento excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show($"Erro ao excluir: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public void CriarParcela()
		{

			if (string.IsNullOrWhiteSpace(txtNumParc.Text) ||
				string.IsNullOrWhiteSpace(txtPrazo.Text) ||
				string.IsNullOrWhiteSpace(txtPercent.Text) ||
				cbFormaPagamentos.SelectedItem == null)
			{
				MessageBox.Show("Preencha todos os campos da parcela antes de adicionar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}


			int numParcela = Convert.ToInt32(txtNumParc.Text);
			int prazo = Convert.ToInt32(txtPrazo.Text);
			decimal percentual = Convert.ToDecimal(txtPercent.Text);
			FormaPagamento formaSelecionada = (FormaPagamento)cbFormaPagamentos.SelectedItem;


			ParcelaCondPag novaParcela = new ParcelaCondPag
			{
				NumeroParcela = numParcela,
				Prazo = prazo,
				Percentual = percentual,
				Ativo = true,
				DtCriacao = DateTime.Now,
				AFormPag = new FormaPagamento 
				{
					Id = formaSelecionada.Id,
					Descricao = formaSelecionada.Descricao
				}

			};


			oCondicaoPagamento.ParcelasCondPag.Add(novaParcela);

			ListViewItem item = new ListViewItem(novaParcela.NumeroParcela.ToString());
			item.SubItems.Add(novaParcela.Prazo.ToString() + " dias");
			item.SubItems.Add(novaParcela.Percentual.ToString() + "%");
			item.SubItems.Add(novaParcela.AFormPag.Descricao);
			item.Tag = novaParcela;
			listV.Items.Add(item);
			LimparTxtParcela();
		}
		public void iniciarAlteracao()
		{
			this.btnCriarParc.Text = "Salvar";
			this.btnCancel.Enabled = true;
			this.btnAlterarParc.Enabled = false;
			this.btnExcluirParc.Enabled = false;

			if (listV.SelectedItems.Count == 0)
			{
				MessageBox.Show("Selecione uma parcela para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (oParcelaCondPag != null)
			{
				txtNumParc.Text = oParcelaCondPag.NumeroParcela.ToString();
				txtPrazo.Text = oParcelaCondPag.Prazo.ToString();
				txtPercent.Text = oParcelaCondPag.Percentual.ToString();
				txtCodFormPag.Text = oParcelaCondPag.AFormPag.Id.ToString();
				oParcelaCondPag.DtAlt = DateTime.Now;
				for (int i = 0; i < cbFormaPagamentos.Items.Count; i++)
				{
					FormaPagamento forma = (FormaPagamento)cbFormaPagamentos.Items[i];
					if (forma.Id == oParcelaCondPag.AFormPag.Id)
					{
						cbFormaPagamentos.SelectedIndex = i;
						break;
					}
				}
			}
		}

		public void iniciarExclusao ()
		{
			this.btnCriarParc.Text = "Excluir";
			this.btnCancel.Enabled = true;
			this.btnAlterarParc.Enabled = false;
			this.btnExcluirParc.Enabled = false;

			if (listV.SelectedItems.Count == 0)
			{
				MessageBox.Show("Selecione uma parcela para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (oParcelaCondPag != null)
			{
				txtNumParc.Text = oParcelaCondPag.NumeroParcela.ToString();
				txtPrazo.Text = oParcelaCondPag.Prazo.ToString();
				txtPercent.Text = oParcelaCondPag.Percentual.ToString();
				txtCodFormPag.Text = oParcelaCondPag.AFormPag.Id.ToString();

				for (int i = 0; i < cbFormaPagamentos.Items.Count; i++)
				{
					FormaPagamento forma = (FormaPagamento)cbFormaPagamentos.Items[i];
					if (forma.Id == oParcelaCondPag.AFormPag.Id)
					{
						cbFormaPagamentos.SelectedIndex = i;
						break;
					}
				}
			}
		}

		public void AlterarParcela()
		{
			if (oParcelaCondPag == null)
			{
				MessageBox.Show("Nenhuma parcela selecionada para alterar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(txtNumParc.Text) ||
				string.IsNullOrWhiteSpace(txtPrazo.Text) ||
				string.IsNullOrWhiteSpace(txtPercent.Text) ||
				cbFormaPagamentos.SelectedItem == null)
			{
				MessageBox.Show("Preencha todos os campos da parcela antes de salvar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (!int.TryParse(txtNumParc.Text, out int numParcela) ||
				!int.TryParse(txtPrazo.Text, out int prazo) ||
				!decimal.TryParse(txtPercent.Text, out decimal percentual))
			{
				MessageBox.Show("Valores inválidos nos campos da parcela.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			FormaPagamento formaSelecionada = (FormaPagamento)cbFormaPagamentos.SelectedItem;

			oParcelaCondPag.NumeroParcela = numParcela;
			oParcelaCondPag.Prazo = prazo;
			oParcelaCondPag.Percentual = percentual;
			oParcelaCondPag.AFormPag.Id = formaSelecionada.Id;
			oParcelaCondPag.AFormPag.Descricao = formaSelecionada.Descricao;

			int index = oCondicaoPagamento.ParcelasCondPag.IndexOf(oParcelaCondPag);
			if (index >= 0)
			{
				oCondicaoPagamento.ParcelasCondPag[index] = oParcelaCondPag;
			}

			CarregaLV();

			btnCriarParc.Text = "Criar Parcela";
			btnCancel.Enabled = false;
			this.btnAlterarParc.Enabled = true;
			this.btnExcluirParc.Enabled = true;
			LimparTxtParcela();
		}

		public void ExcluirParcela()
		{
			if (listV.SelectedItems.Count == 0)
			{
				MessageBox.Show("Selecione uma parcela para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ListViewItem selectedItem = listV.SelectedItems[0];
			ParcelaCondPag parcelaSelecionada = (ParcelaCondPag)selectedItem.Tag;

			if (MessageBox.Show("Deseja realmente excluir a parcela selecionada?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				oCondicaoPagamento.ParcelasCondPag.Remove(parcelaSelecionada);

				if (parcelaSelecionada.Id > 0)
				{
					parcelasRemovidas.Add(parcelaSelecionada);
				}

				CarregaLV();
				LimparTxtParcela();
				btnCriarParc.Text = "Criar Parcela";
				btnCancel.Enabled = false;
				this.btnAlterarParc.Enabled = true;
				this.btnExcluirParc.Enabled = true;
			}
		}

		public override void CarregarTxt()
		{
			base.CarregarTxt();
			this.txtCodigo.Text = oCondicaoPagamento.Id.ToString();
			this.txtDescricao.Text = oCondicaoPagamento.Descricao;
			this.txtParcelas.Text = oCondicaoPagamento.NumParcelas.ToString();

			this.txtJuro.Text = oCondicaoPagamento.Juro.ToString();
			this.txtMulta.Text = oCondicaoPagamento.Multa.ToString();
			this.txtDesconto.Text = oCondicaoPagamento.Desconto.ToString();
				
			this.txtDtCriacao.Text = oCondicaoPagamento.DtCriacao.ToString();
			this.txtDtAlt.Text = oCondicaoPagamento.DtAlt.ToString();

			CarregaLV();
		}

		public override void BloqueiaTxt()
		{
			base.BloqueiaTxt();
			this.txtCodigo.Enabled = false;
			this.txtDescricao.Enabled = false;
			this.txtParcelas.Enabled = false;
			this.txtJuro.Enabled = false;
			this.txtMulta.Enabled = false;
			this.txtDesconto.Enabled = false;
			this.btnAlterarParc.Enabled = false;
			this.btnExcluirParc.Enabled = false;
			this.btnCriarParc.Enabled = false;
			this.btnPesquisar.Enabled = false;
			this.listV.Enabled = false;	

			this.cbFormaPagamentos.Enabled = false;
			this.txtPrazo.Enabled = false;
			this.txtNumParc.Enabled = false;
			this.txtPercent.Enabled = false;
		}

		public override void DesbloqueiaTxt()
		{
			base.DesbloqueiaTxt();
			this.txtCodigo.Enabled = true;
			this.txtDescricao.Enabled = true;
			this.txtParcelas.Enabled = true;
			this.txtJuro.Enabled = true;
			this.txtMulta.Enabled = true;
			this.txtDesconto.Enabled = true;
			this.btnAlterarParc.Enabled = true;
			this.btnExcluirParc.Enabled = true;
			this.btnCriarParc.Enabled = true;
			this.btnPesquisar.Enabled = true;
			this.listV.Enabled = true;

			this.cbFormaPagamentos.Enabled = true;
			this.txtPrazo.Enabled = true;
			this.txtNumParc.Enabled = true;
			this.txtPercent.Enabled = true;
		}

		public void CarregaLV()
		{
			this.listV.Items.Clear();
			var lista = oCondicaoPagamento.ParcelasCondPag;

			foreach (var parcela in lista)
			{
				ListViewItem item = new ListViewItem(parcela.NumeroParcela.ToString());
				item.SubItems.Add(parcela.Prazo.ToString() + " dias");
				item.SubItems.Add(parcela.Percentual.ToString() + "%");
				item.SubItems.Add(parcela.AFormPag.Descricao);
				item.Tag = parcela;

				listV.Items.Add(item);
			}
		}
		private void CarregarComboBoxFormaPag()
		{
			cbFormaPagamentos.Items.Clear();
			cbFormaPagamentos.DisplayMember = "Descricao";
			cbFormaPagamentos.ValueMember = "Id";

			var listaFormas = aCtrlFormaPag.Listar();
			foreach (var forma in listaFormas)
			{
				cbFormaPagamentos.Items.Add(forma);
			}
		}

		private void cbFormaPagamentos_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbFormaPagamentos.SelectedItem is FormaPagamento formaSelecionada)
			{
				txtCodFormPag.Text = formaSelecionada.Id.ToString();
			}
		}
		private void listV_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listV.SelectedItems.Count > 0)
			{
				ListViewItem selectedItem = listV.SelectedItems[0];
				oParcelaCondPag = (ParcelaCondPag)selectedItem.Tag;

				// Enable buttons
				btnAlterarParc.Enabled = true;
				btnExcluirParc.Enabled = true;
			}
		}

		private void btnCriarParc_Click(object sender, EventArgs e)
		{
			if (btnCriarParc.Text == "Criar Parcela")
			{
				CriarParcela();
			}
			else if (btnCriarParc.Text == "Salvar")
			{
				AlterarParcela();
			}
			else if (btnCriarParc.Text == "Excluir")
			{
				ExcluirParcela();
			}
		}

		private void btnAlterarFormPag_Click(object sender, EventArgs e)
		{
			iniciarAlteracao();
		}

		private void btnExcluirFormPag_Click(object sender, EventArgs e)
		{
			iniciarExclusao();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.btnCriarParc.Text = "Criar Parcela";
			this.btnCancel.Enabled = false;

			LimparTxtParcela();
		}

		private void frmCadastroCondpag_Load(object sender, EventArgs e)
		{

		}

		private void btnPesquisar_Click(object sender, EventArgs e)
		{
			CtrlFormPag aCtrlFormPag = new CtrlFormPag();

			if (oParcelaCondPag.AFormPag == null)
				oParcelaCondPag.AFormPag = new FormaPagamento();

			aFormConsultaFormPag.ConhecaObj(oParcelaCondPag.AFormPag, aCtrlFormPag);
			aFormConsultaFormPag.ShowDialog();

			CarregarComboBoxFormaPag();

			txtCodFormPag.Text = oParcelaCondPag.AFormPag.Id.ToString();

			for (int i = 0; i < cbFormaPagamentos.Items.Count; i++)
			{
				var forma = (FormaPagamento)cbFormaPagamentos.Items[i];
				if (forma.Id == oParcelaCondPag.AFormPag.Id)
				{
					cbFormaPagamentos.SelectedIndex = i;
					break;
				}
			}
		}
	}
}