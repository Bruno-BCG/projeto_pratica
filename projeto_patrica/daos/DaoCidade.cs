using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_pratica.classes;
using projeto_pratica.daos;

namespace projeto_pratica
{
    internal class DaoCidade : Dao
    {
        public DaoCidade()
        {
        }
        public override string Salvar(object obj)
        {
			Cidade aCidade = (Cidade)obj;
			string ok = "";
			string sql;
			char operacao = 'I';

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
				{
					return "Erro ao conectar ao banco de dados.";
				}

				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;

				if (aCidade.Id == 0) // INSERT
				{
					sql = "INSERT INTO CIDADE (CIDADE_NOME, CIDADE_DDD, ESTADO_ID) " +
						  "OUTPUT INSERTED.CIDADE_ID " +
						  "VALUES (@nome, @ddd, @estadoId)";
				}
				else // UPDATE
				{
					operacao = 'U';
					sql = "UPDATE CIDADE SET CIDADE_NOME = @nome, CIDADE_DDD = @ddd, ESTADO_ID = @estadoId " +
						  "WHERE CIDADE_ID = @id";
				}

				cmd.CommandText = sql;
				cmd.Parameters.AddWithValue("@nome", aCidade.Nome);
				cmd.Parameters.AddWithValue("@ddd", aCidade.Ddd);
				cmd.Parameters.AddWithValue("@estadoId", aCidade.OEstado.Id);

				if (aCidade.Id != 0)
					cmd.Parameters.AddWithValue("@id", aCidade.Id);

				try
				{
					if (operacao == 'I')
					{
						aCidade.Id = Convert.ToInt32(cmd.ExecuteScalar());
						ok = aCidade.Id.ToString();
					}
					else
					{
						cmd.ExecuteNonQuery();
						ok = aCidade.Id.ToString();
					}
				}
				catch (SqlException ex)
				{
					ok = "Erro ao salvar: " + ex.Message;
				}
			}

			return ok;
		}

        public override string Excluir(object obj)
        {
			Cidade aCidade = (Cidade)obj;
			string resultado = "";

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
				{
					return "Erro ao conectar ao banco de dados.";
				}

				string sql = "DELETE FROM CIDADE WHERE CIDADE_ID = @id";
				SqlCommand cmd = new SqlCommand(sql, cnn);
				cmd.Parameters.AddWithValue("@id", aCidade.Id);

				try
				{
					int rows = cmd.ExecuteNonQuery();
					resultado = (rows > 0) ? "OK" : "Cidade não encontrada.";
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao excluir: " + ex.Message;
				}
			}

			return resultado;
		}

		public List<Cidade> Listar()
		{
			List<Cidade> lista = new List<Cidade>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
				{
					throw new Exception("Erro ao conectar ao Banco de dados.");
				}

				string sql = @"
			SELECT 
				C.CIDADE_ID, C.CIDADE_NOME, C.CIDADE_DDD,
				E.ESTADO_ID, E.ESTADO_NOME, E.ESTADO_UF,
				P.PAIS_ID, P.PAIS_NOME, P.PAIS_SIGLA, P.PAIS_MOEDA, P.PAIS_DDI
			FROM CIDADE C
			INNER JOIN ESTADO E ON C.ESTADO_ID = E.ESTADO_ID
			INNER JOIN PAIS P ON E.PAIS_ID = P.PAIS_ID";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new Cidade
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
							});
						}
					}
				}
			}

			return lista;
		}

	}
}
