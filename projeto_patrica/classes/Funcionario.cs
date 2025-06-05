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
		private DateTime dataDemissao;
		private string turno;
		private int cargaHoraria;

		public Funcionario() : base()
		{
			matricula = " ";
			cargo = " ";
			salarioBruto = 0.0;
			salarioLiquido = 0.0;
			dataAdmissao = DateTime.Now;
			dataDemissao = DateTime.Now;
			turno = " ";
			cargaHoraria = 0;
		}

		public Funcionario(
			int id, DateTime dtCriacao, DateTime dtAlt, bool ativo,
			char tipo, string nome, string apelido, DateTime nascimento,
			string cpf, string rg, string email, string telefone,
			Enderecos endereco,
			string matricula, string cargo, double salarioBruto, double salarioLiquido,
			DateTime dataAdmissao, DateTime dataDemissao, string turno, int cargaHoraria
		) : base(id, dtCriacao, dtAlt, tipo, nome, apelido, nascimento, cpf, rg, email, telefone, ativo, endereco)
		{
			this.matricula = matricula;
			this.cargo = cargo;
			this.salarioBruto = salarioBruto;
			this.salarioLiquido = salarioLiquido;
			this.dataAdmissao = dataAdmissao;
			this.dataDemissao = dataDemissao;
			this.turno = turno;
			this.cargaHoraria = cargaHoraria;
		}

		public string Matricula
		{
			get => matricula;
			set => matricula = value;
		}

		public string Cargo
		{
			get => cargo;
			set => cargo = value;
		}

		public double SalarioBruto
		{
			get => salarioBruto;
			set => salarioBruto = value;
		}

		public double SalarioLiquido
		{
			get => salarioLiquido;
			set => salarioLiquido = value;
		}

		public DateTime DataAdmissao
		{
			get => dataAdmissao;
			set => dataAdmissao = value;
		}

		public DateTime DataDemissao
		{
			get => dataDemissao;
			set => dataDemissao = value;
		}

		public string Turno
		{
			get => turno;
			set => turno = value;
		}

		public int CargaHoraria
		{
			get => cargaHoraria;
			set => cargaHoraria = value;
		}
	}
}
