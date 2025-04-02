using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.classes
{
	internal class Funcionario : Pessoa
	{
		private string matricula;
		private string cargo;
		private double salarioBruto;
		private double salarioLiquido;
		private DateTime dataAdmissao;
		private int cargaHoraria;

		public Funcionario()
		{
			matricula = " ";
			cargo = " ";
			salarioBruto = 0.0;
			salarioLiquido = 0.0;
			dataAdmissao = DateTime.Now;
			cargaHoraria = 0;
		}

		public Funcionario (string matricula, string cargo, double salarioBruto, double salarioLiquido, DateTime dataAdmissao, int cargaHoraria)
		{
			this.matricula = matricula;
			this.cargo = cargo;
			this.salarioBruto = salarioBruto;
			this.salarioLiquido = salarioLiquido;
			this.dataAdmissao = dataAdmissao;
			this.cargaHoraria = cargaHoraria;
		}

		public string Matricula { get; set; }
		public string Cargo { get; set; }
		public double SalarioBruto { get;set; }	
		public double SalarioLiquido { get; set; }
		public DateTime DataAdmissao { get; set; }
		public int CargaHoraria { get; set; }
	}
}
