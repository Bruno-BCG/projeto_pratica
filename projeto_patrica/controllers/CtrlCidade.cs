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
    internal class CtrlCidade : Controller
    {
        protected DaoCidade aDaoCidade;
        public CtrlCidade()
        {
            aDaoCidade = new DaoCidade();
        }
        public override string Salvar(object obj)
        {
            return aDaoCidade.Salvar(obj);
        }

        public override string Excluir(object obj)
        {
            return " ";
        }

        /*
        public override List<object> Pesquisar(string chave)
        {

        }

        public override void CarregarObj(object obj)
        {

        }
        */
    }
}
