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

		public FormaPagamento()
		{
			descricao = string.Empty;
		}
		public FormaPagamento (string descricao)
		{
			this.descricao = descricao;
		}
		public string Descricao { get; set; }
	}
}
