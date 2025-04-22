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
	internal class DaoEstado : Dao
	{
		public override string Salvar(object obj)
		{
			Estado oEstado = (Estado)obj;
			string resultado = "";
			string sql;
			char operacao = 'I';

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
					return "Erro ao conectar ao banco de dados.";

				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;

				if (oEstado.Id == 0)
				{
					sql = @"INSERT INTO ESTADO 
							(ESTADO_NOME, ESTADO_UF, PAIS_ID, ESTADO_DT_CRIACAO)
							OUTPUT INSERTED.ESTADO_ID
							VALUES (@nome, @uf, @paisId, @dtCriacao)";
				}
				else
				{
					operacao = 'U';
					sql = @"UPDATE ESTADO SET 
							ESTADO_NOME = @nome, 
							ESTADO_UF = @uf, 
							PAIS_ID = @paisId, 
							ESTADO_DT_ALT = @dtAlt,
							WHERE ESTADO_ID = @id";
				}

				cmd.CommandText = sql;
				cmd.Parameters.AddWithValue("@nome", oEstado.Nome);
				cmd.Parameters.AddWithValue("@uf", oEstado.Uf);
				cmd.Parameters.AddWithValue("@paisId", oEstado.OPais.Id);
				if (oEstado.Id == 0)
					cmd.Parameters.AddWithValue("@dtCriacao", oEstado.DtCriacao);
				else
				{
					cmd.Parameters.AddWithValue("@dtAlt", oEstado.DtAlt);
					cmd.Parameters.AddWithValue("@id", oEstado.Id);
				}

				try
				{
					if (operacao == 'I')
						oEstado.Id = Convert.ToInt32(cmd.ExecuteScalar());
					else
						cmd.ExecuteNonQuery();

					resultado = oEstado.Id.ToString();
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao salvar: " + ex.Message;
				}
			}
			return resultado;
		}

		public override string Excluir(object obj)
		{
			Estado oEstado = (Estado)obj;
			string resultado = "";

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
					return "Erro ao conectar ao banco de dados.";

				string sql = "DELETE FROM ESTADO WHERE ESTADO_ID = @id";
				SqlCommand cmd = new SqlCommand(sql, cnn);
				cmd.Parameters.AddWithValue("@id", oEstado.Id);

				try
				{
					int rows = cmd.ExecuteNonQuery();
					resultado = (rows > 0) ? "OK" : "Estado não encontrado.";
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao excluir: " + ex.Message;
				}
			}
			return resultado;
		}

		public List<Estado> Listar()
		{
			List<Estado> lista = new List<Estado>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					throw new Exception("Erro ao conectar ao Banco de dados.");

				string sql = @"
				SELECT 
					E.ESTADO_ID, E.ESTADO_NOME, E.ESTADO_UF, E.PAIS_ID,
					E.ESTADO_DT_CRIACAO, E.ESTADO_DT_ALT,
					P.PAIS_NOME, P.PAIS_SIGLA, P.PAIS_MOEDA, P.PAIS_DDI
				FROM ESTADO E
				INNER JOIN PAIS P ON E.PAIS_ID = P.PAIS_ID";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new Estado
							{
								Id = Convert.ToInt32(dr["ESTADO_ID"]),
								Nome = dr["ESTADO_NOME"].ToString(),
								Uf = dr["ESTADO_UF"].ToString(),
								DtCriacao = Convert.ToDateTime(dr["ESTADO_DT_CRIACAO"]),
								DtAlt = dr["ESTADO_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["ESTADO_DT_ALT"]),
								OPais = new Pais
								{
									Id = Convert.ToInt32(dr["PAIS_ID"]),
									Nome = dr["PAIS_NOME"].ToString(),
									Sigla = dr["PAIS_SIGLA"].ToString(),
									Moeda = dr["PAIS_MOEDA"].ToString(),
									Ddi = dr["PAIS_DDI"].ToString()
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
