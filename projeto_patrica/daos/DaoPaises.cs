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
	internal class DaoPaises : Dao
	{
		public override string Salvar(object obj)
		{
			Pais oPais = (Pais)obj;
			string resultado = "";
			string sql;
			char operacao = 'I';

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
					return "Erro ao conectar ao banco de dados.";

				SqlCommand cmd = new SqlCommand();
				cmd.Connection = cnn;

				if (oPais.Id == 0)
				{
					sql = @"INSERT INTO PAIS 
							(PAIS_NOME, PAIS_SIGLA, PAIS_MOEDA, PAIS_DDI, PAIS_DT_CRIACAO)
							OUTPUT INSERTED.PAIS_ID 
							VALUES (@nome, @sigla, @moeda, @ddi, @dtCriacao)";
				}
				else
				{
					operacao = 'U';
					sql = @"UPDATE PAIS SET 
							PAIS_NOME = @nome, 
							PAIS_SIGLA = @sigla, 
							PAIS_MOEDA = @moeda, 
							PAIS_DDI = @ddi,
							PAIS_DT_ALT = @dtAlt
							WHERE PAIS_ID = @id";
				}

				cmd.CommandText = sql;
				cmd.Parameters.AddWithValue("@nome", oPais.Nome);
				cmd.Parameters.AddWithValue("@sigla", oPais.Sigla);
				cmd.Parameters.AddWithValue("@moeda", oPais.Moeda);
				cmd.Parameters.AddWithValue("@ddi", oPais.Ddi);

				if (oPais.Id == 0)
					cmd.Parameters.AddWithValue("@dtCriacao", oPais.DtCriacao);
				else
				{
					cmd.Parameters.AddWithValue("@dtAlt", oPais.DtAlt);
					cmd.Parameters.AddWithValue("@id", oPais.Id);
				}

				try
				{
					if (operacao == 'I')
						oPais.Id = Convert.ToInt32(cmd.ExecuteScalar());
					else
						cmd.ExecuteNonQuery();

					resultado = oPais.Id.ToString();
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao salvar: " + ex.Message;
				}
			}

			return resultado;
		}

		public List<Pais> ListarPaises()
		{
			List<Pais> lista = new List<Pais>();

			using (SqlConnection conexao = Banco.Abrir())
			{
				if (conexao == null)
					throw new Exception("Erro ao conectar ao Banco de dados.");

				string sql = "SELECT * FROM PAIS";

				using (SqlCommand cmd = new SqlCommand(sql, conexao))
				{
					using (SqlDataReader dr = cmd.ExecuteReader())
					{
						while (dr.Read())
						{
							lista.Add(new Pais
							{
								Id = Convert.ToInt32(dr["PAIS_ID"]),
								Nome = dr["PAIS_NOME"].ToString(),
								Sigla = dr["PAIS_SIGLA"].ToString(),
								Moeda = dr["PAIS_MOEDA"].ToString(),
								Ddi = dr["PAIS_DDI"].ToString(),
								DtCriacao = Convert.ToDateTime(dr["PAIS_DT_CRIACAO"]),
								DtAlt = dr["PAIS_DT_ALT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["PAIS_DT_ALT"])
							});
						}
					}
				}
			}

			return lista;
		}

		public override string Excluir(object obj)
		{
			Pais oPais = (Pais)obj;
			string resultado = "";

			using (SqlConnection cnn = Banco.Abrir())
			{
				if (cnn == null)
					return "Erro ao conectar ao banco de dados.";

				string sql = "DELETE FROM PAIS WHERE PAIS_ID = @id";
				SqlCommand cmd = new SqlCommand(sql, cnn);
				cmd.Parameters.AddWithValue("@id", oPais.Id);

				try
				{
					int rows = cmd.ExecuteNonQuery();
					resultado = (rows > 0) ? "OK" : "País não encontrado.";
				}
				catch (SqlException ex)
				{
					resultado = "Erro ao excluir: " + ex.Message;
				}
			}
			return resultado;
		}
	}
}