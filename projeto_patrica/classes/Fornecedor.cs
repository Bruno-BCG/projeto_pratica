using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Fornecedor : Pessoa
	{
		private CondicaoPagamento aCondPag;

		public Fornecedor() : base()
		{
			aCondPag = new CondicaoPagamento();
		}

		public Fornecedor(
			int id, DateTime dtCriacao, DateTime dtAlt, bool ativo,
			char tipo, string nome, string apelido, DateTime nascimento,
			string cpf, string rg, string email, string telefone,
			Enderecos endereco, 
			CondicaoPagamento condicaoPagamento
		) : base(id, dtCriacao, dtAlt, tipo, nome, apelido, nascimento, cpf, rg, email, telefone, ativo, endereco)
		{
			this.aCondPag = condicaoPagamento;
		}

		public CondicaoPagamento ACondPag
		{
			get => aCondPag;
			set => aCondPag = value;	
		}
	}
}
