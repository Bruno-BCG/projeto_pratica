using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
    internal class NotaSaida : Pai
    {
        protected string modelo;
        protected string serie;
        protected string numero;
        protected Cliente oCliente;
        protected Funcionario oFuncionario;
        protected DateTime dataEmissao;

        protected List<ItensNotaSaida> itensDaNota;

        protected CondicaoPagamento aCondicaoPagamento;

        protected string motivoCancelamento;

        public NotaSaida() : base()
        {
            this.modelo = string.Empty;
            this.serie = string.Empty;
            this.numero = string.Empty;
            this.oCliente = new Cliente();
            this.oFuncionario = new Funcionario();
            this.dataEmissao = DateTime.Now;
            this.itensDaNota = new List<ItensNotaSaida>();
            this.aCondicaoPagamento = new CondicaoPagamento();
            this.motivoCancelamento = string.Empty;
        }

        public NotaSaida(
          int id, DateTime dtCriacao, DateTime dtAlt, bool ativo,
          string modelo, string serie, string numero, Cliente cliente, Funcionario oFuncionario,
          DateTime dataEmissao, List<ItensNotaSaida> itens,
          CondicaoPagamento condicaoPagamento, string motivoCancelamento) : base(id, dtCriacao, dtAlt, ativo)
        {
            this.modelo = modelo;
            this.serie = serie;
            this.numero = numero;
            this.oCliente = cliente;
            this.oFuncionario = oFuncionario;
            this.dataEmissao = dataEmissao;
            this.itensDaNota = itens;
            this.aCondicaoPagamento = condicaoPagamento;
            this.motivoCancelamento = motivoCancelamento;
        }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Numero { get => numero; set => numero = value; }
        public Cliente OCliente { get => oCliente; set => oCliente = value; }
        public Funcionario OFuncionario { get => oFuncionario; set => oFuncionario = value; }
        public DateTime DataEmissao { get => dataEmissao; set => dataEmissao = value; }
        public List<ItensNotaSaida> ItensDaNota { get => itensDaNota; set => itensDaNota = value; }
        public CondicaoPagamento ACondicaoPagamento { get => aCondicaoPagamento; set => aCondicaoPagamento = value; }
        public string MotivoCancelamento { get => motivoCancelamento; set => motivoCancelamento = value; }
        public decimal SubTotalProdutos
        {
            get => itensDaNota.Sum(item => item.ValorTotal);
        }
    }
}
