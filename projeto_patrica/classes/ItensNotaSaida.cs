using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace projeto_pratica.classes
{
    internal class ItensNotaSaida: Pai
    {
        protected Produto oProduto;
        protected decimal qtd;
        protected decimal valorUnitario;

        // Construtores, Getters e Setters

        public ItensNotaSaida()
        {
            this.oProduto = new Produto();
            this.qtd = 0;
            this.valorUnitario = 0;
        }

        public ItensNotaSaida(int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, Produto oProduto, decimal qtd) : base(id, dtCriacao, dtAlt, ativo)
        {
            this.oProduto = oProduto;
            this.qtd = qtd;
        }

        // Getters e Setters
        public Produto OProduto
        {
            get => oProduto;
            set => oProduto = value;
        }

        public decimal Qtd
        {
            get => qtd;
            set => qtd = value;
        }

        public decimal ValorUnitario
        {
            get => valorUnitario;
            set => valorUnitario = value;
        }

        public decimal ValorTotal
        {
            get { return this.qtd * this.valorUnitario; }
        }
    }
}
