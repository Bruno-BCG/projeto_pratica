using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.daos;

namespace projeto_pratica
{
    internal class CtrlEstado : Controller
    {
        protected DaoEstado aDaoEstado;
        public CtrlEstado()
        {
            aDaoEstado = new DaoEstado();
        }
        public override string Salvar(object obj)
        {
            return aDaoEstado.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
			return aDaoEstado.Excluir(obj);
		}

		public List<Estado> Listar()
		{
			return aDaoEstado.Listar();
		}
	}
}
