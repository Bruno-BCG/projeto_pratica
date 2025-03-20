using projeto_pratica.classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace projeto_pratica.daos
{
	internal class DaoCondPag : Dao
	{
		public override string Salvar(object obj)
		{
			CondicaoPagamento pagamento = (CondicaoPagamento)obj;
			string resultado = "";
			string sql;

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
				{
					return "Erro ao conectar ao Banco de dados.";
				}

				if (pagamento.Id == 0)
				{
					sql = "INSERT INTO COND_PAGAMENTO (CONDPAG_DESC, CONDPAG_PARCELAS) OUTPUT INSERTED.CONDPAG_ID VALUES (@Descricao, @NumParcelas)";
				}
				else // Update (Registro já existente)
				{
					sql = "UPDATE COND_PAGAMENTO SET CONDPAG_DESC = @Descricao, CONDPAG_PARCELAS = @NumParcelas WHERE CONDPAG_ID = @Id";
				}

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Descricao", pagamento.Descricao);
					cmd.Parameters.AddWithValue("@NumParcelas", pagamento.NumParcelas);

					if (pagamento.Id != 0)
					{
						cmd.Parameters.AddWithValue("@Id", pagamento.Id);
					}

					try
					{
						if (pagamento.Id == 0) // Insert case
						{
							pagamento.Id = Convert.ToInt32(cmd.ExecuteScalar());
							resultado = pagamento.Id.ToString();
						}
						else // Update case
						{
							cmd.ExecuteNonQuery();
							resultado = pagamento.Id.ToString();
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
			CondicaoPagamento pagamento = (CondicaoPagamento)obj; // Cast obj to condicaoPagamento
			string resultado = "";
			string sql = "DELETE FROM COND_PAGAMENTO WHERE CONDPAG_ID = @Id";

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
				{
					return "Erro ao conectar ao Banco de dados.";
				}

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Id", pagamento.Id);

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

		public List<CondicaoPagamento> Listar()
		{
			List<CondicaoPagamento> lista = new List<CondicaoPagamento>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
				{
					throw new Exception("Erro ao conectar ao Banco de dados.");
				}

				using (SqlCommand cmd = new SqlCommand("SELECT * FROM COND_PAGAMENTO", conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new CondicaoPagamento
							{
								Id = Convert.ToInt32(dr["CONDPAG_ID"]),
								Descricao = dr["CONDPAG_DESC"].ToString(),
								NumParcelas = Convert.ToInt32(dr["CONDPAG_PARCELAS"])});
						}
					}
				}
			}
			return lista;
		}
	}
}
