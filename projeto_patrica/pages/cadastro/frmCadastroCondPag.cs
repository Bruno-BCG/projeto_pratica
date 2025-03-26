using projeto_pratica.classes;
using projeto_pratica.controllers;
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

		public frmCadastroCondpag()
		{
			InitializeComponent();
			oCondicaoPagamento = new CondicaoPagamento();
			aCtrlCondPag = new CtrlCondPag();
			aCtrlParcCondPag = new CtrlParcCondPag();
			aCtrlFormaPag = new CtrlFormPag();

			CarregarComboBoxFormaPag();
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			oCondicaoPagamento = (CondicaoPagamento)obj;
			aCtrlCondPag = (CtrlCondPag)ctrl;
			this.CarregarTxt();
			this.CarregaLV();
		}

		public override void LimparTxt()
		{
			base.LimparTxt();
			this.txtCodigo.Text = "0";
			this.txtDescricao.Clear();
			this.txtParcelas.Clear();

			this.txtCodFormPag.Clear();
			this.cbFormaPagamentos.SelectedIndex = -1;
			this.txtPrazo.Clear();
			this.txtNumParc.Clear();
			this.txtPercent.Clear();

			this.listV.Items.Clear(); 
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

			// Save CondicaoPagamento and get the generated ID
			string resultado = aCtrlCondPag.Salvar(oCondicaoPagamento);

			if (int.TryParse(resultado, out int novoId))
			{
				oCondicaoPagamento.Id = novoId; // Store the generated ID

				// Insert each ParcelaCondPag with the new CondicaoPagamento ID
				foreach (var parcela in oCondicaoPagamento.ParcelasCondPag)
				{
					parcela.CondPagId = novoId; // Assign the new ID to the parcela
					aCtrlParcCondPag.Salvar(parcela); // Save parcela to the database
				}

				txtCodigo.Text = novoId.ToString();
				MessageBox.Show($"A condição de pagamento '{oCondicaoPagamento.Descricao}' foi salva com o código {txtCodigo.Text}, e todas as parcelas foram cadastradas.",
					"Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				FormPagId = formaSelecionada.Id,
				FormPagDesc = formaSelecionada.Descricao
			};


			oCondicaoPagamento.ParcelasCondPag.Add(novaParcela);

			ListViewItem item = new ListViewItem(novaParcela.NumeroParcela.ToString());
			item.SubItems.Add(novaParcela.Prazo.ToString() + " dias");
			item.SubItems.Add(novaParcela.Percentual.ToString() + "%");
			item.SubItems.Add(novaParcela.FormPagDesc);
			item.Tag = novaParcela;
			listV.Items.Add(item);


			txtNumParc.Clear();
			txtPrazo.Clear();
			txtPercent.Clear();
			cbFormaPagamentos.SelectedIndex = -1;
			txtCodFormPag.Clear();
		}

		public void AlterarParcela()
		{
			
		}

		public void ExcluirParcela()
		{

		}

		public override void CarregarTxt()
		{
			base.CarregarTxt();
			this.txtCodigo.Text = oCondicaoPagamento.Id.ToString();
			this.txtDescricao.Text = oCondicaoPagamento.Descricao;
			this.txtParcelas.Text = oCondicaoPagamento.NumParcelas.ToString();

			CarregaLV(); 
		}

		public override void BloqueiaTxt()
		{
			base.BloqueiaTxt();
			this.txtCodigo.Enabled = false;
			this.txtDescricao.Enabled = false;
			this.txtParcelas.Enabled = false;
			this.btnAlterarFormPag.Enabled = false;
			this.btnExcluirFormPag.Enabled = false;
			this.btnCriarParc.Enabled = false;

			this.txtCodFormPag.Enabled = false;
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
			this.btnAlterarFormPag.Enabled = true;
			this.btnExcluirFormPag.Enabled = true;
			this.btnCriarParc.Enabled = true;

			this.txtCodFormPag.Enabled = true;
			this.cbFormaPagamentos.Enabled = true;
			this.txtPrazo.Enabled = true;
			this.txtNumParc.Enabled = true;
			this.txtPercent.Enabled = true;
		}

		public void CarregaLV() 
		{
			if (oCondicaoPagamento.Id == 0) return; 

			this.listV.Items.Clear();
			var lista = aCtrlParcCondPag.Listar(oCondicaoPagamento.Id);

			foreach (var parcela in lista)
			{
				ListViewItem item = new ListViewItem(parcela.NumeroParcela.ToString()); 
				item.SubItems.Add(parcela.Prazo.ToString() + " dias"); 
				item.SubItems.Add(parcela.Percentual.ToString() + "%"); 
				item.SubItems.Add(parcela.FormPagDesc);
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
				btnAlterarFormPag.Enabled = true;
				btnExcluirFormPag.Enabled = true;
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

			}
		}

		private void btnAlterarFormPag_Click(object sender, EventArgs e)
		{
			this.btnCriarParc.Text = "Salvar";
			this.btnCancel.Enabled = true;
			
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
				txtCodFormPag.Text = oParcelaCondPag.FormPagId.ToString();

				for (int i = 0; i < cbFormaPagamentos.Items.Count; i++)
				{
					FormaPagamento forma = (FormaPagamento)cbFormaPagamentos.Items[i];
					if (forma.Id == oParcelaCondPag.FormPagId)
					{
						cbFormaPagamentos.SelectedIndex = i;
						break;
					}
				}
			}

		}

		private void btnExcluirFormPag_Click(object sender, EventArgs e)
		{

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.btnCriarParc.Text = "Criar Parcela";
			this.btnCancel.Enabled = false;

			txtNumParc.Clear();
			txtPrazo.Clear();
			txtPercent.Clear();
			cbFormaPagamentos.SelectedIndex = -1;
			txtCodFormPag.Clear();
		}
	}
}