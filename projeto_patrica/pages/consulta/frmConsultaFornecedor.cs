using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.pages.cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace projeto_pratica.pages.consulta
{
	public partial class frmConsultaFornecedor : projeto_pratica.pages.consulta.frmConsulta
	{

		private frmCadastroFornecedor oFrmCadFornecedor;
		private Fornecedor oFornecedor;
		private CtrlFornecedor aCtrlFornecedor;

		public frmConsultaFornecedor()
		{
			InitializeComponent();
		}

		public override void setFrmCadastro(object obj)
		{
			base.setFrmCadastro(obj);
			if (obj != null)
			{
				oFrmCadFornecedor = (frmCadastroFornecedor)obj;
			}
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			oFornecedor = (Fornecedor)obj;
			aCtrlFornecedor = (CtrlFornecedor)ctrl;
			this.CarregaLV();
		}

		public override void CarregaLV()
		{
			this.listV.Items.Clear();
			var lista = aCtrlFornecedor.Listar();
			foreach (var fornecedor in lista)
			{
				ListViewItem item = new ListViewItem(Convert.ToString(fornecedor.Id));
				item.SubItems.Add(fornecedor.Tipo);
				item.SubItems.Add(fornecedor.Nome_razaoSocial);
				item.SubItems.Add(fornecedor.Apelido_nomeFanta);
				item.SubItems.Add(Convert.ToString(fornecedor.DataNascimento));
				item.SubItems.Add(Convert.ToString(fornecedor.OEndereco.ACidade.Id));
				item.SubItems.Add(fornecedor.OEndereco.ACidade.Nome);
				item.SubItems.Add(fornecedor.Cpf_cnpj);
				item.SubItems.Add(fornecedor.Email);
				item.SubItems.Add(fornecedor.Telefone);
				item.SubItems.Add(Convert.ToString(fornecedor.Status));
				item.SubItems.Add(Convert.ToString(fornecedor.Estrangeiro));
				item.SubItems.Add(fornecedor.OEndereco.EnderecoCompleto);
				item.SubItems.Add(fornecedor.OEndereco.Bairro);
				item.SubItems.Add(fornecedor.OEndereco.Cep);
				item.SubItems.Add(fornecedor.Rg_inscricaoNum);
				item.SubItems.Add(fornecedor.InscrEstadual);
				listV.Items.Add(item);
			}
		}

		public override void Incluir()
		{
			base.Incluir();
			oFrmCadFornecedor.ConhecaObj(oFornecedor, aCtrlFornecedor);
			oFrmCadFornecedor.LimparTxt();
			oFrmCadFornecedor.ShowDialog();
			this.CarregaLV();
		}

		public override void Alterar()
		{
			base.Alterar();
			oFrmCadFornecedor.ConhecaObj(oFornecedor, aCtrlFornecedor);
			oFrmCadFornecedor.CarregarTxt();
			oFrmCadFornecedor.ShowDialog();
			this.CarregaLV();
		}

		public override void Excluir()
		{
			string aux = oFrmCadFornecedor.btnSave.Text;
			oFrmCadFornecedor.btnSave.Text = "Excluir";
			oFrmCadFornecedor.ConhecaObj(oFornecedor, aCtrlFornecedor);
			oFrmCadFornecedor.CarregarTxt();
			oFrmCadFornecedor.BloqueiaTxt();
			oFrmCadFornecedor.ShowDialog(this);
			oFrmCadFornecedor.DesbloqueiaTxt();
			oFrmCadFornecedor.btnSave.Text = aux;
			this.CarregaLV();
		}

		private void listV_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listV.SelectedItems.Count > 0)
			{
				btnExcluir.Enabled = true;
				btnAlterar.Enabled = true;
				ListViewItem item = listV.SelectedItems[0];

				oFornecedor = new Fornecedor
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
					Rg_inscricaoNum = item.SubItems[15].Text,
					InscrEstadual = item.SubItems[16].Text,
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
