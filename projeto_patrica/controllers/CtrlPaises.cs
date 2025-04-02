using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_pratica.classes;
using projeto_pratica.controllers;
using projeto_pratica.daos;

namespace projeto_pratica
{
    internal class CtrlPaises : Controller
    {
        protected DaoPaises aDaoPaises;
        public CtrlPaises() 
        {
            aDaoPaises = new DaoPaises();
        }
        public override string Salvar(object obj)
        {
           return aDaoPaises.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
			return aDaoPaises.Excluir(obj);
		}

		public List<Pais> ListarPaises() 
        { 
            return aDaoPaises.ListarPaises();
        }

    }
}

