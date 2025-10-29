using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
    internal class NotaEntrada : Pai 
    {
        protected string modelo;
        protected string serie;
        protected string numero;
        protected Fornecedor oFornecedor;
        protected DateTime dataEmissao;
        protected DateTime dataChegada;

        protected List<ItensNotaEntrada> itensDaNota;

        protected decimal valorFrete;
        protected decimal valorSeguro;
        protected decimal outrasDespesas;
        protected CondicaoPagamento aCondicaoPagamento;

        protected string motivoCancelamento;

        public NotaEntrada() : base()
        {
            this.modelo = string.Empty;
            this.serie = string.Empty;
            this.numero = string.Empty;
            this.oFornecedor = new Fornecedor();
            this.dataEmissao = DateTime.Now;
            this.dataChegada = DateTime.Now;
            this.itensDaNota = new List<ItensNotaEntrada>(); 
            this.valorFrete = 0;
            this.valorSeguro = 0;
            this.outrasDespesas = 0;
            this.aCondicaoPagamento = new CondicaoPagamento();
            this.motivoCancelamento = string.Empty;
        }

        public NotaEntrada(
          int id, DateTime dtCriacao, DateTime dtAlt, bool ativo,
          string modelo, string serie, string numero, Fornecedor fornecedor,
          DateTime dataEmissao, DateTime dataChegada, List<ItensNotaEntrada> itens,
          decimal valorFrete, decimal valorSeguro, decimal outrasDespesas,
          CondicaoPagamento condicaoPagamento, string motivoCancelamento) : base(id, dtCriacao, dtAlt, ativo)
        {
            this.modelo = modelo;
            this.serie = serie;
            this.numero = numero;
            this.oFornecedor = fornecedor;
            this.dataEmissao = dataEmissao;
            this.dataChegada = dataChegada;
            this.itensDaNota = itens;
            this.valorFrete = valorFrete;
            this.valorSeguro = valorSeguro;
            this.outrasDespesas = outrasDespesas;
            this.aCondicaoPagamento = condicaoPagamento;
            this.motivoCancelamento = motivoCancelamento;
        }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Numero { get => numero; set => numero = value; }
        public Fornecedor OFornecedor { get => oFornecedor; set => oFornecedor = value; }
        public DateTime DataEmissao { get => dataEmissao; set => dataEmissao = value; }
        public DateTime DataChegada { get => dataChegada; set => dataChegada = value; }
        public List<ItensNotaEntrada> ItensDaNota { get => itensDaNota; set => itensDaNota = value; }
        public decimal ValorFrete { get => valorFrete; set => valorFrete = value; }
        public decimal ValorSeguro { get => valorSeguro; set => valorSeguro = value; }
        public decimal OutrasDespesas { get => outrasDespesas; set => outrasDespesas = value; }
        public CondicaoPagamento ACondicaoPagamento { get => aCondicaoPagamento; set => aCondicaoPagamento = value; }
        public string MotivoCancelamento { get => motivoCancelamento; set => motivoCancelamento = value; }

        // --- Propriedades Calculadas ---

        public decimal SubTotalProdutos
        {
            get => itensDaNota.Sum(item => item.ValorTotal);
        }
        public decimal ValorTotalNota
        {
            get => SubTotalProdutos + this.valorFrete + this.valorSeguro + this.outrasDespesas;
        }

    }
}
