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
			txtCodigo.Text = "0";
			txtNome.Clear();
			txtApelido.Clear();
			txtEmail.Clear();
			txtEndereco.Clear();
			txtCep.Clear();
			txtBairro.Clear();
			txtCodCidade.Clear();
			txtCidade.Clear();
			txtCpf.Clear();
			txtRg.Clear();
			dtpDataNascimento.Value = DateTime.Now;
			txtTel.Clear();
			txtMatricula.Clear();
			txtCargo.Clear();
			txtSalBruto.Clear();
			txtSalLiquido.Clear();
			txtCargaHoraria.Clear();
			dtpDataAdmissao.Value = DateTime.Now;
			dtpDataDemissao.Value = DateTime.Now;	
			txtComple.Clear();
			txtEstado.Clear();
		}

		public override void Salvar()
		{
			base.Salvar();

			if (string.IsNullOrWhiteSpace(txtNome.Text))
			{
				MessageBox.Show("O campo Nome é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (string.IsNullOrWhiteSpace(txtCpf.Text) && (oFuncionario.OEndereco.ACidade?.OEstado?.OPais?.Nome == "Brasil"))
			{
				MessageBox.Show("O campo CPF é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
            }

            //validação de CPF E CNPJ
            if (IsCpf(txtCpf.Text) == false)
            {
                MessageBox.Show("CPF não é valido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
			{
				MessageBox.Show("O campo Email é obrigatório!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

            if (dtpDataNascimento.Value > DateTime.Now )
            {
                MessageBox.Show("Data Selecionada é invalida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("O e-mail informado não é válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oFuncionario.Tipo = 'F'; 
			oFuncionario.NomeRazaoSocial = txtNome.Text;
			oFuncionario.ApelidoFantasia = txtApelido.Text;
			oFuncionario.CpfCnpj = txtCpf.Text;
			oFuncionario.RgInscricaoEst = txtRg.Text;
			oFuncionario.Email = txtEmail.Text;
			oFuncionario.Telefone = txtTel.Text;
			oFuncionario.DataNascimento = dtpDataNascimento.Value;
			oFuncionario.Ativo = ckbStatus.Checked;
			oFuncionario.Matricula = txtMatricula.Text;
			oFuncionario.Cargo = txtCargo.Text;

			oFuncionario.SalarioBruto = double.TryParse(txtSalBruto.Text, out double salBruto) ? salBruto : 0;
			oFuncionario.SalarioLiquido = double.TryParse(txtSalLiquido.Text, out double salLiq) ? salLiq : 0;
			oFuncionario.CargaHoraria = int.TryParse(txtCargaHoraria.Text, out int carga) ? carga : 0;
			oFuncionario.DataAdmissao = dtpDataAdmissao.Value;
			oFuncionario.Turno = cbTurno.Text;

			oFuncionario.OEndereco.Endereco = txtEndereco.Text;
			oFuncionario.OEndereco.Bairro = txtBairro.Text;
			oFuncionario.OEndereco.Num = txtNum.Text;
			oFuncionario.OEndereco.Complemento = txtComple.Text;
			oFuncionario.OEndereco.Cep = txtCep.Text;
			oFuncionario.OEndereco.ACidade = new Cidade
			{
				Id = Convert.ToInt32(txtCodCidade.Text),
				Nome = txtCidade.Text
			};

			// Verifica se é edição
			if (int.TryParse(txtCodigo.Text, out int funcionarioId))
			{
				oFuncionario.Id = funcionarioId;
			}

			if (oFuncionario.Id > 0)
				oFuncionario.DtAlt = DateTime.Now;
			else
				oFuncionario.DtCriacao = DateTime.Now;

			if (btnSave.Text == "Salvar")
			{
				string resultado = aCtrlFuncionario.Salvar(oFuncionario);

				if (int.TryParse(resultado, out int novoId))
				{
					txtCodigo.Text = novoId.ToString();
					MessageBox.Show($"Funcionário '{oFuncionario.NomeRazaoSocial}' foi salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					Close();
				}
				else
				{
					MessageBox.Show($"Erro ao salvar: {resultado}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (btnSave.Text == "Excluir")
			{
				string resultado = aCtrlFuncionario.Excluir(oFuncionario);

				if (resultado == "OK")
				{
					MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			txtCodigo.Text = oFuncionario.Id.ToString();
			txtNome.Text = oFuncionario.NomeRazaoSocial;
			txtApelido.Text = oFuncionario.ApelidoFantasia;
			txtEmail.Text = oFuncionario.Email;
			txtEndereco.Text = oFuncionario.OEndereco.Endereco;
			txtCep.Text = oFuncionario.OEndereco.Cep;
			txtBairro.Text = oFuncionario.OEndereco.Bairro;
			txtCodCidade.Text = oFuncionario.OEndereco.ACidade.Id.ToString();
			txtCidade.Text = oFuncionario.OEndereco.ACidade.Nome;
			txtCpf.Text = oFuncionario.CpfCnpj;
			txtRg.Text = oFuncionario.RgInscricaoEst;
			dtpDataNascimento.Value = oFuncionario.DataNascimento;
			dtpDataAdmissao.Value = oFuncionario.DataAdmissao;
            if (oFuncionario.DataDemissao.HasValue)
            {
                // Se a data EXISTE, nós pegamos o valor real com .Value
                // e o atribuímos ao DateTimePicker.
                dtpDataDemissao.Value = oFuncionario.DataDemissao.Value;
                dtpDataDemissao.Enabled = true; // Opcional: Habilita o controle
            }
            else
            {
                // Se a data é NULL, não há valor para atribuir.
                // A melhor prática é desabilitar o controle visualmente.
                dtpDataDemissao.Enabled = false;

                // Opcional: você pode setar para a data de hoje para evitar erros, já que está desabilitado
                // dtpDataDemissao.Value = DateTime.Now; 
            }
            txtTel.Text = oFuncionario.Telefone;
			txtMatricula.Text = oFuncionario.Matricula;
			txtCargo.Text = oFuncionario.Cargo;
			txtSalBruto.Text = oFuncionario.SalarioBruto.ToString();
			txtSalLiquido.Text = oFuncionario.SalarioLiquido.ToString();
			txtCargaHoraria.Text = oFuncionario.CargaHoraria.ToString();
			txtDtAlt.Text = Convert.ToString(oFuncionario.DtAlt);
			txtDtCriacao.Text = Convert.ToString(oFuncionario.DtCriacao);
			cbTurno.Text = oFuncionario.Turno;
			txtEstado.Text = oFuncionario.OEndereco.ACidade.OEstado.Nome;
			txtComple.Text = oFuncionario.OEndereco.Complemento;
			txtNum.Text = oFuncionario.OEndereco.Num;

			dtpDataNascimento.Refresh();
			dtpDataAdmissao.Refresh();
			dtpDataDemissao.Refresh();
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
			dtpDataAdmissao.Enabled = false;
			txtTel.Enabled = false;
			txtMatricula.Enabled = false;
			txtCargo.Enabled = false;
			txtSalBruto.Enabled = false;
			txtSalLiquido.Enabled = false;
			txtCargaHoraria.Enabled = false;
			txtNum.Enabled = false;
			txtComple.Enabled = false;
			cbTurno.Enabled = false;

			btnPesquisarCidade.Enabled = false;

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
			dtpDataAdmissao.Enabled = true;
			txtTel.Enabled = true;
			txtMatricula.Enabled = true;
			txtCargo.Enabled = true;
			txtSalBruto.Enabled = true;
			txtSalLiquido.Enabled = true;
			txtCargaHoraria.Enabled = true;
			txtNum.Enabled = true;
			txtComple.Enabled = true;
			cbTurno.Enabled = true;

			btnPesquisarCidade.Enabled = true;
		}

		private void btnPesquisarCidade_Click(object sender, EventArgs e)
		{
			aFrmConCidade.ConhecaObj(oFuncionario.OEndereco.ACidade, aCtrlCidade);
			aFrmConCidade.ShowDialog();
			txtCodCidade.Text = Convert.ToString(oFuncionario.OEndereco.ACidade.Id);
			txtCidade.Text = oFuncionario.OEndereco.ACidade.Nome;
			txtEstado.Text = oFuncionario.OEndereco.ACidade.OEstado.Nome;

		}

		private void txtEmail_TextChanged(object sender, EventArgs e)
		{

		}

		private void frmCadastroFuncionario_Load(object sender, EventArgs e)
		{

		}

		private void lblTurno_Click(object sender, EventArgs e)
		{

		}

		private void lblCargo_Click(object sender, EventArgs e)
		{

		}

		private void lblSalLiquido_Click(object sender, EventArgs e)
		{

		}

		private void lblSalBruto_Click(object sender, EventArgs e)
		{

		}
	}
}


