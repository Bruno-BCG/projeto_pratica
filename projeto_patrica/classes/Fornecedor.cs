using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Fornecedor : Pessoa
	{
		protected CondicaoPagamento aCondPag;
		protected double limiteCredito;


		public Fornecedor() : base()
		{
			aCondPag = new CondicaoPagamento();
			limiteCredito = 0;
		}

		public Fornecedor(
			int id, DateTime dtCriacao, DateTime dtAlt, bool ativo,
			char tipo, string nome, string apelido, DateTime nascimento,
			string cpf, string rg, string email, string telefone,
			Enderecos endereco, 
			CondicaoPagamento condicaoPagamento, double limiteCredito
		) : base(id, dtCriacao, dtAlt, tipo, nome, apelido, nascimento, cpf, rg, email, telefone, ativo, endereco)
		{
			this.aCondPag = condicaoPagamento;
			this.limiteCredito = limiteCredito;
		}

		public CondicaoPagamento ACondPag
		{
			get => aCondPag;
			set => aCondPag = value;	
		}
		public double LimiteCredito
		{
			get => limiteCredito;
			set => limiteCredito = value;
		}
	}
}
