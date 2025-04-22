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

		public int CondPagId
		{
			get => condPagId;
			set => condPagId = value;
		}

		public int FormPagId
		{
			get => formPagId;
			set => formPagId = value;
		}

		public string FormPagDesc
		{
			get => formPagDesc;
			set => formPagDesc = value;
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
