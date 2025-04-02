using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Endereco
	{
		protected string enderecoCompleto;
		protected string bairro;
		protected Cidade aCidade;
		protected string cep;
		public Endereco() 
		{ 
			this.enderecoCompleto = " ";
			this.bairro = " ";
			this.cep = " ";
			aCidade = new Cidade();
		}
		public Endereco(string enderecoCompleto, string bairro, Cidade aCidade, string cep)
		{
			this.enderecoCompleto = enderecoCompleto;
			this.bairro = bairro;
			this.aCidade = aCidade;
			this.cep = cep;
		}

		public string EnderecoCompleto { get;  set; }
		public string Bairro { get; set; }
		public Cidade ACidade { get => aCidade; set => aCidade = value; }
		public string Cep { get; set; }

	}
}
