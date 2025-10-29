using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace projeto_pratica.classes
{
    internal class ItensNotaEntrada : Pai
    {
        protected Produto oProduto;
        protected decimal qtd;
        protected decimal valorUnitario;
        protected decimal custoUnitarioReal;

        // Construtores, Getters e Setters

        public ItensNotaEntrada()
        {
            this.oProduto = new Produto();
            this.qtd = 0;
            this.valorUnitario = 0;
        }

        public ItensNotaEntrada(int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, Produto oProduto, decimal qtd, decimal valorUnitario) : base (id, dtCriacao, dtAlt, ativo)
        {
            this.oProduto = oProduto;
            this.qtd = qtd;
            this.valorUnitario = valorUnitario;
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

        public decimal CustoUnitarioReal 
        { 
            get => custoUnitarioReal; 
            set => custoUnitarioReal = value; 
        }

    }
}
