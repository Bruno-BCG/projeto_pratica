using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_pratica.classes
{
	internal class CondicaoPagamento : Pai
	{
		protected string descricao;
		protected int numParcelas;
		public CondicaoPagamento()
		{
			descricao = string.Empty;
			numParcelas = 0;
		}

		public CondicaoPagamento(string descricao, int numParcelas)
		{
			this.descricao = descricao;
			this.numParcelas = numParcelas;
		}

		public string Descricao { get; set; }
		public int NumParcelas { get; set; } 
	}
}
