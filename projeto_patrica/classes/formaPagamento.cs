using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace projeto_pratica.classes
{
	internal class FormaPagamento : Pai
	{
		protected string descricao;

		public FormaPagamento() : base()
		{
			descricao = string.Empty;
		}

		public FormaPagamento(int id, DateTime dtCriacao, DateTime dtAlt, bool ativo, string descricao)
			: base(id, dtCriacao, dtAlt, ativo)
		{
			this.descricao = descricao;
		}

		public string Descricao
		{
			get => descricao;
			set => descricao = value;
		}
	}
}
