using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Cliente : Pessoa
	{
		protected CondicaoPagamento aCondPag;
		protected double limiteCredito;

		public Cliente() : base()
		{
			aCondPag = new CondicaoPagamento();
			limiteCredito = 0;
		}

		public Cliente(
			int id, DateTime dtCriacao, DateTime dtAlt,
			char tipo, string nome, string apelido, DateTime nascimento,
			string cpf, string rg, string email, string telefone,
			bool ativo, Enderecos endereco,
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
