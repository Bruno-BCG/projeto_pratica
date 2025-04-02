using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{
	internal class DaoFuncionario : Dao
	{
		public override string Salvar(object obj)
		{
			Funcionario oFuncionario = (Funcionario)obj;
			string resultado = "";
			string sql;
			char operacao = 'I';

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null) return "Erro ao conectar ao banco de dados.";

				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;

				if (oFuncionario.Id == 0)
				{
					sql = @"INSERT INTO FUNCIONARIO 
						(FUNCIONARIO_TIPO, FUNCIONARIO_NOME, FUNCIONARIO_APELIDO, FUNCIONARIO_NASCIMENTO, 
						 FUNCIONARIO_CPF, FUNCIONARIO_RG, FUNCIONARIO_EMAIL, FUNCIONARIO_TELEFONE, 
						 FUNCIONARIO_STATUS, FUNCIONARIO_ESTRANGEIRO, FUNCIONARIO_ENDERECO, FUNCIONARIO_BAIRRO, FUNCIONARIO_CEP,
						 FUNCIONARIO_MATRICULA, FUNCIONARIO_CARGO, FUNCIONARIO_SALARIO_BRUTO, FUNCIONARIO_SALARIO_LIQUIDO, FUNCIONARIO_DATA_ADMISSAO, FUNCIONARIO_CARGA_HORARIA,
						 CIDADE_ID) 
						OUTPUT INSERTED.FUNCIONARIO_ID
						VALUES 
						(@tipo, @nomeRS, @apelidoFantasia, @nascimento, 
						 @cpfCnpj, @rgInscr, @email, @telefone, 
						 @status, @estrangeiro, @endereco, @bairro, @cep,
						 @matricula, @cargo, @salBruto, @salLiquido, @dataAdm, @cargaHoraria,
						 @cidadeId)";
				}
				else
				{
					operacao = 'U';
					sql = @"UPDATE FUNCIONARIO SET 
						FUNCIONARIO_TIPO = @tipo, FUNCIONARIO_NOME = @nomeRS, FUNCIONARIO_APELIDO = @apelidoFantasia, 
						FUNCIONARIO_NASCIMENTO = @nascimento, FUNCIONARIO_CPF = @cpfCnpj, FUNCIONARIO_RG = @rgInscr, 
						FUNCIONARIO_EMAIL = @email, FUNCIONARIO_TELEFONE = @telefone, FUNCIONARIO_STATUS = @status, 
						FUNCIONARIO_ESTRANGEIRO = @estrangeiro, FUNCIONARIO_ENDERECO = @endereco, FUNCIONARIO_BAIRRO = @bairro, FUNCIONARIO_CEP = @cep,
						FUNCIONARIO_MATRICULA = @matricula, FUNCIONARIO_CARGO = @cargo, FUNCIONARIO_SALARIO_BRUTO = @salBruto,
						FUNCIONARIO_SALARIO_LIQUIDO = @salLiquido, FUNCIONARIO_DATA_ADMISSAO = @dataAdm, FUNCIONARIO_CARGA_HORARIA = @cargaHoraria,
						CIDADE_ID = @cidadeId
						WHERE FUNCIONARIO_ID = @id";
				}

				cmd.CommandText = sql;
				cmd.Parameters.AddWithValue("@tipo", oFuncionario.Tipo);
				cmd.Parameters.AddWithValue("@nomeRS", oFuncionario.Nome_razaoSocial);
				cmd.Parameters.AddWithValue("@apelidoFantasia", oFuncionario.Apelido_nomeFanta);
				cmd.Parameters.AddWithValue("@nascimento", oFuncionario.DataNascimento);
				cmd.Parameters.AddWithValue("@cpfCnpj", oFuncionario.Cpf_cnpj);
				cmd.Parameters.AddWithValue("@rgInscr", oFuncionario.Rg_inscricaoNum);
				cmd.Parameters.AddWithValue("@email", oFuncionario.Email);
				cmd.Parameters.AddWithValue("@telefone", oFuncionario.Telefone);
				cmd.Parameters.AddWithValue("@status", oFuncionario.Status);
				cmd.Parameters.AddWithValue("@estrangeiro", oFuncionario.Estrangeiro);
				cmd.Parameters.AddWithValue("@endereco", oFuncionario.OEndereco.EnderecoCompleto);
				cmd.Parameters.AddWithValue("@bairro", oFuncionario.OEndereco.Bairro);
				cmd.Parameters.AddWithValue("@cep", oFuncionario.OEndereco.Cep);
				cmd.Parameters.AddWithValue("@matricula", oFuncionario.Matricula);
				cmd.Parameters.AddWithValue("@cargo", oFuncionario.Cargo);
				cmd.Parameters.AddWithValue("@salBruto", oFuncionario.SalarioBruto);
				cmd.Parameters.AddWithValue("@salLiquido", oFuncionario.SalarioLiquido);
				cmd.Parameters.AddWithValue("@dataAdm", oFuncionario.DataAdmissao);
				cmd.Parameters.AddWithValue("@cargaHoraria", oFuncionario.CargaHoraria);
				cmd.Parameters.AddWithValue("@cidadeId", oFuncionario.OEndereco.ACidade.Id);

				if (oFuncionario.Id != 0)
					cmd.Parameters.AddWithValue("@id", oFuncionario.Id);

				try
				{
					if (operacao == 'I')
					{
						oFuncionario.Id = Convert.ToInt32(cmd.ExecuteScalar());
						resultado = oFuncionario.Id.ToString();
					}
					else
					{
						cmd.ExecuteNonQuery();
						resultado = oFuncionario.Id.ToString();
					}
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao salvar: " + ex.Message;
				}
			}

			return resultado;
		}

		public override string Excluir(object obj)
		{
			Funcionario oFuncionario = (Funcionario)obj;
			string resultado = "";

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
				{
					return "Erro ao conectar ao banco de dados.";
				}

				string sql = "DELETE FROM FUNCIONARIO WHERE FUNCIONARIO_ID = @id";
				SqlCommand cmd = new SqlCommand(sql, cnn);
				cmd.Parameters.AddWithValue("@id", oFuncionario.Id);

				try
				{
					int rows = cmd.ExecuteNonQuery();
					resultado = (rows > 0) ? "OK" : "Funcionário não encontrado.";
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao excluir: " + ex.Message;
				}
				return resultado;
			}
		}

		public List<Funcionario> Listar()
		{
			List<Funcionario> lista = new List<Funcionario>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
				{
					throw new Exception("Erro ao conectar ao Banco de dados.");
				}

				string sql = @"
							SELECT 
								F.FUNCIONARIO_ID, F.FUNCIONARIO_TIPO, F.FUNCIONARIO_NOME, F.FUNCIONARIO_APELIDO,
								F.FUNCIONARIO_NASCIMENTO, F.FUNCIONARIO_CPF, F.FUNCIONARIO_RG, F.FUNCIONARIO_EMAIL,
								F.FUNCIONARIO_TELEFONE, F.FUNCIONARIO_STATUS, F.FUNCIONARIO_ESTRANGEIRO,
								F.FUNCIONARIO_ENDERECO, F.FUNCIONARIO_BAIRRO, F.FUNCIONARIO_CEP,
								F.FUNCIONARIO_MATRICULA, F.FUNCIONARIO_CARGO, F.FUNCIONARIO_SALARIO_BRUTO,
								F.FUNCIONARIO_SALARIO_LIQUIDO, F.FUNCIONARIO_DATA_ADMISSAO, F.FUNCIONARIO_CARGA_HORARIA,
								C.CIDADE_ID, C.CIDADE_NOME, C.CIDADE_DDD,
								E.ESTADO_ID, E.ESTADO_NOME, E.ESTADO_UF,
								P.PAIS_ID, P.PAIS_NOME, P.PAIS_SIGLA, P.PAIS_MOEDA, P.PAIS_DDI
							FROM FUNCIONARIO F
							INNER JOIN CIDADE C ON F.CIDADE_ID = C.CIDADE_ID
							INNER JOIN ESTADO E ON C.ESTADO_ID = E.ESTADO_ID
							INNER JOIN PAIS P ON E.PAIS_ID = P.PAIS_ID";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new Funcionario
							{
								Id = Convert.ToInt32(dr["FUNCIONARIO_ID"]),
								Tipo = dr["FUNCIONARIO_TIPO"].ToString(),
								Nome_razaoSocial = dr["FUNCIONARIO_NOME"].ToString(),
								Apelido_nomeFanta = dr["FUNCIONARIO_APELIDO"].ToString(),
								DataNascimento = Convert.ToDateTime(dr["FUNCIONARIO_NASCIMENTO"]),
								Cpf_cnpj = dr["FUNCIONARIO_CPF"].ToString(),
								Rg_inscricaoNum = dr["FUNCIONARIO_RG"].ToString(),
								Email = dr["FUNCIONARIO_EMAIL"].ToString(),
								Telefone = dr["FUNCIONARIO_TELEFONE"].ToString(),
								Status = Convert.ToBoolean(dr["FUNCIONARIO_STATUS"]),
								Estrangeiro = Convert.ToBoolean(dr["FUNCIONARIO_ESTRANGEIRO"]),
								Matricula = dr["FUNCIONARIO_MATRICULA"].ToString(),
								Cargo = dr["FUNCIONARIO_CARGO"].ToString(),
								SalarioBruto = Convert.ToDouble(dr["FUNCIONARIO_SALARIO_BRUTO"]),
								SalarioLiquido = Convert.ToDouble(dr["FUNCIONARIO_SALARIO_LIQUIDO"]),
								DataAdmissao = Convert.ToDateTime(dr["FUNCIONARIO_DATA_ADMISSAO"]),
								CargaHoraria = Convert.ToInt32(dr["FUNCIONARIO_CARGA_HORARIA"]),
								OEndereco = new Endereco
								{
									EnderecoCompleto = dr["FUNCIONARIO_ENDERECO"].ToString(),
									Bairro = dr["FUNCIONARIO_BAIRRO"].ToString(),
									Cep = dr["FUNCIONARIO_CEP"].ToString(),
									ACidade = new Cidade
									{
										Id = Convert.ToInt32(dr["CIDADE_ID"]),
										Nome = dr["CIDADE_NOME"].ToString(),
										Ddd = dr["CIDADE_DDD"].ToString(),
										OEstado = new Estado
										{
											Id = Convert.ToInt32(dr["ESTADO_ID"]),
											Nome = dr["ESTADO_NOME"].ToString(),
											Uf = dr["ESTADO_UF"].ToString(),
											OPais = new Pais
											{
												Id = Convert.ToInt32(dr["PAIS_ID"]),
												Nome = dr["PAIS_NOME"].ToString(),
												Sigla = dr["PAIS_SIGLA"].ToString(),
												Moeda = dr["PAIS_MOEDA"].ToString(),
												Ddi = dr["PAIS_DDI"].ToString()
											}
										}
									}
								}
							});
						}
					}
				}
			}

			return lista;
		}
	}
}
