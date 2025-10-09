using projeto_pratica.classes;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
    internal class CtrlNotaEntrada : Controller
    {
        protected DaoNotaEntrada aDaoNotaEntrada;

        public CtrlNotaEntrada() 
        {
            aDaoNotaEntrada = new DaoNotaEntrada();
        }

        public override string Salvar(object obj)
        {
            return aDaoNotaEntrada.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDaoNotaEntrada.Excluir(obj);
        }

        public List<NotaEntrada> Listar()
        {
            return aDaoNotaEntrada.Listar();
        }

    }
}
