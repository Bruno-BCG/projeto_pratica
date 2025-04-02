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

namespace projeto_pratica.pages.cadastro
{
	public partial class frmCadastroFuncionario : projeto_pratica.pages.cadastro.frmCadastroPessoa
	{
		private Funcionario oFuncionario;
		private CtrlFuncionario aCtrlFuncionario;
		private CtrlCidade aCtrlCidade;
		private frmConsultaCidade aFrmConCidade;
		public frmCadastroFuncionario()
		{
			InitializeComponent();
			oFuncionario = new Funcionario();
			aCtrlFuncionario = new CtrlFuncionario();
			aCtrlCidade = new CtrlCidade();


		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			oFuncionario = (Funcionario)obj;
			aCtrlFuncionario = (CtrlFuncionario)ctrl;
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
		}

		public override void Salvar()
		{
			base.Salvar();

			// Validação dos campos obrigatórios
			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				MessageBox.Show("O campo Nome é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(txtCpf.Text))
			{
				MessageBox.Show("O campo CPF é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				MessageBox.Show("O campo Email é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Preenchimento do objeto oFuncionario com os dados do formulário
			oFuncionario.Nome_razaoSocial = txtNome.Text;
			oFuncionario.Apelido_nomeFanta = txtApelido.Text;
			oFuncionario.Cpf_cnpj = txtCpf.Text;
			oFuncionario.Rg_inscricaoNum = txtRg.Text;
			oFuncionario.Email = txtEmail.Text;
			oFuncionario.Telefone = txtTel.Text;
			oFuncionario.DataNascimento = dtpDataNascimento.Value;

			// Preenchimento do endereço
			oFuncionario.OEndereco.EnderecoCompleto = txtEndereco.Text;
			oFuncionario.OEndereco.Bairro = txtBairro.Text;
			oFuncionario.OEndereco.Cep = txtCep.Text;
			oFuncionario.OEndereco.ACidade = new Cidade
			{
				Id = int.TryParse(txtCodCidade.Text, out int cidadeId) ? cidadeId : 0,
				Nome = txtCidade.Text
			};

			// Verifica se é uma atualização ou inserção
			if (int.TryParse(txtCodigo.Text, out int funcionarioId) && funcionarioId > 0)
			{
				oFuncionario.Id = funcionarioId;
			}

			// Chamada ao controlador para salvar o funcionário
			string resultado = aCtrlFuncionario.Salvar(oFuncionario);

			if (int.TryParse(resultado, out int novoId))
			{
				txtCodigo.Text = novoId.ToString();
				MessageBox.Show($"Funcionário '{oFuncionario.Nome_razaoSocial}' foi salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public override void CarregarTxt()
		{
			base.CarregarTxt();
			txtCodigo.Text = oFuncionario.Id.ToString();
			txtNome.Text = oFuncionario.Nome_razaoSocial;
			txtApelido.Text = oFuncionario.Apelido_nomeFanta;
			txtEmail.Text = oFuncionario.Email;
			txtEndereco.Text = oFuncionario.OEndereco.EnderecoCompleto;
			txtCep.Text = oFuncionario.OEndereco.Cep;	
			txtBairro.Text = oFuncionario.OEndereco.Bairro;
			txtCodCidade.Text = oFuncionario.OEndereco.ACidade.Id.ToString();
			txtCidade.Text = oFuncionario.OEndereco.ACidade.Nome;
			txtCpf.Text = oFuncionario.Cpf_cnpj;
			txtRg.Text = oFuncionario.Rg_inscricaoNum;
			dtpDataNascimento.Value = oFuncionario.DataNascimento;
			txtTel.Text = oFuncionario.Telefone;
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
		}

		private void btnPesquisarCidade_Click(object sender, EventArgs e)
		{
			aFrmConCidade.ConhecaObj(oFuncionario.OEndereco.ACidade, aCtrlCidade);
			aFrmConCidade.ShowDialog();
			txtCodCidade.Text = Convert.ToString(oFuncionario.OEndereco.ACidade.Id);
			txtCidade.Text = oFuncionario.OEndereco.ACidade.Nome;

		}
	}
}


