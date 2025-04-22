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
		private string descricao;
		private int numParcelas;
		private double juro;
		private double multa;
		private double desconto;

		private List<ParcelaCondPag> parcelasCondPag;

		public CondicaoPagamento() : base()
		{
			descricao = string.Empty;
			numParcelas = 0;
			juro = 0.0;
			multa = 0.0;
			desconto = 0.0;
			parcelasCondPag = new List<ParcelaCondPag>();
		}

		public CondicaoPagamento(
			int id, DateTime dtCriacao, DateTime dtAlt, bool ativo,
			string descricao, int numParcelas, double juro, double multa, double desconto,
			List<ParcelaCondPag> parcelasCondPag
		) : base(id, dtCriacao, dtAlt, ativo)
		{
			this.descricao = descricao;
			this.numParcelas = numParcelas;
			this.juro = juro;
			this.multa = multa;
			this.desconto = desconto;
			this.parcelasCondPag = parcelasCondPag;
		}

		public string Descricao
		{
			get => descricao;
			set => descricao = value;
		}

		public int NumParcelas
		{
			get => numParcelas;
			set => numParcelas = value;
		}

		public double Juro
		{
			get => juro;
			set => juro = value;
		}

		public double Multa
		{
			get => multa;
			set => multa = value;
		}

		public double Desconto
		{
			get => desconto;
			set => desconto = value;
		}

		public List<ParcelaCondPag> ParcelasCondPag
		{
			get => parcelasCondPag;
			set => parcelasCondPag = value;
		}
	}
}
