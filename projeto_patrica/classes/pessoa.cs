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
		protected string nomeRazaoSocial;
		protected string apelidoFantasia;
		protected DateTime dataNascimento;
		protected string cpfCnpj;
		protected string rgInscricaoEst;
		protected string email;
		protected string telefone;
		protected Enderecos oEndereco;

		public Pessoa()
		{
			tipo = ' ';
			nomeRazaoSocial = "";
			apelidoFantasia = "";
			dataNascimento = DateTime.MinValue;
			cpfCnpj = "";
			rgInscricaoEst = "";
			email = "";
			telefone = "";
			oEndereco = new Enderecos();
		}

		public Pessoa(
			int id, DateTime dtCriacao, DateTime dtAlt,
			char tipo, string nome, string apelido, DateTime nascimento,
			string cpf, string rg, string email, string telefone,
			bool ativo, Enderecos endereco
		) : base(id, dtCriacao, dtAlt, ativo)
		{
			this.tipo = tipo;
			this.nomeRazaoSocial = nome;
			this.apelidoFantasia = apelido;
			this.dataNascimento = nascimento;
			this.cpfCnpj = cpf;
			this.rgInscricaoEst = rg;
			this.email = email;
			this.telefone = telefone;
			this.oEndereco = endereco;

		}

		public char Tipo
		{
			get => tipo;
			set => tipo = value;
		}

		public string NomeRazaoSocial
		{
			get => nomeRazaoSocial;
			set => nomeRazaoSocial = value;
		}

		public string ApelidoFantasia
		{
			get => apelidoFantasia;
			set => apelidoFantasia = value;
		}

		public DateTime DataNascimento
		{
			get => dataNascimento;
			set => dataNascimento = value;
		}

		public string CpfCnpj
		{
			get => cpfCnpj;
			set => cpfCnpj = value;
		}

		public string RgInscricaoEst
		{
			get => rgInscricaoEst;
			set => rgInscricaoEst = value;
		}

		public string Email
		{
			get => email;
			set => email = value;
		}

		public string Telefone
		{
			get => telefone;
			set => telefone = value;
		}

		public Enderecos OEndereco
		{
			get => oEndereco;
			set => oEndereco = value;
		}
	}

}

