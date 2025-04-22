using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Cidade : Pai	
	{
		protected string nome;
		protected string ddd;
		protected Estado oEstado;

		public Cidade() : base()
		{
			nome = " ";
			ddd = " ";
			oEstado = new Estado();

		}

		public Cidade(int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, Funcionario funcAlt, string nome, string ddd, Estado oEstado)
			: base(id, dtCriacao, dtAlt, ativo)
		{
			this.nome = nome;
			this.ddd = ddd;
			this.oEstado = oEstado;
		}

		public string Nome
		{
			get => nome;
			set => nome = value;
		}

		public string Ddd
		{
			get => ddd;
			set => ddd = value;
		}

		public Estado OEstado
		{
			get => oEstado;
			set => oEstado = value;
		}
	}
}
