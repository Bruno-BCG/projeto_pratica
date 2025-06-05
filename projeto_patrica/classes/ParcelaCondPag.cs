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
		protected FormaPagamento aFormPag;
		protected decimal percentual;
		protected int numeroParcela;
		protected int prazo;

		public ParcelaCondPag()
		{
			condPagId = 0;
			aFormPag = new FormaPagamento();
			percentual = 0;
			numeroParcela = 0;
			prazo = 0;
		}

		public ParcelaCondPag(int condPagId, FormaPagamento aFormPag, decimal percentual, int numeroParcela, int prazo)
		{
			this.condPagId = condPagId;
			this.aFormPag = aFormPag;
			this.percentual = percentual;
			this.numeroParcela = numeroParcela;
			this.prazo = prazo;
		}

		public int CondPagId
		{
			get => condPagId;
			set => condPagId = value;
		}

		public FormaPagamento AFormPag
		{
			get => aFormPag;
			set => aFormPag = value;
		}

		public decimal Percentual
		{
			get => percentual;
			set => percentual = value;
		}

		public int NumeroParcela
		{
			get => numeroParcela;
			set => numeroParcela = value;
		}

		public int Prazo
		{
			get => prazo;
			set => prazo = value;
		}
	}
}
