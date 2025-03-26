using projeto_pratica.classes;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
	internal class CtrlParcCondPag : Controller
	{
		protected DaoParcCondPag aDaoParcelaCondPag;

		public CtrlParcCondPag()
		{
			aDaoParcelaCondPag = new DaoParcCondPag();
		}

		public override string Salvar(object obj)
		{
			return aDaoParcelaCondPag.Salvar(obj);
		}

		public override string Excluir(object obj)
		{
			return aDaoParcelaCondPag.Excluir(obj);
		}

		// Updated Listar() to accept a Condição de Pagamento ID as a filter
		public List<ParcelaCondPag> Listar(int condPagId)
		{
			return aDaoParcelaCondPag.Listar(condPagId);
		}
	}
}

