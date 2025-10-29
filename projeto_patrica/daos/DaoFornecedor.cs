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

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
					return "Erro ao conectar ao banco de dados.";

				if (oFornecedor.Id == 0)
				{
					sql = @"INSERT INTO FORNECEDOR 
					(FORNECEDOR_TIPO, FORNECEDOR_NOME_RS, FORNECEDOR_APELIDO_FANTASIA, FORNECEDOR_NASCIMENTO, 
					 FORNECEDOR_CPF_CNPJ, FORNECEDOR_RG_INSCR, FORNECEDOR_EMAIL, FORNECEDOR_TELEFONE, 
					 ATIVO, FORNECEDOR_ENDERECO, FORNECEDOR_NUM, FORNECEDOR_COMPLEMENTO, 
					 FORNECEDOR_BAIRRO, FORNECEDOR_CEP, CIDADE_ID, CONDPAG_ID, LIMITE_CREDITO, 
					 FORNECEDOR_DT_CRIACAO)
					OUTPUT INSERTED.FORNECEDOR_ID
					VALUES 
					(@tipo, @nomeRS, @apelidoFantasia, @nascimento, 
					 @cpfCnpj, @rgInscr, @email, @telefone, 
					 @ativo, @endereco, @num, @complemento, 
					 @bairro, @cep, @cidadeId, @condPagId, @limiteCredito, 
					 @dtCriacao)";
				}
				else
				{
					sql = @"UPDATE FORNECEDOR SET 
						FORNECEDOR_TIPO = @tipo, 
						FORNECEDOR_NOME_RS = @nomeRS, 
						FORNECEDOR_APELIDO_FANTASIA = @apelidoFantasia, 
						FORNECEDOR_NASCIMENTO = @nascimento, 
						FORNECEDOR_CPF_CNPJ = @cpfCnpj, 
						FORNECEDOR_RG_INSCR = @rgInscr, 
						FORNECEDOR_EMAIL = @email, 
						FORNECEDOR_TELEFONE = @telefone, 
						ATIVO = @ativo, 
						FORNECEDOR_ENDERECO = @endereco,
						FORNECEDOR_NUM = @num,
						FORNECEDOR_COMPLEMENTO = @complemento,
						FORNECEDOR_BAIRRO = @bairro, 
						FORNECEDOR_CEP = @cep,
						CIDADE_ID = @cidadeId,
						CONDPAG_ID = @condPagId,
						LIMITE_CREDITO = @limiteCredito,
						FORNECEDOR_DT_ALT = @dtAlt
						WHERE FORNECEDOR_ID = @id";
				}

				using (SqlCommand cmd = new SqlCommand(sql, cnn))
				{
					cmd.Parameters.AddWithValue("@tipo", oFornecedor.Tipo);
					cmd.Parameters.AddWithValue("@nomeRS", oFornecedor.NomeRazaoSocial);
					cmd.Parameters.AddWithValue("@apelidoFantasia", oFornecedor.ApelidoFantasia);
					cmd.Parameters.AddWithValue("@nascimento", oFornecedor.DataNascimento);
					cmd.Parameters.AddWithValue("@cpfCnpj", oFornecedor.CpfCnpj);
					cmd.Parameters.AddWithValue("@rgInscr", oFornecedor.RgInscricaoEst);
					cmd.Parameters.AddWithValue("@email", oFornecedor.Email);
					cmd.Parameters.AddWithValue("@telefone", oFornecedor.Telefone);
					cmd.Parameters.AddWithValue("@ativo", oFornecedor.Ativo);
					cmd.Parameters.AddWithValue("@cidadeId", oFornecedor.OEndereco.ACidade.Id);
					cmd.Parameters.AddWithValue("@endereco", oFornecedor.OEndereco.Endereco);
					cmd.Parameters.AddWithValue("@num", oFornecedor.OEndereco.Num);
					cmd.Parameters.AddWithValue("@complemento", oFornecedor.OEndereco.Complemento);
					cmd.Parameters.AddWithValue("@bairro", oFornecedor.OEndereco.Bairro);
					cmd.Parameters.AddWithValue("@cep", oFornecedor.OEndereco.Cep);
					cmd.Parameters.AddWithValue("@limiteCredito", oFornecedor.LimiteCredito);
					cmd.Parameters.AddWithValue("@condPagId", oFornecedor.ACondPag.Id);

					if (oFornecedor.Id == 0)
					{
						cmd.Parameters.AddWithValue("@dtCriacao", oFornecedor.DtCriacao);
					}
					else
					{
						cmd.Parameters.AddWithValue("@dtAlt", oFornecedor.DtAlt);
						cmd.Parameters.AddWithValue("@id", oFornecedor.Id);
					}

					try
					{
						if (oFornecedor.Id == 0)
							oFornecedor.Id = Convert.ToInt32(cmd.ExecuteScalar());
						else
							cmd.ExecuteNonQuery();

						resultado = oFornecedor.Id.ToString();
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
			Fornecedor oFornecedor = (Fornecedor)obj;
			string resultado = "";

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
					return "Erro ao conectar ao banco de dados.";

				string sql = "UPDATE FORNECEDOR SET ATIVO = 0 WHERE FORNECEDOR_ID = @id";
				SqlCommand cmd = new SqlCommand(sql, cnn);
				cmd.Parameters.AddWithValue("@id", oFornecedor.Id);

				try
				{
					int rows = cmd.ExecuteNonQuery();
					resultado = (rows > 0) ? "OK" : "Fornecedor não encontrado.";
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao desativar: " + ex.Message;
				}
			}

			return resultado;
		}

		public List<Fornecedor> Listar()
		{
			List<Fornecedor> lista = new List<Fornecedor>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					throw new Exception("Erro ao conectar ao banco de dados.");

				string sql = @"
				SELECT 
					F.FORNECEDOR_ID, F.FORNECEDOR_TIPO, F.FORNECEDOR_NOME_RS, F.FORNECEDOR_APELIDO_FANTASIA,
					F.FORNECEDOR_NASCIMENTO, F.FORNECEDOR_CPF_CNPJ, F.FORNECEDOR_RG_INSCR, F.FORNECEDOR_EMAIL,
					F.FORNECEDOR_TELEFONE, F.ATIVO,
					F.FORNECEDOR_ENDERECO, F.FORNECEDOR_NUM, F.FORNECEDOR_COMPLEMENTO, F.FORNECEDOR_BAIRRO, F.FORNECEDOR_CEP,
					F.CONDPAG_ID, CP.CONDPAG_DESC, F.LIMITE_CREDITO, F.FORNECEDOR_DT_CRIACAO, F.FORNECEDOR_DT_ALT,
					C.CIDADE_ID, C.CIDADE_NOME, C.CIDADE_DDD,
					E.ESTADO_ID, E.ESTADO_NOME, E.ESTADO_UF,
					P.PAIS_ID, P.PAIS_NOME, P.PAIS_SIGLA, P.PAIS_MOEDA, P.PAIS_DDI
				FROM FORNECEDOR F
				INNER JOIN CIDADE C ON F.CIDADE_ID = C.CIDADE_ID
				INNER JOIN ESTADO E ON C.ESTADO_ID = E.ESTADO_ID
				INNER JOIN PAIS P ON E.PAIS_ID = P.PAIS_ID
				INNER JOIN COND_PAGAMENTO CP ON CP.CONDPAG_ID = F.CONDPAG_ID
				WHERE F.ATIVO = 1";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new Fornecedor
							{
								Id = Convert.ToInt32(dr["FORNECEDOR_ID"]),
								Tipo = Convert.ToChar(dr["FORNECEDOR_TIPO"]),
								NomeRazaoSocial = dr["FORNECEDOR_NOME_RS"].ToString(),
								ApelidoFantasia = dr["FORNECEDOR_APELIDO_FANTASIA"].ToString(),
								DataNascimento = Convert.ToDateTime(dr["FORNECEDOR_NASCIMENTO"]),
								CpfCnpj = dr["FORNECEDOR_CPF_CNPJ"].ToString(),
								RgInscricaoEst = dr["FORNECEDOR_RG_INSCR"].ToString(),
								Email = dr["FORNECEDOR_EMAIL"].ToString(),
								Telefone = dr["FORNECEDOR_TELEFONE"].ToString(),
								Ativo = Convert.ToBoolean(dr["ATIVO"]),
								DtCriacao = Convert.ToDateTime(dr["FORNECEDOR_DT_CRIACAO"]),
								DtAlt = dr["FORNECEDOR_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["FORNECEDOR_DT_ALT"]),
								LimiteCredito = Convert.ToDouble(dr["LIMITE_CREDITO"]),
								ACondPag = new CondicaoPagamento
								{
									Id = Convert.ToInt32(dr["CONDPAG_ID"]),
									Descricao = dr["CONDPAG_DESC"].ToString(),
								},
								OEndereco = new Enderecos
								{
									Endereco = dr["FORNECEDOR_ENDERECO"].ToString(),
									Num = dr["FORNECEDOR_NUM"].ToString(),
									Complemento = dr["FORNECEDOR_COMPLEMENTO"].ToString(),
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
        public Fornecedor BuscarPorId(int id)
        {
            Fornecedor forn = null;
            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) return null;

                // (Vou assumir que você também quer carregar a Cidade e CondPag ID)
                string sql = "SELECT * FROM FORNECEDOR WHERE FORNECEDOR_ID = @Id AND ATIVO = 1";
                using (SqlCommand cmd = new SqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            forn = new Fornecedor
                            {
                                Id = Convert.ToInt32(dr["FORNECEDOR_ID"]),
                                NomeRazaoSocial = dr["FORNECEDOR_NOME_RS"].ToString()
                                // ... preencha outras propriedades se necessário
                            };
                        }
                    }
                }
            }
            return forn;
        }
    }
}