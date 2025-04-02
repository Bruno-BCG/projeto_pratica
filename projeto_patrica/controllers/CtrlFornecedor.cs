using projeto_pratica.classes;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
	internal class CtrlFornecedor : Controller
	{
		protected DaoFornecedor aDaoFornecedor;

		public CtrlFornecedor()
		{
			aDaoFornecedor = new DaoFornecedor();
		}
		public override string Salvar(object obj)
		{
			return aDaoFornecedor.Salvar(obj);
		}
		public override string Excluir(object obj)
		{
			return aDaoFornecedor.Excluir(obj);
		}
		public List<Fornecedor> Listar()
		{
			return aDaoFornecedor.Listar();
		}

	}
}
