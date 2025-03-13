using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_pratica.classes
{
	internal class condicaoPagamento : pai
	{
		protected string descricao;
		protected int numParcelas;
		public condicaoPagamento()
		{
			descricao = string.Empty;
			numParcelas = 0;
		}

		public condicaoPagamento(string descricao, int numParcelas)
		{
			this.descricao = descricao;
			this.numParcelas = numParcelas;
		}

		public string Descricao { get; set; }
		public int NumParcelas { get; set; }
		public static string Salvar(condicaoPagamento pagamento)
		{
			string resultado = "";
			string sql;

			using (SqlConnection conexao = banco.Abrir())
			{
				if (conexao == null)
				{
					return "Erro ao conectar ao banco de dados.";
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
							resultado = pagamento.Id.ToString();						}
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
		public static List<condicaoPagamento> Listar()
		{
			List<condicaoPagamento> lista = new List<condicaoPagamento>();

			using (SqlConnection conexao = banco.Abrir())
			{
				if (conexao == null)
				{
					throw new Exception("Erro ao conectar ao banco de dados.");
				}

				using (SqlCommand cmd = new SqlCommand("SELECT * FROM COND_PAGAMENTO", conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new condicaoPagamento
							{
								Id = Convert.ToInt32(dr["CONDPAG_ID"]),
								Descricao = dr["CONDPAG_DESC"].ToString(),
								NumParcelas = Convert.ToInt32(dr["CONDPAG_PARCELAS"])
							});
						}
					}
				}
			}

			return lista;
		}
	}
}
