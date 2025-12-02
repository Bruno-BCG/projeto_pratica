using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.daos;
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
	public partial class frmCadastroFornecedor : projeto_pratica.pages.cadastro.frmCadastroPessoa
	{
		private Fornecedor oFornecedor;
		private CtrlFornecedor aCtrlFornecedor;
		private CtrlCidade aCtrlCidade;
		private CtrlCondPag aCtrlCondPag;
		private frmConsultaCidade aFrmConCidade;
		private frmConsultaCondPag aFrmConCondPag;

		public frmCadastroFornecedor()
		{
			InitializeComponent();
			oFornecedor = new Fornecedor();
			aCtrlFornecedor =  new CtrlFornecedor();
			aCtrlCidade = new CtrlCidade();
			aCtrlCondPag = new CtrlCondPag();
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
		public void setFrmConsultaCondPag(object obj)
		{
			aFrmConCondPag = (frmConsultaCondPag)obj;
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

			this.txtNum.Clear();
			this.txtComple.Clear();
			this.txtCondPag.Clear();
			this.txtEstado.Clear();
			this.txtLimiteCredito.Clear();
		}
		public override void Salvar()
		{
			base.Salvar();

			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				MessageBox.Show("O campo Nome/Razão Social é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(txtCpf.Text) && (oFornecedor.OEndereco.ACidade.OEstado.OPais.Nome == "Brasil"))
			{
				MessageBox.Show("O campo CPF/CNPJ é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

            //validação de CPF E CNPJ
            if (rbtnFisica.Checked)
            {
                if (IsCpf(txtCpf.Text) == false)
                {
                    MessageBox.Show("CPF não é valido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (rbtnJuridico.Checked)
            {
                if (IsCnpj(txtCpf.Text) == false)
                {
                    MessageBox.Show("CNPJ não é valido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				MessageBox.Show("O campo Email é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

            if (dtpDataNascimento.Value > DateTime.Now)
            {
                MessageBox.Show("Data Selecionada é invalida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("O e-mail informado não é válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCondPag.Text))
            {
                MessageBox.Show("O campo Condição de Pagamento é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oFornecedor.Tipo = rbtnFisica.Checked ? 'F' : 'J';

			oFornecedor.NomeRazaoSocial = txtNome.Text;
			oFornecedor.ApelidoFantasia = txtApelido.Text;
			oFornecedor.CpfCnpj = txtCpf.Text;
			oFornecedor.RgInscricaoEst = txtRg.Text;
			oFornecedor.Email = txtEmail.Text;
			oFornecedor.Telefone = txtTel.Text;
			oFornecedor.DataNascimento = dtpDataNascimento.Value;
			oFornecedor.LimiteCredito = Convert.ToDouble(txtLimiteCredito.Text);
			oFornecedor.Ativo = ckbStatus.Checked;

			oFornecedor.OEndereco.Endereco = txtEndereco.Text;
			oFornecedor.OEndereco.Bairro = txtBairro.Text;
			oFornecedor.OEndereco.Num = txtNum.Text;
			oFornecedor.OEndereco.Complemento = txtComple.Text;
			oFornecedor.OEndereco.Cep = txtCep.Text;
			oFornecedor.OEndereco.ACidade = new Cidade
			{
				Id = int.TryParse(txtCodCidade.Text, out int cidadeId) ? cidadeId : 0,
				Nome = txtCidade.Text
			};

			if (int.TryParse(txtCodigo.Text, out int fornecedorId))
			{
				oFornecedor.Id = fornecedorId;
			}

			// Define as datas
			if (oFornecedor.Id > 0)
				oFornecedor.DtAlt = DateTime.Now;
			else
				oFornecedor.DtCriacao = DateTime.Now;

			// Salvar ou excluir
			if (btnSave.Text == "Salvar")
			{
				string resultado = aCtrlFornecedor.Salvar(oFornecedor);

				if (int.TryParse(resultado, out int novoId))
				{
					txtCodigo.Text = novoId.ToString();
					MessageBox.Show($"Fornecedor '{oFornecedor.NomeRazaoSocial}' foi salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (btnSave.Text == "Excluir")
			{
				string resultado = aCtrlFornecedor.Excluir(oFornecedor);

				if (resultado == "OK")
				{
					MessageBox.Show("Fornecedor excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			txtCodigo.Text = oFornecedor.Id.ToString();
			txtNome.Text = oFornecedor.NomeRazaoSocial;
			txtApelido.Text = oFornecedor.ApelidoFantasia;
			txtEmail.Text = oFornecedor.Email;
			txtEndereco.Text = oFornecedor.OEndereco.Endereco;
			txtCep.Text = oFornecedor.OEndereco.Cep;
			txtBairro.Text = oFornecedor.OEndereco.Bairro;
			txtCodCidade.Text = oFornecedor.OEndereco.ACidade.Id.ToString();
			txtCidade.Text = oFornecedor.OEndereco.ACidade.Nome;
			txtCpf.Text = oFornecedor.CpfCnpj;
			txtRg.Text = oFornecedor.RgInscricaoEst;
			dtpDataNascimento.Value = oFornecedor.DataNascimento;
			txtTel.Text = oFornecedor.Telefone;
			txtDtAlt.Text = Convert.ToString(oFornecedor.DtAlt);
			txtDtCriacao.Text = Convert.ToString(oFornecedor.DtCriacao);
			txtComple.Text = oFornecedor.OEndereco.Complemento;
			txtNum.Text = Convert.ToString(oFornecedor.OEndereco.Num);
			txtEstado.Text = oFornecedor.OEndereco.ACidade.OEstado.Nome;
			txtCondPag.Text = oFornecedor.ACondPag.Descricao;
			txtLimiteCredito.Text = Convert.ToString(oFornecedor.LimiteCredito);

			rbtnFisica.Enabled = false;
			rbtnJuridico.Enabled = false;

            dtpDataNascimento.Refresh();
        }

		public override void BloqueiaTxt()
		{
			txtCodigo.Enabled = false;
			txtNome.Enabled = false;
			txtApelido.Enabled = false;
			txtEmail.Enabled = false;
			txtEndereco.Enabled = false;
			txtNum.Enabled = false;
			txtComple.Enabled = false;
			txtCep.Enabled = false;
			txtBairro.Enabled = false;
			txtCpf.Enabled = false;
			txtRg.Enabled = false;
			dtpDataNascimento.Enabled = false;
			txtTel.Enabled = false;
			txtCondPag.Enabled = false;
			txtLimiteCredito.Enabled = false;

			btnPesquisarCidade.Enabled = false;
			btnPesquisarCondPag.Enabled = false;

			rbtnFisica.Enabled = false;
			rbtnJuridico.Enabled = false;
		}

		public override void DesbloqueiaTxt()
		{
			base.DesbloqueiaTxt();
			txtCodigo.Enabled = true;
			txtNome.Enabled = true;
			txtApelido.Enabled = true;
			txtEmail.Enabled = true;
			txtEndereco.Enabled = true;
			txtNum.Enabled = true;
			txtComple.Enabled = true;
			txtCep.Enabled = true;
			txtBairro.Enabled = true;
			txtCpf.Enabled = true;
			txtRg.Enabled = true;
			dtpDataNascimento.Enabled = true;
			txtTel.Enabled = true;
			txtCondPag.Enabled = true;
			txtLimiteCredito.Enabled = true;

			btnPesquisarCidade.Enabled = true;
			btnPesquisarCondPag.Enabled = true;

			rbtnFisica.Enabled = true;
			rbtnJuridico.Enabled = true;
		}

		private void btnPesquisarCidade_Click(object sender, EventArgs e)
		{
			aFrmConCidade.ConhecaObj(oFornecedor.OEndereco.ACidade, aCtrlCidade);
			aFrmConCidade.ShowDialog();
			txtCodCidade.Text = oFornecedor.OEndereco.ACidade.Id.ToString();
			txtCidade.Text = oFornecedor.OEndereco.ACidade.Nome;
			txtEstado.Text = oFornecedor.OEndereco.ACidade.OEstado.Nome;
		}

		private void rbtnFisicaqqq_CheckedChanged(object sender, EventArgs e)
		{
			lblApelido.Text = "Apelido";
			lblCPF.Text = "CPF";
			txtCpf.MaxLength = 11;
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
			lblApelido.Text = "Nome Fantasia";
			lblCPF.Text = "CNPJ";
            txtCpf.MaxLength = 14;
            lblRG.Text = "Inscrição Estadual";
			lblDtNascimento.Text = "Data Criação";

			this.txtNome.Clear();
			this.txtApelido.Clear();
			this.txtCpf.Clear();
			this.txtRg.Clear();
			this.dtpDataNascimento.Value = DateTime.Now;
		}

		private void lblPesquisarCondPag_Click(object sender, EventArgs e)
		{
			aFrmConCondPag.ConhecaObj(oFornecedor.ACondPag, aCtrlCondPag);
			aFrmConCondPag.ShowDialog();
			txtCondPag.Text = oFornecedor.ACondPag.Descricao;
			
		}

        private void dtpDataNascimento_ValueChanged(object sender, EventArgs e)
        {
            this.dtpDataNascimento.ValueChanged -= dtpDataNascimento_ValueChanged;

            if (dtpDataNascimento.Value > DateTime.Now)
            {
                dtpDataNascimento.Value = DateTime.Now;
            }

            this.dtpDataNascimento.ValueChanged += dtpDataNascimento_ValueChanged;
        }
    }
}
