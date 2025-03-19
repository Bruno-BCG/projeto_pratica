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
				{
					return "Erro ao conectar ao Banco de dados.";
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

		public List<FormaPagamento> Listar()
		{
			List<FormaPagamento> lista = new List<FormaPagamento>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
				{
					throw new Exception("Erro ao conectar ao Banco de dados.");
				}

				using (SqlCommand cmd = new SqlCommand("SELECT * FROM FORMA_PAGAMENTO", conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new FormaPagamento
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
