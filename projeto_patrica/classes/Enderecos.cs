using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Enderecos
	{
		protected string endereco;
		protected string bairro;
		protected Cidade aCidade;
		protected string cep;
		public Enderecos() 
		{ 
			this.endereco = " ";
			this.bairro = " ";
			this.cep = " ";
			aCidade = new Cidade();
		}
		public Enderecos(string endereco, string bairro, Cidade aCidade, string cep)
		{
			this.endereco = endereco;
			this.bairro = bairro;
			this.aCidade = aCidade;
			this.cep = cep;
		}

		public string Endereco { get => endereco;  set => value = endereco; }
		public string Bairro { get; set; }
		public Cidade ACidade { get => aCidade; set => aCidade = value; }
		public string Cep { get; set; }

	}
}
