using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{
	internal class DaoParcCondPag : Dao
	{
		public override string Salvar(object obj)
		{
			ParcelaCondPag parcela = (ParcelaCondPag)obj;
			string resultado = "";
			string sql;

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					return "Erro ao conectar ao Banco de dados.";

				if (parcela.Id == 0)
				{
					sql = @"INSERT INTO PARCELA_CONDPAG 
					(CONDPAG_ID, FORMAPAG_ID, PARCELA_PERCT, PARCELA_NUM, PARCELA_PRAZO, PARCELA_CONDPAG_DT_CRIACAO, ATIVO)
					OUTPUT INSERTED.PARCELA_ID 
					VALUES (@CondPagId, @FormPagId, @Percentual, @NumeroParcela, @Prazo, 
						    @DtCriacao, @Ativo)";
				}
				else
				{
					sql = @"UPDATE PARCELA_CONDPAG SET 
					CONDPAG_ID = @CondPagId, 
					FORMAPAG_ID = @FormPagId, 
					PARCELA_PERCT = @Percentual, 
					PARCELA_NUM = @NumeroParcela, 
					PARCELA_PRAZO = @Prazo,
					PARCELA_CONDPAG_DT_ALT = @DtAlt
					ATIVO = @Ativo
					WHERE PARCELA_ID = @Id";
				}

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@CondPagId", parcela.CondPagId);
					cmd.Parameters.AddWithValue("@FormPagId", parcela.AFormPag.Id);
					cmd.Parameters.AddWithValue("@Percentual", parcela.Percentual);
					cmd.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
					cmd.Parameters.AddWithValue("@Prazo", parcela.Prazo);
					cmd.Parameters.AddWithValue("@Ativo", parcela.Ativo);

					if (parcela.Id == 0)
						cmd.Parameters.AddWithValue("@DtCriacao", parcela.DtCriacao);
					else
					{
						parcela.DtAlt = DateTime.Now;
						cmd.Parameters.AddWithValue("@DtAlt", parcela.DtAlt);
						cmd.Parameters.AddWithValue("@Id", parcela.Id);
					}

					try
					{
						if (parcela.Id == 0)
							parcela.Id = Convert.ToInt32(cmd.ExecuteScalar());
						else
							cmd.ExecuteNonQuery();

						resultado = parcela.Id.ToString();
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
			ParcelaCondPag parcela = (ParcelaCondPag)obj;
			string resultado = "";

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					return "Erro ao conectar ao Banco de dados.";

				string sql = @"UPDATE PARCELA_CONDPAG 
					   SET ATIVO = 0, PARCELA_CONDPAG_DT_ALT = @DtAlt 
					   WHERE PARCELA_ID = @Id";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Id", parcela.Id);
					cmd.Parameters.AddWithValue("@DtAlt", DateTime.Now);

					try
					{
						int rowsAffected = cmd.ExecuteNonQuery();
						resultado = rowsAffected > 0 ? "OK" : "Nenhum registro foi encontrado para exclusão.";
					}
					catch (SqlException ex)
					{
						resultado = "Erro ao excluir: " + ex.Message;
					}
				}
			}
			return resultado;
		}

		public List<ParcelaCondPag> Listar(int condPagId)
		{
			List<ParcelaCondPag> lista = new List<ParcelaCondPag>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					throw new Exception("Erro ao conectar ao Banco de dados.");

				string sql = @"
					SELECT 
						p.PARCELA_ID, p.CONDPAG_ID, p.FORMAPAG_ID, 
						p.PARCELA_PERCT, p.PARCELA_NUM, p.PARCELA_PRAZO, 
						p.PARCELA_CONDPAG_DT_CRIACAO, p.PARCELA_CONDPAG_DT_ALT,
						f.FORMAPAG_DESC
					FROM PARCELA_CONDPAG p
					INNER JOIN FORMA_PAGAMENTO f ON p.FORMAPAG_ID = f.FORMAPAG_ID
					WHERE p.CONDPAG_ID = @CondPagId AND p.ATIVO = 1";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@CondPagId", condPagId);

					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new ParcelaCondPag
							{
								Id = Convert.ToInt32(dr["PARCELA_ID"]),
								CondPagId = Convert.ToInt32(dr["CONDPAG_ID"]),
								AFormPag = new FormaPagamento
								{
									Id = Convert.ToInt32(dr["FORMAPAG_ID"]),
									Descricao = dr["FORMAPAG_DESC"].ToString()
								},
								Percentual = Convert.ToDecimal(dr["PARCELA_PERCT"]),
								NumeroParcela = Convert.ToInt32(dr["PARCELA_NUM"]),
								Prazo = Convert.ToInt32(dr["PARCELA_PRAZO"]),
								DtCriacao = Convert.ToDateTime(dr["PARCELA_CONDPAG_DT_CRIACAO"]),
								DtAlt = dr["PARCELA_CONDPAG_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["PARCELA_CONDPAG_DT_ALT"]),
								
							});
						}
					}
				}
			}
			return lista;
		}
	}
}