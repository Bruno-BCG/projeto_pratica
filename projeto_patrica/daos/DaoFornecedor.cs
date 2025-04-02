using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{
	internal class DaoFornecedor : Dao
	{
		public override string Salvar(object obj)
		{
			Fornecedor oFornecedor = (Fornecedor)obj;
			string resultado = "";
			string sql;
			char operacao = 'I';

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null) return "Erro ao conectar ao banco de dados.";

				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;

				if (oFornecedor.Id == 0)
				{
					sql = @"INSERT INTO FORNECEDOR 
						(FORNECEDOR_TIPO, FORNECEDOR_NOME_RS, FORNECEDOR_APELIDO_FANTASIA, FORNECEDOR_NASCIMENTO, 
						 FORNECEDOR_CPF_CNPJ, FORNECEDOR_RG_INSCR, FORNECEDOR_INSCR_ESTADUAL, FORNECEDOR_EMAIL, FORNECEDOR_TELEFONE, 
						 FORNECEDOR_STATUS, FORNECEDOR_ESTRANGEIRO, FORNECEDOR_ENDERECO, FORNECEDOR_BAIRRO, FORNECEDOR_CEP,
						 CIDADE_ID) 
						OUTPUT INSERTED.FORNECEDOR_ID
						VALUES 
						(@tipo, @nomeRS, @apelidoFantasia, @nascimento, 
						 @cpfCnpj, @rgInscr, @inscrEstadual, @email, @telefone, 
						 @status, @estrangeiro, @endereco, @bairro, @cep,
						 @cidadeId)";
				}
				else
				{
					operacao = 'U';
					sql = @"UPDATE FORNECEDOR SET 
						FORNECEDOR_TIPO = @tipo, FORNECEDOR_NOME_RS = @nomeRS, FORNECEDOR_APELIDO_FANTASIA = @apelidoFantasia, 
						FORNECEDOR_NASCIMENTO = @nascimento, FORNECEDOR_CPF_CNPJ = @cpfCnpj, FORNECEDOR_RG_INSCR = @rgInscr, 
						FORNECEDOR_INSCR_ESTADUAL = @inscrEstadual, FORNECEDOR_EMAIL = @email, FORNECEDOR_TELEFONE = @telefone, 
						FORNECEDOR_STATUS = @status, FORNECEDOR_ESTRANGEIRO = @estrangeiro, 
						FORNECEDOR_ENDERECO = @endereco, FORNECEDOR_BAIRRO = @bairro, FORNECEDOR_CEP = @cep,
						CIDADE_ID = @cidadeId
						WHERE FORNECEDOR_ID = @id";
				}

				cmd.CommandText = sql;
				cmd.Parameters.AddWithValue("@tipo", oFornecedor.Tipo);
				cmd.Parameters.AddWithValue("@nomeRS", oFornecedor.Nome_razaoSocial);
				cmd.Parameters.AddWithValue("@apelidoFantasia", oFornecedor.Apelido_nomeFanta);
				cmd.Parameters.AddWithValue("@nascimento", oFornecedor.DataNascimento);
				cmd.Parameters.AddWithValue("@cpfCnpj", oFornecedor.Cpf_cnpj);
				cmd.Parameters.AddWithValue("@rgInscr", oFornecedor.Rg_inscricaoNum);
				cmd.Parameters.AddWithValue("@inscrEstadual", oFornecedor.InscrEstadual);
				cmd.Parameters.AddWithValue("@email", oFornecedor.Email);
				cmd.Parameters.AddWithValue("@telefone", oFornecedor.Telefone);
				cmd.Parameters.AddWithValue("@status", oFornecedor.Status);
				cmd.Parameters.AddWithValue("@estrangeiro", oFornecedor.Estrangeiro);
				cmd.Parameters.AddWithValue("@endereco", oFornecedor.OEndereco.EnderecoCompleto);
				cmd.Parameters.AddWithValue("@bairro", oFornecedor.OEndereco.Bairro);
				cmd.Parameters.AddWithValue("@cep", oFornecedor.OEndereco.Cep);
				cmd.Parameters.AddWithValue("@cidadeId", oFornecedor.OEndereco.ACidade.Id);

				if (oFornecedor.Id != 0)
					cmd.Parameters.AddWithValue("@id", oFornecedor.Id);

				try
				{
					if (operacao == 'I')
					{
						oFornecedor.Id = Convert.ToInt32(cmd.ExecuteScalar());
						resultado = oFornecedor.Id.ToString();
					}
					else
					{
						cmd.ExecuteNonQuery();
						resultado = oFornecedor.Id.ToString();
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
			Fornecedor oFornecedor = (Fornecedor)obj;
			string resultado = "";

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
				{
					return "Erro ao conectar ao banco de dados.";
				}

				string sql = "DELETE FROM FORNECEDOR WHERE FORNECEDOR_ID = @id";
				SqlCommand cmd = new SqlCommand(sql, cnn);
				cmd.Parameters.AddWithValue("@id", oFornecedor.Id);

				try
				{
					int rows = cmd.ExecuteNonQuery();
					resultado = (rows > 0) ? "OK" : "Fornecedor não encontrado.";
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao excluir: " + ex.Message;
				}
				return resultado;
			}
		}
		public List<Fornecedor> Listar()
		{
			List<Fornecedor> lista = new List<Fornecedor>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
				{
					throw new Exception("Erro ao conectar ao banco de dados.");
				}

				string sql = @"
							SELECT 
								F.FORNECEDOR_ID, F.FORNECEDOR_TIPO, F.FORNECEDOR_NOME_RS, F.FORNECEDOR_APELIDO_FANTASIA,
								F.FORNECEDOR_NASCIMENTO, F.FORNECEDOR_CPF_CNPJ, F.FORNECEDOR_RG_INSCR, F.FORNECEDOR_EMAIL,
								F.FORNECEDOR_TELEFONE, F.FORNECEDOR_STATUS, F.FORNECEDOR_ESTRANGEIRO,
								F.FORNECEDOR_ENDERECO, F.FORNECEDOR_BAIRRO, F.FORNECEDOR_CEP,
								F.FORNECEDOR_INSCR_ESTADUAL,
								C.CIDADE_ID, C.CIDADE_NOME, C.CIDADE_DDD,
								E.ESTADO_ID, E.ESTADO_NOME, E.ESTADO_UF,
								P.PAIS_ID, P.PAIS_NOME, P.PAIS_SIGLA, P.PAIS_MOEDA, P.PAIS_DDI
							FROM FORNECEDOR F
							INNER JOIN CIDADE C ON F.CIDADE_ID = C.CIDADE_ID
							INNER JOIN ESTADO E ON C.ESTADO_ID = E.ESTADO_ID
							INNER JOIN PAIS P ON E.PAIS_ID = P.PAIS_ID";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new Fornecedor
							{
								Id = Convert.ToInt32(dr["FORNECEDOR_ID"]),
								Tipo = dr["FORNECEDOR_TIPO"].ToString(),
								Nome_razaoSocial = dr["FORNECEDOR_NOME_RS"].ToString(),
								Apelido_nomeFanta = dr["FORNECEDOR_APELIDO_FANTASIA"].ToString(),
								DataNascimento = Convert.ToDateTime(dr["FORNECEDOR_NASCIMENTO"]),
								Cpf_cnpj = dr["FORNECEDOR_CPF_CNPJ"].ToString(),
								Rg_inscricaoNum = dr["FORNECEDOR_RG_INSCR"].ToString(),
								Email = dr["FORNECEDOR_EMAIL"].ToString(),
								Telefone = dr["FORNECEDOR_TELEFONE"].ToString(),
								Status = Convert.ToBoolean(dr["FORNECEDOR_STATUS"]),
								Estrangeiro = Convert.ToBoolean(dr["FORNECEDOR_ESTRANGEIRO"]),
								InscrEstadual = dr["FORNECEDOR_INSCR_ESTADUAL"].ToString(),
								OEndereco = new Endereco
								{
									EnderecoCompleto = dr["FORNECEDOR_ENDERECO"].ToString(),
									Bairro = dr["FORNECEDOR_BAIRRO"].ToString(),
									Cep = dr["FORNECEDOR_CEP"].ToString(),
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
