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
    internal class CtrlNotaEntrada : Controller
    {
        private NotaEntradaService serviceNota; 

        public CtrlNotaEntrada()
        {
            serviceNota = new NotaEntradaService(); 
        }

        public override string Salvar(object obj)
        {
            return serviceNota.Salvar((NotaEntrada)obj); 
        }

        public List<NotaEntrada> Listar()
        {
            return serviceNota.Listar(); 
        }
    }
}
