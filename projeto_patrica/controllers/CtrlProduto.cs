using System.Collections.Generic;
using projeto_pratica.classes;
using projeto_pratica.daos;

namespace projeto_pratica.controllers
{
    internal class CtrlProduto : Controller
    {
        protected DaoProduto aDaoProduto;

        public CtrlProduto()
        {
            aDaoProduto = new DaoProduto();
        }

        public override string Salvar(object obj)
        {
            return aDaoProduto.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDaoProduto.Excluir(obj);
        }

        public List<Produto> Listar()
        {
            return aDaoProduto.Listar();
        }
        public Produto BuscarPorId(int id)
        {
            return aDaoProduto.BuscarPorId(id);
        }
    }
}