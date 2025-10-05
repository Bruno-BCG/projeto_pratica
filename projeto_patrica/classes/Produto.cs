using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
    internal class Produto : Pai
    {
        protected string nome;
        protected string codBar;
        protected List<Fornecedor> oFornecedor;
        protected UnidadeMedida aUnidadeMedida;
        protected Categoria aCategoria;
        protected Marca aMarca;
        protected double custo;
        protected double venda;
        protected int estoque;

        public Produto () : base ()
        {
            nome = " ";
            codBar = " ";
            oFornecedor = new List<Fornecedor>();
            aUnidadeMedida = new UnidadeMedida ();
            aCategoria = new Categoria ();
            aMarca = new Marca ();
            custo = 0;
            venda = 0;
            estoque = 0;
        }

        public Produto (int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, string nome, string codBar, List<Fornecedor> oFornecedor, UnidadeMedida aUnidadeMedida, Categoria aCategoria, Marca aMarca, double custo, double venda, int qtd) : base (id, dtCriacao, dtAlt, ativo)
        {
            this.nome = nome;
            this.codBar = codBar;
            this.oFornecedor = oFornecedor;
            this.aUnidadeMedida = aUnidadeMedida;
            this.aCategoria = aCategoria;
            this.aCategoria = aCategoria;
            this.aMarca = aMarca;
            this.custo = custo;
            this.venda = venda;
            this.estoque = qtd;
        }
        public string Nome 
        { 
            get => nome; 
            set => nome = value; 
        }
        public string Codbar
        {
            get => codBar;
            set => codBar = value;
        }
        public List<Fornecedor> OFornecedor
        {
            get => oFornecedor;
            set => oFornecedor = value;
        }
        public UnidadeMedida AUnidadeMedida
        {
            get => aUnidadeMedida;
            set => aUnidadeMedida = value;
        }
        public Categoria ACategoria
        {
            get => aCategoria;
            set => aCategoria = value;
        }
        public Marca AMarca
        {
            get => aMarca;
            set => aMarca = value;
        }
        public double Custo
        {
            get => custo;
            set => custo = value;
        }
        public double Venda
        {
            get => venda;
            set => venda = value;
        }
        public int Estoque
        {
            get => estoque;
            set => estoque = value;
        }
    }
}
