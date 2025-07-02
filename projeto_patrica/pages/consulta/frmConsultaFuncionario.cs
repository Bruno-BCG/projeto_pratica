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
			listV.Items.Clear();
			var lista = aCtrlFuncionario.Listar();

			foreach (var f in lista)
			{
				var item = new ListViewItem(f.Id.ToString());
				item.SubItems.Add(f.Tipo.ToString());
				item.SubItems.Add(f.NomeRazaoSocial);
				item.SubItems.Add(f.ApelidoFantasia);
				item.SubItems.Add(f.CpfCnpj);
				item.SubItems.Add(f.RgInscricaoEst);
                item.SubItems.Add(f.DataNascimento.ToShortDateString());
                item.SubItems.Add(f.Email);
				item.SubItems.Add(f.Telefone);
				item.SubItems.Add(f.Matricula);
				item.SubItems.Add(f.Cargo);
				item.SubItems.Add(f.SalarioBruto.ToString("F2"));
				item.SubItems.Add(f.SalarioLiquido.ToString("F2"));
				item.SubItems.Add(f.DataAdmissao.ToShortDateString());
                item.SubItems.Add(f.DataDemissao.ToShortDateString());
                item.SubItems.Add(f.CargaHoraria.ToString());
				item.SubItems.Add(f.Turno);
                item.SubItems.Add(f.Ativo.ToString());

                item.Tag = f; 
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

				oFuncionario = (Funcionario)listV.SelectedItems[0].Tag;
			}
		}

		private void frmConsultaFuncionario_Load(object sender, EventArgs e)
		{

		}
	}
}
