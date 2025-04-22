using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Pais : Pai
	{
		protected string nome;
		protected string sigla;
		protected string moeda;
		protected string ddi;

		public Pais() : base()
		{
			nome = " ";
			sigla = " ";
			moeda = " ";
			ddi = " ";
		}

		public Pais(int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, string nome, string sigla, string moeda, string ddi)
			: base(id, dtCriacao, dtAlt, ativo)
		{
			this.nome = nome;
			this.sigla = sigla;
			this.moeda = moeda;
			this.ddi = ddi;
		}

		public string Nome
		{
			get => nome;
			set => nome = value;
		}

		public string Sigla
		{
			get => sigla;
			set => sigla = value;
		}

		public string Moeda
		{
			get => moeda;
			set => moeda = value;
		}

		public string Ddi
		{
			get => ddi;
			set => ddi = value;
		}
	}
}
