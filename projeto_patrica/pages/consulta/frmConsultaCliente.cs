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
	public partial class frmConsultaCliente : projeto_pratica.pages.consulta.frmConsulta
	{

		private frmCadastroCliente oFrmCadastroCliente;
		private Cliente oCliente;
		private CtrlCliente aCtrlCliente;

		public frmConsultaCliente()
		{
			InitializeComponent();
		}

		public override void setFrmCadastro(object obj)
		{
			base.setFrmCadastro(obj);
			if (obj != null)
			{
				oFrmCadastroCliente = (frmCadastroCliente)obj;
			}
		}

		public override void ConhecaObj(object obj, object ctrl)
		{
			oCliente = (Cliente)obj;
			aCtrlCliente = (CtrlCliente)ctrl;
			this.CarregaLV();
		}

		public override void CarregaLV()
		{
			this.listV.Items.Clear();
			var lista = aCtrlCliente.Listar();
			foreach (var cliente in lista)
			{
				ListViewItem item = new ListViewItem(Convert.ToString(cliente.Id));
				item.SubItems.Add(Convert.ToString(cliente.Tipo));
				item.SubItems.Add(cliente.NomeRazaoSocial);
				item.SubItems.Add(cliente.ApelidoFantasia);
				item.SubItems.Add(Convert.ToString(cliente.DataNascimento));
				item.SubItems.Add(Convert.ToString(cliente.OEndereco.ACidade.Id));
				item.SubItems.Add(cliente.OEndereco.ACidade.Nome);
				item.SubItems.Add(cliente.CpfCnpj);
				item.SubItems.Add(cliente.Email);
				item.SubItems.Add(cliente.Telefone);
				item.SubItems.Add(Convert.ToString(cliente.Ativo));
				item.SubItems.Add(cliente.OEndereco.Endereco);
				item.SubItems.Add(cliente.OEndereco.Bairro);
				item.SubItems.Add(cliente.OEndereco.Cep);
				item.SubItems.Add(cliente.RgInscricaoEst);
				listV.Items.Add(item);
			}
		}

		public override void Incluir()
		{
			base.Incluir();
			oFrmCadastroCliente.ConhecaObj(oCliente, aCtrlCliente);
			oFrmCadastroCliente.LimparTxt();
			oFrmCadastroCliente.ShowDialog();
			this.CarregaLV();
		}

		public override void Alterar()
		{
			base.Alterar();
			oFrmCadastroCliente.ConhecaObj(oCliente, aCtrlCliente);
			oFrmCadastroCliente.CarregarTxt();
			oFrmCadastroCliente.ShowDialog();
			this.CarregaLV();
		}

		public override void Excluir()
		{
			string aux = oFrmCadastroCliente.btnSave.Text;
			oFrmCadastroCliente.btnSave.Text = "Excluir";
			oFrmCadastroCliente.ConhecaObj(oCliente, aCtrlCliente);
			oFrmCadastroCliente.CarregarTxt();
			oFrmCadastroCliente.BloqueiaTxt();
			oFrmCadastroCliente.ShowDialog(this);
			oFrmCadastroCliente.DesbloqueiaTxt();
			oFrmCadastroCliente.btnSave.Text = aux;
			this.CarregaLV();
		}

		private void listV_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listV.SelectedItems.Count > 0)
			{
				btnExcluir.Enabled = true;
				btnAlterar.Enabled = true;
				ListViewItem item = listV.SelectedItems[0];

				oCliente = new Cliente
				{
					Id = Convert.ToInt32(item.SubItems[0].Text), 
					Tipo = Convert.ToChar(item.SubItems[1].Text[0]), 
					NomeRazaoSocial = item.SubItems[2].Text,
					ApelidoFantasia = item.SubItems[3].Text, 
					DataNascimento = DateTime.Parse(item.SubItems[4].Text), 
					CpfCnpj = item.SubItems[7].Text, 
					Email = item.SubItems[8].Text,
					Telefone = item.SubItems[9].Text, 
					Ativo = Convert.ToBoolean(item.SubItems[10].Text), 
					RgInscricaoEst = item.SubItems[15].Text,
					OEndereco = new Enderecos		
					{
						Endereco = item.SubItems[12].Text,
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
