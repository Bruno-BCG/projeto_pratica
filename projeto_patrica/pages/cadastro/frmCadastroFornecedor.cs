using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.cadastro
{
	public partial class frmCadastroFornecedor : projeto_pratica.pages.cadastro.frmCadastroPessoa
	{
		private Fornecedor oFornecedor;
		private CtrlFornecedor aCtrlFornecedor;
		private CtrlCidade aCtrlCidade;
		private frmConsultaCidade aFrmConCidade;


		public frmCadastroFornecedor()
		{
			InitializeComponent();
			oFornecedor = new Fornecedor();
			aCtrlFornecedor =  new CtrlFornecedor();
			aCtrlCidade = new CtrlCidade();
		}
		public override void ConhecaObj(object obj, object ctrl)
		{
			oFornecedor = (Fornecedor)obj;
			aCtrlFornecedor = (CtrlFornecedor)ctrl;
		}
		public void setFrmConsultaCidade(object obj)
		{
			aFrmConCidade = (frmConsultaCidade)obj;
		}


		public override void LimparTxt()
		{
			base.LimparTxt();
			this.txtCodigo.Text = "0";
			this.txtNome.Clear();
			this.txtApelido.Clear();
			this.txtEmail.Clear();
			this.txtEndereco.Clear();
			this.txtCep.Clear();
			this.txtBairro.Clear();
			this.txtCodCidade.Clear();
			this.txtCidade.Clear();
			this.txtCpf.Clear();
			this.txtRg.Clear();
			this.dtpDataNascimento.Value = DateTime.Now;
			this.txtTel.Clear();
			this.txtInscEst.Clear();
		}
		public override void Salvar()
		{
			base.Salvar();

			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				MessageBox.Show("O campo Nome/Razão Social é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (rbtnFisicaqqq.Checked)
				oFornecedor.Tipo = "F";
			else if (rbtnJuridico.Checked)
				oFornecedor.Tipo = "J";

			oFornecedor.Nome_razaoSocial = txtNome.Text;
			oFornecedor.Apelido_nomeFanta = txtApelido.Text;
			oFornecedor.Cpf_cnpj = txtCpf.Text;
			oFornecedor.Rg_inscricaoNum = txtRg.Text;
			oFornecedor.Email = txtEmail.Text;
			oFornecedor.Telefone = txtTel.Text;
			oFornecedor.DataNascimento = dtpDataNascimento.Value;
			oFornecedor.Status = ckbStatus.Checked;
			oFornecedor.Estrangeiro = false;
			oFornecedor.InscrEstadual = txtInscEst.Text;

			oFornecedor.OEndereco.EnderecoCompleto = txtEndereco.Text;
			oFornecedor.OEndereco.Bairro = txtBairro.Text;
			oFornecedor.OEndereco.Cep = txtCep.Text;
			oFornecedor.OEndereco.ACidade = new Cidade
			{
				Id = int.TryParse(txtCodCidade.Text, out int idCidade) ? idCidade : 0,
				Nome = txtCidade.Text
			};

			if (int.TryParse(txtCodigo.Text, out int id) && id > 0)
				oFornecedor.Id = id;

			if (btnSave.Text == "Salvar")
			{
				string resultado = aCtrlFornecedor.Salvar(oFornecedor);

				if (int.TryParse(resultado, out int novoId))
				{
					txtCodigo.Text = novoId.ToString();
					MessageBox.Show("Fornecedor salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Erro ao salvar: " + resultado, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (btnSave.Text == "Excluir")
			{
				string resultado = aCtrlFornecedor.Excluir(oFornecedor);

				if (resultado == "OK")
				{
					MessageBox.Show("Fornecedor excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Erro ao excluir: " + resultado, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public override void CarregarTxt()
		{
			base.CarregarTxt();
			txtCodigo.Text = oFornecedor.Id.ToString();
			txtNome.Text = oFornecedor.Nome_razaoSocial;
			txtApelido.Text = oFornecedor.Apelido_nomeFanta;
			txtEmail.Text = oFornecedor.Email;
			txtEndereco.Text = oFornecedor.OEndereco.EnderecoCompleto;
			txtCep.Text = oFornecedor.OEndereco.Cep;
			txtBairro.Text = oFornecedor.OEndereco.Bairro;
			txtCodCidade.Text = oFornecedor.OEndereco.ACidade.Id.ToString();
			txtCidade.Text = oFornecedor.OEndereco.ACidade.Nome;
			txtCpf.Text = oFornecedor.Cpf_cnpj;
			txtRg.Text = oFornecedor.Rg_inscricaoNum;
			dtpDataNascimento.Value = oFornecedor.DataNascimento;
			txtTel.Text = oFornecedor.Telefone;
			txtInscEst.Text = oFornecedor.InscrEstadual;
			ckbStatus.Checked = oFornecedor.Status;
		}

		public override void BloqueiaTxt()
		{
			base.BloqueiaTxt();
			txtCodigo.Enabled = false;
			txtNome.Enabled = false;
			txtApelido.Enabled = false;
			txtEmail.Enabled = false;
			txtEndereco.Enabled = false;
			txtCep.Enabled = false;
			txtBairro.Enabled = false;
			txtCodCidade.Enabled = false;
			txtCidade.Enabled = false;
			txtCpf.Enabled = false;
			txtRg.Enabled = false;
			dtpDataNascimento.Enabled = false;
			txtTel.Enabled = false;
			txtInscEst.Enabled = false;
		}

		public override void DesbloqueiaTxt()
		{
			base.DesbloqueiaTxt();
			txtCodigo.Enabled = true;
			txtNome.Enabled = true;
			txtApelido.Enabled = true;
			txtEmail.Enabled = true;
			txtEndereco.Enabled = true;
			txtCep.Enabled = true;
			txtBairro.Enabled = true;
			txtCodCidade.Enabled = true;
			txtCidade.Enabled = true;
			txtCpf.Enabled = true;
			txtRg.Enabled = true;
			dtpDataNascimento.Enabled = true;
			txtTel.Enabled = true;
			txtInscEst.Enabled = true;
		}

		private void btnPesquisarCidade_Click(object sender, EventArgs e)
		{
			aFrmConCidade.ConhecaObj(oFornecedor.OEndereco.ACidade, aCtrlCidade);
			aFrmConCidade.ShowDialog();
			txtCodCidade.Text = oFornecedor.OEndereco.ACidade.Id.ToString();
			txtCidade.Text = oFornecedor.OEndereco.ACidade.Nome;

			oFornecedor.Estrangeiro = oFornecedor.OEndereco.ACidade.OEstado.OPais.Nome != "Brasil";
		}

		private void rbtnFisicaqqq_CheckedChanged(object sender, EventArgs e)
		{
			lblNome.Text = "Nome";
			lblApelido.Text = "Apelido";
			lblCPF.Text = "CPF";
			lblRG.Text = "RG";
			lblDtNascimento.Text = "Data de Nacimento";
			txtInscEst.Enabled = false;

			this.txtNome.Clear();
			this.txtApelido.Clear();
			this.txtCpf.Clear();
			this.txtRg.Clear();
			this.dtpDataNascimento.Value = DateTime.Now;
		}

		private void rbtnJuridico_CheckedChanged(object sender, EventArgs e)
		{
			lblNome.Text = "Razao Social";
			lblApelido.Text = "Nome Fantasia";
			lblCPF.Text = "CNPJ";
			lblRG.Text = "Inscrição Municipal";
			lblDtNascimento.Text = "Data Criação";
			txtInscEst.Enabled = true;

			this.txtNome.Clear();
			this.txtApelido.Clear();
			this.txtCpf.Clear();
			this.txtRg.Clear();
			this.dtpDataNascimento.Value = DateTime.Now;
		}
	}
}
