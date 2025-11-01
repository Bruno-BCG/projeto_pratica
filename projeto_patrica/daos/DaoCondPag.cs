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

				string sql = @"UPDATE COND_PAGAMENTO 
                       SET ATIVO = 0, CONDPAG_DT_ALT = @DtAlt 
                       WHERE CONDPAG_ID = @Id";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Id", pagamento.Id);
					cmd.Parameters.AddWithValue("@DtAlt", DateTime.Now);

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

				string sql = "SELECT * FROM COND_PAGAMENTO WHERE ATIVO = 1";

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
								Ativo = Convert.ToBoolean(dr["ATIVO"])
							});
						}
					}
				}
			}
			return lista;
		}
        public CondicaoPagamento BuscarPorId(int id)
        {
            CondicaoPagamento condPag = null;
            using (SqlConnection conexao = Banco.Abrir())
            {
                if (conexao == null) return null;

                // 1. Busca a Condição de Pagamento principal
                string sqlCond = "SELECT * FROM COND_PAGAMENTO WHERE ATIVO = 1 AND CONDPAG_ID = @Id";
                using (SqlCommand cmd = new SqlCommand(sqlCond, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            condPag = new CondicaoPagamento
                            {
                                Id = Convert.ToInt32(dr["CONDPAG_ID"]),
                                Descricao = dr["CONDPAG_DESC"].ToString(),
                                NumParcelas = Convert.ToInt32(dr["CONDPAG_PARCELAS"]),
                                Juro = Convert.ToDouble(dr["CONDPAG_JURO"]),
                                Multa = Convert.ToDouble(dr["CONDPAG_MULTA"]),
                                Desconto = Convert.ToDouble(dr["CONDPAG_DESCONTO"]),
                                Ativo = Convert.ToBoolean(dr["ATIVO"])
                            };
                        }
                    }
                }

                // 2. Se encontrou, busca as parcelas
                if (condPag != null)
                {
                    string sqlParcelas = $@"
                        SELECT 
                            P.PARCELA_ID, P.CONDPAG_ID, P.PARCELA_NUM, P.PARCELA_PRAZO, P.PARCELA_PERCT,
                            FP.FORMAPAG_ID, FP.FORMAPAG_DESC
                        FROM PARCELA_CONDPAG P
                        INNER JOIN FORMA_PAGAMENTO FP ON P.FORMAPAG_ID = FP.FORMAPAG_ID
                        WHERE P.CONDPAG_ID = @Id";

                    using (SqlCommand cmd = new SqlCommand(sqlParcelas, conexao))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                condPag.ParcelasCondPag.Add(new ParcelaCondPag
                                {
                                    Id = Convert.ToInt32(dr["PARCELA_ID"]),
                                    CondPagId = condPag.Id,
                                    NumeroParcela = Convert.ToInt32(dr["PARCELA_NUM"]),
                                    Prazo = Convert.ToInt32(dr["PARCELA_PRAZO"]),
                                    Percentual = Convert.ToDecimal(dr["PARCELA_PERCT"]),
                                    AFormPag = new FormaPagamento
                                    {
                                        Id = Convert.ToInt32(dr["FORMAPAG_ID"]),
                                        Descricao = dr["FORMAPAG_DESC"].ToString()
                                    },
                                    Ativo = Convert.ToBoolean(dr["ATIVO"])
                                });
                            }
                        }
                    }
                }
            }
            return condPag;
        }
    }
}