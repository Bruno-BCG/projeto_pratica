using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Enderecos
	{
		protected string endereco;
		protected string num;
		protected string bairro;
		protected Cidade aCidade;
		protected string cep;
		protected string complemento;
		public Enderecos() 
		{ 
			this.endereco = " ";
			this.num = " ";
			this.complemento = " ";
			this.bairro = " ";
			this.cep = " ";
			aCidade = new Cidade();
		}
		public Enderecos(string endereco, string bairro, string num, string complemento, Cidade aCidade, string cep)
		{
			this.endereco = endereco;
			this.bairro = bairro;
			this.num = num;
			this.complemento = complemento;
			this.aCidade = aCidade;
			this.cep = cep;
		}

		public string Endereco { get => endereco;  set => endereco = value; }
		public string Num
		{
			get => num; 
			set => num = value;
		}
		public string Complemento
		{
			get => complemento;
			set => complemento = value;
		}
		public string Bairro { get => bairro; set => bairro = value; }
		public Cidade ACidade { get => aCidade; set => aCidade = value; }
		public string Cep { get => cep; set => cep = value; }

	}
}
