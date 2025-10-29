using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_pratica.classes;
using projeto_pratica.daos;

namespace projeto_pratica.controllers
{
	internal class CtrlCondPag : Controller
	{
		protected DaoCondPag aDaoCondPag;

		public CtrlCondPag()
		{
			aDaoCondPag = new DaoCondPag();
		}
		public override string Salvar(object obj)
		{
			return aDaoCondPag.Salvar(obj);
		}

		public override string Excluir(object obj)
		{
			return aDaoCondPag.Excluir(obj);
		}

		public List<CondicaoPagamento> Listar()
		{
			return aDaoCondPag.Listar();
		}
        public CondicaoPagamento BuscarPorId(int id)
        {
            return aDaoCondPag.BuscarPorId(id);
        }

    }
}
