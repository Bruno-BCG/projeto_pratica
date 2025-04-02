using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Pessoa : Pai
	{
		protected char tipo;
		protected string nome_razaoSocial;
		protected string apelido_nomeFanta;
		protected DateTime dataNascimento;
		protected string cpf_cnpj;
		protected string rg_inscricaoNum;
		protected string email;
		protected string telefone;
		protected bool status;
		protected bool estrangeiro;
		protected Endereco oEndereco;

		public Pessoa()
		{
			this.tipo = ' ';
			this.nome_razaoSocial = " ";
			this.apelido_nomeFanta = " ";
			this.dataNascimento = DateTime.MinValue;
			this.cpf_cnpj = " ";
			this.rg_inscricaoNum = " ";
			this.email = " ";
			this.telefone = " ";
			this.status = false;
			this.estrangeiro = false;
			this.oEndereco = new Endereco();
		}
		public Pessoa(char tipo, string nome_razaoSocial, string apelido_nomeFanta, DateTime dataNascimento, string cpf_cnpj, string rg_inscricaoNum, string email, string telefone, bool status, bool estrangeiro, Endereco endereco)
		{ 
			this.tipo = tipo;
			this.nome_razaoSocial = nome_razaoSocial;
			this.apelido_nomeFanta = apelido_nomeFanta;
			this.dataNascimento = dataNascimento;
			this.rg_inscricaoNum = rg_inscricaoNum;
			this.cpf_cnpj = cpf_cnpj;
			this.email = email;
			this.telefone = telefone;
			this.status = status;
			this.estrangeiro = estrangeiro;
			this.oEndereco = endereco;
		}
		public string Tipo { get; set; }
		public string Nome_razaoSocial { get; set; }
		public string Apelido_nomeFanta {  get; set; }
		public DateTime DataNascimento { get; set; }
		public string Cpf_cnpj { get; set; }
		public string Rg_inscricaoNum{ get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
		public bool Status { get; set; }
		public bool Estrangeiro { get; set; }
		public Endereco OEndereco { get => oEndereco; set => oEndereco = value; }


	}
}
