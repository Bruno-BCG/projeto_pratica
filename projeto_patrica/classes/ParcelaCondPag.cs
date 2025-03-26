using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class ParcelaCondPag : Pai
	{
		protected int condPagId;
		protected int formPagId;
		protected string formPagDesc;
		protected decimal percentual;
		protected int numeroParcela;
		protected int prazo;

		public ParcelaCondPag()
		{
			condPagId = 0;
			formPagId = 0;
			formPagDesc = string.Empty;
			percentual = 0;
			numeroParcela = 0;
			prazo = 0;
		}

		public ParcelaCondPag(int condPagId, int formPagId, string formPagDesc, decimal percentual, int numeroParcela, int prazo)
		{
			this.condPagId = condPagId;
			this.formPagId = formPagId;
			this.formPagDesc = formPagDesc;
			this.percentual = percentual;
			this.numeroParcela = numeroParcela;
			this.prazo = prazo;
		}

		public int CondPagId { get; set; }
		public int FormPagId { get; set; }
		public string FormPagDesc { get; set; }
		public decimal Percentual { get; set; }
		public int NumeroParcela { get; set; }
		public int Prazo { get; set; }
	}
}
