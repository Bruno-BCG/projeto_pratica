using projeto_pratica.classes;
using projeto_pratica.daos;
using projeto_pratica.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.controllers
{
    internal class CtrlNotaSaida : Controller
    {
        private NotaSaidaService serviceNota;
        private DaoNotaSaida daoNotaSaida;   

        public CtrlNotaSaida()
        {
            serviceNota = new NotaSaidaService(); 
        }

        public override string Salvar(object obj)
        {
            return serviceNota.Salvar((NotaSaida)obj); 
        }

        public List<NotaSaida> Listar()
        {
            return serviceNota.Listar(); 
        }
        public bool ExistemParcelasPagasPorNota(int notaSaidaId)
        {
            if (daoNotaSaida == null) daoNotaSaida = new DaoNotaSaida();
            return daoNotaSaida.ExistemParcelasPagasPorNota(notaSaidaId);
        }
    }
}
