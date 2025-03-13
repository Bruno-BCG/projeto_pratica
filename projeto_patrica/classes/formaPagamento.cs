using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace projeto_pratica.classes
{
	internal class formaPagamento : pai
	{
		protected string descricao;

		public formaPagamento()
		{
			descricao = string.Empty;
		}
		public formaPagamento (string descricao)
		{
			this.descricao = descricao;
		}
		public string Descricao { get; set; }

		public static string Salvar(formaPagamento pagamento)
		{
			string resultado = "";
			string sql;

			using (SqlConnection conexao = banco.Abrir())
			{
				if (conexao == null)
				{
					return "Erro ao conectar ao banco de dados.";
				}

				if (pagamento.Id == 0) // Insert
				{
					sql = "INSERT INTO FORMA_PAGAMENTO (FORMAPAG_DESC) OUTPUT INSERTED.FORMAPAG_ID VALUES (@Descricao)";
				}
				else // Update
				{
					sql = "UPDATE FORMA_PAGAMENTO SET FORMAPAG_DESC = @Descricao WHERE FORMAPAG_ID = @Id";
				}

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					cmd.Parameters.AddWithValue("@Descricao", pagamento.Descricao);

					if (pagamento.Id != 0)
					{
						cmd.Parameters.AddWithValue("@Id", pagamento.Id);
					}

					try
					{
						if (pagamento.Id == 0)
						{
							pagamento.Id = Convert.ToInt32(cmd.ExecuteScalar());
							resultado = pagamento.Id.ToString();
						}
						else
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
		public static List<formaPagamento> Listar()
		{
			List<formaPagamento> lista = new List<formaPagamento>();

			using (SqlConnection conexao = banco.Abrir())
			{
				if (conexao == null)
				{
					throw new Exception("Erro ao conectar ao banco de dados.");
				}

				using (SqlCommand cmd = new SqlCommand("SELECT * FROM FORMA_PAGAMENTO", conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new formaPagamento
							{
								Id = Convert.ToInt32(dr["FORMAPAG_ID"]),
								Descricao = dr["FORMAPAG_DESC"].ToString()
							});
						}
					}
				}
			}

			return lista;
		}
	}
}
