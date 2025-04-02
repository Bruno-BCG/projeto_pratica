using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Fornecedor : Pessoa
	{
		private string inscrEstadual;

		public Fornecedor()
		{
			inscrEstadual = "";
		}

		public Fornecedor(string inscrEstadual)
		{
			this.inscrEstadual =  inscrEstadual;
		}

		public string InscrEstadual { get; set; }
	}
}
