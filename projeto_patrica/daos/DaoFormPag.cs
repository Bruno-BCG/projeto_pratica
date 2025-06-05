using projeto_pratica.classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pratica.daos
{
	internal class DaoFormPag : Dao
	{
		public override string Salvar(object obj)
		{
			FormaPagamento pagamento = (FormaPagamento)obj;
			string resultado = "";
			string sql;

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					return "Erro ao conectar ao Banco de dados.";

				if (pagamento.Id == 0)
				{
					sql = @"INSERT INTO FORMA_PAGAMENTO 
							(FORMAPAG_DESC, FORMAPAG_DT_CRIACAO)
							OUTPUT INSERTED.FORMAPAG_ID 
							VALUES (@Descricao, @DtCriacao)";
				}
				else
				{
					sql = @"UPDATE FORMA_PAGAMENTO SET 
							FORMAPAG_DESC = @Descricao, 
							FORMAPAG_DT_ALT = @DtAlt
							WHERE FORMAPAG_ID = @Id";
				}

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Descricao", pagamento.Descricao);

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
			FormaPagamento pagamento = (FormaPagamento)obj;
			string resultado = "";
			string sql = @"
						UPDATE FORMA_PAGAMENTO 
						SET ATIVO = 0, FORMAPAG_DT_ALT = @dtAlt 
						WHERE FORMAPAG_ID = @Id";

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					return "Erro ao conectar ao Banco de dados.";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Id", pagamento.Id);
					cmd.Parameters.AddWithValue("@dtAlt", DateTime.Now);

					try
					{
						int rowsAffected = cmd.ExecuteNonQuery();
						resultado = (rowsAffected > 0) ? "OK" : "Nenhum registro foi encontrado para exclusão.";
					}
					catch (SqlException ex)
					{
						resultado = "Erro ao excluir: " + ex.Message;
					}
				}
			}
			return resultado;
		}

		public List<FormaPagamento> Listar()
		{
			List<FormaPagamento> lista = new List<FormaPagamento>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					throw new Exception("Erro ao conectar ao Banco de dados.");

				string sql = @"SELECT * FROM FORMA_PAGAMENTO
							   WHERE ATIVO = 1";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new FormaPagamento
							{
								Id = Convert.ToInt32(dr["FORMAPAG_ID"]),
								Descricao = dr["FORMAPAG_DESC"].ToString(),
								DtCriacao = Convert.ToDateTime(dr["FORMAPAG_DT_CRIACAO"]),
								DtAlt = dr["FORMAPAG_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["FORMAPAG_DT_ALT"]),

							});
						}
					}
				}
			}

			return lista;
		}
	}
}