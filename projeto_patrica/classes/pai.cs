using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Pai
	{
		protected int id;
		protected DateTime dtCriacao;
		protected DateTime dtAlt;
		protected bool ativo;

		public Pai()
		{
			id = 0;
			dtCriacao = DateTime.Now;
			dtAlt = DateTime.Now;
			ativo = false;
		}

		public Pai(int id, DateTime dtCriacao, DateTime dtAlt, bool ativo)
		{
			this.id = id;
			this.dtCriacao = dtCriacao;
			this.dtAlt = dtAlt;
			this.ativo = ativo;
		}

		public int Id
		{
			get => id;
			set => id = value;
		}

		public DateTime DtCriacao
		{
			get => dtCriacao;
			set => dtCriacao = value;
		}

		public DateTime DtAlt
		{
			get => dtAlt;
			set => dtAlt = value;
		}
		public bool Ativo
		{
			get => ativo;
			set => ativo = value;
		}
	}
}
