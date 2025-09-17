using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
    internal class UnidadeMedida : Pai
    {
        protected string nome;

        public UnidadeMedida() : base()
        {
            nome = " ";
        }
        public UnidadeMedida(int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, string nome) : base(id, dtCriacao, dtAlt, ativo)
        {
            this.nome = nome;
        }
        public string Nome
        {
            get => nome;
            set => nome = value;
        }
    }
}
