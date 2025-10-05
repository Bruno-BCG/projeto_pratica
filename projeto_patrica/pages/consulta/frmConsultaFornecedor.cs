using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.daos;
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
				ListViewItem item = new ListViewItem(fornecedor.Id.ToString());
				item.SubItems.Add(fornecedor.Tipo.ToString());
				item.SubItems.Add(fornecedor.NomeRazaoSocial);
				item.SubItems.Add(fornecedor.ApelidoFantasia);
				item.SubItems.Add(fornecedor.CpfCnpj);
				item.SubItems.Add(fornecedor.RgInscricaoEst);
                item.SubItems.Add(fornecedor.DataNascimento.ToShortDateString());
                item.SubItems.Add(fornecedor.Email);
				item.SubItems.Add(fornecedor.Telefone);
                item.SubItems.Add(fornecedor.OEndereco.Cep);
                item.SubItems.Add(fornecedor.OEndereco.Endereco);
				item.SubItems.Add(fornecedor.OEndereco.Bairro);
                item.SubItems.Add(fornecedor.OEndereco.ACidade.Nome);
                item.SubItems.Add(fornecedor.ACondPag.Descricao);
                item.SubItems.Add(Convert.ToString(fornecedor.LimiteCredito));
                item.SubItems.Add(Convert.ToString(fornecedor.Ativo));

                item.Tag = fornecedor;
				listV.Items.Add(item);
			}
		}

		public override void Incluir()
		{
			base.Incluir();
			oFornecedor = new Fornecedor();
			oFrmCadFornecedor.DesbloqueiaTxt();
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

                // 1. Pega o objeto da lista em uma variável temporária "selecionado"
                var selecionado = (Fornecedor)listV.SelectedItems[0].Tag;

                // 2. Copia cada valor do "selecionado" para o objeto "oFornecedor" original.
                // Isso preserva a referência do objeto que veio da tela anterior.
                oFornecedor.Id = selecionado.Id;
                oFornecedor.Tipo = selecionado.Tipo;
                oFornecedor.NomeRazaoSocial = selecionado.NomeRazaoSocial;
                oFornecedor.ApelidoFantasia = selecionado.ApelidoFantasia;
				oFornecedor.DataNascimento = selecionado.DataNascimento;
                oFornecedor.CpfCnpj = selecionado.CpfCnpj;
                oFornecedor.RgInscricaoEst = selecionado.RgInscricaoEst;
                oFornecedor.Email = selecionado.Email;
                oFornecedor.Telefone = selecionado.Telefone;
                oFornecedor.Ativo = selecionado.Ativo;
                oFornecedor.LimiteCredito = selecionado.LimiteCredito;

                // É crucial copiar também os objetos internos
                oFornecedor.OEndereco = selecionado.OEndereco;
                oFornecedor.ACondPag = selecionado.ACondPag;
            }
        }
    }
}
