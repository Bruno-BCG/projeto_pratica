using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
    internal class ContasPagar : Pai
    {
        // Chaves Estrangeiras (como objetos, seguindo seu padrão)
        protected NotaEntrada aNotaEntrada;
        protected Fornecedor oFornecedor;
        protected FormaPagamento aFormaPagamento;

        // Propriedades da Parcela
        protected int numeroParcela;
        protected DateTime dataEmissao;
        protected DateTime dataVencimento;
        protected decimal valorParcela;

        // Propriedades de Pagamento
        protected int situacao; // 0: Em aberto, 1: Pago
        protected decimal juros;
        protected decimal multa;
        protected decimal desconto;
        protected decimal? valorPago; // Permite nulo
        protected DateTime? dataPagamento; // Permite nulo

        // Propriedades de Cancelamento
        protected string motivoCancelamento;

        // Construtor Padrão
        public ContasPagar() : base()
        {
            // Inicializa os objetos (para evitar NullReferenceException)
            this.aNotaEntrada = new NotaEntrada();
            this.oFornecedor = new Fornecedor();
            this.aFormaPagamento = new FormaPagamento();

            // Inicializa valores padrão
            this.numeroParcela = 1;
            this.dataEmissao = DateTime.Now;
            this.dataVencimento = DateTime.Now;
            this.valorParcela = 0;
            this.situacao = 0;
            this.juros = 0;
            this.multa = 0;
            this.desconto = 0;
            this.valorPago = null;
            this.dataPagamento = null;
            this.motivoCancelamento = string.Empty;
        }

        // Getters e Setters

        public NotaEntrada ANotaEntrada
        {
            get => aNotaEntrada;
            set => aNotaEntrada = value;
        }

        public Fornecedor OFornecedor
        {
            get => oFornecedor;
            set => oFornecedor = value;
        }

        public FormaPagamento AFormaPagamento
        {
            get => aFormaPagamento;
            set => aFormaPagamento = value;
        }

        public int NumeroParcela
        {
            get => numeroParcela;
            set => numeroParcela = value;
        }

        public DateTime DataEmissao
        {
            get => dataEmissao;
            set => dataEmissao = value;
        }

        public DateTime DataVencimento
        {
            get => dataVencimento;
            set => dataVencimento = value;
        }

        public decimal ValorParcela
        {
            get => valorParcela;
            set => valorParcela = value;
        }

        public int Situacao
        {
            get => situacao;
            set => situacao = value;
        }

        public decimal Juros
        {
            get => juros;
            set => juros = value;
        }

        public decimal Multa
        {
            get => multa;
            set => multa = value;
        }

        public decimal Desconto
        {
            get => desconto;
            set => desconto = value;
        }

        public decimal? ValorPago
        {
            get => valorPago;
            set => valorPago = value;
        }

        public DateTime? DataPagamento
        {
            get => dataPagamento;
            set => dataPagamento = value;
        }

        public string MotivoCancelamento
        {
            get => motivoCancelamento;
            set => motivoCancelamento = value;
        }
    }
}
