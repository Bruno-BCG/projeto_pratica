using projeto_pratica.classes;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
    internal class CtrlContasPagar : Controller
    {
        protected DaoContasPagar aDaoContasPagar;

        public CtrlContasPagar()
        {
            aDaoContasPagar = new DaoContasPagar();
        }

        public override string Salvar(object obj)
        {
            return aDaoContasPagar.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDaoContasPagar.Excluir(obj);
        }

        public List<ContasPagar> Listar()
        {
            return aDaoContasPagar.Listar();
        }
        public bool ExistemParcelasAvulsasPendentes(int idFornecedor, int numeroParcela)
        {
            return aDaoContasPagar.ExistemParcelasAvulsasPendentes(idFornecedor, numeroParcela);
        }
        public bool ExistemParcelasAnterioresPendentesPorNota(int idFornecedor, int numeroParcela)
        {
            return aDaoContasPagar.ExistemParcelasAnterioresPendentesPorNota(idFornecedor,numeroParcela);
        }
    }
}
