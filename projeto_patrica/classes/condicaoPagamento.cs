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
		protected List<ParcelaCondPag> parcelasCondPag;
		public CondicaoPagamento()
		{
			descricao = string.Empty;
			numParcelas = 0;
			parcelasCondPag = new List<ParcelaCondPag>();
		}	

		public CondicaoPagamento(string descricao, int numParcelas, List<ParcelaCondPag> parcelasCondPag)
		{
			this.descricao = descricao;
			this.numParcelas = numParcelas;
			this.parcelasCondPag = parcelasCondPag;
		}

		public string Descricao { get; set; }
		public int NumParcelas { get; set; } 
		public List<ParcelaCondPag> ParcelasCondPag { get => parcelasCondPag; set => parcelasCondPag = value; }
	}
}
