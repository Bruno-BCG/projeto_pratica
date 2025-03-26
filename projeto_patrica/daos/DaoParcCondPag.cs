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
				{
					return "Erro ao conectar ao Banco de dados.";
				}

				if (parcela.Id == 0) // Insert new record
				{
					sql = "INSERT INTO PARCELA_CONDPAG (CONDPAG_ID, FORMAPAG_ID, PARCELA_PERCT, PARCELA_NUM, PARCELA_PRAZO) " +
						  "OUTPUT INSERTED.PARCELA_ID VALUES (@CondPagId, @FormPagId, @Percentual, @NumeroParcela, @Prazo)";
				}
				else // Update existing record
				{
					sql = "UPDATE PARCELA_CONDPAG SET CONDPAG_ID = @CondPagId, FORMAPAG_ID = @FormPagId, " +
						  "PARCELA_PERCT = @Percentual, PARCELA_NUM = @NumeroParcela, PARCELA_PRAZO = @Prazo " +
						  "WHERE PARCELA_ID = @Id";
				}

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@CondPagId", parcela.CondPagId);
					cmd.Parameters.AddWithValue("@FormPagId", parcela.FormPagId);
					cmd.Parameters.AddWithValue("@Percentual", parcela.Percentual);
					cmd.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
					cmd.Parameters.AddWithValue("@Prazo", parcela.Prazo);

					if (parcela.Id != 0)
					{
						cmd.Parameters.AddWithValue("@Id", parcela.Id);
					}

					try
					{
						if (parcela.Id == 0) // Insert case
						{
							parcela.Id = Convert.ToInt32(cmd.ExecuteScalar());
							resultado = parcela.Id.ToString();
						}
						else // Update case
						{
							cmd.ExecuteNonQuery();
							resultado = parcela.Id.ToString();
						}
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
			string sql = "DELETE FROM PARCELA_CONDPAG WHERE PARCELA_ID = @Id";

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
				{
					return "Erro ao conectar ao Banco de dados.";
				}

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Id", parcela.Id);

					try
					{
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							resultado = "OK"; // Successfully deleted
						}
						else
						{
							resultado = "Nenhum registro foi encontrado para exclusão.";
						}
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
				{
					throw new Exception("Erro ao conectar ao Banco de dados.");
				}

				// Fetch only parcels related to the specified CondPagId
				string sql = @"SELECT p.PARCELA_ID, p.CONDPAG_ID, p.FORMAPAG_ID, p.PARCELA_PERCT, p.PARCELA_NUM, p.PARCELA_PRAZO, f.FORMAPAG_DESC
                       FROM PARCELA_CONDPAG p
                       INNER JOIN FORMA_PAGAMENTO f ON p.FORMAPAG_ID = f.FORMAPAG_ID
                       WHERE p.CONDPAG_ID = @CondPagId";

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
								FormPagId = Convert.ToInt32(dr["FORMAPAG_ID"]),
								Percentual = Convert.ToDecimal(dr["PARCELA_PERCT"]),
								NumeroParcela = Convert.ToInt32(dr["PARCELA_NUM"]),
								Prazo = Convert.ToInt32(dr["PARCELA_PRAZO"]),

								// Assign foreign key descriptions
								FormPagDesc = dr["FORMAPAG_DESC"].ToString()
							});
						}
					}
				}
			}
			return lista;
		}
	}
}
