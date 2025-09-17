using System.Collections.Generic;
using projeto_pratica.classes;
using projeto_pratica.daos;

namespace projeto_pratica.controllers
{
    internal class CtrlUniMedida : Controller
    {
        protected DaoUniMedida aDaoUniMedida;

        public CtrlUniMedida()
        {
            aDaoUniMedida = new DaoUniMedida();
        }

        public override string Salvar(object obj)
        {
            return aDaoUniMedida.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDaoUniMedida.Excluir(obj);
        }

        public List<UnidadeMedida> Listar()
        {
            return aDaoUniMedida.Listar();
        }
    }
}