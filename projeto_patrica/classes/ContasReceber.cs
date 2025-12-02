using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
    internal class ContasReceber : Pai
    {
        protected NotaSaida aNotaSaida;
        protected Cliente oCliente;
        protected FormaPagamento aFormaPagamento;

        protected int numeroParcela;
        protected DateTime dataEmissao;
        protected DateTime dataVencimento;
        protected decimal valorParcela;

        protected int situacao; 
        protected decimal juros;
        protected decimal multa;
        protected decimal desconto;
        protected decimal? valorPago;
        protected decimal? multaValor;
        protected decimal? jurosValor;
        protected decimal? descontoValor;
        protected DateTime? dataPagamento;

        protected string motivoCancelamento;

        public ContasReceber() : base()
        {
            // Inicializa os objetos (para evitar NullReferenceException)
            this.aNotaSaida = new NotaSaida();
            this.oCliente = new Cliente();
            this.aFormaPagamento = new FormaPagamento();
            numeroParcela = 0;
            dataEmissao = DateTime.MinValue;
            dataVencimento = DateTime.MinValue;
            valorParcela = 0;
            aFormaPagamento = new FormaPagamento();
            situacao = 0;
            juros = 0;
            multa = 0;
            desconto = 0;
            valorPago = null;
            multaValor = null;
            jurosValor = null;
            descontoValor = null;
            dataPagamento = null;
            motivoCancelamento = null;
        }

        public ContasReceber(
            int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, int modeloVenda, string serieVenda, int numeroNotaVenda, Cliente oCliente, int numeroParcela,
            DateTime dataEmissao, DateTime dataVencimento, decimal valorParcela, FormaPagamento aFormaPagamento,
            int situacao, decimal juros, decimal multa, decimal desconto, decimal? valorPago, DateTime? dataPagamento,
            DateTime dataCadastro, DateTime? dataUltimaEdicao, string motivoCancelamento, decimal? multaValor, decimal? jurosValor, decimal? descontoValor
        ) : base(id, dtCriacao, dtAlt, ativo)
        {

            this.oCliente = oCliente;
            this.numeroParcela = numeroParcela;
            this.dataEmissao = dataEmissao;
            this.dataVencimento = dataVencimento;
            this.valorParcela = valorParcela;
            this.aFormaPagamento = aFormaPagamento;
            this.situacao = situacao;
            this.juros = juros;
            this.multa = multa;
            this.desconto = desconto;
            this.valorPago = valorPago;
            this.multaValor = multaValor;
            this.jurosValor = jurosValor;
            this.descontoValor = descontoValor;
            this.dataPagamento = dataPagamento;
            this.motivoCancelamento = motivoCancelamento;
        }

        public Cliente OCliente
        {
            get => oCliente;
            set => oCliente = value;
        }

        public NotaSaida ANotaSaida
        {
            get => aNotaSaida;
            set => aNotaSaida = value;
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

        public FormaPagamento AFormaPagamento
        {
            get => aFormaPagamento;
            set => aFormaPagamento = value;
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
        public decimal? MultaValor
        {
            get => multaValor;
            set => multaValor = value;
        }
        public decimal? JurosValor
        {
            get => jurosValor;
            set => jurosValor = value;
        }
        public decimal? DescontoValor
        {
            get => descontoValor;
            set => descontoValor = value;
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
