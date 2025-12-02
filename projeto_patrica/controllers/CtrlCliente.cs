using projeto_pratica.classes;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
	internal class CtrlCliente : Controller
	{
		protected DaoCliente aDaoCliente;

		public CtrlCliente()
		{
			aDaoCliente = new DaoCliente();
		}

		public override string Salvar(object obj)
		{
			return aDaoCliente.Salvar(obj);
		}

		public override string Excluir(object obj)
		{
			return aDaoCliente.Excluir(obj);
		}

		public List<Cliente> Listar()
		{
			return aDaoCliente.Listar();
		}

		public Cliente BuscarPorId(int id)
		{
			return aDaoCliente.BuscarPorId(id);

        }
	}
}
