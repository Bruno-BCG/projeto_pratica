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
	public partial class frmCadastroCliente : projeto_pratica.pages.cadastro.frmCadastroPessoa
	{
		private Cliente oCliente;
		private CtrlCliente aCtrlCliente;
		private CtrlCidade aCtrlCidade;
		private frmConsultaCidade aFrmConCidade;
		public frmCadastroCliente()
		{
			InitializeComponent();
			oCliente = new Cliente();
			aCtrlCliente = new CtrlCliente();
			aCtrlCidade = new CtrlCidade();
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			oCliente = (Cliente)obj;
			aCtrlCliente = (CtrlCliente)ctrl;
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

			if ((string.IsNullOrWhiteSpace(txtCpf.Text)) && (oCliente.Estrangeiro != true)) 
			{
				MessageBox.Show("O campo CPF/CNPJ é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				MessageBox.Show("O campo Email é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Preenchimento do objeto oCliente com os dados do formulário
			if (rbtnFisicaqqq.Checked)
			{ 
				oCliente.Tipo = "F";
			}
            else if (rbtnJuridico.Checked) 
            {
				oCliente.Tipo = "J";
            }

            oCliente.Nome_razaoSocial = txtNome.Text;
			oCliente.Apelido_nomeFanta = txtApelido.Text;
			oCliente.Cpf_cnpj = txtCpf.Text;
			oCliente.Rg_inscricaoNum = txtRg.Text;
			oCliente.Email = txtEmail.Text;
			oCliente.Telefone = txtTel.Text;
			oCliente.DataNascimento = dtpDataNascimento.Value;
			oCliente.Status = ckbStatus.Checked;



			// Preenchimento do endereço
			oCliente.OEndereco.EnderecoCompleto = txtEndereco.Text;
			oCliente.OEndereco.Bairro = txtBairro.Text;
			oCliente.OEndereco.Cep = txtCep.Text;
			oCliente.OEndereco.ACidade = new Cidade
			{
				Id = int.TryParse(txtCodCidade.Text, out int cidadeId) ? cidadeId : 0,
				Nome = txtCidade.Text
			};

			// Verifica se é uma atualização ou inserção
			if (int.TryParse(txtCodigo.Text, out int clienteId) && clienteId > 0)
			{
				oCliente.Id = clienteId;
			}

			// Chamada ao controlador para salvar o cliente
			string resultado = aCtrlCliente.Salvar(oCliente);

			if (int.TryParse(resultado, out int novoId))
			{
				txtCodigo.Text = novoId.ToString();
				MessageBox.Show($"Cliente '{oCliente.Nome_razaoSocial}' foi salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public override void CarregarTxt()
		{
			base.CarregarTxt();
			txtCodigo.Text = oCliente.Id.ToString();
			txtNome.Text = oCliente.Nome_razaoSocial;
			txtApelido.Text = oCliente.Apelido_nomeFanta;
			txtEmail.Text = oCliente.Email;
			txtEndereco.Text = oCliente.OEndereco.EnderecoCompleto;
			txtCep.Text = oCliente.OEndereco.Cep;
			txtBairro.Text = oCliente.OEndereco.Bairro;
			txtCodCidade.Text = oCliente.OEndereco.ACidade.Id.ToString();
			txtCidade.Text = oCliente.OEndereco.ACidade.Nome;
			txtCpf.Text = oCliente.Cpf_cnpj;
			txtRg.Text = oCliente.Rg_inscricaoNum;
			dtpDataNascimento.Value = oCliente.DataNascimento;
			txtTel.Text = oCliente.Telefone;
			
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
			aFrmConCidade.ConhecaObj(oCliente.OEndereco.ACidade, aCtrlCidade);
			aFrmConCidade.ShowDialog();
			txtCodCidade.Text = Convert.ToString(oCliente.OEndereco.ACidade.Id);
			txtCidade.Text = oCliente.OEndereco.ACidade.Nome;
			if (oCliente.OEndereco.ACidade.OEstado.OPais.Nome != "Brasil")
			{
				oCliente.Estrangeiro = true;
			}
			else
			{
				oCliente.Estrangeiro = false;
			}
		}

		private void rbtnFisicaqqq_CheckedChanged(object sender, EventArgs e)
		{
			lblNome.Text = "Nome";
			lblApelido.Text = "Apelido";
			lblCPF.Text = "CPF";
			lblRG.Text = "RG";
			lblDtNascimento.Text = "Data de Nacimento";

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

			this.txtNome.Clear();
			this.txtApelido.Clear();
			this.txtCpf.Clear();
			this.txtRg.Clear();
			this.dtpDataNascimento.Value = DateTime.Now;
		}

	}
}
