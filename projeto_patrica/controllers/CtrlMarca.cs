using System.Collections.Generic;
using projeto_pratica.classes;
using projeto_pratica.daos;

namespace projeto_pratica.controllers
{
    internal class CtrlMarca : Controller
    {
        protected DaoMarca aDaoMarca;

        public CtrlMarca()
        {
            aDaoMarca = new DaoMarca();
        }

        public override string Salvar(object obj)
        {
            return aDaoMarca.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDaoMarca.Excluir(obj);
        }

        public List<Marca> Listar()
        {
            return aDaoMarca.Listar();
        }
    }
}