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
					return "Erro ao conectar ao Banco de dados.";

				if (pagamento.Id == 0)
				{
					sql = @"INSERT INTO COND_PAGAMENTO 
						(CONDPAG_DESC, CONDPAG_PARCELAS, CONDPAG_JURO, CONDPAG_MULTA, CONDPAG_DESCONTO, CONDPAG_DT_CRIACAO)
						OUTPUT INSERTED.CONDPAG_ID
						VALUES (@Descricao, @NumParcelas, @Juro, @Multa, @Desconto, @DtCriacao)";
				}
				else
				{
					sql = @"UPDATE COND_PAGAMENTO SET 
						CONDPAG_DESC = @Descricao,
						CONDPAG_PARCELAS = @NumParcelas,
						CONDPAG_JURO = @Juro,
						CONDPAG_MULTA = @Multa,
						CONDPAG_DESCONTO = @Desconto,
						CONDPAG_DT_ALT = @DtAlt
						WHERE CONDPAG_ID = @Id";
				}

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Descricao", pagamento.Descricao);
					cmd.Parameters.AddWithValue("@NumParcelas", pagamento.NumParcelas);
					cmd.Parameters.AddWithValue("@Juro", pagamento.Juro);
					cmd.Parameters.AddWithValue("@Multa", pagamento.Multa);
					cmd.Parameters.AddWithValue("@Desconto", pagamento.Desconto);

					if (pagamento.Id == 0)
						cmd.Parameters.AddWithValue("@DtCriacao", pagamento.DtCriacao);
					else
					{
						cmd.Parameters.AddWithValue("@DtAlt", pagamento.DtAlt);
						cmd.Parameters.AddWithValue("@Id", pagamento.Id);
					}

					try
					{
						if (pagamento.Id == 0)
							pagamento.Id = Convert.ToInt32(cmd.ExecuteScalar());
						else
							cmd.ExecuteNonQuery();

						resultado = pagamento.Id.ToString();
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
			CondicaoPagamento pagamento = (CondicaoPagamento)obj;
			string resultado = "";

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					return "Erro ao conectar ao Banco de dados.";

				string sql = "DELETE FROM COND_PAGAMENTO WHERE CONDPAG_ID = @Id";
				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Id", pagamento.Id);

					try
					{
						int rows = cmd.ExecuteNonQuery();
						resultado = rows > 0 ? "OK" : "Nenhum registro foi encontrado para exclusão.";
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
					throw new Exception("Erro ao conectar ao Banco de dados.");

				string sql = "SELECT * FROM COND_PAGAMENTO";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new CondicaoPagamento
							{
								Id = Convert.ToInt32(dr["CONDPAG_ID"]),
								Descricao = dr["CONDPAG_DESC"].ToString(),
								NumParcelas = Convert.ToInt32(dr["CONDPAG_PARCELAS"]),
								Juro = Convert.ToDouble(dr["CONDPAG_JURO"]),
								Multa = Convert.ToDouble(dr["CONDPAG_MULTA"]),
								Desconto = Convert.ToDouble(dr["CONDPAG_DESCONTO"]),
								DtCriacao = Convert.ToDateTime(dr["CONDPAG_DT_CRIACAO"]),
								DtAlt = dr["CONDPAG_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["CONDPAG_DT_ALT"]),
							});
						}
					}
				}
			}
			return lista;
		}
	}
}