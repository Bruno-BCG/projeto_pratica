using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
    internal class Marca : Pai
    {
        protected string nome;

        public Marca() : base()
        {
            nome = " ";
        }
        public Marca(int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, string nome) : base(id, dtCriacao, dtAlt, ativo)
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
