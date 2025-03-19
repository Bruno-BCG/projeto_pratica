using projeto_pratica.classes;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
	internal class CtrlFormPag : Controller
	{
		protected DaoFormPag aDaoFormPag;
		public CtrlFormPag()
		{
			 aDaoFormPag = new DaoFormPag();
		}

		public override string Salvar(object obj)
		{
			return aDaoFormPag.Salvar(obj);
		}
		public List<FormaPagamento> Listar()
		{
			return aDaoFormPag.Listar();
		}
	}
}
