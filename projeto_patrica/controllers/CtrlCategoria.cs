using System.Collections.Generic;
using projeto_pratica.classes;
using projeto_pratica.daos;

namespace projeto_pratica.controllers
{
    internal class CtrlCategoria : Controller
    {
        protected DaoCategoria aDaoCategoria;

        public CtrlCategoria()
        {
            aDaoCategoria = new DaoCategoria();
        }

        public override string Salvar(object obj)
        {
            return aDaoCategoria.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDaoCategoria.Excluir(obj);
        }

        public List<Categoria> Listar()
        {
            return aDaoCategoria.Listar();
        }
    }
}