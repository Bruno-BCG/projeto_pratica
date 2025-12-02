using projeto_pratica.classes;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
	internal class CtrlFuncionario : Controller
	{
		protected DaoFuncionario aDaoFuncionario;

		public CtrlFuncionario()
		{
			aDaoFuncionario = new DaoFuncionario();
		}

		public override string Salvar(object obj)
		{
			return aDaoFuncionario.Salvar(obj);
		}

		public override string Excluir(object obj)
		{
			return aDaoFuncionario.Excluir(obj);
		}

		public List<Funcionario> Listar()
		{
			return aDaoFuncionario.Listar();
		}
		public Funcionario BuscarPorId(int id)
		{
			return aDaoFuncionario.BuscarPorId(id);
		}
	}
}
