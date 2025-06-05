using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{
	internal class DaoCliente : Dao
	{
		public DaoCliente() { }

		public override string Salvar(object obj)
		{
			Cliente oCliente = (Cliente)obj;
			string resultado = "";
			string sql;

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
					return "Erro ao conectar ao banco de dados.";

				if (oCliente.Id == 0)
				{
					sql = @"INSERT INTO CLIENTE 
				(CLIENTE_TIPO, CLIENTE_NOME_RS, CLIENTE_APELIDO_FANTASIA, CLIENTE_NASCIMENTO, 
				 CLIENTE_CPF_CNPJ, CLIENTE_RG_INSCR, CLIENTE_EMAIL, CLIENTE_TELEFONE, 
				 ATIVO, CLIENTE_ENDERECO, CLIENTE_NUM, CLIENTE_COMPLEMENTO, CLIENTE_BAIRRO, CLIENTE_CEP,
				 CIDADE_ID, CONDPAG_ID, CLIENTE_LIMITE_CREDITO, CLIENTE_DT_CRIACAO)
				OUTPUT INSERTED.CLIENTE_ID
				VALUES 
				(@tipo, @nomeRS, @apelidoFantasia, @nascimento, 
				 @cpfCnpj, @rgInscr, @email, @telefone, 
				 @Ativo, @endereco, @num, @complemento, @bairro, @cep,
				 @cidadeId, @condPagId, @limiteCredito, @dtCriacao)";
				}
				else
				{
					sql = @"UPDATE CLIENTE SET 
				CLIENTE_TIPO = @tipo, 
				CLIENTE_NOME_RS = @nomeRS, 
				CLIENTE_APELIDO_FANTASIA = @apelidoFantasia, 
				CLIENTE_NASCIMENTO = @nascimento, 
				CLIENTE_CPF_CNPJ = @cpfCnpj, 
				CLIENTE_RG_INSCR = @rgInscr, 
				CLIENTE_EMAIL = @email, 
				CLIENTE_TELEFONE = @telefone, 
				CLIENTE_ENDERECO = @endereco,
				CLIENTE_NUM = @num,
				CLIENTE_COMPLEMENTO = @complemento,
				CLIENTE_BAIRRO = @bairro, 
				CLIENTE_CEP = @cep,
				CIDADE_ID = @cidadeId,
				CONDPAG_ID = @condPagId,
				CLIENTE_LIMITE_CREDITO = @limiteCredito,
				CLIENTE_DT_ALT = @dtAlt
				WHERE CLIENTE_ID = @id";
				}

				using (SqlCommand cmd = new SqlCommand(sql, cnn))
				{
					cmd.Parameters.AddWithValue("@tipo", oCliente.Tipo);
					cmd.Parameters.AddWithValue("@nomeRS", oCliente.NomeRazaoSocial);
					cmd.Parameters.AddWithValue("@apelidoFantasia", oCliente.ApelidoFantasia);
					cmd.Parameters.AddWithValue("@nascimento", oCliente.DataNascimento);
					cmd.Parameters.AddWithValue("@cpfCnpj", oCliente.CpfCnpj);
					cmd.Parameters.AddWithValue("@rgInscr", oCliente.RgInscricaoEst);
					cmd.Parameters.AddWithValue("@email", oCliente.Email);
					cmd.Parameters.AddWithValue("@telefone", oCliente.Telefone);
					cmd.Parameters.AddWithValue("@Ativo", oCliente.Ativo);
					cmd.Parameters.AddWithValue("@cidadeId", oCliente.OEndereco.ACidade.Id);
					cmd.Parameters.AddWithValue("@endereco", oCliente.OEndereco.Endereco);
					cmd.Parameters.AddWithValue("@num", oCliente.OEndereco.Num);
					cmd.Parameters.AddWithValue("@complemento", oCliente.OEndereco.Complemento);
					cmd.Parameters.AddWithValue("@bairro", oCliente.OEndereco.Bairro);
					cmd.Parameters.AddWithValue("@cep", oCliente.OEndereco.Cep);
					cmd.Parameters.AddWithValue("@limiteCredito", oCliente.LimiteCredito);
					cmd.Parameters.AddWithValue("@condPagId", oCliente.ACondPag.Id);

					if (oCliente.Id == 0)
					{
						cmd.Parameters.AddWithValue("@dtCriacao", oCliente.DtCriacao);
					}
					else
					{
						cmd.Parameters.AddWithValue("@dtAlt", oCliente.DtAlt);
						cmd.Parameters.AddWithValue("@id", oCliente.Id);
					}

					try
					{
						if (oCliente.Id == 0)
							oCliente.Id = Convert.ToInt32(cmd.ExecuteScalar());
						else
							cmd.ExecuteNonQuery();

						resultado = oCliente.Id.ToString();
					}
					catch (SqlException ex)
					{
						resultado = "Erro ao salvar: " + ex.Message;
					}
				}
			}
			return resultado;
		}

		public override string Excluir(object obj)
		{
			Cliente oCliente = (Cliente)obj;
			string resultado = "";

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
					return "Erro ao conectar ao banco de dados.";

				string sql = "UPDATE CLIENTE SET ATIVO = 0 WHERE CLIENTE_ID = @id";
				SqlCommand cmd = new SqlCommand(sql, cnn);
				cmd.Parameters.AddWithValue("@id", oCliente.Id);

				try
				{
					int rows = cmd.ExecuteNonQuery();
					resultado = (rows > 0) ? "OK" : "Cliente não encontrado.";
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao desativar: " + ex.Message;
				}
			}

			return resultado;
		}

		public List<Cliente> Listar()
		{
			List<Cliente> lista = new List<Cliente>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					throw new Exception("Erro ao conectar ao Banco de dados.");

				string sql = @"
						SELECT 
						CL.CLIENTE_ID, CL.CLIENTE_TIPO, CL.CLIENTE_NOME_RS, 
						CL.CLIENTE_APELIDO_FANTASIA, CL.CLIENTE_NASCIMENTO, 
						CL.CLIENTE_CPF_CNPJ, CL.CLIENTE_RG_INSCR, CL.CLIENTE_EMAIL,
						CL.CLIENTE_TELEFONE, CL.ATIVO,
						CL.CLIENTE_ENDERECO, CL.CLIENTE_BAIRRO, CL.CLIENTE_CEP, 
						CL.CLIENTE_DT_CRIACAO, CL.CLIENTE_DT_ALT, CL.CLIENTE_USR_ALT,
						CL.CONDPAG_ID, CP.CONDPAG_DESC, CL.CLIENTE_LIMITE_CREDITO,
						CL.CLIENTE_COMPLEMENTO, CL.CLIENTE_NUM,
						C.CIDADE_ID, C.CIDADE_NOME, C.CIDADE_DDD,
						E.ESTADO_ID, E.ESTADO_NOME, E.ESTADO_UF,
						P.PAIS_ID, P.PAIS_NOME, P.PAIS_SIGLA, P.PAIS_MOEDA, P.PAIS_DDI
					FROM CLIENTE CL
					INNER JOIN CIDADE C ON CL.CIDADE_ID = C.CIDADE_ID
					INNER JOIN ESTADO E ON C.ESTADO_ID = E.ESTADO_ID
					INNER JOIN PAIS P ON E.PAIS_ID = P.PAIS_ID
					INNER JOIN COND_PAGAMENTO CP ON CP.CONDPAG_ID = CL.CONDPAG_ID
					WHERE CL.ATIVO = 1 ";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new Cliente
							{
								Id = Convert.ToInt32(dr["CLIENTE_ID"]),
								Tipo = Convert.ToChar(dr["CLIENTE_TIPO"]),
								NomeRazaoSocial = dr["CLIENTE_NOME_RS"].ToString(),
								ApelidoFantasia = dr["CLIENTE_APELIDO_FANTASIA"].ToString(),
								DataNascimento = Convert.ToDateTime(dr["CLIENTE_NASCIMENTO"]),
								CpfCnpj = dr["CLIENTE_CPF_CNPJ"].ToString(),
								RgInscricaoEst = dr["CLIENTE_RG_INSCR"].ToString(),
								Email = dr["CLIENTE_EMAIL"].ToString(),
								Telefone = dr["CLIENTE_TELEFONE"].ToString(),
								Ativo = Convert.ToBoolean(dr["ATIVO"]),
								DtCriacao = Convert.ToDateTime(dr["CLIENTE_DT_CRIACAO"]),
								DtAlt = dr["CLIENTE_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CLIENTE_DT_ALT"]),
								LimiteCredito = Convert.ToDouble(dr["CLIENTE_LIMITE_CREDITO"]),
								ACondPag = new CondicaoPagamento
								{
									Id = Convert.ToInt32(dr["CONDPAG_ID"]),
									Descricao = dr["CONDPAG_DESC"].ToString()
								},
								OEndereco = new Enderecos
								{
									Endereco = dr["CLIENTE_ENDERECO"].ToString(),
									Bairro = dr["CLIENTE_BAIRRO"].ToString(),
									Cep = dr["CLIENTE_CEP"].ToString(),
									Complemento = dr["CLIENTE_COMPLEMENTO"].ToString(),
									Num = dr["CLIENTE_NUM"].ToString(),
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