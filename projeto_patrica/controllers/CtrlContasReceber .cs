using projeto_pratica.classes;
using projeto_pratica.daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
    internal class CtrlContasReceber : Controller
    {
        protected DaoContasReceber aDaoContasReceber;

        public CtrlContasReceber()
        {
            aDaoContasReceber = new DaoContasReceber();
        }

        public override string Salvar(object obj)
        {
            return aDaoContasReceber.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return aDaoContasReceber.Excluir(obj);
        }

        public List<ContasReceber> Listar()
        {
            return aDaoContasReceber.Listar();
        }
        public bool ExistemParcelasAvulsasPendentes(int idCliente, int numeroParcela)
        {
            return aDaoContasReceber.ExistemParcelasAvulsasPendentes(idCliente, numeroParcela);
        }
    }
}
