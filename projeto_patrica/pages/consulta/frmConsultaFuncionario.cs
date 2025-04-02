using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.consulta
{
	public partial class frmConsultaFuncionario : projeto_pratica.pages.consulta.frmConsulta
	{

		private frmCadastroFuncionario oFrmCadastroFuncionario;
		private Funcionario oFuncionario;
		private CtrlFuncionario aCtrlFuncionario;

		public frmConsultaFuncionario()
		{
			InitializeComponent();
		}

		public override void setFrmCadastro(object obj)
		{
			base.setFrmCadastro(obj);
			if (obj != null)
			{
				oFrmCadastroFuncionario = (frmCadastroFuncionario)obj;
			}
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			oFuncionario = (Funcionario)obj;
			aCtrlFuncionario = (CtrlFuncionario)ctrl;
			this.CarregaLV();
		}

		public override void CarregaLV()
		{
			this.listV.Items.Clear();
			var lista = aCtrlFuncionario.Listar();
			foreach (var Funcionario in lista)
			{
				ListViewItem item = new ListViewItem(Convert.ToString(Funcionario.Id));
				item.SubItems.Add(Funcionario.Tipo);
				item.SubItems.Add(Funcionario.Nome_razaoSocial);
				item.SubItems.Add(Funcionario.Apelido_nomeFanta);
				item.SubItems.Add(Convert.ToString(Funcionario.DataNascimento));
				item.SubItems.Add(Convert.ToString(Funcionario.OEndereco.ACidade.Id));
				item.SubItems.Add(Funcionario.OEndereco.ACidade.Nome);
				item.SubItems.Add(Funcionario.Cpf_cnpj);
				item.SubItems.Add(Funcionario.Email);
				item.SubItems.Add(Funcionario.Telefone);
				item.SubItems.Add(Convert.ToString(Funcionario.Status));
				item.SubItems.Add(Convert.ToString(Funcionario.Estrangeiro));
				item.SubItems.Add(Funcionario.OEndereco.EnderecoCompleto);
				item.SubItems.Add(Funcionario.OEndereco.Bairro);
				item.SubItems.Add(Funcionario.OEndereco.Cep);
				item.SubItems.Add(Funcionario.Rg_inscricaoNum);
				item.SubItems.Add(Funcionario.Matricula);
				item.SubItems.Add(Funcionario.Cargo);
				item.SubItems.Add(Convert.ToString(Funcionario.SalarioBruto));
				item.SubItems.Add(Convert.ToString(Funcionario.SalarioLiquido));
				item.SubItems.Add(Convert.ToString(Funcionario.DataAdmissao));
				item.SubItems.Add(Convert.ToString(Funcionario.CargaHoraria));
				listV.Items.Add(item);
			}
		}

		public override void Incluir()
		{
			base.Incluir();
			oFrmCadastroFuncionario.ConhecaObj(oFuncionario, aCtrlFuncionario);
			oFrmCadastroFuncionario.LimparTxt();
			oFrmCadastroFuncionario.ShowDialog();
			this.CarregaLV();
		}

		public override void Alterar()
		{
			base.Alterar();
			oFrmCadastroFuncionario.ConhecaObj(oFuncionario, aCtrlFuncionario);
			oFrmCadastroFuncionario.CarregarTxt();
			oFrmCadastroFuncionario.ShowDialog();
			this.CarregaLV();
		}

		public override void Excluir()
		{
			string aux = oFrmCadastroFuncionario.btnSave.Text;
			oFrmCadastroFuncionario.btnSave.Text = "Excluir";
			oFrmCadastroFuncionario.ConhecaObj(oFuncionario, aCtrlFuncionario);
			oFrmCadastroFuncionario.CarregarTxt();
			oFrmCadastroFuncionario.BloqueiaTxt();
			oFrmCadastroFuncionario.ShowDialog(this);
			oFrmCadastroFuncionario.DesbloqueiaTxt();
			oFrmCadastroFuncionario.btnSave.Text = aux;
			this.CarregaLV();
		}

		private void listV_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listV.SelectedItems.Count > 0)
			{
				btnExcluir.Enabled = true;
				btnAlterar.Enabled = true;
				ListViewItem item = listV.SelectedItems[0];

				oFuncionario = new Funcionario
				{
					Id = Convert.ToInt32(item.SubItems[0].Text), 
					Tipo = Convert.ToString(item.SubItems[1].Text[0]), 
					Nome_razaoSocial = item.SubItems[2].Text,
					Apelido_nomeFanta = item.SubItems[3].Text, 
					DataNascimento = DateTime.Parse(item.SubItems[4].Text), 
					Cpf_cnpj = item.SubItems[7].Text, 
					Email = item.SubItems[8].Text,
					Telefone = item.SubItems[9].Text, 
					Status = Convert.ToBoolean(item.SubItems[10].Text), 
					Estrangeiro = Convert.ToBoolean(item.SubItems[11].Text), 
					OEndereco = new Endereco			
					{
						EnderecoCompleto = item.SubItems[12].Text,
						Bairro = item.SubItems[13].Text,
						Cep = item.SubItems[14].Text,
						ACidade = new Cidade
						{
							Id = Convert.ToInt32(item.SubItems[5].Text), // Cidade ID
							Nome = item.SubItems[6].Text // Cidade Nome
						}
						
					}
				};
			}
		}
	}
}
