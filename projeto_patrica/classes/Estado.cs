using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Estado : Pai
	{
		protected string nome;
		protected string uf;
		protected Pais oPais;

		public Estado() : base()
		{
			nome = " ";
			uf = " ";
			oPais = new Pais();
		}

		public Estado(int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, string nome, string uf, Pais oPais)
			: base(id, dtCriacao, dtAlt, ativo)
		{
			this.nome = nome;
			this.uf = uf;
			this.oPais = oPais;
		}

		public string Nome
		{
			get => nome;
			set => nome = value;
		}

		public string Uf
		{
			get => uf;
			set => uf = value;
		}

		public Pais OPais
		{
			get => oPais;
			set => oPais = value;
		}
	}
}
